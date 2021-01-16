[CmdletBinding()]
param
(
    [parameter(Mandatory=$false)]
    [switch]$IsDraft,

    [ValidateScript({Test-Path $_ -PathType Leaf})]
    [parameter(Mandatory=$true)]
    [string]$NotesFile,

    [ValidateScript({Test-Path $_ -PathType Leaf})]
    [parameter(Mandatory=$false)]
    [string[]]$Assets
)

function Invoke-GitHub([string]$ghArgs)
{
    $pinfo = New-Object System.Diagnostics.ProcessStartInfo
    $pinfo.FileName = "gh"
    $pinfo.UseShellExecute = $false
    $pinfo.Arguments = $ghArgs
    Write-Verbose -Message $pinfo.Arguments
    $ghProcess = New-Object System.Diagnostics.Process
    $ghProcess.StartInfo = $pinfo
    $null = $ghProcess.Start();
    $ghProcess.WaitForExit();
    return $ghProcess.ExitCode;
}

if ([string]::IsNullOrWhiteSpace($Env:GITHUB_TOKEN))
{
    Write-Error "GITHUB_TOKEN environment variable is missing."
    Exit 1;
}

if ([string]::IsNullOrWhiteSpace($Env:GITHUB_SHA))
{
    Write-Error "GITHUB_SHA is missing."
    Exit 2;
}
$Commitish = $Env:GITHUB_SHA;

if ([string]::IsNullOrWhiteSpace($Env:STRAVAIG_PACKAGE_FULL_VERSION))
{
    Write-Error "STRAVAIG_PACKAGE_FULL_VERSION is missing."
    Exit 3;
}
$TagName = "v" + $Env:STRAVAIG_PACKAGE_FULL_VERSION


if ([string]::IsNullOrWhiteSpace($Env:STRAVAIG_IS_PREVIEW))
{
    Write-Error "STRAVAIG_IS_PREVIEW is missing."
    Exit 4;
}
$IsPrerelease = [System.Convert]::ToBoolean($Env:STRAVAIG_IS_PREVIEW);


$ghArgs = "release create `"$TagName`""
foreach($assetPath in $Assets)
{
    $specificAssets = Get-Item $assetPath;
    foreach($specificAsset in $specificAssets)
    {
        if (-not $specificAsset.PSIsContainer)
        {
            $fileName = $specificAsset.FullName;
            $ghArgs += " `"$fileName`""
        }
        else 
        {
            Write-Verbose "Skipping `"$specificAsset`" as it refers to a directory. Must provide paths to files."
        }
    }
}



$ghArgs += " --title `"Release of $TagName`" --target $Commitish --notes-file `"$NotesFile`""
if ($IsDraft)
{
    $ghArgs += " --draft"
}
if ($IsPrerelease)
{
    $ghArgs += " --prerelease"
}
$exitCode = Invoke-GitHub $ghArgs
if ($exitCode -ne 0)
{
    Write-Error "Failed to create a release."
    Exit $exitCode;
}


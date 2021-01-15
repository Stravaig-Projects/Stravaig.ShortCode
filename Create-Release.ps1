[CmdletBinding()]
param
(
    [parameter(Mandatory=$true)]
    [string]$TagName,

    [parameter(Mandatory=$false)]
    [switch]$IsPrerelease,

    [parameter(Mandatory=$false)]
    [switch]$IsDraft,

    [parameter(Mandatory=$true)] # Will use current commit if not supplied
    [string]$Commitish,

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

$ghArgs = "release create `"$TagName`" --title `"Release of $TagName`" --target $Commitish --notes-file `"$NotesFile`""
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

foreach($assetPath in $Assets)
{
    $specificAssets = Get-Item $assetPath;
    foreach($specificAsset in $specificAssets)
    {
        if (-not $specificAsset.PSIsContainer)
        {
            $fileName = $specificAsset.FullName;
            $ghArgs = "release upload `"$TagName`" `"$fileName`" --clobber"
            $exitCode = Invoke-GitHub $ghArgs
            if ($exitCode -ne 0)
            {
                Write-Warning "Failed to attach `"$fileName`" to the release."
            }
        }
        else 
        {
            Write-Verbose "Skipping `"$specificAsset`" as it refers to a directory. Must provide paths to files."
        }
    }
}

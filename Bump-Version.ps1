[CmdletBinding()]
param (
    [Switch]
    $BumpMajor,
    
    [Switch]
    $BumpMinor,
    
    [Switch]
    $BumpPatch
)

$VersionFile = "$PSScriptRoot/version.txt";
$currentVersion = Get-Content $VersionFile -ErrorAction Stop
if ($null -eq $currentVersion)
{
    Write-Error "The $VersionFile file is empty"
    Exit 1
}
if ($currentVersion.GetType().BaseType.Name -eq "Array")
{
    $currentVersion = $currentVersion[0]
    Write-Warning "$VersionFile contains more than one line of text. Using the first line."
}
if ($currentVersion -notmatch "^[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}$")
{
    Write-Error "The contents of $VersionFile (`"$nextVersion`") not recognised as a valid version number."
    Exit 2
}

$parts = $currentVersion.Split('.');
[int]$major = $parts[0]
[int]$minor = $parts[1]
[int]$patch = $parts[2]

if ($BumpMajor)
{
    $major += 1;
}

if ($BumpMinor)
{
    $minor += 1;
}

if ($BumpPatch)
{
    $patch += 1;
}

$newVersion = "$major.$minor.$patch";

Set-Content $VersionFile $newVersion -Encoding UTF8 -Force
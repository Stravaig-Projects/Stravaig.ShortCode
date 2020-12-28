$fullVersion = $Env:STRAVAIG_PACKAGE_FULL_VERSION

$currentReleaseNotes = Get-Content "$PSScriptRoot/release-notes/wip-release-notes.md";

for($i = 0; $i -lt $currentReleaseNotes.Length; $i++)
{
    $line = $currentReleaseNotes[$i];
    if ($line -eq "## Version X")
    {
        $line = "## Version $fullVersion"
        $currentReleaseNotes[$i] = $line;
    }

    if ($line -eq "Date: ???")
    {
        $line = "Date: "+(Get-Date).ToString("dddd, d MMMM, yyyy 'at' HH:mm:ss zzzz")
        $currentReleaseNotes[$i] = $line;
    }
}

Set-Content "$PSScriptRoot/release-notes/release-notes-$fullVersion.md" $currentReleaseNotes -Encoding UTF8 -Force

$fullReleaseNotes = Get-Content "$PSScriptRoot/release-notes/full-release-notes.md";

$preamble = $fullReleaseNotes[0..1];

$currentReleaseNotesExtractLength = $currentReleaseNotes.Length - 1;
$currentReleaseNotesExtract = $currentReleaseNotes[2..$currentReleaseNotesExtractLength]

$existingLength = $fullReleaseNotes.Length - 1;
$existing = $fullReleaseNotes[2..$existingLength];

$fullReleaseNotes = $preamble + $currentReleaseNotesExtract + $existing

Set-Content "$PSScriptRoot/release-notes/full-release-notes.md" $fullReleaseNotes -Encoding UTF8 -Force

$contributors = Get-Content "$PSScriptRoot/contributors.md";
$releaseBody = $currentReleaseNotes + @("", "---", "") + $contributors
Set-Content "$PSScriptRoot/release-body.md" $releaseBody -Encoding UTF8 -Force


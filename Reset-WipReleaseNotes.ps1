$content = @(
"# Release Notes",
"",
"## Version X",
"",
"Date: ???",
""
"### Bugs"
"",
"### Features",
"",
"### Miscellaneous",
""
)

Set-Content "$PSScriptRoot/release-notes/wip-release-notes.md" $content -Encoding UTF8 -Force
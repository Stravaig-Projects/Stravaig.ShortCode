# This script is licenced under an MIT licence. Licence details can be found at
# https://github.com/Stravaig-Projects/Repo-Contributor-List/blob/master/LICENSE
# Please keep this licence notice link intact.
#
# Full details of this script can be found at:
# https://github.com/Stravaig-Projects/Repo-Contributor-List

param
(
    [parameter(Mandatory=$false)]
    [string]$OutputFile = "contributors.md",

    [parameter(Mandatory=$false)]
    [string]$DateTimeFormat = "dddd, d MMMM, yyyy @ HH:mm:ss zzz",

    [parameter(Mandatory=$false)]
    [string]$TimeFormat = "HH:mm:ss zzz",

    [parameter(Mandatory=$false)]
    [ValidateSet("Name", "FirstCommit", "LastCommit", "CommitCount")]
    [string]$SortOrder = "Name",

    [parameter(Mandatory=$false)]
    [ValidateSet("Ascending", "Descending")]
    [string]$SortDirection = "Ascending",

    [parameter(Mandatory=$false)]
    [System.IO.FileInfo]$AkaFilePath,

    [parameter(Mandatory=$false)]
    [System.IO.FileInfo]$IgnoredNamesPath,

    [parameter(Mandatory=$false)]
    [System.IO.FileInfo]$IgnoredEmailsPath
)

function Test-StringEquality($A, $B)
{
    return [string]::Compare($A, $B, $true) -eq 0
}

function Test-Name($contributor, $committerName)
{
    return $null -ne $contributor.Names.Where({ Test-StringEquality $_ $committerName }, "First", 1)[0];
}

function Test-Email($contributor, $committerEmail)
{
    return $null -ne $contributor.Emails.Where({ Test-StringEquality $_ $committerEmail }, "First", 1)[0];
}

function Test-IgnoredItem($Item, $IgnoredItemsList)
{
    return $null -ne $IgnoredItemsList.Where({ Test-StringEquality $_ $Item }, "First", 1)[0];
}
function Test-Contributor($contributor, $commit)
{
    $nameMatch = Test-Name -Contributor $contributor -Commit $commit.Name;
    if ($nameMatch) {
        return $true;
    }

    $emailMatch = Test-Email -Contributor $contributor -Commit $commit.Email;
    return $emailMatch;
}

function Get-ConfigFilePath($configFilePath, $defaultConfigFilePath, $friendlyName)
{
    $configFileMustExist = $true;
    if ($null -eq $configFilePath)
    {
        $configFileMustExist = $false;
        $configFilePath = $defaultConfigFilePath;
    }

    $pathExists = Test-Path -Path $configFilePath;

    if (-not $pathExists)
    {
        if ($configFileMustExist)
        {
            throw "The `"$friendlyName`" file at $configFilePath does not exist.";
        }
        else
        {
            return $null;
        }
    }
    return $configFilePath;
}

function Get-IgnoredNamesList($IgnoredNamesPath, $AkaContributors)
{
    $result = @();
    foreach($contributor in $AkaContributors)
    {
        foreach($name in $contributor.names)
        {
            $result += $name;
            Write-Verbose "Ignoring name `"$name`"";
        }
    }

    $IgnoredNamesPath = Get-ConfigFilePath -configFilePath $IgnoredNamesPath -defaultConfigFilePath "$PSScriptRoot/.stravaig/list-contributor-ignore-names.txt" -friendlyName "list of ignored names";    
    if ($null -ne $IgnoredNamesPath)
    {
        $ignoredNames = Get-Content -Path $IgnoredNamesPath;
        foreach($name in $ignoredNames)
        {
            $result += $name;
            Write-Verbose "Ignoring name `"$name`"";
        }
    }
    $result = $result | Select-Object -Unique;
    return (,$result);
}

function Get-IgnoredEmailsList($IgnoredEmailsPath, $AkaContributors)
{
    $result = @();
    foreach($contributor in $AkaContributors)
    {
        foreach($email in $contributor.emails)
        {
            $result += $email;
            Write-Verbose "Ignoring email `"$email`"";
        }
    }

    $IgnoredEmailsPath = Get-ConfigFilePath -configFilePath $IgnoredEmailsPath -defaultConfigFilePath "$PSScriptRoot/.stravaig/list-contributor-ignore-emails.txt" -friendlyName "list of ignored email addresses";
    if ($null -ne $IgnoredEmailsPath)
    {
        $ignoredEmails = Get-Content -Path $IgnoredEmailsPath;
        foreach($email in $ignoredEmails)
        {
            $result += $email;
            Write-Verbose "Ignoring email `"$email`"";
        }
    }
    $result = $result | Select-Object -Unique;
    return (,$result);
}

function Get-InitialContributors($AkaFilePath)
{
    $result = @();
    $akaFilePath = Get-ConfigFilePath -configFilePath $akaFilePath -defaultConfigFilePath "$PSScriptRoot/.stravaig/list-contributor-akas.json" -friendlyName "AKA (Also Known As)";
    if ($null -eq $akaFilePath)
    {
        return (,$result);
    }

    try
    {
        $akaDetails = Get-Content -Raw -Path $akaFilePath | ConvertFrom-Json -ErrorAction Stop
    }
    catch
    {
        # For some reason it isn't stopping the script when erroring with 
        # -ErrorAction Stop in the ConvertFrom-Json 
        throw $_
    }

    foreach($person in $akaDetails)
    {
        if ($null -eq $person.primaryName)
        {
            $fragment = $person | ConvertTo-Json;
            throw "Each entry must have a `"primaryPerson`" element.`n$fragment";
        }

        if ($null -eq $person.emails)
        {
            $fragment = $person | ConvertTo-Json;
            throw "Each entry must have a `"emails`" element. If there are no emails supply an empty array.`n$fragment";
        }

        if ($null -eq $person.akas)
        {
            $fragment = $person | ConvertTo-Json;
            throw "Each entry must have a `"akas`" element. If there are no AKAs supply an empty array.`n$fragment";
        }

        $contributor = New-Object -TypeName PSObject -Property @{
            Names=@($person.primaryName);
            PrimaryName = $person.primaryName;
            Emails=@();
            FirstCommit=[DateTime]::MaxValue;
            LastCommit=[DateTime]::MinValue;
            CommitCount=0
        };
        Write-Verbose "Adding name `"$($contributor.PrimaryName)`" as primary name from $akaFilePath.";

        foreach($email in $person.emails)
        {
            if (-not (Test-Email -Contributor $contributor -CommitterEmail $email))
            {
                $contributor.Emails += $email;
                Write-Verbose "Adding email `"$email`" to $($contributor.PrimaryName) from $akaFilePath."
            }
        }

        foreach($name in $person.akas)
        {
            if (-not (Test-Name -Contributor $contributor -CommitterName $name))
            {
                $contributor.Names += $name;
                Write-Verbose "Adding name `"$name`" to $($contributor.PrimaryName) from $akaFilePath."
            }
        }

        $result += $contributor;
    }

    return (,$result);
}

$contributors = Get-InitialContributors -AkaFilePath $AkaFilePath;
$ignoredNamesList = Get-IgnoredNamesList -IgnoredNamesPath $IgnoredNamesPath -AkaContributors $contributors
$ignoredEmailsList = Get-IgnoredEmailsList -IgnoredEmailsPath $IgnoredEmailsPath -AkaContributors $contributors
& git log --format="\`"%ai\`",\`"%an\`",\`"%ae\`",\`"%H\`"" > raw-contributors.csv
$commits = Import-Csv raw-contributors.csv -Header Time,Name,Email,Hash | Sort-Object Time;
Remove-Item .\raw-contributors.csv

$commitsPerPercentPoint = [Math]::Ceiling($commits.Length / 100)
$totalCommits = $commits.Length;
for($i = 0; $i -lt $totalCommits; $i++)
{
    $nextCommit = $commits[$i];
    $commitTime = [DateTime]::ParseExact($nextCommit.Time, "yyyy-MM-dd HH:mm:ss zzz", [CultureInfo]::InvariantCulture);

    if ($i % $commitsPerPercentPoint -eq 0)
    {
        $percent = [Math]::Floor($i / $totalCommits * 100);
        Write-Progress -Activity "Processing" -CurrentOperation "Commit $i of $totalCommits" -PercentComplete $percent
    }

    $contributor = $contributors.Where({Test-Contributor -Contributor $_ -Commit $nextCommit}, "First", 1)[0]
    if ($null -eq $contributor)
    {
        $contributor = New-Object -TypeName PSObject -Property @{
            Names=@($nextCommit.Name);
            PrimaryName = $nextCommit.Name;
            Emails=@($nextCommit.Email); 
            FirstCommit=$commitTime; 
            LastCommit=$commitTime; 
            CommitCount=1
        };
        $contributors += $contributor;
        Write-Verbose "Adding name `"$($nextCommit.Name)`" as primary name from commit $($nextCommit.Hash).";
        Write-Verbose "Adding email `"$($nextCommit.Email)`" to $($contributor.PrimaryName) from commit $($nextCommit.Hash)."
    }
    else
    {
        if ((-not(Test-IgnoredItem -Item $nextCommit.Email -IgnoredItemsList $ignoredEmailsList)) -and 
            (-not (Test-Email -Contributor $contributor -CommitterEmail $nextCommit.Email)))
        {
            Write-Verbose "Adding email `"$($nextCommit.Email)`" to $($contributor.PrimaryName) from commit $($nextCommit.Hash)."
            $contributor.Emails += $nextCommit.Email;
        }
        if ((-not(Test-IgnoredItem -Item $nextCommit.Name -IgnoredItemsList $ignoredNamesList)) -and 
            (-not (Test-Name -Contributor $contributor -CommitterName $nextCommit.Name)))
        {
            Write-Verbose "Adding name `"$($nextCommit.Name)`" to $($contributor.PrimaryName) from commit $($nextCommit.Hash)."
            $contributor.Names += $nextCommit.Name;
        }
        if ($commitTime -lt $contributor.FirstCommit)
        {
            $contributor.FirstCommit = $commitTime;
        }
        if ($commitTime -gt $contributor.LastCommit)
        {
            $contributor.LastCommit = $commitTime
        }
        $contributor.CommitCount += 1;
    }
}
Write-Progress -Activity "Processing" -PercentComplete 100 -Completed

$contributors = $contributors | Where-Object CommitCount -gt 0

$isDescending = $SortDirection -eq "Descending";
Switch($SortOrder)
{
    "Name" { 
        $contributors = $contributors | Sort-Object PrimaryName -Descending:$isDescending;
        $textOrderBy = "contributor name";
    }
    "FirstCommit" {
        $contributors = $contributors | Sort-Object FirstCommit -Descending:$isDescending; 
        $textOrderBy = "first commit date";
    }
    "LastCommit" {
        $contributors = $contributors | Sort-Object LastCommit -Descending:$isDescending; 
        $textOrderBy = "last commit date";
    }
    "CommitCount" {
        $contributors = $contributors | Sort-Object CommitCount -Descending:$isDescending; 
        $textOrderBy = "number of commits";
    }
}


"# Contributors" | Out-File $OutputFile -Encoding utf8
"" | Out-File $OutputFile -Append -Encoding utf8
$line = "This is a list of all the contributors to this repository in "
$line += $SortDirection.ToLower();
"$line order by the $textOrderBy." | Out-File $OutputFile -Append -Encoding utf8
"" | Out-File $OutputFile -Append -Encoding utf8
foreach($contributor in $contributors)
{
    $name = $contributor.PrimaryName;
    $aka = ""
    if ($contributor.Names.Length -gt 1)
    {
        $aka = " (AKA ";
        $isFirst = $true;
        for($i = 1; $i -lt $contributor.Names.Length; $i++)
        {
            if (-not $isFirst) { $aka += ", " }
            $aka += "*"+$contributor.Names[$i]+"*";
            $isFirst = $false
        }
        $aka += ")"
    }
    $numCommits = $contributor.CommitCount
    $commitMsg = "commit"; if ($numCommits -gt 1) { $commitMsg += "s" }
    $start = $contributor.FirstCommit.ToString($DateTimeFormat);
    if ($contributor.FirstCommit.Date -eq $contributor.LastCommit.Date)
    {
        $end = $contributor.LastCommit.ToString($TimeFormat);
    }
    else {
        $end = $contributor.LastCommit.ToString($DateTimeFormat);        
    }
    "**$name**$aka contributed $numCommits $commitMsg" | Out-File $OutputFile -Append -Encoding utf8 -NoNewline
    if ($numCommits -eq 1)
    {
        " on $start." | Out-File $OutputFile -Append -Encoding utf8
    }
    else 
    {
        " from $start to $end." | Out-File $OutputFile -Append -Encoding utf8
    }
    "" | Out-File $OutputFile -Append -Encoding utf8
}
"## Summary" | Out-File $OutputFile -Append -Encoding utf8
"" | Out-File $OutputFile -Append -Encoding utf8

$firstCommit = $commits[0];
$firstCommitMsg = [DateTime]::ParseExact($firstCommit.Time, "yyyy-MM-dd HH:mm:ss zzz", [CultureInfo]::InvariantCulture).ToString($DateTimeFormat);  
$lastCommit = $commits[$totalCommits - 1];
$lastCommitMsg = [DateTime]::ParseExact($lastCommit.Time, "yyyy-MM-dd HH:mm:ss zzz", [CultureInfo]::InvariantCulture).ToString($DateTimeFormat);  

":octocat: $totalCommits commits in total." | Out-File $OutputFile -Append -Encoding utf8
"" | Out-File $OutputFile -Append -Encoding utf8
":date: From $firstCommitMsg." | Out-File $OutputFile -Append -Encoding utf8
"" | Out-File $OutputFile -Append -Encoding utf8
":date: Until $lastCommitMsg." | Out-File $OutputFile -Append -Encoding utf8
"" | Out-File $OutputFile -Append -Encoding utf8

$topCommitters = ($contributors | Sort-Object CommitCount -Descending);
$topCommitter = $topCommitters[0];
$name = $topCommitter.PrimaryName;
$commitCount = $topCommitter.CommitCount;
$percentage = $topCommitter.CommitCount / $totalCommits;

":1st_place_medal: Gold medal to $name with $commitCount commits which represents "+("{0:P2}" -f $percentage)+" of all commits." | Out-File $OutputFile -Append -Encoding utf8
"" | Out-File $OutputFile -Append -Encoding utf8

$topCommitter = $topCommitters[1];
if ($null -ne $topCommitter)
{
    $name = $topCommitter.PrimaryName;
    $commitCount = $topCommitter.CommitCount;
    $percentage = $topCommitter.CommitCount / $totalCommits;
    ":2nd_place_medal: Silver medal to $name with $commitCount commits which represents "+("{0:P2}" -f $percentage)+" of all commits." | Out-File $OutputFile -Append -Encoding utf8
    "" | Out-File $OutputFile -Append -Encoding utf8
}

$topCommitter = $topCommitters[2];
if ($null -ne $topCommitter)
{
    $name = $topCommitter.PrimaryName;
    $commitCount = $topCommitter.CommitCount;
    $percentage = $topCommitter.CommitCount / $totalCommits;
    ":3rd_place_medal: Bronze medal to $name with $commitCount commits which represents "+("{0:P2}" -f $percentage)+" of all commits." | Out-File $OutputFile -Append -Encoding utf8
    "" | Out-File $OutputFile -Append -Encoding utf8
}

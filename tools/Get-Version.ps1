<#
.SYNOPSIS
A tool that gets the latest nuget version from the sproj.

.PARAMETER ProjectPath
The Path to the project.
[Default = ../src/NP.Common/NP.Common.csproj]

#>

param(
[Parameter(Mandatory = $false)]
[string]$ProjectPath)

if([System.String]::IsNullOrWhiteSpace($ProjectPath))
{
    $ProjectPath = [System.IO.Path]::Combine((Split-Path $PSScriptRoot),"src","NP.Common", "NP.Common.csproj");
}

$project = Get-ChildItem $ProjectPath -Filter "*.csproj" -Exclude ("*Tests*") -Recurse | Select-Object -First 1

if($null -eq $project)
{
    Write-Output 'No projects found.'
    return;
}
$xml = [xml](Get-Content $project.FullName)
$currentVersion = [Version]::Parse($xml.Project.PropertyGroup.Version)

return $currentVersion.ToString();
    
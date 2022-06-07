# NP.Common

[![CI Build](https://github.com/NickPolyder/NP.Common/actions/workflows/CI.yml/badge.svg)](https://github.com/NickPolyder/NP.Common/actions/workflows/CI.yml)
[![CD Build](https://github.com/NickPolyder/NP.Common/actions/workflows/CD.yml/badge.svg)](https://github.com/NickPolyder/NP.Common/actions/workflows/CD.yml)
[![Release](https://github.com/NickPolyder/NP.Common/actions/workflows/Release.yml/badge.svg)](https://github.com/NickPolyder/NP.Common/actions/workflows/Release.yml)
[![Nuget](https://img.shields.io/nuget/v/NP.Common?color=blue&logo=nuget&style=flat)](https://www.nuget.org/packages/NP.Common/)

[![Line Coverage](https://raw.githubusercontent.com/NickPolyder/NP.Common/coverage_main/badges/badge_linecoverage.svg)](https://github.com/NickPolyder/NP.Common/releases/tag/coverage_main)
[![Branch Coverage](https://raw.githubusercontent.com/NickPolyder/NP.Common/coverage_main/badges/badge_branchcoverage.svg)](https://github.com/NickPolyder/NP.Common/releases/tag/coverage_main)

The NP.Common library provides common extensions and utilities for coding.

## Installation


To install the package to a project:

```cmd
dotnet add {PROJECT} package NP.Common
```

The package source for dev streams can be added through:

```cmd
dotnet nuget add source --name github "https://nuget.pkg.github.com/NickPolyder/index.json"
```


## Usage

- `Maybe<T>` is a class that acts like a `Nullable<T>` but for both reference and struct types.
- `OR<T1, T2>`, `OR<T1, T2, T3>` is a class set that will hold the reference of one of the generic parameters.

### Extensions 

A set of Extension classes for types like `Collections`, `Dictionaries`, `Enumerables`, `Objects` etc.

### Responses

Responses is a way to control flow without the need to throw exceptions.

## LICENSE

[MIT LICENSE](../../LICENSE)
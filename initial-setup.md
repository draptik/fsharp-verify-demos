# Initial project setup

## Step 1: High-level setup

```sh
touch README.md
touch .editorconfig
touch .gitattributes
mkdir -p src/README.d
mkdir -p tests/README.md
mkdir -p docs/README.md
```

I don't want git to touch my line endings. Add this to `.gitattributes`:

```sh
* -text
```

Create a `.gitignore` file:

```sh
dotnet new gitignore
```

Create a solution file:

```sh
dotnet new sln -n MyDemo
```

Now it's time to create a git repo:

```sh
git init

# If necessary: Configure the git account you want to use (hint: private vs work account)
# I sometimes forget this and have to rewrite the git history after the fact...
# git config --local user.email "..."

git add .
git commit -m "Initial commit"
```

## Step 2: Setup F# projects

A solution might have a lib (`MyDemo.Lib`) and a console (`MyDemo.Ui`) project, 
and a "lib-test" (`"MyDemo.Lib.Tests"`) project.

Create the projects:

```sh
dotnet new classlib -o src/MyDemo.Lib -lang f#
dotnet new console -o src/MyDemo.Ui -lang f#
dotnet new xunit -o test/MyDemo.Lib.Tests -lang f#
```

Wireup: Setup references between projects:

```sh
dotnet add src/MyDemo.Ui reference src/MyDemo.Lib 
dotnet add tests/MyDemo.Lib.Tests reference src/MyDemo.Lib 
```

## Step 3: Add projects to solution

```sh
dotnet sln add src/MyDemo.Lib src/MyDemo.Ui src/MyDemo.Lib.Tests
```

## Step 4: Test setup with IDE

Open the solultion file `MyDemo.sln` in the editor/IDE of your choice.

## Step 5: Update NuGet packages

You can do this from within your IDE or try the tool `dotnet-outdated-tool` from the cli:

```sh
# Install dotnet-outdated-tool
#
# https://blog.elmah.io/updating-nuget-packages-from-command-line-deep-dive/
#
dotnet tool install --global dotnet-outdated-tool

# Use dotnet-outdated
dotnet outdated --upgrade
```

## Summary

### 2023-09-12

```sh
❯ dotnet --info
.NET SDK:
 Version:   7.0.110
 Commit:    ba920f88ac

Runtime Environment:
 OS Name:     arch
 OS Version:
 OS Platform: Linux
 RID:         arch-x64
 Base Path:   /usr/share/dotnet/sdk/7.0.110/

Host:
  Version:      7.0.10
  Architecture: x64
  Commit:       a6dbb800a4

.NET SDKs installed:
  3.1.200 [/usr/share/dotnet/sdk]
  3.1.404 [/usr/share/dotnet/sdk]
  5.0.100 [/usr/share/dotnet/sdk]
  5.0.301 [/usr/share/dotnet/sdk]
  5.0.404 [/usr/share/dotnet/sdk]
  6.0.100-preview.7.21379.14 [/usr/share/dotnet/sdk]
  6.0.101 [/usr/share/dotnet/sdk]
  7.0.110 [/usr/share/dotnet/sdk]

.NET runtimes installed:
  Microsoft.AspNetCore.App 5.0.13 [/usr/share/dotnet/shared/Microsoft.AspNetCore.App]
  Microsoft.AspNetCore.App 6.0.1 [/usr/share/dotnet/shared/Microsoft.AspNetCore.App]
  Microsoft.AspNetCore.App 7.0.10 [/usr/share/dotnet/shared/Microsoft.AspNetCore.App]
  Microsoft.NETCore.App 5.0.13 [/usr/share/dotnet/shared/Microsoft.NETCore.App]
  Microsoft.NETCore.App 6.0.1 [/usr/share/dotnet/shared/Microsoft.NETCore.App]
  Microsoft.NETCore.App 7.0.10 [/usr/share/dotnet/shared/Microsoft.NETCore.App]

Other architectures found:
  None

Environment variables:
  DOTNET_ROOT       [/usr/share/dotnet]

global.json file:
  Not found

Learn more:
  https://aka.ms/dotnet/info

Download .NET:
  https://aka.ms/dotnet/download
```

```sh
❯ dotnet list package
Project 'MyDemo.Lib' has the following package references
   [net7.0]:
   Top-level Package      Requested   Resolved
   > FSharp.Core          7.0.400     7.0.400

Project 'MyDemo.Ui' has the following package references
   [net7.0]:
   Top-level Package      Requested   Resolved
   > FSharp.Core          7.0.400     7.0.400

Project 'MyDemo.Lib.Tests' has the following package references
   [net7.0]:
   Top-level Package                Requested   Resolved
   > coverlet.collector             6.0.0       6.0.0
   > FSharp.Core                    7.0.400     7.0.400
   > Microsoft.NET.Test.Sdk         17.7.2      17.7.2
   > xunit                          2.5.0       2.5.0
   > xunit.runner.visualstudio      2.5.0       2.5.0
```

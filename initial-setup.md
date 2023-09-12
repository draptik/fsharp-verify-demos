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

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
git commit -m"Initial commit"
```


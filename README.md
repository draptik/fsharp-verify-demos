# Experiments using Verify with F#

[Verify](https://github.com/VerifyTests/Verify) is an approval testing framework. 
This type of testing framework is also known as 'Golden Master' or 'Snapshot' testing.

This style of testing is very useful for testing the output at the **boundaries of your application**.

Think more "outside-in" than "inside-out".

Imagine a backend providing a REST API.
You can apply the [Strangler Fig Pattern](https://martinfowler.com/bliki/StranglerFigApplication.html) and replace 
the backend with a new implementation.
The new implementation should provide the same API as the old one.
This is a typical use-case where a framework like Verify shines.

## Motivation

In this project I want to explore how to use Verify with F#.
Verify is a .NET library written in C#.
So, basically, it should just work.

Some methods and classes have to be invoked or wrapped in a special way to make them work with F#.

## Goals

- [x] Invoke Verify with settings placing the output in a specific directory
- [ ] Invoke Verify with settings replacing spaces with underscores in the output file name
- [ ] Find a Diff viewer setup which works with F# and Rider and Linux
  - [x] Meld
  - [x] Rider Verify Plugin
  - [ ] Rider
  - [ ] VS Code

Side note on Diff Viewers: 

VS Code's Diff viewer not only highlights the line, but also the characters which are different.
While porting an app from PHP to C#, this was extremely helpful to find the differences in floating point
numbers ("as long as the precisions is fine up to 8 digits..").

## Example usages in this demo application

See:

- [tests/MyDemo.Lib.Tests/Verifier.fs](tests/MyDemo.Lib.Tests/Verifier.fs)
- [tests/MyDemo.Lib.Tests/Library.Tests.fs](tests/MyDemo.Lib.Tests/Library.Tests.fs)

## Resources

- https://www.planetgeek.ch/2023/03/31/todays-random-f-code-using-verify-to-prevent-breaking-changes-in-stored-data/
- https://tooting.ch/@UrsEnzler/111063884182280956

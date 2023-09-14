[<RequireQualifiedAccess>]
module Verifier

// Solution inspired by Urs: https://tooting.ch/@UrsEnzler/111063884182280956

open Argon
open System.Threading.Tasks
open DiffEngine
open VerifyTests
open VerifyXunit

let inline verify (value: 't :> obj) =
    Verifier.Verify(value :> obj).ToTask() :> Task

let inline verify' (settings: VerifySettings) (value: 't :> obj) =
    Verifier.Verify(value :> obj, settings).ToTask() :> Task

let inline verifyUsingParameters parameters (value: 't :> obj) =
    Verifier.Verify(value :> obj).UseParameters(parameters).ToTask() :> Task
    
let inline verifyUsingParameters' parameters (settings: VerifySettings) (value: 't :> obj) =
    Verifier.Verify(value :> obj, settings).UseParameters(parameters).ToTask() :> Task

// TODO: Not really sure were this info should be placed...
let verifySettings =
    let settings = VerifySettings ()
    settings.UseDirectory "snapshots"
    settings.AddExtraSettings(fun s -> s.NullValueHandling <- NullValueHandling.Include)
    settings

// TODO: Not really sure were this info should be placed...
let initializeDiffTool () =
    // DiffTools.UseOrder(DiffTool.Rider) // This has no effect when used with Rider and Linux?
    // DiffTools.UseOrder(DiffTool.Meld) // Seems to be the default on my system?
    
    // Use Rider plugin `Verify` by right-clicking in the test explorer and selecting
    // 
    //  "Compare Received/Verified"
    // or
    //  "Accept Received"
    //
    DiffRunner.Disabled <- true
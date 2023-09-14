[<RequireQualifiedAccess>]
module Verifier

// Solution from Urs: https://tooting.ch/@UrsEnzler/111063884182280956

open System.Threading.Tasks
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

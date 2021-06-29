open System
open Pictures
open HangLogic.Hangman

type State =
    { mutable Hidden: string
      mutable Secret: string
      mutable Picked': List<char>
      mutable Chances : int}


let init =
    { Hidden = ""
      Secret = "coconut"
      Picked' = []
      Chances = 12}


let mutable currentState : State =
    { init with
          Secret = init.Secret
          Hidden = init.Hidden
          Picked' = init.Picked'
          Chances = init.Chances }

[<EntryPoint>]
let main args =

    while (currentState.Chances > 0) do

        // Picture diplayed
        printfn "%A" HANGMANPICS.[currentState.Chances]
        printfn "\n(exit: ctrl + C) Enter a letter ?: \n"

        // Input
        let mutable pick = char (System.Console.ReadLine())

        if not (List.contains pick currentState.Picked') then
            currentState.Picked' <- pick :: currentState.Picked'
        if not (currentState.Secret.Contains(pick)) then
            currentState.Chances <- currentState.Chances - 1

        currentState.Hidden <-  hideLetters currentState.Secret (conversionType currentState.Picked')
        printfn "-Hidden: %A\n-Secret* %A\n-Picked %A" currentState.Hidden currentState.Secret (presentPickedLetters currentState.Picked')

        match (currentState.Hidden.Contains("_")) with
        | false ->
            printfn "Answome! You win!"
            printfn "%A" DANCING
            Environment.Exit 55
        | true ->
            printfn "Chances left: %A" currentState.Chances

    printfn "%A" FINGER |> ignore
    0

// TODO: hide the secret!
// TODO: random generator de veggies (inside the code) then (micro-services)
// TODO: split side effects from pure functions
// TODO: check if only one char is entered or not null.
//
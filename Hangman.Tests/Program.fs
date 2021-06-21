open Expecto
open Hangman


let hangmanTests =
        testList "HangmanTests" [
            test "[conv] string -> list string" {
                let someResult = splitIntoList "abc"
                Expect.equal someResult ['a'; 'b'; 'c'] "Result is a list of char"
            }

            test "[conv] list string -> string with spaces" {
                let someResult = createWordFromList ['a'; 'b'; 'c']
                Expect.equal someResult "a b c" "Result is a list of char"
            }

        ]


[<EntryPoint>]
let main argv =
    runTestsWithArgs defaultConfig argv hangmanTests
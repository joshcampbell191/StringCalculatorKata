# String Calculator Kata

## Credit

This exercise is based off the [work of Roy Osherove](http://osherove.com/kata)

## Before you start

- Do not read ahead
- Do one task at a time
- Refactor as necessary
- Do not handle invalid inputs
- Check in often
- Tests are your friends

## Getting Started

Clone the [branch from here](https://transport-canada@dev.azure.com/transport-canada/Public/_git/StringCalculatorKata)

Create and push a branch under `attempts/` now. Ideally you can call it `<first name>_<last name>` (eg. `attempts/philippe_castonguay`)

You will be building a String Calculator. The initial branch contains the following projects:

- Product - The String Calculator you will be developing, with the initial function stub
- Product.Tests - An XUnit test file with one failing test
- Product.CLI - A simple console application that will run the calculator and show the results

Only expand the details once you have completed the previous step, to avoid looking ahead

<details>
    <summary>0. Base case</summary>
    Start with the base case. 

    Eg. 
    "" → 0
</details>

<details>
    <summary>1. Loneliest</summary>
    When one number is passed, return that number for the sum

    Eg. 
    "1" → 1
    "10" → 10
</details>

<details>
    <summary>2. Basics</summary>
    When two numbers are passed, separated by a plus '+', return their sum
    
    Eg.
    "1+1" → 2
    "12+34" → 36
</details>

<details>
    <summary>3. N</summary>
    Allow any number of numbers to be passed, and add ',' as a delimiter

    Eg.
    "1,2,3" → 6
    "1,1,1,1,1" → 5
</details>

<details>
    <summary>4. NL</summary>
    Allow the new line character (\n) to be used as a delimiter as well

    Eg.
    "1\n2" → 3
</details>

<details>
    <summary>5. Custom</summary>
    Allow optional custom delimiters, in the format of "//{delimiter}{numbers}" (It should continue to work without the delimiters)

    Eg.
    "//;1;2" → 3
</details>

<details>
    <summary>6. Negative</summary>
    When a negative is passed, throw an Exception with the message "Negatives not allowed ({number})", where number is the first negative number that was encountered

    Eg.
    "-1" → "Negatives not allowed (-1)"
</details>

<details>
    <summary>7. Numerous</summary>
    When multiple negatives are passed, return the comma-separated list of all the negatives in the order they were presented, instead of just the first one

    Eg.
    "-1,-2" → "Negatives not allowed (-1,-2)"
</details>

<details>
    <summary>8. Mille</summary>
    Ignore numbers greater than 1000

    Eg.
    "1,1005" → 1
</details>

<details>
    <summary>9. Delimited</summary>
    Allow for delimiters of any length, using the format "//[{delimiter}]{numbers}". (The previous delimiter method should continue to work)

    Eg.
    "//[***]1***2***3" → 6
</details>

<details>
    <summary>10. Unlimiated</summary>
    Allow for multiple long delimiters, using the format "//[{delimiter1}][{delimiter2}][{...}]{numbers}".

    Eg.
    "//[*][%]1*2%3" → 6
</details>

<details>
    <summary>11. Revision</summary>
    Ensure that you can use multiple and long delimiters

    Eg.
    "//[***][%%%]1***2%%%3" → 6
</details>

<details>
    <summary>12. Conclusion</summary>
    Woohoo! You're done! Check it in and reflect.

</details>
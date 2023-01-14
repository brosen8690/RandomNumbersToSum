# RandomNumbersToSum
Generates X random numbers that equal the sum of Y.

In creating mock data, I often come across situations where we have a group of entities where properties among them all need to add up to X. For example, 5 items with a percent property that need to equal 100% across the 5 of them. Assigning 20% to each of them isn't always realistic, so here's a simple extension method to randomize it a bit better.

### TODO

The current implementation is not good, since the numbers will trend large -> small with each iteration of the loop. Some sort of weighting system will be worked on to give a more realistic spread.

An out of bounds exception will be thrown if the count is greater than the sum.

Maybe just don't use this until I have more time to work on it.

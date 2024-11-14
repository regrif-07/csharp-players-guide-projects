using Utility;

var sievePredicate = new ConsoleMenuBuilder<Predicate<int>>()
    .SetTitle("Select the sieve filter:")
    .AddItems(IsEven, IsPositive, IsMultipleOf10)
    .SetFixedItemNames("Only even", "Only positive", "Only multiples of 10")
    .Build()
    .StartMenuForSelectedItem();

var sieve = new Sieve(sievePredicate);

Console.WriteLine("\nEnter the numbers and they will be processed by the sieve:");
while (true)
{
    var userNumber = InputUtility.AskUserForValue<int>("> ");
    Console.WriteLine(sieve.IsGood(userNumber));
}

bool IsEven(int number) => number % 2 == 0;
bool IsPositive(int number) => number > 0;
bool IsMultipleOf10(int number) => number % 10 == 0;
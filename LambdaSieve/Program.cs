using Utility;

var sievePredicate = new ConsoleMenuBuilder<Predicate<int>>()
    .SetTitle("Select the sieve filter:")
    .AddItems(n => n % 2 == 0,
              n => n > 0, 
              n => n % 10 == 0)
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
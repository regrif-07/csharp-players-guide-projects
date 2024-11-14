using Utility;

var num = InputUtility.AskUserForValue<int>("Enter the number to be processed by the clocktower: ");
Console.WriteLine(num % 2 == 0 ? "Tick" : "Tock");

//if (num % 2 == 0)
//{
//    Console.WriteLine("Tick");
//}
//else
//{
//    Console.WriteLine("Tock.");
//}
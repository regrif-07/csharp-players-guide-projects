using Utility;

const int SistersNum = 4;

var chocolateEggsNum = InputUtility.AskUserForValue<int>("Enter the number of chocolate eggs gathered: ");

var chocolateEggsPerSister = chocolateEggsNum / SistersNum;
var chocolateEggsForDuckbear = chocolateEggsNum % SistersNum;

Console.WriteLine($"Chocolate eggs per sister: {chocolateEggsPerSister}");
Console.WriteLine($"Chocolate eggs for duckbear: {chocolateEggsForDuckbear}");
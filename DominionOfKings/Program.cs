using Utility;

const int PointsPerProvince = 6;
const int PointsPerDuchy = 3;
const int PointsPerEstate = 1;

var provincesNum = InputUtility.AskUserForValue<int>("How many provinces do you have? ");
var duchiesNum = InputUtility.AskUserForValue<int>("How many duchies do you have? ");
var estatesNum = InputUtility.AskUserForValue<int>("How many estates do you have? ");

var totalScore = (provincesNum * PointsPerProvince) + (duchiesNum * PointsPerDuchy) + (estatesNum * PointsPerEstate);
Console.WriteLine($"Your total score is: {totalScore}");
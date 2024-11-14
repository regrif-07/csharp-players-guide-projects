var firstCoordinate  = new Coordinate(0, 0);
var secondCoordinate = new Coordinate(1, 0);
var thirdCoordinate  = new Coordinate(2, 0);

Console.WriteLine($"{firstCoordinate} is adjacent to {secondCoordinate}? {firstCoordinate.IsAdjacentTo(secondCoordinate)}");
Console.WriteLine($"{firstCoordinate} is adjacent to {thirdCoordinate}? {firstCoordinate.IsAdjacentTo(thirdCoordinate)}");
Console.WriteLine($"{secondCoordinate} is adjacent to {thirdCoordinate}? {secondCoordinate.IsAdjacentTo(thirdCoordinate)}");

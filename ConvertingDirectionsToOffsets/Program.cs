var originCoord = new BlockCoordinate(0, 0);

Console.WriteLine(originCoord + new BlockOffset(1, -5));
Console.WriteLine(originCoord + Direction.South);
Console.WriteLine((originCoord + Direction.North)[0]);
Console.WriteLine((BlockOffset)Direction.West);

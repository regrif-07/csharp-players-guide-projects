sbyte mySbyte = 0;
short myShort = 0;
int myInt = 0;
long myLong = 0;

byte myByte = 0;
ushort myUShort = 0;
uint myUInt = 0;
ulong myULong = 0;

char myChar = 'a';
string myString = "aaa";

float myFloat = 0.0f;
double myDouble = 0.0;
decimal myDecimal = 0m;

bool myBool = false;

Console.WriteLine("Signed integer types:");
Console.WriteLine($"sbyte: {mySbyte}");
Console.WriteLine($"short: {myShort}");
Console.WriteLine($"int: {myInt}");
Console.WriteLine($"long: {myLong}");
Console.WriteLine();

Console.WriteLine("Unsigned integer types:");
Console.WriteLine($"byte: {myByte}");
Console.WriteLine($"ushort: {myUShort}");
Console.WriteLine($"uint: {myUInt}");
Console.WriteLine($"ulong: {myULong}");
Console.WriteLine();

Console.WriteLine("Character and string types:");
Console.WriteLine($"char: {myChar}");
Console.WriteLine($"string: {myString}");
Console.WriteLine();

Console.WriteLine("Floating-point types:");
Console.WriteLine($"float: {myFloat}");
Console.WriteLine($"double: {myDouble}");
Console.WriteLine($"decimal: {myDecimal}");
Console.WriteLine();

Console.WriteLine("Boolean type:");
Console.WriteLine($"bool: {myBool}");
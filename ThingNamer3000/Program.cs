// better variable names will make this program more understandable

Console.WriteLine("What kind of thing are we talking about?");
string a = Console.ReadLine(); // the kind of thing (e.g. banana)
Console.WriteLine("How would you describe it? Big? Azure? Tattered?");
string b = Console.ReadLine(); // characteristic of that thing (e.g. yellow)
string c = "Doom"; /* Name part #1 */
string d = "3000"; /* Name part #2 */
Console.WriteLine("The " + b + " " + a + " of " + c + " " + d + "!");
using ExceptisGame;

var exceptisGame = new Game(new Player("Player #1"), new Player("Player #2"));

try
{
    exceptisGame.StartGame();
}
catch (GameEndException e)
{
    Console.WriteLine($"\n{e.Winner.Name} won!");
}
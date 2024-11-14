var cardColors = Enum.GetValues<CardColor>();
var cardRanks = Enum.GetValues<CardRank>();

List<Card> cardsDeck = new(cardColors.Length * cardRanks.Length);
foreach (var cardColor in cardColors)
{
    foreach (var cardRank in cardRanks)
    {
        cardsDeck.Add(new Card(cardColor, cardRank));
    }
}

foreach (var card in cardsDeck)
{
    Console.WriteLine(card);
}

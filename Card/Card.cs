internal class Card
{
    public Card(CardColor color, CardRank rank)
    {
        Color = color;
        Rank = rank;
    }

    public CardColor Color { get; }
    public CardRank Rank { get; }

    public bool IsNumberCard() => (int)Rank < 10;
    public bool IsSymbolCard() => !IsNumberCard();

    public override string ToString() => $"{Color.GetSymbol()}{Rank.GetSymbol()}";
}
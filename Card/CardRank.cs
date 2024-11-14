internal enum CardRank
{
    Rank1,
    Rank2,
    Rank3,
    Rank4,
    Rank5,
    Rank6,
    Rank7,
    Rank8,
    Rank9,
    Rank10,
    RankDollar,
    RankPercent,
    RankHat,
    RankAmpersand,
}

internal static class CardRankExtensions
{
    public static string GetSymbol(this CardRank rank) => rank switch
    {
        CardRank.Rank1 => "1",
        CardRank.Rank2 => "2",
        CardRank.Rank3 => "3",
        CardRank.Rank4 => "4",
        CardRank.Rank5 => "5",
        CardRank.Rank6 => "6",
        CardRank.Rank7 => "7",
        CardRank.Rank8 => "8",
        CardRank.Rank9 => "9",
        CardRank.Rank10 => "10",
        CardRank.RankDollar => "$",
        CardRank.RankPercent => "%",
        CardRank.RankHat => "^",
        CardRank.RankAmpersand => "&",
        _ => throw new NotImplementedException()
    };
}

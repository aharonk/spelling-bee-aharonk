namespace SpellingBeeModel;

public enum Rank // value is percentage of words needed to reach that rank. Unfortunately can't be float
{
    Beginner = 0,
    GoodStart = 2,
    MovingUp = 5,
    Good = 8,
    Solid = 15,
    Nice = 25,
    Great = 40,
    Amazing = 50,
    Genius = 70
}

public static class RankExtensions
{
    public static string ScreenName(this Rank r)
    {
        return r switch
        {
            Rank.GoodStart => "Good Start",
            Rank.MovingUp => "Moving Up",
            _ => r.ToString()
        };
    }
}
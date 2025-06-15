namespace Application.SimpleBowlingGame;

internal record SimpleFrame : IBowlingFrame
{
    public bool IsStrike => FirstRoll.HasValue && FirstRoll == 10;
    public bool IsSpare => FirstRoll.HasValue && SecondRoll.HasValue && FirstRoll + SecondRoll == 10;
    public int? FirstRoll { get; set; }
    public int? SecondRoll { get; set; }
    public int? Score
    {
        get
        {
            if (!FirstRoll.HasValue)
            {
                return null;
            }

            var score = FirstRoll + SecondRoll.GetValueOrDefault();

            if (IsStrike)
            {
                score += TrailingFrame?.FirstRoll.GetValueOrDefault() + TrailingFrame?.SecondRoll.GetValueOrDefault();

                if (TrailingFrame?.IsStrike is true)
                {
                    score += TrailingFrame.TrailingFrame?.FirstRoll.GetValueOrDefault();
                }
            }
            else if (IsSpare)
            {
                score += TrailingFrame?.FirstRoll;
            }

            return score;
        }
    }
    public SimpleFrame? TrailingFrame { get; set; } // For strike handling
}
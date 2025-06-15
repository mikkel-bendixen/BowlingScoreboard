namespace Application.BowlingGameChain;

internal class DefaultRollHandler : RollHandler, IBowlingFrame
{
    public override int? FirstRoll => firstRoll;
    public override int? SecondRoll => secondRoll;
    public override int? Score => FirstRoll.GetValueOrDefault() + SecondRoll.GetValueOrDefault() + Bonus1.GetValueOrDefault() + Bonus2.GetValueOrDefault();
    protected int? Bonus1 { get; private set; }
    protected int? Bonus2 { get; private set; }
    protected bool FrameCompleted => FirstRoll.HasValue && SecondRoll.HasValue || IsStrike;
    protected bool IsStrike => FirstRoll.HasValue && FirstRoll == 10;
    protected bool IsSpare => FirstRoll.HasValue && SecondRoll.HasValue && FirstRoll + SecondRoll == 10;

    private int? firstRoll;
    private int? secondRoll;

    public override void Handle(int pins)
    {
        if (FrameCompleted)
        {
            AddBonusIfEligible(pins);
            Successor?.Handle(pins);
        }
        else if (FirstRoll is null)
        {
            firstRoll = pins;
        }
        else if (FirstRoll.Value + pins > 10)
        {
            throw new Exception($"It is not possible to roll {pins} pins, when there are only {10 - FirstRoll.Value} pins remaining");
        }
        else
        {
            secondRoll = pins;
        }
    }

    private void AddBonusIfEligible(int pins)
    {
        if (IsStrike)
        {
            if (Bonus1 is null)
            {
                Bonus1 = pins;
            }
            else if (Bonus2 is null)
            {
                Bonus2 = pins;
            }
        }
        else if (IsSpare)
        {
            if (Bonus1 is null)
            {
                Bonus1 = pins;
            }
        }
    }
}

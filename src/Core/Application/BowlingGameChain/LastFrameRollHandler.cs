namespace Application.BowlingGameChain;

internal class LastFrameRollHandler : DefaultRollHandler
{
    public override void Handle(int pins)
    {
        if (FrameCompleted && IsAllBonusRollsCompleted())
        {
            throw new Exception("Game Over");     
        }     
        
        base.Handle(pins);
    }

    private bool IsAllBonusRollsCompleted()
    {
        if (IsStrike)
        {
            if (Bonus1 is not null && Bonus2 is not null)
            {
                return true;
            }
        }
        else if (IsSpare)
        {
            if (Bonus1 is not null)
            {
                return true;
            }
        }
        else
        {
            return true;
        }

        return false;
    }


}

namespace Application;

public class BowlingGameChain : IBowlingGame
{
    private const int TotalFrames = 10;
    public IReadOnlyCollection<IBowlingFrame> Frames => frames;
    public int Score => frames.Sum(frame => frame.Score ?? 0);

    private List<IBowlingFrame> frames = [];

    private RollHandler rollHandler;
    public BowlingGameChain()
    {
        var chain = CreateChain().ToList();
        frames = chain.Cast<IBowlingFrame>().ToList();
        rollHandler = chain.First();
    }

    public void Roll(int pins)
    {
        rollHandler.Handle(pins);
    }

    private IEnumerable<RollHandler> CreateChain()
    {
        RollHandler? lastHandler = null;
        for (int i = 0; i < TotalFrames; i++)
        {
            RollHandler handler = i < TotalFrames - 1 ? new DefaultRollHandler() : new LastFrameRollHandler();
            rollHandler ??= handler;
            lastHandler?.SetNext(handler);
            lastHandler = handler;
            yield return handler;
        }
    }
}

internal abstract class RollHandler : IBowlingFrame
{
    public abstract int? FirstRoll { get; protected set;  }

    public abstract int? SecondRoll { get; protected set; }

    public abstract int? Score { get; }
    protected RollHandler? Successor = null;

    public void SetNext(RollHandler successor)
    {
        Successor = successor;
    }
    public abstract void Handle(int pins);
}

internal class LastFrameRollHandler : RollHandler
{
    public override int? FirstRoll { get; protected set; }
    public override int? SecondRoll { get; protected set; }
    public override int? Score => FirstRoll.GetValueOrDefault() + SecondRoll.GetValueOrDefault() + bonus1.GetValueOrDefault() + bonus2.GetValueOrDefault();

    private bool FrameCompleted => FirstRoll.HasValue && SecondRoll.HasValue || IsStrike;
    private bool IsStrike => FirstRoll.HasValue && FirstRoll == 10;
    private bool IsSpare => FirstRoll.HasValue && SecondRoll.HasValue && (FirstRoll + SecondRoll == 10);
    private int? bonus1;
    private int? bonus2;

    public override void Handle(int pins)
    {
        if (FrameCompleted)
        {
            if (IsStrike)
            {
                if (bonus1 is null)
                {
                    bonus1 = pins;
                }
                else if (bonus2 is null)
                {
                    bonus2 = pins;
                }
                else
                {
                    throw new Exception("Game Over");
                }
            }
            else if (IsSpare)
            {
                if (bonus1 is null)
                {
                    bonus1 = pins;
                }
                else
                {
                    throw new Exception("Game Over");
                }
            }
            else
            {
                throw new Exception("Game Over");
            }

            Successor?.Handle(pins);
            return;
        }

        if (FirstRoll is null)
        {
            FirstRoll = pins;
        }
        else if (FirstRoll.Value + pins > 10)
        {
            throw new Exception($"It is not possible to roll {pins} pins, when there are only {10 - FirstRoll.Value} pins remaining");
        }
        else
        {
            SecondRoll = pins;
        }
    }
}

internal class DefaultRollHandler : RollHandler, IBowlingFrame
{
    public override int? FirstRoll { get; protected set; }
    public override int? SecondRoll { get; protected set; }
    public override int? Score => FirstRoll.GetValueOrDefault() + SecondRoll.GetValueOrDefault() + Bonus1.GetValueOrDefault() + Bonus2.GetValueOrDefault();
    private bool FrameCompleted => FirstRoll.HasValue && SecondRoll.HasValue || IsStrike;
    private bool IsStrike => FirstRoll.HasValue && FirstRoll == 10;
    private bool IsSpare => FirstRoll.HasValue && SecondRoll.HasValue && (FirstRoll + SecondRoll == 10);

    public int? Bonus1 { get; private set; }
    public int? Bonus2 { get; private set; }

    public override void Handle(int pins)
    {
        if (FrameCompleted)
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

            Successor?.Handle(pins);
            return;
        }

        if (FirstRoll is null)
        {
            FirstRoll = pins;
        }
        else if (FirstRoll.Value + pins > 10)
        {
            throw new Exception($"It is not possible to roll {pins} pins, when there are only {10 - FirstRoll.Value} pins remaining");
        }
        else
        {
            SecondRoll = pins;
        }
    }
}

namespace Application;

public class BowlingGameChain : IBowlingGame
{
    public IReadOnlyCollection<IBowlingFrame> Frames => frames;
    private List<IBowlingFrame> frames = new List<IBowlingFrame>();
   
    public int Score => frames.Sum(frame => frame.Score ?? 0);
    private RollHandler rollHandler;
    public BowlingGameChain()
    {
        var frame1Handler = new DefaultRollHandler();
        var frame2Handler = new DefaultRollHandler();
        var frame3Handler = new DefaultRollHandler();
        var frame4Handler = new DefaultRollHandler();
        var frame5Handler = new DefaultRollHandler();
        var frame6Handler = new DefaultRollHandler();
        var frame7Handler = new DefaultRollHandler();
        var frame8Handler = new DefaultRollHandler();
        var frame9Handler = new DefaultRollHandler();
        var frame10Handler = new LastFrameRollHandler();

        frame1Handler.SetNext(frame2Handler);
        frame2Handler.SetNext(frame3Handler);
        frame3Handler.SetNext(frame4Handler);
        frame4Handler.SetNext(frame5Handler);
        frame5Handler.SetNext(frame6Handler);
        frame6Handler.SetNext(frame7Handler);
        frame7Handler.SetNext(frame8Handler);
        frame8Handler.SetNext(frame9Handler);
        frame9Handler.SetNext(frame10Handler);

        frames.Add(frame1Handler);
        frames.Add(frame2Handler);
        frames.Add(frame3Handler);
        frames.Add(frame4Handler);
        frames.Add(frame5Handler);
        frames.Add(frame6Handler);
        frames.Add(frame7Handler);
        frames.Add(frame8Handler);
        frames.Add(frame9Handler);
        frames.Add(frame10Handler);

        rollHandler = frame1Handler;
        // You can add more handlers here if needed, e.g. for special frames or rules
        // rollHandler.SetNext(new SpecialFrameHandler());

    }

    public void Roll(int pins)
    {
        rollHandler.Handle(pins);
    }


}

internal abstract class RollHandler
{
    protected RollHandler? Successor = null;
    public void SetNext(RollHandler successor)
    {
        Successor = successor;
    }
    public abstract void Handle(int pins);
}

internal class LastFrameRollHandler : RollHandler, IBowlingFrame
{
    private bool FrameCompleted => FirstRoll.HasValue && SecondRoll.HasValue || IsStrike;
    private bool IsStrike => FirstRoll.HasValue && FirstRoll == 10;
    private bool IsSpare => FirstRoll.HasValue && SecondRoll.HasValue && (FirstRoll + SecondRoll == 10);
    public int? FirstRoll { get; private set; }
    public int? SecondRoll { get; private set; }
    public int? Score => FirstRoll.GetValueOrDefault() + SecondRoll.GetValueOrDefault() + Bonus1.GetValueOrDefault() + Bonus2.GetValueOrDefault();
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
                else
                {
                    throw new Exception("Game Over");
                }
            }
            else if (IsSpare)
            {
                if (Bonus1 is null)
                {
                    Bonus1 = pins;
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
        else
        {
            SecondRoll = pins;
        }
    }
}

internal class DefaultRollHandler : RollHandler, IBowlingFrame
{
    private bool FrameCompleted => FirstRoll.HasValue && SecondRoll.HasValue || IsStrike;
    private bool IsStrike => FirstRoll.HasValue && FirstRoll == 10;
    private bool IsSpare => FirstRoll.HasValue && SecondRoll.HasValue && (FirstRoll + SecondRoll == 10);
    public int? FirstRoll { get; private set; }
    public int? SecondRoll { get; private set; }
    public int? Score => FirstRoll.GetValueOrDefault() + SecondRoll.GetValueOrDefault() + Bonus1.GetValueOrDefault() + Bonus2.GetValueOrDefault();
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
        else
        {
            SecondRoll = pins;
        }
    }
}
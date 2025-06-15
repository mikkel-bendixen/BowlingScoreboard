namespace Application.BowlingGameChain;

internal abstract class RollHandler : IBowlingFrame
{
    public abstract int? FirstRoll { get; }
    public abstract int? SecondRoll { get;  }
    public abstract int? Score { get; }
    protected RollHandler? Successor = null;
    public void SetNext(RollHandler successor) => Successor = successor;
    public abstract void Handle(int pins);
}

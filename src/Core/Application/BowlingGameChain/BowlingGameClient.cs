namespace Application.BowlingGameChain;

public class BowlingGameClient : IBowlingGame
{
    private const int TotalFrames = 10;
    public IReadOnlyCollection<IBowlingFrame> Frames => frames;
    public int Score => frames.Sum(frame => frame.Score ?? 0);

    private List<IBowlingFrame> frames = [];

    private RollHandler rollHandler;
    public BowlingGameClient()
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

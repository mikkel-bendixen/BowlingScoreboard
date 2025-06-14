
namespace Application;

public class BowlingGame : IBowlingGame
{
    private int currentFrameIndex = 0;
    public IReadOnlyCollection<IBowlingFrame> Frames => frames;

    private Frame[] frames = new Frame[10]
    {
        new Frame(), new Frame(), new Frame(), new Frame(), new Frame(),
        new Frame(), new Frame(), new Frame(), new Frame(), new Frame()
    };
    public BowlingGame()
    {
        //currentFrame = new Frame();
    }

    public void Roll(int pins)
    {
        var currentFrame = frames[currentFrameIndex];
        if (currentFrame.FirstRoll is null)
        {
            currentFrame.FirstRoll = pins;

        }
        else if (currentFrame.SecondRoll is null)
        {
            currentFrame.SecondRoll = pins;
        }
    }

    internal record Frame : IBowlingFrame
    {
        public int? FirstRoll { get; set; }
        public int? SecondRoll { get; set; }
    }
}

namespace Application;

public class BowlingGame : IBowlingGame
{
    private int currentFrameIndex = 0;
    public IReadOnlyCollection<IBowlingFrame> Frames => frames;

    public int Score => frames
        .SelectMany(frame => new[] { frame.FirstRoll, frame.SecondRoll })
        .Where(roll => roll.HasValue)
        .Sum(roll => roll.Value);

    private Frame[] frames =
    [
        new Frame(), new Frame(), new Frame(), new Frame(), new Frame(),
        new Frame(), new Frame(), new Frame(), new Frame(), new Frame()
    ];

    public void Roll(int pins)
    {
        var currentFrame = frames[currentFrameIndex];
        if (currentFrame.FirstRoll is null)
        {
            currentFrame.FirstRoll = pins;
            if (pins == 10) // Strike
            {
                currentFrameIndex++;
            }

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

        public int? Score
        {
            get
            {
                var score = FirstRoll + SecondRoll;

                return score;
            }
        }
    }
}
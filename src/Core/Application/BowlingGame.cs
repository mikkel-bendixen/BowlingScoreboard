
namespace Application;

public class BowlingGame : IBowlingGame
{
    private int currentFrameIndex = 0;
    public IReadOnlyCollection<IBowlingFrame> Frames => frames;

    public int Score => frames.Sum(frame => frame.Score ?? 0);

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
                currentFrame.TrailingFrame = frames[currentFrameIndex];
            }

        }
        else if (currentFrame.SecondRoll is null)
        {
            currentFrame.SecondRoll = pins;
            currentFrameIndex++;
            currentFrame.TrailingFrame = frames[currentFrameIndex];
        }
    }

    internal record Frame : IBowlingFrame
    {
        public bool IsStrike => FirstRoll.HasValue && FirstRoll == 10;
        public bool IsSpare => FirstRoll.HasValue && SecondRoll.HasValue && (FirstRoll + SecondRoll == 10);
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
        public Frame? TrailingFrame { get; set; } // For strike handling
    }
}
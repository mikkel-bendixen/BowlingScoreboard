
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

                if (FirstRoll == 10) // Strike
                {
                    score += TrailingFrame?.FirstRoll.GetValueOrDefault() + TrailingFrame?.SecondRoll.GetValueOrDefault();

                    if (TrailingFrame?.FirstRoll == 10) // If the next frame is also a strike, add its first roll again
                    {
                        score += TrailingFrame.TrailingFrame?.FirstRoll.GetValueOrDefault();
                    }
                }
                else if (score == 10) // Spare
                {
                    score += TrailingFrame?.FirstRoll;
                }


                return score;
            }
        }
        public Frame? TrailingFrame { get; set; } // For strike handling
    }
}
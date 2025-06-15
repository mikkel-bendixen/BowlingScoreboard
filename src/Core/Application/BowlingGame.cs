
namespace Application;

public class BowlingGame : IBowlingGame
{
    private Frame? currentFrame;
    public IReadOnlyCollection<IBowlingFrame> Frames => frames;

    public int Score => frames.Sum(frame => frame.Score ?? 0);

    private Frame[] frames =
    [
        new Frame(), new Frame(), new Frame(), new Frame(), new Frame(),
        new Frame(), new Frame(), new Frame(), new Frame(), new Frame()
    ];

    public BowlingGame()
    {
        currentFrame = frames[0];
    }

    public void Roll(int pins)
    {
        if (currentFrame is null)
        {
            throw new Exception("Game Over");
        }

        if (currentFrame.FirstRoll is null)
        {
            currentFrame.FirstRoll = pins;
            if (pins == 10) // Strike
            {
                EndFrame();
            }

        }
        else if (currentFrame.SecondRoll is null)
        {
            currentFrame.SecondRoll = pins;
            EndFrame();
        }
    }

    private void EndFrame()
    {
        var currentFrameIndex = Array.IndexOf(frames, currentFrame);
        if (currentFrameIndex < 0 || currentFrameIndex >= frames.Length - 1)
        {
            currentFrame = null;
        }
        else
        {
            // Set the next frame as the current frame
            var nextFrameIndex = currentFrameIndex + 1;
            var nextFrame = frames[nextFrameIndex];
            currentFrame.TrailingFrame = nextFrame;
            currentFrame = nextFrame;
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
namespace Application.SimpleBowlingGame;

public class BowlingGame : IBowlingGame
{
    private SimpleFrame? currentFrame;
    public IReadOnlyCollection<IBowlingFrame> Frames => frames;

    public int Score => frames.Sum(frame => frame.Score ?? 0);

    private SimpleFrame[] frames =
    [
        new SimpleFrame(), new SimpleFrame(), new SimpleFrame(), new SimpleFrame(), new SimpleFrame(),
        new SimpleFrame(), new SimpleFrame(), new SimpleFrame(), new SimpleFrame(), new SimpleFrame()
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
        if (currentFrameIndex is 9) // Last frame
        {
            if(currentFrame.IsStrike || currentFrame.IsSpare)
            {
                // Allow for bonus rolls in the last frame
                var supportFrame = new SimpleFrame();
                currentFrame.TrailingFrame = supportFrame;
                currentFrame = supportFrame;
            }
            else
            {
                currentFrame = null;
            }
        }
        else if (currentFrameIndex < 0)
        {
            // support frame
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



    
}

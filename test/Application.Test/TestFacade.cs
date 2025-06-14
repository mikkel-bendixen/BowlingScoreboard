using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Test;

internal class TestFacade
{
    private IBowlingGame currentGame;

    internal void StartNewGame()
    {
        currentGame = new BowlingGame();
    }
    internal void Roll(int pins) => currentGame.Roll(pins);
    internal void RollStrike() => currentGame.Roll(10);

    internal void RollSpare(int firstRollPins = 7)
    {
        currentGame.Roll(firstRollPins);
        currentGame.Roll(10 - firstRollPins);
    }

    internal void FinishFrames(int frameCount)
    {
        while (currentGame.Frames.Where(IsFinished).Count() < frameCount)
        {
            currentGame.Roll(0);
        }
    }


    internal async Task AssertFrameHasFirstRollPinsKnockedDown(int frame, int pins) => await Assert
        .That(currentGame.Frames.Skip(frame - 1).First().FirstRoll)
        .IsEqualTo(pins);

    internal async Task AssertFrameHasSecondRollPinsKnockedDown(int frame, int pins) => await Assert
        .That(currentGame.Frames.Skip(frame - 1).First().SecondRoll)
        .IsEqualTo(pins);

    //internal async Task AssertKnockedPinsOnFirstRollInFrame(int pins, int frame) => await Assert
    //    .That(currentGame.Frames.Skip(frame - 1).First().FirstRoll)
    //    .IsEqualTo(pins);

    //internal async Task AssertKnockedPinsOnSecondRollInFrame(int pins, int frame) => await Assert
    //    .That(currentGame.Frames.Skip(frame - 1).First().SecondRoll)
    //    .IsEqualTo(pins);

    internal async Task AssertNoFirstRollInFrame(int frame) => await Assert
        .That(currentGame.Frames.Skip(frame - 1).First().FirstRoll)
        .IsNull();

    internal async Task AssertNoSecondRollInFrame(int frame) => await Assert
        .That(currentGame.Frames.Skip(frame - 1).First().SecondRoll)
        .IsNull();

    internal async Task AssertTotalScore(int score) => await Assert
        .That(currentGame.Score)
        .IsEqualTo(score);

    internal async Task AssertFrameScore(int frame, int score) => await Assert
        .That(currentGame.Frames.Skip(frame - 1).First().Score)
        .IsEqualTo(score);

    private bool IsFinished (IBowlingFrame frame) => frame.FirstRoll.HasValue && frame.SecondRoll.HasValue || frame.FirstRoll == 10;

}
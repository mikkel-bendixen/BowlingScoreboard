
namespace Application.Test;

// GivenANewBowlingGame_WhenRollingOnePin_ThenFirstRollInFirstFrameIsOne
// GivenANewBowlingGame_WhenRollingTwoPins_ThenFirstRollInFirstFrameIsTwo

// GivenPlayerRolledOnePinOnFirstRollInFirstFrame_WhenRollingFourPins_ThenSecondRollInFirstFrameIsFour
// GivenPlayerRolledOnePinOnFirstRollInFirstFrame_WhenRollingFourPins_ThenTotalScoreIsFive

// GivenPlayerRolledStrikeOnFirstFrame_WhenRollingTwoPins_ThenSecondRollInFirstFrameIsZero
// GivenPlayerRolledStrikeOnFirstFrame_WhenRollingTwoPins_ThenFirstRollInSecondFrameIsTwo

// GivenPlayerRolledStrikeOnFirstFrameAndTwoPinsOnFirstRollInSecondFrame_WhenRollingFourPins_ThenSecondRollInSecondFrameIsFour
// GivenPlayerRolledStrikeOnFirstFrameAndTwoPinsOnFirstRollInSecondFrame_WhenRollingFourPins_ThenSecondFrameScoreIsSix
// GivenPlayerRolledStrikeOnFirstFrameAndTwoPinsOnFirstRollInSecondFrame_WhenRollingFourPins_ThenFirstFrameScoreIsSixteen
// GivenPlayerRolledStrikeOnFirstFrameAndTwoPinsOnFirstRollInSecondFrame_WhenRollingFourPins_ThenTotalScoreIsTwentyTwo

// GivenPlayerRolledSpareOnFirstFrame_WhenRollingFivePins_ThenFirstFrameScoreIsFifteen
// GivenPlayerRolledSpareOnFirstFrameAndFivePinsOnFirstRollInSecondFrame_WhenRollingFourPins_ThenSecondFrameScoreIsNine
// GivenPlayerRolledSpareOnFirstFrameAndFivePinsOnFirstRollInSecondFrame_WhenRollingFourPins_ThenFirstFrameScoreIsFifteen
// GivenPlayerRolledSpareOnFirstFrameAndFivePinsOnFirstRollInSecondFrame_WhenRollingFourPins_ThenTotalScoreIsTwentyFour

// GivenPlayerRolledSpareOnFirstFrame_WhenRollingStrike_ThenFirstFrameScoreIsTwenty
// GivenPlayerRolledSpareOnFirstFrameStrikeOnSecondFrame_WhenRollingFivePins_ThenFirstFrameScoreIsTwenty
// GivenPlayerRolledSpareOnFirstFrame_WhenRollingZeroPins_ThenFirstFrameScoreIsTen

// GivenPlayerRolledTwoStrikersOnFirstTwoFrames_WhenRollingFourPins_ThenFirstFrameScoreIsTwentyFour
// GivenPlayerRolledTwoStrikersOnFirstTwoFrames_WhenRollingFourPins_ThenSecondFrameScoreIsFourteen
// GivenPlayerRolledTwoStrikersOnFirstTwoFrames_WhenRollingFourPins_ThenThirdFrameScoreIsFour

// GivenPlayerRolledThreeStrikersOnFirstThreeFrames_WhenRollingSixPins_ThenFirstFrameScoreIsThirty
// GivenPlayerRolledThreeStrikersOnFirstThreeFrames_WhenRollingSixPins_ThenSecondFrameScoreIsTwentySix
// GivenPlayerRolledThreeStrikersOnFirstThreeFrames_WhenRollingSixPins_ThenThirdFrameScoreIsSixteen
// GivenPlayerRolledThreeStrikersOnFirstThreeFrames_WhenRollingSixPins_ThenFourthFrameScoreIsSix

// GivenPlayerHasPlayedNineFrames_WhenRollingTwoPins_ThenFirstRollInTenthFrameIsTwo
// GivenPlayerHasPlayedNineFramesAndRolledTwoPinsOnFirstRollInTenthFrame_WhenRollingFourPins_ThenSecondRollInTenthFrameIsFour
// GivenPlayerHasPlayedNineFramesAndRolledTwoPinsOnFirstRollInTenthFrame_WhenRollingFourPins_ThenTenthFrameScoreIsSix
// GIvenPlayerHasPlayedNineFramesAndRolledTwoPinsOnFirstRollAndFourPinsInSecondRollInTenthFrame_WhenRollingSixPins_ThenGameOverExceptionIsThrown

// GivenPlayerHasPlayedNineFramesAndRolledAStrikeOnFirstRollInTenthFrame_WhenRollingFourPins_ThenTenthFrameScoreIsFourteen
// GivenPlayerHasPlayedNineFramesAndRolledAStrikeOnFirstRollInTenthFrameAndThenRolledFourPins_WhenRollingFourPins_ThenTenthFrameScoreIsEighteen
// GivenPlayerHasPlayedNineFramesAndRolledAStrikeOnFirstRollInTenthFrameAndThenRolledFourPins_WhenRollingSixPins_ThenTenthFrameScoreIsTwenty
// GivenPlayerHasPlayedNineFramesAndRolledAStrikeOnFirstRollInTenthFrameAndThenRolledFourPinsAndFourPinsAgain_WhenRollingSixPins_ThenGameOverExceptionIsThrown

// GivenPlayerHasPlayedNineFramesAndRolledASpareInTenthFrame_WhenRollingFourPins_ThenTenthFrameScoreIsFourteen
// GivenPlayerHasPlayedNineFramesAndRolledASpareInTenthFrameAndThenRolledFourPins_WhenRollingFourPins_ThenGameOverExceptionIsThrown
// GivenPlayerHasPlayedNineFramesAndRolledASpareInTenthFrame_WhenRollingAStrike_ThenTenthFrameScoreIsTwenty
// GivenPlayerHasPlayedNineFramesAndRolledASpareInTenthFrameAndThenRolledAStrike_WhenRollingFourPins_ThenGameOverExceptionIsThrown


// GivenPlayerHasPlayedTenFrames_WhenRollingSixPins_ThenInvalidPinsExceptionIsThrown
// GivenPlayerRolledSixPinsOnFirstRollInFirstFrame_WhenRollingSixPins_ThenInvalidPinsExceptionIsThrown

internal class BowlingGameTests
{
    private TestFacade testFacade;

    [Before(HookType.Test)]
    public void Setup()
    {
        testFacade = new TestFacade();
    }

    [Test]
    public async Task GivenANewBowlingGame_WhenRollingOnePin_ThenFirstRollInFirstFrameIsOne()
    {
        // Given
        testFacade.StartNewGame();

        // When
        testFacade.Roll(1);

        // Then
        await testFacade.AssertFrameHasFirstRollPinsKnockedDown(1, 1);
    }

    [Test]
    public async Task GivenANewBowlingGame_WhenRollingTwoPins_ThenFirstRollInFirstFrameIsTwo()
    {
        // Given
        testFacade.StartNewGame();

        // When
        testFacade.Roll(2);

        // Then
        await testFacade.AssertFrameHasFirstRollPinsKnockedDown(1, 2);
    }

    [Test]
    public async Task GivenPlayerRolledOnePinOnFirstRollInFirstFrame_WhenRollingFourPins_ThenSecondRollInFirstFrameIsFour()
    {
        // Given
        testFacade.StartNewGame();
        testFacade.Roll(1);

        // When
        testFacade.Roll(4);

        // Then
        await testFacade.AssertFrameHasSecondRollPinsKnockedDown(1, 4);
    }

    [Test]
    public async Task GivenPlayerRolledOnePinOnFirstRollInFirstFrame_WhenRollingFourPins_ThenTotalScoreIsFive()
    {
        // Given
        testFacade.StartNewGame();
        testFacade.Roll(1);

        // When
        testFacade.Roll(4);

        // Then
        await testFacade.AssertTotalScore(5);
    }

    [Test]
    public async Task GivenPlayerRolledStrikeOnFirstFrame_WhenRollingTwoPins_ThenThereIsNoSecondRollInFirstFrame()
    {
        // Given
        testFacade.StartNewGame();
        testFacade.RollStrike();

        // When
        testFacade.Roll(2);

        // Then
        await testFacade.AssertNoSecondRollInFrame(1);
    }

    [Test]
    public async Task GivenPlayerRolledStrikeOnFirstFrame_WhenRollingTwoPins_ThenFirstRollInSecondFrameIsTwo()
    {
        // Given
        testFacade.StartNewGame();
        testFacade.RollStrike();

        // When
        testFacade.Roll(2);

        // Then
        await testFacade.AssertFrameHasFirstRollPinsKnockedDown(2, 2);
    }

    [Test]
    public async Task GivenPlayerRolledStrikeOnFirstFrameAndTwoPinsOnFirstRollInSecondFrame_WhenRollingFourPins_ThenSecondRollInSecondFrameIsFour()
    {
        // Given
        testFacade.StartNewGame();
        testFacade.RollStrike();
        testFacade.Roll(2);

        // When
        testFacade.Roll(4);

        // Then
        await testFacade.AssertFrameHasSecondRollPinsKnockedDown(2, 4);
    }

    [Test]
    public async Task GivenPlayerRolledStrikeOnFirstFrameAndTwoPinsOnFirstRollInSecondFrame_WhenRollingFourPins_ThenSecondFrameScoreIsSix()
    {
        // Given
        testFacade.StartNewGame();
        testFacade.RollStrike();
        testFacade.Roll(2);

        // When
        testFacade.Roll(4);

        // Then
        await testFacade.AssertFrameScore(2, 6);
    }

    [Test]
    public async Task GivenPlayerRolledStrikeOnFirstFrameAndTwoPinsOnFirstRollInSecondFrame_WhenRollingFourPins_ThenFirstFrameScoreIsSixteen()
    {
        // Given
        testFacade.StartNewGame();
        testFacade.RollStrike();
        testFacade.Roll(2);

        // When
        testFacade.Roll(4);

        // Then
        await testFacade.AssertFrameScore(1, 16);
    }

    [Test]
    public async Task GivenPlayerRolledStrikeOnFirstFrameAndTwoPinsOnFirstRollInSecondFrame_WhenRollingFourPins_ThenTotalScoreIsTwentyTwo()
    {
        // Given
        testFacade.StartNewGame();
        testFacade.RollStrike();
        testFacade.Roll(2);
        // When
        testFacade.Roll(4);
        // Then
        await testFacade.AssertTotalScore(22);
    }

    [Test]
    public async Task GivenPlayerRolledSpareOnFirstFrame_WhenRollingFivePins_ThenFirstFrameScoreIsFifteen()
    {
        // Given
        testFacade.StartNewGame();
        testFacade.RollSpare();

        // When
        testFacade.Roll(5);

        // Then
        await testFacade.AssertFrameScore(1, 15);
    }

    [Test]
    public async Task GivenPlayerRolledSpareOnFirstFrameAndFivePinsOnFirstRollInSecondFrame_WhenRollingFourPins_ThenSecondFrameScoreIsNine()
    {
        // Given
        testFacade.StartNewGame();
        testFacade.RollSpare();
        testFacade.Roll(5);

        // When
        testFacade.Roll(4);

        // Then
        await testFacade.AssertFrameScore(2, 9);
    }

    [Test]
    public async Task GivenPlayerRolledSpareOnFirstFrameAndFivePinsOnFirstRollInSecondFrame_WhenRollingFourPins_ThenFirstFrameScoreIsFifteen()
    {
        // Given
        testFacade.StartNewGame();
        testFacade.RollSpare();
        testFacade.Roll(5);

        // When
        testFacade.Roll(4);

        // Then
        await testFacade.AssertFrameScore(2, 9);
    }

    [Test]
    public async Task GivenPlayerRolledSpareOnFirstFrameAndFivePinsOnFirstRollInSecondFrame_WhenRollingFourPins_ThenTotalScoreIsTwentyFour()
    {
        // Given
        testFacade.StartNewGame();
        testFacade.RollSpare();
        testFacade.Roll(5);

        // When
        testFacade.Roll(4);

        // Then
        await testFacade.AssertTotalScore(24);
    }

    [Test]
    public async Task GivenPlayerRolledSpareOnFirstFrame_WhenRollingStrike_ThenFirstFrameScoreIsTwenty()
    {
        // Given
        testFacade.StartNewGame();
        testFacade.RollSpare();

        // When
        testFacade.RollStrike();

        // Then
        await testFacade.AssertFrameScore(1, 20);
    }

    [Test]
    public async Task GivenPlayerRolledSpareOnFirstFrameStrikeOnSecondFrame_WhenRollingFivePins_ThenFirstFrameScoreIsTwenty()
    {
        // Given
        testFacade.StartNewGame();
        testFacade.RollSpare();
        testFacade.RollStrike();

        // When
        testFacade.Roll(5);

        // Then
        await testFacade.AssertFrameScore(1, 20);
    }

    [Test]
    public async Task GivenPlayerRolledSpareOnFirstFrame_WhenRollingZeroPins_ThenFirstFrameScoreIsTen()
    {
        // Given
        testFacade.StartNewGame();
        testFacade.RollSpare();

        // When
        testFacade.Roll(0);

        // Then
        await testFacade.AssertFrameScore(1, 10);
    }

    [Test]
    public async Task GivenPlayerRolledTwoStrikersOnFirstTwoFrames_WhenRollingFourPins_ThenFirstFrameScoreIsTwentyFour()
    {
        // Given
        testFacade.StartNewGame();
        testFacade.RollStrike();
        testFacade.RollStrike();

        // When
        testFacade.Roll(4);

        // Then
        await testFacade.AssertFrameScore(1, 24);
    }

    [Test]
    public async Task GivenPlayerRolledTwoStrikersOnFirstTwoFrames_WhenRollingFourPins_ThenSecondFrameScoreIsFourteen()
    {
        // Given
        testFacade.StartNewGame();
        testFacade.RollStrike();
        testFacade.RollStrike();

        // When
        testFacade.Roll(4);

        // Then
        await testFacade.AssertFrameScore(2, 14);
    }

    [Test]
    public async Task GivenPlayerRolledTwoStrikersOnFirstTwoFrames_WhenRollingFourPins_ThenThirdFrameScoreIsFour()
    {
        // Given
        testFacade.StartNewGame();
        testFacade.RollStrike();
        testFacade.RollStrike();
        testFacade.Roll(4);

        // When
        testFacade.Roll(0);

        // Then
        await testFacade.AssertFrameScore(3, 4);
    }

    [Test]
    public async Task GivenPlayerRolledThreeStrikersOnFirstThreeFrames_WhenRollingSixPins_ThenFirstFrameScoreIsThirty()
    {
        // Given
        testFacade.StartNewGame();
        testFacade.RollStrike();
        testFacade.RollStrike();
        testFacade.RollStrike();

        // When
        testFacade.Roll(6);

        // Then
        await testFacade.AssertFrameScore(1, 30);
    }

    [Test]
    public async Task GivenPlayerRolledThreeStrikersOnFirstThreeFrames_WhenRollingSixPins_ThenSecondFrameScoreIsTwentySix()
    {
        // Given
        testFacade.StartNewGame();
        testFacade.RollStrike();
        testFacade.RollStrike();
        testFacade.RollStrike();

        // When
        testFacade.Roll(6);

        // Then
        await testFacade.AssertFrameScore(2, 26);
    }

    [Test]
    public async Task GivenPlayerRolledThreeStrikersOnFirstThreeFrames_WhenRollingSixPins_ThenThirdFrameScoreIsSixteen()
    {
        // Given
        testFacade.StartNewGame();
        testFacade.RollStrike();
        testFacade.RollStrike();
        testFacade.RollStrike();
        // When
        testFacade.Roll(6);
        // Then
        await testFacade.AssertFrameScore(3, 16);
    }

    [Test]
    public async Task GivenPlayerRolledThreeStrikersOnFirstThreeFrames_WhenRollingSixPins_ThenFourthFrameScoreIsSix()
    {
        // Given
        testFacade.StartNewGame();
        testFacade.RollStrike();
        testFacade.RollStrike();
        testFacade.RollStrike();

        // When
        testFacade.Roll(6);

        // Then
        await testFacade.AssertFrameScore(4, 6);
    }

    [Test]
    public async Task GivenPlayerHasPlayedNineFrames_WhenRollingTwoPins_ThenFirstRollInTenthFrameIsTwo()
    {
        // Given
        testFacade.StartNewGame();
        testFacade.FinishFrames(9);

        // When
        testFacade.Roll(2);

        // Then
        await testFacade.AssertFrameHasFirstRollPinsKnockedDown(10, 2);
    }

    [Test]
    public async Task GivenPlayerHasPlayedNineFramesAndRolledTwoPinsOnFirstRollInTenthFrame_WhenRollingFourPins_ThenSecondRollInTenthFrameIsFour()
    {
        // Given
        testFacade.StartNewGame();
        testFacade.FinishFrames(9);
        testFacade.Roll(2);

        // When
        testFacade.Roll(4);

        // Then
        await testFacade.AssertFrameHasSecondRollPinsKnockedDown(10, 4);
    }

    [Test]
    public async Task GivenPlayerHasPlayedNineFramesAndRolledTwoPinsOnFirstRollInTenthFrame_WhenRollingFourPins_ThenTenthFrameScoreIsSix()
    {
        // Given
        testFacade.StartNewGame();
        testFacade.FinishFrames(9);
        testFacade.Roll(2);
        // When
        testFacade.Roll(4);
        // Then
        await testFacade.AssertFrameScore(10, 6);
    }

    [Test]
    public async Task GivenPlayerHasPlayedNineFramesAndRolledTwoPinsOnFirstRollAndFourPinsInSecondRollInTenthFrame_WhenRollingSixPins_ThenGameOverExceptionIsThrown()
    {
        // Given
        testFacade.StartNewGame();
        testFacade.FinishFrames(9);
        testFacade.Roll(2);
        testFacade.Roll(4);

        // When
        var exception = Assert.Throws<Exception>(() => testFacade.Roll(6));

        // Then
        await Assert.That(exception.Message).Contains("Game Over");
    }

    [Test]
    public async Task GivenPlayerHasPlayedNineFramesAndRolledAStrikeOnFirstRollInTenthFrame_WhenRollingFourPins_ThenTenthFrameScoreIsFourteen()
    {
        // Given
        testFacade.StartNewGame();
        testFacade.FinishFrames(9);
        testFacade.RollStrike();

        // When
        testFacade.Roll(4);

        // Then
        await testFacade.AssertFrameScore(10, 14);
    }

    [Test]
    public async Task GivenPlayerHasPlayedNineFramesAndRolledAStrikeOnFirstRollInTenthFrameAndThenRolledFourPins_WhenRollingFourPins_ThenTenthFrameScoreIsEighteen()
    {
        // Given
        testFacade.StartNewGame();
        testFacade.FinishFrames(9);
        testFacade.RollStrike();
        testFacade.Roll(4);

        // When
        testFacade.Roll(4);

        // Then
        await testFacade.AssertFrameScore(10, 18);
    }

    [Test]
    public async Task GivenPlayerHasPlayedNineFramesAndRolledAStrikeOnFirstRollInTenthFrameAndThenRolledFourPins_WhenRollingSixPins_ThenTenthFrameScoreIsTwenty()
    {
        // Given
        testFacade.StartNewGame();
        testFacade.FinishFrames(9);
        testFacade.RollStrike();
        testFacade.Roll(4);

        // When
        testFacade.Roll(6);

        // Then
        await testFacade.AssertFrameScore(10, 20);
    }

    [Test]
    public async Task GivenPlayerHasPlayedNineFramesAndRolledAStrikeOnFirstRollInTenthFrameAndThenRolledFourPinsAndFourPinsAgain_WhenRollingSixPins_ThenGameOverExceptionIsThrown()
    {
        // Given
        testFacade.StartNewGame();
        testFacade.FinishFrames(9);
        testFacade.RollStrike();
        testFacade.Roll(4);
        testFacade.Roll(4);

        // When
        var exception = Assert.Throws<Exception>(() => testFacade.Roll(6));

        // Then
        await Assert.That(exception.Message).Contains("Game Over");
    }

    [Test]
    public async Task GivenPlayerHasPlayedNineFramesAndRolledASpareInTenthFrame_WhenRollingFourPins_ThenTenthFrameScoreIsFourteen()
    {
        // Given
        testFacade.StartNewGame();
        testFacade.FinishFrames(9);
        testFacade.RollSpare();

        // When
        testFacade.Roll(4);

        // Then
        await testFacade.AssertFrameScore(10, 14);
    }

    [Test]
    public async Task GivenPlayerHasPlayedNineFramesAndRolledASpareInTenthFrameAndThenRolledFourPins_WhenRollingFourPins_ThenGameOverExceptionIsThrown()
    {
        // Given
        testFacade.StartNewGame();
        testFacade.FinishFrames(9);
        testFacade.RollSpare();
        testFacade.Roll(4);

        // When
        var exception = Assert.Throws<Exception>(() => testFacade.Roll(4));

        // Then
        await Assert.That(exception.Message).Contains("Game Over");
    }

    [Test]
    public async Task GivenPlayerHasPlayedNineFramesAndRolledASpareInTenthFrame_WhenRollingAStrike_ThenTenthFrameScoreIsTwenty()
    {
        // Given
        testFacade.StartNewGame();
        testFacade.FinishFrames(9);
        testFacade.RollSpare();
        // When
        testFacade.RollStrike();
        // Then
        await testFacade.AssertFrameScore(10, 20);
    }

    [Test]
    public async Task GivenPlayerHasPlayedNineFramesAndRolledASpareInTenthFrameAndThenRolledAStrike_WhenRollingFourPins_ThenGameOverExceptionIsThrown()
    {
        // Given
        testFacade.StartNewGame();
        testFacade.FinishFrames(9);
        testFacade.RollSpare();
        testFacade.RollStrike();
        // When
        var exception = Assert.Throws<Exception>(() => testFacade.Roll(4));
        // Then
        await Assert.That(exception.Message).Contains("Game Over");
    }

}

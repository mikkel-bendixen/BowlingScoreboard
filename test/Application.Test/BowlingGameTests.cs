
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


}

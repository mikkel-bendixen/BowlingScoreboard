
namespace Application.Test;

// GivenANewBowlingGame_WhenRollingOnePin_ThenFirstRollInFirstFrameIsOne
// GivenANewBowlingGame_WhenRollingTwoPins_ThenFirstRollInFirstFrameIsTwo

// GivenPlayerRolledOnePinOnFirstRollInFirstFrame_WhenRollingFourPins_ThenSecondRollInFirstFrameIsFour
// GivenPlayerRolledOnePinOnFirstRollInFirstFrame_WhenRollingFourPins_ThenTotalScoreIsFive

// GivenPlayerRolledStrikeOnFirstFrame_WhenRollingTwoPins_ThenSecondRollInFirstFrameIsZero
// GivenPlayerRolledStrikeOnFirstFrame_WhenRollingTwoPins_ThenFirstRollInSecondFrameIsTwo

// GivenPlayerRolledStrikeOnFirstFrameAndTwoPinsOnFirstRollInSecondFrame_WhenRollingFourPins_ThenSecondRollInSecondFrameIsFour
// GivenPlayerRolledStrikeOnFirstFrameAndTwoPinsOnFirstRollInSecondFrame_WhenRollingFourPins_ThenFirstFrameScoreIsSixteen
// GivenPlayerRolledStrikeOnFirstFrameAndTwoPinsOnFirstRollInSecondFrame_WhenRollingFourPins_ThenSecondFrameScoreIsSix
// GivenPlayerRolledStrikeOnFirstFrameAndTwoPinsOnFirstRollInSecondFrame_WhenRollingFourPins_ThenTotalScoreIsTwentyTwo






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
        await testFacade.AssertKnockedPinsOnFirstRollInFrame(1, 1);
    }

    [Test]
    public async Task GivenANewBowlingGame_WhenRollingTwoPins_ThenFirstRollInFirstFrameIsTwo()
    {
        // Given
        testFacade.StartNewGame();

        // When
        testFacade.Roll(2);

        // Then
        await testFacade.AssertKnockedPinsOnFirstRollInFrame(2, 1);
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
        await testFacade.AssertKnockedPinsOnSecondRollInFrame(4, 1);
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
        testFacade.Roll(10);

        // When
        testFacade.Roll(2);

        // Then
        await testFacade.AssertNoSecondRollInFrame(1);
    }
}

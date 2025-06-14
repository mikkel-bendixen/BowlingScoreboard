
namespace Application;

public interface IBowlingGame
{
    public void Roll(int pins);
    public IReadOnlyCollection<IBowlingFrame> Frames { get; }

}

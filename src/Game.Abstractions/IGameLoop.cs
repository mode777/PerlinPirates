using System.Threading;

namespace Game.Abstractions
{
    public interface IGameLoop
    {
        void Run(CancellationToken token);
    }
}
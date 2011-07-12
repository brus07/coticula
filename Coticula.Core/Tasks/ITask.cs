
namespace Coticula.Core.Tasks
{
    interface ITask
    {
        ITask[] Execute();
        IChannel Channel { get; }
    }
}

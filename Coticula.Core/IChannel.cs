
namespace Coticula.Core
{
    public delegate int[] UntestedEventHandler();
    public delegate DTO.Solution SolutionEventHandler(int id);
    public delegate bool ResultEventHandler(DTO.Result result);

    public interface IChannel
    {
        event UntestedEventHandler UntestedEvent;

        int[] Untested();

        event SolutionEventHandler SolutionEvent;

        DTO.Solution Solution(int id);

        event ResultEventHandler ResultEvent;

        bool Result(DTO.Result result);
    }
}

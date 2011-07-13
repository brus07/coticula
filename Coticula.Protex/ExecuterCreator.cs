using Coticula.Protex.Executers;

namespace Coticula.Protex
{
    public static class ExecuterCreator
    {
        public static IExecuter CreateSimpleExecuter()
        {
            return new SimpleExecuter();
        }
    }
}

using System;
using Coticula.Protex.Executers;

namespace Coticula.Protex
{
    public static class ExecuterCreator
    {
        public static IExecuter CreateRunexeExecuter()
        {
            return new RunexeExecuter();
        }

        public static IExecuter CreateSimpleExecuter()
        {
            throw new NotImplementedException();
        }
    }
}

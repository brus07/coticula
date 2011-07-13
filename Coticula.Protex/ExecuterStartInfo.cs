
namespace Coticula.Protex
{
    public class ExecuterStartInfo
    {
        internal ExecuterStartInfo()
        {
        }

        public string Command { get; set; }
        public string WorkingDirectory { get; set; }
        public string InputStream { get; set; } //maybe need Stream type or specific type
        public string OutputStream { get; set; }
        public string ErrorStream { get; set; }
        public long TimeLimit { get; set; }//in milliseconds. The default is not set.
        public long MemoryLimit { get; set; }//in bytes. The default is not set.

        public static ExecuterStartInfo CreateInstance()
        {
            return new ExecuterStartInfo();
        }
    }
}

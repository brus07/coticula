
namespace Coticula.Protex
{
    public class Conclusion
    {
        internal Conclusion()
        {
        }

        public int ReturnCode { get; set; }//0 - OK, other - Run-time error
        public long UsedTime { get; set; }
        public long UsedMemory { get; set; }
    }
}

using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace Coticula.Protex.Executers.runexe
{
    /*
        <?xml version = "1.1" encoding = "UTF-8"?>

        <invocationResult>
            <invocationVerdict>SUCCESS</invocationVerdict>
            <exitCode>0</exitCode>
            <processorUserModeTime>3478</processorUserModeTime>
            <processorKernelModeTime>0</processorKernelModeTime>
            <passedTime>3559</passedTime>
            <consumedMemory>1077248</consumedMemory>
            <comment>success</comment>
        </invocationResult>
    */
    [Serializable]
    [XmlRoot("invocationResult")]
    public class InvocationResult
    {
        private InvocationResult()
        {
            
        }

        [XmlElement("invocationVerdict")]
        public string InvocationVerdict { get; set; }

        [XmlElement("exitCode")]
        public int ExitCode { get; set; }

        [XmlElement("processorUserModeTime")]
        public int ProcessorUserModeTime { get; set; }

        [XmlElement("processorKernelModeTime")]
        public int ProcessorKernelModeTime { get; set; }

        [XmlElement("passedTime")]
        public int PassedTime { get; set; }

        [XmlElement("consumedMemory")]
        public int ConsumedMemory { get; set; }

        [XmlElement("comment")]
        public string Comment { get; set; }

        public static InvocationResult DeserializeFromXml(string xml)
        {
            //TODO:
            //hotfix: change xml version from 1.1 to 1.0
            xml = xml.Replace("<?xml version = \"1.1\" encoding = \"UTF-8\"?>", "<?xml version = \"1.0\" encoding = \"UTF-8\"?>");

            var mySerializer = new XmlSerializer(typeof(InvocationResult));
            var reader = new StringReader(xml);
            return (InvocationResult)mySerializer.Deserialize(reader);
        }
    }
}

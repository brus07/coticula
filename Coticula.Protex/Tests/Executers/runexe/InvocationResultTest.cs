using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Coticula.Protex.Executers.runexe
{
    [TestFixture]
    public class InvocationResultTest
    {
        [Test]
        public void TestDeserialize()
        {
            const string xml = @"<?xml version = ""1.1"" encoding = ""UTF-8""?>

<invocationResult>
    <invocationVerdict>SUCCESS</invocationVerdict>
    <exitCode>0</exitCode>
    <processorUserModeTime>3478</processorUserModeTime>
    <processorKernelModeTime>0</processorKernelModeTime>
    <passedTime>3559</passedTime>
    <consumedMemory>1077248</consumedMemory>
    <comment>success</comment>
</invocationResult>";

            var result = InvocationResult.DeserializeFromXml(xml);
        }
    }
}

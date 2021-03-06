﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ValveMultitool.Models.Formats.Vpc;

namespace ValveMultitool.Tests.Parser.Vpc
{
    [TestClass]
    [DeploymentItem("Resources/TestData/Vpc")]
    public class VpcParserTestCase
    {


        [TestMethod]
        public void Behaviour()
        {
            VpcObject obj = null;
            using (var stream = File.OpenRead("Resources/TestData/Vpc/dedicated.vpc"))
                obj = VpcObject.Parse(stream);

            using (var stream = new MemoryStream())
            {
                obj.Serialise(stream);
                var result = Encoding.UTF8.GetString(stream.ToArray());
            }
        }
    }
}

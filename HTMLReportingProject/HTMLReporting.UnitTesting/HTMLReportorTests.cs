using System;
using HTMLReportingProject;
using DecimalConversionsDLL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HTMLReporting.UnitTesting
{
    [TestClass]
    public class HTMLReportorTests
    {
        DecimalConvert convert = new DecimalConvert();

        [TestMethod]
        public void HTMLReportor_Constructor_Default()
        {
            //Arrange
            string defaultName = "index";
            HTMLReportor htmlProject = new HTMLReportor();

            //Act
            string actualName = htmlProject.ProjectName;

            //Assert
            Assert.AreSame(defaultName, actualName);
        }

        [TestMethod]
        public void HTMLReportor_Constructor_WithTitle()
        {
            HTMLReportor reportor = new HTMLReportor("SampleData");
            //Arrange 
            string expectedName = "SampleData";
            
            //Act
            string actualName = reportor.ProjectName;

            //Assert
            Assert.AreSame(expectedName, actualName);
        }

        [TestMethod]
        public void HTMLReportor_Constructor_WithTitleandLocation()
        {
            HTMLReportor reportor = new HTMLReportor("SampleData", "C:\\Data\\");
            //Arrange
            string expectedName = "SampleData";
            string expectedLocation = "C:\\Data\\";
            
            //Act
            string actualName = reportor.ProjectName;
            string actualLocation = reportor.FolderName;

            //Assert
            Assert.AreSame(expectedLocation, actualLocation);
            Assert.AreSame(expectedName, actualName);
        }

        [TestMethod]
        public void DecimalConvertDLL_Bin()
        {
            //Arrange
            long[] expectedVal = new long[] { 1010, 1100100, 1111101000, 10011100010000, 11000011010100000 };
            long testVal = 10;
            int count = 0;

            //Act
            while (testVal < 100000)
            {
                long returnVal = convert.BinaryCalculator(testVal);
                long actualVal = expectedVal[count];

                //Assert
                Assert.AreEqual(actualVal, returnVal);

                //Loop
                testVal = (testVal * 10);
                count++;
            }
        }

        [TestMethod]
        public void DecimalConvertDLL_Oct()
        {

            //Arrange
            long[] expectedVal = new long[] { 12, 144, 1750, 23420 };
            long testVal = 10;
            int count = 0;

            //Act
            while (testVal < 100000)
            {
                long returnVal = long.Parse(convert.OctalCalculator(testVal));
                long actualVal = expectedVal[count];

                //Assert
                Assert.AreEqual(actualVal, returnVal);

                //Loop
                testVal = (testVal * 10);
                count++;
            }
        }

        [TestMethod]
        public void DecimalConvertDLL_Hex()
        {
            //Arrange 
            string[] expectedVal = new string[] { "A", "64", "3E8", "2710", "186A0" };
            long testVal = 10;
            int count = 0;

            //Act
            while (testVal < 100000)
            {
                string returnVal = convert.HexCalculator(testVal);
                string actualVal = expectedVal[count];

                //Assert
                Assert.AreEqual(actualVal, returnVal);

                //Loop
                testVal = (testVal * 10);
                count++;
            }
        }
    }
}

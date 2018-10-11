using System;
using HTMLReportingProject;
using DecimalConversionsDLL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HTMLReporting.UnitTesting
{
    [TestClass]
    public class HTMLReportorTests
    {
        [TestMethod]
        public void DecimalConvertorDLL_BinaryCalculator()
        {
            //Arrange
            long expected = 1111101000;
            long testVal = 1000;
            DecimalConvert convert = new DecimalConvert();

            //Act
            long actual = convert.BinaryCalculator(testVal);

            //Assert
            Assert.AreEqual(expected, actual);
        }

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
            //Arrange 
            string expectedName = "SampleData";
            HTMLReportor reportor = new HTMLReportor("SampleData");

            //Act
            string actualName = reportor.ProjectName;

            //Assert
            Assert.AreSame(expectedName, actualName);
        }

        [TestMethod]
        public void HTMLReportor_Constructor_WithTitleandLocation()
        {
            //Arrange
            string expectedName = "SampleData";
            string expectedLocation = "C:\\Data\\";
            HTMLReportor reportor = new HTMLReportor("SampleData", "C:\\Data\\");

            //Act
            string actualName = reportor.ProjectName;
            string actualLocation = reportor.FolderName;

            //Assert
            Assert.AreSame(expectedLocation, actualLocation);
            Assert.AreSame(expectedName, actualName);
        }
    }
}

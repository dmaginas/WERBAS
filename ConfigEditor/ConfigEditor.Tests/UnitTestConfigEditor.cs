using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConfigEditor.XML;
using System;
using System.IO;

namespace ConfigEditor.Tests
{
    [TestClass]
    public class UnitTestConfigEditor
    {
        [TestMethod]
        public void TestValidateInvalidXml()
        {
            // Arrange
            IConfigEditorXml sut = new ConfigEditorXml();
            string xmlFileToValidate = Path.GetFullPath(@"..\..\..\ConfigEditor\TestXML\TestXMLInvalid.xml");

            // Act
            bool success = sut.ValidateXmlFile(xmlFileToValidate);

            // Assert
            Assert.IsFalse(success);
        }

        [TestMethod]
        public void TestValidateLeerXml()
        {
            // Arrange
            IConfigEditorXml sut = new ConfigEditorXml();
            string xmlFileToValidate = Path.GetFullPath(@"..\..\..\ConfigEditor\TestXML\Leer.xml");

            // Act
            bool success = sut.ValidateXmlFile(xmlFileToValidate);

            // Assert
            Assert.IsTrue(success);
        }

        [TestMethod]
        public void TestValidateXml()
        {
            // Arrange
            IConfigEditorXml sut = new ConfigEditorXml();
            string xmlFileToValidate = Path.GetFullPath(@"..\..\..\ConfigEditor\TestXML\TestXML.xml");

            // Act
            bool success = sut.ValidateXmlFile(xmlFileToValidate);

            // Assert
            Assert.IsTrue(success);
        }

        [TestMethod]
        public void TestOpenXml()
        {
            // Arrange
            IConfigEditorXml sut = new ConfigEditorXml();
            string xmlFileToValidate = Path.GetFullPath(@"..\..\..\ConfigEditor\TestXML\TestXML.xml");

            // Act
            bool success = sut.OpenXmlFile(xmlFileToValidate);

            // Assert
            Assert.IsTrue(success);
        }
    }
}

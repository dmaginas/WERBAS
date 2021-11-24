using System;
using System.IO;
using System.Xml;
using System.Xml.Schema;
using System.Xml.XPath;

namespace ConfigEditor.XML
{
    public class ConfigEditorXml : IConfigEditorXml
    {

        protected bool IsValidationSuccessful { get; set; } // war die Validierung gegen die XSD erfolgreich?
        protected XmlDocument XmlConfigEditorDocument { get; set; } // Das Xml-Dokument

        public ConfigEditorXml()
        {
            IsValidationSuccessful = false;
        }

        //------------------------------------------------------------------------------
        // Validieren gegen XSD
        public bool ValidateXmlFile(string fileName)
        {
            try
            {
                string xsdFile = Path.GetFullPath(@"..\..\..\ConfigEditor\XSD\ConnectConfig.xsd");

                // Erstmal Dateien prüfen
                if (!File.Exists(fileName) || !File.Exists(xsdFile))
                { 
                    return false;
                }
                
                // Danach validieren
                XmlReaderSettings settings = new XmlReaderSettings();
                XmlSchema scheme = settings.Schemas.Add("http://www.w3.org/2001/XMLSchema", xsdFile);
                settings.ValidationType = ValidationType.Schema;
                settings.ValidationFlags |= XmlSchemaValidationFlags.ProcessInlineSchema;
                settings.ValidationFlags |= XmlSchemaValidationFlags.ReportValidationWarnings;
                settings.IgnoreComments = true;
                settings.IgnoreWhitespace = true;
                settings.ValidationEventHandler += Validate;

                XmlReader reader = XmlReader.Create(fileName, settings);
                while (reader.Read()) ;
                reader.Close();

                if (IsValidationSuccessful)
                    return true;

                return false;
            }
            catch (Exception)
            {
                // TODO :  Logging etc....
                IsValidationSuccessful = false;
                return false;
            }
        }

        //------------------------------------------------------------------------------
        // Der Validation handler
        protected void Validate(object sender, ValidationEventArgs e)
        {
            switch (e.Severity)
            {
                case XmlSeverityType.Error:
                    IsValidationSuccessful = false;
                    break;
                case XmlSeverityType.Warning:
                default:
                    IsValidationSuccessful = true;
                    break;
            }
        }

        //------------------------------------------------------------------------------
        // Öffnen des XML Files
        public bool OpenXmlFile(string fileName)
        {
            try
            {
                // Erstmal Datei prüfen 
                if (!File.Exists(fileName))
                {
                    return false;
                }

                // Danach Datei öffnen
                XmlConfigEditorDocument = new XmlDocument();
                XmlConfigEditorDocument.Load(fileName);

                return true;
            }
            catch (Exception)
            {
                // TODO :  Logging etc....
                return false;
            }
        }
    }
}

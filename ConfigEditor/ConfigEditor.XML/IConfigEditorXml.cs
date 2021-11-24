using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigEditor.XML
{
    public interface IConfigEditorXml
    {
        bool ValidateXmlFile(string fileName); // Gegen XSD validieren

        bool OpenXmlFile(string fileName); // Öffnen einer Config-Datei
    }
}

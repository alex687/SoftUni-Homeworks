namespace ExportMonastiersAsXml
{
    using System.Collections.Generic;
    using System.Xml;

    public class ExportToXml
    {
        private readonly List<dynamic> data;

        public ExportToXml(List<dynamic> data)
        {
            this.data = data;
        }

        public void ExportDataToFile(string fileName)
        {
            using (XmlWriter writer = XmlWriter.Create(fileName))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("monasteries");

                foreach (dynamic countryData in this.data)
                {
                    this.GenerateXmlForCountry(writer, countryData);
                }

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }

        private void GenerateXmlForCountry(XmlWriter writer, dynamic countryData)
        {
            writer.WriteStartElement("country");
            writer.WriteAttributeString("name", countryData.Country.Name);

            foreach (var monastery in countryData.Monasteries)
            {
                this.GenerateXmlForMonastery(writer, monastery);
            }

            writer.WriteEndElement();
        }

        private void GenerateXmlForMonastery(XmlWriter writer, dynamic monasteryData)
        {
            writer.WriteStartElement("monastery");
            writer.WriteString(monasteryData.Name);
            writer.WriteEndElement();
        }
    }
}

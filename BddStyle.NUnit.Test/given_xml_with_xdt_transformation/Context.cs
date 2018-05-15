using System.Xml;

namespace BddStyle.NUnit.Test.given_xml_with_xdt_transformation
{
    public abstract class Context : ContextBase
    {
        protected string TransformedContent;

        protected string GetStoragePathAttribute()
        {
            var doc = new XmlDocument();
            doc.LoadXml(TransformedContent);

            // ReSharper disable once PossibleNullReferenceException
            return doc.SelectSingleNode("configuration/E247.Configuration/Nodes/@storage-path").Value;
        }
    }
}
using System.IO;
using System.Xml;
using Microsoft.Web.XmlTransform;

namespace BddStyle.NUnit.Utilities
{
    public static class XmlTransformator
    {
        public static string ApplyTransformation(object caller, string documentResourceName, string transformationResourceName)
        {
            var transformation = ReadTransformation(caller, transformationResourceName);

            var document = ReadDocument(caller, documentResourceName);

            var xmlTransformation = new XmlTransformation(transformation, null);

            xmlTransformation.Apply(document);

            var transformedDocument = document;

            return transformedDocument.OuterXml;
        }

        private static XmlDocument ReadDocument(object caller, string documentName)
        {
            var documentContent = AssemblyResourceReader.ReadString(caller, documentName);

            var configDocument = new XmlDocument();
            
            configDocument.LoadXml(documentContent);

            return configDocument;
        }

        private static Stream ReadTransformation(object caller, string transformationName)
        {
            return AssemblyResourceReader.ReadStream(caller, transformationName);
        }
    }
}

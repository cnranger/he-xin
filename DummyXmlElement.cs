
// we cannot create XmlElement directly, so we create a dummy sub class to do
//new DummyXmlElement("","localName","", new XmlDocument())

    public class DummyXmlElement : XmlElement
    {
        protected internal DummyXmlElement(string prefix, string localName, string namespaceURI, XmlDocument doc) 
            : base(prefix, localName, namespaceURI, doc)
        {
        }
    }

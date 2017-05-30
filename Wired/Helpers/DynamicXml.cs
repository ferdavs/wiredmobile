using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Xml.Linq;

namespace Wired.Helpers
{
    public class DynamicXml : DynamicObject, IEnumerable
    {
        private readonly XElement _root;

        private DynamicXml(XElement root)
        {
            _root = root;
        }

        public static DynamicXml Parse(string xmlString)
        {
            xmlString = xmlString.Replace(" xmlns=\"", " whocares=\"");
            return new DynamicXml(XDocument.Parse(xmlString).Root);
        }


        public IEnumerator GetEnumerator()
        {
            return _root.Elements().Select(element => new DynamicXml(element)).GetEnumerator();
        }

        public bool Contains(string kid)
        {
            return _root.Element(kid) != null;
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            result = string.Empty;

            var att = _root.Attribute(binder.Name);
            if (att != null)
            {
                result = att.Value;
                return true;
            }

            var nodes = _root.Elements(binder.Name).ToList();
            if (nodes.Count == 0) return true;
            if (nodes.Count > 1)
            {
                result = nodes.Select(n => new DynamicXml(n)).ToList();
                return true;
            }
            var node = nodes[0];//_root.Element(binder.Name);
                                //if (node == null) return false;
            if (node.HasElements)
            {
                result = new DynamicXml(node);
            }
            else
            {
                result = node.Value;
            }
            return true;
        }

        public object this[int index] => _root.HasElements ? (object)_root.Elements().ToArray()[index] : string.Empty;

        public string Text => _root.ToString();

        public override string ToString()
        {
            return _root.Value;
        }
    }
}

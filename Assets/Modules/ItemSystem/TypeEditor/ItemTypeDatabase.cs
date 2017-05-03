using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Xml.Serialization;
using System.Xml.Schema;
using System.Xml;
using System.IO;

namespace Module.ItemType
{
    public class ItemTypeDatabase : MonoBehaviour
    {
        List<ItemType> itemTypeList;
        ItemTypeFactory itemTypeFactory;

        public ItemTypeDatabase(ItemTypeFactory factory)
        {
            itemTypeFactory = factory;
        }

        // TODO: Make saving and loading be based on a path and a filename.

        public void Save()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ItemTypeDatabase));
            TextWriter writer = new StreamWriter("Types.xml");
            serializer.Serialize(writer, this);
            writer.Close();
        }

        public void Load()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ItemTypeDatabase));
            TextReader reader = new StreamReader("Types.xml");
            ItemTypeDatabase deserializedDatabase = serializer.Deserialize(reader) as ItemTypeDatabase;
            reader.Close();
            itemTypeList = deserializedDatabase.itemTypeList;
        }


        #region Serialization

        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            itemTypeList = new List<ItemType>();

            reader.Read();

            while (reader.MoveToAttribute("Name"))
            {
                string name = reader.ReadContentAsString();
                itemTypeList.Add(itemTypeFactory.CreateNewType(name));
                reader.Read();
            }

            while (reader.MoveToAttribute("Parent"))
            {
                string parentName = reader.ReadContentAsString();
                reader.MoveToContent();
                string childName = reader.ReadInnerXml();

                int parentID = GetIDFromListByName(itemTypeList, parentName);
                int childID = GetIDFromListByName(itemTypeList, childName);

                itemTypeFactory.AddChildToType(itemTypeList[parentID], itemTypeList[childID]);
            }

        }

        public void WriteXml(XmlWriter writer)
        {
            foreach (ItemType itemType in itemTypeList)
            {
                writer.WriteStartElement("Type");
                writer.WriteAttributeString("Name", itemType.Name);
                writer.WriteEndElement();
            }

            foreach (ItemType itemType in itemTypeList)
            {
                foreach (ItemType itemTypeChild in itemType.Children)
                {
                    writer.WriteStartElement("TypeChild");
                    writer.WriteAttributeString("Parent", itemType.Name);
                    writer.WriteValue(itemTypeChild.Name);
                    writer.WriteEndElement();
                }
            }


        }

        int GetIDFromListByName(List<ItemType> list, string name)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Name == name)
                {
                    return i;
                }
            }
            Debug.LogError(string.Format("There is no object in a list {0}, with name {1}", list, name));
            return 0;
        }

        #endregion

    }
}
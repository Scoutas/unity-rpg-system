using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Xml.Serialization;
using System.Xml.Schema;
using System.Xml;
using System.IO;
using Module.Factory.ItemSystem;

namespace Module.Submodule.ItemTypes
{
    public class ItemTypeDatabase : IXmlSerializable
    {
        List<ItemType> m_itemTypeList;
        ItemTypeFactory m_itemTypeFactory;


        public ItemTypeDatabase(ItemTypeFactory itemTypeFactory)
        {
            m_itemTypeFactory = itemTypeFactory;
            Load();

        }

        public List<ItemType> LoadedItemTypes { get { return m_itemTypeList; } }




        

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
            m_itemTypeList = deserializedDatabase.m_itemTypeList;
        }


        #region Serialization

        public ItemTypeDatabase()
        {
            // This is here for serialization purposes.
        }

        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            m_itemTypeList = new List<ItemType>();
            m_itemTypeFactory = new ItemTypeFactory();
            
            reader.Read();

            while (reader.MoveToAttribute("Name"))
            {
                string name = reader.ReadContentAsString();
                m_itemTypeList.Add(m_itemTypeFactory.CreateNewType(name));
                reader.Read();
            }

            while (reader.MoveToAttribute("Parent"))
            {
                string parentName = reader.ReadContentAsString();
                reader.MoveToContent();
                string childName = reader.ReadInnerXml();

                int parentID = GetIDFromListByName(m_itemTypeList, parentName);
                int childID = GetIDFromListByName(m_itemTypeList, childName);

                AddChildToType(m_itemTypeList[parentID], m_itemTypeList[childID]);
            }

        }

        public void WriteXml(XmlWriter writer)
        {
            foreach (ItemType itemType in m_itemTypeList)
            {
                writer.WriteStartElement("Type");
                writer.WriteAttributeString("Name", itemType.Name);
                writer.WriteEndElement();
            }

            foreach (ItemType itemType in m_itemTypeList)
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

        public void AddChildToType(ItemType type, ItemType child)
        {
            if (type.Children.Contains(child))
            {
                string warningMessage = string.Format("The type {0} is already a child of type {1}.", child, type);
                Debug.LogWarning(warningMessage);
                return;
            }

            type.Children.Add(child);
        }

        #endregion

    }
}
using System.Collections;
using System.Collections.Generic;

namespace Module.ItemType
{
    public class ItemType
    {
        public string Name { get; set; }
        public List<ItemType> Children { get; set; }

        public ItemType()
        {
            Name = "";
            Children = new List<ItemType>();
        }

        public override string ToString()
        {
            return string.Format("Type name: {0}. Child count: {1}", Name, Children.Count);
        }
    }
}
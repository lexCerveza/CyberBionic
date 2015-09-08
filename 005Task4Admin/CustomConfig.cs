using System.Configuration;

namespace _005Task4Admin
{
    public class AnimalsSection : ConfigurationSection
    {
        // IsDefaultCollection shows, that section is collection
        [ConfigurationProperty("", IsDefaultCollection = true)]
        public AnimalsCollection AnimalItems
        {
            get { return (AnimalsCollection)this[""]; }
        }
    }

    [ConfigurationCollection(typeof(AnimalElement), AddItemName = "Animal")]
    public class AnimalsCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new AnimalElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((AnimalElement)element).Name;
        }

        public string GetElementType(ConfigurationElement element)
        {
            return ((AnimalElement)element).Type;
        }
    }

    public class AnimalElement : ConfigurationElement
    {
        [ConfigurationProperty("Name", IsKey = true, IsRequired = true)]
        public string Name
        {
            get { return ((string)(base["Name"])); }
            set { base["Name"] = value; }
        }

        [ConfigurationProperty("Type", IsKey = false, IsRequired = true)]
        public string Type
        {
            get { return ((string)(base["Type"])); }
            set { base["Type"] = value; }
        }
    }
}
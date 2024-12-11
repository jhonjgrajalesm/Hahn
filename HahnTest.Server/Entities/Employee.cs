using System.Xml.Serialization;

namespace HahnTest.Server.Entities
{
    /// <summary>
    /// For this exercise, XML decorators to mapo the entities easier
    /// </summary>
    public class Employee
    {
        [XmlElement("Id")]
        public string Id { get; set; }

        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("Position")]
        public string Position { get; set; }

        [XmlElement("Salary")]
        public decimal Salary { get; set; }
    }
}

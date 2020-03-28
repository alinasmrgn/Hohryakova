using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Lab2
{
    [Serializable]
    [XmlRoot(Namespace = "Lab2")]
    [XmlType("address")]
    public class Address: IEquatable<Address>
    {
        [XmlElement(ElementName ="City")]
        public string City { get; set; }

        [XmlElement(ElementName = "Country")]
        public string Country { get; set; }

        [XmlElement(ElementName = "Street")]
        public string Street { get; set; }

        [XmlElement(ElementName = "House")]
        public int House { get; set; }

        public Address():this("unknown", "unknown", "unknown", 0)
        { }

        public Address(string counry, string city, string street, int house)
        {
            Country = counry;
            City = city;
            Street = street;
            House = house;
        }

        public bool Equals(Address other)
        {
            return Country.Equals(other.Country) && City.Equals(other.City) && Street.Equals(other.Street) && House == other.House;
        }

        public override int GetHashCode()
        {
            return Country.GetHashCode() ^ City.GetHashCode() ^ Street.GetHashCode() ^ House.GetHashCode();
        }
    }
}

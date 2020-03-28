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
    [XmlType("workPlace")]
    public class WorkPlace
    {
        [XmlElement(ElementName = "Company")]
        public string Company { get; set; }

        [XmlElement(ElementName = "Post")]
        public string Post { get; set; }

        [XmlElement(ElementName = "Experience")]
        public string Experience { get; set; }

        [XmlElement(ElementName = "Address")]
        public string Address { get; set; }

        public WorkPlace():this("unknow", "unknown", "none", "unknown")
        { }

        public WorkPlace(string company, string post, string experience, string address)
        {
            Company = company;
            Post = post;
            Experience = experience;
            Address = address;
        }
    }

}

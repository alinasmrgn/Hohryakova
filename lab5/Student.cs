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
    [XmlType("student")]
    public class Student: IEquatable<Student>
    {
        [XmlElement(ElementName ="FullName")]
        public string FullName { get; set; }

        [XmlElement(ElementName = "Age")]
        public int Age { get; set; }

        [XmlElement(ElementName = "Speciality")]
        public string Speciality { get; set; }

        [XmlElement(ElementName = "DateOfBirth")]
        public DateTime DateOfBirth { get; set; }

        [XmlElement(ElementName = "Course")]
        public int Course { get; set; }

        [XmlElement(ElementName = "AverageMArk")]
        public string AverageMark { get; set; }

        [XmlElement(ElementName = "Group")]
        public int Group { get; set; }

        public Address Address { get; set; }

        public Student():this("Anonim", 0, "unknown", DateTime.Now, 1, "unknown", 1, new Address())
        {
        }

        public Student(string fullName, int age, string speciality, DateTime dateOfBirth, int course, string averageMark, int group, Address address)
        {
            FullName = fullName;
            Age = age;
            Speciality = speciality;
            DateOfBirth = dateOfBirth;
            Course = course;
            AverageMark = averageMark;
            Group = group;
            Address = address;
        }

        public bool Equals(Student other)
        {
            return FullName.Equals(other.FullName);
        }

        public override int GetHashCode()
        {
            return FullName.GetHashCode();
        }
    }
}

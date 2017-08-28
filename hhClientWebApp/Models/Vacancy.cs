using System;
using System.Runtime.Serialization;


namespace hhClientWebApp.Models
{
    [DataContract]
    public class Vacancy
    {
        [DataMember(Name = "id")]
        public int id { get; set; }

        [DataMember(Name = "name")]
        public string name { get; set; }

        [DataMember(Name = "alternate_url")]
        public string alternate_url { get; set; }

        [DataMember(Name = "salary")]
        public Salary salary { get; set; }

    }
}

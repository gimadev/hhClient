using System;
using System.Runtime.Serialization;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace hhClientWebApp.Models
{
    [DataContract]
    public class Vacancy
    {
        [DataMember(Name = "id")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [DataMember(Name = "name")]
        public string name { get; set; }

        [DataMember(Name = "alternate_url")]
        public string alternate_url { get; set; }

        [DataMember(Name = "salary")]
        public Salary salary { get; set; }


		[DataMember(Name = "description")]
        public string description { get; set; }

    }
}

using System;
using System.Runtime.Serialization;
using System.Collections.Generic;


namespace hhClientWebApp.Models
{
    [DataContract]
    public class Data
    {
        [DataMember(Name = "found")]
        public int found;

        [DataMember(Name = "per_page")]
        public int per_page;

        [DataMember(Name = "pages")]
        public int pages;

        [DataMember(Name = "page")]
        public int page;

        [DataMember(Name = "items",IsRequired = true)]
        public List<Vacancy> Vacancies { set; get; }
    }

}

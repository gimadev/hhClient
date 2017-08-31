using System;
using System.Runtime.Serialization;
using Microsoft.EntityFrameworkCore;

namespace hhClientWebApp.Models
{
	[DataContract]
    public class Salary
	{
        public Salary(){}

        public int id { get; set; }

		[DataMember(Name = "currency")]
		public string currency { get; set; }

		[DataMember(Name = "from")]
		public string @from { get; set; }

		[DataMember(Name = "gross")]
		public string gross { get; set; }

		[DataMember(Name = "to")]
		public string to { get; set; }
	}
}

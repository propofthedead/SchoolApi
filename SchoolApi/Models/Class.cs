using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolApi.Models
{
	public class Class
	{
		public int Id { get; set; }
		public int MajorId { get; set; }
		public virtual Major Major { get; set; }
		public string Descriptoin { get; set; }

		public Class() { }
	}
}
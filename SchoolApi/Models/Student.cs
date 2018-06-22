﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolApi.Models
{
	public class Student
	{
		public int Id { get; set; }
		public int MajorId { get; set; }
		public virtual Major Major { get; set; }
		public string Name { get; set; }
		public int Sat { get; set; }

		public Student() { }
	}
}
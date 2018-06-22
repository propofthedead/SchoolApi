using SchoolApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SchoolApi.Controllers
{
    public class StudentsController : ApiController
    {
		private SchoolContext db = new SchoolContext();

		[HttpGet]
		[ActionName("List")]
		public IEnumerable<Student> List() {
			return db.Students.ToList();
		}
		[HttpGet]
		[ActionName("Get")]
		public Student Get(int? id) {
			if (id == null)
				return null;
			return db.Students.Find(id);			
		}

		[HttpPost]
		[ActionName("Create")]
		public bool Create(Student student)
		{
			if (student == null)
				return false;
			if (!ModelState.IsValid)
				return false;
			db.Students.Add(student);
			db.SaveChanges();
			return true;
		}

		[HttpPost]
		[ActionName("Change")]
		public bool Change(Student student) {
			if (student == null)
				return false;
			if (!ModelState.IsValid)
				return false;
			var cha = db.Students.Find(student.Id);
			cha.MajorId = student.MajorId;
			cha.Name = student.Name;
			cha.Sat = student.Sat;
			cha.Major = student.Major;
			db.SaveChanges();
			return true;
		}

		[HttpPost]
		[ActionName("Remove")]
		public bool Remove(Student student) {
			if (student == null)
				return false;
			if (!ModelState.IsValid)
				return false;
			var cha = db.Students.Find(student.Id);
			db.Students.Remove(cha);
			db.SaveChanges();
			return true;
		}
    }
}

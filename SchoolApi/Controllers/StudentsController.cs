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
    }
}

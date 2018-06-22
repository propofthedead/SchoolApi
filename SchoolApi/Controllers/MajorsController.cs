using SchoolApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SchoolApi.Controllers
{
    public class MajorsController : ApiController
    {
		private SchoolContext db = new SchoolContext();

		[HttpGet]
		[ActionName("List")]
		public IEnumerable<Major> List()
		{
			return db.Majors.ToList();
		}

		[HttpGet]
		[ActionName("Get")]
		public Major Get(int? id) {
			if (id == null)
				return null;
			return db.Majors.Find(id);
		}
		[HttpPost]
		[ActionName("Create")]
		public bool Create(Major major) {
			if (major == null)
				return false;
			if (!ModelState.IsValid)
				return false;
			db.Majors.Add(major);
			db.SaveChanges();
			return true;
		}
    }
}

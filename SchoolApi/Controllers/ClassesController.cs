using SchoolApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SchoolApi.Controllers
{
    public class ClassesController : ApiController
    {
		private SchoolContext db = new SchoolContext();

		[HttpGet]
		[ActionName("List")]
		public IEnumerable<Class> List() {
			return db.Classes.ToList();
		}
    }
}

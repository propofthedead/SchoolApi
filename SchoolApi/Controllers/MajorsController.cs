using SchoolApi.Models;
using SchoolApi.Utility;
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
		public JsonResponse List()
		{
			return new JsonResponse { Data = db.Majors.ToList() };
		}

		[HttpGet]
		[ActionName("Get")]
		public JsonResponse Get(int? id) {
			if (id == null)
				return new JsonResponse { Result = "Fail", Error=null,Message= "The id is null value"};
			return new JsonResponse { Data = db.Majors.Find(id) };
			
		}
		[HttpPost]
		[ActionName("Create")]
		public JsonResponse Create(Major major) {
			if (major == null)
				return new JsonResponse { Result="Fail", Error=null,Message="The value is null"};
			if (!ModelState.IsValid)
				return new JsonResponse { Result="Fail",Error=null,Message="The value isnt valid"};
			db.Majors.Add(major);
			db.SaveChanges();
			return new JsonResponse();
		}
		[HttpPost]
		[ActionName("Change")]
		public JsonResponse Change(Major major)
		{
			if (major == null)
				return new JsonResponse { Result="fail", Error=null, Message="The is null"};
			if (!ModelState.IsValid)
				return new JsonResponse { Result="fail", Error=null,Message="The value isn't valid"};
			var maj = db.Majors.Find(major.Id);
			maj.Description = major.Description;
			maj.MinSat = major.MinSat;
			db.SaveChanges();
			return new JsonResponse();
		}
		[HttpPost]
		[ActionName("Remove")]
		public JsonResponse Remove(Major major)
		{
			if (major == null)
				return new JsonResponse { Result="Failed",Error=null, Message="The value is null"};
			if (!ModelState.IsValid)
				return new JsonResponse { Result="Failed",Error=null,Message="the value isn't valid"};
			var ma = db.Majors.Find(major.Id);
			db.Majors.Remove(ma);
			db.SaveChanges();
			return new JsonResponse();
		}

    }
}

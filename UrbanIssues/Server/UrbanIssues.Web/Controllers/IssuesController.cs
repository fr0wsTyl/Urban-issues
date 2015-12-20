using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using UrbanIssues.Data;
using UrbanIssues.Models;
using UrbanIssues.Web.Models.Comments;
using UrbanIssues.Web.Models.Issues;

namespace UrbanIssues.Web.Controllers
{
	public class IssuesController : BaseApiController
	{
		public IssuesController()
            : this(new UrbanIssuesData())
        {
		}

		public IssuesController(IUrbanIssuesData data)
            : base(data)
        {
		}
		
		// http://localhost:1337/api/issues/All
		[HttpGet]
		public IHttpActionResult All()
		{
			var issues = this.Data.Issues.All().Take(10).Select(i => new ResponseIssueModel
			{
				Category = i.Category.Name,
				City = i.City.Name,
				CreatedOn = i.CreatedOn,
				Likes = i.Likes,
				User = i.User.UserName,
				Url = i.Images.FirstOrDefault().Url
			}).ToList();
			
			return this.Ok(issues);
		}

		// http://localhost:1337/api/issues/Get/1
		[HttpGet]
		public IHttpActionResult Get(int id)
		{
			var issue = this.Data.Issues.All().Where(i => i.Id == id).FirstOrDefault();

			if (issue == null)
			{
				return this.NotFound();
			}

			var comments = issue.Comments.Select(c => new ResponseCommentModel
			{
				Content = c.Content,
				User = c.User.UserName
			}).Take(5).ToList();

			var urls = issue.Images.Select(img => img.Url).ToList();

			var issueToReturn = new ResponseIssueDetailModel
			{
				Category = issue.Category.Name,
				City = issue.City.Name,
				CreatedOn = issue.CreatedOn,
				Likes = issue.Likes,
				User = issue.User.UserName,
				Urls = urls,
				Comments = comments
			};

			return this.Ok(issueToReturn);
		}

		// http://localhost:1337/api/issues/Create
		//[Authorize]
		[HttpPost]
		public IHttpActionResult Create(RequestIssueModel model)
		{
			//var currentUserId = User.Identity.GetUserId();
			//var currentUser = this.Data.Users.All().FirstOrDefault(x => x.Id == currentUserId);

			//if (currentUser == null)
			//{
			//	return this.BadRequest("Invalid user token! Please login again!");
			//}

			if (model == null)
			{
				return this.BadRequest();
			}
			

			var category = this.Data.Categories.All().Where(c => c.Name == model.Category).FirstOrDefault();
			var city = this.Data.Cities.All().Where(c => c.Name == model.City).FirstOrDefault();

			var images = new List<Image>();

			foreach (var img in model.Images)
			{
				images.Add(new Image() { Url = img.Url });
			}

			var createdOn = DateTime.Now;
			var currentUser = this.Data.Users.All().FirstOrDefault();
			var issue = new Issue
			{
				Description = model.Description,
				User = currentUser,
				Category = category,
				City = city,
				Images = images,
				CreatedOn = createdOn
			};

			this.Data.Issues.Add(issue);
			this.Data.SaveChanges();

			// return custom view
			return this.Ok(issue.Id);
		}

		// http://localhost:1337/api/issues/Users/pesho
		[HttpGet]
		public IHttpActionResult Users([FromUri]string id)
		{
			var user = this.Data.Users.All().Where(u => u.Id == id).FirstOrDefault();

			if (user == null)
			{
				return this.NotFound();
			}

			var issues = user.Issues.Select(i => new ResponseIssueModel
			{
				Category = i.Category.Name,
				City = i.City.Name,
				CreatedOn = i.CreatedOn,
				Likes = i.Likes,
				Url = i.Images.FirstOrDefault().Url,
				User = i.User.UserName
			});

			return this.Ok(issues);
		}

		// http://localhost:1337/api/issues/Comment/1
		[HttpPut]
		//[Authorize]
		public IHttpActionResult Comment([FromUri]int id, [FromBody]string comment)
		{
			//var currentUserId = User.Identity.GetUserId();
			//var currentUser = this.Data.Users.All().FirstOrDefault(x => x.Id == currentUserId);

			//if (currentUser == null)
			//{
			//	return this.BadRequest("Invalid user token! Please login again!");
			//}

			var issue = this.Data.Issues.All().Where(i => i.Id == id).FirstOrDefault();

			if (issue == null)
			{
				return this.BadRequest();
			}

			var currentUser = this.Data.Users.All().FirstOrDefault();
			var newComment = new Comment
			{
				User = currentUser,
				Content = comment
			};

			issue.Comments.Add(newComment);
			this.Data.SaveChanges();

			return this.Ok();
		}

		// http://localhost:1337/api/issues/Like/1
		[HttpPut]
		//[Authorize]
		public IHttpActionResult Like(int id)
		{
			//var currentUserId = User.Identity.GetUserId();
			//var currentUser = this.Data.Users.All().FirstOrDefault(x => x.Id == currentUserId);

			//if (currentUser == null)
			//{
			//	return this.BadRequest("Invalid user token! Please login again!");
			//}

			var issue = this.Data.Issues.All().Where(i => i.Id == id).FirstOrDefault();

			if (issue == null)
			{
				return this.BadRequest();
			}

			issue.Likes++;

			return this.Ok();
		}

		// http://localhost:1337/api/issues/Cities?city=sofia
		[HttpGet]
		public IHttpActionResult Cities(string city)
		{
			var issues = this.Data.Issues.All().Where(i => i.City.Name == city).Take(10).Select(i => new ResponseIssueModel
			{
				Category = i.Category.Name,
				City = i.City.Name,
				CreatedOn = i.CreatedOn,
				Likes = i.Likes,
				User = i.User.UserName,
				Url = i.Images.FirstOrDefault().Url
			}).ToList();

			return this.Ok(issues);
		}

		// http://localhost:1337/api/issues/Categories?category=infrastructure
		[HttpGet]
		public IHttpActionResult Categories(string category)
		{
			var issues = this.Data.Issues.All().Where(i => i.Category.Name == category).Take(10).Select(i => new ResponseIssueModel
			{
				Category = i.Category.Name,
				City = i.City.Name,
				CreatedOn = i.CreatedOn,
				Likes = i.Likes,
				User = i.User.UserName,
				Url = i.Images.FirstOrDefault().Url
			}).ToList();

			return this.Ok(issues);
		}
	}
}
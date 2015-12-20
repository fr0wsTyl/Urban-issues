using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UrbanIssues.Web.Models.Comments;

namespace UrbanIssues.Web.Models.Issues
{
	public class ResponseIssueDetailModel
	{
		public string User { get; set; }

		public ICollection<string > Urls { get; set; }

		public DateTime CreatedOn { get; set; }

		public int Likes { get; set; }

		public string City { get; set; }

		public string Category { get; set; }

		public ICollection<ResponseCommentModel> Comments { get; set; }
	}
}
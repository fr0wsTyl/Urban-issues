using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UrbanIssues.Web.Models.Pictures;

namespace UrbanIssues.Web.Models.Issues
{
	public class RequestIssueModel
	{
		public string Description { get; set; }

		public string User { get; set; }

		public ICollection<ViewModelPicture> Images { get; set; }

		public string City { get; set; }

		public string Category { get; set; }
	}
}
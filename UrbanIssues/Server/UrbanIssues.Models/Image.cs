using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrbanIssues.Models
{
	public class Image
	{
		public int Id { get; set; }

		public string Url { get; set; }

		public int IssueId { get; set; }

		public Issue Issue { get; set; }
	}
}

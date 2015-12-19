using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrbanIssues.Models
{
	public class Comment
	{
		public int Id { get; set; }

		public string Content { get; set; }

		public string ApplicationUserId { get; set; }

		public virtual ApplicationUser User { get; set; }

		public int IssueId { get; set; }

		public virtual Issue Issue { get; set; }

		public DateTime CreatetOn { get; set; }
	}
}

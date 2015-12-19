using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrbanIssues.Models
{
	public class Issue
	{
		private ICollection<Comment> comments;

		public Issue()
		{
			this.comments = new HashSet<Comment>();
		}

		public int Id { get; set; }

		public string Description { get; set; }

		public DateTime CreatedOn { get; set; }

		public string ApplicationUserId { get; set; }

		public virtual ApplicationUser User { get; set; }
		
		public int Likes { get; set; }

		public int CategoryId { get; set; }

		public virtual Category Category { get; set; }

		public int CityId { get; set; }

		public virtual City City { get; set; }

		public ICollection<Comment> Comments
		{
			get
			{
				return this.comments;
			}
			set
			{
				this.comments = value;
			}
		}
	}
}

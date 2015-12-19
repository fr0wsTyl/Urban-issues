using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrbanIssues.Models
{
	public class City
	{
		private ICollection<Issue> issues;

		public City()
		{
			this.issues = new HashSet<Issue>();
		}

		public int Id { get; set; }

		public string Name { get; set; }

		public ICollection<Issue> Issues
		{
			get
			{
				return this.issues;
			}
			set
			{
				this.issues = value;
			}
		}
	}
}

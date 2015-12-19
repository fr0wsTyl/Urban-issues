namespace UrbanIssues.Models
{
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
		private ICollection<Issue> issues;
		private ICollection<Comment> comments;

		public ApplicationUser()
		{
			this.issues = new HashSet<Issue>();
			this.comments = new HashSet<Comment>();
		}

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

		public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);

            // Add custom user claims here
            return userIdentity;
        }
    }
}
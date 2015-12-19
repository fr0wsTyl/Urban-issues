namespace UrbanIssues.Data
{
    using UrbanIssues.Models;

    public interface IUrbanIssuesData
    {
        IRepository<ApplicationUser> Users { get; }

		IRepository<Issue> Issues { get; }

		IRepository<Category> Categories { get; }

		IRepository<City> Cities { get; }

		IRepository<Comment> Comments { get; }

		int SaveChanges();
    }
}

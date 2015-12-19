namespace UrbanIssues.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;

    using UrbanIssues.Models;

    public class UrbanIssuesData : IUrbanIssuesData
    {
        private readonly DbContext context;

        private readonly IDictionary<Type, object> repositories;

        public UrbanIssuesData()
            : this(new ApplicationDbContext())
        {
        }

        public UrbanIssuesData(DbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<ApplicationUser> Users
        {
            get
            {
                return this.GetRepository<ApplicationUser>();
            }
        }

		public IRepository<Issue> Issues
		{
			get
			{
				return this.GetRepository<Issue>();
			}
		}

		public IRepository<Category> Categories
		{
			get
			{
				return this.GetRepository<Category>();
			}
		}

		public IRepository<Comment> Comments
		{
			get
			{
				return this.GetRepository<Comment>();
			}
		}

		public IRepository<City> Cities
		{
			get
			{
				return this.GetRepository<City>();
			}
		}

		public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(EfRepository<T>);

                //// if (typeof(T).IsAssignableFrom(typeof(UserProfile)))
                //// {
                ////     type = typeof(UsersRepository);
                //// }

                this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.context));
            }

            return (IRepository<T>)this.repositories[typeof(T)];
        }
    }
}

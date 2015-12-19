namespace UrbanIssues.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using UrbanIssues.Models;

    public sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            if (context.Users.Any())
            {
                return;
            }

            var random = new Random();

            var users = this.SeedApplicationUsers(context);

            context.SaveChanges();
        }
       
        private List<ApplicationUser> SeedApplicationUsers(ApplicationDbContext context)
        {
            const int NumberOfUsers = 40;
            var users = new List<ApplicationUser>();
            var userStore = new UserStore<ApplicationUser>(context);
            var manager = new UserManager<ApplicationUser>(userStore);
            for (var i = 1; i <= NumberOfUsers; i++)
            {
                var userName = string.Format("test{0:D2}@test.com", i);
                const string Password = "123456";
                var user = new ApplicationUser
                               {
                                   UserName = userName,
                                   Email = userName
                               };

                var identityResult = manager.Create(user, Password);
                if (identityResult.Succeeded)
                {
                    users.Add(user);
                }
            }

            return users;
        }

        private IList<T> Shuffle<T>(IList<T> list, Random randomGenerator)
        {
            for (var i = 0; i < list.Count; i++)
            {
                var swapIndex = randomGenerator.Next(list.Count);
                var currentElement = list[i];
                list[i] = list[swapIndex];
                list[swapIndex] = currentElement;
            }

            return list;
        }
    }
}

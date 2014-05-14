namespace PassStorage.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using PassStorage.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PassStorage.Models.ServicesDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(PassStorage.Models.ServicesDb context)
        {
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            string roleName = "admin";
            if (!RoleManager.RoleExists(roleName))
            {
                RoleManager.Create(new IdentityRole(roleName));
            }

            var admin = new ApplicationUser() { UserName = "admin" };
            UserManager.Create(
                admin
                , "123qwe");

            var addedUser = UserManager.FindByName("admin");
            UserManager.AddToRole(addedUser.Id, "admin");

            context.Services.AddOrUpdate(
                p => p.Name,
                new Service { 
                    Name = "Test service", 
                    Description = "Something here", 
                    UpdateDate = DateTime.Now, 
                    Url = "http://test.com/",
                    UserRef = addedUser
                }
                );

            var addedService = from key in context.Services
                               where key.Name == "Test service"
                               select key;
            context.ServiceAccounts.AddOrUpdate(
                    p => p.Login,
                    new ServiceAccount
                    {
                        Login = "AdminAcc",
                        Password = "123qwe",
                        ServiceId = addedService.First().Id
                    }
                );

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}

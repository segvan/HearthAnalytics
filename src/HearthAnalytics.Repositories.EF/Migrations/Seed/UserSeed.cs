using HearthAnalytics.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace HearthAnalytics.Repositories.EF.Seed
{
    [SeedOrder(3)]
    public class UserSeed : ISeed
    {
        private readonly DbSet<User> _databaseSet;

        public UserSeed(DbSet<User> dbset)
        {
            _databaseSet = dbset;
        }

        public void Apply()
        {
            AddUser();
        }

        private void AddUser()
        {            
            var user = _databaseSet.FirstOrDefault(x => x.UserName == "admin");

            if (user == null)
            {
                user = new User
                {
                   UserName = "admin",
                   Email = "admin@microsoft.com",
                   FirstName = "Admin",
                   LastName = ""
                };

                _databaseSet.Add(user);
            }
        }
    }
}

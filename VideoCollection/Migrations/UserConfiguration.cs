using System.Collections.Generic;
using System.Data.Entity.Migrations;
using VideoCollection.Data;
using VideoCollection.Data.Models;
using System.Linq;
using VideoCollection.Security;
using System;
using System.Data.Entity;

namespace VideoCollection.Migrations
{
    public class UserConfiguration
    {
        public static void Seed(VideoCollectionDataContext context) {

            var systemRole = context.Roles.First(x => x.Name == "[Video Collection Security Roles] System");
            var roles = new List<Role>();
            roles.Add(systemRole);

            var user = context.Users.Include(x=>x.Roles).FirstOrDefault(x => x.Username == "quinntynebrown@gmail.com");

            if (user == null)
            {
                context.Users.Add(new User()
                {
                    Username = "quinntynebrown@gmail.com",
                    Password = new EncryptionService().HashPassword("P@ssw0rd"),
                    Roles = roles
                });
            }

            context.SaveChanges();
        }
    }
}

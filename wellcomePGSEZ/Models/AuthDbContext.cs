using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace wellcomePGSEZ.Models
{

    
    public class AuthDbContext : IdentityDbContext
    {

        private String _password;
        
        public AuthDbContext(DbContextOptions options) : base(options)
        {

            _password = new Utils().hassPass();

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var userAdminRoleId = "851d91b1-62b8-42e3-8693-befc5663340d";
            var userSuperAdminRoleId = "54e404bd-375a-438c-a974-70497970d254";
            var userNormalRoleId = "54e404bd-375a-438c-a974-70497970d254";
            var roles = new List<IdentityRole>();

            roles.Add(new IdentityRole
            {
                Name = "Admin",
                NormalizedName = "Admin",
                Id = userAdminRoleId,
                ConcurrencyStamp = userAdminRoleId
            });




            roles.Add(new IdentityRole
            {
                Name = "SuperAdmin",
                NormalizedName = "SuperAdmin",
                Id = userSuperAdminRoleId,
                ConcurrencyStamp = userSuperAdminRoleId
            });


           

            roles.Add(new IdentityRole
            {
                Name = "NormalRoleId",
                NormalizedName = "NormalRoleId",
                Id = userNormalRoleId,
                ConcurrencyStamp = userNormalRoleId
            });

            builder.Entity<IdentityRole>().HasData(roles);

            var superAdminId = "1df47bd1-c744-4294-99e2-571366eb747c\r\n"
            var superAdminUser = new IdentityUser
            {
               UserName = "alireza",
               Id = superAdminId,
               PasswordHash = _password 
            };
            builder.Entity<IdentityUser>().HasData(superAdminUser);

            var superAdminRoles = new List<IdentityUserRole<String>{

                new IdentityUserRole<string>
                {
                    RoleId= userSuperAdminRoleId,
                    UserId= superAdminId,
                },

                 new IdentityUserRole<string>
                {
                    RoleId= userAdminRoleId,
                    UserId= superAdminId,
                },

                  new IdentityUserRole<string>
                {
                    RoleId= userNormalRoleId,
                    UserId= superAdminId,
                }
            };

            builder.Entity<IdentityUserRole<String>>().HasData(superAdminRoles);
        }
    }
}

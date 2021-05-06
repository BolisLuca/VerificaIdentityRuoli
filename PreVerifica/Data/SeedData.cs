using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PreVerifica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PreVerifica.Data
{
    public class SeedData
    {
        public static async Task Initzialize(IServiceProvider serviceProvider)
        {
            /*
             1.Ruoli
            2.Utenti
            3.Automobili
             */
            using (var context = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                //1.RUOLI
                var roleManager = serviceProvider.GetService<RoleManager<IdentityRole>>();
                if(roleManager == null)
                {
                    throw new Exception("Role Manager is null");
                }

                if( ! await roleManager.RoleExistsAsync("Admin"))
                {
                    await roleManager.CreateAsync(new IdentityRole("Admin"));
                }

                if (!await roleManager.RoleExistsAsync("Salesman"))
                {
                    await roleManager.CreateAsync(new IdentityRole("Salesman"));
                }

                if (!await roleManager.RoleExistsAsync("Customer"))
                {
                    await roleManager.CreateAsync(new IdentityRole("Customer"));
                }

                var userManager = serviceProvider.GetService<UserManager<IdentityUser>>();
                if( userManager == null)
                {
                    throw new Exception("User manager is null");
                }

                //Utente 1
                var UserName1 = "alpha@alpha.it";
                var pwd = "P@ssw0rd";
                var user = await userManager.FindByNameAsync(UserName1);
                if (user == null)
                {
                    user = new IdentityUser()
                    {
                        UserName = UserName1,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(user, pwd);
                }
                if (user == null)
                    throw new Exception("Weak Password!");

                await userManager.AddToRoleAsync(user, "Admin");
                

                //Utente 2
                var UserName2 = "beta@beta.it";
                var pwd2 = "P@ssw0rd";
                var user2 = await userManager.FindByNameAsync(UserName2);
                if(user2 == null)
                {
                    user2 = new IdentityUser()
                    {
                        UserName = UserName2,
                        EmailConfirmed = true
                    };
                   await  userManager.CreateAsync(user2, pwd2);
                }
                if(user2 == null)
                {
                    throw new Exception("Weak Password!");
                }

                await userManager.AddToRoleAsync(user2, "Salesman");
                //Utente 3
                var UserName3 = "gamma@gamma.it";
                var pwd3 = "P@ssw0rd";
                var user3 = await userManager.FindByNameAsync(UserName3);
                if(user3 == null)
                {
                    user3 = new IdentityUser()
                    {
                        UserName = UserName3,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(user3, pwd3);
                }
                if(user3 == null)
                {
                    throw new Exception("Weak password");
                }
                await userManager.AddToRoleAsync(user3, "Customer");

                //Utente 4
                var UserName4 = "delta@delta.it";
                var pwd4 = "P@ssw0rd";
                var user4 = await userManager.FindByNameAsync(UserName4);
                if (user4 == null)
                {
                    user4 = new IdentityUser()
                    {
                        UserName = UserName4,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(user4, pwd4);
                }
                if (user4 == null)
                {
                    throw new Exception("Weak password");
                }
                await userManager.AddToRoleAsync(user4, "Customer");

            }
            using (var context = new AutomobiliDbContext(serviceProvider.GetRequiredService<DbContextOptions<AutomobiliDbContext>>()))
            {
                if (!context.Automobili.Any())
                {
                    context.Automobili.AddRange(
                        new Automobile()//Id, Nome, Descrizione, cavalli, data di produzione
                        {
                            PkId = "EIV BEI7374902",
                            NomeModello = "Nissan primera",
                            Descrizione = "Lorem Ipsum",
                            cavalli = 334,
                            data_di_produzione = DateTime.Now,
                            fkUserName = "alpha@alpha.it"
                        },
                        new Automobile()//Id, Nome, Descrizione, cavalli, data di produzione
                        {
                            PkId = "EUBEGO8339",
                            NomeModello = "Nissan primera",
                            Descrizione = "Lorem Ipsum",
                            cavalli = 334,
                            data_di_produzione = DateTime.Now,
                            fkUserName = "alpha@alpha.it"
                        },
                        new Automobile()//Id, Nome, Descrizione, cavalli, data di produzione
                        {
                            PkId = "EVNAE89Q39",
                            NomeModello = "Nissan primera",
                            Descrizione = "Lorem Ipsum",
                            cavalli = 334,
                            data_di_produzione = DateTime.Now,
                            fkUserName = "alpha@alpha.it"
                        },
                        new Automobile()//Id, Nome, Descrizione, cavalli, data di produzione
                        {
                            PkId = "EVINOAE9RWEW8",
                            NomeModello = "Nissan primera",
                            Descrizione = "Lorem Ipsum",
                            cavalli = 334,
                            data_di_produzione = DateTime.Now,
                            fkUserName = "alpha@alpha.it"
                        },
                        new Automobile()//Id, Nome, Descrizione, cavalli, data di produzione
                        {
                            PkId = "VSOIEI9R8Q8",
                            NomeModello = "Nissan primera",
                            Descrizione = "Lorem Ipsum",
                            cavalli = 334,
                            data_di_produzione = DateTime.Now,
                            fkUserName = "alpha@alpha.it"
                        }
                        ) ;

                    context.SaveChanges();
                        
                }
            }

        }
    }
}

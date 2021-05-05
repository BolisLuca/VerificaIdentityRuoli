using AgenziaFotografica.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using WebApp1.Data;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace AgenziaFotografica.Data
{
    public class DataGenerator
    {
       // private readonly SignInManager<IdentityUser> _signInManager;
      //  private readonly UserManager<IdentityUser> _userManager;

        //public RegisterModel(
        //    UserManager<IdentityUser> userManager,
        //    SignInManager<IdentityUser> signInManager)
        //{
        //    _userManager = userManager;
        //    _signInManager = signInManager;
        //}
        public static async Task Initzialize(IServiceProvider serviceProvider)
        {

            using (var context = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                //Creo Ruoli
                var roleManager = serviceProvider.GetService<RoleManager<IdentityRole>>();
                if (roleManager == null)
                {
                    throw new Exception("roleMangarer is null.");
                }

                if(!await roleManager.RoleExistsAsync("Administrator"))
                {
                    await roleManager.CreateAsync(new IdentityRole("Administrator"));
                }
                if (!await roleManager.RoleExistsAsync("Editor"))
                {
                    await roleManager.CreateAsync(new IdentityRole("Editor"));
                }
                if (!await roleManager.RoleExistsAsync("Employee"))
                {
                    await roleManager.CreateAsync(new IdentityRole("Employee"));
                }


                //Utente 1
                var userManager = serviceProvider.GetService<UserManager<IdentityUser>>();
             // var phonenumber = await userManager.FindByEmailAsync("ef").Result.PhoneNumber;
                var UserName = "beta@beta.it";
                var pwd = "Beta@pwd0";
                var user = await userManager.FindByNameAsync(UserName);
                if (user == null)
                {
                    user = new IdentityUser
                    {
                        UserName = UserName,
                        EmailConfirmed = true
                    };
                await userManager.CreateAsync(user, pwd);
                }

                if (user == null)
                {
                    throw new Exception("Weak Password."); //fallito inserimento, unico motivo possibile è la pwd errata
                }
                if (!await roleManager.RoleExistsAsync("Administrator"))
                {
                    throw new Exception("The Administrator role doesn't exist.");
                }

                await userManager.AddToRoleAsync(user, "Administrator");

                if(!await userManager.IsInRoleAsync(user, "Administrator"))//controllo se l'ultima operazione sia fallita o meno
                {
                    throw new Exception("Utente non assegnato.");
                }

                //Utente2
                var UserName2 = "alpha@alpha.it";
                var pwd2= "Alpha@pwd0";
                var user2 = await userManager.FindByNameAsync(UserName2);
                if (user2 == null)
                {
                    user2 = new IdentityUser
                    {
                        UserName = UserName,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(user2, pwd2);
                }

                if (user2 == null)
                {
                    throw new Exception("Weak Password."); //fallito inserimento, unico motivo possibile è la pwd errata
                }
                if (!await roleManager.RoleExistsAsync("Employee"))
                {
                    throw new Exception("The Employee role doesn't exist.");
                }

                await userManager.AddToRoleAsync(user2, "Employee");

                if (!await userManager.IsInRoleAsync(user2, "Employee"))//controllo se l'ultima operazione sia fallita o meno
                {
                    throw new Exception("Utente non assegnato.");
                }


            }

            using (var context = new ModelsDbContext(serviceProvider.GetRequiredService<DbContextOptions<ModelsDbContext>>()))
            {
                if (!(context.Books.Any() || context.Clienti.Any() || context.Modelli.Any()))
                {
                    //context.Users.AddRange(
                    //    new IdentityUser
                    //    {
                    //        Email = "demo@demo.it",
                    //        PasswordHash =
                    //    }
                    //);
                    // var user = new IdentityUser { UserName = "demo@demo.it", Email = "demo@demo.it" };
                    // var result = await _userManager.CreateAsync(user, password);


                    context.Modelli.AddRange(
                        new Modelli //pkModello,NomeModello,DataNascita,NazioneModello,emailModello
                    {
                            pkModello = "mod34",
                            NomeModello = "Rossi Monica",
                            DataNascita = DateTime.Parse("12/07/2002"),
                            NazioneModello = "Italia",
                            emailModello = "rsmn@email.it"
                        },
                        new Modelli
                        {
                            pkModello = "mod03",
                            NomeModello = "Turis Manuel",
                            DataNascita = DateTime.Parse("08/12/1999"),
                            NazioneModello = "Spagna",
                            emailModello = "turis@yahoo.com"


                        },
                        new Modelli
                        {
                            pkModello = "mod12",
                            NomeModello = "Hegel Ruth",
                            DataNascita = DateTime.Parse("24 / 01 / 2000"),
                            NazioneModello = "Olanda",
                            emailModello = "hegr@email.com"

                        }
                        );



                    context.Clienti.AddRange(
                        new Clienti //**Clienti(pkCliente, RagioneSocialeCliente, NazioneCliente, emailCliente)
                    {
                            pkCliente = "kkm2",
                            RagioneSocialeCliente = "Zarni spa",
                            NazioneCliente = "Italia",
                            emailCliente = "zarni@email.com"
                        },
                        new Clienti
                        {
                            pkCliente = "ppb1",
                            RagioneSocialeCliente = "Wagel Zort",
                            NazioneCliente = "Germania",
                            emailCliente = "wz@hotmail.com"
                        },

                        new Clienti
                        {
                            pkCliente = "mmA8",
                            RagioneSocialeCliente = "Desiri srl",
                            NazioneCliente = "Italia",
                            emailCliente = "desi@email.it"
                        }
                        );



                    context.Books.AddRange(
                        new Books //**Books(pkBook,descrizioneBook,dataBook,numeroScatti,fkModello,fkCliente)
                    {
                            pkBook = "bk876",
                            descrizioneBook = "Winter Maldive",
                            dataBook = DateTime.Parse("12/06/2018"),
                            numeroScatti = 34,
                            fkModello = "mod03",
                            fkCliente = "kkm2"



                        },
                        new Books
                        {
                            pkBook = "bk003",
                            descrizioneBook = "Italy by night",
                            dataBook = DateTime.Parse("23/01/2020"),
                            numeroScatti = 41,
                            fkModello = "mod34",
                            fkCliente = "ppb1"
                        },
                        new Books
                        {
                            pkBook = "bk901",
                            descrizioneBook = "Paris mon amour",
                            dataBook = DateTime.Parse("04/02/2019"),
                            numeroScatti = 56,
                            fkModello = "mod03",
                            fkCliente = "mmA8"
                        },
                        new Books
                        {
                            pkBook = "bk456",
                            descrizioneBook = "Aperitivo Belfiore",
                            dataBook = DateTime.Parse("15/02/2020"),
                            numeroScatti = 28,
                            fkModello = "mod12",
                            fkCliente = "ppb1"
                        }
                        );

                    context.SaveChanges();
                }

            }
            }


        }

    }


using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bolis.Data
{
    public class SeedData
    {
        //Oltre a essere statico il task Initzialize ha anche bisogno come parametro di un IserviceProvider per prendere come parametro il ServiceProvider per poter accedere ai servizi che gli serviranno, es: UserManager, RoleManager ecc.
        public static async Task Initzialize(IServiceProvider serviceProvider) //naturalmente questo Task deve essere statico in quanto la sua richiamazione non deve richiedere l'istanza di una classe
        {
            //Cosa deve fare ora la Initzialize:
            /*
             Creare Utenti,
            Creare Ruoli,
            Creare Eventi,
            Associare Ruoli a Utenti

            In quale ordine?
            1.Utenti
            2.Eventi
            3.Ruoli
            4.Ruoli Utenti

            no ha più senso fare prima i Ruoli 

            Top: Prof Like_
            1.Ruoli
            2.Uteti --> a cui associo subito il corispettivo Ruolo, 3.Utenti-Ruoli
            4.Eventi
             */
            /*
             2 using --> 1 per ogni DB --> per ogni context
             
             GetRequiredService restituisce o il servizio o restituisce un eccezzione se quel servizio non esiste
             GetService restituisce il servizio o restituisce null se il servizio non esiste, ma di per se non genera nessuna eccezzione, per questo poi da me devo controllare se la ricerca del servizio ha prodotto un risultato utile o se ha prodotto null e in quel caso generare un eccezzione             
            
             Lavorano con le parentesi angolari per definire il tipo di servizio richiesto, le tonde restano sempre vuote
             */

            using (var context = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>())) //non panicare ricorda che spesso caita che manchino using
            {
                //1.Ruoli
               var RoleManager =  serviceProvider.GetService<RoleManager<IdentityRole>>(); //Role Manager da solo è incompleto, con altre parentesi angolari va definito di che tipo di ruoli si tratta, IdenitityRole

                if (RoleManager == null)
                    throw new Exception("RoleManager is null");
                //I ruoli che creiamo sono istanze della classe IdentityRole, sono IdentityRole con cui stiamo lavorando. --> che ha un costruttore che accetta come parametro una stringa, che diventa il titolo del Ruolo

                //Come creo un Ruolo? --> Idee: Uso il Role Manager per aggiungerlo?

                //Prima controllo, se il ruolo che voglio aggiungere già esiste, se non esiste lo aggiungo

                if(! await RoleManager.RoleExistsAsync("Admin")) //--> ci va l'await, è un task Async
                  await   RoleManager.CreateAsync(new IdentityRole("Admin"));

                if (!await RoleManager.RoleExistsAsync("Editor"))
                  await  RoleManager.CreateAsync(new IdentityRole("Editor"));

                if(! await RoleManager.RoleExistsAsync("Worker"))
                await    RoleManager.CreateAsync(new IdentityRole("Worker"));

                //2.Utenti

                var UserManager = serviceProvider.GetService<UserManager<IdentityUser>>(); //UserManager allo stesso modo di RoleManager vuole sapere di che tipo di utentiti si occupa, IdentityUser, per I ruoli era IdentiryRole

                //Creare gli utenti è un attimo un trick
                    /*
                     1.Definisco le proprietà che dovrà avere il mio utente in delle variabili temporanee --> username e pwd
                    2.Controllo se è già presente--> se non è presente eseguo newIdentityUser e passo Username desiderato 
                     */

                if (UserManager == null)
                    throw new Exception("UserManage is null");

              





            }



        }

    }
}

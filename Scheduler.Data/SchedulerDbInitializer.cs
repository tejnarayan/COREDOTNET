using Scheduler.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scheduler.Data
{
    public class SchedulerDbInitializer
    {
        private static SchedulerContext context;
        public static void Initialize(IServiceProvider serviceProvider)
        {
            context = (SchedulerContext)serviceProvider.GetService(typeof(SchedulerContext));

            InitializeSchedules();
        }

        private static void InitializeSchedules()
        {
            

            if (!context.Contacts.Any())
            {
                Contact c1 = new Contact { FirstName="Arun",LastName="Kumar", Email="abc@gmail.com",PhoneNumber=1233445,Status=1};

                Contact c2 = new Contact { FirstName = "Arun", LastName = "Kumar", Email = "abc@gmail.com", PhoneNumber = 1233445, Status = 1 };

                Contact c3 = new Contact { FirstName = "Arun", LastName = "Kumar", Email = "abc@gmail.com", PhoneNumber = 1233445, Status = 1 };

                Contact c4 = new Contact { FirstName = "Arun", LastName = "Kumar", Email = "abc@gmail.com", PhoneNumber = 1233445, Status = 1 };

                Contact c5 = new Contact { FirstName = "Arun", LastName = "Kumar", Email = "abc@gmail.com", PhoneNumber = 1233445, Status = 1 };

                Contact c6 = new Contact { FirstName = "Arun", LastName = "Kumar", Email = "abc@gmail.com", PhoneNumber = 1233445, Status = 1 };

                context.Contacts.Add(c1); context.Contacts.Add(c2);
                context.Contacts.Add(c3); context.Contacts.Add(c4);
                context.Contacts.Add(c5); context.Contacts.Add(c6);

                context.SaveChanges();
            }
        }
    }
}

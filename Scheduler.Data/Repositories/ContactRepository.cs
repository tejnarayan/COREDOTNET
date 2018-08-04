using Scheduler.Data;
using Scheduler.Data.Abstract;
using Scheduler.Data.Repositories;
using Scheduler.Model;

namespace Sample.Data.Repositories
{
    public  class ContactRepository: EntityBaseRepository<Contact>,IContactRepository
    {
        public ContactRepository(SchedulerContext context) : base(context)
        {

        }
    }
}

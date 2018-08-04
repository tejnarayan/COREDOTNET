using Scheduler.Model;

namespace Scheduler.Model
{
    public class Contact : IEntityBase
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email  {   get; set;}
        public int PhoneNumber { get; set; }
        public int Status { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sample.API.ViewModels;
using Scheduler.API.Core;
using Scheduler.Data.Abstract;
using Scheduler.Model;

namespace Sample.API.Controllers
{
[Route("api/[controller]")]
    public class ContactController : Controller
    {
        private IContactRepository _contactRepository;
        
        int page = 1;
        int pageSize = 10;
        public ContactController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;           
        }

        public IActionResult Get()
        {
            var pagination = Request.Headers["Pagination"];

            if (!string.IsNullOrEmpty(pagination))
            {
                string[] vals = pagination.ToString().Split(',');
                int.TryParse(vals[0], out page);
                int.TryParse(vals[1], out pageSize);
            }

            int currentPage = page;
            int currentPageSize = pageSize;
            var totalUsers = _contactRepository.Count();
            var totalPages = (int)Math.Ceiling((double)totalUsers / pageSize);

            IEnumerable<Contact> _contacts = _contactRepository
                .GetAll()
                .OrderBy(u => u.Id)
                .Skip((currentPage - 1) * currentPageSize)
                .Take(currentPageSize)
                .ToList();

            IEnumerable<ContactViewModel> _usersVM = Mapper.Map<IEnumerable<Contact>, IEnumerable<ContactViewModel>>(_contacts);

            Response.AddPagination(page, pageSize, totalUsers, totalPages);

            return new OkObjectResult(_usersVM);
        }

        [HttpGet("{id}", Name = "GetContact")]
        public IActionResult Get(int id)
        {
            Contact _contact = _contactRepository.GetSingle(u => u.Id == id);

            if (_contact != null)
            {
                ContactViewModel _contactVM = Mapper.Map<Contact, ContactViewModel>(_contact);
                return new OkObjectResult(_contactVM);
            }
            else
            {
                return NotFound();
            }
        }
          


        [HttpPost]
        public IActionResult Create([FromBody]ContactViewModel contact)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Contact _newContact = new Contact { FirstName = contact.FirstName, LastName = contact.LastName, Email = contact.Email
            ,PhoneNumber=contact.PhoneNumber,Status=contact.Status};

            _contactRepository.Add(_newContact);
            _contactRepository.Commit();

            contact = Mapper.Map<Contact, ContactViewModel>(_newContact);

            CreatedAtRouteResult result = CreatedAtRoute("GetContact", new { controller = "Contact", id = contact.Id }, contact);
            return result;
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]ContactViewModel contact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Contact _contact = _contactRepository.GetSingle(id);

            if (_contact == null)
            {
                return NotFound();
            }
            else
            {
                _contact.FirstName = contact.FirstName;
                _contact.LastName = contact.LastName;
                _contact.Email = contact.Email;
                _contact.PhoneNumber = contact.PhoneNumber;
                _contact.Status = contact.Status;
                _contactRepository.Commit();
            }

            contact = Mapper.Map<Contact, ContactViewModel>(_contact);

            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Contact _contact = _contactRepository.GetSingle(id);

            if (_contact == null)
            {
                return new NotFoundResult();
            }
            else
            {
                

                _contactRepository.Delete(_contact);

                _contactRepository.Commit();

                return new NoContentResult();
            }
        }
    }
}

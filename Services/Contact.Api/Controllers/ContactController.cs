using Contact.API.Infrastructure;
using Contact.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Contact.Api.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;
        public ContactController(IContactService contactService)
        {
            this._contactService = contactService;
        }

        [HttpGet("{id}")] 
        public ContactDTO Get(int id)
        {
            return _contactService.GetContactById(id);
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using SimpleContactManager.InMemoryDb;
using SimpleContactManager.Models;

namespace SimpleContactManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {

        [HttpGet]
        public IActionResult Get()
        {
            using (var _helper = new ContactDbHelper())
            {
                var result = _helper.GetContacts();
                if (result != null)
                {
                    return Ok(result);
                }
                return NotFound();
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            using (var _helper = new ContactDbHelper())
            {
                var result = _helper.GetContact(id);
                if (result != null)
                {
                    return Ok(result);
                }
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult Post(Contact contact)
        {
            using (var _helper = new ContactDbHelper())
            {
                var result = _helper.Create(contact);
                return Ok(result);
            }
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            using (var _helper = new ContactDbHelper())
            {
                var result = _helper.Delete(id);
                return Ok(result);
            }
        }
    }
}

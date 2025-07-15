using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.ComponentModel;
using Testbga.Models;

namespace Testbga.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComponentController : ControllerBase
    {

        private readonly CustomContext _context;

        public ComponentController(CustomContext context)
        {
            _context = context;
        }


        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            Testbga.Models.Component page = new Testbga.Models.Component();

            return Ok(page);
        }

        [HttpPost("create")]
        public ActionResult Create(Testbga.Models.Component component)
        {
            //var c = json;
            //var a = json.ToObject<Page>();
            Page page = new Page();
            page.Name = component.Name;
            page.Data = component.Data;
            page.Containings = component.Containings;
            foreach (var item in component.Containings)
            {
                Console.WriteLine(item);
                var n = item.Component;
                Console.WriteLine(n);
            }
            page.CreatePage(_context);
            return Ok(page);

            //return Ok(c);
        }


    }
}

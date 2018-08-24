using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using AllCore.EFCore;
using AllCore.Models;

namespace AllCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly XContext _context;

        public ValuesController(XContext context)
        {
            _context = context;
        }
        // GET api/values
        [HttpGet]
        public async Task<ActionResult<object>> Get()
        {
            //注意循环引用
            //Activity activity = _context.Activities.Include(x => x.Items).ThenInclude(y => y.Goods).ThenInclude(z=>z.Catalog).FirstOrDefault();
            //return activity;

            //List<Goods> goods = await _context.Goods.Include(o=>o.Catalog).Include(x => x.ActivityItem).ThenInclude(y => y.Activity).ToListAsync();
            List<Goods> goods = await _context.Goods.Include(o => o.Catalog).ToListAsync();
            return goods;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

using hmwrk64.scraping;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hmwrk64.web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LakewoodScoopController : ControllerBase
    {
        [HttpGet]
        [Route("scrape")]
        public List<Post> Scrape()
        {
            return LakewoodScoop.Scrape();
        }
    }
}

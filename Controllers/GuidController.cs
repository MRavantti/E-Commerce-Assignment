using System;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    [Route("api/[controller]")]
    public class MyGuidController : Controller
        {
            [HttpGet]
            public Guid Get()
            {
                Guid guid;
                guid = Guid.NewGuid();
                return guid;
            }
        }
}

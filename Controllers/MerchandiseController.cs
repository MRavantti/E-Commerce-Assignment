using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace E_Commerce
{

    [Route("api/[controller]")]
    public class MerchandiseController : ControllerBase
    {
        private readonly string connectionString;

        private readonly MerchendiseService merchendiseService;

        public MerchandiseController(IConfiguration configuration)
        {
            this.connectionString = configuration.GetConnectionString("ConnectionString");
            this.merchendiseService = new MerchendiseService(new MerchandiseRepository(connectionString));
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Merchandise>), StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            return Ok(this.merchendiseService.Get());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Merchandise), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(int id)
        {
            return Ok(this.merchendiseService.Get(id));
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody]Merchandise merchandise)
        {
            var result = this.merchendiseService.Add(merchandise);

            if (!result)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(int id)
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                var merchandiseItem = connection.QuerySingleOrDefault<Merchandise>("SELECT * FROM Merchandise WHERE id = @id", new { id });

                if (merchandiseItem == null)
                {
                    return NotFound();
                }

                connection.Execute("DELETE FROM Merchandise WHERE Id = @id", new { id });
                return Ok();
            }
        }
    }
}
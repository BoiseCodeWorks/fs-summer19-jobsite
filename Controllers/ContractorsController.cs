using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobsite.Models;
using Jobsite.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Jobsite.Controllers
{
    [Route("api/[controller]")] // api/contractors
    [ApiController]
    public class ContractorsController : ControllerBase
    {
        private readonly ContractorsRepository _Repo;
        public ContractorsController(ContractorsRepository repo)
        {
            _Repo = repo;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Contractor>> Get()
        {
            try
            {
                return Ok(_Repo.GetAll());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Contractor> Get(int id)
        {
            try
            {
                return Ok(_Repo.GetById(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public ActionResult<Contractor> Post([FromBody] Contractor c)
        {
            try
            {
                return Ok(_Repo.Create(c));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // [HttpPut]
        // public ActionResult<Job> Put([FromBody] Job job)
        // {

        // }

        [HttpDelete("{id}")]
        public ActionResult<string> Delete(int id)
        {
            try
            {
                return Ok(_Repo.Delete(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}

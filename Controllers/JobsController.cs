using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobsite.Models;
using Jobsite.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Jobsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly JobsRepository _JobsRepo;
        public JobsController(JobsRepository jobsRepo) 
        {
            _JobsRepo = jobsRepo;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Job>> Get()
        {
            try
            {
                return Ok(_JobsRepo.GetAll());                
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Job> Get(int id)
        {
            try
            {
                return Ok(_JobsRepo.GetById(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public ActionResult<Job> Post([FromBody] Job job)
        {
            try
            {
               return Ok(_JobsRepo.Post(job)); 
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public ActionResult<Job> Put([FromBody] Job job)
        {
            try
            {
                return Ok(_JobsRepo.Put(job));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<string> Delete(int id)
        {
            try
            {
                return Ok(_JobsRepo.DeleteById(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}

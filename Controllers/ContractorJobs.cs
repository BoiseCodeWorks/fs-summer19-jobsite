using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobsite.Models;
using Jobsite.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Jobsite.Controllers
{
    [Route("api/contractor-jobs")] // api/contractors
    [ApiController]
    public class ContractorJobsController : ControllerBase
    {
        private readonly ContractorJobsRepository _Repo;
        public ContractorJobsController(ContractorJobsRepository repo)
        {
            _Repo = repo;
        }

        [HttpGet("{cId}/jobs")]
        public ActionResult<IEnumerable<Contractor>> GetJobsByContractor(int cId)
        {
            try
            {
                return Ok(_Repo.GetJobsByContractor(cId));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpGet("{jId}/contractors")]
        public ActionResult<IEnumerable<ContractorOnJob>> GetContractorsByJob(int jId)
        {
            try
            {
                return Ok(_Repo.GetContractorsByJob(jId));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }





















        // [HttpGet("{id}")]
        // public ActionResult<Contractor> Get(int id)
        // {
        //     try
        //     {
        //         return Ok(_Repo.GetById(id));
        //     }
        //     catch (Exception e)
        //     {
        //         return BadRequest(e.Message);
        //     }
        // }

        // [HttpPost]
        // public ActionResult<Contractor> Post([FromBody] Contractor c)
        // {
        //     try
        //     {
        //         return Ok(_Repo.Create(c));
        //     }
        //     catch (Exception e)
        //     {
        //         return BadRequest(e.Message);
        //     }
        // }

        // // [HttpPut]
        // // public ActionResult<Job> Put([FromBody] Job job)
        // // {

        // // }

        // [HttpDelete("{id}")]
        // public ActionResult<string> Delete(int id)
        // {
        //     try
        //     {
        //         return Ok(_Repo.Delete(id));
        //     }
        //     catch (Exception e)
        //     {
        //         return BadRequest(e.Message);
        //     }
        // }
    }
}

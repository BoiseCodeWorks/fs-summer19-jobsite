using System;
using System.Collections.Generic;
using System.Data;
using Jobsite.Models;
using Dapper;

namespace Jobsite.Repositories
{
    public class ContractorJobsRepository
    {
        private readonly IDbConnection _db;
        public ContractorJobsRepository(IDbConnection db)
        {
            _db = db;
        }

        public IEnumerable<Job> GetJobsByContractor(int cId)
        {
            try
            {
                string query = @"SELECT * FROM contractorJobs cj 
                INNER JOIN jobs j ON j.id = cj.jobId
                WHERE contractorId = @cId;";
                return _db.Query<Job>(query, new { cId });
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IEnumerable<ContractorOnJob> GetContractorsByJob(int jId)
        {
            try
            {
                string query = @"SELECT * FROM contractorJobs cj
                INNER JOIN contractors c ON c.id = cj.contractorId
                WHERE jobId = @jId;";
                return _db.Query<ContractorOnJob>(query, new { jId });
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
using System.Data;
using Jobsite.Models;
using System.Collections.Generic;
using Dapper;
using System;

namespace Jobsite.Repositories
{
    public class JobsRepository
    {
        private readonly IDbConnection _db;
        public JobsRepository(IDbConnection db)
        {
            _db = db;
        }

        public IEnumerable<Job> GetAll()
        {
            try
            {
                return _db.Query<Job>("Select * FROM jobs;");                
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public Job GetById(int id) 
        {
            try
            {
                Job job = _db.QueryFirstOrDefault<Job>("SELECT * FROM jobs WHERE id = @id;", new { id });
                if (job is null) throw new Exception("No Job with that Id.");
                return job;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public Job Post(Job job)
        {
            try
            {
                int id = _db.ExecuteScalar<int>(@"INSERT INTO jobs (type, createdAt, location)
                VALUES (@Type, @CreatedAt, @Location); SELECT LAST_INSERT_ID();", job);
                if (id < 1) throw new Exception("Unable to save job to db.");
                job.Id = id;
                return job;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public Job Put(Job job)
        {
            try
            {
               int success = _db.Execute(@"UPDATE jobs
               SET type = @Type, location = @Location
               WHERE id = @Id;", job);
               if (success != 1) throw new Exception("Something has gone horribly wrong.");
               return job; 
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public String DeleteById(int id)
        {
            try
            {
                int success = _db.Execute("DELETE FROM jobs WHERE id = @id;", new { id });
                if (success != 1) throw new Exception("Something has gone horribly wrong.");
                return "Job deleted!";
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
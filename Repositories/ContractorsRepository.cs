using System;
using System.Collections.Generic;
using System.Data;
using Jobsite.Models;
using Dapper;

namespace Jobsite.Repositories
{
    public class ContractorsRepository
    {
        private readonly IDbConnection _db;
        public ContractorsRepository(IDbConnection db)
        {
            _db = db;
        }

        public IEnumerable<Contractor> GetAll()
        {
            try
            {
                return _db.Query<Contractor>("SELECT * FROM contractors;");
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public Contractor GetById(int id)
        {
            try
            {
                Contractor c = _db.QueryFirstOrDefault<Contractor>(@"SELECT * FROM contractors
                WHERE id = @id", new { id });
                if (c is null) throw new Exception("Bad id bro");
                return c;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public Contractor Create(Contractor c)
        {
            try
            {
                int id = _db.ExecuteScalar<int>(@"INSERT INTO contractors (name, pricePerHour, basePrice)
                VALUES (@Name, @PricePerHour, @BasePrice); SELECT LAST_INSERT_ID();", c);
                if (id < 1) throw new Exception("Something has gone horribly wrong.");
                c.Id = id;
                return c;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public string Delete(int id)
        {
            try
            {
                int success = _db.Execute("DELETE FROM contractors WHERE id = @id", new { id });
                if (success != 1) throw new Exception("Something has gone horribly wrong.");
                return "She gone.";
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
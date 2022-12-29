using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net;
using CoreApiResponse;
using MagnetoAPI.Controllers;
using System.Threading.Tasks;

namespace MagnetoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]    
    public class MutantController : BaseController
    {
        Mutant_db dbop = new Mutant_db();
        string msg = string.Empty;      

        //GET: api/<dnaController>
        [HttpGet]
        public IActionResult Get()
        {
            Mutant dna = new Mutant();
            DataSet ds = dbop.MutantGet(dna, out msg);
            List<Mutant> list = new List<Mutant>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(new Mutant
                {
                    dna = dr["dna"].ToString(),
                });
            }
            if (msg == "SUCCESS")
            {
                return CustomResult(list, HttpStatusCode.OK);
            }
            else
            {
                return CustomResult(list, HttpStatusCode.Forbidden);
            }
                
        }

        //POST
        [HttpPost]
        public IActionResult Post([FromBody] Mutant dna)
        {
            dbop.DnaAdd(dna, out msg);
            if (msg == "SUCCESS")
            {
                return CustomResult("SUCCESS",HttpStatusCode.OK);
            }
            else
            {
                return CustomResult(HttpStatusCode.Forbidden);
            }
        }

    }
        
    
}
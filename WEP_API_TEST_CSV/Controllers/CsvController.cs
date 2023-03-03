using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEP_API_TEST_CSV.models;

namespace WEP_API_TEST_CSV.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CsvController : ControllerBase
    {
        private readonly CsvDbContext dbContext;

        public CsvController(CsvDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CSVDoc>>> Get()
        {
            return await dbContext.CsvDocs.ToListAsync();
        }


        [HttpPost]
        public async Task<ActionResult<CSVDoc>> Post(CSVDoc CsvDoc)
        {

            if (CsvDoc == null)
            {
                return BadRequest();
            }
            else
            {
                dbContext.CsvDocs.Add(CsvDoc);
              await dbContext.SaveChangesAsync();
                return Ok(CsvDoc);
            }
        }

        [HttpPut]
        public async Task<ActionResult<CSVDoc>> Put(CSVDoc CsvDoc)
        {
            if (CsvDoc == null)
            {
                return BadRequest();
            }
            if (!dbContext.CsvDocs.Any(x => x.Id == CsvDoc.Id))
            {
                return NotFound();
            }

            dbContext.Update(CsvDoc);
            await dbContext.SaveChangesAsync();
            return Ok(CsvDoc);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<CSVDoc>> Delete(int id)
        {
            CSVDoc CsvDoc = dbContext.CsvDocs.FirstOrDefault(x => x.Id == id);
            if (CsvDoc == null)
            {
                return NotFound();
            }
            dbContext.CsvDocs.Remove(CsvDoc);
            await dbContext.SaveChangesAsync();
            return Ok(CsvDoc);
        }

    }
}

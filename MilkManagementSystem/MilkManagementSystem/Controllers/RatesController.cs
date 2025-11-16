using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MilkManagementSystem.Excel;
using MilkManagementSystem.Models;


namespace MilkManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatesController : ControllerBase
    {
        private readonly MilkMgtSystemContext _context;
        
        public RatesController(MilkMgtSystemContext context)
        {
            _context = context;
            

        }

        [HttpGet]
       
        public async Task<ActionResult> CalculateMilkrRates()
        {
            Rates _rates = new Rates();
            var ratedata = await _context.Milkerates.ToListAsync();

           // _rates.CalculateMilkRate((double)ratedata[0].Fatrate, (double)ratedata[0].Snfrate);

            return Ok(ratedata);
        }


        [HttpPost]

        public  async Task<ActionResult> CalculateMilkrRates([FromBody] Milkerate milkerate)
        {
            Rates _rates = new Rates();
        //var ratedata = await _context.Milkerates.ToListAsync();
        _rates.CalculateMilkRate((double)milkerate.Fatrate, (double)milkerate.Snfrate);

            await _context.SaveChangesAsync();
            return Ok("Rate Updated sucessfully...");
        }


    }
}

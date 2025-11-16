using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using MilkManagementSystem.DTOS;
using MilkManagementSystem.Models;

namespace MilkManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollectionController : ControllerBase
    {
       private readonly MilkMgtSystemContext _context;
       
        
        public CollectionController(MilkMgtSystemContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult> GetCollection()
        {
            var CollectionData = await _context.Milkcollections.ToListAsync();

            if (CollectionData == null)
            {
                return NotFound();
            }

            return Ok(CollectionData);
        }

        [HttpGet("id")]
        public async Task<ActionResult> GetCollection(int id)
        {
            var CollectionData = await _context.Milkcollections.FirstOrDefaultAsync(x => x.Customerid == id);

            if (CollectionData == null)
            {
                return NotFound();
            }

            return Ok(CollectionData);
        }

        [HttpPost("Collection/{id}")]
        public async Task<ActionResult> CreateCollection(int id, [FromBody] CollectionDTO collectionDTO)
        {
           var CurrentdateTime = DateTime.Now.Hour;
            try
            {
                var CustomerExist = await _context.Milkcollections.FirstOrDefaultAsync( x => x.Customerid== id);

                                   
                
                if (CurrentdateTime <= 11.59)
                {
                    collectionDTO.shift = Shift.Morning;
                }
                else
                {
                    collectionDTO.shift = Shift.Evening;
                }

                


                if (CustomerExist!= null)
                {
                    
                    if (collectionDTO.Milktypeid == 1)
                    {
                        var MilkCollection = new Milkcollection
                        {
                            Customerid = CustomerExist.Customerid,
                            Milktypeid = collectionDTO.Milktypeid,
                            Liter = (decimal?)(float?)collectionDTO.Liter,
                            Fat = collectionDTO.Fat,
                            Snf = collectionDTO.Snf,
                            Total = Convert.ToInt32(collectionDTO.Fat * (35 * Convert.ToInt32(collectionDTO.Liter)))    ,
                            Rate = collectionDTO.Rate,
                            Collectionshift = collectionDTO.shift.ToString()
                        };
                        
                        await _context.Database.ExecuteSqlRawAsync(
                                                                    "Exec USP_ADDCOLLECTION @Customerid={0}, @Milktypeid={1}, @Liter={2}, @Fat={3}, @Snf={4}, @Total={5}, @Rate={6},@Shift={7}",
                                                                    MilkCollection.Customerid,
                                                                    MilkCollection.Milktypeid,
                                                                    MilkCollection.Liter,
                                                                    MilkCollection.Fat,
                                                                    MilkCollection.Snf,
                                                                    MilkCollection.Total,
                                                                    MilkCollection.Rate,
                                                                    MilkCollection.Collectionshift);
                        //await _context.SaveChangesAsync();
                    }

                    if (collectionDTO.Milktypeid == 2)
                    {
                        var MilkCollection = new Milkcollection
                        {
                            Customerid = collectionDTO.Customerid,
                            Milktypeid = collectionDTO.Milktypeid,
                            Liter = (decimal?)(float?)collectionDTO.Liter,
                            Fat = collectionDTO.Fat,
                            Snf = collectionDTO.Snf,
                            Total = Convert.ToInt32(collectionDTO.Fat *( 8 * Convert.ToInt32(collectionDTO.Liter))),
                            Rate = collectionDTO.Rate,
                            Collectionshift = collectionDTO.shift.ToString()
                        };
                        
                        await _context.Database.ExecuteSqlRawAsync(
                                                                    "Exec USP_ADDCOLLECTION @Customerid={0}, @Milktypeid={1}, @Liter={2}, @Fat={3}, @Snf={4}, @Total={5}, @Rate={6},@shift={7}",
                                                                    MilkCollection.Customerid,
                                                                    MilkCollection.Milktypeid,
                                                                    MilkCollection.Liter,
                                                                    MilkCollection.Fat,
                                                                    MilkCollection.Snf,
                                                                    MilkCollection.Total,
                                                                    MilkCollection.Rate,
                                                                    MilkCollection.Collectionshift
                                                                    );
                        //await _context.Milkcollections.AddAsync(MilkCollection);
                        //await _context.SaveChangesAsync();
                    }

              }
                

                return Ok("Data Saved Sucessfully..");
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);  
            }
           
        }
    }
}

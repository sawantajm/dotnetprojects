using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilkManagementSystem.DTOS;
using MilkManagementSystem.Models;

namespace MilkManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodDeatailsController : ControllerBase
    {
        private readonly MilkMgtSystemContext _context; 


        public FoodDeatailsController(MilkMgtSystemContext context)
        {
            _context = context;
        }


        [HttpGet]

        public async Task<ActionResult> GetFoodDetails()
        {
            var details = from food in _context.FoodDetails
                          join cust in _context.Customers
                          on food.Customerid equals  cust.Customerid
                          select new
                          {
                              food.Srno,
                              food.Foodname,
                              NAME = cust.FirstName + " " + cust.LastName,
                              food.Quantity,
                              food.Rate,
                              food.Amount,
                              Date = Convert.ToString(food.Dateadded)

                          };
            if (details != null && details.Count() > 0) {
                return Ok(details);
            }

            return BadRequest("Data is not present...");
          


        }

        [HttpPost("Sell/Food/{id}")]

        public async Task<ActionResult> SellFood(int id, [FromBody] FoodDeatilsDTO fooddetailDTO)
        {
            try
            {
                var Cutomerexist = await _context.Customers.FindAsync(id);


                if (Cutomerexist != null)
                {
                   
                    int TotalAmount = 0;
                    foreach (var item in fooddetailDTO.FoodItems)
                    {
                        var FoodItems = await _context.Foods.FindAsync(item.Foodid);

                        if (FoodItems == null)
                        {
                            return BadRequest($"{item.FoodName} Stock not available...");
                        }
                        if(FoodItems.Stock < fooddetailDTO.Quantity)
                        {
                            return BadRequest($"insufficient Stock {item.FoodName}");

                        }
                        FoodItems.Stock -= fooddetailDTO.Quantity;
                        TotalAmount = Convert.ToInt32(fooddetailDTO.Quantity * FoodItems.SellingRate);

                        var createfood = new FoodDetail
                        {
                            
                            Rate = Convert.ToInt32(FoodItems.SellingRate),
                            Amount = TotalAmount,
                            Quantity = Convert.ToInt32(fooddetailDTO.Quantity),
                            Foodname = FoodItems.FoodName,
                            Customerid = Cutomerexist.Customerid,
                            Dateadded = DateTime.Now,
                            Datechanged =DateTime.Now,
                            Deleteflag = false,
                            FoodId = item.Foodid
                        };

                        await _context.AddAsync(createfood);
                    }

                   

                   
                    await _context.SaveChangesAsync();

                    return Ok("Data Added sucessfully.....");
                }

                return Ok("Customer Not Exist....");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            
        }
    }
}

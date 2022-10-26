using APICapstoneProject.Data;
using APICapstoneProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using System.ComponentModel.DataAnnotations;



namespace APICapstoneProject.Controllers

{

    [ApiController]

    [Route("api/[controller]")]

    public class OrderDetailsController : Controller

    {

        private readonly OrderDetailDBContext orderDetailDBContext;



        public OrderDetailsController(OrderDetailDBContext orderDetailDBContext)

        {

            this.orderDetailDBContext = orderDetailDBContext;

        }



        // Get all Order Details

        [HttpGet]

        public async Task<IActionResult> GetAllOrderDetails()

        {

            var orderDetails = await orderDetailDBContext.OrderDetails.ToListAsync();

            return Ok(orderDetails);

        }



        // Get Single Order Detail

        [HttpGet]

        [Route("{uid}")]

        [ActionName("GetOrderDetail")]

        public async Task<IActionResult> GetOrderDetail([FromRoute] string uid)

        {

            var orderDetails = await orderDetailDBContext.OrderDetails.FirstOrDefaultAsync(x => x.Uid == uid);

            if (orderDetails != null)

            {

                return Ok(orderDetails);

            }

            return NotFound("Not Found");

        }



        //Add Order Detail



        [HttpPost]



        public async Task<IActionResult> AddOrderDetail([FromBody] OrderDetail orderDetail)

        {

            //orderDetail.Uid = Guid.NewGuid().ToString();





            await orderDetailDBContext.OrderDetails.AddAsync(orderDetail);

            await orderDetailDBContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetOrderDetail), new { uid = orderDetail.Uid }, orderDetail);

        }





        //update Order Detail

        [HttpPut]

        [Route("{uid}")]

        public async Task<IActionResult> UpdateOrderDetail(string uid, [FromBody] OrderDetail orderDetail)

        {

            var ExistingOrderDetail = await orderDetailDBContext.OrderDetails.FirstOrDefaultAsync(x => x.Uid == uid);



            if (ExistingOrderDetail != null)

            {

                ExistingOrderDetail.Uid = orderDetail.Uid;

                ExistingOrderDetail.Email = orderDetail.Email;

                ExistingOrderDetail.FurnitureNeeded = orderDetail.FurnitureNeeded;

                ExistingOrderDetail.EquipmentNeeded = orderDetail.EquipmentNeeded;

                ExistingOrderDetail.ShippingAddress = orderDetail.ShippingAddress;


                ExistingOrderDetail.DeliveryDate = orderDetail.DeliveryDate;



                await orderDetailDBContext.SaveChangesAsync();

                return Ok(ExistingOrderDetail);



            }

            return NotFound("Not Found");

        }







        //delete Order Detail
        [HttpDelete]

        [Route("{uid}")]

        public async Task<IActionResult> DeleteOrderRequest(string uid)

        {

            var ExistingOrderDetail = await orderDetailDBContext.OrderDetails.FirstOrDefaultAsync(x => x.Uid == uid);



            if (ExistingOrderDetail != null)

            {

                orderDetailDBContext.Remove(ExistingOrderDetail);

                await orderDetailDBContext.SaveChangesAsync();

                return Ok(ExistingOrderDetail);



            }

            return NotFound("Not Found");

        }

    }

}
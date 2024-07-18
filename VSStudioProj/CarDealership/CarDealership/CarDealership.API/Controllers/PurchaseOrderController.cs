using Microsoft.AspNetCore.Mvc;
using CarDealership.API.Entities;
using CarDealership.API.Data;
using CarDealership.API.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarDealership.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseOrderController : ControllerBase
    {
        private readonly DataContext _context;

        public PurchaseOrderController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<PurchaseOrderDTO>>> GetAllPurchaseOrders()
        {
            var purchaseOrders = await _context.PurchaseOrderEntities.ToListAsync();
            var purchaseOrderDTOs = purchaseOrders.Select(po => new PurchaseOrderDTO
            {
                OrderID = po.OrderID,
                VIN = po.VIN,
                CustomerID = po.CustomerID
                // Map other properties as needed
            }).ToList();

            return Ok(purchaseOrderDTOs);
        }

        [HttpGet("{orderID}")]
        public async Task<ActionResult<PurchaseOrderDTO>> GetPurchaseOrder(int orderID)
        {
            var purchaseOrder = await _context.PurchaseOrderEntities.FindAsync(orderID);
            if (purchaseOrder is null)
                return NotFound("Purchase order not found");

            var purchaseOrderDTO = new PurchaseOrderDTO
            {
                OrderID = purchaseOrder.OrderID,
                VIN = purchaseOrder.VIN,
                CustomerID = purchaseOrder.CustomerID
                // Map other properties as needed
            };

            return Ok(purchaseOrderDTO);
        }

        [HttpPost]
        public async Task<ActionResult<List<PurchaseOrderDTO>>> AddPurchaseOrder(CreatePurchaseOrderDTO createPurchaseOrderDTO)
        {
            var purchaseOrder = new PurchaseOrderEntity
            {
                VIN = createPurchaseOrderDTO.VIN,
                CustomerID = createPurchaseOrderDTO.CustomerID
                // Map other properties as needed
            };

            _context.PurchaseOrderEntities.Add(purchaseOrder);
            await _context.SaveChangesAsync();

            var purchaseOrderDTOs = await _context.PurchaseOrderEntities.Select(po => new PurchaseOrderDTO
            {
                OrderID = po.OrderID,
                VIN = po.VIN,
                CustomerID = po.CustomerID
                // Map other properties as needed
            }).ToListAsync();

            return Ok(purchaseOrderDTOs);
        }

        [HttpPut]
        public async Task<ActionResult<List<PurchaseOrderDTO>>> UpdatePurchaseOrder(UpdatePurchaseOrderDTO updatePurchaseOrderDTO)
        {
            var dbPurchaseOrder = await _context.PurchaseOrderEntities.FindAsync(updatePurchaseOrderDTO.OrderID);
            if (dbPurchaseOrder is null)
                return NotFound("Purchase order not found");

            dbPurchaseOrder.VIN = updatePurchaseOrderDTO.VIN;
            dbPurchaseOrder.CustomerID = updatePurchaseOrderDTO.CustomerID;
            // Update other properties as needed

            await _context.SaveChangesAsync();

            var purchaseOrderDTOs = await _context.PurchaseOrderEntities.Select(po => new PurchaseOrderDTO
            {
                OrderID = po.OrderID,
                VIN = po.VIN,
                CustomerID = po.CustomerID
                // Map other properties as needed
            }).ToListAsync();

            return Ok(purchaseOrderDTOs);
        }

        [HttpDelete("{orderID}")]
        public async Task<ActionResult<List<PurchaseOrderDTO>>> DeletePurchaseOrder(int orderID)
        {
            var dbPurchaseOrder = await _context.PurchaseOrderEntities.FindAsync(orderID);
            if (dbPurchaseOrder is null)
                return NotFound("Purchase order not found");

            _context.PurchaseOrderEntities.Remove(dbPurchaseOrder);
            await _context.SaveChangesAsync();

            var purchaseOrderDTOs = await _context.PurchaseOrderEntities.Select(po => new PurchaseOrderDTO
            {
                OrderID = po.OrderID,
                VIN = po.VIN,
                CustomerID = po.CustomerID
                // Map other properties as needed
            }).ToListAsync();

            return Ok(purchaseOrderDTOs);
        }
    }
}
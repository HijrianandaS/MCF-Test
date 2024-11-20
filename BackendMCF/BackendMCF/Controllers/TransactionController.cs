using BackendMCF.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendMCF.Controllers
{
    [Route("api/Bpkb")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TransactionController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            var transactions = _context.TrBpkbs.ToList();
            return Ok(new { Message = "Data retrieved successfully", Data = transactions });
        }

        [HttpGet]
        [Route("GetById/{agreementNumber}")]
        public IActionResult GetById(string agreementNumber)
        {
            var transaction = _context.TrBpkbs.FirstOrDefault(t => t.AgreementNumber == agreementNumber);

            if (transaction == null)
            {
                return NotFound(new { Message = "Transaction not found" });
            }

            return Ok(new { Message = "Data retrieved successfully", Data = transaction });
        }

        [HttpPost]
        [Route("Add")]
        public IActionResult Add([FromBody] TrBpkb bpkb)
        {
            if (bpkb == null)
            {
                return BadRequest(new { Message = "Invalid data" });
            }

            // Validasi location_id
            var locationExists = _context.MsStorageLocations.Any(l => l.LocationId == bpkb.LocationId);
            if (!locationExists)
            {
                return BadRequest(new { Message = "Invalid. The specified location does not exist." });
            }

            // Periksa apakah transaksi dengan agreement_number sudah ada
            var existingTransaction = _context.TrBpkbs.FirstOrDefault(t => t.AgreementNumber == bpkb.AgreementNumber);
            if (existingTransaction != null)
            {
                return BadRequest(new { Message = "Transaction with this agreement number already exists" });
            }

            // Tambahkan transaksi baru
            _context.TrBpkbs.Add(bpkb);
            _context.SaveChanges();
            return Ok(new { Message = "Data added successfully", Data = bpkb });
        }


        [HttpPut]
        [Route("Update/{agreementNumber}")]
        public IActionResult Update(string agreementNumber, [FromBody] TrBpkb updatedBpkb)
        {
            if (updatedBpkb == null || agreementNumber != updatedBpkb.AgreementNumber)
            {
                return BadRequest(new { Message = "Invalid data" });
            }

            // Validasi location_id
            var locationExists = _context.MsStorageLocations.Any(l => l.LocationId == updatedBpkb.LocationId);
            if (!locationExists)
            {
                return BadRequest(new { Message = "Invalid location_id. The specified location does not exist." });
            }

            var existingBpkb = _context.TrBpkbs.FirstOrDefault(t => t.AgreementNumber == agreementNumber);

            if (existingBpkb == null)
            {
                return NotFound(new { Message = "Transaction not found" });
            }

            // Update properties
            existingBpkb.BpkbNo = updatedBpkb.BpkbNo;
            existingBpkb.BranchId = updatedBpkb.BranchId;
            existingBpkb.BpkbDate = updatedBpkb.BpkbDate;
            existingBpkb.FakturNo = updatedBpkb.FakturNo;
            existingBpkb.FakturDate = updatedBpkb.FakturDate;
            existingBpkb.LocationId = updatedBpkb.LocationId;
            existingBpkb.PoliceNo = updatedBpkb.PoliceNo;
            existingBpkb.BpkbDateIn = updatedBpkb.BpkbDateIn;
            existingBpkb.LastUpdatedBy = updatedBpkb.LastUpdatedBy;
            existingBpkb.LastUpdatedOn = updatedBpkb.LastUpdatedOn;

            _context.SaveChanges();
            return Ok(new { Message = "Data updated successfully", Data = existingBpkb });
        }

        [HttpDelete]
        [Route("Delete/{agreementNumber}")]
        public IActionResult Delete(string agreementNumber)
        {
            var transaction = _context.TrBpkbs.FirstOrDefault(t => t.AgreementNumber == agreementNumber);

            if (transaction == null)
            {
                return NotFound(new { Message = "Transaction not found" });
            }

            _context.TrBpkbs.Remove(transaction);
            _context.SaveChanges();
            return Ok(new { Message = "Data deleted successfully", Data = transaction });
        }
    }
}

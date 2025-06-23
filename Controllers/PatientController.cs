using Microsoft.AspNetCore.Mvc;
using HospitalSystemAPI.Models;
using HospitalSystemAPI.Data;

namespace HospitalSystemAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PatientController(AppDbContext context)
        {
            _context = context;
        }

        // ✅ REGISTER API — Clean model binding (no [FromBody])
        [HttpPost("register")]
        public IActionResult Register(Patient patient)
        {
            // Check if already registered by email
            var exists = _context.Patients.FirstOrDefault(p => p.Email == patient.Email);
            if (exists != null)
                return BadRequest("Already registered");

            _context.Patients.Add(patient);
            _context.SaveChanges();

            return Ok(new { message = "Registered successfully", patient.Id });
        }

        // ✅ LOGIN API — Use FromBody here (because it's not full model binding)
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel login)
        {
            var user = _context.Patients
                .FirstOrDefault(p => p.Email == login.Email && p.Password == login.Password);

            if (user == null)
                return Unauthorized("Invalid credentials");

            return Ok(new { message = "Login successful", user.Id });
        }

        // ✅ (Optional) Get all patients - For testing only
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_context.Patients.ToList());
        }
    }
}
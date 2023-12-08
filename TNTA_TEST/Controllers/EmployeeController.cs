using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TNTA_TEST.Models;


namespace TNTA_TEST.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var employees = _context.Employees.Include(e => e.Department).ToList();
            return View(employees);
        }
        public IActionResult AddEmployee()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Edit(int id)
        {
            var employee = await _context.Employees.FindAsync(id);

            if (employee == null)
            {
                return NotFound(); 
            }

            return View(employee);
        }

        
        [HttpPost]
        public async Task<IActionResult> Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Update(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index"); 
            }

            return View(employee);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var employee = await _context.Employees.FindAsync(id);

            if (employee == null)
            {
                return NotFound(); 
            }

            return View(employee);
        }

       
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _context.Employees.FindAsync(id);

            if (employee == null)
            {
                return NotFound(); 
            }

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index"); 
        }
    }
}

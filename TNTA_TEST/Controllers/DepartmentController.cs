using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TNTA_TEST.Models;

public class DepartmentController : Controller
{
    private readonly ApplicationDbContext db;

    public DepartmentController(ApplicationDbContext context)
    {
        db = context;
    }

    public IActionResult Index()
    {
        var departments = db.Departments.ToList();
        return View(departments);
    }
    public IActionResult AddDepartment()
    {
        return View();
    }
    [HttpPost]
    public IActionResult AddDepartment(Department department)
    {
        db.Departments.Add(department);
        db.SaveChanges();
        return RedirectToAction(nameof(Index));
    }
    public async Task<IActionResult> EditDepartment(int id)
    {
        var department = await db.Departments.FindAsync(id);

        if (department == null)
        {
            return NotFound(); 
        }

        return View(department);
    }

    
    [HttpPost]
    public async Task<IActionResult> EditDepartment(Department department)
    {
        if (ModelState.IsValid)
        {
            db.Update(department);
            await db.SaveChangesAsync();
            return RedirectToAction("Index"); 
        }

        return View(department);
    }
    public async Task<IActionResult> Delete(int id)
    {
        var department = await db.Departments.FindAsync(id);

        if (department == null)
        {
            return NotFound(); 
        }

        return View(department);
    }

    
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var department = await db.Departments.FindAsync(id);

        if (department == null)
        {
            return NotFound(); 
        }

        db.Departments.Remove(department);
        await db.SaveChangesAsync();
        return RedirectToAction("Index"); 
    }
}
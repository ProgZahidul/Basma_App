using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

public class ContactController : Controller
{
    private readonly ApplicationDbContext _context;

    public ContactController(ApplicationDbContext context)
    {
        _context = context;
    }
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ContactViewModel model)
    {
        if (ModelState.IsValid)
        {
            _context.Contacts.Add(model);
            await _context.SaveChangesAsync();

            ViewBag.SuccessMessage = "Your message has been submitted successfully.";
            ModelState.Clear(); // Clear the form
            return View(); // Return the same view
        }

        return View(model);
    }

}

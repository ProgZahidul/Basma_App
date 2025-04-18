using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

[Authorize(AuthenticationSchemes = "CustomScheme")]
public class ContactController : Controller
{
    private readonly ApplicationDbContext _context;

    public ContactController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var contacts = _context.Contacts.ToList();
        return View(contacts);
    }

    [HttpGet]
    public IActionResult Details(int id)
    {
        var contact = _context.Contacts.FirstOrDefault(c => c.Id == id);
        if (contact == null)
        {
            return NotFound();
        }

        return View(contact);
    }

    [HttpGet]
    [AllowAnonymous] // Allow unauthenticated access
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [AllowAnonymous] // Allow unauthenticated access
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ContactViewModel model)
    {
        if (ModelState.IsValid)
        {
            _context.Contacts.Add(model);
            await _context.SaveChangesAsync();

            ViewBag.SuccessMessage = "Your message has been submitted successfully.";
            ModelState.Clear();
            return View(); // Return the same view to show the form again
        }

        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        var contact = await _context.Contacts.FindAsync(id);
        if (contact == null)
        {
            return NotFound();
        }

        _context.Contacts.Remove(contact);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }
}

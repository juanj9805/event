using Microsoft.AspNetCore.Mvc;

namespace events.Controllers.Event;

public class EventController : Controller
{
    public IActionResult Event()
    {
        return View();
    }
    
    public IActionResult Show()
    {
        return View();
    }
}
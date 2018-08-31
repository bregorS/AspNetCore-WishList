namespace WishList.Controllers
{
    using System.Linq;

    using Microsoft.AspNetCore.Mvc;

    using WishList.Data;

    public class ItemController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ItemController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var model = _context.Items.ToList();

            return View("Index", model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public IActionResult Create(Models.Item item)
        {
            _context.Items.Add(item);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var item = _context.Items.FirstOrDefault(i => i.Id == id);

            _context.Items.Remove(item);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}

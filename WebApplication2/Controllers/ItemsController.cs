using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Data;
using WebApplication2.Models;
using WebApplication2.ViewModels;
using static NuGet.Packaging.PackagingConstants;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace WebApplication2.Controllers
{
    
    public class ItemsController : Controller
    {
        //  for database
        private readonly AppDbContext _db;
        //  for images
        private readonly IWebHostEnvironment _host;

        //  constructor
        public ItemsController(AppDbContext db, IWebHostEnvironment host)
        {
            _db = db;
            _host = host;
        }

        public IActionResult Index(int? filterCriteria)
        {
            IEnumerable<Item> itemsList = _db.Items.ToList();

            if (filterCriteria.HasValue)
            {
                if (filterCriteria == 1)
                {
                    itemsList = _db.Items.ToList().Where(w => w.Warehouse.Equals(1));
                }
                else if (filterCriteria == 2)
                {
                    itemsList = _db.Items.ToList().Where(w => w.Warehouse.Equals(2));
                }
            }

            return View(itemsList);
        }

        //public IActionResult Index1()
        //{
        //    IEnumerable<Item> itemsList1 = _db.Items.ToList().Where(w => w.Warehouse.Equals(1));
        //    return View(itemsList1);
        //}

        //public IActionResult Index2()
        //{
        //    IEnumerable<Item> itemsList2 = _db.Items.ToList().Where(w => w.Warehouse.Equals(2));
        //    return View(itemsList2);
        //}

        [Authorize(Roles = clsRoles.roleAdmin)]
        //  GET
        public IActionResult Create()
        {
            return View();
        }

        //  POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = clsRoles.roleAdmin)]
        public IActionResult Create(Item item)
        {
            if (ModelState.IsValid)
            {

                //  hadling image input ---------------------------------------------------------

                string fileName = string.Empty;

                if (item.ItemImage != null)
                {
                    string myUpload = Path.Combine(_host.WebRootPath, "images");
                    fileName = item.ItemImage.FileName;
                    string fullPath = Path.Combine(myUpload, fileName);
                    item.ItemImage.CopyTo(new FileStream(fullPath, FileMode.Create));
                    item.ItemImageFileName = fileName;
                }

                //  hadling image input ---------------------------------------------------------

                _db.Items.Add(item);
                _db.SaveChanges();
                TempData["success"] = "Item added successfully";
                return RedirectToAction("Index");

            }
            else
            {
                return View(item);
            }
        }
        //  GET
        [Authorize(Roles = clsRoles.roleAdmin)]
        public IActionResult Edit(int? Code)
        {
            if(Code == null || Code== 0)
            {
                return NotFound();
            }

            var item = _db.Items.Find(Code);
            if (item == null) { return NotFound(); }

            return View(item);
        }

        //  POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = clsRoles.roleAdmin)]
        public IActionResult Edit(Item item)
        {
            if (ModelState.IsValid)
            {
                //  hadling image input ---------------------------------------------------------

                string fileName = string.Empty;

                if (item.ItemImage != null)
                {
                    string myUpload = Path.Combine(_host.WebRootPath, "images");
                    fileName = item.ItemImage.FileName;
                    string fullPath = Path.Combine(myUpload, fileName);
                    item.ItemImage.CopyTo(new FileStream(fullPath, FileMode.Create));
                    item.ItemImageFileName = fileName;
                }

                //  hadling image input ---------------------------------------------------------

                //  updates instead of adds to database
                //  matches passed id to id in database to access item instance
                _db.Items.Update(item);
                TempData["success"] = "Item edited successfully";
                _db.SaveChanges();
                return RedirectToAction("Index");

            }
            else
            {
                return View(item);
            }
        }
        //  GET
        [Authorize(Roles = clsRoles.roleAdmin)]
        public IActionResult Delete(int? Code)
        {
            if(Code == null || Code== 0)
            {
                return NotFound();
            }

            var item = _db.Items.Find(Code);
            if (item == null) { return NotFound(); }

            return View(item);
        }

        //  POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = clsRoles.roleAdmin)]
        public IActionResult Delete(Item item)
        {
            _db.Items.Remove(item);
            TempData["success"] = "Item deleted successfully";
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Unicode;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using UserApp3_1.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserApp3_1.Controllers
{
    public class CategoryController : Controller
    {


        private readonly WorkerDbContext _db;


        public CategoryController (WorkerDbContext db)
        {


            _db = db;

        }

        // GET: /<controller>/
        public IActionResult CategoryIndex()
        {
            IEnumerable<Category> objCategoryList = _db.Categories.ToList();

            return View(objCategoryList);
        }

        public IActionResult Create()
        {
           
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create( Category obj)
        {
            if( obj.Name==obj.DisplayOrder.ToString())

            {
                ModelState.AddModelError("Custom Error", "DisplayOrder cannot match width the Name");

            }



            if (ModelState.IsValid)
            {

                _db.Categories.Add(obj);

                _db.SaveChanges();
                TempData["success"] = "Category Created Succesfully";
                return RedirectToAction("CategoryIndex");
            }

            return View(obj);

           
        }


        public IActionResult Edit(int? id)
        {
            if (id ==null|| id==0)
            {
                return NotFound();
            }

            var CategoryFromDb = _db.Categories.Find(id);
           // var CategoryFromDbFirst = _db.Categories.FirstOrDefault(u=>u.Id==id);
           // var CategoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);
            


            if(CategoryFromDb==null)
            {
                return NotFound();
            }



            return View(CategoryFromDb);
        } 
         

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())

            {
                ModelState.AddModelError("Custom Error", "DisplayOrder cannot match width the Name");

            }

            


            if (ModelState.IsValid)
            {

                _db.Categories.Update(obj);

                _db.SaveChanges();

                TempData["success"] = "Category Updated Succesfully";
                return RedirectToAction("CategoryIndex");
            }

            return View(obj);


        }


        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var CategoryFromDb = _db.Categories.Find(id);
            // var CategoryFromDbFirst = _db.Categories.FirstOrDefault(u=>u.Id==id);
            // var CategoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);



            if (CategoryFromDb == null)
            {
                return NotFound();
            }



            return View(CategoryFromDb);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Category obj)
        {
          

           
                _db.Categories.Remove(obj);

                _db.SaveChanges();


           TempData["success"] = "Category Deleted  Succesfully";
            return RedirectToAction("CategoryIndex");
           

        }





    }
}


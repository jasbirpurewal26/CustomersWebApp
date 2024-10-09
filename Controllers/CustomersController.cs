using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CustomersWebApp.Data;
using CustomersWebApp.Models;
using CustomersApp.Data;

namespace CustomersWebApp.Controllers
{
    public class CustomersController : Controller
    {

            private readonly CustomersData CustomersData;

            public CustomersController()
            {
                CustomersData = new CustomersData();
            }


            public IActionResult Index()
            {
                ViewBag.Customers = CustomersData.GetCustomers();
                return View();
            }

            // GET: Customers/Details/5
            public IActionResult Details(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                Customer? Customer = CustomersData.Get(id);

                if (Customer == null)
                {
                    return NotFound();
                }
                return View(Customer);
            }

            // GET: Customers/Create
            public IActionResult Create()
            {
                return View();
            }

            // GET: Customers/Edit/5
            public IActionResult Edit(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                Customer? Customer = CustomersData.Get(id);

                if (Customer == null)
                {
                    return NotFound();
                }
                return View(Customer);
            }

            // POST: Customers/Edit/5

            [HttpPost]
            public IActionResult Save(int id, [Bind("Id,Name,Address,City,PostCode,Country,Phone")] Customer Customer)
            {
                if (id != Customer.Id)
                {
                    return NotFound();
                }

                CustomersData.Update(Customer);
                return RedirectToAction(nameof(Index));
            }


            // POST: Customers/Create
            [HttpPost]
            public IActionResult Create([Bind("Id,Name,Address,City,PostCode,Country,Phone")] Customer Customer)
            {

                CustomersData.Create(Customer);

                return RedirectToAction(nameof(Index));
            }



            // GET: Customers/Delete/5
            public IActionResult Delete(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                Customer? Customer = CustomersData.Get(id);

                if (Customer == null)
                {
                    return NotFound();
                }
                return View(Customer);
            }

            // POST: Customers/Delete/5
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public IActionResult DeleteConfirmed(int id)
            {
                CustomersData.Remove(id);

                return RedirectToAction(nameof(Index));
            }

        }
    }

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

            /*       private readonly CustomersWebAppContext _context;

                   public CustomersController(CustomersWebAppContext context)
                   {
                       _context = context;
                   }

                   // GET: Customers
                   public async Task<IActionResult> Index()
                   {
                       return View(await _context.Customer.ToListAsync());
                   }

                   // GET: Customers/Details/5
                   public async Task<IActionResult> Details(int? id)
                   {
                       if (id == null)
                       {
                           return NotFound();
                       }

                       var customer = await _context.Customer
                           .FirstOrDefaultAsync(m => m.Id == id);
                       if (customer == null)
                       {
                           return NotFound();
                       }

                       return View(customer);
                   }

                   // GET: Customers/Create
                   public IActionResult Create()
                   {
                       return View();
                   }

                   // POST: Customers/Create
                   // To protect from overposting attacks, enable the specific properties you want to bind to.
                   // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
                   [HttpPost]
                   [ValidateAntiForgeryToken]
                   public async Task<IActionResult> Create([Bind("Id,Name,Address,City,PostCode,Country,Phone")] Customer customer)
                   {
                       if (ModelState.IsValid)
                       {
                           _context.Add(customer);
                           await _context.SaveChangesAsync();
                           return RedirectToAction(nameof(Index));
                       }
                       return View(customer);
                   }

                   // GET: Customers/Edit/5
                   public async Task<IActionResult> Edit(int? id)
                   {
                       if (id == null)
                       {
                           return NotFound();
                       }

                       var customer = await _context.Customer.FindAsync(id);
                       if (customer == null)
                       {
                           return NotFound();
                       }
                       return View(customer);
                   }

                   // POST: Customers/Edit/5
                   // To protect from overposting attacks, enable the specific properties you want to bind to.
                   // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
                   [HttpPost]
                   [ValidateAntiForgeryToken]
                   public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Address,City,PostCode,Country,Phone")] Customer customer)
                   {
                       if (id != customer.Id)
                       {
                           return NotFound();
                       }

                       if (ModelState.IsValid)
                       {
                           try
                           {
                               _context.Update(customer);
                               await _context.SaveChangesAsync();
                           }
                           catch (DbUpdateConcurrencyException)
                           {
                               if (!CustomerExists(customer.Id))
                               {
                                   return NotFound();
                               }
                               else
                               {
                                   throw;
                               }
                           }
                           return RedirectToAction(nameof(Index));
                       }
                       return View(customer);
                   }

                   // GET: Customers/Delete/5
                   public async Task<IActionResult> Delete(int? id)
                   {
                       if (id == null)
                       {
                           return NotFound();
                       }

                       var customer = await _context.Customer
                           .FirstOrDefaultAsync(m => m.Id == id);
                       if (customer == null)
                       {
                           return NotFound();
                       }

                       return View(customer);
                   }

                   // POST: Customers/Delete/5
                   [HttpPost, ActionName("Delete")]
                   [ValidateAntiForgeryToken]
                   public async Task<IActionResult> DeleteConfirmed(int id)
                   {
                       var customer = await _context.Customer.FindAsync(id);
                       if (customer != null)
                       {
                           _context.Customer.Remove(customer);
                       }

                       await _context.SaveChangesAsync();
                       return RedirectToAction(nameof(Index));
                   }

                   private bool CustomerExists(int id)
                   {
                       return _context.Customer.Any(e => e.Id == id);
                   }*/
        }
    }

using CustomerCRUD.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CustomerCRUD.Controllers
{
    public class CustomerController : Controller
    {
        CustomerDataAccessLayer objCustomerDAL = new CustomerDataAccessLayer();
        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Customer> customers= new List<Customer>();
            customers = objCustomerDAL.GetAllCustomers().ToList();
            return View(customers);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] Customer objCustomer)
        {
            if (ModelState.IsValid)
            {
                objCustomerDAL.AddCustomer(objCustomer);
                return RedirectToAction("Index");
            }
            return View(objCustomer);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Customer customer = objCustomerDAL.GetCustomerData(id);

            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind]Customer objcustomer)
        {
            if (id != objcustomer.ID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                objCustomerDAL.UpdateCustomer(objcustomer);
                return RedirectToAction("Index");
            }
            return View(objCustomerDAL);
        }
        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Customer objcustomer = objCustomerDAL.GetCustomerData(id);

            if (objcustomer == null)
            {
                return NotFound();
            }
            return View(objcustomer);
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Customer objcustomer = objCustomerDAL.GetCustomerData(id);

            if (objcustomer == null)
            {
                return NotFound();
            }
            return View(objcustomer);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id)
        {
            objCustomerDAL.DeleteCustomer(id);
            return RedirectToAction("Index");
        }
    }
}

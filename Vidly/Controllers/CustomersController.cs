﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        // GET: Customers
        public ActionResult Index()
        {
            //var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            //return View(customers);
            return View();
        }

       
        public ActionResult Details(int id)
        {
            var customers = _context.Customers.Include(c=> c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customers == null)
            {
                return HttpNotFound();
            }

            return View(customers);
        }

        public ActionResult New()
        {
             var memberhsip = _context.MembershipTypes.ToList();
              var viewModel = new CustomerFormViewModel
              {
                  Customer= new Customer(),
                  MembershipType = memberhsip
              };
              return View("CustomerForm",viewModel);
           
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
          {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer= customer,
                    MembershipType= _context.MembershipTypes.ToList()
                };
                return View("CustomerForm", viewModel);
            }

            if (customer.Id == 0)
                _context.Customers.Add(customer);
            else
            {
                var customerInDB = _context.Customers.Single(c => c.Id == customer.Id);
                customerInDB.Name = customer.Name;
                customerInDB.Birthdate = customer.Birthdate;
                customerInDB.isSubscribedToNewsLetter = customer.isSubscribedToNewsLetter;
                customerInDB.MembershipTypeID = customer.MembershipTypeID;
            }
              _context.SaveChanges();
              return RedirectToAction("Index", "Customers");
          }


        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipType = _context.MembershipTypes.ToList()

            };
            return View("CustomerForm", viewModel);
        }
    }
}
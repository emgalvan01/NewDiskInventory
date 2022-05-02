using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DiskInventory.Models;

namespace DiskInventory.Controllers
{
    public class DiskHasBorrowerController : Controller
    {
        private disk_inventoryegContext context { get; set; }
        public DiskHasBorrowerController(disk_inventoryegContext ctx)
        {
            context = ctx;
        }
        public IActionResult Index()
        {
            var diskhasborrowers = context.DiskHasBorrowers.Include(d => d.Disk).OrderBy(d => d.Disk.DiskName).Include(b => b.Borrower).ToList();
            return View(diskhasborrowers);
        }
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            DiskHasBorrowerViewModel checkOut = new DiskHasBorrowerViewModel();
            checkOut.CurrentVM.BorrowedDate = DateTime.Now;
            checkOut.Disks = context.Disks.OrderBy(d => d.DiskName).ToList();
            checkOut.Borrowers = context.Borrowers.OrderBy(b => b.Lname).ToList();
            return View("Edit", checkOut);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            var diskhasborrower = context.DiskHasBorrowers.Find(id);
            DiskHasBorrowerViewModel checkOut = new DiskHasBorrowerViewModel();
            checkOut.Disks = context.Disks.OrderBy(d => d.DiskName).ToList();
            checkOut.Borrowers = context.Borrowers.OrderBy(b => b.Lname).ToList();
            checkOut.CurrentVM.DiskHasBorrowerId = diskhasborrower.DiskHasBorrowerId;
            checkOut.CurrentVM.BorrowerId = diskhasborrower.BorrowerId;
            checkOut.CurrentVM.DiskId = diskhasborrower.DiskId;
            checkOut.CurrentVM.BorrowedDate = diskhasborrower.BorrowedDate;
            checkOut.CurrentVM.ReturnedDate = diskhasborrower.ReturnedDate;
            return View(checkOut);
        }

        [HttpPost]
        public IActionResult Edit(DiskHasBorrowerViewModel diskHasBorrowerViewModel)
        {
            DiskHasBorrower checkOut = new DiskHasBorrower();
            if (ModelState.IsValid)
            {
                checkOut.DiskHasBorrowerId = diskHasBorrowerViewModel.CurrentVM.DiskHasBorrowerId;
                checkOut.BorrowerId = diskHasBorrowerViewModel.CurrentVM.BorrowerId;
                checkOut.DiskId = diskHasBorrowerViewModel.CurrentVM.DiskId;
                checkOut.BorrowedDate = diskHasBorrowerViewModel.CurrentVM.BorrowedDate;
                checkOut.ReturnedDate = diskHasBorrowerViewModel.CurrentVM.ReturnedDate;
                if (checkOut.DiskHasBorrowerId == 0)
                {
                    context.DiskHasBorrowers.Add(checkOut);
                    TempData["message"]= "Checkout added.";
                }
                else
                {
                    context.DiskHasBorrowers.Update(checkOut);
                    TempData["message"] = "Checkout updated.";
                }
                context.SaveChanges();
                return RedirectToAction("Index", "DiskHasBorrower");
            }
            ViewBag.Action = (diskHasBorrowerViewModel.CurrentVM.DiskHasBorrowerId == 0) ? "Add" : "Edit";
            diskHasBorrowerViewModel.Disks = context.Disks.OrderBy(d => d.DiskName).ToList();
            diskHasBorrowerViewModel.Borrowers = context.Borrowers.OrderBy(b => b.Lname).ToList();
            return View(diskHasBorrowerViewModel);
        }
    }
}
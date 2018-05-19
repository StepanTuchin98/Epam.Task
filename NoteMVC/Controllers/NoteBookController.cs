using Entites;
using NoteBook.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace NoteMVC.Controllers
{
    public class NoteBookController : Controller
    {
        // GET: NoteBook
        private readonly NoteBookLogic noteBookLogic;

        public NoteBookController(NoteBookLogic noteBookLogic)
        {
            this.noteBookLogic = noteBookLogic;
        }

        public ActionResult ListNote()
        {
            var notes = noteBookLogic.GetAll();
            return View(notes);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "FirstName, LastName, YearOfBirth, PhoneNumber")] Note note)
        {
            if (ModelState.IsValid)
            {
                noteBookLogic.Add(note);
                return RedirectToAction("ListNote");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Delete([Bind(Include = "Id")] Note student)
        {
            noteBookLogic.Remove((int)student.Id);
            return RedirectToAction("ListNote");
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Note nt = noteBookLogic.GetById(id);
            if (nt == null)
            {
                return HttpNotFound();
            }
            return View(nt);
        }

        public ActionResult Edit(int id)
        {
            Note nt = noteBookLogic.GetById(id);
            return View(nt);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id ,FirstName, LastName, YearOfBirth, PhoneNumber")]Note nt)
        {
            if (ModelState.IsValid)
            {
                noteBookLogic.Edit(nt);
                return RedirectToAction("ListNote");
            }
            return View(nt);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Note nt = noteBookLogic.GetById(id);
            if (nt == null)
            {
                return HttpNotFound();
            }
            return View(nt);
        }

        public ActionResult SortedByLastName()
        {
            var notes = noteBookLogic.SortByLastName();
            return View(notes);
        }

        public ActionResult SortedByYear()
        {
            var notes = noteBookLogic.SortByYear();
            return View(notes);
        }

        [HttpGet]
        public ActionResult SearchByLastName()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SearchByLastName(string LastName)
        {
            if (ModelState.IsValid)
            {
                var tmp = noteBookLogic.SearchByLastName(LastName);
                return View(tmp);
            }
            
            return View();
        }

        [HttpGet]
        public ActionResult SearchByName()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SearchByName(string Name)
        {
            if (ModelState.IsValid)
            {
                var tmp = noteBookLogic.SearchByName(Name);
                return View(tmp);
            }

            return View();
        }
        [HttpGet]
        public ActionResult SearchByNumber()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SearchByNumber(string Number)
        {
            if (ModelState.IsValid)
            {
                var tmp = noteBookLogic.SearchByPhoneNum(Number);
                return View(tmp);
            }

            return View();
        }
    }
}
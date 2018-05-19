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
        
        private readonly NoteBookLogic noteBookLogic;

        public NoteBookController(NoteBookLogic noteBookLogic)
        {
            this.noteBookLogic = noteBookLogic;
        }
        
        public ActionResult ListNote()
        {
            // full list of notes
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
        {//getting parameters from the post query
            if (ModelState.IsValid)// check, if the note is valid
            {
                noteBookLogic.Add(note); // add note to the db 
                return RedirectToAction("ListNote"); // go to the page "ListNote" 
            }
            // back to form, if not correct
            return View();
        }

        [HttpPost]
        public ActionResult Delete([Bind(Include = "Id")] Note student)
        {
            // getting id from post query
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
            // edit the note
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
        {// get parameter and search note with such lastname
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
        {// get parameter and search note with such name
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
        {// get parameter and search note with such number
            if (ModelState.IsValid)
            {
                var tmp = noteBookLogic.SearchByPhoneNum(Number);
                return View(tmp);
            }

            return View();
        }
    }
}
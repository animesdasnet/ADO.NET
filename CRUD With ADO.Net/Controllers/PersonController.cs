using CRUD_With_ADO.Net.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;


namespace CRUD_With_ADO.Net.Controllers
{
    public class PersonController : Controller
    {
        // GET: Employee
        private Person_CRUD_ db = new Person_CRUD_();

        public ActionResult Index()
        {
            List<Person> personList = new List<Person>();
            DataTable dtResult = db.GetAllPerson();
            for (int i = 0; i < dtResult.Rows.Count; i++)
            {
                Person person = new Person(); //model
                person.BusinessEntityID = Convert.ToInt32(dtResult.Rows[i]["BusinessEntityID"]);
                person.FirstName = dtResult.Rows[i]["FirstName"].ToString();
                person.MiddleName = dtResult.Rows[i]["MiddleName"].ToString();
                person.LastName = dtResult.Rows[i]["LastName"].ToString();
                person.EmailPromotion = dtResult.Rows[i]["EmailPromotion"].ToString();
                personList.Add(person);
            }
            return View(personList);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create([Bind(Include = " BusinessEntityID,PersonType,FirstName,MiddleName,LastName,EmailPromotion")] Person person)
        {

            if (ModelState.IsValid)
            {
                int status = db.CreatePerson(person.BusinessEntityID,person.PersonType,person.FirstName, person.MiddleName, person.LastName, person.EmailPromotion);
           
                ViewBag.StatusMessage = "Person created successfully";
            }
            return RedirectToAction("Index");

        }
        // GET: Person/Details/5
        public ActionResult Details(int BusinessEntityID)
        {

            DataTable dt = db.GetPersonById(BusinessEntityID);
            Person person = new Person();
            person.BusinessEntityID = Convert.ToInt32(dt.Rows[0]["BusinessEntityID"]);
            person.FirstName = Convert.ToString(dt.Rows[0]["FirstName"]);
            person.MiddleName = Convert.ToString(dt.Rows[0]["MiddleName"]);
            person.LastName = Convert.ToString(dt.Rows[0]["LastName"]);
            person.EmailPromotion = Convert.ToString(dt.Rows[0]["EmailPromotion"]);

            //if (BusinessEntityID ==  null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}

            //if (person.BusinessEntityID == null)
            //{
            //    return HttpNotFound();
            //}
            return View(person);
        }


        [HttpGet]
        public ActionResult Edit(int BusinessEntityID)
        {
            DataTable dt = db.GetPersonById(BusinessEntityID);
            Person person = new Person();
            person.BusinessEntityID = Convert.ToInt32(dt.Rows[0]["BusinessEntityID"]);
            person.FirstName = Convert.ToString(dt.Rows[0]["FirstName"]);
            person.MiddleName = Convert.ToString(dt.Rows[0]["MiddleName"]);
            person.LastName = Convert.ToString(dt.Rows[0]["LastName"]);
            person.EmailPromotion = Convert.ToString(dt.Rows[0]["EmailPromotion"]);

            if (BusinessEntityID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (person.BusinessEntityID == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PersonType,BusinessEntityID,FirstName,MiddleName,LastName,EmailPromotion")] Person person)
        {

            if (ModelState.IsValid)
            {
                int status = db.UpdatePerson(person.PersonType,person.BusinessEntityID, person.FirstName, person.MiddleName, person.LastName, person.EmailPromotion);

                ViewBag.Status = "Updated Employee details successfully";

            }
            return RedirectToAction("Index");

        }

        public ActionResult Delete(int BusinessEntityID)
        {
            db.Delete(BusinessEntityID);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(int BusinessEntityID, FormCollection collection)
        {
            try
            {
             
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

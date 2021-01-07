using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EvansApp.Models;

namespace EvansApp.Controllers
{
    public class HZ_CustomerController : Controller
    {
        private EvansDBEntities db = new EvansDBEntities();

        // GET: HZ_Customer
        public ActionResult Index()
        {
            return View(db.HZ_Customer.ToList());
        }

        // GET: HZ_Customer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HZ_Customer hZ_Customer = db.HZ_Customer.Find(id);
            if (hZ_Customer == null)
            {
                return HttpNotFound();
            }
            return View(hZ_Customer);
        }

        // GET: HZ_Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HZ_Customer/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BossProccessDate,CustomerKey,CustomerType,CustomerName,ServiceMember,DriverID,DriverIDIssueDate,DriverIDExpirationDate,DriverIDIssueState,PassPortID,PassPortIssueDate,PassPortExpirationDate,PassPortIssueCountry,TaxpayerIDMasked,TaxpayerIDFull,ForeignTaxID,Address1StreetNumber,Address1StreetName,City,State,Zipcode,Zipcode_plus_4,ForeignCountryCode,ForeignPostalCode,CommentLine,CreditBureauReportCode,Prefix,ProfessionalDesignation,FirstName,MiddleName,LastName,Suffix,NonPersonalNameLine1,NonPersonalNameLine2,RegOCode,Status,InactiveDate,BranchCode,Branch,CommSpecUseNbr,IVRAccessFlag,InternetAccessFlag,InternetAddress,DateOfBirth,LastCustomerContactDate,DateCustomerAdded,LostCustomerDate,HomePhone,CellPhone,BusinessPhone,Privacy_Sharing_Option,LoadedDate")] HZ_Customer hZ_Customer)
        {
            if (ModelState.IsValid)
            {
                db.HZ_Customer.Add(hZ_Customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hZ_Customer);
        }

        // GET: HZ_Customer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HZ_Customer hZ_Customer = db.HZ_Customer.Find(id);
            if (hZ_Customer == null)
            {
                return HttpNotFound();
            }
            return View(hZ_Customer);
        }

        // POST: HZ_Customer/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BossProccessDate,CustomerKey,CustomerType,CustomerName,ServiceMember,DriverID,DriverIDIssueDate,DriverIDExpirationDate,DriverIDIssueState,PassPortID,PassPortIssueDate,PassPortExpirationDate,PassPortIssueCountry,TaxpayerIDMasked,TaxpayerIDFull,ForeignTaxID,Address1StreetNumber,Address1StreetName,City,State,Zipcode,Zipcode_plus_4,ForeignCountryCode,ForeignPostalCode,CommentLine,CreditBureauReportCode,Prefix,ProfessionalDesignation,FirstName,MiddleName,LastName,Suffix,NonPersonalNameLine1,NonPersonalNameLine2,RegOCode,Status,InactiveDate,BranchCode,Branch,CommSpecUseNbr,IVRAccessFlag,InternetAccessFlag,InternetAddress,DateOfBirth,LastCustomerContactDate,DateCustomerAdded,LostCustomerDate,HomePhone,CellPhone,BusinessPhone,Privacy_Sharing_Option,LoadedDate")] HZ_Customer hZ_Customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hZ_Customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hZ_Customer);
        }

        // GET: HZ_Customer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HZ_Customer hZ_Customer = db.HZ_Customer.Find(id);
            if (hZ_Customer == null)
            {
                return HttpNotFound();
            }
            return View(hZ_Customer);
        }

        // POST: HZ_Customer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HZ_Customer hZ_Customer = db.HZ_Customer.Find(id);
            db.HZ_Customer.Remove(hZ_Customer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Search()
        {
            return View("Search");
        }

        [HttpPost, ActionName("Search")]
        [ValidateAntiForgeryToken]
        public ActionResult Search(string CustomerName)
        {
           
            //ViewBag.Customers = hZ_Customer;
            //Console.WriteLine(hZ_Customer);
          //  return RedirectToAction("Detail", hZ_Customer);

            if (CustomerName == null)
            {
                ViewBag.Notfound = "Kindly Write the Name of the Customer before searching";
                return View("Search");
            }
            
           
            IEnumerable < HZ_Customer > customers= db.HZ_Customer.Where(x => x.FirstName.ToLower().Contains(CustomerName.ToLower()) || x.LastName.ToLower().Contains(CustomerName.ToLower())).ToList();
            if(customers.Count()==0) ViewBag.Notfound = "Customer not found !!!";
            return View("Search", customers);
        }
        // GET: HZ_Customer/Details/5
        public ActionResult ProductsServicesOfCustomer(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HZ_Customer hZ_Customer = db.HZ_Customer.Find(id);
            if (hZ_Customer == null)
            {
                return HttpNotFound();
            }
             IEnumerable< HZ_Cards> cards = db.HZ_Cards.Where(x => x.PrimaryCustomerKey == id).ToList();
            ViewData["Cards"]= cards ;

            IEnumerable<HZ_CD_IRA> ira = db.HZ_CD_IRA.Where(x => x.PrimaryCustomerKey == id).ToList();
            ViewData["IRA"] = ira;//db.HZ_CD_IRA.Where(x => x.PrimaryCustomerKey == id).ToList();

            IEnumerable<HZ_DD_SV> sv= db.HZ_DD_SV.Where(x => x.PrimaryCustomerKey == id).ToList();
            ViewData["SV"] = sv;

            IEnumerable<HZ_LN> ln = db.HZ_LN.Where(x => x.PrimaryCustomerKey == id).ToList();
            ViewData["LN"] = ln;// db.HZ_LN.Where(x => x.PrimaryCustomerKey == id).ToList();

            IEnumerable<HZ_ML> ml = db.HZ_ML.Where(x => x.PrimaryCustomerKey == id).ToList();
            ViewData["ML"] = ml;// db.HZ_ML.Where(x => x.PrimaryCustomerKey == id).ToList();

            IEnumerable<HZ_SafeDepBox> depositBox = db.HZ_SafeDepBox.Where(x => x.PrimaryCustomerKey == id).ToList();
            ViewData["depositBox"] = depositBox;// db.HZ_SafeDepBox.Where(x => x.PrimaryCustomerKey == id).ToList();

            return View(hZ_Customer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TransportMSSajib.Data;
using TransportMSSajib.Models;

namespace TransportMSSajib.Controllers
{
    public class AdminPanelController : Controller
    {
        public readonly dataContext db;
        public AdminPanelController(dataContext _db)
        {
            db = _db;
        }
        public IActionResult Adminpanel()
        {
            string adminname = Request.Cookies["Key"];
            var model = new A_W_M_C
            {

                Tf = db.Notifications,
                Tishow = db.Transport,
                fishow = db.Faculty_Info,
                Airetrive = db.Admin_Info.Where(a=>a.aUName==adminname)
            };

        ViewBag.Name = HttpContext.Request.Cookies["key"];
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Adminpanel(A_W_M_C ob)
        {
            if (ob.Tiretrive != null)
            {
                var tinfo = db.Transport.Where(a => a.TransportNumber == ob.Tiretrive.TransportNumber).FirstOrDefault();
                if (tinfo == null)
                {
                    ob.Tiretrive.Status = "Available";
                    ob.Tiretrive.hour = "00";
                    db.Transport.Add(ob.Tiretrive);
                    db.SaveChanges();
                    ViewBag.addTransportStatus = "Success";
                }
                else
                {
                    ViewBag.addTransportStatus = "Error";
                }
            }
            else if (ob.fi != null)
            {
                var finfo = db.Faculty_Info.Where(a => a.id == ob.fi.id).FirstOrDefault();
                if (finfo == null)
                {
                    ob.fi.fCPassword = BCrypt.Net.BCrypt.HashPassword(ob.fi.fCPassword);
                    ob.fi.fNPassword = BCrypt.Net.BCrypt.HashPassword(ob.fi.fNPassword);
                    db.Faculty_Info.Add(ob.fi);
                    db.SaveChanges();
                    ViewBag.addFacultyStatus = "Success";
                }
                else
                {
                    ViewBag.addFacultyStatus = "Error";
                }
            }
            else if (ob.Aitakeinput != null)
            {
                ob.Aitakeinput.aCPassword = ob.Aitakeinput.aCPassword;
                ob.Aitakeinput.aNPassword = ob.Aitakeinput.aNPassword;
                db.Admin_Info.Update(ob.Aitakeinput);
                db.SaveChanges();
                Response.Cookies.Append("key", ob.Aitakeinput.aUName) ;
            }
            //default values--------------------
            string adminname = Request.Cookies["Key"];
            var model = new A_W_M_C
            {

                Tf = db.Notifications,
                Tishow=db.Transport,
                fishow=db.Faculty_Info,
                Airetrive = db.Admin_Info.Where(a => a.aUName == adminname)
            };
            
            ViewBag.Name = HttpContext.Request.Cookies["key"];
            
            //default values--------------------
            return View(model);
        }
        [HttpGet]
        public IActionResult Reject(int id)
        {
            var notiinfo = db.Notifications.Where(a =>a.id == id).FirstOrDefault();
            
                NotificationInfo ninfo = new NotificationInfo();
                ninfo.NStatus = "Rejected";
                ninfo.NFor = notiinfo.NFor;
                ninfo.NComingDate = notiinfo.NComingDate;
                ninfo.NComingTime = notiinfo.NComingTime;
                ninfo.NDetails = notiinfo.NDetails;
                ninfo.NFor = notiinfo.NFor;
                ninfo.Nfrom = notiinfo.Nfrom;
                ninfo.NHId = notiinfo.NHId;
                ninfo.NTo = notiinfo.NTo;
                db.Notifications.Remove(notiinfo);
                db.SaveChanges();
                db.Notifications.Add(ninfo);
                db.SaveChanges();
                
            if (notiinfo.NFor == "Registration")
            {  
                var finfo = db.Registration_faculty.Where(a => a.id == ninfo.NHId).FirstOrDefault();
                db.Registration_faculty.Remove(finfo);
                db.SaveChanges();
            }
            return RedirectToAction("Adminpanel");

        }
        [HttpGet]
        public IActionResult Accept(int id)
        {
            var notiinfo = db.Notifications.Where(a => a.id == id).FirstOrDefault();
            
            NotificationInfo ninfo = new NotificationInfo();
            ninfo.NStatus = "Accepted";
            ninfo.NFor = notiinfo.NFor;
            ninfo.NComingDate = notiinfo.NComingDate;
            ninfo.NComingTime = notiinfo.NComingTime;
            ninfo.NDetails = notiinfo.NDetails;
            ninfo.NFor = notiinfo.NFor;
            ninfo.Nfrom = notiinfo.Nfrom;
            ninfo.NHId = notiinfo.NHId;
            ninfo.NTo = notiinfo.NTo;
            if (notiinfo.NFor == "Registration")
            {
                var finfo = db.Registration_faculty.Where(a => a.id == ninfo.NHId).FirstOrDefault();


                FacultyInfo fi = new FacultyInfo();
                fi.fContactNumber = finfo.fContactNumber;
                fi.fCPassword = finfo.fCPassword;
                fi.fDesignation = finfo.fDesignation;
                fi.fEmail = finfo.fEmail;
                fi.fFName = finfo.fFName;
                fi.fLName = finfo.fLName;
                fi.fNPassword = finfo.fNPassword;
                fi.fUName = finfo.fUName;
                fi.id = finfo.id;

                db.Faculty_Info.Add(fi);
                db.SaveChanges();
                db.Registration_faculty.Remove(finfo);
                db.SaveChanges();
            }
            else if (notiinfo.NFor == "Transport Request")
            {
                var transporInfo = db.Transport.Where(a => a.TransportNumber == notiinfo.extra1).FirstOrDefault();
                TransportInfo tff = new TransportInfo();
                transporInfo.Status = "Booked by"+notiinfo.Nfrom;
               
                db.Transport.Update(transporInfo);
                db.SaveChanges();

            
            }
            db.Notifications.Remove(notiinfo);
            db.SaveChanges();
            db.Notifications.Add(ninfo);
            db.SaveChanges();
            
            return RedirectToAction("Adminpanel");

        }
        public IActionResult Logout()
        {
            Remove("key");
            return Redirect("/Home/Index");
        }
        public void Remove(string key)
        {
            Response.Cookies.Delete(key);
        }
    }
}
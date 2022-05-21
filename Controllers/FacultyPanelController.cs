using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Korzh.EasyQuery.Linq;
using Microsoft.AspNetCore.Mvc;
using TransportMSSajib.Data;
using TransportMSSajib.Models;

namespace TransportMSSajib.Controllers
{
    public class FacultyPanelController : Controller
    {
        public readonly dataContext db;
        public FacultyPanelController(dataContext _db)
        {
            db = _db;
        }
        public IActionResult Facultypanel()
        {
            string username = Request.Cookies["keys"];
            var facultylogininfo = db.Faculty_Info.Where(a => a.fUName == username).FirstOrDefault();
            var model = new F_W_M_C
            {

                Tf = db.Notifications.Where(a=>a.Nfrom==facultylogininfo.fLName),
                Tishow = db.Transport,
                Airetrive = db.Admin_Info,
                fishow = db.Faculty_Info.Where(a => a.fUName == username)
            };

            ViewBag.Name = HttpContext.Request.Cookies["keys"];
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Facultypanel(F_W_M_C ob)
        {
            string username = Request.Cookies["keys"];
            var facultylogininfo = db.Faculty_Info.Where(a => a.fUName == username).FirstOrDefault();
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
                ob.fi.fCPassword = BCrypt.Net.BCrypt.HashPassword(ob.fi.fCPassword);
                ob.fi.fNPassword = BCrypt.Net.BCrypt.HashPassword(ob.fi.fNPassword);
                db.Faculty_Info.Update(ob.fi);
                db.SaveChanges();
                Response.Cookies.Append("keys", ob.fi.fUName);
            }
            //default values--------------------
            string adminname = Request.Cookies["keys"];
            var model = new F_W_M_C
            {

                Tf = db.Notifications.Where(a => a.Nfrom == facultylogininfo.fLName),
                Tishow = db.Transport,
                Airetrive = db.Admin_Info,
                fishow = db.Faculty_Info.Where(a => a.fUName == username)
            };

            ViewBag.Name = HttpContext.Request.Cookies["keys"];

            //default values--------------------
            return View(model);
        }

        public IActionResult SearchTransport()
        {

            string username = Request.Cookies["keys"];
            var facultylogininfo = db.Faculty_Info.Where(a => a.fUName == username).FirstOrDefault();
            var model = new F_W_M_C
            {

                Tf = db.Notifications.Where(a => a.Nfrom == facultylogininfo.fLName),
                Tishow = db.Transport,
                Tisearch = db.Transport.Where(a=>a.Status=="Available"),
                Airetrive = db.Admin_Info,
                fishow = db.Faculty_Info.Where(a => a.fUName == username)
            };

            ViewBag.Name = HttpContext.Request.Cookies["keys"];
            return View(model);
        }


        [HttpPost]
        public IActionResult SearchTransport(F_W_M_C model)
        {
            if (!string.IsNullOrEmpty(model.txt))
            {
                model.Tisearch = db.Transport.FullTextSearchQuery(model.txt).Where(a => Equals(a.Status, "Available"));
            }
            else
            {
                model.Tisearch = db.Transport;
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult AM(int id)
        {
            var info = db.Notifications.Where(a => a.id == id).FirstOrDefault();
            db.Notifications.Remove(info);
            db.SaveChanges();
            return RedirectToAction("Facultypanel");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult transportRequest(F_W_M_C sb)
        {
            var info = db.Transport.Where(a => a.TransportNumber == sb.txt).FirstOrDefault();
            NotificationInfo ni = new NotificationInfo();
            DateTimeOffset value = DateTimeOffset.Now;
            string usr = Request.Cookies["Keys"];          
            var userInfo = db.Faculty_Info.Where(a =>Equals (a.fUName , usr)).FirstOrDefault();
            ni.NDetails = "Contact Number="+userInfo.fContactNumber +"\n Transport For="+sb.rpurpose +"\n On="+sb.rdate +"\n Transport Number="+info.TransportNumber+"\n Transport Type="+info.TransportType;
            ni.Nfrom = userInfo.fLName;                                                          
            ni.NTo = "Admin";
            ni.NStatus = "Pending";
            ni.NFor = "Transport Request";
            ni.NHId = sb.rdate;
            ni.NComingDate = value.ToString("d");
            ni.NComingTime = value.ToString("t");
            ni.extra1 = info.TransportNumber;
            db.Notifications.Add(ni);
            db.SaveChanges();
            ViewBag.message = "Request Sent Successfully Waiting";
            return RedirectToAction("SearchTransport");
        }


        public IActionResult Logout()
        {
            Response.Cookies.Delete("keys");
            return Redirect("/Home/Index");
        }
        public void Remove(string key)
        {
            Response.Cookies.Delete(key);
        }
    }
}
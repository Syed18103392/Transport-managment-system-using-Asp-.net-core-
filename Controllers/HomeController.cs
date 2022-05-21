using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TransportMSSajib.Data;
using TransportMSSajib.Models;

namespace TransportMSSajib.Controllers
{
    public class HomeController : Controller
    {
        public readonly dataContext db;
        public HomeController(dataContext _db)
        {
            db = _db;
        }
 

        public IActionResult Index()
        {
            string cookieValueFromContext = HttpContext.Request.Cookies["key"];
            string FCVFC = HttpContext.Request.Cookies["keys"];
            if (cookieValueFromContext != null)
            {
                return Redirect("/AdminPanel/Adminpanel");
            }
           else if (FCVFC != null)
            {
               return Redirect("/FacultyPanel/Facultypanel");
            }
            MainModel ob = new MainModel
            {
                loginAleart = false
            };
            return View(ob);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(MainModel mm)
        {
            
          
            if (mm.ai != null && mm.fi ==null)
            {    string msg="ds";
                var adminInfo = db.Admin_Info.Where(a => Equals(a.aUName, mm.ai.aUName)).FirstOrDefault();
                if (adminInfo != null)
                {
                   if (mm.ai.aNPassword== adminInfo.aNPassword)
                   //if(mm.ai.aNPassword==adminInfo.aNPassword)
                    {
                       
                        const string SessionName = "AdminName";
                        msg = "Successfully Login";
                        HttpContext.Session.SetString(SessionName, mm.ai.aUName);
                        Set("key",mm.ai.aUName, 100);
                        return Redirect("/AdminPanel/Adminpanel");

                    }
                    else { msg = "Wrong Password"; mm.loginAleart = true; }
                    
                }
                else
                {
                    msg = "user Name Not Registered";
                    mm.loginAleart = true;
                   
                }         
                ViewBag.message = msg; 
            }
            else if(mm.lf !=null && mm.ai==null)
            {
                string fmsg = "ds";
                var facultyInfo = db.Faculty_Info.Where(a => Equals(a.fUName, mm.lf.fUName)).FirstOrDefault();
                if (facultyInfo != null)
                {
                    if (mm.lf.fNPassword == facultyInfo.fNPassword)
                    {
                        fmsg = "Successfully Login";
                        Set("keys", mm.lf.fUName, 100);
                        return Redirect("/FacultyPanel/Facultypanel");

                    }
                    else { fmsg = "Wrong Password"; mm.loginAleart = true; }
                }
                else
                {
                    fmsg = "User Name Not Registered";
                    mm.loginAleart = true;

                }
                ViewBag.fmessage = fmsg;
            }
            else if(mm.fi!=null)
            {
                var srchId = db.Registration_faculty.Where(a => a.id == mm.fi.id).FirstOrDefault();

                if (srchId == null)
                {
                    mm.fi.fCPassword = BCrypt.Net.BCrypt.HashPassword(mm.fi.fCPassword);
                    mm.fi.fNPassword = BCrypt.Net.BCrypt.HashPassword(mm.fi.fNPassword);
                    db.Registration_faculty.Add(mm.fi);
                    DateTimeOffset value = DateTimeOffset.Now;
                    NotificationInfo nf = new NotificationInfo();
                    nf.Nfrom = mm.fi.fLName;
                    nf.NDetails = "University id=" + mm.fi.id + " Faculty User Name=" + mm.fi.fUName + " Faculty Email id=" + mm.fi.fEmail + " Contact Number=" + mm.fi.fContactNumber;
                    nf.NFor = "Registration";
                    nf.NTo = "Admin";
                    nf.NStatus = "Pending";
                    nf.NComingDate = value.ToString("d");
                    nf.NComingTime = value.ToString("t");
                    nf.NHId = mm.fi.id;
                    db.Notifications.Add(nf);

                    db.Registration_faculty.Add(mm.fi);
                    db.SaveChanges();
                    mm.RegistrationAleart = "success";
                }
                else
                {
                    mm.RegistrationAleart = "error";
                }

            }
                 return View(mm);
           
        }


        public void Set(string key, string value, int? expireTime)
        {
            CookieOptions option = new CookieOptions();

            if (expireTime.HasValue)
                option.Expires = DateTime.Now.AddMinutes(expireTime.Value);
            else
                option.Expires = DateTime.Now.AddMilliseconds(10);

            Response.Cookies.Append(key, value, option);
        }
    }
}

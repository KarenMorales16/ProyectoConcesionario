using concesionario.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Data.Entity.Core.Objects;
using System.Web.Security;
using System.Web.Configuration;

namespace concesionario.Controllers
{
    public class LoginController : Controller
    {
        ConsecionarioDeAutosEntities db = new ConsecionarioDeAutosEntities();
        public ViewResult Index(string ReturnUrl)
        {

            FormsAuthentication.SignOut();

            // clear authentication cookie
            HttpCookie cookie1 = new HttpCookie(FormsAuthentication.FormsCookieName, "");
            cookie1.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(cookie1);


            // clear session cookie (not necessary for your current problem but i would recommend you do it anyway)
            SessionStateSection sessionStateSection = (SessionStateSection)WebConfigurationManager.GetSection("system.web/sessionState");
            HttpCookie cookie2 = new HttpCookie(sessionStateSection.CookieName, "");
            cookie2.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(cookie2);
            ViewBag.ReturnUrl = ReturnUrl;
            return View();

        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(Login model, string ReturnUrl)
        {
            //System.Threading.Thread.Sleep(4000);
            if (!ModelState.IsValid)
            {
                return View("Index", model);
            }
            using (ConsecionarioDeAutosEntities db = new ConsecionarioDeAutosEntities())
            {
                List<SP_Login_Result> result = db.SP_Login(model.Usuario, model.Contra).ToList();
                int IdUser = Convert.ToInt32(result[0].IdUsu);
                int IdTipEmp = Convert.ToInt32(result[0].IdTip);

                if (IdUser > 0 && IdTipEmp > 0)
                {
                    Session["IdUsuario"] = IdUser;
                    Session["IdTipoEmpleado"] = IdTipEmp;
                    FormsAuthentication.SetAuthCookie(Convert.ToString(10), false);

                    
       
                        return Json(new { value = 1, messe = "/Empleado/Index" }, JsonRequestBehavior.AllowGet);
                                       
                }
                else
                {
                    return Json(new { value = 0, messe = "Usuario y/o contraseña incorrectos." }, JsonRequestBehavior.AllowGet);
                }
            }
        }
    }
}

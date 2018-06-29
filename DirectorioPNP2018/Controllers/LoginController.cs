using DirectorioPNP2018.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DirectorioPNP2018.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        //
        [HttpPost]
        public ActionResult Autherize(DirectorioPNP2018.Models.Usuarios UsuariosModel)


        {
            using (DirectorioPNPEntities db = new DirectorioPNPEntities())
            {
                var usuariosDetails = db.Usuarios.Where(x => x.username == UsuariosModel.username && x.pass == UsuariosModel.pass).FirstOrDefault();
                if (usuariosDetails == null)
                {
                    UsuariosModel.LoginErrorMessage = "Usuario y/o contraseña incorrecta.";
                    return View("Index", UsuariosModel);
                }
                else
                {
                    Session["idUsuarios"] = usuariosDetails.idUsuarios;
                    Session["username"] = usuariosDetails.username;
                    Session["apPaterno"] = usuariosDetails.apPaterno;
                    Session["apMaterno"] = usuariosDetails.apMaterno;
                    Session["nombres"] = usuariosDetails.nombres;
                    return RedirectToAction("Index", "Home");
                }
            }

        }

        public ActionResult LogOut()
        {
            int userId = (int)Session["idUsuarios"];
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }


    }
}
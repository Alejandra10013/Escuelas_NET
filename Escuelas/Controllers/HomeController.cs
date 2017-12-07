using Escuelas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc; 

namespace Escuelas.Controllers
{
    public class HomeController : Controller
    {
        ESCUELAS_NETEntities cnx;

        public HomeController() {
            cnx = new ESCUELAS_NETEntities();
        }

        public ActionResult Formulario() {
            return View();
        }
        public ActionResult Guardar(string rut, string nombre, string titulo, string grado)
        {
            PROFESOR profe = new PROFESOR()
            {
                rut = rut,
               nombre = nombre,
                titulo = titulo,
                grado = grado
            };

            cnx.PROFESORs.Add(profe); 
            cnx.SaveChanges();
            return View ("Listado", ListadoProfesores());

        }

        public ActionResult Listado()
        { 
            return View( ListadoProfesores());
        }




        private List<Escuelas.Models.PROFESOR> ListadoProfesores()
        {
            cnx.Database.Connection.Open();

            List<PROFESOR> profesores = cnx.PROFESORs.ToList();
            cnx.Database.Connection.Close();
            return profesores;
        }
    }
}
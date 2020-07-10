using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using concesionario.Models;
using concesionario.Models.PedirModelos;
using Newtonsoft.Json;
using System.Data.Entity.Core.Objects;


namespace concesionario.Controllers
{
    public class OrdenarController : Controller
    {
        // GET: Ordenar
        private ConsecionarioDeAutosEntities db = new ConsecionarioDeAutosEntities();
        [HttpGet]
        public ActionResult Index()
        {
           
            ViewBag.Performance = (from p in db.Performance
                                   select new
                                   {
                                       IdPerformance = p.IdPerformance,
                                       Performance = p.Performance1 + " $" + p.Precio,
                                   }).ToList();
            ViewBag.Color = (from c in db.Color
                             select new
                             {
                                 IdColor = c.IdColor,
                                 Color = c.Color1 + " $" + c.Precio,
                             }).ToList();
            ViewBag.Sexo = (from s in db.Sexo
                            select new
                            {
                                IdSexo = s.IdSexo,
                                Sexo = s.Sexo1
                            }).ToList();
            ViewBag.IdMesExpiracion = (from m in db.MesExpiracion
                                       select new
                                       {
                                           IdMesExpiracion = m.IdMesExpiracion,
                                           MesExpiracion = m.MesExpiracion1
                                       }).ToList();
            ViewBag.IdFechaExpiracion = (from m in db.FechaExpiracion
                                         select new
                                         {
                                             IdFechaExpiracion = m.IdFechaExpiracion,
                                             FechaExpiracion = m.FechaExpiracion1
                                         }).ToList();

            ViewBag.IdTiempodePago = (from t in db.TiempoDePago
                                      select new
                                      {
                                          IdTiempo=t.IdTiempoDePago,
                                          Tiempo=t.TiempoDePago1

                                      }).ToList();

            ViewBag.Anio = (from A in db.Autos join AA in  db.Anio on A.IdAnio equals AA.IdAnio join M in db.Modelo on  A.IdModelo equals  M.IdModelo where  A.IdModelo == 1
                            
                                      select new
                                      {
                                          IdAutos = A.IdAutos,                                     
                                          Precio = AA.Anio1+" $"+A.Precio

                                      }).ToList();
            ViewBag.Sucursal = (from s in db.Sucursal
                                      select new
                                      {
                                          IdSucursal = s.IdSucursal,
                                          Sucursal = s.Direccion

                                      }).ToList();
            
            return View("Index");
        }
        
        [HttpPost]
        public ActionResult Index(CarroOrdenar model)
        {
            
            try
                {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                else
                {
                    ObjectParameter OutPut = new ObjectParameter("Bandera", typeof(int));
                    db.SP_OrdeanarCarro(model.IdAuto, model.IdColor, model.IdPerformance, model.Nombre, model.ApP, model.ApM, model.Edad, model.FechaDeNacimiento, model.Sexo, model.RFC, model.Direccion,
                        model.CP, model.Telefono, model.TelefonoCasa, model.Correo, model.NombreEnTC, model.NoTarjetaC, model.IdMesExpiracion, model.IdFechaExpiracion, model.CVV, model.CPFacturacion,
                        model.IdTiempoDePago,model.IdSucursal,model.NombreAval,model.ApPAval,model.ApMAval,model.TelefonoAval,OutPut);
                    int valorR = Convert.ToInt32(OutPut.Value);
                    if(valorR==1)
                    {
                        return Json(new { value = 1, messen = "Carro Ordenado" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { value=0,messen="Ocurrio un error, favor de no dejar campos vacios"});
                    }
                    
                }
            }

            catch
            {
                //ViewBag.Performance = (from p in db.Performance
                //                       select new
                //                       {
                //                           IdPerformance = p.IdPerformance,
                //                           Performance = p.Performance1 + " $" + p.Precio,
                //                       }).ToList();
                //ViewBag.Color = (from c in db.Color
                //                 select new
                //                 {
                //                     IdColor = c.IdColor,
                //                     Color = c.Color1 + " $" + c.Precio,
                //                 }).ToList();
                //ViewBag.Sexo = (from s in db.Sexo
                //                select new
                //                {
                //                    IdSexo = s.IdSexo,
                //                    Sexo = s.Sexo1
                //                }).ToList();
                //ViewBag.IdMesExpiracion = (from m in db.MesExpiracion
                //                           select new
                //                           {
                //                               IdMesExpiracion = m.IdMesExpiracion,
                //                               MesExpiracion = m.MesExpiracion1
                //                           }).ToList();
                //ViewBag.IdFechaExpiracion = (from m in db.FechaExpiracion
                //                             select new
                //                             {
                //                                 IdFechaExpiracion = m.IdFechaExpiracion,
                //                                 FechaExpiracion = m.FechaExpiracion1
                //                             }).ToList();

                //ViewBag.IdTiempodePago = (from t in db.TiempoDePago
                //                          select new
                //                          {
                //                              IdTiempo = t.IdTiempoDePago,
                //                              Tiempo = t.TiempoDePago1

                //                          }).ToList();

                //ViewBag.Anio = (from A in db.Autos
                //                join AA in db.Anio on A.IdAnio equals AA.IdAnio
                //                join M in db.Modelo on A.IdModelo equals M.IdModelo
                //                where A.IdModelo == 1

                //                select new
                //                {
                //                    IdAutos = A.IdAutos,
                //                    Precio = AA.Anio1 + " $" + A.Precio

                //                }).ToList();
                //ViewBag.Sucursal = (from s in db.Sucursal
                //                    select new
                //                    {
                //                        IdSucursal = s.IdSucursal,
                //                        Sucursal = s.Direccion

                //                    }).ToList();
                return PartialView("Index",model);
            }
        }
        [HttpGet]
        public ActionResult Index3()
        {

            ViewBag.Performance = (from p in db.Performance
                                   select new
                                   {
                                       IdPerformance = p.IdPerformance,
                                       Performance = p.Performance1 + " $" + p.Precio,
                                   }).ToList();
            ViewBag.Color = (from c in db.Color
                             select new
                             {
                                 IdColor = c.IdColor,
                                 Color = c.Color1 + " $" + c.Precio,
                             }).ToList();
            ViewBag.Sexo = (from s in db.Sexo
                            select new
                            {
                                IdSexo = s.IdSexo,
                                Sexo = s.Sexo1
                            }).ToList();
            ViewBag.IdMesExpiracion = (from m in db.MesExpiracion
                                       select new
                                       {
                                           IdMesExpiracion = m.IdMesExpiracion,
                                           MesExpiracion = m.MesExpiracion1
                                       }).ToList();
            ViewBag.IdFechaExpiracion = (from m in db.FechaExpiracion
                                         select new
                                         {
                                             IdFechaExpiracion = m.IdFechaExpiracion,
                                             FechaExpiracion = m.FechaExpiracion1
                                         }).ToList();

            ViewBag.IdTiempodePago = (from t in db.TiempoDePago
                                      select new
                                      {
                                          IdTiempo = t.IdTiempoDePago,
                                          Tiempo = t.TiempoDePago1

                                      }).ToList();

            ViewBag.Anio = (from A in db.Autos
                            join AA in db.Anio on A.IdAnio equals AA.IdAnio
                            join M in db.Modelo on A.IdModelo equals M.IdModelo
                            where A.IdModelo == 2

                            select new
                            {
                                IdAutos = A.IdAutos,
                                Precio = AA.Anio1 + " $" + A.Precio

                            }).ToList();
            ViewBag.Sucursal = (from s in db.Sucursal
                                select new
                                {
                                    IdSucursal = s.IdSucursal,
                                    Sucursal = s.Direccion

                                }).ToList();

            return View("Index3");
        }
        [HttpPost]
        public ActionResult Index3(CarroOrdenar model)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                else
                {

                    ObjectParameter OutPut = new ObjectParameter("Bandera", typeof(int));
                    db.SP_OrdeanarCarro(model.IdAuto, model.IdColor, model.IdPerformance, model.Nombre, model.ApP, model.ApM, model.Edad, model.FechaDeNacimiento, model.Sexo, model.RFC, model.Direccion,
                        model.CP, model.Telefono, model.TelefonoCasa, model.Correo, model.NombreEnTC, model.NoTarjetaC, model.IdMesExpiracion, model.IdFechaExpiracion, model.CVV, model.CPFacturacion,
                        model.IdTiempoDePago, model.IdSucursal, model.NombreAval, model.ApPAval, model.ApMAval, model.TelefonoAval, OutPut);
                    int valorR = Convert.ToInt32(OutPut.Value);
                    if (valorR == 1)
                    {
                        return Json(new { value = 1, messen = "Carro Ordenado" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { value = 0, messen = "Ocurrio un error, favor de no dejar campos vacios" });
                    }
                }
            }

            catch
            {
                ViewBag.Performance = (from p in db.Performance
                                       select new
                                       {
                                           IdPerformance = p.IdPerformance,
                                           Performance = p.Performance1 + " $" + p.Precio,
                                       }).ToList();
                ViewBag.Color = (from c in db.Color
                                 select new
                                 {
                                     IdColor = c.IdColor,
                                     Color = c.Color1 + " $" + c.Precio,
                                 }).ToList();
                ViewBag.Sexo = (from s in db.Sexo
                                select new
                                {
                                    IdSexo = s.IdSexo,
                                    Sexo = s.Sexo1
                                }).ToList();
                ViewBag.IdMesExpiracion = (from m in db.MesExpiracion
                                           select new
                                           {
                                               IdMesExpiracion = m.IdMesExpiracion,
                                               MesExpiracion = m.MesExpiracion1
                                           }).ToList();
                ViewBag.IdFechaExpiracion = (from m in db.FechaExpiracion
                                             select new
                                             {
                                                 IdFechaExpiracion = m.IdFechaExpiracion,
                                                 FechaExpiracion = m.FechaExpiracion1
                                             }).ToList();

                ViewBag.IdTiempodePago = (from t in db.TiempoDePago
                                          select new
                                          {
                                              IdTiempo = t.IdTiempoDePago,
                                              Tiempo = t.TiempoDePago1

                                          }).ToList();

                ViewBag.Anio = (from A in db.Autos
                                join AA in db.Anio on A.IdAnio equals AA.IdAnio
                                join M in db.Modelo on A.IdModelo equals M.IdModelo
                                where A.IdModelo == 2

                                select new
                                {
                                    IdAutos = A.IdAutos,
                                    Precio = AA.Anio1 + " $" + A.Precio

                                }).ToList();
                ViewBag.Sucursal = (from s in db.Sucursal
                                    select new
                                    {
                                        IdSucursal = s.IdSucursal,
                                        Sucursal = s.Direccion

                                    }).ToList();
                return PartialView("Index3", model);
            }
        }
        [HttpGet]
        public ActionResult IndexX()
        {

            ViewBag.Performance = (from p in db.Performance
                                   select new
                                   {
                                       IdPerformance = p.IdPerformance,
                                       Performance = p.Performance1 + " $" + p.Precio,
                                   }).ToList();
            ViewBag.Color = (from c in db.Color
                             select new
                             {
                                 IdColor = c.IdColor,
                                 Color = c.Color1 + " $" + c.Precio,
                             }).ToList();
            ViewBag.Sexo = (from s in db.Sexo
                            select new
                            {
                                IdSexo = s.IdSexo,
                                Sexo = s.Sexo1
                            }).ToList();
            ViewBag.IdMesExpiracion = (from m in db.MesExpiracion
                                       select new
                                       {
                                           IdMesExpiracion = m.IdMesExpiracion,
                                           MesExpiracion = m.MesExpiracion1
                                       }).ToList();
            ViewBag.IdFechaExpiracion = (from m in db.FechaExpiracion
                                         select new
                                         {
                                             IdFechaExpiracion = m.IdFechaExpiracion,
                                             FechaExpiracion = m.FechaExpiracion1
                                         }).ToList();

            ViewBag.IdTiempodePago = (from t in db.TiempoDePago
                                      select new
                                      {
                                          IdTiempo = t.IdTiempoDePago,
                                          Tiempo = t.TiempoDePago1

                                      }).ToList();

            ViewBag.Anio = (from A in db.Autos
                            join AA in db.Anio on A.IdAnio equals AA.IdAnio
                            join M in db.Modelo on A.IdModelo equals M.IdModelo
                            where A.IdModelo == 3

                            select new
                            {
                                IdAutos = A.IdAutos,
                                Precio = AA.Anio1 + " $" + A.Precio

                            }).ToList();
            ViewBag.Sucursal = (from s in db.Sucursal
                                select new
                                {
                                    IdSucursal = s.IdSucursal,
                                    Sucursal = s.Direccion

                                }).ToList();

            return View("IndexX");
        }
        [HttpPost]
        public ActionResult IndexX(CarroOrdenar model)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                else
                {

                    ObjectParameter OutPut = new ObjectParameter("Bandera", typeof(int));
                    db.SP_OrdeanarCarro(model.IdAuto, model.IdColor, model.IdPerformance, model.Nombre, model.ApP, model.ApM, model.Edad, model.FechaDeNacimiento, model.Sexo, model.RFC, model.Direccion,
                        model.CP, model.Telefono, model.TelefonoCasa, model.Correo, model.NombreEnTC, model.NoTarjetaC, model.IdMesExpiracion, model.IdFechaExpiracion, model.CVV, model.CPFacturacion,
                        model.IdTiempoDePago, model.IdSucursal, model.NombreAval, model.ApPAval, model.ApMAval, model.TelefonoAval, OutPut);
                    int valorR = Convert.ToInt32(OutPut.Value);
                    if (valorR == 1)
                    {
                        return Json(new { value = 1, messen = "Carro Ordenado" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { value = 0, messen = "Ocurrio un error, favor de no dejar campos vacios" });
                    }
                }
            }

            catch
            {
                ViewBag.Performance = (from p in db.Performance
                                       select new
                                       {
                                           IdPerformance = p.IdPerformance,
                                           Performance = p.Performance1 + " $" + p.Precio,
                                       }).ToList();
                ViewBag.Color = (from c in db.Color
                                 select new
                                 {
                                     IdColor = c.IdColor,
                                     Color = c.Color1 + " $" + c.Precio,
                                 }).ToList();
                ViewBag.Sexo = (from s in db.Sexo
                                select new
                                {
                                    IdSexo = s.IdSexo,
                                    Sexo = s.Sexo1
                                }).ToList();
                ViewBag.IdMesExpiracion = (from m in db.MesExpiracion
                                           select new
                                           {
                                               IdMesExpiracion = m.IdMesExpiracion,
                                               MesExpiracion = m.MesExpiracion1
                                           }).ToList();
                ViewBag.IdFechaExpiracion = (from m in db.FechaExpiracion
                                             select new
                                             {
                                                 IdFechaExpiracion = m.IdFechaExpiracion,
                                                 FechaExpiracion = m.FechaExpiracion1
                                             }).ToList();

                ViewBag.IdTiempodePago = (from t in db.TiempoDePago
                                          select new
                                          {
                                              IdTiempo = t.IdTiempoDePago,
                                              Tiempo = t.TiempoDePago1

                                          }).ToList();

                ViewBag.Anio = (from A in db.Autos
                                join AA in db.Anio on A.IdAnio equals AA.IdAnio
                                join M in db.Modelo on A.IdModelo equals M.IdModelo
                                where A.IdModelo == 3

                                select new
                                {
                                    IdAutos = A.IdAutos,
                                    Precio = AA.Anio1 + " $" + A.Precio

                                }).ToList();
                ViewBag.Sucursal = (from s in db.Sucursal
                                    select new
                                    {
                                        IdSucursal = s.IdSucursal,
                                        Sucursal = s.Direccion

                                    }).ToList();
                return PartialView("IndexX", model);
            }
        }
        [HttpGet]
        public ActionResult IndexC()
        {

            ViewBag.Performance = (from p in db.Performance
                                   select new
                                   {
                                       IdPerformance = p.IdPerformance,
                                       Performance = p.Performance1 + " $" + p.Precio,
                                   }).ToList();
            ViewBag.Color = (from c in db.Color
                             select new
                             {
                                 IdColor = c.IdColor,
                                 Color = c.Color1 + " $" + c.Precio,
                             }).ToList();
            ViewBag.Sexo = (from s in db.Sexo
                            select new
                            {
                                IdSexo = s.IdSexo,
                                Sexo = s.Sexo1
                            }).ToList();
            ViewBag.IdMesExpiracion = (from m in db.MesExpiracion
                                       select new
                                       {
                                           IdMesExpiracion = m.IdMesExpiracion,
                                           MesExpiracion = m.MesExpiracion1
                                       }).ToList();
            ViewBag.IdFechaExpiracion = (from m in db.FechaExpiracion
                                         select new
                                         {
                                             IdFechaExpiracion = m.IdFechaExpiracion,
                                             FechaExpiracion = m.FechaExpiracion1
                                         }).ToList();

            ViewBag.IdTiempodePago = (from t in db.TiempoDePago
                                      select new
                                      {
                                          IdTiempo = t.IdTiempoDePago,
                                          Tiempo = t.TiempoDePago1

                                      }).ToList();

            ViewBag.Anio = (from A in db.Autos
                            join AA in db.Anio on A.IdAnio equals AA.IdAnio
                            join M in db.Modelo on A.IdModelo equals M.IdModelo
                            where A.IdModelo == 4

                            select new
                            {
                                IdAutos = A.IdAutos,
                                Precio = AA.Anio1 + " $" + A.Precio

                            }).ToList();
            ViewBag.Sucursal = (from s in db.Sucursal
                                select new
                                {
                                    IdSucursal = s.IdSucursal,
                                    Sucursal = s.Direccion

                                }).ToList();

            return View("IndexC");
        }
        [HttpPost]
        public ActionResult IndexC(CarroOrdenar model)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                else
                {

                    ObjectParameter OutPut = new ObjectParameter("Bandera", typeof(int));
                    db.SP_OrdeanarCarro(model.IdAuto, model.IdColor, model.IdPerformance, model.Nombre, model.ApP, model.ApM, model.Edad, model.FechaDeNacimiento, model.Sexo, model.RFC, model.Direccion,
                        model.CP, model.Telefono, model.TelefonoCasa, model.Correo, model.NombreEnTC, model.NoTarjetaC, model.IdMesExpiracion, model.IdFechaExpiracion, model.CVV, model.CPFacturacion,
                        model.IdTiempoDePago, model.IdSucursal, model.NombreAval, model.ApPAval, model.ApMAval, model.TelefonoAval, OutPut);
                    int valorR = Convert.ToInt32(OutPut.Value);
                    if (valorR == 1)
                    {
                        return Json(new { value = 1, messen = "Carro Ordenado" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { value = 0, messen = "Ocurrio un error, favor de no dejar campos vacios" });
                    }
                }
            }

            catch
            {
                ViewBag.Performance = (from p in db.Performance
                                       select new
                                       {
                                           IdPerformance = p.IdPerformance,
                                           Performance = p.Performance1 + " $" + p.Precio,
                                       }).ToList();
                ViewBag.Color = (from c in db.Color
                                 select new
                                 {
                                     IdColor = c.IdColor,
                                     Color = c.Color1 + " $" + c.Precio,
                                 }).ToList();
                ViewBag.Sexo = (from s in db.Sexo
                                select new
                                {
                                    IdSexo = s.IdSexo,
                                    Sexo = s.Sexo1
                                }).ToList();
                ViewBag.IdMesExpiracion = (from m in db.MesExpiracion
                                           select new
                                           {
                                               IdMesExpiracion = m.IdMesExpiracion,
                                               MesExpiracion = m.MesExpiracion1
                                           }).ToList();
                ViewBag.IdFechaExpiracion = (from m in db.FechaExpiracion
                                             select new
                                             {
                                                 IdFechaExpiracion = m.IdFechaExpiracion,
                                                 FechaExpiracion = m.FechaExpiracion1
                                             }).ToList();

                ViewBag.IdTiempodePago = (from t in db.TiempoDePago
                                          select new
                                          {
                                              IdTiempo = t.IdTiempoDePago,
                                              Tiempo = t.TiempoDePago1

                                          }).ToList();

                ViewBag.Anio = (from A in db.Autos
                                join AA in db.Anio on A.IdAnio equals AA.IdAnio
                                join M in db.Modelo on A.IdModelo equals M.IdModelo
                                where A.IdModelo == 4

                                select new
                                {
                                    IdAutos = A.IdAutos,
                                    Precio = AA.Anio1 + " $" + A.Precio

                                }).ToList();
                ViewBag.Sucursal = (from s in db.Sucursal
                                    select new
                                    {
                                        IdSucursal = s.IdSucursal,
                                        Sucursal = s.Direccion

                                    }).ToList();
                return PartialView("IndexC", model);
            }
        }
    }
}

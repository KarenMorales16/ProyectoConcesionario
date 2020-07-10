using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using concesionario.Models;
using Newtonsoft.Json;
using System.Data.Entity.Core.Objects;
using System.Security.Cryptography;

namespace concesionario.Controllers
{
    public class EmpleadoController : Controller
    {
        ConsecionarioDeAutosEntities db = new ConsecionarioDeAutosEntities();
        // GET: Empleado
        public ActionResult Index()
        {
            int IdUsuario = Convert.ToInt32(Session["IdUsuario"]);
            var nombre = (from e in db.Empleado
                          where e.IdUsuarioLogin == IdUsuario
                          select e.Nombre
                                      ).FirstOrDefault();
            var ApP = (from e in db.Empleado
                       where e.IdUsuarioLogin == IdUsuario
                       select e.ApP
                                      ).FirstOrDefault();

            ViewBag.NombreEmpleado = nombre + " " + ApP;

            return View("Index");
        }

        // GET: Empleado/Details/5
        public ActionResult Abono()
        {
            return View("Abono");
        }
        public ActionResult gridabono()
        {
            string JSONString = string.Empty;
            List<Bitacora> grid = (from bp in db.BitacoraDePago
                                   join va in db.VentaAuto on bp.IdVentaAuto equals va.IdVentaAuto
                                   join c in db.Cliente on va.IdCliente equals c.IdCliente
                                   select new Bitacora
                                   {
                                       id_Bitacora = bp.id_Bitacora,
                                       FechaDePago = bp.FechaDePago,
                                       Abono = bp.Abono,
                                       PagoMinimo = bp.PagoMinimo,
                                       IdVentaAuto = bp.IdVentaAuto,
                                       Restante = bp.Restante,
                                       IdCliente = c.IdCliente,
                                       Nombre = c.Nombre + " " + c.ApP + " " + c.ApM
                                   }).ToList();

            JSONString = JsonConvert.SerializeObject(grid);
            return Json(JSONString, JsonRequestBehavior.AllowGet);
        }
        public ActionResult VentaAuto()
        {
            return View("VentaAuto");
        }
        public ActionResult gridVentaAuto()
        {
            string JSONString = string.Empty;
            List<VentaAutoGrid> grid = (from va in db.VentaAuto
                                        join a in db.Autos on va.IdAutos equals a.IdAutos
                                        join aa in db.Auto_Adiccionales on va.IdAuto_Adic equals aa.IdAuto_Adic
                                        join c in db.Cliente on va.IdCliente equals c.IdCliente
                                        join s in db.Sucursal on va.IdSucursal equals s.IdSucursal
                                        join co in db.Color on a.IdColor equals co.IdColor
                                        join m in db.Modelo on a.IdModelo equals m.IdModelo
                                        join an in db.Anio on a.IdAnio equals an.IdAnio
                                        where va.IdVendido == 1
                                        select new VentaAutoGrid
                                        {
                                            IdVentaAuto = va.IdVentaAuto,
                                            Nombre = c.Nombre + " " + c.ApP + " " + c.ApM,
                                            Telefono = c.Telefono,
                                            TelefonoCasa = c.TelefonoCasa,
                                            Correo = c.Correo,
                                            Carro = a.Marca + " " + m.Modelo1,
                                            Anio = an.Anio1
                                        }).ToList();

            JSONString = JsonConvert.SerializeObject(grid);
            return Json(JSONString, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Completado(int IdVentaAuto)
        {
            int IdUsuario = Convert.ToInt32(Session["IdUsuario"]);
            var IdEmpleado = (from u in db.UsuarioLogin
                              join e in db.Empleado on u.IdUsuarioLogin equals e.IdUsuarioLogin
                              where u.IdUsuarioLogin == IdUsuario
                              select e.IdEmpleado).FirstOrDefault();

            ObjectParameter OutPut = new ObjectParameter("Bandera", typeof(int));
            db.SP_CompraCompletada(IdVentaAuto, IdEmpleado, OutPut);
            int valorR = Convert.ToInt32(OutPut.Value);
            if (valorR == 1)
            {
                return Json(new { value = 1 }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { value = 0 }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Traspaso()
        {
            return View("Traspaso");
        }
        public ActionResult Abonar(int id_Bitacora, decimal PagoMinimo)
        {

            ObjectParameter OutPut = new ObjectParameter("Bandera", typeof(int));
            db.SP_Abonar(id_Bitacora, PagoMinimo, OutPut);
            int valorR = Convert.ToInt32(OutPut.Value);
            if (valorR == 1)
            {
                return Json(new { value = 1 }, JsonRequestBehavior.AllowGet);
            }
            else if (valorR == 2)
            {
                return Json(new { value = 2 }, JsonRequestBehavior.AllowGet);
            }
            else if (valorR == 3)
            {
                return Json(new { value = 3 }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { value = 0 }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult Pagos()
        {
            return View("ListaP");
        }
        public ActionResult Lp()
        {
            string JSONString = string.Empty;
            List<Bitacora> grid = (from bp in db.BitacoraDePago
                                   join va in db.VentaAuto on bp.IdVentaAuto equals va.IdVentaAuto
                                   join c in db.Cliente on va.IdCliente equals c.IdCliente
                                   where bp.Restante != null
                                   select new Bitacora
                                   {
                                       id_Bitacora = bp.id_Bitacora,
                                       FechaDePago = bp.FechaDePago,
                                       Abono = bp.Abono,
                                       PagoMinimo = bp.PagoMinimo,
                                       IdVentaAuto = bp.IdVentaAuto,
                                       Restante = bp.Restante,
                                       IdCliente = c.IdCliente,
                                       Nombre = c.Nombre + " " + c.ApP + " " + c.ApM
                                   }).ToList();

            JSONString = JsonConvert.SerializeObject(grid);
            return Json(JSONString, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult Alta()
        {
            ViewBag.Color = (from c in db.Color
                             select new
                             {
                                 IdColor = c.IdColor,
                                 Color = c.Color1 + " $" + c.Precio,
                             }).ToList();
            ViewBag.Anio = (from A in db.Anio
                            select new
                            {
                                IdAnio = A.IdAnio,
                                Anio = A.Anio1

                            }).ToList();
            ViewBag.Sucursal = (from s in db.Sucursal
                                select new
                                {
                                    IdSucursal = s.IdSucursal,
                                    Sucursal = s.Direccion

                                }).ToList();

            return View("AltaAuto");
        }
        [HttpPost]
        public ActionResult Alta(AltaAuto model)
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
                    db.AutosAlta(model.Marca, model.IdColor, model.Modelo, model.IdAnio, model.Precio, model.Cantidad, model.IdSucursal, OutPut);
                    int valorR = Convert.ToInt32(OutPut.Value);
                    if (valorR == 1)
                    {
                        return Json(new { value = 1, messen = "Carro Creado" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { value = 0, messen = "Ocurrio un error, favor de no dejar campos vacios" });
                    }
                }
            }
            catch
            {
                return PartialView("Index", model);
            }
        }

        public ActionResult AutosConsecionario()
        {
            string JSONString = string.Empty;
            List<AutosConsecionario> grid = (from a in db.Autos
                                             join m in db.Modelo on a.IdModelo equals m.IdModelo
                                             join an in db.Anio on a.IdAnio equals an.IdAnio

                                             select new AutosConsecionario
                                             {
                                                 IdAuto = a.IdAutos,
                                                 Marca = a.Marca + " "+m.Modelo1,
                                                 IdModelo = a.IdModelo,
                                                 IdAnio = a.IdAnio,
                                                 Anio = an.Anio1,
                                                 Precio = a.Precio
                                             }).ToList();
            JSONString = JsonConvert.SerializeObject(grid);
            return Json(JSONString, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult TraspasoA()
        {
            ViewBag.Modelo = (from m in db.Modelo
                              select new
                              {
                                  IdModelo = m.IdModelo,
                                  Modelo = m.Modelo1

                              }).ToList();
            ViewBag.Sucursal = (from s in db.Sucursal
                                select new
                                {
                                    IdSucursal = s.IdSucursal,
                                    Sucursal = s.Direccion

                                }).ToList();
            ViewBag.Anio = (from a in db.Anio
                            where a.IdAnio != 1
                            select new
                            {
                                IdAnio = a.IdAnio,
                                Anio = a.Anio1

                            }).ToList();
            ViewBag.SucursalD = (from s in db.Sucursal
                                 select new
                                 {
                                     IdSucursal = s.IdSucursal,
                                     Sucursal = s.Direccion

                                 }).ToList();
            return View("Traspaso");
        }
        [HttpPost]
        public ActionResult TraspasoA(Traspaso model)
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
                    db.SP_Traspaso(model.IdModelo, model.IdAnio, model.Cantidad, model.IdSucursal, model.IdSucursalD, OutPut);
                    int valorR = Convert.ToInt32(OutPut.Value);
                    if (valorR == 1)
                    {
                        return Json(new { value = 1, messen = "Traspaso realizado correctamente" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { value = 0, messen = "Ocurrio un error" });
                    }
                }
            }
            catch
            {
                return PartialView("Index", model);
            }
        }

    }
}

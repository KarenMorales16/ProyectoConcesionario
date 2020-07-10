﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace concesionario.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class ConsecionarioDeAutosEntities : DbContext
    {
        public ConsecionarioDeAutosEntities()
            : base("name=ConsecionarioDeAutosEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Anio> Anio { get; set; }
        public virtual DbSet<Auto_Adiccionales> Auto_Adiccionales { get; set; }
        public virtual DbSet<AutoExistencia> AutoExistencia { get; set; }
        public virtual DbSet<Autos> Autos { get; set; }
        public virtual DbSet<Aval> Aval { get; set; }
        public virtual DbSet<BitacoraDePago> BitacoraDePago { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Color> Color { get; set; }
        public virtual DbSet<Consecionario> Consecionario { get; set; }
        public virtual DbSet<DatosFinanciamiento> DatosFinanciamiento { get; set; }
        public virtual DbSet<DB_Errors> DB_Errors { get; set; }
        public virtual DbSet<Empleado> Empleado { get; set; }
        public virtual DbSet<EmpleadoSucursal> EmpleadoSucursal { get; set; }
        public virtual DbSet<FechaExpiracion> FechaExpiracion { get; set; }
        public virtual DbSet<MesExpiracion> MesExpiracion { get; set; }
        public virtual DbSet<Modelo> Modelo { get; set; }
        public virtual DbSet<Partes> Partes { get; set; }
        public virtual DbSet<PartesInventario> PartesInventario { get; set; }
        public virtual DbSet<PartesPrecio> PartesPrecio { get; set; }
        public virtual DbSet<PartesPrecioBitacora> PartesPrecioBitacora { get; set; }
        public virtual DbSet<Performance> Performance { get; set; }
        public virtual DbSet<Sexo> Sexo { get; set; }
        public virtual DbSet<Sucursal> Sucursal { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TiempoDePago> TiempoDePago { get; set; }
        public virtual DbSet<TipoEmpleado> TipoEmpleado { get; set; }
        public virtual DbSet<UsuarioLogin> UsuarioLogin { get; set; }
        public virtual DbSet<Vendido> Vendido { get; set; }
        public virtual DbSet<VentaAuto> VentaAuto { get; set; }
        public virtual DbSet<VentaParte> VentaParte { get; set; }
        public virtual DbSet<ZonaHoraria> ZonaHoraria { get; set; }
    
        public virtual int AutosAlta(string marca, Nullable<int> idColor, string modelo, Nullable<int> idAnio, Nullable<decimal> precio, Nullable<int> cantidad, Nullable<int> idSucursal, ObjectParameter bandera)
        {
            var marcaParameter = marca != null ?
                new ObjectParameter("Marca", marca) :
                new ObjectParameter("Marca", typeof(string));
    
            var idColorParameter = idColor.HasValue ?
                new ObjectParameter("IdColor", idColor) :
                new ObjectParameter("IdColor", typeof(int));
    
            var modeloParameter = modelo != null ?
                new ObjectParameter("Modelo", modelo) :
                new ObjectParameter("Modelo", typeof(string));
    
            var idAnioParameter = idAnio.HasValue ?
                new ObjectParameter("IdAnio", idAnio) :
                new ObjectParameter("IdAnio", typeof(int));
    
            var precioParameter = precio.HasValue ?
                new ObjectParameter("Precio", precio) :
                new ObjectParameter("Precio", typeof(decimal));
    
            var cantidadParameter = cantidad.HasValue ?
                new ObjectParameter("Cantidad", cantidad) :
                new ObjectParameter("Cantidad", typeof(int));
    
            var idSucursalParameter = idSucursal.HasValue ?
                new ObjectParameter("IdSucursal", idSucursal) :
                new ObjectParameter("IdSucursal", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AutosAlta", marcaParameter, idColorParameter, modeloParameter, idAnioParameter, precioParameter, cantidadParameter, idSucursalParameter, bandera);
        }
    
        public virtual int Caracteristicas(Nullable<int> idAuto, Nullable<int> idPerformace, Nullable<int> idColor)
        {
            var idAutoParameter = idAuto.HasValue ?
                new ObjectParameter("IdAuto", idAuto) :
                new ObjectParameter("IdAuto", typeof(int));
    
            var idPerformaceParameter = idPerformace.HasValue ?
                new ObjectParameter("IdPerformace", idPerformace) :
                new ObjectParameter("IdPerformace", typeof(int));
    
            var idColorParameter = idColor.HasValue ?
                new ObjectParameter("IdColor", idColor) :
                new ObjectParameter("IdColor", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Caracteristicas", idAutoParameter, idPerformaceParameter, idColorParameter);
        }
    
        public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagramdefinition_Result> sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagramdefinition_Result>("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagrams_Result> sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagrams_Result>("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<SP_Login_Result> SP_Login(string usuario, string contra)
        {
            var usuarioParameter = usuario != null ?
                new ObjectParameter("Usuario", usuario) :
                new ObjectParameter("Usuario", typeof(string));
    
            var contraParameter = contra != null ?
                new ObjectParameter("Contra", contra) :
                new ObjectParameter("Contra", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_Login_Result>("SP_Login", usuarioParameter, contraParameter);
        }
    
        public virtual int SP_OrdeanarCarro(Nullable<int> idAuto, Nullable<int> idColor, Nullable<int> idPerformance, string nombre, string apP, string apM, Nullable<int> edad, Nullable<System.DateTime> fechaDeNacimiento, Nullable<int> sexo, string rFC, string direccion, Nullable<int> cP, string telefono, string telefonoCasa, string correo, string nombreEnTC, string noTarjetaC, Nullable<int> idMesExpiracion, Nullable<int> idFechaExpiracion, string cVV, Nullable<int> cPFacturacion, Nullable<int> idTiempoDePago, Nullable<int> idSucursal, string nombreAval, string apPAval, string apMAval, string telefonoAval, ObjectParameter bandera)
        {
            var idAutoParameter = idAuto.HasValue ?
                new ObjectParameter("IdAuto", idAuto) :
                new ObjectParameter("IdAuto", typeof(int));
    
            var idColorParameter = idColor.HasValue ?
                new ObjectParameter("IdColor", idColor) :
                new ObjectParameter("IdColor", typeof(int));
    
            var idPerformanceParameter = idPerformance.HasValue ?
                new ObjectParameter("IdPerformance", idPerformance) :
                new ObjectParameter("IdPerformance", typeof(int));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var apPParameter = apP != null ?
                new ObjectParameter("ApP", apP) :
                new ObjectParameter("ApP", typeof(string));
    
            var apMParameter = apM != null ?
                new ObjectParameter("ApM", apM) :
                new ObjectParameter("ApM", typeof(string));
    
            var edadParameter = edad.HasValue ?
                new ObjectParameter("Edad", edad) :
                new ObjectParameter("Edad", typeof(int));
    
            var fechaDeNacimientoParameter = fechaDeNacimiento.HasValue ?
                new ObjectParameter("FechaDeNacimiento", fechaDeNacimiento) :
                new ObjectParameter("FechaDeNacimiento", typeof(System.DateTime));
    
            var sexoParameter = sexo.HasValue ?
                new ObjectParameter("Sexo", sexo) :
                new ObjectParameter("Sexo", typeof(int));
    
            var rFCParameter = rFC != null ?
                new ObjectParameter("RFC", rFC) :
                new ObjectParameter("RFC", typeof(string));
    
            var direccionParameter = direccion != null ?
                new ObjectParameter("Direccion", direccion) :
                new ObjectParameter("Direccion", typeof(string));
    
            var cPParameter = cP.HasValue ?
                new ObjectParameter("CP", cP) :
                new ObjectParameter("CP", typeof(int));
    
            var telefonoParameter = telefono != null ?
                new ObjectParameter("Telefono", telefono) :
                new ObjectParameter("Telefono", typeof(string));
    
            var telefonoCasaParameter = telefonoCasa != null ?
                new ObjectParameter("TelefonoCasa", telefonoCasa) :
                new ObjectParameter("TelefonoCasa", typeof(string));
    
            var correoParameter = correo != null ?
                new ObjectParameter("Correo", correo) :
                new ObjectParameter("Correo", typeof(string));
    
            var nombreEnTCParameter = nombreEnTC != null ?
                new ObjectParameter("NombreEnTC", nombreEnTC) :
                new ObjectParameter("NombreEnTC", typeof(string));
    
            var noTarjetaCParameter = noTarjetaC != null ?
                new ObjectParameter("NoTarjetaC", noTarjetaC) :
                new ObjectParameter("NoTarjetaC", typeof(string));
    
            var idMesExpiracionParameter = idMesExpiracion.HasValue ?
                new ObjectParameter("IdMesExpiracion", idMesExpiracion) :
                new ObjectParameter("IdMesExpiracion", typeof(int));
    
            var idFechaExpiracionParameter = idFechaExpiracion.HasValue ?
                new ObjectParameter("IdFechaExpiracion", idFechaExpiracion) :
                new ObjectParameter("IdFechaExpiracion", typeof(int));
    
            var cVVParameter = cVV != null ?
                new ObjectParameter("CVV", cVV) :
                new ObjectParameter("CVV", typeof(string));
    
            var cPFacturacionParameter = cPFacturacion.HasValue ?
                new ObjectParameter("CPFacturacion", cPFacturacion) :
                new ObjectParameter("CPFacturacion", typeof(int));
    
            var idTiempoDePagoParameter = idTiempoDePago.HasValue ?
                new ObjectParameter("IdTiempoDePago", idTiempoDePago) :
                new ObjectParameter("IdTiempoDePago", typeof(int));
    
            var idSucursalParameter = idSucursal.HasValue ?
                new ObjectParameter("IdSucursal", idSucursal) :
                new ObjectParameter("IdSucursal", typeof(int));
    
            var nombreAvalParameter = nombreAval != null ?
                new ObjectParameter("NombreAval", nombreAval) :
                new ObjectParameter("NombreAval", typeof(string));
    
            var apPAvalParameter = apPAval != null ?
                new ObjectParameter("ApPAval", apPAval) :
                new ObjectParameter("ApPAval", typeof(string));
    
            var apMAvalParameter = apMAval != null ?
                new ObjectParameter("ApMAval", apMAval) :
                new ObjectParameter("ApMAval", typeof(string));
    
            var telefonoAvalParameter = telefonoAval != null ?
                new ObjectParameter("TelefonoAval", telefonoAval) :
                new ObjectParameter("TelefonoAval", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_OrdeanarCarro", idAutoParameter, idColorParameter, idPerformanceParameter, nombreParameter, apPParameter, apMParameter, edadParameter, fechaDeNacimientoParameter, sexoParameter, rFCParameter, direccionParameter, cPParameter, telefonoParameter, telefonoCasaParameter, correoParameter, nombreEnTCParameter, noTarjetaCParameter, idMesExpiracionParameter, idFechaExpiracionParameter, cVVParameter, cPFacturacionParameter, idTiempoDePagoParameter, idSucursalParameter, nombreAvalParameter, apPAvalParameter, apMAvalParameter, telefonoAvalParameter, bandera);
        }
    
        public virtual int sp_renamediagram(string diagramname, Nullable<int> owner_id, string new_diagramname)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var new_diagramnameParameter = new_diagramname != null ?
                new ObjectParameter("new_diagramname", new_diagramname) :
                new ObjectParameter("new_diagramname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        }
    
        public virtual int sp_upgraddiagrams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        }
    
        public virtual int SP_Usuario_Alta(string usuario, string contra, Nullable<int> idEmpleado, ObjectParameter bandera)
        {
            var usuarioParameter = usuario != null ?
                new ObjectParameter("Usuario", usuario) :
                new ObjectParameter("Usuario", typeof(string));
    
            var contraParameter = contra != null ?
                new ObjectParameter("Contra", contra) :
                new ObjectParameter("Contra", typeof(string));
    
            var idEmpleadoParameter = idEmpleado.HasValue ?
                new ObjectParameter("IdEmpleado", idEmpleado) :
                new ObjectParameter("IdEmpleado", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_Usuario_Alta", usuarioParameter, contraParameter, idEmpleadoParameter, bandera);
        }
    
        public virtual int SP_CompraCompletada(Nullable<int> idVentaAuto, Nullable<int> idEmpleado, ObjectParameter bandera)
        {
            var idVentaAutoParameter = idVentaAuto.HasValue ?
                new ObjectParameter("IdVentaAuto", idVentaAuto) :
                new ObjectParameter("IdVentaAuto", typeof(int));
    
            var idEmpleadoParameter = idEmpleado.HasValue ?
                new ObjectParameter("IdEmpleado", idEmpleado) :
                new ObjectParameter("IdEmpleado", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_CompraCompletada", idVentaAutoParameter, idEmpleadoParameter, bandera);
        }
    
        public virtual int SP_Abonar(Nullable<int> id_Bitacora, Nullable<decimal> pago, ObjectParameter bandera)
        {
            var id_BitacoraParameter = id_Bitacora.HasValue ?
                new ObjectParameter("id_Bitacora", id_Bitacora) :
                new ObjectParameter("id_Bitacora", typeof(int));
    
            var pagoParameter = pago.HasValue ?
                new ObjectParameter("Pago", pago) :
                new ObjectParameter("Pago", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_Abonar", id_BitacoraParameter, pagoParameter, bandera);
        }
    
        public virtual int SP_Traspaso(Nullable<int> idModelo, Nullable<int> idAnio, Nullable<int> cantidad, Nullable<int> idSucursal, Nullable<int> idSucursalD, ObjectParameter bandera)
        {
            var idModeloParameter = idModelo.HasValue ?
                new ObjectParameter("IdModelo", idModelo) :
                new ObjectParameter("IdModelo", typeof(int));
    
            var idAnioParameter = idAnio.HasValue ?
                new ObjectParameter("IdAnio", idAnio) :
                new ObjectParameter("IdAnio", typeof(int));
    
            var cantidadParameter = cantidad.HasValue ?
                new ObjectParameter("Cantidad", cantidad) :
                new ObjectParameter("Cantidad", typeof(int));
    
            var idSucursalParameter = idSucursal.HasValue ?
                new ObjectParameter("IdSucursal", idSucursal) :
                new ObjectParameter("IdSucursal", typeof(int));
    
            var idSucursalDParameter = idSucursalD.HasValue ?
                new ObjectParameter("IdSucursalD", idSucursalD) :
                new ObjectParameter("IdSucursalD", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_Traspaso", idModeloParameter, idAnioParameter, cantidadParameter, idSucursalParameter, idSucursalDParameter, bandera);
        }
    }
}
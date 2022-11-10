﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP09_Arana_Baranczuk.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace TP09_Arana_Baranczuk.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private IWebHostEnvironment Environment;
    public HomeController(ILogger<HomeController> logger, IWebHostEnvironment environment)
    {
        Environment = environment;
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
    
    public IActionResult VerDetalleTelas(int IdTela)
    {
        ViewBag.ListaTelas = BD.GetTela(IdTela);
        ViewBag.DetalleTelas=BD.DetalleTela(IdTela);
        return View("Telas");
    }
    public IActionResult VerDetalleColores(int IdTela)
    {
        ViewBag.ListaColores = BD.GetColor(IdTela);
        ViewBag.DetalleColores=BD.DetalleColor(IdTela);
        return View("Color");
    }
    /*
    public IActionResult EliminarColor(int IdColor)
    {
        
        BD.DeleteColorById(IdColor);
        ViewBag.DetalleColores=BD.GetColor(IdColor);
        ViewBag.ListaProductos = BD.GetProductoColor(IdColor);       
        return View("Color");
    }*/

    public IActionResult VerDetalleProducto(int IdColor)
    {
        ViewBag.ListaProductos = BD.GetProductoColor(IdColor);
        return View("Productos");
    }
    public IActionResult AgregarProducto(string Clave, int IdColor)
    {
        if(Clave=="Tpfinal")
        {
            return View("AgregarProductos");
        }
        else
        {
            ViewBag.ListaProductos = BD.GetProductoColor(IdColor);
            return View("Productos");
            
        }
    }
    
    [HttpPost]
    public IActionResult GuardarProducto(Producto producto, IFormFile File,string NombreColor, string NombreTela)
    {
        int IdTela = BD.GetNombreTela(NombreTela);
        int IdColor = BD.GetNombreColor(NombreColor);
        producto.IdTela=IdTela;
        producto.IdColor=IdColor;
        
        producto.FotoProducto=producto.NombreProducto + ".jpg";
        if(File.Length>0)
        {
            string wwwRootLocal = this.Environment.ContentRootPath + @"\wwwroot\" + producto.FotoProducto;
            using (var stream = System.IO.File.Create(wwwRootLocal))
            {
                File.CopyToAsync(stream);
            }
        }
        BD.InsertProducto(producto);
        ViewBag.ListaProductos = BD.GetProductoColor(IdColor);
        return View("Productos");
    }
    public IActionResult EliminarProducto(int IdProducto,int IdColor,int IdTela, string Clave)
    {
        if(Clave=="Tpfinal")
        {
            BD.EliminarProducto(IdProducto);
        
        
            ViewBag.ListaTelas = BD.GetTela(IdTela);
            ViewBag.DetalleTelas=BD.DetalleTela(IdTela);
            ViewBag.ListaColores = BD.GetColor(IdTela);
            ViewBag.DetalleColores=BD.DetalleColor(IdTela);
            ViewBag.ListaProductos = BD.GetProductoColor(IdColor);
            ViewBag.DetalleProducto = BD.DetalleProducto(IdProducto);
            return View("Productos");
        }
        else
        {
            ViewBag.ListaProductos = BD.GetProductoColor(IdColor);
            return View("Productos");
            
        }
        
    }
    public Producto VerDetalleProductoAjax(int IdProducto)
    {
        ViewBag.Producto = BD.VerInfoProductoAjax(IdProducto);
        return ViewBag.Producto;
    }
    /*
    public IActionResult AgregarColor(string Clave, int IdColor)
    {
        if(Clave=="Tpfinal")
        {
            return View("AgregarColor");
        }
        else
        {
            ViewBag.ListaColores = BD.GetColor(IdColor);
            return View("Color");
            
        }
    }
    [HttpPost]
    public IActionResult GuardarColor(Color color, IFormFile File,string NombreColor,int IdColor, string NombreTela)
    {
        int IdTela = BD.GetNombreTela(NombreTela);
        color.IdTela=IdTela;
        color.FotoColor=color.NombreColor + ".jpg";
        if(File.Length>0)
        {
            string wwwRootLocal = this.Environment.ContentRootPath + @"\wwwroot\" + color.FotoColor;
            using (var stream = System.IO.File.Create(wwwRootLocal))
            {
                File.CopyToAsync(stream);
            }
        }
        BD.InsertColor(color);
        ViewBag.ListaColores = BD.GetColor(IdColor);
        return View("Color");
    }
    public IActionResult EliminarColor1(int IdColor,int IdTela, string Clave)
    {
        if(Clave=="Tpfinal")
        {
            BD.DeleteColorById(IdColor);
        
        
            ViewBag.ListaTelas = BD.GetTela(IdTela);
            ViewBag.DetalleTelas=BD.DetalleTela(IdTela);
            ViewBag.ListaColores = BD.GetColor(IdTela);
            ViewBag.DetalleColores=BD.DetalleColor(IdTela);
            return View("Color");
        }
        else
        {
            ViewBag.ListaColores = BD.GetColor(IdColor);
            return View("Color");
        }
    }*/

    /* [HttpPost]
    public int UpdateMas(int IdProducto, int CantidadDisponible)
    {
        ViewBag.actualizarMas=BD.UpdateProductoMas(IdProducto,CantidadDisponible);

    }*/

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

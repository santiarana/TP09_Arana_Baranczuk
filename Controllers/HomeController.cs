using System.Diagnostics;
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
    
    public IActionResult EliminarColor(int IdColor)
    {
        
        BD.DeleteColorById(IdColor);
        ViewBag.DetalleColores=BD.GetColor(IdColor);
        ViewBag.ListaProductos = BD.GetProductoColor(IdColor);       
        return View("Color");
    }

    public IActionResult VerDetalleProducto(int IdColor)
    {
        ViewBag.ListaProductos = BD.GetProductoColor(IdColor);
        return View("Productos");
    }
    public IActionResult AgregarProducto()
    {
        return View("AgregarProducto");
    }
    [HttpPost]
    public IActionResult GuardarProducto(Producto prod, IFormFile File, int IdColor)
    {
        prod.FotoProducto=prod.NombreProducto + ".jpg";
        if(File.Length>0)
        {
            string wwwRootLocal = this.Environment.ContentRootPath + @"\wwwroot\" + prod.FotoProducto;
            using (var stream = System.IO.File.Create(wwwRootLocal))
            {
                File.CopyToAsync(stream);
            }
        }
        BD.InsertProducto(prod);
        ViewBag.ListaProductos = BD.GetProductoColor(IdColor);
        return View("Productos");
    }
    public IActionResult EliminarProducto(int IdProducto)
    {
        
        BD.EliminarProducto(IdProducto);
        ViewBag.DetalleProducto = BD.DetalleProducto(IdProducto);
        return View("Productos");
    }
    public Producto VerDetalleProductoAjax(int IdProducto)
    {
        ViewBag.Producto = BD.VerInfoProductoAjax(IdProducto);
        return ViewBag.Producto;
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
}

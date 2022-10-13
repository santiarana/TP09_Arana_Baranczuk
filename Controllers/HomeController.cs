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
    
    public IActionResult VerDetalleTelas(int IdTela, int IdColor)
    {
        ViewBag.DetalleTelas=BD.DetalleTela(IdTela);
        ViewBag.ListaColores = BD.GetColor(IdColor);
        return View("Telas");
    }
    public IActionResult VerDetalleColores(int IdColor)
    {
        ViewBag.DetalleColores=BD.DetalleColor(IdColor);
        ViewBag.ListaProductos = BD.GetProducto(IdColor);
        return View("Color");
    }
    
    public IActionResult EliminarColor(int IdColor)
    {
        
        BD.DeleteColorById(IdColor);
        ViewBag.DetalleColores=BD.GetColor(IdColor);
        ViewBag.ListaProductos = BD.GetProducto(IdColor);       
        return View("Color");
    }

    public IActionResult VerDetalleProducto(int IdProducto)
    {
        ViewBag.DetalleProducto = BD.DetalleProducto(IdProducto);
        return View("Productos");
    }
    public IActionResult AgregarProducto(int IdProducto)
    {
        ViewBag.IdProducto = IdProducto;
        return View();
    }
    [HttpPost]
    public IActionResult GuardarProducto(Producto prod, IFormFile File, int IdProducto, int IdColor)
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
        ViewBag.DetalleProducto = BD.DetalleProducto(IdProducto);
        ViewBag.ListaProductos = BD.GetProducto(IdColor);
        return View("VerDetalleEquipo");
    }
    public IActionResult EliminarProducto(int IdProducto)
    {
        
        BD.EliminarProducto(IdProducto);
        ViewBag.DetalleProducto = BD.DetalleProducto(IdProducto);
        return View("Productos");
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

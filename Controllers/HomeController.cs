using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP09_Arana_Baranczuk.Models;

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
        ViewBag.ListaTelas = BD.ListaTela();
        return View();
    }
    
    public IActionResult VerDetalleTelas(int IdTela, int IdColor)
    {
        ViewBag.DetalleTelas=BD.getTela(IdTela);
        ViewBag.ListaColores = BD.ListaColor(IdColor);
        return View("Telas");
    }
    public IActionResult VerDetalleColores(int IdColor)
    {
        ViewBag.DetalleColores=BD.getColor(IdColor);
        ViewBag.ListaProductos = BD.ListaProducto(IdColor);
        return View("Color");
    }
    
    public IActionResult EliminarColor(int IdColor)
    {
        
        BD.EliminarColor(IdColor);
        ViewBag.DetalleColores=BD.getColor(IdColor);
        ViewBag.ListaProductos = BD.ListaProducto(IdColor);       
        return View("Color");
    }

    public IActionResult VerDetalleProducto(int IdProducto)
    {
        ViewBag.DetalleProducto = BD.getProducto(IdProducto);
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
        prod.FotoProducto=prod.Nombre + ".jpg";
        if(File.Length>0)
        {
            string wwwRootLocal = this.Environment.ContentRootPath + @"\wwwroot\" + prod.FotoProducto;
            using (var stream = System.IO.File.Create(wwwRootLocal))
            {
                File.CopyToAsync(stream);
            }
        }
        BD.AgregarProducto(prod);
        ViewBag.DetalleProducto = BD.getProducto(IdProducto);
        ViewBag.ListaProductos = BD.ListaProducto(IdColor);
        return View("VerDetalleEquipo");
    }
    public IActionResult EliminarProducto(int IdProducto)
    {
        
        BD.EliminarProducto(IdProducto);
        ViewBag.DetalleProducto = BD.getProducto(IdProducto);
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

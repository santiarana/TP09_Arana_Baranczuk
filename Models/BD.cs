using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using Dapper;
using System.Linq;
namespace TP09_Arana_Baranczuk.Models;
public static class BD
{
    private static string _connectionString = @"Server=A-phz2-cidi-042; Database=TPFinal;Trusted_Connection=True;";
    public static List<Tela> GetTela(int IdTela)
    {
        List<Tela> _ListaTela = new List<Tela>();
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            string sql = "SELECT * FROM Tela";
            _ListaTela = db.Query<Tela>(sql).ToList();
        }
        return _ListaTela;
    }
    public static List<Color> GetColor(int IdColor)
    {
        List<Color> _ListaColor = new List<Color>();
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            string sql = "SELECT * FROM Color";
            _ListaColor = db.Query<Color>(sql).ToList();
        }
        return _ListaColor;
    }
    public static List<Producto> GetProducto(int IdProducto)
    {
        List<Producto> _ListaProducto = new List<Producto>();
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            string sql = "SELECT * FROM Producto";
            _ListaProducto = db.Query<Producto>(sql).ToList();
        }
        return _ListaProducto;
    }
    public static void InsertProducto(Producto producto)
    {
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            string sql = "INSERT INTO Producto(NombreProducto, FotoProducto,IdTela,IdColor,FechaDeIngreso,CantidadDisponible,Peso) VALUES (@pNombreProducto,@pFotoProducto,@pIdTela,@pIdColor,@pFechaDeIngreso,@pCantidadDisponible,@pPeso)";
            db.Execute(sql, new { pNombre = producto.NombreProducto, pFotoProducto = producto.FotoProducto, pIdTela = producto.IdTela, pIdColor = producto.IdColor, pFechaDeIngreso = producto.FechaDeIngreso, pCantidadDisponible = producto.CantidadDisponible, pPeso = producto.Peso });
        }
    }
    public static int DeleteColorById(int idColor)
    {
        int Reg = 0;
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            string sql = "DELETE FROM Clientes WHERE IdColor = @pIdColor";
            Reg = db.Execute(sql, new { pIdColor = idColor });
        }
        return Reg;
    }
    public static int EliminarProducto(int idProducto)
    {
        int Reg = 0;
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            string sql = "DELETE FROM Producto WHERE IdProducto = @pIdProducto";
            Reg = db.Execute(sql, new { pIdProducto = idProducto });
        }
        return Reg;
    }
    public static Producto DetalleProducto(int IdProducto)
    {
        Producto prod;
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            string sql = "SELECT * FROM Producto where IdProducto = @pIdProducto";
            prod = db.QueryFirstOrDefault<Producto>(sql, new { pIdProducto = IdProducto });
        }
        return prod;
    }
    public static Tela DetalleTela(int IdTela)
    {
        Tela tel;
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            string sql = "SELECT * FROM Tela where IdTela = @pIdTela";
            tel = db.QueryFirstOrDefault<Tela>(sql, new { pIdTela = IdTela });
        }
        return tel;
    }
    public static Color DetalleColor(int IdColor)
    {
        Color col;
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            string sql = "SELECT * FROM Color where IdColor = @pIdColor";
            col = db.QueryFirstOrDefault<Color>(sql, new { pIdColor = IdColor });
        }
        return col;
    }
}
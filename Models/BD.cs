using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using Dapper;
using System.Linq;
namespace TP09_Arana_Baranczuk.Models;
public static class BD
{
    private static string _connectionString = @"Server=A-phz2-cidi-021; Database=TPFinal;Trusted_Connection=True;";
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
    public static List<Color> GetColor(int IdTela)
    {
        List<Color> _ListaColor = new List<Color>();
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            string sql = "SELECT * FROM Color WHERE IdTela = @pTela";
            _ListaColor = db.Query<Color>(sql, new{pTela = IdTela}).ToList();
        }
        return _ListaColor;
    }
    public static List<Producto> GetProductoColor(int IdColor)
    {
        List<Producto> _ListaProducto = new List<Producto>();
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            string sql = "SELECT * FROM Producto WHERE IdColor = @pIdColor";
            _ListaProducto = db.Query<Producto>(sql, new{pIdColor = IdColor}).ToList();
        }
        return _ListaProducto;
    }
    public static void InsertProducto(Producto producto)
    {
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            string sql = "INSERT INTO Producto(NombreProducto, FotoProducto,NombreTela,NombreColor,FechaDeIngreso,CantidadDisponible,Peso) VALUES (@pNombreProducto,@pFotoProducto,@pNombreTela,@pNombreColor,@pFechaDeIngreso,@pCantidadDisponible,@pPeso)";
            db.Execute(sql, new { pNombre = producto.NombreProducto, pFotoProducto = producto.FotoProducto, pNombreTela = producto.NombreTela, pNombreColor = producto.NombreColor, pFechaDeIngreso = producto.FechaDeIngreso, pCantidadDisponible = producto.CantidadDisponible, pPeso = producto.Peso });
        }
    }
    public static int DeleteColorById(int IdColor)
    {
        int Reg = 0;
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            string sql = "DELETE FROM Clientes WHERE IdColor = @pIdColor";
            Reg = db.Execute(sql, new { pIdColor = IdColor });
        }
        return Reg;
    }
    public static int EliminarProducto(int IdProducto)
    {
        int Reg = 0;
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            string sql = "DELETE FROM Producto WHERE IdProducto = @pIdProducto";
            Reg = db.Execute(sql, new { pIdProducto = IdProducto });
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

    public static Producto VerInfoProductoAjax(int IdProducto)
    {
        Producto product = null;
        using(SqlConnection db = new SqlConnection(_connectionString))
        {
            string sql = "SELECT * FROM Producto WHERE IdProducto = @pIdProducto";
            product = db.QueryFirstOrDefault<Producto>(sql,new{pIdProducto = IdProducto});
        }
        return product;
    }
    /*public static List<Usuario> GetUsuario()
    {
        List<Usuario> _ListaUsuario = new List<Usuario>();
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            
        }
    }*/
    
}
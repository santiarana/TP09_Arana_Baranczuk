using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using Dapper;
using System.Linq;
namespace TP09_Arana_Baranczuk.Models;
public static class BD
{
    private static string _connectionString = @"Server=a-phz2-cidi-019; Database=TPFinal;Trusted_Connection=True;";
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
    public static int GetNombreTela(string NombreTela)
    {
        int id;
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            string sql = "SELECT IdTela FROM Tela where NombreTela=@pNombreTela";
            id=db.QueryFirstOrDefault<int>(sql, new { pNombreTela = NombreTela});
        }
        return id;
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
    public static int GetNombreColor(string NombreColor)
    {
        int id;
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            string sql = "SELECT IdColor FROM Color where NombreColor=@pNombreColor";
            id=db.QueryFirstOrDefault<int>(sql, new { pNombreColor = NombreColor });
        }
        return id;
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
            string sql = "INSERT INTO Producto(NombreProducto,FotoProducto,IdTela,IdColor,FechaDeIngreso,CantidadDisponible,Peso) VALUES (@pNombreProducto,@pFotoProducto,@pIdTela,@pIdColor,@pFechaDeIngreso,@pCantidadDisponible,@pPeso)";
            db.Execute(sql, new { pNombreProducto = producto.NombreProducto, pFotoProducto = producto.FotoProducto, pIdTela = producto.IdTela, pIdColor = producto.IdColor, pFechaDeIngreso = producto.FechaDeIngreso, pCantidadDisponible = producto.CantidadDisponible, pPeso = producto.Peso});
        }
    }
    public static void InsertColor(Color color)
    {
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            string sql = "INSERT INTO Color(NombreColor,FotoColor,IdTela) VALUES (@pNombreColor,@pFotoColor,@pIdTela)";
            db.Execute(sql, new { pNombreColor = color.NombreColor, pFotoColor = color.FotoColor, pIdTela = color.IdTela});
        }
    }
    public static int DeleteColorById(int IdColor)
    {
        int Reg = 0;
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            string sql = "DELETE FROM Color WHERE IdColor = @pIdColor";
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
    public static int UpdateProducto(int IdProducto, int CantidadDisponible)
    {
        int NuevoIngreso = 0;
        using(SqlConnection db = new SqlConnection(_connectionString))
        {
            string sql = "UPDATE Producto SET CantidadDisponible = (CantidadDisponible + @pCantidadDisponible) WHERE IdProducto = @pIdProducto";
            NuevoIngreso = db.Execute(sql, new{pIdProducto = IdProducto, pCantidadDisponible = CantidadDisponible});
            return NuevoIngreso;
        }
    }
    
}
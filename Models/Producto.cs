using System; 
namespace TP09_ARANA_BARANCZUK.Models;

  public class Producto 
    {
        private  int _IdProducto;
        private  string _NombreProducto;
        private  string _FotoProducto;
        private int _IdTela;
        private int _IdColor;
        private DateTime _FechaDeIngreso;
        private int _CantidadDisponible;
        private float _Peso;
        private string _NombreTela;
        private string _Nombre; 
       
        
        public Producto(int IdProducto, string NombreProducto,string FotoProducto,int IdTela, int IdColor, DateTime FechaDeIngreso, int CantidadDisponible, float Peso,string NombreTela, string Nombre)
        {
            _IdProducto = IdProducto;
            _NombreProducto = NombreProducto;
            _FotoProducto = FotoProducto;
            _IdTela = IdTela;
            _IdColor = IdColor;
            _FechaDeIngreso = FechaDeIngreso;
            _CantidadDisponible = CantidadDisponible;
            _Peso = Peso; 
            _NombreTela = NombreTela;
            _Nombre = Nombre; 
         
        }
        public Producto()
        {

        }
        public int IdProducto
        {
            get{return _IdProducto;}
            set { _IdProducto = value; }

        } 
        public string NombreProducto
        {
            get{return _NombreProducto;}
            set { _NombreProducto = value; }

        } 
        public string FotoProducto
        {
            get{return _FotoProducto;}
            set { _FotoProducto = value; }

        } 
          public int IdTela
        {
            get{return _IdTela;}
            set { _IdTela = value; }

        } 

            public int IdColor
        {
            get{return _IdColor;}
            set { _IdColor = value; }

        } 
          public DateTime FechaDeIngreso
        {
            get{return _FechaDeIngreso;}
            set { _FechaDeIngreso = value; }

        } 

         public int CantidadDisponible
        {
            get{return _CantidadDisponible;}
            set { _CantidadDisponible = value; }

        } 
         public float Peso
        {
            get{return _Peso;}
            set { _Peso = value; }

        } 
        public string NombreTela
        {
            get{return _NombreTela;}
            set { _NombreTela = value; }

        } 
        public string Nombre
        {
            get{return _Nombre;}
            set { _Nombre = value; }

        } 
   
}
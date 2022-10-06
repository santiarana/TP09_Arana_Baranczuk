using System; 
namespace TP09_ARANA_BARANCZUK.Models;

  public class Color
    {
        private  int _IdColor;
        private  string _Nombre;
        private  string _FotoColor;
       
        
        public Color(int IdColor, string Nombre,string FotoColor)
        {
            _IdColor = IdColor;
            _Nombre = Nombre;
         _FotoColor = FotoColor;
        }
        public Color()
        {

        }
        public int IdColor
        {
            get{return _IdColor;}
            set { _IdColor = value; }

        } 
        public string Nombre
        {
            get{return _Nombre;}
            set { _Nombre = value; }

        } 
        public string FotoColor
        {
            get{return _FotoColor;}
            set { _FotoColor = value; }

        } 
   
}
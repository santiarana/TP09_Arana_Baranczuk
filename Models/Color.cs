using System;
namespace TP09_Arana_Baranczuk.Models;

  public class Color
    {
        private  int _IdColor;
        private  string _NombreColor;
        private  string _FotoColor;
        private int _IdTela;
       
        
        public Color(int IdColor, string NombreColor,string FotoColor,int IdTela)
        {
            _IdColor = IdColor;
            _NombreColor = NombreColor;
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
        public string NombreColor
        {
            get{return _NombreColor;}
            set { _NombreColor = value; }

        } 
        public string FotoColor
        {
            get{return _FotoColor;}
            set { _FotoColor = value; }

        } 
         public int IdTela
        {
            get{return _IdTela;}
            set { _IdTela = value; }

        } 
   
}

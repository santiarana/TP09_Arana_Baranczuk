using System; 
namespace TP09_Arana_Baranczuk.Models;

public class Tela
    {
        private  int _IdTela;
        private  string _NombreTela;
        private  string _FotoTela;
        private float _Precio;
       
        
        public Tela(int IdTela, string NombreTela,string FotoTela,float Precio)
        {
            _IdTela = IdTela;
            _NombreTela = NombreTela;
            _FotoTela= FotoTela;
            _Precio = Precio;
        }
        public Tela()
        {

        }
        public int IdTela
        {
            get{return _IdTela;}
            set { _IdTela = value; }

        } 
        public string NombreTela
        {
            get{return _NombreTela;}
            set { _NombreTela = value; }

        } 
        public string FotoTela
        {
            get{return _FotoTela;}
            set { _FotoTela = value; }

        } 
        public float Precio
        {
            get{return _Precio;}
            set { _Precio = value; }

        } 
    }

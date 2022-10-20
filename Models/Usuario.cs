using System; 
namespace TP09_Arana_Baranczuk.Models;
  public class Usuario
    {
        private  int _IdUsuario;
        private  string _Clave;
        public Usuario(int IdUsuario, string Clave)
        {
            _IdUsuario = IdUsuario;
            _Clave = Clave;
         
        }
        public Usuario()
        {

        }
        public int IdUsuario
        {
            get{return _IdUsuario;}
            set { _IdUsuario = value; }

        } 
        public string Clave
        {
            get{return _Clave;}
            set { _Clave = value; }

        } 
      
}


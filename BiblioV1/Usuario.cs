using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BiblioV1
{
    internal class Usuario
    {
        public string Nombre { get; set; }

        private int _dni;
        public int DNI
        {
            get { return _dni; } //Lectura
            set
            {
                if (value.ToString().Length >= 5 || value.ToString().Length < 8) // Validación digitos del dni.
                {
                    _dni = value; //Escritura
                }
                else
                {
                    throw new ArgumentException("Datos invalidos , revise los digitos ingresados."); //Escritura-Error
                }
            }
        }

        private IBibliotec BibliotecaX;


        //Constructor 

        public Usuario (string unNombre , int unDni , IBibliotec unaBiblioteca)
        {
            this.Nombre = unNombre;
            this.DNI = unDni;
            this.BibliotecaX = unaBiblioteca;
        }
        

        //Metodo para comprar un libro , como una propiedad es de tipo


        public void ComprarLibro (string tituloLibro , int cantidadComprar)
        {
            BibliotecaX.RealizarCompra(tituloLibro, cantidadComprar); // Accedemos al metodo de la biblioteca mediante Polimorfismo y inyeccion de dependencias.

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 Clase Libro:
Hereda de Publicacion.
Propiedades adicionales: ISBN, Genero.
Métodos:
MostrarDetalles(): Sobrescribe el método para incluir ISBN y género.

*/

namespace BiblioV1
{
    internal class Libro : Publicacion
    {
        public int ISBN { get; set; }  //Codigo para buscar y identidificar un libro.

        public string Genero { get; set; }


        //Constructor 
        public Libro(string unTitulo, string unAutor, int unStock, int unIsbn, string unGenero , bool estadoPrestacion , decimal unPrecio)
        {
            this.Titulo = unTitulo;
            this.Autor = unAutor;
            this.ActualizarStock(unStock); 
            this.ISBN = unIsbn;
            this.Genero = unGenero;
            this.EstaPrestada = estadoPrestacion;
            this.Precio = unPrecio;
        }


        //Metodos

        public override void MostrarDetalles ()
        {
            Console.WriteLine($"Titulo: {Titulo} , Autor: {Autor} , ISBN: {ISBN} , Genero: {Genero}");
        }
    }
}


  

    

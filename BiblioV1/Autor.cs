using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 Clase Autor:
Propiedades: Nombre, ListaDeLibros.
Métodos:
AgregarLibro(Libro libro): Agrega un libro a la lista de libros del autor.
MostrarLibros(): Muestra todos los libros escritos por el autor.
*/

namespace BiblioV1
{
    internal class Autor
    {
        public string Nombre { get; set; }

        List<Libro> ListaLibros = new List<Libro>();

        //Constructor

        public Autor (string unNombre)
        {
            this.Nombre = unNombre;
        }

        //Metodos


        //Metodo para agregar un libro a la lista.
        public void AgregarLibro (Libro libro)
        {
            if (ElLibro_NoestaEnLista(libro)) //Agregar al libro si este no se encuentra antes en la lista.
            {
                ListaLibros.Add(libro);

            } else
            {
                throw new ArgumentOutOfRangeException("Este libro ya esta en el listado");
            }
        }


        //Metodo booleano para evaluar si un libro esta en la lista de libros.
        public bool ElLibro_NoestaEnLista (Libro libro)
        {
            foreach (Libro unLibro in ListaLibros)
            {
                if (libro.ISBN == unLibro.ISBN)
                {
                    return false;
                }
            }

            return true;
        }


        //Metodo para mostrar los detalles de la lista de libros.


        public void MostrarDetalles ()
        {

            foreach (Libro item in ListaLibros)
            {
                Console.WriteLine(item.Titulo);
            }
        }
    }
}

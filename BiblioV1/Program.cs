using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 Objetivo
Desarrollar un sistema de gestión de biblioteca que permita manejar publicaciones (libros y revistas), autores, préstamos y
notificaciones en la consola.El sistema debe ser capaz de gestionar la información de manera eficiente y notificar al usuario
sobre las acciones realizadas.

Requisitos
Clases Principales:

Clase Abstracta Publicacion:

Propiedades: Titulo, Autor, Stock.
Métodos:
MostrarDetalles(): Muestra información de la publicación.
ActualizarStock(int cantidad): Actualiza el stock de la publicación.


Clase Libro:
Hereda de Publicacion.
Propiedades adicionales: ISBN, Genero.
Métodos:
MostrarDetalles(): Sobrescribe el método para incluir ISBN y género.


Clase Revista:
Hereda de Publicacion.
Propiedades adicionales: Numero, Frecuencia.
Métodos:
MostrarDetalles(): Sobrescribe el método para incluir número y frecuencia.

Clase Autor:
Propiedades: Nombre, ListaDeLibros.
Métodos:
AgregarLibro(Libro libro): Agrega un libro a la lista de libros del autor.
MostrarLibros(): Muestra todos los libros escritos por el autor.

Clase Biblioteca:
Propiedades: ListaDePublicaciones, ListaDeAutores.
Métodos:
AgregarPublicacion(Publicacion publicacion): Agrega una publicación a la biblioteca.
EliminarPublicacion(string titulo): Elimina una publicación por título.
BuscarPublicacion(string titulo): Busca y retorna una publicación por título.
ListarPublicaciones(): Muestra todas las publicaciones disponibles.
RealizarPrestamo(string titulo): Realiza el préstamo de un libro o revista, verificando disponibilidad.
DevolverPublicacion(string titulo): Permite devolver una publicación y actualizar el stock.

Sistema de Notificaciones:
Clase Notificacion que gestione la visualización de mensajes en la consola para informar al usuario sobre acciones realizadas (ej.
"Libro prestado con éxito", "Libro no disponible", etc.). Manejo de Excepciones:

Excepciones personalizadas:
LibroNoDisponibleException: Para manejar cuando un libro no está disponible.
AutorNoEncontradoException: Para manejar cuando se intenta acceder a un autor que no existe.


Simulación de Préstamos:
En el método Main, simular varias operaciones:
Agregar libros y revistas a la biblioteca.
Intentar prestar un libro que esté disponible.
Intentar prestar un libro que no esté disponible.
Devolver un libro y verificar el stock.
Mostrar los detalles de las publicaciones disponibles.
Ejemplo de Uso


Agregar Publicaciones:
Crear instancias de Libro y Revista y agregarlas a la biblioteca utilizando AgregarPublicacion().

Realizar Préstamos:
Simular el préstamo de un libro utilizando RealizarPrestamo() y manejar posibles excepciones.

Devolver Publicaciones:
Simular la devolución de un libro utilizando DevolverPublicacion().
Mostrar Detalles:

Mostrar en consola los detalles de las publicaciones y autores utilizando ListarPublicaciones() y MostrarLibros().
Gestionar Autores:

Agregar autores y asociar libros a ellos utilizando AgregarLibro() en la clase Autor.
*/

namespace BiblioV1
{
    internal class Program
    {
        static void Main(string[] args)
        {
                                         //Libro ----> Titulo , NombreAutor , stock , ISBM , Estilo , estadoPrestacion , Precio.}
             //Instansia de Libros
            Libro CienAñosdeSoledad = new Libro("Cien años de soledad", "Gabriel García Márquez", 44, 661, "Novela" , true ,400m);
            Libro ElAmorEnLosTiemposDelColera = new Libro("El amor en los tiempos del cólera", "Gabriel García Márquez", 50, 432, "Romance" , true , 500m);
            Libro LasVenasAbiertasDeAmericaLatina = new Libro("Las venas abiertas de América Latina", "Eduardo Galeano", 30, 360, "Historia", true , 300m);
            Libro Rayuela = new Libro("Rayuela", "Julio Cortázar", 38, 500, "Ficción" , true, 1500.200m);
            Libro DonQuijoteDeLaMancha = new Libro("Don Quijote de la Mancha", "Miguel de Cervantes", 60, 863, "Clásico", true , 10000.500m);

            //Autor
            Autor AutorEduardoGaleano = new Autor("Eduardo Galeano");
            AutorEduardoGaleano.AgregarLibro(LasVenasAbiertasDeAmericaLatina);

            Autor GabrielGarcia = new Autor("Gabriel Garcia Marquez");
            GabrielGarcia.AgregarLibro(CienAñosdeSoledad);

            Autor JulioCortazar = new Autor("Julio Cortazar");
            JulioCortazar.AgregarLibro(Rayuela);


            Autor MiguelCervantes = new Autor("Miguel de Cervantes");
            MiguelCervantes.AgregarLibro(DonQuijoteDeLaMancha);

            //Biblioteca
            Biblioteca biblioteca = new Biblioteca();

            biblioteca.AgregarPublicacion(CienAñosdeSoledad);
            biblioteca.AgregarPublicacion(ElAmorEnLosTiemposDelColera);
            biblioteca.AgregarPublicacion(LasVenasAbiertasDeAmericaLatina);
            biblioteca.AgregarPublicacion(Rayuela);
            biblioteca.AgregarPublicacion(DonQuijoteDeLaMancha);

            //Usuario

            Usuario David = new Usuario("David" , 52096266 , biblioteca);

            David.ComprarLibro("El amor en los tiempos del cólera", 10);
        }
    }
}

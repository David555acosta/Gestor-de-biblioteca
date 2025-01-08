using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 Clase Biblioteca:
Propiedades: ListaDePublicaciones, ListaDeAutores.
Métodos:
AgregarPublicacion(Publicacion publicacion): Agrega una publicación a la biblioteca.
EliminarPublicacion(string titulo): Elimina una publicación por título.
BuscarPublicacion(string titulo): Busca y retorna una publicación por título.
ListarPublicaciones(): Muestra todas las publicaciones disponibles.
RealizarPrestamo(string titulo): Realiza el préstamo de un libro o revista, verificando disponibilidad.
DevolverPublicacion(string titulo): Permite devolver una publicación y actualizar el stock.
ComprarPublicacion(string titulo, int cantidad): Permite comprar publicaciones, actualizando stock y calculando impuestos.
VenderPublicacion(string titulo, int cantidad): Permite vender publicaciones, actualizando stock y calculando impuestos.
*/

namespace BiblioV1
{
    internal class Biblioteca : IBibliotec
    {
        List<Publicacion> Publicaciones = new List<Publicacion>();

        List<Autor> Autores = new List<Autor>();


        //Metodos para la lista Publicaciones.


        //Metodo para agregar publicacion.
        public void AgregarPublicacion(Publicacion publicacion)
        {
            if (LaPublicacion_EstaEnLista(publicacion))
            {
                Publicaciones.Add(publicacion);

            }
            else
            {
                throw new ArgumentOutOfRangeException("Esta publicacion ya se encuentra en la biblioteca");
            }
        }


        //Metodo Booleano que evalua si una Publicacion esta en la lista.


        public bool LaPublicacion_EstaEnLista(Publicacion publicacion)
        {
            foreach (Publicacion item in Publicaciones)
            {
                if (item.Titulo == publicacion.Titulo)
                {
                    return false;
                }
            }

            return true; //La logica es que si no esta es Verdadero , por ende se podria agregar un libro cuando
                         //no este en lista.
        }


        //Metodo para eliminar publicacion

        public void EliminarPublicacion(Publicacion publicacion)
        {
            if (!LaPublicacion_EstaEnLista(publicacion))
            {
                Publicaciones.Remove(publicacion);

            } else
            {
                throw new ArgumentOutOfRangeException("No se puede eliminar una publicacion que no esta en la lista");
            }
        }


        //Metodo para buscar una Publicacion en la lista de publicaciones.

        public string BuscarPublicacion(string publicacion)
        {
            foreach (Publicacion item in Publicaciones)
            {
                if (item.Titulo.Equals(publicacion, StringComparison.OrdinalIgnoreCase))
                {
                    return item.Titulo;
                }
            }

            return "Esta publicacion no esta en lista";
        }


        //Metodo para mostrar las publicaciones de la lista.


        public void ListarPublicaciones()
        {
            foreach (var item in Publicaciones)
            {
                Console.WriteLine(item.Titulo);
            }
        }


        //Metodo para realizar Prestamo

        public void RealizarPrestamo(string unTitulo)
        {
            // Verifica si el título está en la lista y tiene stock
            if (HayStockYEstaEnListaElTitulo_(unTitulo))
            {
                // Encuentra la publicación correspondiente - se realiza este procedimiento para encontrar un titulo y acceder a sus campos mediante el string.
                Publicacion publicacion = Publicaciones.FirstOrDefault(item =>
                    item.Titulo.Equals(unTitulo, StringComparison.OrdinalIgnoreCase));


                if (publicacion != null && publicacion.EstaPrestada) //Evaluar que exista la publicacion.
                    //Existe la publicacion y NO esta prestada
                {
                    // Reduce el stock
                        publicacion.Stock--;
                        publicacion.EstaPrestada = true;
                        Console.WriteLine($"Préstamo realizado de: {unTitulo}. Stock restante: {publicacion.Stock}");
                }
            }

            else //No existe publicacion o no hay stock
            {
                Console.WriteLine($"No se puede realizar el préstamo de: {unTitulo}. Título no disponible o sin stock.");
            }
        }


        //Metodo para evaluar si un titulo esta en lista y tiene stock


        public bool HayStockYEstaEnListaElTitulo_(string tituloX)
        {
            if (ElTitulo_EstaEnLlista(tituloX) && HayStockDelTitulo_(tituloX))
            {
                return true;
            }

            return false;   
        }


        //Metodo para evaluar mediante un string si la este titulo esta en la lista.
        public bool ElTitulo_EstaEnLlista (string unTitulo)
        {
            foreach (Publicacion item in Publicaciones)
            {
                //Funcionlaidad para evaluar si un titulo
                //Esta en la lista sin tener en cuenta las mayusculas y minusculas.

                if (item.Titulo.Equals(unTitulo ,StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
                   
            }

            return false;
        }


        //Metodo para evaluar mediante un string si este titulo tiene stock disponible.


        public bool HayStockDelTitulo_(string unTitulo)
        {
            foreach(Publicacion item in Publicaciones)
            {
                if (item.Titulo.Equals(unTitulo , StringComparison.OrdinalIgnoreCase))
                {
                    return item.Stock > 0;
                }
            }

            return false;  
        }



        //Metodo para devolver la publicacion


        public void DevolverPublicacion (string unTitulo)
        {
            // Encuentra la publicación correspondiente
            Publicacion publicacion = Publicaciones.FirstOrDefault(item =>
            item.Titulo.Equals(unTitulo, StringComparison.OrdinalIgnoreCase));



            if (publicacion != null && publicacion.EstaPrestada)
            {
                publicacion.Stock++; // Aumenta el stock
                publicacion.EstaPrestada = false; // Marca como no prestada
                Console.WriteLine($"Publicación '{unTitulo}' devuelta. Stock actual: {publicacion.Stock}");
            }
            else
            {
                Console.WriteLine($"No se puede devolver '{unTitulo}'.Ya esta devuelva o no existe");
            }
        }


        //Metodos para la lista autor


        //Agregar a lista de autores.

        public void AgregarAutorALista (Autor autor)
        {
            if (ElAutor_EstaEnLista(autor)) //Si el autor No esta en la lista == True , se lo agrega a la misma.
            {
                Autores.Add(autor);
            }
        }



        //Metodo para evaluar si un autor esta en la lista de autores


        public bool ElAutor_EstaEnLista (Autor autorX)
        {
            foreach (Autor item in Autores)
            {
                if (item.Nombre == autorX.Nombre)
                {
                    return false;
                }
            }

            return true; //Logica: Da verdadero cuando no se encuentra en la lista
        }



        //Metodo para eliminar un autor de la lista de autores


        public void EliminarAutor_SiEstaEnLista(Autor autor)
        {
            //Invertimos la logica , en el metodo original si se lo encuentra da False.
            //Para este caso debemos invertir el metodo , cuando nos de false en el metodo
            //Dara true y asi podremos eliminar un autor.

            if (!ElAutor_EstaEnLista(autor)) 
            {
                Autores.Remove(autor);
            }
        }


        //Metodo para mostrar los autores de la lista de autores.


        public void  ListadoDetalladoDeAutores ()
        {
            foreach (Autor item in Autores)
            {
                Console.WriteLine(item.Nombre);
            }
        }

        //Metodo de interfaz para que realize una compra un USUARIO en base a los contenidos de la biblioteca.
        public void RealizarCompra(string unTitulo, int unaCantidad)
        {

            // Encuentra la publicación correspondiente
            Publicacion publicacion = Publicaciones.FirstOrDefault(item =>
            item.Titulo.Equals(unTitulo, StringComparison.OrdinalIgnoreCase));
            

            if (EsPosibleRealizarCompra(unTitulo, unaCantidad))
            {
                publicacion.Stock -= unaCantidad;

                decimal totalCompra = TotalCompra(unaCantidad, publicacion.Precio);

                Console.WriteLine($"stock disponible : {publicacion.Stock} , total con descuentos : {totalCompra}");

            } else
            {
                throw new ArgumentOutOfRangeException("No se puede realizar esta compra , no hay stock o la cantidad supera el stock");
            }
        }


        //Metodo para evaluar si es posible realizar la compra.
        //(El titulo tiene que estar en la lista) y (el el stock del titulo tiene que ser menor o igual a la cantidad a comprar).
        public bool EsPosibleRealizarCompra(string unTitulo, int unaCantidad)
        {
            if (ElTitulo_EstaEnLlista(unTitulo) && ElTitulo_TieneUnStockAptoParaCompraDe_(unTitulo , unaCantidad))
            {
                return true;
            }

            return false;
        }


        //Metodo para evaluar si el stock del titulo a realizar la compra es menor o igual a la cantidad de compra.

        public bool ElTitulo_TieneUnStockAptoParaCompraDe_ (string unTituloX, int unaCantidadX)

        {

            foreach (Publicacion item in Publicaciones)
            {
                if (item.Titulo.Equals(unTituloX, StringComparison.OrdinalIgnoreCase))
                {
                    return item.Stock >= unaCantidadX;
                }
            }

            return false;
        }


        //Metodo agregado para mostrar el monto total y el descuento.

        public decimal TotalCompra(int cantidadEvaluar , decimal unPrecioEvaluar)
        {
            decimal descuento = 0m;

            decimal total;

            if (cantidadEvaluar > 0 && cantidadEvaluar <= 10)
            {
                descuento = 0.1m; 


            } else if (cantidadEvaluar > 10 && cantidadEvaluar <= 20)

            {
                descuento = 0.2m;

            } else if (cantidadEvaluar > 20)
            {
                descuento = 0.3m;

            } else
            {
                descuento = 0.5m;
            }

            decimal precioFinal = unPrecioEvaluar - descuento;

            total = cantidadEvaluar * precioFinal;

            return total;
        }
    }
}


//Precio inicial

///Cantidad 

// Cantidad * (precioFinal) = precioInicial + recargo


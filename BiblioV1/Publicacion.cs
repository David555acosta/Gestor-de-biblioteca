using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 Clase Abstracta Publicacion:

Propiedades: Titulo, Autor, Stock.
Métodos:
MostrarDetalles(): Muestra información de la publicación.
ActualizarStock(int cantidad): Actualiza el stock de la publicación.
*/

namespace BiblioV1
{
    internal class Publicacion : IBibliotec
    {
        public string Titutlo { get; set; }

        public string Autor {  get; set; }


        //Como la propiedad es privada accedemos a ella mediante Stock , cargando los datos de la misma en _Stock
        private int _stock;
        public int Stock
        {
            get { return _stock; } //Lectura
            set
            {
                if (value >= 0) // Validación: por ejemplo, que la duración no sea negativa.
                    //Mayor o igual a 0 para que al quedar 1 stock este pueda ser comprado
                {
                    _stock = value; //Escritura
                }
                else
                {
                    throw new ArgumentException("Stock no puede ser negativo"); //Escritura-Error
                }
            }
        }


        public bool EstaPrestada { get; set; } // Bandera para indicar si está prestada


        public decimal Precio { get; set; }

        //Metodos.


        //Metodo para mostrar los detalles de la publicacion.
        public virtual void MostrarDetalles ()
        {
            
        }

        //Metodo para actualizar el stock

        public void ActualizarStock (int UnaCantidad)
        {
            Stock = UnaCantidad;    
        }




        public void RealizarCompra(string unTitulo, int unaCantidad)
        {
            throw new NotImplementedException();
        }

        public bool EsPosibleRealizarCompra(string unTitulo, int unaCantidad)
        {
            throw new NotImplementedException();
        }

        public decimal TotalCompra(int unaCantidad, decimal unPrecio)
        {
            throw new NotImplementedException();
        }
    }
}

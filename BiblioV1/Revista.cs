using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 Clase Revista:
Hereda de Publicacion.
Propiedades adicionales: Numero, Frecuencia.
Métodos:
MostrarDetalles(): Sobrescribe el método para incluir número y frecuencia.
*/

namespace BiblioV1
{
    internal class Revista: Publicacion
    {
        public int Numero {  get; set; }

        public string Frecuencia { get; set; }


        //Constructor


        public Revista(string unTitulo, string unAutor, int unStock, int unNumero, string unaFrecuencia , bool estadoPrestacion , decimal unPrecio)
        {
            this.Titutlo = unTitulo;
            this.Autor = unAutor;
            this.ActualizarStock(unStock);
            this.Numero= unNumero;
            this.Frecuencia = unaFrecuencia;
            this.EstaPrestada = estadoPrestacion;
            this.Precio = unPrecio;
        }

        //Metodos

        public override void MostrarDetalles()
        {
            Console.WriteLine($"Titulo: {Titutlo} , Autor: {Autor} , Numero: {Numero} , Frecuencia: {Frecuencia}");
        }
    }
}

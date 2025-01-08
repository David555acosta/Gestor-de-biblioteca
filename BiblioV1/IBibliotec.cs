using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioV1
{
    internal interface IBibliotec
    {
        void RealizarCompra(string unTitulo, int unaCantidad);

        bool EsPosibleRealizarCompra(string unTitulo, int unaCantidad);

        decimal TotalCompra(int unaCantidad , decimal unPrecio);
    }
}

using EjercicioExepcionesPersonalizadas.brl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioExepcionesPersonalizadas.dal
{
    public class DALDemo
    {
        public void dalAlta()
        {
            throw new CustomDALException("Error en la capa de datos");
        }
    }
}

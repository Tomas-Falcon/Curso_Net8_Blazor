using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioExepcionesPersonalizadas.dal
{
    [Serializable]
    public class CustomDALException : Exception
    {
        public CustomDALException(string message) : base(message)
        {
        }

    }
}

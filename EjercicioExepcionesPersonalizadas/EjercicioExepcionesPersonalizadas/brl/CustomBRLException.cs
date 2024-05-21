using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioExepcionesPersonalizadas.brl
{
    [Serializable]
    public class CustomBRLException: Exception
    {
        public CustomBRLException(string message) : base(message) 
        {
        }
    }
}

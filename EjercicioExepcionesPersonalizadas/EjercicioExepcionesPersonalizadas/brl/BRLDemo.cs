using EjercicioExepcionesPersonalizadas.dal;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioExepcionesPersonalizadas.brl
{

    public class BRLDemo
    {
        
        public void brlAlta()
        {
            
            DALDemo dalObj = new DALDemo();
            try
            {
                dalObj.dalAlta();
            }
            catch (CustomDALException ex)
            {
                Log.Error("Error en la capa de negocio desde la dal, serilog");
                throw new CustomBRLException("Error en la capa de negocio desde la dal");
            }
            catch (Exception ex)
            {
                throw new CustomBRLException("Error en la capa de negocio");
            }
        }
    }
}


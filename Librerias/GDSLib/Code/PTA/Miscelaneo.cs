using CustomLog;
using EntidadesGDS.Base;
using GDSLib.Base;
using GDSLib.Utiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDSLib.Code.PTA
{
    public sealed class Miscelaneo : Common
    {
        // =============================
        // constructores y destructores

        #region "constructores y destructores"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="codigoSeguimiento"></param>
        /// <param name="codigoEntorno"></param>
        /// <returns></returns>
        public Miscelaneo(string codigoSeguimiento,
                                    string codigoEntorno)
            : base(codigoSeguimiento, codigoEntorno)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="codigoSeguimiento"></param>
        /// <returns></returns>
        public Miscelaneo(string codigoSeguimiento)
            : base(codigoSeguimiento)
        {
        }

        ~Miscelaneo()
        {
            Dispose(false);
        }

        #endregion

        // =============================
        // metodos

        public CE_Estatus MostrarMensajeEnMantenimiento(out bool resultado)
        {
            var lrespuesta = new CE_Estatus(true);
            resultado = false;
            try
            {
                resultado = Configuracion.AppEnMantenimiento;
                if (resultado)
                {
                    var lmessage = Configuracion.GetMessageApp(CodigoEntorno.Split('/')[2]);
                    lrespuesta.Registrar(lmessage);
                }
            }
            catch (Exception ex)
            {
                Bitacora.Current.ErrorAndInfo(ex, CodigoSeguimiento);
                lrespuesta = new CE_Estatus(ex);
            }
            return lrespuesta;
        }

        public CE_Estatus GetCredencialesSIT(out string resultado)
        {
            var lrespuesta = new CE_Estatus(true);
            resultado = string.Empty;
            try
            {
                resultado = Configuracion.SitCredentials;

                if (!string.IsNullOrEmpty(resultado)) 
                {
                    var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(resultado);
                    resultado = System.Convert.ToBase64String(plainTextBytes);
                }

            }
            catch (Exception ex)
            {
                Bitacora.Current.ErrorAndInfo(ex, CodigoSeguimiento);
                lrespuesta = new CE_Estatus(ex);
            }
            return lrespuesta;
        }
    }
}

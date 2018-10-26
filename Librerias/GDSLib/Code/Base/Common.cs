using System;

using OracleLib;
using CustomLog;

using EntidadesGDS;
using EntidadesGDS.Base;

using GDSLib.Utiles;

namespace GDSLib.Base
{
    public class Common : IDisposable
    {
        // =============================
        // variables

        #region "variables"

        private bool _laConexionEsPropia;
        private bool _disposing;

        #endregion

        // =============================
        // constructores y destructores

        #region "constructores y destructores"

        //private Common()
        public Common()
        {
            _laConexionEsPropia = false;
            Aplicacion = null;
            CodigoSeguimiento = null;
            CodigoEntorno = null;
            Esquema = null;
            Conexion = null;
            Sesion = null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="aplicacion"></param>
        /// <param name="codigoSeguimiento"></param>
        /// <param name="codigoEntorno"></param>
        /// <param name="sesion"></param>
        /// <returns></returns>
        protected Common(EnumAplicaciones? aplicacion, 
                         string codigoSeguimiento,
                         string codigoEntorno,
                         CE_Session sesion)
            : this()
        {
            Aplicacion = aplicacion;
            CodigoSeguimiento = codigoSeguimiento;
            CodigoEntorno = codigoEntorno;
            Sesion = sesion;

            // registrando evento
            Bitacora.Current.Debug("Parametros recibidos", new { Aplicacion, CodigoEntorno, Sesion }, CodigoSeguimiento);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="aplicacion"></param>
        /// <param name="codigoSeguimiento"></param>
        /// <param name="conexion"></param>
        /// <param name="esquema"></param>
        /// <param name="sesion"></param>
        /// <returns></returns>
        protected Common(EnumAplicaciones? aplicacion,
                         string codigoSeguimiento,
                         Conexion conexion,
                         string esquema,
                         CE_Session sesion)
            : this()
        {
            Aplicacion = aplicacion;
            CodigoSeguimiento = codigoSeguimiento;
            Conexion = conexion;
            Esquema = esquema;
            Sesion = sesion;

            // registrando evento
            Bitacora.Current.Debug("Parametros recibidos", new { Aplicacion, esquema, Sesion }, CodigoSeguimiento);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="aplicacion"></param>
        /// <param name="codigoSeguimiento"></param>
        /// <param name="sesion"></param>
        /// <returns></returns>
        protected Common(EnumAplicaciones aplicacion,
                         string codigoSeguimiento,
                         CE_Session sesion)
            : this()
        {
            Aplicacion = aplicacion;
            CodigoSeguimiento = codigoSeguimiento;
            Sesion = sesion;

            // registrando evento
            Bitacora.Current.Debug("Parametros recibidos", new { Aplicacion, Sesion }, CodigoSeguimiento);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="codigoSeguimiento"></param>
        /// <param name="codigoEntorno"></param>
        /// <returns></returns>
        protected Common(string codigoSeguimiento,
                         string codigoEntorno)
            : this()
        {
            CodigoSeguimiento = codigoSeguimiento;
            CodigoEntorno = codigoEntorno;

            // registrando evento
            Bitacora.Current.Debug("Parametros recibidos", new { CodigoEntorno }, CodigoSeguimiento);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="codigoSeguimiento"></param>
        /// <param name="conexion"></param>
        /// <param name="esquema"></param>
        /// <returns></returns>
        protected Common(string codigoSeguimiento,
                         Conexion conexion,
                         string esquema)
            : this()
        {
            CodigoSeguimiento = codigoSeguimiento;
            Conexion = conexion;
            Esquema = esquema;

            // registrando evento
            Bitacora.Current.Debug("Parametros recibidos", new { esquema }, CodigoSeguimiento);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="codigoSeguimiento"></param>
        /// <returns></returns>
        protected Common(string codigoSeguimiento)
            : this()
        {
            CodigoSeguimiento = codigoSeguimiento;

            // registrando evento
            Bitacora.Current.Debug("Parametros recibidos", CodigoSeguimiento);
        }

        ~Common()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Dispose(bool disposing)
        {
            if (!_disposing)
            {
                if (disposing)
                {
                    // evaluando si la conexión es propia por lo cual debe de cerrarse
                    if (_laConexionEsPropia && (Conexion != null))
                    {
                        Conexion.Dispose();
                    }

                    _laConexionEsPropia = false;
                    Aplicacion = null;
                    CodigoSeguimiento = null;
                    CodigoEntorno = null;
                    Esquema = null;
                    Conexion = null;
                    Sesion = null;
                }
            }

            _disposing = true;
        }

        #endregion

        // =============================
        // auto propiedades

        #region "auto propiedades"

        protected EnumAplicaciones? Aplicacion { private set; get; }
        protected string CodigoEntorno { private set; get; }
        public string Esquema { set; get; }
        public string CodigoSeguimiento { private set; get; }
        public Conexion Conexion { set; get; }
        public CE_Session Sesion { set; get; }

        #endregion

        // =============================
        // metodos

        #region "metodos"

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public void Prepare()
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(CodigoEntorno))
                {
                    // obteniendo esquema de trabajo
                    Esquema = Configuracion.GetSchema(CodigoEntorno);

                    // obteniendo candea de conexión
                    var lcadenaConexion = Configuracion.GetConnectionString(CodigoEntorno);

                    // creando instancia de conexión a base de datos
                    Conexion = new Conexion(lcadenaConexion);

                    // evaluando si la conexión esta abierta 
                    if (!Conexion.Abierta)
                    {
                        // forzando excepción
                        throw new Exception("No se pudo abrir la conexión a Base de Datos");
                    }

                    // marcando que la conexión es propia por lo cual debe de cerrarse en eel destructor de la clase
                    _laConexionEsPropia = true;
                }

            }
            catch (Exception ex)
            {
                Dispose();

                // registrando evento
                Bitacora.Current.Error(ex, new { CodigoEntorno, Esquema, Sesion }, CodigoSeguimiento);

                throw;
            }
        }

        #endregion
    }
}

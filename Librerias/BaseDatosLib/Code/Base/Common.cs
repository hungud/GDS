using System;
using System.Collections.Generic;
using System.Data;

using Oracle.DataAccess.Client;

using OracleLib;
using CoreDaoLib;

namespace BaseDatosLib.Base
{
    public class Common : IDisposable
    {
        // =============================
        // variables

        #region "variables"

        private bool _disposing;

        #endregion

        // =============================
        // constructores y destructores

        #region "constructores y destructores"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="codigoSeguimiento"></param>
        /// <param name="conexion"></param>
        /// <param name="esquema"></param>
        /// <param name="nombrePaquete"></param>
        /// <returns></returns>
        protected Common(string codigoSeguimiento,
                         Conexion conexion, 
                         string esquema,
                         string nombrePaquete)
        {
            CodigoSeguimiento = codigoSeguimiento;
            Conexion = conexion;
            Esquema = esquema;
            NombrePaquete = nombrePaquete;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="codigoSeguimiento"></param>
        /// <param name="nombrePaquete"></param>
        /// <returns></returns>
        protected Common(string codigoSeguimiento,
                         string nombrePaquete)
        {
            CodigoSeguimiento = codigoSeguimiento;
            NombrePaquete = nombrePaquete;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="codigoSeguimiento"></param>
        /// <returns></returns>
        protected Common(string codigoSeguimiento)
            : this(codigoSeguimiento, null)
        {
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
                    CodigoSeguimiento = null;
                    Conexion = null;
                    Esquema = null;
                    NombrePaquete = null;
                }
            }

            _disposing = true;
        }

        #endregion

        // =============================
        // auto propiedades

        #region "auto propiedades"

        protected string CodigoSeguimiento { private set; get; }
        protected Conexion Conexion { private set; get; }
        protected string Esquema { private set; get; }
        protected string NombrePaquete { private set; get; }

        #endregion

        // =============================
        // metodos

        #region "metodos"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="moveFirst"></param>
        /// <returns></returns>
        protected OracleDataReader CastToOracleReader(IDataReader reader,
                                                      bool moveFirst)
        {
            OracleDataReader lreader = null;

            if (reader != null)
            {
                // comprobando si hay registros
                if (((OracleDataReader) reader).HasRows)
                {
                    lreader = ((OracleDataReader) reader);

                    // comprobando si moverse al primer registro
                    if (moveFirst)
                    {
                        // moviendose al primer registro
                        lreader.Read();
                    }
                }
            }

            return lreader;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        protected T ToNew<T>(IDataReader reader)
            where T : class
        {
            var lresultado = default(T);

            // casteando y evaluando el cursor
            var lreader = CastToOracleReader(reader, true);

            if (lreader != null)
            {
                // mapeando registro
                lresultado = Data.ToNew<T>(lreader);

                // cerrando cursor
                lreader.Close();
            }

            return lresultado;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        protected List<T> ToList<T>(IDataReader reader)
            where T : class
        {
            var lresultado = default(List<T>);

            // casteando y evaluando el cursor
            var lreader = CastToOracleReader(reader, false);

            if (lreader != null)
            {
                // mapeando registros
                lresultado = Data.ToList<T>(lreader);

                // cerrando cursor
                lreader.Close();
            }

            return lresultado;
        }

        #endregion
    }
}

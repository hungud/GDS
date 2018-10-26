// <copyright file="SessionWSModel.cs" company="Amadeus IT Group Colombia">   
// Copyright (c) 2018 All Right Reserved   
// </copyright>   
// <author>Amadeus - Diego Buitrago</author> 

namespace AmadeusLATAM.B2BWallet.Amadeus.Model
{
    using AmadeusLATAM.B2BWallet.Amadeus.Enum;
    using System.Collections.Generic;
    using System.Xml.Linq;

    /// <summary>
    /// Apoyo en datos y funcionalidad de limpieza para el manejo de sesiones a nivel de Amadeus WebServices y OTA.
    /// </summary>
    public sealed class SessionWSModel
    {
        #region "Public Properties"

        /// <summary>
        /// Servicio de Amadeus que ha sido invocado.
        /// </summary>
        public string AmadeusService { get; set; }

        /// <summary>
        /// Descriptivo de la plantilla de transformación requerida.
        /// </summary>
        public string XSLTemplate { get; set; }

        /// <summary>
        /// Diccionario con parametros que se quieran enviar a una plantilla de Transformación (Opcional).
        /// </summary>
        public Dictionary<string, string> XsltParameter { get; set; }

        /// <summary>
        /// Ambiente que se desea trabajar en la petición hacia Amadeus Web Services.
        /// </summary>
        public TargetEnum Target { get; set; }

        /// <summary>
        /// Dirección del EndPoint donde se debe ejecutar la transacción.
        /// </summary>
        public string EndPoint { get; set; }

        /// <summary>
        /// Estado de la transacción para manejo del Header 4.0.
        /// </summary>
        public TransactionStatusCodeEnum TransactionStatusCode { get; set; }

        /// <summary>
        /// Estructura XML con la petición entrante al servicio B2BWallet.
        /// </summary>
        public XDocument XmlRequestInitial { get; set; }

        /// <summary>
        /// Estructura XML con la petición entrante a WS.
        /// </summary>
        public XDocument XmlRequest { get; set; }

        /// <summary>
        /// structura XML con la petición saliente de WS.
        /// </summary>
        public XDocument XmlResponse { get; set; }

        /// <summary>
        /// Respuesta verdadera o falsa de acuerdo a la respuesta de la transacción realizada a Amadeus.
        /// </summary>
        public bool Successful { get; set; }

        /// <summary>
        /// Identificativo generado por Amadeus para continuar el flujo de tipo statefull. (Permite ademas buscar logs de transacciones a traves de ALF).
        /// </summary>
        public string SessionId { get; set; }

        /// <summary>
        /// Identificador incremental de la transacción que da un estado del orden de la ejecución de los servicios.
        /// </summary>
        public int SequenceNumber { get; set; }

        /// <summary>
        /// Identificador generado por Amadeus para continar el flujo de tipo stateful.
        /// </summary>
        public string SecurityToken { get; set; }
        
        /// <summary>
        /// OfficeId con el cual se va a manejar las peticiones de Amadeus.
        /// </summary>
        public string OfficeID { get; set; }
        
        /// <summary>
        /// UserId con el cual se va a manejar las peticiones de Amadeus.
        /// </summary>
        public string UserID { get; set; }

        /// <summary>
        /// BinaryData con el cual se va a manejar las peticiones de Amadeus.
        /// </summary>
        public string BinaryData { get; set; }

        /// <summary>
        /// WSAP con el cual se va a manejar las peticiones de Amadeus.
        /// </summary>
        public string WSAP { get; set; }

        /// <summary>
        /// Permite a partir de esta llave, saber si se debe obtener sesion devuelta por Amadeus, para el caso de flujos StateFul.
        /// </summary>
        public bool GetSessionData { get; set; }

        /// <summary>
        /// Permite guardar el log de transacciones para la operación
        /// </summary>
        public bool SaveTransactionLog { get; set; }

        /// <summary>
        /// Permite almacenar los posibles errores generados en una petición de 1AWS.
        /// </summary>
        public List<string> ListErrors { get; set; }

        public TypePasswordEncryptionEnum TypePasswordEncryption { get; set; }
   
        #endregion "Public Properties"

        #region "Public Methods"

        /// <summary>
        /// Permite limpiar datos de peticiones de respuesta, para liberar y reultilizar la entidad un poco mas ligera.
        /// </summary>
        public void CleanResponse()
        {
            this.XmlResponse = null;
        }

        #endregion "Public Methods"
    }
}

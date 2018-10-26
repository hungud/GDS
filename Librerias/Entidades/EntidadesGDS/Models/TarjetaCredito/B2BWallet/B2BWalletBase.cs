using System;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace EntidadesGDS.TarjetaCredito.B2BWallet
{
    // =============================
    // clases

    #region "clases"

    public class ValidityPeriodBase
    {
        // =============================
        // auto propiedades

        #region "auto propiedades"

        [XmlAttribute]
        public string StartDate { set; get; }
        [XmlAttribute]
        public string EndDate { set; get; }

        #endregion
    }

    public class ReferenceBase
    {
        // =============================
        // auto propiedades

        #region "auto propiedades"

        [XmlAttribute]
        public string Type { set; get; }
        [XmlText]
        public string Value { set; get; }

        #endregion
    }

    public class AddressVerificationSystemValueBase
    {
        // =============================
        // auto propiedades

        #region "auto propiedades"

        [XmlAttribute]
        public string CityName { set; get; }

        [XmlAttribute]
        public string PostalCode { set; get; }

        [XmlAttribute]
        public string Country { set; get; }

        public string Line { set; get; }

        #endregion
    }

    public class ValidityBase
    {
        // =============================
        // auto propiedades

        #region "auto propiedades"

        [XmlAttribute]
        public string EndDate { set; get; }

        #endregion
    }

    public class VendorBase
    {
        // =============================
        // auto propiedades

        #region "auto propiedades"

        [XmlAttribute]
        public string Code { set; get; }

        #endregion
    }

    public class CardBase
    {
        // =============================
        // auto propiedades

        #region "auto propiedades"

        [XmlAttribute]
        public string HolderName { set; get; }

        [XmlAttribute]
        public string SubType { set; get; }

        public AddressVerificationSystemValueBase AddressVerificationSystemValue { set; get; }
        public string PrimaryAccountNumber { set; get; }
        public string CVV { set; get; }
        public ValidityBase Validity { set; get; }
        public VendorBase Vendor { set; get; }

        #endregion
    }

    public class VirtualCardBase
    {
        // =============================
        // auto propiedades

        #region "auto propiedades"

        [XmlAttribute]
        public string LastUpdatedTime { set; get; }

        [XmlAttribute]
        public string CreationTime { set; get; }

        [XmlAttribute]
        public string CreationUser { set; get; }

        [XmlAttribute]
        public string CreationOffice { set; get; }

        [XmlAttribute]
        public string CardStatus { set; get; }

        public CardBase Card { set; get; }
        public ReferencesBase References { set; get; }
        public string Provider { set; get; }
        public ValueBase[] Values { set; get; }
        public LimitationsBase Limitations { set; get; }

        #endregion
    }

    public class ReferencesBase
    {
        // =============================
        // auto propiedades

        #region "auto propiedades"

        [XmlElement(ElementName = "Reference")]
        public ReferenceBase[] Reference { set; get; }

        #endregion
    }

    [XmlType("Value")]
    public class ValueBase
    {
        // =============================
        // auto propiedades

        #region "auto propiedades"

        [XmlAttribute]
        public string Type { set; get; }

        [XmlAttribute]
        public string Amount { set; get; }

        [XmlAttribute]
        public string DecimalPlaces { set; get; }

        [XmlAttribute]
        public string CurrencyCode { set; get; }

        #endregion
    }

    public class AllowedTransactionsBase
    {
        // =============================
        // auto propiedades

        #region "auto propiedades"

        [XmlAttribute]
        public string Maximum { set; get; }

        #endregion
    }

    public class LimitationsBase
    {
        // =============================
        // auto propiedades

        #region "auto propiedades"

        public AllowedTransactionsBase AllowedTransactions { set; get; }
        public ValidityPeriodBase ValidityPeriod { set; get; }

        #endregion
    }

    [XmlType("Detail")]
    public class DetailBase
    {
        // =============================
        // auto propiedades

        #region "auto propiedades"

        [XmlText]
        public string Value { set; get; }

        #endregion
    }

    [XmlType("Warning")]
    public class WarningBase : DetailBase
    {
        // =============================
        // auto propiedades

        #region "auto propiedades"

        [XmlAttribute]
        public string Type { set; get; }

        [XmlAttribute]
        public string ShortText { set; get; }

        [XmlAttribute]
        public string Code { set; get; }

        #endregion
    }

    [XmlType("Error")]
    public class ErrorBase : DetailBase
    {
    }

    public class B2BWalletDataRQBase
    {
        // =============================
        // metodos estaticos

        #region "metodos estaticos"

        protected static string ToStringWithoutDecimalSymbol<T>(T valor,
                                                             byte cantidadDecimales)
        {
            if (valor != null)
            {
                // evaluando el tipo de dato recibido
                if ((typeof(T) == typeof(decimal)) || (typeof(T) == typeof(decimal?))
                    || (typeof(T) == typeof(double)) || (typeof(T) == typeof(double?))
                        || (typeof(T) == typeof(string)))
                {
                    object valor1 = valor;

                    if ((typeof(T) == typeof(string)))
                    {
                        valor1 = decimal.Parse(valor as string);
                    }

                    // construyendo patron con el cual extraer el valor
                    var lpatron = ("{0:#0." + (new string('0', ((cantidadDecimales <= 1) ? 1 : cantidadDecimales))) + "}");
                    var lvalor2 = string.Format(lpatron, valor1);

                    // retornando lo solicitado
                    return ((cantidadDecimales < 1) ? lvalor2.Split('.')[0] : (new Regex("[^0-9]")).Replace(lvalor2, string.Empty));
                }
            }

            return null;
        }

        #endregion
    }

    public class B2BWalletBase : IDisposable
    {
        // =============================
        // variables

        #region "variables"

        protected bool _disposing;

        #endregion

        // =============================
        // constructores y destructores

        #region "constructores y destructores"

        ~B2BWalletBase()
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
                    Command = null;
                    ConsumerID = null;
                }
            }

            _disposing = true;
        }

        #endregion

        // =============================
        // auto propiedades

        #region "auto propiedades"

        public string Command { set; get; }
        public string ConsumerID { set; get; }

        #endregion
    }

    #endregion
}

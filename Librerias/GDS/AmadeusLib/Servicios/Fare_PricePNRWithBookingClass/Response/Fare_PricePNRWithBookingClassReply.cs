using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;


namespace AmadeusLib.Servicios.Fare_PricePNRWithBookingClass.Response
{
    
    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TPCBRR_16_1_1A")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://xml.amadeus.com/TPCBRR_16_1_1A", IsNullable = false)]
    public partial class Fare_PricePNRWithBookingClassReply
    {

        private ErrorGroupType applicationErrorField;

        private ReservationControlInformationTypeI pnrLocatorDataField;

        private Fare_PricePNRWithBookingClassReplyFareList[] fareListField;

        /// <comentarios/>
        public ErrorGroupType applicationError
        {
            get
            {
                return this.applicationErrorField;
            }
            set
            {
                this.applicationErrorField = value;
            }
        }

        /// <comentarios/>
        public ReservationControlInformationTypeI pnrLocatorData
        {
            get
            {
                return this.pnrLocatorDataField;
            }
            set
            {
                this.pnrLocatorDataField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("fareList")]
        public Fare_PricePNRWithBookingClassReplyFareList[] fareList
        {
            get
            {
                return this.fareListField;
            }
            set
            {
                this.fareListField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TPCBRR_16_1_1A")]
    public partial class ErrorGroupType
    {

        private ApplicationErrorInformationType_84497S errorOrWarningCodeDetailsField;

        private FreeTextInformationType errorWarningDescriptionField;

        /// <comentarios/>
        public ApplicationErrorInformationType_84497S errorOrWarningCodeDetails
        {
            get
            {
                return this.errorOrWarningCodeDetailsField;
            }
            set
            {
                this.errorOrWarningCodeDetailsField = value;
            }
        }

        /// <comentarios/>
        public FreeTextInformationType errorWarningDescription
        {
            get
            {
                return this.errorWarningDescriptionField;
            }
            set
            {
                this.errorWarningDescriptionField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TPCBRR_16_1_1A")]
    public partial class ApplicationErrorInformationType_84497S
    {

        private ApplicationErrorDetailType errorDetailsField;

        /// <comentarios/>
        public ApplicationErrorDetailType errorDetails
        {
            get
            {
                return this.errorDetailsField;
            }
            set
            {
                this.errorDetailsField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TPCBRR_16_1_1A")]
    public partial class ApplicationErrorDetailType
    {

        private string errorCodeField;

        private string errorCategoryField;

        private string errorCodeOwnerField;

        /// <comentarios/>
        public string errorCode
        {
            get
            {
                return this.errorCodeField;
            }
            set
            {
                this.errorCodeField = value;
            }
        }

        /// <comentarios/>
        public string errorCategory
        {
            get
            {
                return this.errorCategoryField;
            }
            set
            {
                this.errorCategoryField = value;
            }
        }

        /// <comentarios/>
        public string errorCodeOwner
        {
            get
            {
                return this.errorCodeOwnerField;
            }
            set
            {
                this.errorCodeOwnerField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TPCBRR_16_1_1A")]
    public partial class TicketNumberTypeI
    {

        private TicketNumberDetailsTypeI documentDetailsField;

        /// <comentarios/>
        public TicketNumberDetailsTypeI documentDetails
        {
            get
            {
                return this.documentDetailsField;
            }
            set
            {
                this.documentDetailsField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TPCBRR_16_1_1A")]
    public partial class TicketNumberDetailsTypeI
    {

        private string numberField;

        private string typeField;

        /// <comentarios/>
        public string number
        {
            get
            {
                return this.numberField;
            }
            set
            {
                this.numberField = value;
            }
        }

        /// <comentarios/>
        public string type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TPCBRR_16_1_1A")]
    public partial class TaxTypeI
    {

        private TaxDetailsTypeI[] taxDetailsField;

        private object dummyNETField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("taxDetails")]
        public TaxDetailsTypeI[] taxDetails
        {
            get
            {
                return this.taxDetailsField;
            }
            set
            {
                this.taxDetailsField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("Dummy.NET")]
        public object DummyNET
        {
            get
            {
                return this.dummyNETField;
            }
            set
            {
                this.dummyNETField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TPCBRR_16_1_1A")]
    public partial class TaxDetailsTypeI
    {

        private string rateField;

        private string countryCodeField;

        private string currencyCodeField;

        private string typeField;

        private string secondTypeField;

        /// <comentarios/>
        public string rate
        {
            get
            {
                return this.rateField;
            }
            set
            {
                this.rateField = value;
            }
        }

        /// <comentarios/>
        public string countryCode
        {
            get
            {
                return this.countryCodeField;
            }
            set
            {
                this.countryCodeField = value;
            }
        }

        /// <comentarios/>
        public string currencyCode
        {
            get
            {
                return this.currencyCodeField;
            }
            set
            {
                this.currencyCodeField = value;
            }
        }

        /// <comentarios/>
        public string type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }

        /// <comentarios/>
        public string secondType
        {
            get
            {
                return this.secondTypeField;
            }
            set
            {
                this.secondTypeField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TPCBRR_16_1_1A")]
    public partial class SpecificDataInformationTypeI
    {

        private DataTypeInformationTypeI dataTypeInformationField;

        private DataInformationTypeI[] dataInformationField;

        /// <comentarios/>
        public DataTypeInformationTypeI dataTypeInformation
        {
            get
            {
                return this.dataTypeInformationField;
            }
            set
            {
                this.dataTypeInformationField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("dataInformation")]
        public DataInformationTypeI[] dataInformation
        {
            get
            {
                return this.dataInformationField;
            }
            set
            {
                this.dataInformationField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TPCBRR_16_1_1A")]
    public partial class DataTypeInformationTypeI
    {

        private string typeField;

        /// <comentarios/>
        public string type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TPCBRR_16_1_1A")]
    public partial class DataInformationTypeI
    {

        private string indicatorField;

        /// <comentarios/>
        public string indicator
        {
            get
            {
                return this.indicatorField;
            }
            set
            {
                this.indicatorField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TPCBRR_16_1_1A")]
    public partial class SelectionDetailsTypeI
    {

        private SelectionDetailsInformationTypeI selectionDetailsField;

        /// <comentarios/>
        public SelectionDetailsInformationTypeI selectionDetails
        {
            get
            {
                return this.selectionDetailsField;
            }
            set
            {
                this.selectionDetailsField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TPCBRR_16_1_1A")]
    public partial class SelectionDetailsInformationTypeI
    {

        private string optionField;

        /// <comentarios/>
        public string option
        {
            get
            {
                return this.optionField;
            }
            set
            {
                this.optionField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TPCBRR_16_1_1A")]
    public partial class MonetaryInformationTypeI_20897S
    {

        private MonetaryInformationDetailsTypeI_37257C monetaryDetailsField;

        private MonetaryInformationDetailsTypeI_37257C[] otherMonetaryDetailsField;

        /// <comentarios/>
        public MonetaryInformationDetailsTypeI_37257C monetaryDetails
        {
            get
            {
                return this.monetaryDetailsField;
            }
            set
            {
                this.monetaryDetailsField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("otherMonetaryDetails")]
        public MonetaryInformationDetailsTypeI_37257C[] otherMonetaryDetails
        {
            get
            {
                return this.otherMonetaryDetailsField;
            }
            set
            {
                this.otherMonetaryDetailsField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TPCBRR_16_1_1A")]
    public partial class MonetaryInformationDetailsTypeI_37257C
    {

        private string typeQualifierField;

        private string amountField;

        private string currencyField;

        private string locationField;

        /// <comentarios/>
        public string typeQualifier
        {
            get
            {
                return this.typeQualifierField;
            }
            set
            {
                this.typeQualifierField = value;
            }
        }

        /// <comentarios/>
        public string amount
        {
            get
            {
                return this.amountField;
            }
            set
            {
                this.amountField = value;
            }
        }

        /// <comentarios/>
        public string currency
        {
            get
            {
                return this.currencyField;
            }
            set
            {
                this.currencyField = value;
            }
        }

        /// <comentarios/>
        public string location
        {
            get
            {
                return this.locationField;
            }
            set
            {
                this.locationField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TPCBRR_16_1_1A")]
    public partial class MonetaryInformationDetailsTypeI_63727C
    {

        private string typeQualifierField;

        private string amountField;

        private string currencyField;

        private string locationField;

        /// <comentarios/>
        public string typeQualifier
        {
            get
            {
                return this.typeQualifierField;
            }
            set
            {
                this.typeQualifierField = value;
            }
        }

        /// <comentarios/>
        public string amount
        {
            get
            {
                return this.amountField;
            }
            set
            {
                this.amountField = value;
            }
        }

        /// <comentarios/>
        public string currency
        {
            get
            {
                return this.currencyField;
            }
            set
            {
                this.currencyField = value;
            }
        }

        /// <comentarios/>
        public string location
        {
            get
            {
                return this.locationField;
            }
            set
            {
                this.locationField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TPCBRR_16_1_1A")]
    public partial class InteractiveFreeTextTypeI_6759S
    {

        private string errorFreeTextField;

        /// <comentarios/>
        public string errorFreeText
        {
            get
            {
                return this.errorFreeTextField;
            }
            set
            {
                this.errorFreeTextField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TPCBRR_16_1_1A")]
    public partial class InteractiveFreeTextTypeI
    {

        private FreeTextQualificationTypeI freeTextQualificationField;

        private string freeTextField;

        /// <comentarios/>
        public FreeTextQualificationTypeI freeTextQualification
        {
            get
            {
                return this.freeTextQualificationField;
            }
            set
            {
                this.freeTextQualificationField = value;
            }
        }

        /// <comentarios/>
        public string freeText
        {
            get
            {
                return this.freeTextField;
            }
            set
            {
                this.freeTextField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TPCBRR_16_1_1A")]
    public partial class FreeTextQualificationTypeI
    {

        private string textSubjectQualifierField;

        /// <comentarios/>
        public string textSubjectQualifier
        {
            get
            {
                return this.textSubjectQualifierField;
            }
            set
            {
                this.textSubjectQualifierField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TPCBRR_16_1_1A")]
    public partial class TransportIdentifierType_156079S
    {

        private CompanyIdentificationTypeI_222513C companyIdentificationField;

        /// <comentarios/>
        public CompanyIdentificationTypeI_222513C companyIdentification
        {
            get
            {
                return this.companyIdentificationField;
            }
            set
            {
                this.companyIdentificationField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TPCBRR_16_1_1A")]
    public partial class CompanyIdentificationTypeI_222513C
    {

        private string otherCompanyField;

        /// <comentarios/>
        public string otherCompany
        {
            get
            {
                return this.otherCompanyField;
            }
            set
            {
                this.otherCompanyField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TPCBRR_16_1_1A")]
    public partial class FareFamilyDetailsType
    {

        private string commercialFamilyField;

        /// <comentarios/>
        public string commercialFamily
        {
            get
            {
                return this.commercialFamilyField;
            }
            set
            {
                this.commercialFamilyField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TPCBRR_16_1_1A")]
    public partial class FareFamilyType
    {

        private string fareFamilynameField;

        private string hierarchyField;

        private FareFamilyDetailsType[] commercialFamilyDetailsField;

        /// <comentarios/>
        public string fareFamilyname
        {
            get
            {
                return this.fareFamilynameField;
            }
            set
            {
                this.fareFamilynameField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
        public string hierarchy
        {
            get
            {
                return this.hierarchyField;
            }
            set
            {
                this.hierarchyField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("commercialFamilyDetails")]
        public FareFamilyDetailsType[] commercialFamilyDetails
        {
            get
            {
                return this.commercialFamilyDetailsField;
            }
            set
            {
                this.commercialFamilyDetailsField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TPCBRR_16_1_1A")]
    public partial class RateTariffClassInformationType
    {

        private string rateTariffClassField;

        private string otherRateTariffClassField;

        /// <comentarios/>
        public string rateTariffClass
        {
            get
            {
                return this.rateTariffClassField;
            }
            set
            {
                this.rateTariffClassField = value;
            }
        }

        /// <comentarios/>
        public string otherRateTariffClass
        {
            get
            {
                return this.otherRateTariffClassField;
            }
            set
            {
                this.otherRateTariffClassField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TPCBRR_16_1_1A")]
    public partial class PricingOrTicketingSubsequentType
    {

        private RateTariffClassInformationType fareBasisDetailsField;

        /// <comentarios/>
        public RateTariffClassInformationType fareBasisDetails
        {
            get
            {
                return this.fareBasisDetailsField;
            }
            set
            {
                this.fareBasisDetailsField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TPCBRR_16_1_1A")]
    public partial class MonetaryInformationDetailsType
    {

        private string typeQualifierField;

        private string amountField;

        private string currencyField;

        /// <comentarios/>
        public string typeQualifier
        {
            get
            {
                return this.typeQualifierField;
            }
            set
            {
                this.typeQualifierField = value;
            }
        }

        /// <comentarios/>
        public string amount
        {
            get
            {
                return this.amountField;
            }
            set
            {
                this.amountField = value;
            }
        }

        /// <comentarios/>
        public string currency
        {
            get
            {
                return this.currencyField;
            }
            set
            {
                this.currencyField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TPCBRR_16_1_1A")]
    public partial class MonetaryInformationType_198918S
    {

        private MonetaryInformationDetailsType monetaryDetailsField;

        private MonetaryInformationDetailsType[] otherMonetaryDetailsField;

        /// <comentarios/>
        public MonetaryInformationDetailsType monetaryDetails
        {
            get
            {
                return this.monetaryDetailsField;
            }
            set
            {
                this.monetaryDetailsField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("otherMonetaryDetails")]
        public MonetaryInformationDetailsType[] otherMonetaryDetails
        {
            get
            {
                return this.otherMonetaryDetailsField;
            }
            set
            {
                this.otherMonetaryDetailsField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TPCBRR_16_1_1A")]
    public partial class TravelProductInformationTypeI
    {

        private LocationTypeI boardPointDetailsField;

        private LocationTypeI offpointDetailsField;

        /// <comentarios/>
        public LocationTypeI boardPointDetails
        {
            get
            {
                return this.boardPointDetailsField;
            }
            set
            {
                this.boardPointDetailsField = value;
            }
        }

        /// <comentarios/>
        public LocationTypeI offpointDetails
        {
            get
            {
                return this.offpointDetailsField;
            }
            set
            {
                this.offpointDetailsField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TPCBRR_16_1_1A")]
    public partial class LocationTypeI
    {

        private string trueLocationIdField;

        /// <comentarios/>
        public string trueLocationId
        {
            get
            {
                return this.trueLocationIdField;
            }
            set
            {
                this.trueLocationIdField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TPCBRR_16_1_1A")]
    public partial class ItemNumberIdentificationType
    {

        private string numberField;

        private string typeField;

        /// <comentarios/>
        public string number
        {
            get
            {
                return this.numberField;
            }
            set
            {
                this.numberField = value;
            }
        }

        /// <comentarios/>
        public string type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TPCBRR_16_1_1A")]
    public partial class FareComponentDetailsType
    {

        private ItemNumberIdentificationType[] fareComponentIDField;

        private TravelProductInformationTypeI marketFareComponentField;

        private MonetaryInformationType_198918S monetaryInformationField;

        private PricingOrTicketingSubsequentType componentClassInfoField;

        private DiscountPenaltyInformationType[] fareQualifiersDetailField;

        private FareFamilyType fareFamilyDetailsField;

        private TransportIdentifierType_156079S fareFamilyOwnerField;

        private CouponDetailsType[] couponDetailsGroupField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayItemAttribute("itemNumberDetails", IsNullable = false)]
        public ItemNumberIdentificationType[] fareComponentID
        {
            get
            {
                return this.fareComponentIDField;
            }
            set
            {
                this.fareComponentIDField = value;
            }
        }

        /// <comentarios/>
        public TravelProductInformationTypeI marketFareComponent
        {
            get
            {
                return this.marketFareComponentField;
            }
            set
            {
                this.marketFareComponentField = value;
            }
        }

        /// <comentarios/>
        public MonetaryInformationType_198918S monetaryInformation
        {
            get
            {
                return this.monetaryInformationField;
            }
            set
            {
                this.monetaryInformationField = value;
            }
        }

        /// <comentarios/>
        public PricingOrTicketingSubsequentType componentClassInfo
        {
            get
            {
                return this.componentClassInfoField;
            }
            set
            {
                this.componentClassInfoField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayItemAttribute("discountDetails", IsNullable = false)]
        public DiscountPenaltyInformationType[] fareQualifiersDetail
        {
            get
            {
                return this.fareQualifiersDetailField;
            }
            set
            {
                this.fareQualifiersDetailField = value;
            }
        }

        /// <comentarios/>
        public FareFamilyType fareFamilyDetails
        {
            get
            {
                return this.fareFamilyDetailsField;
            }
            set
            {
                this.fareFamilyDetailsField = value;
            }
        }

        /// <comentarios/>
        public TransportIdentifierType_156079S fareFamilyOwner
        {
            get
            {
                return this.fareFamilyOwnerField;
            }
            set
            {
                this.fareFamilyOwnerField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("couponDetailsGroup")]
        public CouponDetailsType[] couponDetailsGroup
        {
            get
            {
                return this.couponDetailsGroupField;
            }
            set
            {
                this.couponDetailsGroupField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TPCBRR_16_1_1A")]
    public partial class DiscountPenaltyInformationType
    {

        private string fareQualifierField;

        /// <comentarios/>
        public string fareQualifier
        {
            get
            {
                return this.fareQualifierField;
            }
            set
            {
                this.fareQualifierField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TPCBRR_16_1_1A")]
    public partial class CouponDetailsType
    {

        private ReferenceInfoType productIdField;

        private TravelProductInformationType flightConnectionTypeField;

        private CouponDetailsTypeCouponTaxDetailsGroup[] couponTaxDetailsGroupField;

        /// <comentarios/>
        public ReferenceInfoType productId
        {
            get
            {
                return this.productIdField;
            }
            set
            {
                this.productIdField = value;
            }
        }

        /// <comentarios/>
        public TravelProductInformationType flightConnectionType
        {
            get
            {
                return this.flightConnectionTypeField;
            }
            set
            {
                this.flightConnectionTypeField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("couponTaxDetailsGroup")]
        public CouponDetailsTypeCouponTaxDetailsGroup[] couponTaxDetailsGroup
        {
            get
            {
                return this.couponTaxDetailsGroupField;
            }
            set
            {
                this.couponTaxDetailsGroupField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TPCBRR_16_1_1A")]
    public partial class ReferenceInfoType
    {

        private ReferencingDetailsType referenceDetailsField;

        /// <comentarios/>
        public ReferencingDetailsType referenceDetails
        {
            get
            {
                return this.referenceDetailsField;
            }
            set
            {
                this.referenceDetailsField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TPCBRR_16_1_1A")]
    public partial class ReferencingDetailsType
    {

        private string typeField;

        private string valueField;

        /// <comentarios/>
        public string type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }

        /// <comentarios/>
        public string value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TPCBRR_16_1_1A")]
    public partial class TravelProductInformationType
    {

        private LocationTypeI boardPointDetailsField;

        private LocationTypeI offpointDetailsField;

        private ProductTypeDetailsType flightTypeDetailsField;

        /// <comentarios/>
        public LocationTypeI boardPointDetails
        {
            get
            {
                return this.boardPointDetailsField;
            }
            set
            {
                this.boardPointDetailsField = value;
            }
        }

        /// <comentarios/>
        public LocationTypeI offpointDetails
        {
            get
            {
                return this.offpointDetailsField;
            }
            set
            {
                this.offpointDetailsField = value;
            }
        }

        /// <comentarios/>
        public ProductTypeDetailsType flightTypeDetails
        {
            get
            {
                return this.flightTypeDetailsField;
            }
            set
            {
                this.flightTypeDetailsField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TPCBRR_16_1_1A")]
    public partial class ProductTypeDetailsType
    {

        private string flightIndicatorField;

        /// <comentarios/>
        public string flightIndicator
        {
            get
            {
                return this.flightIndicatorField;
            }
            set
            {
                this.flightIndicatorField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TPCBRR_16_1_1A")]
    public partial class CouponDetailsTypeCouponTaxDetailsGroup
    {

        private DutyTaxFeeDetailsType taxTriggerInfoField;

        private TaxType taxDetailsField;

        private MonetaryInformationType monetaryInfoField;

        private PlaceLocationIdentificationType locationInfoField;

        /// <comentarios/>
        public DutyTaxFeeDetailsType taxTriggerInfo
        {
            get
            {
                return this.taxTriggerInfoField;
            }
            set
            {
                this.taxTriggerInfoField = value;
            }
        }

        /// <comentarios/>
        public TaxType taxDetails
        {
            get
            {
                return this.taxDetailsField;
            }
            set
            {
                this.taxDetailsField = value;
            }
        }

        /// <comentarios/>
        public MonetaryInformationType monetaryInfo
        {
            get
            {
                return this.monetaryInfoField;
            }
            set
            {
                this.monetaryInfoField = value;
            }
        }

        /// <comentarios/>
        public PlaceLocationIdentificationType locationInfo
        {
            get
            {
                return this.locationInfoField;
            }
            set
            {
                this.locationInfoField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TPCBRR_16_1_1A")]
    public partial class DutyTaxFeeDetailsType
    {

        private string taxQualifierField;

        /// <comentarios/>
        public string taxQualifier
        {
            get
            {
                return this.taxQualifierField;
            }
            set
            {
                this.taxQualifierField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TPCBRR_16_1_1A")]
    public partial class TaxType
    {

        private string taxCategoryField;

        private TaxDetailsType taxDetailsField;

        /// <comentarios/>
        public string taxCategory
        {
            get
            {
                return this.taxCategoryField;
            }
            set
            {
                this.taxCategoryField = value;
            }
        }

        /// <comentarios/>
        public TaxDetailsType taxDetails
        {
            get
            {
                return this.taxDetailsField;
            }
            set
            {
                this.taxDetailsField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TPCBRR_16_1_1A")]
    public partial class TaxDetailsType
    {

        private string countryCodeField;

        private string[] typeField;

        /// <comentarios/>
        public string countryCode
        {
            get
            {
                return this.countryCodeField;
            }
            set
            {
                this.countryCodeField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("type")]
        public string[] type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TPCBRR_16_1_1A")]
    public partial class MonetaryInformationType
    {

        private MonetaryInformationDetailsType_270392C monetaryDetailsField;

        private MonetaryInformationDetailsType_270392C[] otherMonetaryDetailsField;

        /// <comentarios/>
        public MonetaryInformationDetailsType_270392C monetaryDetails
        {
            get
            {
                return this.monetaryDetailsField;
            }
            set
            {
                this.monetaryDetailsField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("otherMonetaryDetails")]
        public MonetaryInformationDetailsType_270392C[] otherMonetaryDetails
        {
            get
            {
                return this.otherMonetaryDetailsField;
            }
            set
            {
                this.otherMonetaryDetailsField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TPCBRR_16_1_1A")]
    public partial class MonetaryInformationDetailsType_270392C
    {

        private string typeQualifierField;

        private decimal amountField;

        private bool amountFieldSpecified;

        private string currencyField;

        private string locationField;

        /// <comentarios/>
        public string typeQualifier
        {
            get
            {
                return this.typeQualifierField;
            }
            set
            {
                this.typeQualifierField = value;
            }
        }

        /// <comentarios/>
        public decimal amount
        {
            get
            {
                return this.amountField;
            }
            set
            {
                this.amountField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool amountSpecified
        {
            get
            {
                return this.amountFieldSpecified;
            }
            set
            {
                this.amountFieldSpecified = value;
            }
        }

        /// <comentarios/>
        public string currency
        {
            get
            {
                return this.currencyField;
            }
            set
            {
                this.currencyField = value;
            }
        }

        /// <comentarios/>
        public string location
        {
            get
            {
                return this.locationField;
            }
            set
            {
                this.locationField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TPCBRR_16_1_1A")]
    public partial class PlaceLocationIdentificationType
    {

        private string locationTypeField;

        private LocationIdentificationBatchType locationDescriptionField;

        /// <comentarios/>
        public string locationType
        {
            get
            {
                return this.locationTypeField;
            }
            set
            {
                this.locationTypeField = value;
            }
        }

        /// <comentarios/>
        public LocationIdentificationBatchType locationDescription
        {
            get
            {
                return this.locationDescriptionField;
            }
            set
            {
                this.locationDescriptionField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TPCBRR_16_1_1A")]
    public partial class LocationIdentificationBatchType
    {

        private string codeField;

        /// <comentarios/>
        public string code
        {
            get
            {
                return this.codeField;
            }
            set
            {
                this.codeField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TPCBRR_16_1_1A")]
    public partial class DummySegmentTypeI
    {
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TPCBRR_16_1_1A")]
    public partial class DiscountPenaltyMonetaryInformationTypeI_29792C
    {

        private string penaltyQualifierField;

        private decimal penaltyAmountField;

        private bool penaltyAmountFieldSpecified;

        private string penaltyCurrencyField;

        /// <comentarios/>
        public string penaltyQualifier
        {
            get
            {
                return this.penaltyQualifierField;
            }
            set
            {
                this.penaltyQualifierField = value;
            }
        }

        /// <comentarios/>
        public decimal penaltyAmount
        {
            get
            {
                return this.penaltyAmountField;
            }
            set
            {
                this.penaltyAmountField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool penaltyAmountSpecified
        {
            get
            {
                return this.penaltyAmountFieldSpecified;
            }
            set
            {
                this.penaltyAmountFieldSpecified = value;
            }
        }

        /// <comentarios/>
        public string penaltyCurrency
        {
            get
            {
                return this.penaltyCurrencyField;
            }
            set
            {
                this.penaltyCurrencyField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TPCBRR_16_1_1A")]
    public partial class DiscountAndPenaltyInformationTypeI
    {

        private DiscountPenaltyMonetaryInformationTypeI_29792C penDisDataField;

        /// <comentarios/>
        public DiscountPenaltyMonetaryInformationTypeI_29792C penDisData
        {
            get
            {
                return this.penDisDataField;
            }
            set
            {
                this.penDisDataField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TPCBRR_16_1_1A")]
    public partial class CouponInformationTypeI
    {

        private CouponInformationDetailsTypeI couponDetailsField;

        private CouponInformationDetailsTypeI[] otherCouponDetailsField;

        /// <comentarios/>
        public CouponInformationDetailsTypeI couponDetails
        {
            get
            {
                return this.couponDetailsField;
            }
            set
            {
                this.couponDetailsField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("otherCouponDetails")]
        public CouponInformationDetailsTypeI[] otherCouponDetails
        {
            get
            {
                return this.otherCouponDetailsField;
            }
            set
            {
                this.otherCouponDetailsField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TPCBRR_16_1_1A")]
    public partial class CouponInformationDetailsTypeI
    {

        private string cpnNumberField;

        /// <comentarios/>
        public string cpnNumber
        {
            get
            {
                return this.cpnNumberField;
            }
            set
            {
                this.cpnNumberField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TPCBRR_16_1_1A")]
    public partial class CorporateFareIdentifiersTypeI
    {

        private string fareQualifierField;

        private string[] corporateIDField;

        /// <comentarios/>
        public string fareQualifier
        {
            get
            {
                return this.fareQualifierField;
            }
            set
            {
                this.fareQualifierField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("corporateID")]
        public string[] corporateID
        {
            get
            {
                return this.corporateIDField;
            }
            set
            {
                this.corporateIDField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TPCBRR_16_1_1A")]
    public partial class CodedAttributeInformationType
    {

        private string attributeTypeField;

        private string attributeDescriptionField;

        /// <comentarios/>
        public string attributeType
        {
            get
            {
                return this.attributeTypeField;
            }
            set
            {
                this.attributeTypeField = value;
            }
        }

        /// <comentarios/>
        public string attributeDescription
        {
            get
            {
                return this.attributeDescriptionField;
            }
            set
            {
                this.attributeDescriptionField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TPCBRR_16_1_1A")]
    public partial class ApplicationErrorInformationType
    {

        private ApplicationErrorDetailType_48648C applicationErrorDetailField;

        /// <comentarios/>
        public ApplicationErrorDetailType_48648C applicationErrorDetail
        {
            get
            {
                return this.applicationErrorDetailField;
            }
            set
            {
                this.applicationErrorDetailField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TPCBRR_16_1_1A")]
    public partial class ApplicationErrorDetailType_48648C
    {

        private string applicationErrorCodeField;

        private string codeListQualifierField;

        private string codeListResponsibleAgencyField;

        /// <comentarios/>
        public string applicationErrorCode
        {
            get
            {
                return this.applicationErrorCodeField;
            }
            set
            {
                this.applicationErrorCodeField = value;
            }
        }

        /// <comentarios/>
        public string codeListQualifier
        {
            get
            {
                return this.codeListQualifierField;
            }
            set
            {
                this.codeListQualifierField = value;
            }
        }

        /// <comentarios/>
        public string codeListResponsibleAgency
        {
            get
            {
                return this.codeListResponsibleAgencyField;
            }
            set
            {
                this.codeListResponsibleAgencyField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TPCBRR_16_1_1A")]
    public partial class MileageTimeDetailsTypeI
    {

        private string totalMileageField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
        public string totalMileage
        {
            get
            {
                return this.totalMileageField;
            }
            set
            {
                this.totalMileageField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TPCBRR_16_1_1A")]
    public partial class AdditionalProductDetailsTypeI
    {

        private MileageTimeDetailsTypeI mileageTimeDetailsField;

        /// <comentarios/>
        public MileageTimeDetailsTypeI mileageTimeDetails
        {
            get
            {
                return this.mileageTimeDetailsField;
            }
            set
            {
                this.mileageTimeDetailsField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TPCBRR_16_1_1A")]
    public partial class CodedAttributeInformationType_66047C
    {

        private string attributeTypeField;

        private string attributeDescriptionField;

        /// <comentarios/>
        public string attributeType
        {
            get
            {
                return this.attributeTypeField;
            }
            set
            {
                this.attributeTypeField = value;
            }
        }

        /// <comentarios/>
        public string attributeDescription
        {
            get
            {
                return this.attributeDescriptionField;
            }
            set
            {
                this.attributeDescriptionField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TPCBRR_16_1_1A")]
    public partial class CodedAttributeType_39223S
    {

        private CodedAttributeInformationType_66047C[] attributeDetailsField;

        private object dummyNETField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("attributeDetails")]
        public CodedAttributeInformationType_66047C[] attributeDetails
        {
            get
            {
                return this.attributeDetailsField;
            }
            set
            {
                this.attributeDetailsField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("Dummy.NET")]
        public object DummyNET
        {
            get
            {
                return this.dummyNETField;
            }
            set
            {
                this.dummyNETField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TPCBRR_16_1_1A")]
    public partial class UniqueIdDescriptionType
    {

        private string sequenceNumberField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
        public string sequenceNumber
        {
            get
            {
                return this.sequenceNumberField;
            }
            set
            {
                this.sequenceNumberField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TPCBRR_16_1_1A")]
    public partial class ItemReferencesAndVersionsType
    {

        private UniqueIdDescriptionType sequenceSectionField;

        /// <comentarios/>
        public UniqueIdDescriptionType sequenceSection
        {
            get
            {
                return this.sequenceSectionField;
            }
            set
            {
                this.sequenceSectionField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TPCBRR_16_1_1A")]
    public partial class BaggageDetailsTypeI
    {

        private string baggageQuantityField;

        private string baggageWeightField;

        private string baggageTypeField;

        private string measureUnitField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
        public string baggageQuantity
        {
            get
            {
                return this.baggageQuantityField;
            }
            set
            {
                this.baggageQuantityField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
        public string baggageWeight
        {
            get
            {
                return this.baggageWeightField;
            }
            set
            {
                this.baggageWeightField = value;
            }
        }

        /// <comentarios/>
        public string baggageType
        {
            get
            {
                return this.baggageTypeField;
            }
            set
            {
                this.baggageTypeField = value;
            }
        }

        /// <comentarios/>
        public string measureUnit
        {
            get
            {
                return this.measureUnitField;
            }
            set
            {
                this.measureUnitField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TPCBRR_16_1_1A")]
    public partial class ExcessBaggageTypeI
    {

        private BaggageDetailsTypeI bagAllowanceDetailsField;

        /// <comentarios/>
        public BaggageDetailsTypeI bagAllowanceDetails
        {
            get
            {
                return this.bagAllowanceDetailsField;
            }
            set
            {
                this.bagAllowanceDetailsField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TPCBRR_16_1_1A")]
    public partial class StructuredDateTimeType
    {

        private string yearField;

        private string monthField;

        private string dayField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
        public string year
        {
            get
            {
                return this.yearField;
            }
            set
            {
                this.yearField = value;
            }
        }

        /// <comentarios/>
        public string month
        {
            get
            {
                return this.monthField;
            }
            set
            {
                this.monthField = value;
            }
        }

        /// <comentarios/>
        public string day
        {
            get
            {
                return this.dayField;
            }
            set
            {
                this.dayField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TPCBRR_16_1_1A")]
    public partial class StructuredDateTimeInformationType
    {

        private string businessSemanticField;

        private StructuredDateTimeType dateTimeField;

        /// <comentarios/>
        public string businessSemantic
        {
            get
            {
                return this.businessSemanticField;
            }
            set
            {
                this.businessSemanticField = value;
            }
        }

        /// <comentarios/>
        public StructuredDateTimeType dateTime
        {
            get
            {
                return this.dateTimeField;
            }
            set
            {
                this.dateTimeField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TPCBRR_16_1_1A")]
    public partial class ProductDetailsTypeI
    {

        private string designatorField;

        private string availabilityStatusField;

        private string specialServiceField;

        private string[] optionField;

        /// <comentarios/>
        public string designator
        {
            get
            {
                return this.designatorField;
            }
            set
            {
                this.designatorField = value;
            }
        }

        /// <comentarios/>
        public string availabilityStatus
        {
            get
            {
                return this.availabilityStatusField;
            }
            set
            {
                this.availabilityStatusField = value;
            }
        }

        /// <comentarios/>
        public string specialService
        {
            get
            {
                return this.specialServiceField;
            }
            set
            {
                this.specialServiceField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("option")]
        public string[] option
        {
            get
            {
                return this.optionField;
            }
            set
            {
                this.optionField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TPCBRR_16_1_1A")]
    public partial class ProductInformationTypeI
    {

        private string productDetailsQualifierField;

        private ProductDetailsTypeI[] bookingClassDetailsField;

        /// <comentarios/>
        public string productDetailsQualifier
        {
            get
            {
                return this.productDetailsQualifierField;
            }
            set
            {
                this.productDetailsQualifierField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("bookingClassDetails")]
        public ProductDetailsTypeI[] bookingClassDetails
        {
            get
            {
                return this.bookingClassDetailsField;
            }
            set
            {
                this.bookingClassDetailsField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TPCBRR_16_1_1A")]
    public partial class DiscountPenaltyInformationTypeI
    {

        private string zapOffTypeField;

        private decimal zapOffAmountField;

        private bool zapOffAmountFieldSpecified;

        private string zapOffPercentageField;

        /// <comentarios/>
        public string zapOffType
        {
            get
            {
                return this.zapOffTypeField;
            }
            set
            {
                this.zapOffTypeField = value;
            }
        }

        /// <comentarios/>
        public decimal zapOffAmount
        {
            get
            {
                return this.zapOffAmountField;
            }
            set
            {
                this.zapOffAmountField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool zapOffAmountSpecified
        {
            get
            {
                return this.zapOffAmountFieldSpecified;
            }
            set
            {
                this.zapOffAmountFieldSpecified = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
        public string zapOffPercentage
        {
            get
            {
                return this.zapOffPercentageField;
            }
            set
            {
                this.zapOffPercentageField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TPCBRR_16_1_1A")]
    public partial class AdditionalFareQualifierDetailsTypeI
    {

        private string primaryCodeField;

        private string fareBasisCodeField;

        private string ticketDesignatorField;

        private string discTktDesignatorField;

        /// <comentarios/>
        public string primaryCode
        {
            get
            {
                return this.primaryCodeField;
            }
            set
            {
                this.primaryCodeField = value;
            }
        }

        /// <comentarios/>
        public string fareBasisCode
        {
            get
            {
                return this.fareBasisCodeField;
            }
            set
            {
                this.fareBasisCodeField = value;
            }
        }

        /// <comentarios/>
        public string ticketDesignator
        {
            get
            {
                return this.ticketDesignatorField;
            }
            set
            {
                this.ticketDesignatorField = value;
            }
        }

        /// <comentarios/>
        public string discTktDesignator
        {
            get
            {
                return this.discTktDesignatorField;
            }
            set
            {
                this.discTktDesignatorField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TPCBRR_16_1_1A")]
    public partial class FareQualifierDetailsTypeI
    {

        private string movementTypeField;

        private AdditionalFareQualifierDetailsTypeI fareBasisDetailsField;

        private DiscountPenaltyInformationTypeI zapOffDetailsField;

        /// <comentarios/>
        public string movementType
        {
            get
            {
                return this.movementTypeField;
            }
            set
            {
                this.movementTypeField = value;
            }
        }

        /// <comentarios/>
        public AdditionalFareQualifierDetailsTypeI fareBasisDetails
        {
            get
            {
                return this.fareBasisDetailsField;
            }
            set
            {
                this.fareBasisDetailsField = value;
            }
        }

        /// <comentarios/>
        public DiscountPenaltyInformationTypeI zapOffDetails
        {
            get
            {
                return this.zapOffDetailsField;
            }
            set
            {
                this.zapOffDetailsField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TPCBRR_16_1_1A")]
    public partial class ProductIdentificationDetailsTypeI
    {

        private string identificationField;

        private string bookingClassField;

        private string classOfServiceField;

        /// <comentarios/>
        public string identification
        {
            get
            {
                return this.identificationField;
            }
            set
            {
                this.identificationField = value;
            }
        }

        /// <comentarios/>
        public string bookingClass
        {
            get
            {
                return this.bookingClassField;
            }
            set
            {
                this.bookingClassField = value;
            }
        }

        /// <comentarios/>
        public string classOfService
        {
            get
            {
                return this.classOfServiceField;
            }
            set
            {
                this.classOfServiceField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TPCBRR_16_1_1A")]
    public partial class LocationTypeI_47688C
    {

        private string cityCodeField;

        /// <comentarios/>
        public string cityCode
        {
            get
            {
                return this.cityCodeField;
            }
            set
            {
                this.cityCodeField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TPCBRR_16_1_1A")]
    public partial class TravelProductInformationTypeI_26322S
    {

        private LocationTypeI_47688C departureCityField;

        private LocationTypeI_47688C arrivalCityField;

        private CompanyIdentificationTypeI airlineDetailField;

        private ProductIdentificationDetailsTypeI segmentDetailField;

        private string ticketingStatusField;

        /// <comentarios/>
        public LocationTypeI_47688C departureCity
        {
            get
            {
                return this.departureCityField;
            }
            set
            {
                this.departureCityField = value;
            }
        }

        /// <comentarios/>
        public LocationTypeI_47688C arrivalCity
        {
            get
            {
                return this.arrivalCityField;
            }
            set
            {
                this.arrivalCityField = value;
            }
        }

        /// <comentarios/>
        public CompanyIdentificationTypeI airlineDetail
        {
            get
            {
                return this.airlineDetailField;
            }
            set
            {
                this.airlineDetailField = value;
            }
        }

        /// <comentarios/>
        public ProductIdentificationDetailsTypeI segmentDetail
        {
            get
            {
                return this.segmentDetailField;
            }
            set
            {
                this.segmentDetailField = value;
            }
        }

        /// <comentarios/>
        public string ticketingStatus
        {
            get
            {
                return this.ticketingStatusField;
            }
            set
            {
                this.ticketingStatusField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TPCBRR_16_1_1A")]
    public partial class CompanyIdentificationTypeI
    {

        private string carrierCodeField;

        /// <comentarios/>
        public string carrierCode
        {
            get
            {
                return this.carrierCodeField;
            }
            set
            {
                this.carrierCodeField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TPCBRR_16_1_1A")]
    public partial class ConnectionDetailsTypeI
    {

        private string routingInformationField;

        private string connexTypeField;

        /// <comentarios/>
        public string routingInformation
        {
            get
            {
                return this.routingInformationField;
            }
            set
            {
                this.routingInformationField = value;
            }
        }

        /// <comentarios/>
        public string connexType
        {
            get
            {
                return this.connexTypeField;
            }
            set
            {
                this.connexTypeField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TPCBRR_16_1_1A")]
    public partial class ConnectionTypeI
    {

        private ConnectionDetailsTypeI connecDetailsField;

        /// <comentarios/>
        public ConnectionDetailsTypeI connecDetails
        {
            get
            {
                return this.connecDetailsField;
            }
            set
            {
                this.connecDetailsField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TPCBRR_16_1_1A")]
    public partial class DiscountPenaltyMonetaryInformationTypeI
    {

        private string penaltyTypeField;

        private string penaltyQualifierField;

        private decimal penaltyAmountField;

        private bool penaltyAmountFieldSpecified;

        private string discountCodeField;

        private string penaltyCurrencyField;

        /// <comentarios/>
        public string penaltyType
        {
            get
            {
                return this.penaltyTypeField;
            }
            set
            {
                this.penaltyTypeField = value;
            }
        }

        /// <comentarios/>
        public string penaltyQualifier
        {
            get
            {
                return this.penaltyQualifierField;
            }
            set
            {
                this.penaltyQualifierField = value;
            }
        }

        /// <comentarios/>
        public decimal penaltyAmount
        {
            get
            {
                return this.penaltyAmountField;
            }
            set
            {
                this.penaltyAmountField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool penaltyAmountSpecified
        {
            get
            {
                return this.penaltyAmountFieldSpecified;
            }
            set
            {
                this.penaltyAmountFieldSpecified = value;
            }
        }

        /// <comentarios/>
        public string discountCode
        {
            get
            {
                return this.discountCodeField;
            }
            set
            {
                this.discountCodeField = value;
            }
        }

        /// <comentarios/>
        public string penaltyCurrency
        {
            get
            {
                return this.penaltyCurrencyField;
            }
            set
            {
                this.penaltyCurrencyField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TPCBRR_16_1_1A")]
    public partial class DiscountAndPenaltyInformationTypeI_6128S
    {

        private string infoQualifierField;

        private DiscountPenaltyMonetaryInformationTypeI[] penDisDataField;

        /// <comentarios/>
        public string infoQualifier
        {
            get
            {
                return this.infoQualifierField;
            }
            set
            {
                this.infoQualifierField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("penDisData")]
        public DiscountPenaltyMonetaryInformationTypeI[] penDisData
        {
            get
            {
                return this.penDisDataField;
            }
            set
            {
                this.penDisDataField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TPCBRR_16_1_1A")]
    public partial class ConversionRateDetailsTypeI
    {

        private string currencyCodeField;

        private decimal amountField;

        private bool amountFieldSpecified;

        /// <comentarios/>
        public string currencyCode
        {
            get
            {
                return this.currencyCodeField;
            }
            set
            {
                this.currencyCodeField = value;
            }
        }

        /// <comentarios/>
        public decimal amount
        {
            get
            {
                return this.amountField;
            }
            set
            {
                this.amountField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool amountSpecified
        {
            get
            {
                return this.amountFieldSpecified;
            }
            set
            {
                this.amountFieldSpecified = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TPCBRR_16_1_1A")]
    public partial class ConversionRateTypeI
    {

        private ConversionRateDetailsTypeI firstRateDetailField;

        private ConversionRateDetailsTypeI secondRateDetailField;

        /// <comentarios/>
        public ConversionRateDetailsTypeI firstRateDetail
        {
            get
            {
                return this.firstRateDetailField;
            }
            set
            {
                this.firstRateDetailField = value;
            }
        }

        /// <comentarios/>
        public ConversionRateDetailsTypeI secondRateDetail
        {
            get
            {
                return this.secondRateDetailField;
            }
            set
            {
                this.secondRateDetailField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TPCBRR_16_1_1A")]
    public partial class MonetaryInformationDetailsTypeI
    {

        private string fareDataQualifierField;

        private string fareAmountField;

        private string fareCurrencyField;

        private string fareLocationField;

        /// <comentarios/>
        public string fareDataQualifier
        {
            get
            {
                return this.fareDataQualifierField;
            }
            set
            {
                this.fareDataQualifierField = value;
            }
        }

        /// <comentarios/>
        public string fareAmount
        {
            get
            {
                return this.fareAmountField;
            }
            set
            {
                this.fareAmountField = value;
            }
        }

        /// <comentarios/>
        public string fareCurrency
        {
            get
            {
                return this.fareCurrencyField;
            }
            set
            {
                this.fareCurrencyField = value;
            }
        }

        /// <comentarios/>
        public string fareLocation
        {
            get
            {
                return this.fareLocationField;
            }
            set
            {
                this.fareLocationField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TPCBRR_16_1_1A")]
    public partial class MonetaryInformationTypeI
    {

        private MonetaryInformationDetailsTypeI fareDataMainInformationField;

        private MonetaryInformationDetailsTypeI[] fareDataSupInformationField;

        /// <comentarios/>
        public MonetaryInformationDetailsTypeI fareDataMainInformation
        {
            get
            {
                return this.fareDataMainInformationField;
            }
            set
            {
                this.fareDataMainInformationField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("fareDataSupInformation")]
        public MonetaryInformationDetailsTypeI[] fareDataSupInformation
        {
            get
            {
                return this.fareDataSupInformationField;
            }
            set
            {
                this.fareDataSupInformationField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TPCBRR_16_1_1A")]
    public partial class DutyTaxFeeAccountDetailTypeU
    {

        private string isoCountryField;

        /// <comentarios/>
        public string isoCountry
        {
            get
            {
                return this.isoCountryField;
            }
            set
            {
                this.isoCountryField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TPCBRR_16_1_1A")]
    public partial class DutyTaxFeeTypeDetailsTypeU
    {

        private string taxIdentifierField;

        /// <comentarios/>
        public string taxIdentifier
        {
            get
            {
                return this.taxIdentifierField;
            }
            set
            {
                this.taxIdentifierField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TPCBRR_16_1_1A")]
    public partial class DutyTaxFeeDetailsTypeU
    {

        private string taxQualifierField;

        private DutyTaxFeeTypeDetailsTypeU taxIdentificationField;

        private DutyTaxFeeAccountDetailTypeU taxTypeField;

        private string taxNatureField;

        private string taxExemptField;

        /// <comentarios/>
        public string taxQualifier
        {
            get
            {
                return this.taxQualifierField;
            }
            set
            {
                this.taxQualifierField = value;
            }
        }

        /// <comentarios/>
        public DutyTaxFeeTypeDetailsTypeU taxIdentification
        {
            get
            {
                return this.taxIdentificationField;
            }
            set
            {
                this.taxIdentificationField = value;
            }
        }

        /// <comentarios/>
        public DutyTaxFeeAccountDetailTypeU taxType
        {
            get
            {
                return this.taxTypeField;
            }
            set
            {
                this.taxTypeField = value;
            }
        }

        /// <comentarios/>
        public string taxNature
        {
            get
            {
                return this.taxNatureField;
            }
            set
            {
                this.taxNatureField = value;
            }
        }

        /// <comentarios/>
        public string taxExempt
        {
            get
            {
                return this.taxExemptField;
            }
            set
            {
                this.taxExemptField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TPCBRR_16_1_1A")]
    public partial class MonetaryInformationDetailsType_262564C
    {

        private string fareDataQualifierField;

        private string fareAmountField;

        private string fareCurrencyField;

        private string fareLocationField;

        /// <comentarios/>
        public string fareDataQualifier
        {
            get
            {
                return this.fareDataQualifierField;
            }
            set
            {
                this.fareDataQualifierField = value;
            }
        }

        /// <comentarios/>
        public string fareAmount
        {
            get
            {
                return this.fareAmountField;
            }
            set
            {
                this.fareAmountField = value;
            }
        }

        /// <comentarios/>
        public string fareCurrency
        {
            get
            {
                return this.fareCurrencyField;
            }
            set
            {
                this.fareCurrencyField = value;
            }
        }

        /// <comentarios/>
        public string fareLocation
        {
            get
            {
                return this.fareLocationField;
            }
            set
            {
                this.fareLocationField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TPCBRR_16_1_1A")]
    public partial class MonetaryInformationType_198917S
    {

        private MonetaryInformationDetailsType_262564C fareDataMainInformationField;

        private MonetaryInformationDetailsType_262564C[] fareDataSupInformationField;

        /// <comentarios/>
        public MonetaryInformationDetailsType_262564C fareDataMainInformation
        {
            get
            {
                return this.fareDataMainInformationField;
            }
            set
            {
                this.fareDataMainInformationField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("fareDataSupInformation")]
        public MonetaryInformationDetailsType_262564C[] fareDataSupInformation
        {
            get
            {
                return this.fareDataSupInformationField;
            }
            set
            {
                this.fareDataSupInformationField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TPCBRR_16_1_1A")]
    public partial class ReferencingDetailsTypeI
    {

        private string refQualifierField;

        private string refNumberField;

        /// <comentarios/>
        public string refQualifier
        {
            get
            {
                return this.refQualifierField;
            }
            set
            {
                this.refQualifierField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
        public string refNumber
        {
            get
            {
                return this.refNumberField;
            }
            set
            {
                this.refNumberField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TPCBRR_16_1_1A")]
    public partial class TransportIdentifierType
    {

        private CompanyIdentificationTypeI carrierInformationField;

        /// <comentarios/>
        public CompanyIdentificationTypeI carrierInformation
        {
            get
            {
                return this.carrierInformationField;
            }
            set
            {
                this.carrierInformationField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TPCBRR_16_1_1A")]
    public partial class StructuredDateTimeType_277474C
    {

        private string yearField;

        private string monthField;

        private string dayField;

        private string hourField;

        private string minutesField;

        private string secondsField;

        private string millisecondsField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
        public string year
        {
            get
            {
                return this.yearField;
            }
            set
            {
                this.yearField = value;
            }
        }

        /// <comentarios/>
        public string month
        {
            get
            {
                return this.monthField;
            }
            set
            {
                this.monthField = value;
            }
        }

        /// <comentarios/>
        public string day
        {
            get
            {
                return this.dayField;
            }
            set
            {
                this.dayField = value;
            }
        }

        /// <comentarios/>
        public string hour
        {
            get
            {
                return this.hourField;
            }
            set
            {
                this.hourField = value;
            }
        }

        /// <comentarios/>
        public string minutes
        {
            get
            {
                return this.minutesField;
            }
            set
            {
                this.minutesField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
        public string seconds
        {
            get
            {
                return this.secondsField;
            }
            set
            {
                this.secondsField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
        public string milliseconds
        {
            get
            {
                return this.millisecondsField;
            }
            set
            {
                this.millisecondsField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TPCBRR_16_1_1A")]
    public partial class StructuredDateTimeInformationType_199533S
    {

        private string businessSemanticField;

        private StructuredDateTimeType_277474C dateTimeField;

        /// <comentarios/>
        public string businessSemantic
        {
            get
            {
                return this.businessSemanticField;
            }
            set
            {
                this.businessSemanticField = value;
            }
        }

        /// <comentarios/>
        public StructuredDateTimeType_277474C dateTime
        {
            get
            {
                return this.dateTimeField;
            }
            set
            {
                this.dateTimeField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TPCBRR_16_1_1A")]
    public partial class FareDetailsType
    {

        private string fareCategoryField;

        /// <comentarios/>
        public string fareCategory
        {
            get
            {
                return this.fareCategoryField;
            }
            set
            {
                this.fareCategoryField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TPCBRR_16_1_1A")]
    public partial class FareInformationType
    {

        private FareDetailsType fareDetailsField;

        /// <comentarios/>
        public FareDetailsType fareDetails
        {
            get
            {
                return this.fareDetailsField;
            }
            set
            {
                this.fareDetailsField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TPCBRR_16_1_1A")]
    public partial class ItemReferencesAndVersionsType_94584S
    {

        private string referenceTypeField;

        private string uniqueReferenceField;

        /// <comentarios/>
        public string referenceType
        {
            get
            {
                return this.referenceTypeField;
            }
            set
            {
                this.referenceTypeField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
        public string uniqueReference
        {
            get
            {
                return this.uniqueReferenceField;
            }
            set
            {
                this.uniqueReferenceField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TPCBRR_16_1_1A")]
    public partial class RateTariffClassInformationTypeI
    {

        private string tstIndicatorField;

        /// <comentarios/>
        public string tstIndicator
        {
            get
            {
                return this.tstIndicatorField;
            }
            set
            {
                this.tstIndicatorField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TPCBRR_16_1_1A")]
    public partial class PricingTicketingSubsequentTypeI
    {

        private RateTariffClassInformationTypeI tstInformationField;

        private string salesIndicatorField;

        private string fcmiField;

        private string bestFareTypeField;

        /// <comentarios/>
        public RateTariffClassInformationTypeI tstInformation
        {
            get
            {
                return this.tstInformationField;
            }
            set
            {
                this.tstInformationField = value;
            }
        }

        /// <comentarios/>
        public string salesIndicator
        {
            get
            {
                return this.salesIndicatorField;
            }
            set
            {
                this.salesIndicatorField = value;
            }
        }

        /// <comentarios/>
        public string fcmi
        {
            get
            {
                return this.fcmiField;
            }
            set
            {
                this.fcmiField = value;
            }
        }

        /// <comentarios/>
        public string bestFareType
        {
            get
            {
                return this.bestFareTypeField;
            }
            set
            {
                this.bestFareTypeField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TPCBRR_16_1_1A")]
    public partial class ReservationControlInformationDetailsTypeI
    {

        private string controlNumberField;

        /// <comentarios/>
        public string controlNumber
        {
            get
            {
                return this.controlNumberField;
            }
            set
            {
                this.controlNumberField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TPCBRR_16_1_1A")]
    public partial class ReservationControlInformationTypeI
    {

        private ReservationControlInformationDetailsTypeI reservationInformationField;

        /// <comentarios/>
        public ReservationControlInformationDetailsTypeI reservationInformation
        {
            get
            {
                return this.reservationInformationField;
            }
            set
            {
                this.reservationInformationField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TPCBRR_16_1_1A")]
    public partial class FreeTextDetailsType
    {

        private string textSubjectQualifierField;

        private string informationTypeField;

        private string statusField;

        private string companyIdField;

        private string languageField;

        private string sourceField;

        private string encodingField;

        /// <comentarios/>
        public string textSubjectQualifier
        {
            get
            {
                return this.textSubjectQualifierField;
            }
            set
            {
                this.textSubjectQualifierField = value;
            }
        }

        /// <comentarios/>
        public string informationType
        {
            get
            {
                return this.informationTypeField;
            }
            set
            {
                this.informationTypeField = value;
            }
        }

        /// <comentarios/>
        public string status
        {
            get
            {
                return this.statusField;
            }
            set
            {
                this.statusField = value;
            }
        }

        /// <comentarios/>
        public string companyId
        {
            get
            {
                return this.companyIdField;
            }
            set
            {
                this.companyIdField = value;
            }
        }

        /// <comentarios/>
        public string language
        {
            get
            {
                return this.languageField;
            }
            set
            {
                this.languageField = value;
            }
        }

        /// <comentarios/>
        public string source
        {
            get
            {
                return this.sourceField;
            }
            set
            {
                this.sourceField = value;
            }
        }

        /// <comentarios/>
        public string encoding
        {
            get
            {
                return this.encodingField;
            }
            set
            {
                this.encodingField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TPCBRR_16_1_1A")]
    public partial class FreeTextInformationType
    {

        private FreeTextDetailsType freeTextDetailsField;

        private string[] freeTextField;

        /// <comentarios/>
        public FreeTextDetailsType freeTextDetails
        {
            get
            {
                return this.freeTextDetailsField;
            }
            set
            {
                this.freeTextDetailsField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("freeText")]
        public string[] freeText
        {
            get
            {
                return this.freeTextField;
            }
            set
            {
                this.freeTextField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TPCBRR_16_1_1A")]
    public partial class Fare_PricePNRWithBookingClassReplyFareList
    {

        private PricingTicketingSubsequentTypeI pricingInformationField;

        private ItemReferencesAndVersionsType_94584S fareReferenceField;

        private FareInformationType fareIndicatorsField;

        private StructuredDateTimeInformationType_199533S lastTktDateField;

        private TransportIdentifierType validatingCarrierField;

        private ReferencingDetailsTypeI[] paxSegReferenceField;

        private MonetaryInformationType_198917S fareDataInformationField;

        private Fare_PricePNRWithBookingClassReplyFareListTaxInformation[] taxInformationField;

        private ConversionRateTypeI bankerRatesField;

        private Fare_PricePNRWithBookingClassReplyFareListPassengerInformation[] passengerInformationField;

        private string[] originDestinationField;

        private Fare_PricePNRWithBookingClassReplyFareListSegmentInformation[] segmentInformationField;

        private CodedAttributeType_39223S[] otherPricingInfoField;

        private Fare_PricePNRWithBookingClassReplyFareListWarningInformation[] warningInformationField;

        private Fare_PricePNRWithBookingClassReplyFareListAutomaticReissueInfo automaticReissueInfoField;

        private CorporateFareIdentifiersTypeI[] corporateInfoField;

        private Fare_PricePNRWithBookingClassReplyFareListFeeBreakdown[] feeBreakdownField;

        private AdditionalProductDetailsTypeI mileageField;

        private FareComponentDetailsType[] fareComponentDetailsGroupField;

        private DummySegmentTypeI endFareListField;

        /// <comentarios/>
        public PricingTicketingSubsequentTypeI pricingInformation
        {
            get
            {
                return this.pricingInformationField;
            }
            set
            {
                this.pricingInformationField = value;
            }
        }

        /// <comentarios/>
        public ItemReferencesAndVersionsType_94584S fareReference
        {
            get
            {
                return this.fareReferenceField;
            }
            set
            {
                this.fareReferenceField = value;
            }
        }

        /// <comentarios/>
        public FareInformationType fareIndicators
        {
            get
            {
                return this.fareIndicatorsField;
            }
            set
            {
                this.fareIndicatorsField = value;
            }
        }

        /// <comentarios/>
        public StructuredDateTimeInformationType_199533S lastTktDate
        {
            get
            {
                return this.lastTktDateField;
            }
            set
            {
                this.lastTktDateField = value;
            }
        }

        /// <comentarios/>
        public TransportIdentifierType validatingCarrier
        {
            get
            {
                return this.validatingCarrierField;
            }
            set
            {
                this.validatingCarrierField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayItemAttribute("refDetails", IsNullable = false)]
        public ReferencingDetailsTypeI[] paxSegReference
        {
            get
            {
                return this.paxSegReferenceField;
            }
            set
            {
                this.paxSegReferenceField = value;
            }
        }

        /// <comentarios/>
        public MonetaryInformationType_198917S fareDataInformation
        {
            get
            {
                return this.fareDataInformationField;
            }
            set
            {
                this.fareDataInformationField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("taxInformation")]
        public Fare_PricePNRWithBookingClassReplyFareListTaxInformation[] taxInformation
        {
            get
            {
                return this.taxInformationField;
            }
            set
            {
                this.taxInformationField = value;
            }
        }

        /// <comentarios/>
        public ConversionRateTypeI bankerRates
        {
            get
            {
                return this.bankerRatesField;
            }
            set
            {
                this.bankerRatesField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("passengerInformation")]
        public Fare_PricePNRWithBookingClassReplyFareListPassengerInformation[] passengerInformation
        {
            get
            {
                return this.passengerInformationField;
            }
            set
            {
                this.passengerInformationField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayItemAttribute("cityCode", IsNullable = false)]
        public string[] originDestination
        {
            get
            {
                return this.originDestinationField;
            }
            set
            {
                this.originDestinationField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("segmentInformation")]
        public Fare_PricePNRWithBookingClassReplyFareListSegmentInformation[] segmentInformation
        {
            get
            {
                return this.segmentInformationField;
            }
            set
            {
                this.segmentInformationField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("otherPricingInfo")]
        public CodedAttributeType_39223S[] otherPricingInfo
        {
            get
            {
                return this.otherPricingInfoField;
            }
            set
            {
                this.otherPricingInfoField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("warningInformation")]
        public Fare_PricePNRWithBookingClassReplyFareListWarningInformation[] warningInformation
        {
            get
            {
                return this.warningInformationField;
            }
            set
            {
                this.warningInformationField = value;
            }
        }

        /// <comentarios/>
        public Fare_PricePNRWithBookingClassReplyFareListAutomaticReissueInfo automaticReissueInfo
        {
            get
            {
                return this.automaticReissueInfoField;
            }
            set
            {
                this.automaticReissueInfoField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayItemAttribute("corporateFareIdentifiers", IsNullable = false)]
        public CorporateFareIdentifiersTypeI[] corporateInfo
        {
            get
            {
                return this.corporateInfoField;
            }
            set
            {
                this.corporateInfoField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("feeBreakdown")]
        public Fare_PricePNRWithBookingClassReplyFareListFeeBreakdown[] feeBreakdown
        {
            get
            {
                return this.feeBreakdownField;
            }
            set
            {
                this.feeBreakdownField = value;
            }
        }

        /// <comentarios/>
        public AdditionalProductDetailsTypeI mileage
        {
            get
            {
                return this.mileageField;
            }
            set
            {
                this.mileageField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("fareComponentDetailsGroup")]
        public FareComponentDetailsType[] fareComponentDetailsGroup
        {
            get
            {
                return this.fareComponentDetailsGroupField;
            }
            set
            {
                this.fareComponentDetailsGroupField = value;
            }
        }

        /// <comentarios/>
        public DummySegmentTypeI endFareList
        {
            get
            {
                return this.endFareListField;
            }
            set
            {
                this.endFareListField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TPCBRR_16_1_1A")]
    public partial class Fare_PricePNRWithBookingClassReplyFareListTaxInformation
    {

        private DutyTaxFeeDetailsTypeU taxDetailsField;

        private MonetaryInformationTypeI amountDetailsField;

        /// <comentarios/>
        public DutyTaxFeeDetailsTypeU taxDetails
        {
            get
            {
                return this.taxDetailsField;
            }
            set
            {
                this.taxDetailsField = value;
            }
        }

        /// <comentarios/>
        public MonetaryInformationTypeI amountDetails
        {
            get
            {
                return this.amountDetailsField;
            }
            set
            {
                this.amountDetailsField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TPCBRR_16_1_1A")]
    public partial class Fare_PricePNRWithBookingClassReplyFareListPassengerInformation
    {

        private DiscountAndPenaltyInformationTypeI_6128S penDisInformationField;

        private ReferencingDetailsTypeI[] passengerReferenceField;

        /// <comentarios/>
        public DiscountAndPenaltyInformationTypeI_6128S penDisInformation
        {
            get
            {
                return this.penDisInformationField;
            }
            set
            {
                this.penDisInformationField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayItemAttribute("refDetails", IsNullable = false)]
        public ReferencingDetailsTypeI[] passengerReference
        {
            get
            {
                return this.passengerReferenceField;
            }
            set
            {
                this.passengerReferenceField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TPCBRR_16_1_1A")]
    public partial class Fare_PricePNRWithBookingClassReplyFareListSegmentInformation
    {

        private ConnectionTypeI connexInformationField;

        private TravelProductInformationTypeI_26322S segDetailsField;

        private FareQualifierDetailsTypeI fareQualifierField;

        private Fare_PricePNRWithBookingClassReplyFareListSegmentInformationCabinGroup[] cabinGroupField;

        private StructuredDateTimeInformationType[] validityInformationField;

        private ExcessBaggageTypeI bagAllowanceInformationField;

        private ReferencingDetailsTypeI[] segmentReferenceField;

        private ItemReferencesAndVersionsType sequenceInformationField;

        /// <comentarios/>
        public ConnectionTypeI connexInformation
        {
            get
            {
                return this.connexInformationField;
            }
            set
            {
                this.connexInformationField = value;
            }
        }

        /// <comentarios/>
        public TravelProductInformationTypeI_26322S segDetails
        {
            get
            {
                return this.segDetailsField;
            }
            set
            {
                this.segDetailsField = value;
            }
        }

        /// <comentarios/>
        public FareQualifierDetailsTypeI fareQualifier
        {
            get
            {
                return this.fareQualifierField;
            }
            set
            {
                this.fareQualifierField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("cabinGroup")]
        public Fare_PricePNRWithBookingClassReplyFareListSegmentInformationCabinGroup[] cabinGroup
        {
            get
            {
                return this.cabinGroupField;
            }
            set
            {
                this.cabinGroupField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("validityInformation")]
        public StructuredDateTimeInformationType[] validityInformation
        {
            get
            {
                return this.validityInformationField;
            }
            set
            {
                this.validityInformationField = value;
            }
        }

        /// <comentarios/>
        public ExcessBaggageTypeI bagAllowanceInformation
        {
            get
            {
                return this.bagAllowanceInformationField;
            }
            set
            {
                this.bagAllowanceInformationField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayItemAttribute("refDetails", IsNullable = false)]
        public ReferencingDetailsTypeI[] segmentReference
        {
            get
            {
                return this.segmentReferenceField;
            }
            set
            {
                this.segmentReferenceField = value;
            }
        }

        /// <comentarios/>
        public ItemReferencesAndVersionsType sequenceInformation
        {
            get
            {
                return this.sequenceInformationField;
            }
            set
            {
                this.sequenceInformationField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TPCBRR_16_1_1A")]
    public partial class Fare_PricePNRWithBookingClassReplyFareListSegmentInformationCabinGroup
    {

        private ProductInformationTypeI cabinSegmentField;

        /// <comentarios/>
        public ProductInformationTypeI cabinSegment
        {
            get
            {
                return this.cabinSegmentField;
            }
            set
            {
                this.cabinSegmentField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TPCBRR_16_1_1A")]
    public partial class Fare_PricePNRWithBookingClassReplyFareListWarningInformation
    {

        private ApplicationErrorInformationType warningCodeField;

        private InteractiveFreeTextTypeI_6759S warningTextField;

        /// <comentarios/>
        public ApplicationErrorInformationType warningCode
        {
            get
            {
                return this.warningCodeField;
            }
            set
            {
                this.warningCodeField = value;
            }
        }

        /// <comentarios/>
        public InteractiveFreeTextTypeI_6759S warningText
        {
            get
            {
                return this.warningTextField;
            }
            set
            {
                this.warningTextField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TPCBRR_16_1_1A")]
    public partial class Fare_PricePNRWithBookingClassReplyFareListAutomaticReissueInfo
    {

        private TicketNumberTypeI ticketInfoField;

        private CouponInformationTypeI couponInfoField;

        private Fare_PricePNRWithBookingClassReplyFareListAutomaticReissueInfoPaperCouponRange paperCouponRangeField;

        private MonetaryInformationTypeI_20897S baseFareInfoField;

        private Fare_PricePNRWithBookingClassReplyFareListAutomaticReissueInfoFirstDpiGroup firstDpiGroupField;

        private Fare_PricePNRWithBookingClassReplyFareListAutomaticReissueInfoSecondDpiGroup secondDpiGroupField;

        private CodedAttributeInformationType[] reissueAttributesField;

        /// <comentarios/>
        public TicketNumberTypeI ticketInfo
        {
            get
            {
                return this.ticketInfoField;
            }
            set
            {
                this.ticketInfoField = value;
            }
        }

        /// <comentarios/>
        public CouponInformationTypeI couponInfo
        {
            get
            {
                return this.couponInfoField;
            }
            set
            {
                this.couponInfoField = value;
            }
        }

        /// <comentarios/>
        public Fare_PricePNRWithBookingClassReplyFareListAutomaticReissueInfoPaperCouponRange paperCouponRange
        {
            get
            {
                return this.paperCouponRangeField;
            }
            set
            {
                this.paperCouponRangeField = value;
            }
        }

        /// <comentarios/>
        public MonetaryInformationTypeI_20897S baseFareInfo
        {
            get
            {
                return this.baseFareInfoField;
            }
            set
            {
                this.baseFareInfoField = value;
            }
        }

        /// <comentarios/>
        public Fare_PricePNRWithBookingClassReplyFareListAutomaticReissueInfoFirstDpiGroup firstDpiGroup
        {
            get
            {
                return this.firstDpiGroupField;
            }
            set
            {
                this.firstDpiGroupField = value;
            }
        }

        /// <comentarios/>
        public Fare_PricePNRWithBookingClassReplyFareListAutomaticReissueInfoSecondDpiGroup secondDpiGroup
        {
            get
            {
                return this.secondDpiGroupField;
            }
            set
            {
                this.secondDpiGroupField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayItemAttribute("attributeDetails", IsNullable = false)]
        public CodedAttributeInformationType[] reissueAttributes
        {
            get
            {
                return this.reissueAttributesField;
            }
            set
            {
                this.reissueAttributesField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TPCBRR_16_1_1A")]
    public partial class Fare_PricePNRWithBookingClassReplyFareListAutomaticReissueInfoPaperCouponRange
    {

        private TicketNumberTypeI ticketInfoField;

        private CouponInformationTypeI couponInfoField;

        /// <comentarios/>
        public TicketNumberTypeI ticketInfo
        {
            get
            {
                return this.ticketInfoField;
            }
            set
            {
                this.ticketInfoField = value;
            }
        }

        /// <comentarios/>
        public CouponInformationTypeI couponInfo
        {
            get
            {
                return this.couponInfoField;
            }
            set
            {
                this.couponInfoField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TPCBRR_16_1_1A")]
    public partial class Fare_PricePNRWithBookingClassReplyFareListAutomaticReissueInfoFirstDpiGroup
    {

        private DiscountAndPenaltyInformationTypeI reIssuePenaltyField;

        private MonetaryInformationTypeI_20897S reissueInfoField;

        private MonetaryInformationTypeI_20897S oldTaxInfoField;

        private MonetaryInformationTypeI_20897S reissueBalanceInfoField;

        /// <comentarios/>
        public DiscountAndPenaltyInformationTypeI reIssuePenalty
        {
            get
            {
                return this.reIssuePenaltyField;
            }
            set
            {
                this.reIssuePenaltyField = value;
            }
        }

        /// <comentarios/>
        public MonetaryInformationTypeI_20897S reissueInfo
        {
            get
            {
                return this.reissueInfoField;
            }
            set
            {
                this.reissueInfoField = value;
            }
        }

        /// <comentarios/>
        public MonetaryInformationTypeI_20897S oldTaxInfo
        {
            get
            {
                return this.oldTaxInfoField;
            }
            set
            {
                this.oldTaxInfoField = value;
            }
        }

        /// <comentarios/>
        public MonetaryInformationTypeI_20897S reissueBalanceInfo
        {
            get
            {
                return this.reissueBalanceInfoField;
            }
            set
            {
                this.reissueBalanceInfoField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TPCBRR_16_1_1A")]
    public partial class Fare_PricePNRWithBookingClassReplyFareListAutomaticReissueInfoSecondDpiGroup
    {

        private DiscountAndPenaltyInformationTypeI penaltyField;

        private MonetaryInformationTypeI_20897S residualValueInfoField;

        private MonetaryInformationTypeI_20897S oldTaxInfoField;

        private MonetaryInformationTypeI_20897S issueBalanceInfoField;

        /// <comentarios/>
        public DiscountAndPenaltyInformationTypeI penalty
        {
            get
            {
                return this.penaltyField;
            }
            set
            {
                this.penaltyField = value;
            }
        }

        /// <comentarios/>
        public MonetaryInformationTypeI_20897S residualValueInfo
        {
            get
            {
                return this.residualValueInfoField;
            }
            set
            {
                this.residualValueInfoField = value;
            }
        }

        /// <comentarios/>
        public MonetaryInformationTypeI_20897S oldTaxInfo
        {
            get
            {
                return this.oldTaxInfoField;
            }
            set
            {
                this.oldTaxInfoField = value;
            }
        }

        /// <comentarios/>
        public MonetaryInformationTypeI_20897S issueBalanceInfo
        {
            get
            {
                return this.issueBalanceInfoField;
            }
            set
            {
                this.issueBalanceInfoField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TPCBRR_16_1_1A")]
    public partial class Fare_PricePNRWithBookingClassReplyFareListFeeBreakdown
    {

        private SelectionDetailsTypeI feeTypeField;

        private Fare_PricePNRWithBookingClassReplyFareListFeeBreakdownFeeDetails[] feeDetailsField;

        /// <comentarios/>
        public SelectionDetailsTypeI feeType
        {
            get
            {
                return this.feeTypeField;
            }
            set
            {
                this.feeTypeField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("feeDetails")]
        public Fare_PricePNRWithBookingClassReplyFareListFeeBreakdownFeeDetails[] feeDetails
        {
            get
            {
                return this.feeDetailsField;
            }
            set
            {
                this.feeDetailsField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TPCBRR_16_1_1A")]
    public partial class Fare_PricePNRWithBookingClassReplyFareListFeeBreakdownFeeDetails
    {

        private SpecificDataInformationTypeI feeInfoField;

        private InteractiveFreeTextTypeI feeDescriptionField;

        private MonetaryInformationDetailsTypeI_63727C[] feeAmountsField;

        private TaxTypeI[] feeTaxesField;

        /// <comentarios/>
        public SpecificDataInformationTypeI feeInfo
        {
            get
            {
                return this.feeInfoField;
            }
            set
            {
                this.feeInfoField = value;
            }
        }

        /// <comentarios/>
        public InteractiveFreeTextTypeI feeDescription
        {
            get
            {
                return this.feeDescriptionField;
            }
            set
            {
                this.feeDescriptionField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayItemAttribute("monetaryDetails", IsNullable = false)]
        public MonetaryInformationDetailsTypeI_63727C[] feeAmounts
        {
            get
            {
                return this.feeAmountsField;
            }
            set
            {
                this.feeAmountsField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("feeTaxes")]
        public TaxTypeI[] feeTaxes
        {
            get
            {
                return this.feeTaxesField;
            }
            set
            {
                this.feeTaxesField = value;
            }
        }
    }
}

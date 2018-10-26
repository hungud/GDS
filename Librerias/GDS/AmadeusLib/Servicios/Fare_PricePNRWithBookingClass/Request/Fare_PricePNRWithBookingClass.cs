using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AmadeusLib.Servicios.Fare_PricePNRWithBookingClass.Request
{
    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TPCBRQ_16_1_1A")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://xml.amadeus.com/TPCBRQ_16_1_1A", IsNullable = false)]
    public partial class Fare_PricePNRWithBookingClass
    {

        private Fare_PricePNRWithBookingClassPricingOptionGroup[] pricingOptionGroupField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("pricingOptionGroup")]
        public Fare_PricePNRWithBookingClassPricingOptionGroup[] pricingOptionGroup
        {
            get
            {
                return this.pricingOptionGroupField;
            }
            set
            {
                this.pricingOptionGroupField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TPCBRQ_16_1_1A")]
    public partial class Fare_PricePNRWithBookingClassPricingOptionGroup
    {

        private PricingOptionKey pricingOptionKeyField;

        private AttributeInformationTypeU[] optionDetailField;

        private TransportIdentifierType carrierInformationField;

        private CurrenciesType currencyField;

        private DiscountAndPenaltyInformationType penDisInformationField;

        private MonetaryInformationType monetaryInformationField;

        private DutyTaxFeeDetailsType[] taxInformationField;

        private StructuredDateTimeInformationType[] dateInformationField;

        private FrequentTravellerIdentificationType[] frequentFlyerInformationField;

        private FormOfPaymentType formOfPaymentInformationField;

        private PlaceLocationIdentificationType locationInformationField;

        private ReferencingDetailsType[] paxSegTstReferenceField;

        /// <comentarios/>
        public PricingOptionKey pricingOptionKey
        {
            get
            {
                return this.pricingOptionKeyField;
            }
            set
            {
                this.pricingOptionKeyField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayItemAttribute("criteriaDetails", IsNullable = false)]
        public AttributeInformationTypeU[] optionDetail
        {
            get
            {
                return this.optionDetailField;
            }
            set
            {
                this.optionDetailField = value;
            }
        }

        /// <comentarios/>
        public TransportIdentifierType carrierInformation
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

        /// <comentarios/>
        public CurrenciesType currency
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
        public DiscountAndPenaltyInformationType penDisInformation
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
        public MonetaryInformationType monetaryInformation
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
        [System.Xml.Serialization.XmlElementAttribute("taxInformation")]
        public DutyTaxFeeDetailsType[] taxInformation
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
        [System.Xml.Serialization.XmlElementAttribute("dateInformation")]
        public StructuredDateTimeInformationType[] dateInformation
        {
            get
            {
                return this.dateInformationField;
            }
            set
            {
                this.dateInformationField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayItemAttribute("frequentTravellerDetails", IsNullable = false)]
        public FrequentTravellerIdentificationType[] frequentFlyerInformation
        {
            get
            {
                return this.frequentFlyerInformationField;
            }
            set
            {
                this.frequentFlyerInformationField = value;
            }
        }

        /// <comentarios/>
        public FormOfPaymentType formOfPaymentInformation
        {
            get
            {
                return this.formOfPaymentInformationField;
            }
            set
            {
                this.formOfPaymentInformationField = value;
            }
        }

        /// <comentarios/>
        public PlaceLocationIdentificationType locationInformation
        {
            get
            {
                return this.locationInformationField;
            }
            set
            {
                this.locationInformationField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayItemAttribute("referenceDetails", IsNullable = false)]
        public ReferencingDetailsType[] paxSegTstReference
        {
            get
            {
                return this.paxSegTstReferenceField;
            }
            set
            {
                this.paxSegTstReferenceField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TPCBRQ_16_1_1A")]
    public partial class PricingOptionKey
    {

        private string pricingOptionKeyField;

        /// <comentarios/>
        public string pricingOptionKey
        {
            get
            {
                return this.pricingOptionKeyField;
            }
            set
            {
                this.pricingOptionKeyField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TPCBRQ_16_1_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TPCBRQ_16_1_1A")]
    public partial class RelatedLocationTwoIdentificationType
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TPCBRQ_16_1_1A")]
    public partial class RelatedLocationOneIdentificationType
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TPCBRQ_16_1_1A")]
    public partial class PlaceLocationIdentificationType
    {

        private string locationTypeField;

        private RelatedLocationOneIdentificationType firstLocationDetailsField;

        private RelatedLocationTwoIdentificationType secondLocationDetailsField;

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
        public RelatedLocationOneIdentificationType firstLocationDetails
        {
            get
            {
                return this.firstLocationDetailsField;
            }
            set
            {
                this.firstLocationDetailsField = value;
            }
        }

        /// <comentarios/>
        public RelatedLocationTwoIdentificationType secondLocationDetails
        {
            get
            {
                return this.secondLocationDetailsField;
            }
            set
            {
                this.secondLocationDetailsField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TPCBRQ_16_1_1A")]
    public partial class FormOfPaymentDetailsType
    {

        private string typeField;

        private decimal amountField;

        private bool amountFieldSpecified;

        private string creditCardNumberField;

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
        public string creditCardNumber
        {
            get
            {
                return this.creditCardNumberField;
            }
            set
            {
                this.creditCardNumberField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TPCBRQ_16_1_1A")]
    public partial class FormOfPaymentType
    {

        private FormOfPaymentDetailsType formOfPaymentField;

        private FormOfPaymentDetailsType[] otherFormOfPaymentField;

        /// <comentarios/>
        public FormOfPaymentDetailsType formOfPayment
        {
            get
            {
                return this.formOfPaymentField;
            }
            set
            {
                this.formOfPaymentField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("otherFormOfPayment")]
        public FormOfPaymentDetailsType[] otherFormOfPayment
        {
            get
            {
                return this.otherFormOfPaymentField;
            }
            set
            {
                this.otherFormOfPaymentField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TPCBRQ_16_1_1A")]
    public partial class FrequentTravellerIdentificationType
    {

        private string carrierField;

        private string numberField;

        private string tierLevelField;

        private string priorityCodeField;

        /// <comentarios/>
        public string carrier
        {
            get
            {
                return this.carrierField;
            }
            set
            {
                this.carrierField = value;
            }
        }

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
        public string tierLevel
        {
            get
            {
                return this.tierLevelField;
            }
            set
            {
                this.tierLevelField = value;
            }
        }

        /// <comentarios/>
        public string priorityCode
        {
            get
            {
                return this.priorityCodeField;
            }
            set
            {
                this.priorityCodeField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TPCBRQ_16_1_1A")]
    public partial class StructuredDateTimeType
    {

        private string yearField;

        private string monthField;

        private string dayField;

        /// <comentarios/>
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TPCBRQ_16_1_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TPCBRQ_16_1_1A")]
    public partial class DutyTaxFeeDetailType
    {

        private string taxRateField;

        private string taxValueQualifierField;

        /// <comentarios/>
        public string taxRate
        {
            get
            {
                return this.taxRateField;
            }
            set
            {
                this.taxRateField = value;
            }
        }

        /// <comentarios/>
        public string taxValueQualifier
        {
            get
            {
                return this.taxValueQualifierField;
            }
            set
            {
                this.taxValueQualifierField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TPCBRQ_16_1_1A")]
    public partial class DutyTaxFeeAccountDetailType
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TPCBRQ_16_1_1A")]
    public partial class DutyTaxFeeDetailsType
    {

        private string taxQualifierField;

        private DutyTaxFeeAccountDetailType taxTypeField;

        private string taxNatureField;

        private DutyTaxFeeDetailType taxDataField;

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
        public DutyTaxFeeAccountDetailType taxType
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
        public DutyTaxFeeDetailType taxData
        {
            get
            {
                return this.taxDataField;
            }
            set
            {
                this.taxDataField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TPCBRQ_16_1_1A")]
    public partial class MonetaryInformationDetailsType
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TPCBRQ_16_1_1A")]
    public partial class MonetaryInformationType
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TPCBRQ_16_1_1A")]
    public partial class DiscountPenaltyMonetaryInformationType
    {

        private string functionField;

        private string amountTypeField;

        private string amountField;

        private string rateField;

        private string currencyField;

        /// <comentarios/>
        public string function
        {
            get
            {
                return this.functionField;
            }
            set
            {
                this.functionField = value;
            }
        }

        /// <comentarios/>
        public string amountType
        {
            get
            {
                return this.amountTypeField;
            }
            set
            {
                this.amountTypeField = value;
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TPCBRQ_16_1_1A")]
    public partial class DiscountAndPenaltyInformationType
    {

        private string discountPenaltyQualifierField;

        private DiscountPenaltyMonetaryInformationType[] discountPenaltyDetailsField;

        /// <comentarios/>
        public string discountPenaltyQualifier
        {
            get
            {
                return this.discountPenaltyQualifierField;
            }
            set
            {
                this.discountPenaltyQualifierField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("discountPenaltyDetails")]
        public DiscountPenaltyMonetaryInformationType[] discountPenaltyDetails
        {
            get
            {
                return this.discountPenaltyDetailsField;
            }
            set
            {
                this.discountPenaltyDetailsField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TPCBRQ_16_1_1A")]
    public partial class CurrencyDetailsTypeU
    {

        private string currencyQualifierField;

        private string currencyIsoCodeField;

        /// <comentarios/>
        public string currencyQualifier
        {
            get
            {
                return this.currencyQualifierField;
            }
            set
            {
                this.currencyQualifierField = value;
            }
        }

        /// <comentarios/>
        public string currencyIsoCode
        {
            get
            {
                return this.currencyIsoCodeField;
            }
            set
            {
                this.currencyIsoCodeField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TPCBRQ_16_1_1A")]
    public partial class CurrenciesType
    {

        private CurrencyDetailsTypeU firstCurrencyDetailsField;

        /// <comentarios/>
        public CurrencyDetailsTypeU firstCurrencyDetails
        {
            get
            {
                return this.firstCurrencyDetailsField;
            }
            set
            {
                this.firstCurrencyDetailsField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TPCBRQ_16_1_1A")]
    public partial class CompanyIdentificationTypeI
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TPCBRQ_16_1_1A")]
    public partial class TransportIdentifierType
    {

        private CompanyIdentificationTypeI companyIdentificationField;

        /// <comentarios/>
        public CompanyIdentificationTypeI companyIdentification
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TPCBRQ_16_1_1A")]
    public partial class AttributeInformationTypeU
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
}

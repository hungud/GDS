using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmadeusLib.Servicios.Ticket_RepricePNRWithBookingClass.Request
{
    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TARIPQ_12_2_1A")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://xml.amadeus.com/TARIPQ_12_2_1A", IsNullable = false)]
    public partial class Ticket_RepricePNRWithBookingClass
    {

        private Ticket_RepricePNRWithBookingClassTicketInfo[] ticketInfoField;

        private ReferencingDetailsTypeI[] pasSegmentSelectionField;

        private StatusTypeI typeRepriceField;

        private MonetaryInformationType instantRePricingOptionField;

        private Ticket_RepricePNRWithBookingClassReissuelPricingOptionsGroup reissuelPricingOptionsGroupField;

        private Ticket_RepricePNRWithBookingClassFlightInformation[] flightInformationField;

        private FrequentFlyerInformationGroupType frequentFlyerInformationGroupField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("ticketInfo")]
        public Ticket_RepricePNRWithBookingClassTicketInfo[] ticketInfo
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
        [System.Xml.Serialization.XmlArrayItemAttribute("referenceDetails", IsNullable = false)]
        public ReferencingDetailsTypeI[] pasSegmentSelection
        {
            get
            {
                return this.pasSegmentSelectionField;
            }
            set
            {
                this.pasSegmentSelectionField = value;
            }
        }

        /// <comentarios/>
        public StatusTypeI typeReprice
        {
            get
            {
                return this.typeRepriceField;
            }
            set
            {
                this.typeRepriceField = value;
            }
        }

        /// <comentarios/>
        public MonetaryInformationType instantRePricingOption
        {
            get
            {
                return this.instantRePricingOptionField;
            }
            set
            {
                this.instantRePricingOptionField = value;
            }
        }

        /// <comentarios/>
        public Ticket_RepricePNRWithBookingClassReissuelPricingOptionsGroup reissuelPricingOptionsGroup
        {
            get
            {
                return this.reissuelPricingOptionsGroupField;
            }
            set
            {
                this.reissuelPricingOptionsGroupField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("flightInformation")]
        public Ticket_RepricePNRWithBookingClassFlightInformation[] flightInformation
        {
            get
            {
                return this.flightInformationField;
            }
            set
            {
                this.flightInformationField = value;
            }
        }

        /// <comentarios/>
        public FrequentFlyerInformationGroupType frequentFlyerInformationGroup
        {
            get
            {
                return this.frequentFlyerInformationGroupField;
            }
            set
            {
                this.frequentFlyerInformationGroupField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TARIPQ_12_2_1A")]
    public partial class Ticket_RepricePNRWithBookingClassTicketInfo
    {

        private TicketNumberTypeI paperticketDetailsFirstCouponField;

        private CouponInformationTypeI couponInfoFirstField;

        private Ticket_RepricePNRWithBookingClassTicketInfoPaperInformation paperInformationField;

        private CodedAttributeInformationType[] overridePaxInformationField;

        private ReferenceInformationTypeI_155154S passengerSelectionField;

        /// <comentarios/>
        public TicketNumberTypeI paperticketDetailsFirstCoupon
        {
            get
            {
                return this.paperticketDetailsFirstCouponField;
            }
            set
            {
                this.paperticketDetailsFirstCouponField = value;
            }
        }

        /// <comentarios/>
        public CouponInformationTypeI couponInfoFirst
        {
            get
            {
                return this.couponInfoFirstField;
            }
            set
            {
                this.couponInfoFirstField = value;
            }
        }

        /// <comentarios/>
        public Ticket_RepricePNRWithBookingClassTicketInfoPaperInformation paperInformation
        {
            get
            {
                return this.paperInformationField;
            }
            set
            {
                this.paperInformationField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayItemAttribute("attributeDetails", IsNullable = false)]
        public CodedAttributeInformationType[] overridePaxInformation
        {
            get
            {
                return this.overridePaxInformationField;
            }
            set
            {
                this.overridePaxInformationField = value;
            }
        }

        /// <comentarios/>
        public ReferenceInformationTypeI_155154S passengerSelection
        {
            get
            {
                return this.passengerSelectionField;
            }
            set
            {
                this.passengerSelectionField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TARIPQ_12_2_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TARIPQ_12_2_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TARIPQ_12_2_1A")]
    public partial class TravelItineraryInformationTypeI
    {

        private string globalRouteField;

        private string bookingClassField;

        private ProductTypeDetailsTypeI flightDetailsField;

        /// <comentarios/>
        public string globalRoute
        {
            get
            {
                return this.globalRouteField;
            }
            set
            {
                this.globalRouteField = value;
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
        public ProductTypeDetailsTypeI flightDetails
        {
            get
            {
                return this.flightDetailsField;
            }
            set
            {
                this.flightDetailsField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TARIPQ_12_2_1A")]
    public partial class ProductTypeDetailsTypeI
    {

        private string flightTypeField;

        private string[] otherFlightTypesField;

        /// <comentarios/>
        public string flightType
        {
            get
            {
                return this.flightTypeField;
            }
            set
            {
                this.flightTypeField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("otherFlightTypes")]
        public string[] otherFlightTypes
        {
            get
            {
                return this.otherFlightTypesField;
            }
            set
            {
                this.otherFlightTypesField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TARIPQ_12_2_1A")]
    public partial class ReferencingDetailsTypeI_221371C
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TARIPQ_12_2_1A")]
    public partial class PricingTicketingDetailsTypeI
    {

        private string waiverCodeField;

        /// <comentarios/>
        public string waiverCode
        {
            get
            {
                return this.waiverCodeField;
            }
            set
            {
                this.waiverCodeField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TARIPQ_12_2_1A")]
    public partial class ReferencingDetailsType_221370C
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TARIPQ_12_2_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TARIPQ_12_2_1A")]
    public partial class FrequentTravellerIdentificationType
    {

        private string carrierField;

        private string tierLevelField;

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
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TARIPQ_12_2_1A")]
    public partial class FrequentTravellerIdentificationCodeType
    {

        private FrequentTravellerIdentificationType frequentTravellerDetailsField;

        /// <comentarios/>
        public FrequentTravellerIdentificationType frequentTravellerDetails
        {
            get
            {
                return this.frequentTravellerDetailsField;
            }
            set
            {
                this.frequentTravellerDetailsField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TARIPQ_12_2_1A")]
    public partial class FrequentFlyerInformationGroupType
    {

        private FrequentTravellerIdentificationCodeType flequentFlyerdetailsField;

        private ReferencingDetailsType[] passengerReferenceField;

        private ReferencingDetailsType_221370C[] flightReferenceField;

        /// <comentarios/>
        public FrequentTravellerIdentificationCodeType flequentFlyerdetails
        {
            get
            {
                return this.flequentFlyerdetailsField;
            }
            set
            {
                this.flequentFlyerdetailsField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayItemAttribute("passengerReference", IsNullable = false)]
        public ReferencingDetailsType[] passengerReference
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

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayItemAttribute("referenceDetails", IsNullable = false)]
        public ReferencingDetailsType_221370C[] flightReference
        {
            get
            {
                return this.flightReferenceField;
            }
            set
            {
                this.flightReferenceField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TARIPQ_12_2_1A")]
    public partial class ReferenceInformationTypeI_155169S
    {

        private ReferencingDetailsTypeI[] referenceDetailsField;

        private object dummyNETField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("referenceDetails")]
        public ReferencingDetailsTypeI[] referenceDetails
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TARIPQ_12_2_1A")]
    public partial class ReferencingDetailsTypeI
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TARIPQ_12_2_1A")]
    public partial class RateTariffClassInformationTypeI
    {

        private string rateTariffClassField;

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
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TARIPQ_12_2_1A")]
    public partial class PricingTicketingSubsequentTypeI
    {

        private RateTariffClassInformationTypeI fareBasisDetailsField;

        /// <comentarios/>
        public RateTariffClassInformationTypeI fareBasisDetails
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TARIPQ_12_2_1A")]
    public partial class ReferencingDetailsTypeI_221394C
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TARIPQ_12_2_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TARIPQ_12_2_1A")]
    public partial class DiscountAndPenaltyInformationTypeI
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TARIPQ_12_2_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TARIPQ_12_2_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TARIPQ_12_2_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TARIPQ_12_2_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TARIPQ_12_2_1A")]
    public partial class DutyTaxFeeTypeDetailsType
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TARIPQ_12_2_1A")]
    public partial class DutyTaxFeeDetailsType
    {

        private string taxQualifierField;

        private DutyTaxFeeTypeDetailsType taxIdentificationField;

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
        public DutyTaxFeeTypeDetailsType taxIdentification
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TARIPQ_12_2_1A")]
    public partial class MonetaryInformationDetailsTypeI
    {

        private string typeQualifierField;

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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TARIPQ_12_2_1A")]
    public partial class MonetaryInformationType_155161S
    {

        private MonetaryInformationDetailsTypeI monetaryDetailsField;

        private MonetaryInformationDetailsTypeI[] otherMonetaryDetailsField;

        /// <comentarios/>
        public MonetaryInformationDetailsTypeI monetaryDetails
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
        public MonetaryInformationDetailsTypeI[] otherMonetaryDetails
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TARIPQ_12_2_1A")]
    public partial class LocationTypeU
    {

        private string cityCodeField;

        private string cityQualifierField;

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

        /// <comentarios/>
        public string cityQualifier
        {
            get
            {
                return this.cityQualifierField;
            }
            set
            {
                this.cityQualifierField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TARIPQ_12_2_1A")]
    public partial class MonetaryInformationDetailsType
    {

        private string typeQualifierField;

        private decimal amountField;

        private bool amountFieldSpecified;

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
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TARIPQ_12_2_1A")]
    public partial class MonetaryInformationType
    {

        private MonetaryInformationDetailsType monetaryDetailsField;

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
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TARIPQ_12_2_1A")]
    public partial class StatusDetailsTypeI
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TARIPQ_12_2_1A")]
    public partial class StatusTypeI
    {

        private StatusDetailsTypeI statusDetailsField;

        /// <comentarios/>
        public StatusDetailsTypeI statusDetails
        {
            get
            {
                return this.statusDetailsField;
            }
            set
            {
                this.statusDetailsField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TARIPQ_12_2_1A")]
    public partial class ReferencingDetailsTypeI_221377C
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TARIPQ_12_2_1A")]
    public partial class ReferenceInformationTypeI_155154S
    {

        private ReferencingDetailsTypeI_221377C referenceDetailsField;

        /// <comentarios/>
        public ReferencingDetailsTypeI_221377C referenceDetails
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TARIPQ_12_2_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TARIPQ_12_2_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TARIPQ_12_2_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TARIPQ_12_2_1A")]
    public partial class Ticket_RepricePNRWithBookingClassTicketInfoPaperInformation
    {

        private TicketNumberTypeI paperticketDetailsLastCouponField;

        private CouponInformationTypeI papercouponInfoLastField;

        private Ticket_RepricePNRWithBookingClassTicketInfoPaperInformationTicketRange ticketRangeField;

        /// <comentarios/>
        public TicketNumberTypeI paperticketDetailsLastCoupon
        {
            get
            {
                return this.paperticketDetailsLastCouponField;
            }
            set
            {
                this.paperticketDetailsLastCouponField = value;
            }
        }

        /// <comentarios/>
        public CouponInformationTypeI papercouponInfoLast
        {
            get
            {
                return this.papercouponInfoLastField;
            }
            set
            {
                this.papercouponInfoLastField = value;
            }
        }

        /// <comentarios/>
        public Ticket_RepricePNRWithBookingClassTicketInfoPaperInformationTicketRange ticketRange
        {
            get
            {
                return this.ticketRangeField;
            }
            set
            {
                this.ticketRangeField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TARIPQ_12_2_1A")]
    public partial class Ticket_RepricePNRWithBookingClassTicketInfoPaperInformationTicketRange
    {

        private TicketNumberTypeI paperticketDetailsfirstField;

        private TicketNumberTypeI paperticketDetailsLastField;

        /// <comentarios/>
        public TicketNumberTypeI paperticketDetailsfirst
        {
            get
            {
                return this.paperticketDetailsfirstField;
            }
            set
            {
                this.paperticketDetailsfirstField = value;
            }
        }

        /// <comentarios/>
        public TicketNumberTypeI paperticketDetailsLast
        {
            get
            {
                return this.paperticketDetailsLastField;
            }
            set
            {
                this.paperticketDetailsLastField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TARIPQ_12_2_1A")]
    public partial class Ticket_RepricePNRWithBookingClassReissuelPricingOptionsGroup
    {

        private CodedAttributeInformationType[] overrideInformationField;

        private LocationTypeU[] cityOverrideField;

        private MonetaryInformationType_155161S overrideCurrencyField;

        private DutyTaxFeeDetailsType[] taxDetailsField;

        private StructuredDateTimeInformationType dateOverrideField;

        private Ticket_RepricePNRWithBookingClassReissuelPricingOptionsGroupDiscountInformation[] discountInformationField;

        private Ticket_RepricePNRWithBookingClassReissuelPricingOptionsGroupPricingFareBase[] pricingFareBaseField;

        private PricingTicketingDetailsTypeI pricingOptionField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayItemAttribute("attributeDetails", IsNullable = false)]
        public CodedAttributeInformationType[] overrideInformation
        {
            get
            {
                return this.overrideInformationField;
            }
            set
            {
                this.overrideInformationField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayItemAttribute("cityDetail", IsNullable = false)]
        public LocationTypeU[] cityOverride
        {
            get
            {
                return this.cityOverrideField;
            }
            set
            {
                this.cityOverrideField = value;
            }
        }

        /// <comentarios/>
        public MonetaryInformationType_155161S overrideCurrency
        {
            get
            {
                return this.overrideCurrencyField;
            }
            set
            {
                this.overrideCurrencyField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("taxDetails")]
        public DutyTaxFeeDetailsType[] taxDetails
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
        public StructuredDateTimeInformationType dateOverride
        {
            get
            {
                return this.dateOverrideField;
            }
            set
            {
                this.dateOverrideField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("discountInformation")]
        public Ticket_RepricePNRWithBookingClassReissuelPricingOptionsGroupDiscountInformation[] discountInformation
        {
            get
            {
                return this.discountInformationField;
            }
            set
            {
                this.discountInformationField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("pricingFareBase")]
        public Ticket_RepricePNRWithBookingClassReissuelPricingOptionsGroupPricingFareBase[] pricingFareBase
        {
            get
            {
                return this.pricingFareBaseField;
            }
            set
            {
                this.pricingFareBaseField = value;
            }
        }

        /// <comentarios/>
        public PricingTicketingDetailsTypeI pricingOption
        {
            get
            {
                return this.pricingOptionField;
            }
            set
            {
                this.pricingOptionField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TARIPQ_12_2_1A")]
    public partial class Ticket_RepricePNRWithBookingClassReissuelPricingOptionsGroupDiscountInformation
    {

        private DiscountAndPenaltyInformationTypeI penDisInformationField;

        private ReferencingDetailsTypeI_221394C[] referenceQualifierField;

        /// <comentarios/>
        public DiscountAndPenaltyInformationTypeI penDisInformation
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
        public ReferencingDetailsTypeI_221394C[] referenceQualifier
        {
            get
            {
                return this.referenceQualifierField;
            }
            set
            {
                this.referenceQualifierField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TARIPQ_12_2_1A")]
    public partial class Ticket_RepricePNRWithBookingClassReissuelPricingOptionsGroupPricingFareBase
    {

        private PricingTicketingSubsequentTypeI fareBasisField;

        private ReferenceInformationTypeI_155169S[] referenceQualifierField;

        /// <comentarios/>
        public PricingTicketingSubsequentTypeI fareBasis
        {
            get
            {
                return this.fareBasisField;
            }
            set
            {
                this.fareBasisField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("referenceQualifier")]
        public ReferenceInformationTypeI_155169S[] referenceQualifier
        {
            get
            {
                return this.referenceQualifierField;
            }
            set
            {
                this.referenceQualifierField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TARIPQ_12_2_1A")]
    public partial class Ticket_RepricePNRWithBookingClassFlightInformation
    {

        private TravelItineraryInformationTypeI itineraryOptionsField;

        private ReferencingDetailsTypeI_221371C[] itinerarySegReferenceField;

        /// <comentarios/>
        public TravelItineraryInformationTypeI itineraryOptions
        {
            get
            {
                return this.itineraryOptionsField;
            }
            set
            {
                this.itineraryOptionsField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayItemAttribute("refDetails", IsNullable = false)]
        public ReferencingDetailsTypeI_221371C[] itinerarySegReference
        {
            get
            {
                return this.itinerarySegReferenceField;
            }
            set
            {
                this.itinerarySegReferenceField = value;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmadeusLib.Servicios.Ticket_RepricePNRWithBookingClass.Response
{
    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TARIPR_12_2_1A")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://xml.amadeus.com/TARIPR_12_2_1A", IsNullable = false)]
    public partial class Ticket_RepricePNRWithBookingClassReply
    {

        private Ticket_RepricePNRWithBookingClassReplyApplicationError applicationErrorField;

        private ReservationControlInformationTypeI pnrLocatorDataField;

        private Ticket_RepricePNRWithBookingClassReplyFareList[] fareListField;

        /// <comentarios/>
        public Ticket_RepricePNRWithBookingClassReplyApplicationError applicationError
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
        public Ticket_RepricePNRWithBookingClassReplyFareList[] fareList
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TARIPR_12_2_1A")]
    public partial class Ticket_RepricePNRWithBookingClassReplyApplicationError
    {

        private ApplicationErrorInformationType applicationErrorInfoField;

        private InteractiveFreeTextType errorTextField;

        /// <comentarios/>
        public ApplicationErrorInformationType applicationErrorInfo
        {
            get
            {
                return this.applicationErrorInfoField;
            }
            set
            {
                this.applicationErrorInfoField = value;
            }
        }

        /// <comentarios/>
        public InteractiveFreeTextType errorText
        {
            get
            {
                return this.errorTextField;
            }
            set
            {
                this.errorTextField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TARIPR_12_2_1A")]
    public partial class ApplicationErrorInformationType
    {

        private ApplicationErrorDetailType applicationErrorDetailField;

        /// <comentarios/>
        public ApplicationErrorDetailType applicationErrorDetail
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TARIPR_12_2_1A")]
    public partial class ApplicationErrorDetailType
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TARIPR_12_2_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TARIPR_12_2_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TARIPR_12_2_1A")]
    public partial class MonetaryInformationType_78667S
    {

        private MonetaryInformationDetailsTypeI_120914C monetaryDetailsField;

        private MonetaryInformationDetailsTypeI_120914C[] otherMonetaryDetailsField;

        /// <comentarios/>
        public MonetaryInformationDetailsTypeI_120914C monetaryDetails
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
        public MonetaryInformationDetailsTypeI_120914C[] otherMonetaryDetails
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TARIPR_12_2_1A")]
    public partial class MonetaryInformationDetailsTypeI_120914C
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TARIPR_12_2_1A")]
    public partial class MonetaryInformationType_145220S
    {

        private MonetaryInformationDetailsType_209702C monetaryDetailsField;

        private MonetaryInformationDetailsType_209702C[] otherMonetaryDetailsField;

        /// <comentarios/>
        public MonetaryInformationDetailsType_209702C monetaryDetails
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
        public MonetaryInformationDetailsType_209702C[] otherMonetaryDetails
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TARIPR_12_2_1A")]
    public partial class MonetaryInformationDetailsType_209702C
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TARIPR_12_2_1A")]
    public partial class MonetaryInformationType_145217S
    {

        private MonetaryInformationDetailsType_209702C monetaryDetailsField;

        private MonetaryInformationDetailsType_209702C[] otherMonetaryDetailsField;

        /// <comentarios/>
        public MonetaryInformationDetailsType_209702C monetaryDetails
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
        public MonetaryInformationDetailsType_209702C[] otherMonetaryDetails
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TARIPR_12_2_1A")]
    public partial class MonetaryInformationTypeI_74385S
    {

        private MonetaryInformationDetailsTypeI_115077C monetaryDetailsField;

        private MonetaryInformationDetailsTypeI_115077C[] otherMonetaryDetailsField;

        /// <comentarios/>
        public MonetaryInformationDetailsTypeI_115077C monetaryDetails
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
        public MonetaryInformationDetailsTypeI_115077C[] otherMonetaryDetails
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TARIPR_12_2_1A")]
    public partial class MonetaryInformationDetailsTypeI_115077C
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TARIPR_12_2_1A")]
    public partial class InteractiveFreeTextTypeI
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TARIPR_12_2_1A")]
    public partial class DiscountPenaltyMonetaryInformationTypeI_115079C
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TARIPR_12_2_1A")]
    public partial class DiscountAndPenaltyInformationTypeI_74387S
    {

        private DiscountPenaltyMonetaryInformationTypeI_115079C penDisDataField;

        /// <comentarios/>
        public DiscountPenaltyMonetaryInformationTypeI_115079C penDisData
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TARIPR_12_2_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TARIPR_12_2_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TARIPR_12_2_1A")]
    public partial class CodedAttributeInformationType_189071C
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TARIPR_12_2_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TARIPR_12_2_1A")]
    public partial class CodedAttributeType
    {

        private CodedAttributeInformationType[] attributeDetailsField;

        private object dummyNETField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("attributeDetails")]
        public CodedAttributeInformationType[] attributeDetails
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TARIPR_12_2_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TARIPR_12_2_1A")]
    public partial class ItemReferencesAndVersionsType_107712S
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TARIPR_12_2_1A")]
    public partial class BaggageDetailsTypeI
    {

        private string baggageQuantityField;

        private decimal baggageWeightField;

        private bool baggageWeightFieldSpecified;

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
        public decimal baggageWeight
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
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool baggageWeightSpecified
        {
            get
            {
                return this.baggageWeightFieldSpecified;
            }
            set
            {
                this.baggageWeightFieldSpecified = value;
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TARIPR_12_2_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TARIPR_12_2_1A")]
    public partial class DiscountPenaltyInformationTypeI
    {

        private string zapOffTypeField;

        private decimal zapOffAmountField;

        private bool zapOffAmountFieldSpecified;

        private decimal zapOffPercentageField;

        private bool zapOffPercentageFieldSpecified;

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
        public decimal zapOffPercentage
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

        /// <comentarios/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool zapOffPercentageSpecified
        {
            get
            {
                return this.zapOffPercentageFieldSpecified;
            }
            set
            {
                this.zapOffPercentageFieldSpecified = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TARIPR_12_2_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TARIPR_12_2_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TARIPR_12_2_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TARIPR_12_2_1A")]
    public partial class LocationTypeI
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TARIPR_12_2_1A")]
    public partial class TravelProductInformationTypeI
    {

        private LocationTypeI departureCityField;

        private LocationTypeI arrivalCityField;

        private CompanyIdentificationTypeI airlineDetailField;

        private ProductIdentificationDetailsTypeI segmentDetailField;

        private string ticketingStatusField;

        /// <comentarios/>
        public LocationTypeI departureCity
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
        public LocationTypeI arrivalCity
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TARIPR_12_2_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TARIPR_12_2_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TARIPR_12_2_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TARIPR_12_2_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TARIPR_12_2_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TARIPR_12_2_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TARIPR_12_2_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TARIPR_12_2_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TARIPR_12_2_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TARIPR_12_2_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TARIPR_12_2_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TARIPR_12_2_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TARIPR_12_2_1A")]
    public partial class MonetaryInformationDetailsType
    {

        private string fareDataQualifierField;

        private decimal fareAmountField;

        private bool fareAmountFieldSpecified;

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
        public decimal fareAmount
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
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool fareAmountSpecified
        {
            get
            {
                return this.fareAmountFieldSpecified;
            }
            set
            {
                this.fareAmountFieldSpecified = value;
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TARIPR_12_2_1A")]
    public partial class MonetaryInformationType
    {

        private MonetaryInformationDetailsType fareDataMainInformationField;

        private MonetaryInformationDetailsType[] fareDataSupInformationField;

        /// <comentarios/>
        public MonetaryInformationDetailsType fareDataMainInformation
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
        public MonetaryInformationDetailsType[] fareDataSupInformation
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TARIPR_12_2_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TARIPR_12_2_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TARIPR_12_2_1A")]
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
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
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
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TARIPR_12_2_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TARIPR_12_2_1A")]
    public partial class ItemReferencesAndVersionsType
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TARIPR_12_2_1A")]
    public partial class RateTariffClassInformationTypeI
    {

        private string tstIndicatorField;

        private string otherRateTariffIndicatorField;

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

        /// <comentarios/>
        public string otherRateTariffIndicator
        {
            get
            {
                return this.otherRateTariffIndicatorField;
            }
            set
            {
                this.otherRateTariffIndicatorField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TARIPR_12_2_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TARIPR_12_2_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TARIPR_12_2_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TARIPR_12_2_1A")]
    public partial class InteractiveFreeTextType
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TARIPR_12_2_1A")]
    public partial class Ticket_RepricePNRWithBookingClassReplyFareList
    {

        private PricingTicketingSubsequentTypeI pricingInformationField;

        private ItemReferencesAndVersionsType fareReferenceField;

        private StructuredDateTimeInformationType lastTktDateField;

        private TransportIdentifierType validatingCarrierField;

        private ReferencingDetailsTypeI[] paxSegReferenceField;

        private MonetaryInformationType fareDataInformationField;

        private Ticket_RepricePNRWithBookingClassReplyFareListTaxInformation[] taxInformationField;

        private ConversionRateTypeI bankerRatesField;

        private Ticket_RepricePNRWithBookingClassReplyFareListPassengerInformation[] passengerInformationField;

        private string[] originDestinationField;

        private Ticket_RepricePNRWithBookingClassReplyFareListSegmentInformation[] segmentInformationField;

        private CodedAttributeType[] otherPricingInfoField;

        private Ticket_RepricePNRWithBookingClassReplyFareListWarningInformation[] warningInformationField;

        private Ticket_RepricePNRWithBookingClassReplyFareListAutomaticReissueInfo automaticReissueInfoField;

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
        public ItemReferencesAndVersionsType fareReference
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
        public StructuredDateTimeInformationType lastTktDate
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
        public MonetaryInformationType fareDataInformation
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
        public Ticket_RepricePNRWithBookingClassReplyFareListTaxInformation[] taxInformation
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
        public Ticket_RepricePNRWithBookingClassReplyFareListPassengerInformation[] passengerInformation
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
        public Ticket_RepricePNRWithBookingClassReplyFareListSegmentInformation[] segmentInformation
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
        public CodedAttributeType[] otherPricingInfo
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
        public Ticket_RepricePNRWithBookingClassReplyFareListWarningInformation[] warningInformation
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
        public Ticket_RepricePNRWithBookingClassReplyFareListAutomaticReissueInfo automaticReissueInfo
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
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TARIPR_12_2_1A")]
    public partial class Ticket_RepricePNRWithBookingClassReplyFareListTaxInformation
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TARIPR_12_2_1A")]
    public partial class Ticket_RepricePNRWithBookingClassReplyFareListPassengerInformation
    {

        private DiscountAndPenaltyInformationTypeI penDisInformationField;

        private ReferencingDetailsTypeI[] passengerReferenceField;

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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TARIPR_12_2_1A")]
    public partial class Ticket_RepricePNRWithBookingClassReplyFareListSegmentInformation
    {

        private ConnectionTypeI connexInformationField;

        private TravelProductInformationTypeI segDetailsField;

        private FareQualifierDetailsTypeI fareQualifierField;

        private StructuredDateTimeInformationType[] validityInformationField;

        private ExcessBaggageTypeI bagAllowanceInformationField;

        private ReferencingDetailsTypeI[] segmentReferenceField;

        private ItemReferencesAndVersionsType_107712S sequenceInformationField;

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
        public TravelProductInformationTypeI segDetails
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
        public ItemReferencesAndVersionsType_107712S sequenceInformation
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TARIPR_12_2_1A")]
    public partial class Ticket_RepricePNRWithBookingClassReplyFareListWarningInformation
    {

        private ApplicationErrorInformationType warningCodeField;

        private InteractiveFreeTextTypeI warningTextField;

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
        public InteractiveFreeTextTypeI warningText
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TARIPR_12_2_1A")]
    public partial class Ticket_RepricePNRWithBookingClassReplyFareListAutomaticReissueInfo
    {

        private TicketNumberTypeI ticketInfoField;

        private CouponInformationTypeI couponInfoField;

        private Ticket_RepricePNRWithBookingClassReplyFareListAutomaticReissueInfoPaperCouponRange paperCouponRangeField;

        private MonetaryInformationTypeI_74385S baseFareInfoField;

        private Ticket_RepricePNRWithBookingClassReplyFareListAutomaticReissueInfoFirstDpiGroup firstDpiGroupField;

        private Ticket_RepricePNRWithBookingClassReplyFareListAutomaticReissueInfoSecondDpiGroup secondDpiGroupField;

        private Ticket_RepricePNRWithBookingClassReplyFareListAutomaticReissueInfoThirdGroup thirdGroupField;

        private CodedAttributeInformationType_189071C[] reissueAttributesField;

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
        public Ticket_RepricePNRWithBookingClassReplyFareListAutomaticReissueInfoPaperCouponRange paperCouponRange
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
        public MonetaryInformationTypeI_74385S baseFareInfo
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
        public Ticket_RepricePNRWithBookingClassReplyFareListAutomaticReissueInfoFirstDpiGroup firstDpiGroup
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
        public Ticket_RepricePNRWithBookingClassReplyFareListAutomaticReissueInfoSecondDpiGroup secondDpiGroup
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
        public Ticket_RepricePNRWithBookingClassReplyFareListAutomaticReissueInfoThirdGroup thirdGroup
        {
            get
            {
                return this.thirdGroupField;
            }
            set
            {
                this.thirdGroupField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayItemAttribute("attributeDetails", IsNullable = false)]
        public CodedAttributeInformationType_189071C[] reissueAttributes
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TARIPR_12_2_1A")]
    public partial class Ticket_RepricePNRWithBookingClassReplyFareListAutomaticReissueInfoPaperCouponRange
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TARIPR_12_2_1A")]
    public partial class Ticket_RepricePNRWithBookingClassReplyFareListAutomaticReissueInfoFirstDpiGroup
    {

        private DiscountAndPenaltyInformationTypeI_74387S reIssuePenaltyField;

        private MonetaryInformationType_145217S reissueInfoField;

        private MonetaryInformationType_145217S oldTaxInfoField;

        private MonetaryInformationType_145220S reissueBalanceInfoField;

        /// <comentarios/>
        public DiscountAndPenaltyInformationTypeI_74387S reIssuePenalty
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
        public MonetaryInformationType_145217S reissueInfo
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
        public MonetaryInformationType_145217S oldTaxInfo
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
        public MonetaryInformationType_145220S reissueBalanceInfo
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TARIPR_12_2_1A")]
    public partial class Ticket_RepricePNRWithBookingClassReplyFareListAutomaticReissueInfoSecondDpiGroup
    {

        private DiscountAndPenaltyInformationTypeI_74387S penaltyField;

        private MonetaryInformationType_145217S residualValueInfoField;

        private MonetaryInformationType_145217S oldTaxInfoField;

        private MonetaryInformationType_145220S issueBalanceInfoField;

        /// <comentarios/>
        public DiscountAndPenaltyInformationTypeI_74387S penalty
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
        public MonetaryInformationType_145217S residualValueInfo
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
        public MonetaryInformationType_145217S oldTaxInfo
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
        public MonetaryInformationType_145220S issueBalanceInfo
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TARIPR_12_2_1A")]
    public partial class Ticket_RepricePNRWithBookingClassReplyFareListAutomaticReissueInfoThirdGroup
    {

        private MonetaryInformationType_78667S reissueMilesInfoField;

        private MonetaryInformationType_78667S originalMilesValuesField;

        /// <comentarios/>
        public MonetaryInformationType_78667S reissueMilesInfo
        {
            get
            {
                return this.reissueMilesInfoField;
            }
            set
            {
                this.reissueMilesInfoField = value;
            }
        }

        /// <comentarios/>
        public MonetaryInformationType_78667S originalMilesValues
        {
            get
            {
                return this.originalMilesValuesField;
            }
            set
            {
                this.originalMilesValuesField = value;
            }
        }
    }
}

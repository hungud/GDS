using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmadeusLib.Servicios.Ticket_CheckEligibility.Response
{
    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/FATCER_13_1_1A")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://xml.amadeus.com/FATCER_13_1_1A", IsNullable = false)]
    public partial class Ticket_CheckEligibilityReply
    {

        private ErrorInformationTypeI[] applicationErrorInfoField;

        private CompanyIdentificationType[] allowedCarriersField;

        private Ticket_CheckEligibilityReplyTravelnfo[] travelnfoField;

        private Ticket_CheckEligibilityReplyEligibilityInfo[] eligibilityInfoField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("applicationErrorInfo")]
        public ErrorInformationTypeI[] applicationErrorInfo
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
        [System.Xml.Serialization.XmlArrayItemAttribute("companyIdentity", IsNullable = false)]
        public CompanyIdentificationType[] allowedCarriers
        {
            get
            {
                return this.allowedCarriersField;
            }
            set
            {
                this.allowedCarriersField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("travelnfo")]
        public Ticket_CheckEligibilityReplyTravelnfo[] travelnfo
        {
            get
            {
                return this.travelnfoField;
            }
            set
            {
                this.travelnfoField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("eligibilityInfo")]
        public Ticket_CheckEligibilityReplyEligibilityInfo[] eligibilityInfo
        {
            get
            {
                return this.eligibilityInfoField;
            }
            set
            {
                this.eligibilityInfoField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FATCER_13_1_1A")]
    public partial class ErrorInformationTypeI
    {

        private ErrorInformationDetailsTypeI applicationErrorDetailField;

        /// <comentarios/>
        public ErrorInformationDetailsTypeI applicationErrorDetail
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FATCER_13_1_1A")]
    public partial class ErrorInformationDetailsTypeI
    {

        private string errorLevelField;

        private string rejectNumberField;

        private string rejectMessageField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
        public string errorLevel
        {
            get
            {
                return this.errorLevelField;
            }
            set
            {
                this.errorLevelField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
        public string rejectNumber
        {
            get
            {
                return this.rejectNumberField;
            }
            set
            {
                this.rejectNumberField = value;
            }
        }

        /// <comentarios/>
        public string rejectMessage
        {
            get
            {
                return this.rejectMessageField;
            }
            set
            {
                this.rejectMessageField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FATCER_13_1_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FATCER_13_1_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FATCER_13_1_1A")]
    public partial class LocationIdentificationBatchType
    {

        private string codeField;

        private string qualifierField;

        private string nameField;

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

        /// <comentarios/>
        public string qualifier
        {
            get
            {
                return this.qualifierField;
            }
            set
            {
                this.qualifierField = value;
            }
        }

        /// <comentarios/>
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FATCER_13_1_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FATCER_13_1_1A")]
    public partial class CodedAttributeInformationType
    {

        private string attributeTypeField;

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
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FATCER_13_1_1A")]
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

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FATCER_13_1_1A")]
    public partial class DummySegmentTypeI
    {
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FATCER_13_1_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FATCER_13_1_1A")]
    public partial class ReferenceInformationTypeI
    {

        private ReferencingDetailsTypeI referencingDetailField;

        /// <comentarios/>
        public ReferencingDetailsTypeI referencingDetail
        {
            get
            {
                return this.referencingDetailField;
            }
            set
            {
                this.referencingDetailField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FATCER_13_1_1A")]
    public partial class AttributeInformationType
    {

        private string eligibilityTypeField;

        private string eligibilityValueField;

        /// <comentarios/>
        public string eligibilityType
        {
            get
            {
                return this.eligibilityTypeField;
            }
            set
            {
                this.eligibilityTypeField = value;
            }
        }

        /// <comentarios/>
        public string eligibilityValue
        {
            get
            {
                return this.eligibilityValueField;
            }
            set
            {
                this.eligibilityValueField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FATCER_13_1_1A")]
    public partial class FareInformationTypeI
    {

        private string[] fareTypeInfoField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayItemAttribute("fareTypeCode", IsNullable = false)]
        public string[] fareTypeInfo
        {
            get
            {
                return this.fareTypeInfoField;
            }
            set
            {
                this.fareTypeInfoField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FATCER_13_1_1A")]
    public partial class TicketNumberDetailsTypeI
    {

        private string numberField;

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
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FATCER_13_1_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FATCER_13_1_1A")]
    public partial class TravellerDetailsTypeI
    {

        private string referenceNumberField;

        private string infantIndicatorField;

        /// <comentarios/>
        public string referenceNumber
        {
            get
            {
                return this.referenceNumberField;
            }
            set
            {
                this.referenceNumberField = value;
            }
        }

        /// <comentarios/>
        public string infantIndicator
        {
            get
            {
                return this.infantIndicatorField;
            }
            set
            {
                this.infantIndicatorField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FATCER_13_1_1A")]
    public partial class ProductIdentificationDetailsTypeI
    {

        private string flightNumberField;

        private string operationalSuffixField;

        private string modifierField;

        /// <comentarios/>
        public string flightNumber
        {
            get
            {
                return this.flightNumberField;
            }
            set
            {
                this.flightNumberField = value;
            }
        }

        /// <comentarios/>
        public string operationalSuffix
        {
            get
            {
                return this.operationalSuffixField;
            }
            set
            {
                this.operationalSuffixField = value;
            }
        }

        /// <comentarios/>
        public string modifier
        {
            get
            {
                return this.modifierField;
            }
            set
            {
                this.modifierField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FATCER_13_1_1A")]
    public partial class CompanyIdentificationTypeI
    {

        private string marketingCompanyField;

        private string operatingCompanyField;

        private string otherCompanyField;

        /// <comentarios/>
        public string marketingCompany
        {
            get
            {
                return this.marketingCompanyField;
            }
            set
            {
                this.marketingCompanyField = value;
            }
        }

        /// <comentarios/>
        public string operatingCompany
        {
            get
            {
                return this.operatingCompanyField;
            }
            set
            {
                this.operatingCompanyField = value;
            }
        }

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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FATCER_13_1_1A")]
    public partial class LocationTypeI_52325C
    {

        private string destinationPointField;

        /// <comentarios/>
        public string destinationPoint
        {
            get
            {
                return this.destinationPointField;
            }
            set
            {
                this.destinationPointField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FATCER_13_1_1A")]
    public partial class LocationTypeI
    {

        private string originPointField;

        /// <comentarios/>
        public string originPoint
        {
            get
            {
                return this.originPointField;
            }
            set
            {
                this.originPointField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FATCER_13_1_1A")]
    public partial class ProductDateTimeTypeI
    {

        private string departureDateField;

        private string departureTimeField;

        private string arrivalDateField;

        private string arrivalTimeField;

        private string dateVariationField;

        /// <comentarios/>
        public string departureDate
        {
            get
            {
                return this.departureDateField;
            }
            set
            {
                this.departureDateField = value;
            }
        }

        /// <comentarios/>
        public string departureTime
        {
            get
            {
                return this.departureTimeField;
            }
            set
            {
                this.departureTimeField = value;
            }
        }

        /// <comentarios/>
        public string arrivalDate
        {
            get
            {
                return this.arrivalDateField;
            }
            set
            {
                this.arrivalDateField = value;
            }
        }

        /// <comentarios/>
        public string arrivalTime
        {
            get
            {
                return this.arrivalTimeField;
            }
            set
            {
                this.arrivalTimeField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
        public string dateVariation
        {
            get
            {
                return this.dateVariationField;
            }
            set
            {
                this.dateVariationField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FATCER_13_1_1A")]
    public partial class TravelProductInformationTypeI
    {

        private ProductDateTimeTypeI dateTimeOfFlightField;

        private LocationTypeI boardPointInfoField;

        private LocationTypeI_52325C offPointInfoField;

        private CompanyIdentificationTypeI carrierIdentificationsField;

        private ProductIdentificationDetailsTypeI additionalFlightInfoField;

        /// <comentarios/>
        public ProductDateTimeTypeI dateTimeOfFlight
        {
            get
            {
                return this.dateTimeOfFlightField;
            }
            set
            {
                this.dateTimeOfFlightField = value;
            }
        }

        /// <comentarios/>
        public LocationTypeI boardPointInfo
        {
            get
            {
                return this.boardPointInfoField;
            }
            set
            {
                this.boardPointInfoField = value;
            }
        }

        /// <comentarios/>
        public LocationTypeI_52325C offPointInfo
        {
            get
            {
                return this.offPointInfoField;
            }
            set
            {
                this.offPointInfoField = value;
            }
        }

        /// <comentarios/>
        public CompanyIdentificationTypeI carrierIdentifications
        {
            get
            {
                return this.carrierIdentificationsField;
            }
            set
            {
                this.carrierIdentificationsField = value;
            }
        }

        /// <comentarios/>
        public ProductIdentificationDetailsTypeI additionalFlightInfo
        {
            get
            {
                return this.additionalFlightInfoField;
            }
            set
            {
                this.additionalFlightInfoField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FATCER_13_1_1A")]
    public partial class ItemNumberIdentificationTypeI
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FATCER_13_1_1A")]
    public partial class ItemNumberTypeI
    {

        private ItemNumberIdentificationTypeI itemNumberIdField;

        /// <comentarios/>
        public ItemNumberIdentificationTypeI itemNumberId
        {
            get
            {
                return this.itemNumberIdField;
            }
            set
            {
                this.itemNumberIdField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FATCER_13_1_1A")]
    public partial class CompanyIdentificationType
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/FATCER_13_1_1A")]
    public partial class Ticket_CheckEligibilityReplyTravelnfo
    {

        private ItemNumberTypeI flightNumberField;

        private TravelProductInformationTypeI flightInfoField;

        private CompanyIdentificationType[] allowedCarriersField;

        /// <comentarios/>
        public ItemNumberTypeI flightNumber
        {
            get
            {
                return this.flightNumberField;
            }
            set
            {
                this.flightNumberField = value;
            }
        }

        /// <comentarios/>
        public TravelProductInformationTypeI flightInfo
        {
            get
            {
                return this.flightInfoField;
            }
            set
            {
                this.flightInfoField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayItemAttribute("companyIdentity", IsNullable = false)]
        public CompanyIdentificationType[] allowedCarriers
        {
            get
            {
                return this.allowedCarriersField;
            }
            set
            {
                this.allowedCarriersField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/FATCER_13_1_1A")]
    public partial class Ticket_CheckEligibilityReplyEligibilityInfo
    {

        private TravellerDetailsTypeI[] travellerInfoField;

        private ErrorInformationTypeI applicationErrorInfoField;

        private Ticket_CheckEligibilityReplyEligibilityInfoETicketInfo[] eTicketInfoField;

        private FareInformationTypeI travellerTypeInfoField;

        private AttributeInformationType[] generalEligibilityInfoField;

        private Ticket_CheckEligibilityReplyEligibilityInfoCouponEligibilityInfo[] couponEligibilityInfoField;

        private DummySegmentTypeI dummyInfoField;

        private Ticket_CheckEligibilityReplyEligibilityInfoChangeOfRoutingGrp[] changeOfRoutingGrpField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayItemAttribute("passengerIndicators", IsNullable = false)]
        public TravellerDetailsTypeI[] travellerInfo
        {
            get
            {
                return this.travellerInfoField;
            }
            set
            {
                this.travellerInfoField = value;
            }
        }

        /// <comentarios/>
        public ErrorInformationTypeI applicationErrorInfo
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
        [System.Xml.Serialization.XmlElementAttribute("eTicketInfo")]
        public Ticket_CheckEligibilityReplyEligibilityInfoETicketInfo[] eTicketInfo
        {
            get
            {
                return this.eTicketInfoField;
            }
            set
            {
                this.eTicketInfoField = value;
            }
        }

        /// <comentarios/>
        public FareInformationTypeI travellerTypeInfo
        {
            get
            {
                return this.travellerTypeInfoField;
            }
            set
            {
                this.travellerTypeInfoField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayItemAttribute("eligibilityId", IsNullable = false)]
        public AttributeInformationType[] generalEligibilityInfo
        {
            get
            {
                return this.generalEligibilityInfoField;
            }
            set
            {
                this.generalEligibilityInfoField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("couponEligibilityInfo")]
        public Ticket_CheckEligibilityReplyEligibilityInfoCouponEligibilityInfo[] couponEligibilityInfo
        {
            get
            {
                return this.couponEligibilityInfoField;
            }
            set
            {
                this.couponEligibilityInfoField = value;
            }
        }

        /// <comentarios/>
        public DummySegmentTypeI dummyInfo
        {
            get
            {
                return this.dummyInfoField;
            }
            set
            {
                this.dummyInfoField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("changeOfRoutingGrp")]
        public Ticket_CheckEligibilityReplyEligibilityInfoChangeOfRoutingGrp[] changeOfRoutingGrp
        {
            get
            {
                return this.changeOfRoutingGrpField;
            }
            set
            {
                this.changeOfRoutingGrpField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/FATCER_13_1_1A")]
    public partial class Ticket_CheckEligibilityReplyEligibilityInfoETicketInfo
    {

        private TicketNumberTypeI ticketNumberDetailsField;

        /// <comentarios/>
        public TicketNumberTypeI ticketNumberDetails
        {
            get
            {
                return this.ticketNumberDetailsField;
            }
            set
            {
                this.ticketNumberDetailsField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/FATCER_13_1_1A")]
    public partial class Ticket_CheckEligibilityReplyEligibilityInfoCouponEligibilityInfo
    {

        private ReferenceInformationTypeI requestedSegmentRefField;

        private AttributeInformationType[] fareCompEligibilityInfoField;

        /// <comentarios/>
        public ReferenceInformationTypeI requestedSegmentRef
        {
            get
            {
                return this.requestedSegmentRefField;
            }
            set
            {
                this.requestedSegmentRefField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayItemAttribute("eligibilityId", IsNullable = false)]
        public AttributeInformationType[] fareCompEligibilityInfo
        {
            get
            {
                return this.fareCompEligibilityInfoField;
            }
            set
            {
                this.fareCompEligibilityInfoField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/FATCER_13_1_1A")]
    public partial class Ticket_CheckEligibilityReplyEligibilityInfoChangeOfRoutingGrp
    {

        private AttributeInformationTypeU[] waiverInfoField;

        private Ticket_CheckEligibilityReplyEligibilityInfoChangeOfRoutingGrpTicketAttributesGrp[] ticketAttributesGrpField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayItemAttribute("criteriaDetails", IsNullable = false)]
        public AttributeInformationTypeU[] waiverInfo
        {
            get
            {
                return this.waiverInfoField;
            }
            set
            {
                this.waiverInfoField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("ticketAttributesGrp")]
        public Ticket_CheckEligibilityReplyEligibilityInfoChangeOfRoutingGrpTicketAttributesGrp[] ticketAttributesGrp
        {
            get
            {
                return this.ticketAttributesGrpField;
            }
            set
            {
                this.ticketAttributesGrpField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/FATCER_13_1_1A")]
    public partial class Ticket_CheckEligibilityReplyEligibilityInfoChangeOfRoutingGrpTicketAttributesGrp
    {

        private CodedAttributeInformationType[] ticketInfoField;

        private PlaceLocationIdentificationType[] locationInfoField;

        private StructuredDateTimeInformationType[] datesInfoField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayItemAttribute("attributeDetails", IsNullable = false)]
        public CodedAttributeInformationType[] ticketInfo
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
        [System.Xml.Serialization.XmlElementAttribute("locationInfo")]
        public PlaceLocationIdentificationType[] locationInfo
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

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("datesInfo")]
        public StructuredDateTimeInformationType[] datesInfo
        {
            get
            {
                return this.datesInfoField;
            }
            set
            {
                this.datesInfoField = value;
            }
        }
    }
}

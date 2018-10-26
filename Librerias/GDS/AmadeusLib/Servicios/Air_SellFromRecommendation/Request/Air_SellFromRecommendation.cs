using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AmadeusLib.Servicios.Air_SellFromRecommendation.Request
{
    

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/ITAREQ_05_2_IA")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://xml.amadeus.com/ITAREQ_05_2_IA", IsNullable = false)]
    public partial class Air_SellFromRecommendation
    {

        private Air_SellFromRecommendationMessageActionDetails messageActionDetailsField;

        private Air_SellFromRecommendationReservation[] recordLocatorField;

        private Air_SellFromRecommendationItineraryDetails[] itineraryDetailsField;

        /// <comentarios/>
        public Air_SellFromRecommendationMessageActionDetails messageActionDetails
        {
            get
            {
                return this.messageActionDetailsField;
            }
            set
            {
                this.messageActionDetailsField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayItemAttribute("reservation", IsNullable = false)]
        public Air_SellFromRecommendationReservation[] recordLocator
        {
            get
            {
                return this.recordLocatorField;
            }
            set
            {
                this.recordLocatorField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("itineraryDetails")]
        public Air_SellFromRecommendationItineraryDetails[] itineraryDetails
        {
            get
            {
                return this.itineraryDetailsField;
            }
            set
            {
                this.itineraryDetailsField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/ITAREQ_05_2_IA")]
    public partial class Air_SellFromRecommendationMessageActionDetails
    {

        private Air_SellFromRecommendationMessageActionDetailsMessageFunctionDetails messageFunctionDetailsField;

        /// <comentarios/>
        public Air_SellFromRecommendationMessageActionDetailsMessageFunctionDetails messageFunctionDetails
        {
            get
            {
                return this.messageFunctionDetailsField;
            }
            set
            {
                this.messageFunctionDetailsField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/ITAREQ_05_2_IA")]
    public partial class Air_SellFromRecommendationMessageActionDetailsMessageFunctionDetails
    {

        private string messageFunctionField;

        private string[] additionalMessageFunctionField;

        /// <comentarios/>
        public string messageFunction
        {
            get
            {
                return this.messageFunctionField;
            }
            set
            {
                this.messageFunctionField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("additionalMessageFunction")]
        public string[] additionalMessageFunction
        {
            get
            {
                return this.additionalMessageFunctionField;
            }
            set
            {
                this.additionalMessageFunctionField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/ITAREQ_05_2_IA")]
    public partial class Air_SellFromRecommendationReservation
    {

        private string companyIdField;

        private string controlNumberField;

        private string controlTypeField;

        private string dateField;

        private decimal timeField;

        private bool timeFieldSpecified;

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

        /// <comentarios/>
        public string controlType
        {
            get
            {
                return this.controlTypeField;
            }
            set
            {
                this.controlTypeField = value;
            }
        }

        /// <comentarios/>
        public string date
        {
            get
            {
                return this.dateField;
            }
            set
            {
                this.dateField = value;
            }
        }

        /// <comentarios/>
        public decimal time
        {
            get
            {
                return this.timeField;
            }
            set
            {
                this.timeField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool timeSpecified
        {
            get
            {
                return this.timeFieldSpecified;
            }
            set
            {
                this.timeFieldSpecified = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/ITAREQ_05_2_IA")]
    public partial class Air_SellFromRecommendationItineraryDetails
    {

        private Air_SellFromRecommendationItineraryDetailsOriginDestinationDetails originDestinationDetailsField;

        private Air_SellFromRecommendationItineraryDetailsMessage messageField;

        private Air_SellFromRecommendationItineraryDetailsSegmentInformation[] segmentInformationField;

        /// <comentarios/>
        public Air_SellFromRecommendationItineraryDetailsOriginDestinationDetails originDestinationDetails
        {
            get
            {
                return this.originDestinationDetailsField;
            }
            set
            {
                this.originDestinationDetailsField = value;
            }
        }

        /// <comentarios/>
        public Air_SellFromRecommendationItineraryDetailsMessage message
        {
            get
            {
                return this.messageField;
            }
            set
            {
                this.messageField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("segmentInformation")]
        public Air_SellFromRecommendationItineraryDetailsSegmentInformation[] segmentInformation
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
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/ITAREQ_05_2_IA")]
    public partial class Air_SellFromRecommendationItineraryDetailsOriginDestinationDetails
    {

        private string originField;

        private string destinationField;

        /// <comentarios/>
        public string origin
        {
            get
            {
                return this.originField;
            }
            set
            {
                this.originField = value;
            }
        }

        /// <comentarios/>
        public string destination
        {
            get
            {
                return this.destinationField;
            }
            set
            {
                this.destinationField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/ITAREQ_05_2_IA")]
    public partial class Air_SellFromRecommendationItineraryDetailsMessage
    {

        private Air_SellFromRecommendationItineraryDetailsMessageMessageFunctionDetails messageFunctionDetailsField;

        /// <comentarios/>
        public Air_SellFromRecommendationItineraryDetailsMessageMessageFunctionDetails messageFunctionDetails
        {
            get
            {
                return this.messageFunctionDetailsField;
            }
            set
            {
                this.messageFunctionDetailsField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/ITAREQ_05_2_IA")]
    public partial class Air_SellFromRecommendationItineraryDetailsMessageMessageFunctionDetails
    {

        private string messageFunctionField;

        private string[] additionalMessageFunctionField;

        /// <comentarios/>
        public string messageFunction
        {
            get
            {
                return this.messageFunctionField;
            }
            set
            {
                this.messageFunctionField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("additionalMessageFunction")]
        public string[] additionalMessageFunction
        {
            get
            {
                return this.additionalMessageFunctionField;
            }
            set
            {
                this.additionalMessageFunctionField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/ITAREQ_05_2_IA")]
    public partial class Air_SellFromRecommendationItineraryDetailsSegmentInformation
    {

        private Air_SellFromRecommendationItineraryDetailsSegmentInformationTravelProductInformation travelProductInformationField;

        private Air_SellFromRecommendationItineraryDetailsSegmentInformationRelatedproductInformation relatedproductInformationField;

        /// <comentarios/>
        public Air_SellFromRecommendationItineraryDetailsSegmentInformationTravelProductInformation travelProductInformation
        {
            get
            {
                return this.travelProductInformationField;
            }
            set
            {
                this.travelProductInformationField = value;
            }
        }

        /// <comentarios/>
        public Air_SellFromRecommendationItineraryDetailsSegmentInformationRelatedproductInformation relatedproductInformation
        {
            get
            {
                return this.relatedproductInformationField;
            }
            set
            {
                this.relatedproductInformationField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/ITAREQ_05_2_IA")]
    public partial class Air_SellFromRecommendationItineraryDetailsSegmentInformationTravelProductInformation
    {

        private Air_SellFromRecommendationItineraryDetailsSegmentInformationTravelProductInformationFlightDate flightDateField;

        private Air_SellFromRecommendationItineraryDetailsSegmentInformationTravelProductInformationBoardPointDetails boardPointDetailsField;

        private Air_SellFromRecommendationItineraryDetailsSegmentInformationTravelProductInformationOffpointDetails offpointDetailsField;

        private Air_SellFromRecommendationItineraryDetailsSegmentInformationTravelProductInformationCompanyDetails companyDetailsField;

        private Air_SellFromRecommendationItineraryDetailsSegmentInformationTravelProductInformationFlightIdentification flightIdentificationField;

        private string[] flightTypeDetailsField;

        private string specialSegmentField;

        private Air_SellFromRecommendationItineraryDetailsSegmentInformationTravelProductInformationMarriageDetails[] marriageDetailsField;

        /// <comentarios/>
        public Air_SellFromRecommendationItineraryDetailsSegmentInformationTravelProductInformationFlightDate flightDate
        {
            get
            {
                return this.flightDateField;
            }
            set
            {
                this.flightDateField = value;
            }
        }

        /// <comentarios/>
        public Air_SellFromRecommendationItineraryDetailsSegmentInformationTravelProductInformationBoardPointDetails boardPointDetails
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
        public Air_SellFromRecommendationItineraryDetailsSegmentInformationTravelProductInformationOffpointDetails offpointDetails
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
        public Air_SellFromRecommendationItineraryDetailsSegmentInformationTravelProductInformationCompanyDetails companyDetails
        {
            get
            {
                return this.companyDetailsField;
            }
            set
            {
                this.companyDetailsField = value;
            }
        }

        /// <comentarios/>
        public Air_SellFromRecommendationItineraryDetailsSegmentInformationTravelProductInformationFlightIdentification flightIdentification
        {
            get
            {
                return this.flightIdentificationField;
            }
            set
            {
                this.flightIdentificationField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayItemAttribute("flightIndicator", IsNullable = false)]
        public string[] flightTypeDetails
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

        /// <comentarios/>
        public string specialSegment
        {
            get
            {
                return this.specialSegmentField;
            }
            set
            {
                this.specialSegmentField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("marriageDetails")]
        public Air_SellFromRecommendationItineraryDetailsSegmentInformationTravelProductInformationMarriageDetails[] marriageDetails
        {
            get
            {
                return this.marriageDetailsField;
            }
            set
            {
                this.marriageDetailsField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/ITAREQ_05_2_IA")]
    public partial class Air_SellFromRecommendationItineraryDetailsSegmentInformationTravelProductInformationFlightDate
    {

        private string departureDateField;

        private decimal departureTimeField;

        private bool departureTimeFieldSpecified;

        private string arrivalDateField;

        private decimal arrivalTimeField;

        private bool arrivalTimeFieldSpecified;

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
        public decimal departureTime
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
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool departureTimeSpecified
        {
            get
            {
                return this.departureTimeFieldSpecified;
            }
            set
            {
                this.departureTimeFieldSpecified = value;
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
        public decimal arrivalTime
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
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool arrivalTimeSpecified
        {
            get
            {
                return this.arrivalTimeFieldSpecified;
            }
            set
            {
                this.arrivalTimeFieldSpecified = value;
            }
        }

        /// <comentarios/>
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/ITAREQ_05_2_IA")]
    public partial class Air_SellFromRecommendationItineraryDetailsSegmentInformationTravelProductInformationBoardPointDetails
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/ITAREQ_05_2_IA")]
    public partial class Air_SellFromRecommendationItineraryDetailsSegmentInformationTravelProductInformationOffpointDetails
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/ITAREQ_05_2_IA")]
    public partial class Air_SellFromRecommendationItineraryDetailsSegmentInformationTravelProductInformationCompanyDetails
    {

        private string marketingCompanyField;

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
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/ITAREQ_05_2_IA")]
    public partial class Air_SellFromRecommendationItineraryDetailsSegmentInformationTravelProductInformationFlightIdentification
    {

        private string flightNumberField;

        private string bookingClassField;

        private string operationalSuffixField;

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
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/ITAREQ_05_2_IA")]
    public partial class Air_SellFromRecommendationItineraryDetailsSegmentInformationTravelProductInformationMarriageDetails
    {

        private string relationField;

        private decimal marriageIdentifierField;

        private bool marriageIdentifierFieldSpecified;

        private decimal lineNumberField;

        private bool lineNumberFieldSpecified;

        /// <comentarios/>
        public string relation
        {
            get
            {
                return this.relationField;
            }
            set
            {
                this.relationField = value;
            }
        }

        /// <comentarios/>
        public decimal marriageIdentifier
        {
            get
            {
                return this.marriageIdentifierField;
            }
            set
            {
                this.marriageIdentifierField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool marriageIdentifierSpecified
        {
            get
            {
                return this.marriageIdentifierFieldSpecified;
            }
            set
            {
                this.marriageIdentifierFieldSpecified = value;
            }
        }

        /// <comentarios/>
        public decimal lineNumber
        {
            get
            {
                return this.lineNumberField;
            }
            set
            {
                this.lineNumberField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool lineNumberSpecified
        {
            get
            {
                return this.lineNumberFieldSpecified;
            }
            set
            {
                this.lineNumberFieldSpecified = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/ITAREQ_05_2_IA")]
    public partial class Air_SellFromRecommendationItineraryDetailsSegmentInformationRelatedproductInformation
    {

        private decimal quantityField;

        private string[] statusCodeField;

        /// <comentarios/>
        public decimal quantity
        {
            get
            {
                return this.quantityField;
            }
            set
            {
                this.quantityField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("statusCode")]
        public string[] statusCode
        {
            get
            {
                return this.statusCodeField;
            }
            set
            {
                this.statusCodeField = value;
            }
        }
    }

}

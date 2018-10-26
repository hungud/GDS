using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AmadeusLib.Servicios.Air_SellFromRecommendation.Response
{

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/ITARES_05_2_IA")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://xml.amadeus.com/ITARES_05_2_IA", IsNullable = false)]
    public partial class Air_SellFromRecommendationReply
    {

        private Air_SellFromRecommendationReplyMessage messageField;

        private Air_SellFromRecommendationReplyErrorAtMessageLevel[] errorAtMessageLevelField;

        private Air_SellFromRecommendationReplyItineraryDetails[] itineraryDetailsField;

        /// <comentarios/>
        public Air_SellFromRecommendationReplyMessage message
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
        [System.Xml.Serialization.XmlElementAttribute("errorAtMessageLevel")]
        public Air_SellFromRecommendationReplyErrorAtMessageLevel[] errorAtMessageLevel
        {
            get
            {
                return this.errorAtMessageLevelField;
            }
            set
            {
                this.errorAtMessageLevelField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("itineraryDetails")]
        public Air_SellFromRecommendationReplyItineraryDetails[] itineraryDetails
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/ITARES_05_2_IA")]
    public partial class Air_SellFromRecommendationReplyMessage
    {

        private Air_SellFromRecommendationReplyMessageMessageFunctionDetails messageFunctionDetailsField;

        private string responseTypeField;

        /// <comentarios/>
        public Air_SellFromRecommendationReplyMessageMessageFunctionDetails messageFunctionDetails
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

        /// <comentarios/>
        public string responseType
        {
            get
            {
                return this.responseTypeField;
            }
            set
            {
                this.responseTypeField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/ITARES_05_2_IA")]
    public partial class Air_SellFromRecommendationReplyMessageMessageFunctionDetails
    {

        private string businessFunctionField;

        private string messageFunctionField;

        private string responsibleAgencyField;

        private string[] additionalMessageFunctionField;

        /// <comentarios/>
        public string businessFunction
        {
            get
            {
                return this.businessFunctionField;
            }
            set
            {
                this.businessFunctionField = value;
            }
        }

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
        public string responsibleAgency
        {
            get
            {
                return this.responsibleAgencyField;
            }
            set
            {
                this.responsibleAgencyField = value;
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/ITARES_05_2_IA")]
    public partial class Air_SellFromRecommendationReplyErrorAtMessageLevel
    {

        private Air_SellFromRecommendationReplyErrorAtMessageLevelErrorSegment errorSegmentField;

        private Air_SellFromRecommendationReplyErrorAtMessageLevelInformationText informationTextField;

        /// <comentarios/>
        public Air_SellFromRecommendationReplyErrorAtMessageLevelErrorSegment errorSegment
        {
            get
            {
                return this.errorSegmentField;
            }
            set
            {
                this.errorSegmentField = value;
            }
        }

        /// <comentarios/>
        public Air_SellFromRecommendationReplyErrorAtMessageLevelInformationText informationText
        {
            get
            {
                return this.informationTextField;
            }
            set
            {
                this.informationTextField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/ITARES_05_2_IA")]
    public partial class Air_SellFromRecommendationReplyErrorAtMessageLevelErrorSegment
    {

        private Air_SellFromRecommendationReplyErrorAtMessageLevelErrorSegmentErrorDetails errorDetailsField;

        /// <comentarios/>
        public Air_SellFromRecommendationReplyErrorAtMessageLevelErrorSegmentErrorDetails errorDetails
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/ITARES_05_2_IA")]
    public partial class Air_SellFromRecommendationReplyErrorAtMessageLevelErrorSegmentErrorDetails
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/ITARES_05_2_IA")]
    public partial class Air_SellFromRecommendationReplyErrorAtMessageLevelInformationText
    {

        private Air_SellFromRecommendationReplyErrorAtMessageLevelInformationTextFreeTextQualification freeTextQualificationField;

        private string[] freeTextField;

        /// <comentarios/>
        public Air_SellFromRecommendationReplyErrorAtMessageLevelInformationTextFreeTextQualification freeTextQualification
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/ITARES_05_2_IA")]
    public partial class Air_SellFromRecommendationReplyErrorAtMessageLevelInformationTextFreeTextQualification
    {

        private string textSubjectQualifierField;

        private string informationTypeField;

        private string statusField;

        private string companyIdField;

        private string languageField;

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
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/ITARES_05_2_IA")]
    public partial class Air_SellFromRecommendationReplyItineraryDetails
    {

        private Air_SellFromRecommendationReplyItineraryDetailsOriginDestination originDestinationField;

        private Air_SellFromRecommendationReplyItineraryDetailsErrorItinerarylevel[] errorItinerarylevelField;

        private Air_SellFromRecommendationReplyItineraryDetailsSegmentInformation[] segmentInformationField;

        /// <comentarios/>
        public Air_SellFromRecommendationReplyItineraryDetailsOriginDestination originDestination
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
        [System.Xml.Serialization.XmlElementAttribute("errorItinerarylevel")]
        public Air_SellFromRecommendationReplyItineraryDetailsErrorItinerarylevel[] errorItinerarylevel
        {
            get
            {
                return this.errorItinerarylevelField;
            }
            set
            {
                this.errorItinerarylevelField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("segmentInformation")]
        public Air_SellFromRecommendationReplyItineraryDetailsSegmentInformation[] segmentInformation
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/ITARES_05_2_IA")]
    public partial class Air_SellFromRecommendationReplyItineraryDetailsOriginDestination
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/ITARES_05_2_IA")]
    public partial class Air_SellFromRecommendationReplyItineraryDetailsErrorItinerarylevel
    {

        private Air_SellFromRecommendationReplyItineraryDetailsErrorItinerarylevelErrorSegment errorSegmentField;

        private Air_SellFromRecommendationReplyItineraryDetailsErrorItinerarylevelInformationText informationTextField;

        /// <comentarios/>
        public Air_SellFromRecommendationReplyItineraryDetailsErrorItinerarylevelErrorSegment errorSegment
        {
            get
            {
                return this.errorSegmentField;
            }
            set
            {
                this.errorSegmentField = value;
            }
        }

        /// <comentarios/>
        public Air_SellFromRecommendationReplyItineraryDetailsErrorItinerarylevelInformationText informationText
        {
            get
            {
                return this.informationTextField;
            }
            set
            {
                this.informationTextField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/ITARES_05_2_IA")]
    public partial class Air_SellFromRecommendationReplyItineraryDetailsErrorItinerarylevelErrorSegment
    {

        private Air_SellFromRecommendationReplyItineraryDetailsErrorItinerarylevelErrorSegmentErrorDetails errorDetailsField;

        /// <comentarios/>
        public Air_SellFromRecommendationReplyItineraryDetailsErrorItinerarylevelErrorSegmentErrorDetails errorDetails
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/ITARES_05_2_IA")]
    public partial class Air_SellFromRecommendationReplyItineraryDetailsErrorItinerarylevelErrorSegmentErrorDetails
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/ITARES_05_2_IA")]
    public partial class Air_SellFromRecommendationReplyItineraryDetailsErrorItinerarylevelInformationText
    {

        private Air_SellFromRecommendationReplyItineraryDetailsErrorItinerarylevelInformationTextFreeTextQualification freeTextQualificationField;

        private string[] freeTextField;

        /// <comentarios/>
        public Air_SellFromRecommendationReplyItineraryDetailsErrorItinerarylevelInformationTextFreeTextQualification freeTextQualification
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/ITARES_05_2_IA")]
    public partial class Air_SellFromRecommendationReplyItineraryDetailsErrorItinerarylevelInformationTextFreeTextQualification
    {

        private string textSubjectQualifierField;

        private string informationTypeField;

        private string statusField;

        private string companyIdField;

        private string languageField;

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
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/ITARES_05_2_IA")]
    public partial class Air_SellFromRecommendationReplyItineraryDetailsSegmentInformation
    {

        private Air_SellFromRecommendationReplyItineraryDetailsSegmentInformationFlightDetails flightDetailsField;

        private Air_SellFromRecommendationReplyItineraryDetailsSegmentInformationApdSegment apdSegmentField;

        private Air_SellFromRecommendationReplyItineraryDetailsSegmentInformationActionDetails actionDetailsField;

        private Air_SellFromRecommendationReplyItineraryDetailsSegmentInformationInformationText informationTextField;

        private Air_SellFromRecommendationReplyItineraryDetailsSegmentInformationErrorAtSegmentLevel[] errorAtSegmentLevelField;

        /// <comentarios/>
        public Air_SellFromRecommendationReplyItineraryDetailsSegmentInformationFlightDetails flightDetails
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

        /// <comentarios/>
        public Air_SellFromRecommendationReplyItineraryDetailsSegmentInformationApdSegment apdSegment
        {
            get
            {
                return this.apdSegmentField;
            }
            set
            {
                this.apdSegmentField = value;
            }
        }

        /// <comentarios/>
        public Air_SellFromRecommendationReplyItineraryDetailsSegmentInformationActionDetails actionDetails
        {
            get
            {
                return this.actionDetailsField;
            }
            set
            {
                this.actionDetailsField = value;
            }
        }

        /// <comentarios/>
        public Air_SellFromRecommendationReplyItineraryDetailsSegmentInformationInformationText informationText
        {
            get
            {
                return this.informationTextField;
            }
            set
            {
                this.informationTextField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("errorAtSegmentLevel")]
        public Air_SellFromRecommendationReplyItineraryDetailsSegmentInformationErrorAtSegmentLevel[] errorAtSegmentLevel
        {
            get
            {
                return this.errorAtSegmentLevelField;
            }
            set
            {
                this.errorAtSegmentLevelField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/ITARES_05_2_IA")]
    public partial class Air_SellFromRecommendationReplyItineraryDetailsSegmentInformationFlightDetails
    {

        private Air_SellFromRecommendationReplyItineraryDetailsSegmentInformationFlightDetailsFlightDate flightDateField;

        private Air_SellFromRecommendationReplyItineraryDetailsSegmentInformationFlightDetailsBoardPointDetails boardPointDetailsField;

        private Air_SellFromRecommendationReplyItineraryDetailsSegmentInformationFlightDetailsOffpointDetails offpointDetailsField;

        private Air_SellFromRecommendationReplyItineraryDetailsSegmentInformationFlightDetailsCompanyDetails companyDetailsField;

        private Air_SellFromRecommendationReplyItineraryDetailsSegmentInformationFlightDetailsFlightIdentification flightIdentificationField;

        private string[] flightTypeDetailsField;

        private string specialSegmentField;

        private Air_SellFromRecommendationReplyItineraryDetailsSegmentInformationFlightDetailsMarriageDetails[] marriageDetailsField;

        /// <comentarios/>
        public Air_SellFromRecommendationReplyItineraryDetailsSegmentInformationFlightDetailsFlightDate flightDate
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
        public Air_SellFromRecommendationReplyItineraryDetailsSegmentInformationFlightDetailsBoardPointDetails boardPointDetails
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
        public Air_SellFromRecommendationReplyItineraryDetailsSegmentInformationFlightDetailsOffpointDetails offpointDetails
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
        public Air_SellFromRecommendationReplyItineraryDetailsSegmentInformationFlightDetailsCompanyDetails companyDetails
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
        public Air_SellFromRecommendationReplyItineraryDetailsSegmentInformationFlightDetailsFlightIdentification flightIdentification
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
        public Air_SellFromRecommendationReplyItineraryDetailsSegmentInformationFlightDetailsMarriageDetails[] marriageDetails
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/ITARES_05_2_IA")]
    public partial class Air_SellFromRecommendationReplyItineraryDetailsSegmentInformationFlightDetailsFlightDate
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/ITARES_05_2_IA")]
    public partial class Air_SellFromRecommendationReplyItineraryDetailsSegmentInformationFlightDetailsBoardPointDetails
    {

        private string trueLocationIdField;

        private string trueLocationField;

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

        /// <comentarios/>
        public string trueLocation
        {
            get
            {
                return this.trueLocationField;
            }
            set
            {
                this.trueLocationField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/ITARES_05_2_IA")]
    public partial class Air_SellFromRecommendationReplyItineraryDetailsSegmentInformationFlightDetailsOffpointDetails
    {

        private string trueLocationIdField;

        private string trueLocationField;

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

        /// <comentarios/>
        public string trueLocation
        {
            get
            {
                return this.trueLocationField;
            }
            set
            {
                this.trueLocationField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/ITARES_05_2_IA")]
    public partial class Air_SellFromRecommendationReplyItineraryDetailsSegmentInformationFlightDetailsCompanyDetails
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/ITARES_05_2_IA")]
    public partial class Air_SellFromRecommendationReplyItineraryDetailsSegmentInformationFlightDetailsFlightIdentification
    {

        private string flightNumberField;

        private string bookingClassField;

        private string operationalSuffixField;

        private string[] modifierField;

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

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("modifier")]
        public string[] modifier
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/ITARES_05_2_IA")]
    public partial class Air_SellFromRecommendationReplyItineraryDetailsSegmentInformationFlightDetailsMarriageDetails
    {

        private string relationField;

        private decimal marriageIdentifierField;

        private bool marriageIdentifierFieldSpecified;

        private decimal lineNumberField;

        private bool lineNumberFieldSpecified;

        private string otherRelationField;

        private string carrierCodeField;

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

        /// <comentarios/>
        public string otherRelation
        {
            get
            {
                return this.otherRelationField;
            }
            set
            {
                this.otherRelationField = value;
            }
        }

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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/ITARES_05_2_IA")]
    public partial class Air_SellFromRecommendationReplyItineraryDetailsSegmentInformationApdSegment
    {

        private Air_SellFromRecommendationReplyItineraryDetailsSegmentInformationApdSegmentLegDetails legDetailsField;

        private Air_SellFromRecommendationReplyItineraryDetailsSegmentInformationApdSegmentDepartureStationInfo departureStationInfoField;

        private Air_SellFromRecommendationReplyItineraryDetailsSegmentInformationApdSegmentArrivalStationInfo arrivalStationInfoField;

        private Air_SellFromRecommendationReplyItineraryDetailsSegmentInformationApdSegmentFacilitiesInformation[] facilitiesInformationField;

        /// <comentarios/>
        public Air_SellFromRecommendationReplyItineraryDetailsSegmentInformationApdSegmentLegDetails legDetails
        {
            get
            {
                return this.legDetailsField;
            }
            set
            {
                this.legDetailsField = value;
            }
        }

        /// <comentarios/>
        public Air_SellFromRecommendationReplyItineraryDetailsSegmentInformationApdSegmentDepartureStationInfo departureStationInfo
        {
            get
            {
                return this.departureStationInfoField;
            }
            set
            {
                this.departureStationInfoField = value;
            }
        }

        /// <comentarios/>
        public Air_SellFromRecommendationReplyItineraryDetailsSegmentInformationApdSegmentArrivalStationInfo arrivalStationInfo
        {
            get
            {
                return this.arrivalStationInfoField;
            }
            set
            {
                this.arrivalStationInfoField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("facilitiesInformation")]
        public Air_SellFromRecommendationReplyItineraryDetailsSegmentInformationApdSegmentFacilitiesInformation[] facilitiesInformation
        {
            get
            {
                return this.facilitiesInformationField;
            }
            set
            {
                this.facilitiesInformationField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/ITARES_05_2_IA")]
    public partial class Air_SellFromRecommendationReplyItineraryDetailsSegmentInformationApdSegmentLegDetails
    {

        private string equipmentField;

        private decimal numberOfStopsField;

        private bool numberOfStopsFieldSpecified;

        private decimal durationField;

        private bool durationFieldSpecified;

        private decimal percentageField;

        private bool percentageFieldSpecified;

        private string daysOfOperationField;

        private string dateTimePeriodField;

        private string complexingFlightIndicatorField;

        private string[] locationsField;

        /// <comentarios/>
        public string equipment
        {
            get
            {
                return this.equipmentField;
            }
            set
            {
                this.equipmentField = value;
            }
        }

        /// <comentarios/>
        public decimal numberOfStops
        {
            get
            {
                return this.numberOfStopsField;
            }
            set
            {
                this.numberOfStopsField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool numberOfStopsSpecified
        {
            get
            {
                return this.numberOfStopsFieldSpecified;
            }
            set
            {
                this.numberOfStopsFieldSpecified = value;
            }
        }

        /// <comentarios/>
        public decimal duration
        {
            get
            {
                return this.durationField;
            }
            set
            {
                this.durationField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool durationSpecified
        {
            get
            {
                return this.durationFieldSpecified;
            }
            set
            {
                this.durationFieldSpecified = value;
            }
        }

        /// <comentarios/>
        public decimal percentage
        {
            get
            {
                return this.percentageField;
            }
            set
            {
                this.percentageField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool percentageSpecified
        {
            get
            {
                return this.percentageFieldSpecified;
            }
            set
            {
                this.percentageFieldSpecified = value;
            }
        }

        /// <comentarios/>
        public string daysOfOperation
        {
            get
            {
                return this.daysOfOperationField;
            }
            set
            {
                this.daysOfOperationField = value;
            }
        }

        /// <comentarios/>
        public string dateTimePeriod
        {
            get
            {
                return this.dateTimePeriodField;
            }
            set
            {
                this.dateTimePeriodField = value;
            }
        }

        /// <comentarios/>
        public string complexingFlightIndicator
        {
            get
            {
                return this.complexingFlightIndicatorField;
            }
            set
            {
                this.complexingFlightIndicatorField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("locations")]
        public string[] locations
        {
            get
            {
                return this.locationsField;
            }
            set
            {
                this.locationsField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/ITARES_05_2_IA")]
    public partial class Air_SellFromRecommendationReplyItineraryDetailsSegmentInformationApdSegmentDepartureStationInfo
    {

        private string gateDescriptionField;

        private string terminalField;

        private string concourseField;

        /// <comentarios/>
        public string gateDescription
        {
            get
            {
                return this.gateDescriptionField;
            }
            set
            {
                this.gateDescriptionField = value;
            }
        }

        /// <comentarios/>
        public string terminal
        {
            get
            {
                return this.terminalField;
            }
            set
            {
                this.terminalField = value;
            }
        }

        /// <comentarios/>
        public string concourse
        {
            get
            {
                return this.concourseField;
            }
            set
            {
                this.concourseField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/ITARES_05_2_IA")]
    public partial class Air_SellFromRecommendationReplyItineraryDetailsSegmentInformationApdSegmentArrivalStationInfo
    {

        private string gateDescriptionField;

        private string terminalField;

        private string concourseField;

        /// <comentarios/>
        public string gateDescription
        {
            get
            {
                return this.gateDescriptionField;
            }
            set
            {
                this.gateDescriptionField = value;
            }
        }

        /// <comentarios/>
        public string terminal
        {
            get
            {
                return this.terminalField;
            }
            set
            {
                this.terminalField = value;
            }
        }

        /// <comentarios/>
        public string concourse
        {
            get
            {
                return this.concourseField;
            }
            set
            {
                this.concourseField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/ITARES_05_2_IA")]
    public partial class Air_SellFromRecommendationReplyItineraryDetailsSegmentInformationApdSegmentFacilitiesInformation
    {

        private string codeField;

        private string descriptionField;

        private string qualifierField;

        private string[] extensionCodeField;

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
        public string description
        {
            get
            {
                return this.descriptionField;
            }
            set
            {
                this.descriptionField = value;
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
        [System.Xml.Serialization.XmlElementAttribute("extensionCode")]
        public string[] extensionCode
        {
            get
            {
                return this.extensionCodeField;
            }
            set
            {
                this.extensionCodeField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/ITARES_05_2_IA")]
    public partial class Air_SellFromRecommendationReplyItineraryDetailsSegmentInformationActionDetails
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

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/ITARES_05_2_IA")]
    public partial class Air_SellFromRecommendationReplyItineraryDetailsSegmentInformationInformationText
    {

        private Air_SellFromRecommendationReplyItineraryDetailsSegmentInformationInformationTextFreeTextQualification freeTextQualificationField;

        private string[] freeTextField;

        /// <comentarios/>
        public Air_SellFromRecommendationReplyItineraryDetailsSegmentInformationInformationTextFreeTextQualification freeTextQualification
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/ITARES_05_2_IA")]
    public partial class Air_SellFromRecommendationReplyItineraryDetailsSegmentInformationInformationTextFreeTextQualification
    {

        private string textSubjectQualifierField;

        private string informationTypeField;

        private string statusField;

        private string companyIdField;

        private string languageField;

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
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/ITARES_05_2_IA")]
    public partial class Air_SellFromRecommendationReplyItineraryDetailsSegmentInformationErrorAtSegmentLevel
    {

        private Air_SellFromRecommendationReplyItineraryDetailsSegmentInformationErrorAtSegmentLevelErrorSegment errorSegmentField;

        private Air_SellFromRecommendationReplyItineraryDetailsSegmentInformationErrorAtSegmentLevelInformationText informationTextField;

        /// <comentarios/>
        public Air_SellFromRecommendationReplyItineraryDetailsSegmentInformationErrorAtSegmentLevelErrorSegment errorSegment
        {
            get
            {
                return this.errorSegmentField;
            }
            set
            {
                this.errorSegmentField = value;
            }
        }

        /// <comentarios/>
        public Air_SellFromRecommendationReplyItineraryDetailsSegmentInformationErrorAtSegmentLevelInformationText informationText
        {
            get
            {
                return this.informationTextField;
            }
            set
            {
                this.informationTextField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/ITARES_05_2_IA")]
    public partial class Air_SellFromRecommendationReplyItineraryDetailsSegmentInformationErrorAtSegmentLevelErrorSegment
    {

        private Air_SellFromRecommendationReplyItineraryDetailsSegmentInformationErrorAtSegmentLevelErrorSegmentErrorDetails errorDetailsField;

        /// <comentarios/>
        public Air_SellFromRecommendationReplyItineraryDetailsSegmentInformationErrorAtSegmentLevelErrorSegmentErrorDetails errorDetails
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/ITARES_05_2_IA")]
    public partial class Air_SellFromRecommendationReplyItineraryDetailsSegmentInformationErrorAtSegmentLevelErrorSegmentErrorDetails
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/ITARES_05_2_IA")]
    public partial class Air_SellFromRecommendationReplyItineraryDetailsSegmentInformationErrorAtSegmentLevelInformationText
    {

        private Air_SellFromRecommendationReplyItineraryDetailsSegmentInformationErrorAtSegmentLevelInformationTextFreeTextQualification freeTextQualificationField;

        private string[] freeTextField;

        /// <comentarios/>
        public Air_SellFromRecommendationReplyItineraryDetailsSegmentInformationErrorAtSegmentLevelInformationTextFreeTextQualification freeTextQualification
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/ITARES_05_2_IA")]
    public partial class Air_SellFromRecommendationReplyItineraryDetailsSegmentInformationErrorAtSegmentLevelInformationTextFreeTextQualification
    {

        private string textSubjectQualifierField;

        private string informationTypeField;

        private string statusField;

        private string companyIdField;

        private string languageField;

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
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AmadeusLib.Servicios.Fare_MasterPricerTravelBoardSearch.Response
{
    
    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A", IsNullable = false)]
    public partial class Fare_MasterPricerTravelBoardSearchReply
    {

        private StatusDetailsType[] replyStatusField;

        private Fare_MasterPricerTravelBoardSearchReplyErrorMessage errorMessageField;

        private ConversionRateDetailsTypeI_179848C[] conversionRateField;

        private FareInformationType[] solutionFamilyField;

        private FareFamilyType[] familyInformationField;

        private Fare_MasterPricerTravelBoardSearchReplyAmountInfoForAllPax amountInfoForAllPaxField;

        private Fare_MasterPricerTravelBoardSearchReplyAmountInfoPerPax[] amountInfoPerPaxField;

        private Fare_MasterPricerTravelBoardSearchReplyFeeDetails[] feeDetailsField;

        private CompanyIdentificationTextType[] companyIdTextField;

        private Fare_MasterPricerTravelBoardSearchReplyOfficeIdDetails[] officeIdDetailsField;

        private Fare_MasterPricerTravelBoardSearchReplyFlightIndex[] flightIndexField;

        private Fare_MasterPricerTravelBoardSearchReplyRecommendation[] recommendationField;

        private Fare_MasterPricerTravelBoardSearchReplyOtherSolutions[] otherSolutionsField;

        private Fare_MasterPricerTravelBoardSearchReplyWarningInfo[] warningInfoField;

        private Fare_MasterPricerTravelBoardSearchReplyGlobalInformation[] globalInformationField;

        private Fare_MasterPricerTravelBoardSearchReplyServiceFeesGrp[] serviceFeesGrpField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayItemAttribute("status", IsNullable = false)]
        public StatusDetailsType[] replyStatus
        {
            get
            {
                return this.replyStatusField;
            }
            set
            {
                this.replyStatusField = value;
            }
        }

        /// <comentarios/>
        public Fare_MasterPricerTravelBoardSearchReplyErrorMessage errorMessage
        {
            get
            {
                return this.errorMessageField;
            }
            set
            {
                this.errorMessageField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayItemAttribute("conversionRateDetail", IsNullable = false)]
        public ConversionRateDetailsTypeI_179848C[] conversionRate
        {
            get
            {
                return this.conversionRateField;
            }
            set
            {
                this.conversionRateField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("solutionFamily")]
        public FareInformationType[] solutionFamily
        {
            get
            {
                return this.solutionFamilyField;
            }
            set
            {
                this.solutionFamilyField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("familyInformation")]
        public FareFamilyType[] familyInformation
        {
            get
            {
                return this.familyInformationField;
            }
            set
            {
                this.familyInformationField = value;
            }
        }

        /// <comentarios/>
        public Fare_MasterPricerTravelBoardSearchReplyAmountInfoForAllPax amountInfoForAllPax
        {
            get
            {
                return this.amountInfoForAllPaxField;
            }
            set
            {
                this.amountInfoForAllPaxField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("amountInfoPerPax")]
        public Fare_MasterPricerTravelBoardSearchReplyAmountInfoPerPax[] amountInfoPerPax
        {
            get
            {
                return this.amountInfoPerPaxField;
            }
            set
            {
                this.amountInfoPerPaxField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("feeDetails")]
        public Fare_MasterPricerTravelBoardSearchReplyFeeDetails[] feeDetails
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

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("companyIdText")]
        public CompanyIdentificationTextType[] companyIdText
        {
            get
            {
                return this.companyIdTextField;
            }
            set
            {
                this.companyIdTextField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("officeIdDetails")]
        public Fare_MasterPricerTravelBoardSearchReplyOfficeIdDetails[] officeIdDetails
        {
            get
            {
                return this.officeIdDetailsField;
            }
            set
            {
                this.officeIdDetailsField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("flightIndex")]
        public Fare_MasterPricerTravelBoardSearchReplyFlightIndex[] flightIndex
        {
            get
            {
                return this.flightIndexField;
            }
            set
            {
                this.flightIndexField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("recommendation")]
        public Fare_MasterPricerTravelBoardSearchReplyRecommendation[] recommendation
        {
            get
            {
                return this.recommendationField;
            }
            set
            {
                this.recommendationField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("otherSolutions")]
        public Fare_MasterPricerTravelBoardSearchReplyOtherSolutions[] otherSolutions
        {
            get
            {
                return this.otherSolutionsField;
            }
            set
            {
                this.otherSolutionsField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("warningInfo")]
        public Fare_MasterPricerTravelBoardSearchReplyWarningInfo[] warningInfo
        {
            get
            {
                return this.warningInfoField;
            }
            set
            {
                this.warningInfoField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("globalInformation")]
        public Fare_MasterPricerTravelBoardSearchReplyGlobalInformation[] globalInformation
        {
            get
            {
                return this.globalInformationField;
            }
            set
            {
                this.globalInformationField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("serviceFeesGrp")]
        public Fare_MasterPricerTravelBoardSearchReplyServiceFeesGrp[] serviceFeesGrp
        {
            get
            {
                return this.serviceFeesGrpField;
            }
            set
            {
                this.serviceFeesGrpField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class StatusDetailsType
    {

        private string advisoryTypeInfoField;

        private string notificationField;

        private string notification2Field;

        private string descriptionField;

        /// <comentarios/>
        public string advisoryTypeInfo
        {
            get
            {
                return this.advisoryTypeInfoField;
            }
            set
            {
                this.advisoryTypeInfoField = value;
            }
        }

        /// <comentarios/>
        public string notification
        {
            get
            {
                return this.notificationField;
            }
            set
            {
                this.notificationField = value;
            }
        }

        /// <comentarios/>
        public string notification2
        {
            get
            {
                return this.notification2Field;
            }
            set
            {
                this.notification2Field = value;
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
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class TravellerReferenceInformationType
    {

        private string[] ptcField;

        private TravellerDetailsType[] travellerField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("ptc")]
        public string[] ptc
        {
            get
            {
                return this.ptcField;
            }
            set
            {
                this.ptcField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("traveller")]
        public TravellerDetailsType[] traveller
        {
            get
            {
                return this.travellerField;
            }
            set
            {
                this.travellerField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class TravellerDetailsType
    {

        private string refField;

        private string infantIndicatorField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
        public string @ref
        {
            get
            {
                return this.refField;
            }
            set
            {
                this.refField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class TaxType
    {

        private string taxCategoryField;

        private TaxDetailsType[] taxDetailsField;

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
        [System.Xml.Serialization.XmlElementAttribute("taxDetails")]
        public TaxDetailsType[] taxDetails
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class TaxDetailsType
    {

        private string rateField;

        private string countryCodeField;

        private string currencyCodeField;

        private string typeField;

        private string[] indicatorField;

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
        [System.Xml.Serialization.XmlElementAttribute("indicator")]
        public string[] indicator
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class SpecificDataInformationType
    {

        private DataTypeInformationType dataTypeInformationField;

        private DataInformationType[] dataInformationField;

        /// <comentarios/>
        public DataTypeInformationType dataTypeInformation
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
        public DataInformationType[] dataInformation
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class DataTypeInformationType
    {

        private string subTypeField;

        private string optionField;

        /// <comentarios/>
        public string subType
        {
            get
            {
                return this.subTypeField;
            }
            set
            {
                this.subTypeField = value;
            }
        }

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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class DataInformationType
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class SpecialRequirementsTypeDetailsType
    {

        private string serviceClassificationField;

        private string serviceStatusField;

        private string serviceNumberOfInstancesField;

        private string serviceMarketingCarrierField;

        private string serviceGroupField;

        private string serviceSubGroupField;

        private string[] serviceFreeTextField;

        /// <comentarios/>
        public string serviceClassification
        {
            get
            {
                return this.serviceClassificationField;
            }
            set
            {
                this.serviceClassificationField = value;
            }
        }

        /// <comentarios/>
        public string serviceStatus
        {
            get
            {
                return this.serviceStatusField;
            }
            set
            {
                this.serviceStatusField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
        public string serviceNumberOfInstances
        {
            get
            {
                return this.serviceNumberOfInstancesField;
            }
            set
            {
                this.serviceNumberOfInstancesField = value;
            }
        }

        /// <comentarios/>
        public string serviceMarketingCarrier
        {
            get
            {
                return this.serviceMarketingCarrierField;
            }
            set
            {
                this.serviceMarketingCarrierField = value;
            }
        }

        /// <comentarios/>
        public string serviceGroup
        {
            get
            {
                return this.serviceGroupField;
            }
            set
            {
                this.serviceGroupField = value;
            }
        }

        /// <comentarios/>
        public string serviceSubGroup
        {
            get
            {
                return this.serviceSubGroupField;
            }
            set
            {
                this.serviceSubGroupField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("serviceFreeText")]
        public string[] serviceFreeText
        {
            get
            {
                return this.serviceFreeTextField;
            }
            set
            {
                this.serviceFreeTextField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class SpecialRequirementsDetailsType
    {

        private SpecialRequirementsTypeDetailsType serviceRequirementsInfoField;

        private SpecialRequirementsDataDetailsType[] seatDetailsField;

        /// <comentarios/>
        public SpecialRequirementsTypeDetailsType serviceRequirementsInfo
        {
            get
            {
                return this.serviceRequirementsInfoField;
            }
            set
            {
                this.serviceRequirementsInfoField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("seatDetails")]
        public SpecialRequirementsDataDetailsType[] seatDetails
        {
            get
            {
                return this.seatDetailsField;
            }
            set
            {
                this.seatDetailsField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class SpecialRequirementsDataDetailsType
    {

        private string[] seatCharacteristicsField;

        private object dummyNETField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("seatCharacteristics")]
        public string[] seatCharacteristics
        {
            get
            {
                return this.seatCharacteristicsField;
            }
            set
            {
                this.seatCharacteristicsField = value;
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class SequenceInformationTypeU
    {

        private string numberField;

        private string identificationCodeField;

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
        public string identificationCode
        {
            get
            {
                return this.identificationCodeField;
            }
            set
            {
                this.identificationCodeField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class SequenceDetailsTypeU
    {

        private SequenceInformationTypeU sequenceDetailsField;

        /// <comentarios/>
        public SequenceInformationTypeU sequenceDetails
        {
            get
            {
                return this.sequenceDetailsField;
            }
            set
            {
                this.sequenceDetailsField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class SelectionDetailsType
    {

        private SelectionDetailsInformationType carrierFeeDetailsField;

        /// <comentarios/>
        public SelectionDetailsInformationType carrierFeeDetails
        {
            get
            {
                return this.carrierFeeDetailsField;
            }
            set
            {
                this.carrierFeeDetailsField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class SelectionDetailsInformationType
    {

        private string typeField;

        private string optionInformationField;

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
        public string optionInformation
        {
            get
            {
                return this.optionInformationField;
            }
            set
            {
                this.optionInformationField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class SegmentRepetitionControlDetailsTypeI
    {

        private string quantityField;

        private string numberOfUnitsField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
        public string quantity
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
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
        public string numberOfUnits
        {
            get
            {
                return this.numberOfUnitsField;
            }
            set
            {
                this.numberOfUnitsField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class ReferencingDetailsType_234704C
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class ReferencingDetailsType_195561C
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class ReferencingDetailsType_191583C
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class ReferenceInfoType
    {

        private ReferencingDetailsType_191583C[] referencingDetailField;

        private object dummyNETField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("referencingDetail")]
        public ReferencingDetailsType_191583C[] referencingDetail
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class ProductInformationType
    {

        private string productDetailsQualifierField;

        private ProductDetailsType[] bookingClassDetailsField;

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
        public ProductDetailsType[] bookingClassDetails
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class ProductDetailsType
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class PricingTicketingSubsequentType_144401S
    {

        private string paxFareNumField;

        private decimal totalFareAmountField;

        private decimal totalTaxAmountField;

        private bool totalTaxAmountFieldSpecified;

        private CompanyRoleIdentificationType_120771C[] codeShareDetailsField;

        private MonetaryInformationDetailsType[] monetaryDetailsField;

        private string[] pricingTicketingField;

        /// <comentarios/>
        public string paxFareNum
        {
            get
            {
                return this.paxFareNumField;
            }
            set
            {
                this.paxFareNumField = value;
            }
        }

        /// <comentarios/>
        public decimal totalFareAmount
        {
            get
            {
                return this.totalFareAmountField;
            }
            set
            {
                this.totalFareAmountField = value;
            }
        }

        /// <comentarios/>
        public decimal totalTaxAmount
        {
            get
            {
                return this.totalTaxAmountField;
            }
            set
            {
                this.totalTaxAmountField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool totalTaxAmountSpecified
        {
            get
            {
                return this.totalTaxAmountFieldSpecified;
            }
            set
            {
                this.totalTaxAmountFieldSpecified = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("codeShareDetails")]
        public CompanyRoleIdentificationType_120771C[] codeShareDetails
        {
            get
            {
                return this.codeShareDetailsField;
            }
            set
            {
                this.codeShareDetailsField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("monetaryDetails")]
        public MonetaryInformationDetailsType[] monetaryDetails
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
        [System.Xml.Serialization.XmlArrayItemAttribute("priceType", IsNullable = false)]
        public string[] pricingTicketing
        {
            get
            {
                return this.pricingTicketingField;
            }
            set
            {
                this.pricingTicketingField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class CompanyRoleIdentificationType_120771C
    {

        private string transportStageQualifierField;

        private string companyField;

        /// <comentarios/>
        public string transportStageQualifier
        {
            get
            {
                return this.transportStageQualifierField;
            }
            set
            {
                this.transportStageQualifierField = value;
            }
        }

        /// <comentarios/>
        public string company
        {
            get
            {
                return this.companyField;
            }
            set
            {
                this.companyField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class MonetaryInformationDetailsType
    {

        private string amountTypeField;

        private decimal amountField;

        private string currencyField;

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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class OriginAndDestinationRequestType_134833S
    {

        private string segRefField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
        public string segRef
        {
            get
            {
                return this.segRefField;
            }
            set
            {
                this.segRefField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class MonetaryInformationDetailsTypeI
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class MiniRulesType
    {

        private string restrictionTypeField;

        private string categoryField;

        private string[] indicatorField;

        private MiniRulesDetailsType[] miniRulesField;

        /// <comentarios/>
        public string restrictionType
        {
            get
            {
                return this.restrictionTypeField;
            }
            set
            {
                this.restrictionTypeField = value;
            }
        }

        /// <comentarios/>
        public string category
        {
            get
            {
                return this.categoryField;
            }
            set
            {
                this.categoryField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayItemAttribute("ruleIndicator", IsNullable = false)]
        public string[] indicator
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

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("miniRules")]
        public MiniRulesDetailsType[] miniRules
        {
            get
            {
                return this.miniRulesField;
            }
            set
            {
                this.miniRulesField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class MiniRulesDetailsType
    {

        private string interpretationField;

        private string[] valueField;

        /// <comentarios/>
        public string interpretation
        {
            get
            {
                return this.interpretationField;
            }
            set
            {
                this.interpretationField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("value")]
        public string[] value
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class ItemReferencesAndVersionsType
    {

        private string referenceTypeField;

        private string refNumberField;

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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class ItemNumberType_80866S
    {

        private ItemNumberIdentificationType itemNumberDetailsField;

        /// <comentarios/>
        public ItemNumberIdentificationType itemNumberDetails
        {
            get
            {
                return this.itemNumberDetailsField;
            }
            set
            {
                this.itemNumberDetailsField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class ItemNumberIdentificationType
    {

        private string numberField;

        private string typeField;

        private string qualifierField;

        private string responsibleAgencyField;

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
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class ItemNumberType_161497S
    {

        private ItemNumberIdentificationType_191597C itemNumberIdField;

        private CompanyRoleIdentificationType_120771C[] codeShareDetailsField;

        private string[] priceTicketingField;

        /// <comentarios/>
        public ItemNumberIdentificationType_191597C itemNumberId
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

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("codeShareDetails")]
        public CompanyRoleIdentificationType_120771C[] codeShareDetails
        {
            get
            {
                return this.codeShareDetailsField;
            }
            set
            {
                this.codeShareDetailsField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayItemAttribute("priceType", IsNullable = false)]
        public string[] priceTicketing
        {
            get
            {
                return this.priceTicketingField;
            }
            set
            {
                this.priceTicketingField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class ItemNumberIdentificationType_191597C
    {

        private string numberField;

        private string numberTypeField;

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
        public string numberType
        {
            get
            {
                return this.numberTypeField;
            }
            set
            {
                this.numberTypeField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class ItemNumberType
    {

        private ItemNumberIdentificationType_192331C itemNumberField;

        /// <comentarios/>
        public ItemNumberIdentificationType_192331C itemNumber
        {
            get
            {
                return this.itemNumberField;
            }
            set
            {
                this.itemNumberField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class ItemNumberIdentificationType_192331C
    {

        private string numberField;

        private string typeField;

        private string qualifierField;

        private string responsibleAgencyField;

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
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class ItemNumberIdentificationType_234878C
    {

        private string numberField;

        private string typeField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class InteractiveFreeTextType_78559S
    {

        private FreeTextQualificationType_120769C freeTextQualificationField;

        private string[] descriptionField;

        /// <comentarios/>
        public FreeTextQualificationType_120769C freeTextQualification
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
        [System.Xml.Serialization.XmlElementAttribute("description")]
        public string[] description
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
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class FreeTextQualificationType_120769C
    {

        private string textSubjectQualifierField;

        private string informationTypeField;

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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class InteractiveFreeTextType
    {

        private FreeTextQualificationType freeTextQualificationField;

        private string[] descriptionField;

        /// <comentarios/>
        public FreeTextQualificationType freeTextQualification
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
        [System.Xml.Serialization.XmlElementAttribute("description")]
        public string[] description
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
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class FreeTextQualificationType
    {

        private string textSubjectQualifierField;

        private string informationTypeField;

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
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class HeaderInformationTypeI
    {

        private string[] statusField;

        private DateTimePeriodDetailsTypeI dateTimePeriodDetailsField;

        private string referenceNumberField;

        private string[] productIdentificationField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("status")]
        public string[] status
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
        public DateTimePeriodDetailsTypeI dateTimePeriodDetails
        {
            get
            {
                return this.dateTimePeriodDetailsField;
            }
            set
            {
                this.dateTimePeriodDetailsField = value;
            }
        }

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
        [System.Xml.Serialization.XmlElementAttribute("productIdentification")]
        public string[] productIdentification
        {
            get
            {
                return this.productIdentificationField;
            }
            set
            {
                this.productIdentificationField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class DateTimePeriodDetailsTypeI
    {

        private string qualifierField;

        private string valueField;

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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class FlightProductInformationType_161491S
    {

        private CabinProductDetailsType_229142C cabinProductField;

        private FareProductDetailsType_229143C fareProductDetailField;

        /// <comentarios/>
        public CabinProductDetailsType_229142C cabinProduct
        {
            get
            {
                return this.cabinProductField;
            }
            set
            {
                this.cabinProductField = value;
            }
        }

        /// <comentarios/>
        public FareProductDetailsType_229143C fareProductDetail
        {
            get
            {
                return this.fareProductDetailField;
            }
            set
            {
                this.fareProductDetailField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class CabinProductDetailsType_229142C
    {

        private string rbdField;

        private string cabinField;

        private string avlStatusField;

        /// <comentarios/>
        public string rbd
        {
            get
            {
                return this.rbdField;
            }
            set
            {
                this.rbdField = value;
            }
        }

        /// <comentarios/>
        public string cabin
        {
            get
            {
                return this.cabinField;
            }
            set
            {
                this.cabinField = value;
            }
        }

        /// <comentarios/>
        public string avlStatus
        {
            get
            {
                return this.avlStatusField;
            }
            set
            {
                this.avlStatusField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class FareProductDetailsType_229143C
    {

        private string fareBasisField;

        /// <comentarios/>
        public string fareBasis
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
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class FlightProductInformationType_134801S
    {

        private CabinProductDetailsType_195516C[] cabinProductField;

        private string[] contextDetailsField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("cabinProduct")]
        public CabinProductDetailsType_195516C[] cabinProduct
        {
            get
            {
                return this.cabinProductField;
            }
            set
            {
                this.cabinProductField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayItemAttribute("availabilityCnxType", IsNullable = false)]
        public string[] contextDetails
        {
            get
            {
                return this.contextDetailsField;
            }
            set
            {
                this.contextDetailsField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class CabinProductDetailsType_195516C
    {

        private string rbdField;

        private string bookingModifierField;

        private string cabinField;

        private string avlStatusField;

        /// <comentarios/>
        public string rbd
        {
            get
            {
                return this.rbdField;
            }
            set
            {
                this.rbdField = value;
            }
        }

        /// <comentarios/>
        public string bookingModifier
        {
            get
            {
                return this.bookingModifierField;
            }
            set
            {
                this.bookingModifierField = value;
            }
        }

        /// <comentarios/>
        public string cabin
        {
            get
            {
                return this.cabinField;
            }
            set
            {
                this.cabinField = value;
            }
        }

        /// <comentarios/>
        public string avlStatus
        {
            get
            {
                return this.avlStatusField;
            }
            set
            {
                this.avlStatusField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class FlightProductInformationType
    {

        private CabinProductDetailsType cabinProductField;

        private FareProductDetailsType fareProductDetailField;

        private string[] corporateIdField;

        private string breakPointField;

        private string[] contextDetailsField;

        /// <comentarios/>
        public CabinProductDetailsType cabinProduct
        {
            get
            {
                return this.cabinProductField;
            }
            set
            {
                this.cabinProductField = value;
            }
        }

        /// <comentarios/>
        public FareProductDetailsType fareProductDetail
        {
            get
            {
                return this.fareProductDetailField;
            }
            set
            {
                this.fareProductDetailField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("corporateId")]
        public string[] corporateId
        {
            get
            {
                return this.corporateIdField;
            }
            set
            {
                this.corporateIdField = value;
            }
        }

        /// <comentarios/>
        public string breakPoint
        {
            get
            {
                return this.breakPointField;
            }
            set
            {
                this.breakPointField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayItemAttribute("availabilityCnxType", IsNullable = false)]
        public string[] contextDetails
        {
            get
            {
                return this.contextDetailsField;
            }
            set
            {
                this.contextDetailsField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class CabinProductDetailsType
    {

        private string rbdField;

        private string bookingModifierField;

        private string cabinField;

        private string avlStatusField;

        /// <comentarios/>
        public string rbd
        {
            get
            {
                return this.rbdField;
            }
            set
            {
                this.rbdField = value;
            }
        }

        /// <comentarios/>
        public string bookingModifier
        {
            get
            {
                return this.bookingModifierField;
            }
            set
            {
                this.bookingModifierField = value;
            }
        }

        /// <comentarios/>
        public string cabin
        {
            get
            {
                return this.cabinField;
            }
            set
            {
                this.cabinField = value;
            }
        }

        /// <comentarios/>
        public string avlStatus
        {
            get
            {
                return this.avlStatusField;
            }
            set
            {
                this.avlStatusField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class FareProductDetailsType
    {

        private string fareBasisField;

        private string passengerTypeField;

        private string[] fareTypeField;

        /// <comentarios/>
        public string fareBasis
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
        public string passengerType
        {
            get
            {
                return this.passengerTypeField;
            }
            set
            {
                this.passengerTypeField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("fareType")]
        public string[] fareType
        {
            get
            {
                return this.fareTypeField;
            }
            set
            {
                this.fareTypeField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class FareQualifierDetailsType
    {

        private string movementTypeField;

        private FareCategoryCodesTypeI fareCategoriesField;

        private FareDetailsTypeI fareDetailsField;

        private AdditionalFareQualifierDetailsTypeI additionalFareDetailsField;

        private DiscountPenaltyInformationType[] discountDetailsField;

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
        public FareCategoryCodesTypeI fareCategories
        {
            get
            {
                return this.fareCategoriesField;
            }
            set
            {
                this.fareCategoriesField = value;
            }
        }

        /// <comentarios/>
        public FareDetailsTypeI fareDetails
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

        /// <comentarios/>
        public AdditionalFareQualifierDetailsTypeI additionalFareDetails
        {
            get
            {
                return this.additionalFareDetailsField;
            }
            set
            {
                this.additionalFareDetailsField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("discountDetails")]
        public DiscountPenaltyInformationType[] discountDetails
        {
            get
            {
                return this.discountDetailsField;
            }
            set
            {
                this.discountDetailsField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class FareCategoryCodesTypeI
    {

        private string fareTypeField;

        private string[] otherFareTypeField;

        /// <comentarios/>
        public string fareType
        {
            get
            {
                return this.fareTypeField;
            }
            set
            {
                this.fareTypeField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("otherFareType")]
        public string[] otherFareType
        {
            get
            {
                return this.otherFareTypeField;
            }
            set
            {
                this.otherFareTypeField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class FareDetailsTypeI
    {

        private string qualifierField;

        private decimal rateField;

        private bool rateFieldSpecified;

        private string countryField;

        private string fareCategoryField;

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
        public decimal rate
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
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool rateSpecified
        {
            get
            {
                return this.rateFieldSpecified;
            }
            set
            {
                this.rateFieldSpecified = value;
            }
        }

        /// <comentarios/>
        public string country
        {
            get
            {
                return this.countryField;
            }
            set
            {
                this.countryField = value;
            }
        }

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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class AdditionalFareQualifierDetailsTypeI
    {

        private string rateClassField;

        private string ticketDesignatorField;

        private string pricingGroupField;

        private string[] secondRateClassField;

        /// <comentarios/>
        public string rateClass
        {
            get
            {
                return this.rateClassField;
            }
            set
            {
                this.rateClassField = value;
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
        public string pricingGroup
        {
            get
            {
                return this.pricingGroupField;
            }
            set
            {
                this.pricingGroupField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("secondRateClass")]
        public string[] secondRateClass
        {
            get
            {
                return this.secondRateClassField;
            }
            set
            {
                this.secondRateClassField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class DiscountPenaltyInformationType
    {

        private string fareQualifierField;

        private string rateCategoryField;

        private decimal amountField;

        private bool amountFieldSpecified;

        private decimal percentageField;

        private bool percentageFieldSpecified;

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
        public string rateCategory
        {
            get
            {
                return this.rateCategoryField;
            }
            set
            {
                this.rateCategoryField = value;
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
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class FareInformationTypeI
    {

        private string valueQualifierField;

        private string valueField;

        /// <comentarios/>
        public string valueQualifier
        {
            get
            {
                return this.valueQualifierField;
            }
            set
            {
                this.valueQualifierField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class FareCalculationCodeDetailsType
    {

        private string qualifierField;

        private decimal amountField;

        private bool amountFieldSpecified;

        private string locationCodeField;

        private string otherLocationCodeField;

        private decimal rateField;

        private bool rateFieldSpecified;

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
        public string locationCode
        {
            get
            {
                return this.locationCodeField;
            }
            set
            {
                this.locationCodeField = value;
            }
        }

        /// <comentarios/>
        public string otherLocationCode
        {
            get
            {
                return this.otherLocationCodeField;
            }
            set
            {
                this.otherLocationCodeField = value;
            }
        }

        /// <comentarios/>
        public decimal rate
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
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool rateSpecified
        {
            get
            {
                return this.rateFieldSpecified;
            }
            set
            {
                this.rateFieldSpecified = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class ExcessBaggageType
    {

        private BaggageDetailsType baggageDetailsField;

        private BagtagDetailsType[] bagTagDetailsField;

        /// <comentarios/>
        public BaggageDetailsType baggageDetails
        {
            get
            {
                return this.baggageDetailsField;
            }
            set
            {
                this.baggageDetailsField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("bagTagDetails")]
        public BagtagDetailsType[] bagTagDetails
        {
            get
            {
                return this.bagTagDetailsField;
            }
            set
            {
                this.bagTagDetailsField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class BaggageDetailsType
    {

        private string freeAllowanceField;

        private string quantityCodeField;

        private string unitQualifierField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
        public string freeAllowance
        {
            get
            {
                return this.freeAllowanceField;
            }
            set
            {
                this.freeAllowanceField = value;
            }
        }

        /// <comentarios/>
        public string quantityCode
        {
            get
            {
                return this.quantityCodeField;
            }
            set
            {
                this.quantityCodeField = value;
            }
        }

        /// <comentarios/>
        public string unitQualifier
        {
            get
            {
                return this.unitQualifierField;
            }
            set
            {
                this.unitQualifierField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class BagtagDetailsType
    {

        private string identifierField;

        private string numberField;

        /// <comentarios/>
        public string identifier
        {
            get
            {
                return this.identifierField;
            }
            set
            {
                this.identifierField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class DummySegmentTypeI
    {
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class CompanyRoleIdentificationType
    {

        private string codeShareTypeField;

        private string airlineDesignatorField;

        private string flightNumberField;

        /// <comentarios/>
        public string codeShareType
        {
            get
            {
                return this.codeShareTypeField;
            }
            set
            {
                this.codeShareTypeField = value;
            }
        }

        /// <comentarios/>
        public string airlineDesignator
        {
            get
            {
                return this.airlineDesignatorField;
            }
            set
            {
                this.airlineDesignatorField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
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
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class CommercialAgreementsType
    {

        private CompanyRoleIdentificationType codeshareDetailsField;

        private CompanyRoleIdentificationType[] otherCodeshareDetailsField;

        /// <comentarios/>
        public CompanyRoleIdentificationType codeshareDetails
        {
            get
            {
                return this.codeshareDetailsField;
            }
            set
            {
                this.codeshareDetailsField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("otherCodeshareDetails")]
        public CompanyRoleIdentificationType[] otherCodeshareDetails
        {
            get
            {
                return this.otherCodeshareDetailsField;
            }
            set
            {
                this.otherCodeshareDetailsField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class AttributeType
    {

        private string attributeQualifierField;

        private AttributeInformationType_97181C[] attributeDetailsField;

        /// <comentarios/>
        public string attributeQualifier
        {
            get
            {
                return this.attributeQualifierField;
            }
            set
            {
                this.attributeQualifierField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("attributeDetails")]
        public AttributeInformationType_97181C[] attributeDetails
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
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class AttributeInformationType_97181C
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class AttributeTypeU
    {

        private string attributeFunctionField;

        private AttributeInformationTypeU attributeDetailsField;

        /// <comentarios/>
        public string attributeFunction
        {
            get
            {
                return this.attributeFunctionField;
            }
            set
            {
                this.attributeFunctionField = value;
            }
        }

        /// <comentarios/>
        public AttributeInformationTypeU attributeDetails
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
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class ReferenceType
    {

        private string refOfLegField;

        private string firstItemIdentifierField;

        private string lastItemIdentifierField;

        /// <comentarios/>
        public string refOfLeg
        {
            get
            {
                return this.refOfLegField;
            }
            set
            {
                this.refOfLegField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
        public string firstItemIdentifier
        {
            get
            {
                return this.firstItemIdentifierField;
            }
            set
            {
                this.firstItemIdentifierField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
        public string lastItemIdentifier
        {
            get
            {
                return this.lastItemIdentifierField;
            }
            set
            {
                this.lastItemIdentifierField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class ProcessingInformationType
    {

        private string actionQualifierField;

        private string referenceQualifierField;

        private string refNumField;

        /// <comentarios/>
        public string actionQualifier
        {
            get
            {
                return this.actionQualifierField;
            }
            set
            {
                this.actionQualifierField = value;
            }
        }

        /// <comentarios/>
        public string referenceQualifier
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

        /// <comentarios/>
        public string refNum
        {
            get
            {
                return this.refNumField;
            }
            set
            {
                this.refNumField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class ActionDetailsType
    {

        private ProcessingInformationType numberOfItemsDetailsField;

        private ReferenceType[] lastItemsDetailsField;

        /// <comentarios/>
        public ProcessingInformationType numberOfItemsDetails
        {
            get
            {
                return this.numberOfItemsDetailsField;
            }
            set
            {
                this.numberOfItemsDetailsField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("lastItemsDetails")]
        public ReferenceType[] lastItemsDetails
        {
            get
            {
                return this.lastItemsDetailsField;
            }
            set
            {
                this.lastItemsDetailsField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class DateAndTimeDetailsType
    {

        private string dateQualifierField;

        private string dateField;

        private string firstTimeField;

        private string equipementTypeField;

        private string locationIdField;

        /// <comentarios/>
        public string dateQualifier
        {
            get
            {
                return this.dateQualifierField;
            }
            set
            {
                this.dateQualifierField = value;
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
        public string firstTime
        {
            get
            {
                return this.firstTimeField;
            }
            set
            {
                this.firstTimeField = value;
            }
        }

        /// <comentarios/>
        public string equipementType
        {
            get
            {
                return this.equipementTypeField;
            }
            set
            {
                this.equipementTypeField = value;
            }
        }

        /// <comentarios/>
        public string locationId
        {
            get
            {
                return this.locationIdField;
            }
            set
            {
                this.locationIdField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class DateAndTimeInformationType
    {

        private DateAndTimeDetailsType[] stopDetailsField;

        private object dummyNETField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("stopDetails")]
        public DateAndTimeDetailsType[] stopDetails
        {
            get
            {
                return this.stopDetailsField;
            }
            set
            {
                this.stopDetailsField = value;
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class CabinProductDetailsType_205138C
    {

        private string rbdField;

        private string bookingModifierField;

        private string cabinField;

        private string avlStatusField;

        /// <comentarios/>
        public string rbd
        {
            get
            {
                return this.rbdField;
            }
            set
            {
                this.rbdField = value;
            }
        }

        /// <comentarios/>
        public string bookingModifier
        {
            get
            {
                return this.bookingModifierField;
            }
            set
            {
                this.bookingModifierField = value;
            }
        }

        /// <comentarios/>
        public string cabin
        {
            get
            {
                return this.cabinField;
            }
            set
            {
                this.cabinField = value;
            }
        }

        /// <comentarios/>
        public string avlStatus
        {
            get
            {
                return this.avlStatusField;
            }
            set
            {
                this.avlStatusField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class FlightProductInformationType_141442S
    {

        private CabinProductDetailsType_205138C[] cabinProductField;

        private string[] contextDetailsField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("cabinProduct")]
        public CabinProductDetailsType_205138C[] cabinProduct
        {
            get
            {
                return this.cabinProductField;
            }
            set
            {
                this.cabinProductField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayItemAttribute("avl", IsNullable = false)]
        public string[] contextDetails
        {
            get
            {
                return this.contextDetailsField;
            }
            set
            {
                this.contextDetailsField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class CodedAttributeInformationType_234684C
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class ProductFacilitiesType
    {

        private string lastSeatAvailableField;

        private string levelOfAccessField;

        private string electronicTicketingField;

        private string operationalSuffixField;

        private string productDetailQualifierField;

        private string[] flightCharacteristicField;

        /// <comentarios/>
        public string lastSeatAvailable
        {
            get
            {
                return this.lastSeatAvailableField;
            }
            set
            {
                this.lastSeatAvailableField = value;
            }
        }

        /// <comentarios/>
        public string levelOfAccess
        {
            get
            {
                return this.levelOfAccessField;
            }
            set
            {
                this.levelOfAccessField = value;
            }
        }

        /// <comentarios/>
        public string electronicTicketing
        {
            get
            {
                return this.electronicTicketingField;
            }
            set
            {
                this.electronicTicketingField = value;
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
        public string productDetailQualifier
        {
            get
            {
                return this.productDetailQualifierField;
            }
            set
            {
                this.productDetailQualifierField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("flightCharacteristic")]
        public string[] flightCharacteristic
        {
            get
            {
                return this.flightCharacteristicField;
            }
            set
            {
                this.flightCharacteristicField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class AdditionalProductDetailsType
    {

        private string equipmentTypeField;

        private string operatingDayField;

        private string techStopNumberField;

        private string[] locationIdField;

        /// <comentarios/>
        public string equipmentType
        {
            get
            {
                return this.equipmentTypeField;
            }
            set
            {
                this.equipmentTypeField = value;
            }
        }

        /// <comentarios/>
        public string operatingDay
        {
            get
            {
                return this.operatingDayField;
            }
            set
            {
                this.operatingDayField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
        public string techStopNumber
        {
            get
            {
                return this.techStopNumberField;
            }
            set
            {
                this.techStopNumberField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("locationId")]
        public string[] locationId
        {
            get
            {
                return this.locationIdField;
            }
            set
            {
                this.locationIdField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class CompanyIdentificationType
    {

        private string marketingCarrierField;

        private string operatingCarrierField;

        /// <comentarios/>
        public string marketingCarrier
        {
            get
            {
                return this.marketingCarrierField;
            }
            set
            {
                this.marketingCarrierField = value;
            }
        }

        /// <comentarios/>
        public string operatingCarrier
        {
            get
            {
                return this.operatingCarrierField;
            }
            set
            {
                this.operatingCarrierField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class LocationIdentificationDetailsType
    {

        private string locationIdField;

        private string airportCityQualifierField;

        private string terminalField;

        /// <comentarios/>
        public string locationId
        {
            get
            {
                return this.locationIdField;
            }
            set
            {
                this.locationIdField = value;
            }
        }

        /// <comentarios/>
        public string airportCityQualifier
        {
            get
            {
                return this.airportCityQualifierField;
            }
            set
            {
                this.airportCityQualifierField = value;
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
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class ProductDateTimeType
    {

        private string dateOfDepartureField;

        private string timeOfDepartureField;

        private string dateOfArrivalField;

        private string timeOfArrivalField;

        private string dateVariationField;

        /// <comentarios/>
        public string dateOfDeparture
        {
            get
            {
                return this.dateOfDepartureField;
            }
            set
            {
                this.dateOfDepartureField = value;
            }
        }

        /// <comentarios/>
        public string timeOfDeparture
        {
            get
            {
                return this.timeOfDepartureField;
            }
            set
            {
                this.timeOfDepartureField = value;
            }
        }

        /// <comentarios/>
        public string dateOfArrival
        {
            get
            {
                return this.dateOfArrivalField;
            }
            set
            {
                this.dateOfArrivalField = value;
            }
        }

        /// <comentarios/>
        public string timeOfArrival
        {
            get
            {
                return this.timeOfArrivalField;
            }
            set
            {
                this.timeOfArrivalField = value;
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class TravelProductType
    {

        private ProductDateTimeType productDateTimeField;

        private LocationIdentificationDetailsType[] locationField;

        private CompanyIdentificationType companyIdField;

        private string flightOrtrainNumberField;

        private AdditionalProductDetailsType productDetailField;

        private ProductFacilitiesType addProductDetailField;

        private CodedAttributeInformationType_234684C[] attributeDetailsField;

        /// <comentarios/>
        public ProductDateTimeType productDateTime
        {
            get
            {
                return this.productDateTimeField;
            }
            set
            {
                this.productDateTimeField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("location")]
        public LocationIdentificationDetailsType[] location
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

        /// <comentarios/>
        public CompanyIdentificationType companyId
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
        public string flightOrtrainNumber
        {
            get
            {
                return this.flightOrtrainNumberField;
            }
            set
            {
                this.flightOrtrainNumberField = value;
            }
        }

        /// <comentarios/>
        public AdditionalProductDetailsType productDetail
        {
            get
            {
                return this.productDetailField;
            }
            set
            {
                this.productDetailField = value;
            }
        }

        /// <comentarios/>
        public ProductFacilitiesType addProductDetail
        {
            get
            {
                return this.addProductDetailField;
            }
            set
            {
                this.addProductDetailField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("attributeDetails")]
        public CodedAttributeInformationType_234684C[] attributeDetails
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
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class ProposedSegmentDetailsType
    {

        private string refField;

        private string unitQualifierField;

        /// <comentarios/>
        public string @ref
        {
            get
            {
                return this.refField;
            }
            set
            {
                this.refField = value;
            }
        }

        /// <comentarios/>
        public string unitQualifier
        {
            get
            {
                return this.unitQualifierField;
            }
            set
            {
                this.unitQualifierField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class ProposedSegmentType
    {

        private ProposedSegmentDetailsType[] flightProposalField;

        private string flightCharacteristicField;

        private string majCabinField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("flightProposal")]
        public ProposedSegmentDetailsType[] flightProposal
        {
            get
            {
                return this.flightProposalField;
            }
            set
            {
                this.flightProposalField = value;
            }
        }

        /// <comentarios/>
        public string flightCharacteristic
        {
            get
            {
                return this.flightCharacteristicField;
            }
            set
            {
                this.flightCharacteristicField = value;
            }
        }

        /// <comentarios/>
        public string majCabin
        {
            get
            {
                return this.majCabinField;
            }
            set
            {
                this.majCabinField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class ItineraryDetailsType
    {

        private string airportCityQualifierField;

        private string segmentNumberField;

        /// <comentarios/>
        public string airportCityQualifier
        {
            get
            {
                return this.airportCityQualifierField;
            }
            set
            {
                this.airportCityQualifierField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
        public string segmentNumber
        {
            get
            {
                return this.segmentNumberField;
            }
            set
            {
                this.segmentNumberField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class OriginAndDestinationRequestType
    {

        private string segRefField;

        private ItineraryDetailsType[] locationForcingField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
        public string segRef
        {
            get
            {
                return this.segRefField;
            }
            set
            {
                this.segRefField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("locationForcing")]
        public ItineraryDetailsType[] locationForcing
        {
            get
            {
                return this.locationForcingField;
            }
            set
            {
                this.locationForcingField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class ItemReferencesAndVersionsType_78536S
    {

        private string referenceTypeField;

        private string refNumberField;

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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class OriginatorIdentificationDetailsTypeI
    {

        private string officeNameField;

        private string agentSigninField;

        private string confidentialOfficeField;

        private string otherOfficeField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
        public string officeName
        {
            get
            {
                return this.officeNameField;
            }
            set
            {
                this.officeNameField = value;
            }
        }

        /// <comentarios/>
        public string agentSignin
        {
            get
            {
                return this.agentSigninField;
            }
            set
            {
                this.agentSigninField = value;
            }
        }

        /// <comentarios/>
        public string confidentialOffice
        {
            get
            {
                return this.confidentialOfficeField;
            }
            set
            {
                this.confidentialOfficeField = value;
            }
        }

        /// <comentarios/>
        public string otherOffice
        {
            get
            {
                return this.otherOfficeField;
            }
            set
            {
                this.otherOfficeField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class UserIdentificationType
    {

        private OriginatorIdentificationDetailsTypeI officeIdentificationField;

        private string officeTypeField;

        private string officeCodeField;

        /// <comentarios/>
        public OriginatorIdentificationDetailsTypeI officeIdentification
        {
            get
            {
                return this.officeIdentificationField;
            }
            set
            {
                this.officeIdentificationField = value;
            }
        }

        /// <comentarios/>
        public string officeType
        {
            get
            {
                return this.officeTypeField;
            }
            set
            {
                this.officeTypeField = value;
            }
        }

        /// <comentarios/>
        public string officeCode
        {
            get
            {
                return this.officeCodeField;
            }
            set
            {
                this.officeCodeField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class CompanyIdentificationTextType
    {

        private string textRefNumberField;

        private string companyTextField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
        public string textRefNumber
        {
            get
            {
                return this.textRefNumberField;
            }
            set
            {
                this.textRefNumberField = value;
            }
        }

        /// <comentarios/>
        public string companyText
        {
            get
            {
                return this.companyTextField;
            }
            set
            {
                this.companyTextField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class ConversionRateDetailsTypeI
    {

        private string conversionTypeField;

        private string currencyField;

        private string amountField;

        /// <comentarios/>
        public string conversionType
        {
            get
            {
                return this.conversionTypeField;
            }
            set
            {
                this.conversionTypeField = value;
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
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class AttributeInformationType
    {

        private string feeParameterTypeField;

        private string feeParameterDescriptionField;

        /// <comentarios/>
        public string feeParameterType
        {
            get
            {
                return this.feeParameterTypeField;
            }
            set
            {
                this.feeParameterTypeField = value;
            }
        }

        /// <comentarios/>
        public string feeParameterDescription
        {
            get
            {
                return this.feeParameterDescriptionField;
            }
            set
            {
                this.feeParameterDescriptionField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class DiscountPenaltyMonetaryInformationType
    {

        private string feeTypeField;

        private string feeAmountTypeField;

        private decimal feeAmountField;

        private bool feeAmountFieldSpecified;

        private string feeCurrencyField;

        /// <comentarios/>
        public string feeType
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
        public string feeAmountType
        {
            get
            {
                return this.feeAmountTypeField;
            }
            set
            {
                this.feeAmountTypeField = value;
            }
        }

        /// <comentarios/>
        public decimal feeAmount
        {
            get
            {
                return this.feeAmountField;
            }
            set
            {
                this.feeAmountField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool feeAmountSpecified
        {
            get
            {
                return this.feeAmountFieldSpecified;
            }
            set
            {
                this.feeAmountFieldSpecified = value;
            }
        }

        /// <comentarios/>
        public string feeCurrency
        {
            get
            {
                return this.feeCurrencyField;
            }
            set
            {
                this.feeCurrencyField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class DiscountAndPenaltyInformationType
    {

        private string feeIdentificationField;

        private DiscountPenaltyMonetaryInformationType feeInformationField;

        /// <comentarios/>
        public string feeIdentification
        {
            get
            {
                return this.feeIdentificationField;
            }
            set
            {
                this.feeIdentificationField = value;
            }
        }

        /// <comentarios/>
        public DiscountPenaltyMonetaryInformationType feeInformation
        {
            get
            {
                return this.feeInformationField;
            }
            set
            {
                this.feeInformationField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class ItemReferencesAndVersionsType_78564S
    {

        private string referenceTypeField;

        private string feeRefNumberField;

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
        public string feeRefNumber
        {
            get
            {
                return this.feeRefNumberField;
            }
            set
            {
                this.feeRefNumberField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class FareDetailsType
    {

        private string passengerTypeQualifierField;

        /// <comentarios/>
        public string passengerTypeQualifier
        {
            get
            {
                return this.passengerTypeQualifierField;
            }
            set
            {
                this.passengerTypeQualifierField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class FareInformationType_80868S
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class SpecificTravellerDetailsType
    {

        private string referenceNumberField;

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
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class ReferencingDetailsType
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class FareFamilyType
    {

        private string refNumberField;

        private string fareFamilynameField;

        private string hierarchyField;

        private string cabinField;

        private FareFamilyDetailsType[] commercialFamilyDetailsField;

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
        public string cabin
        {
            get
            {
                return this.cabinField;
            }
            set
            {
                this.cabinField = value;
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class FareTypeGroupingInformationType
    {

        private string pricingGroupField;

        /// <comentarios/>
        public string pricingGroup
        {
            get
            {
                return this.pricingGroupField;
            }
            set
            {
                this.pricingGroupField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class FareDetailsType_193037C
    {

        private string qualifierField;

        private string rateField;

        private string countryField;

        private string fareCategoryField;

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
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
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
        public string country
        {
            get
            {
                return this.countryField;
            }
            set
            {
                this.countryField = value;
            }
        }

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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class FareInformationType
    {

        private string valueQualifierField;

        private string valueField;

        private FareDetailsType_193037C fareDetailsField;

        private string identityNumberField;

        private FareTypeGroupingInformationType fareTypeGroupingField;

        private string rateCategoryField;

        /// <comentarios/>
        public string valueQualifier
        {
            get
            {
                return this.valueQualifierField;
            }
            set
            {
                this.valueQualifierField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
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

        /// <comentarios/>
        public FareDetailsType_193037C fareDetails
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

        /// <comentarios/>
        public string identityNumber
        {
            get
            {
                return this.identityNumberField;
            }
            set
            {
                this.identityNumberField = value;
            }
        }

        /// <comentarios/>
        public FareTypeGroupingInformationType fareTypeGrouping
        {
            get
            {
                return this.fareTypeGroupingField;
            }
            set
            {
                this.fareTypeGroupingField = value;
            }
        }

        /// <comentarios/>
        public string rateCategory
        {
            get
            {
                return this.rateCategoryField;
            }
            set
            {
                this.rateCategoryField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class ConversionRateDetailsTypeI_179848C
    {

        private string conversionTypeField;

        private string currencyField;

        private string rateField;

        private string convertedAmountLinkField;

        private string taxQualifierField;

        /// <comentarios/>
        public string conversionType
        {
            get
            {
                return this.conversionTypeField;
            }
            set
            {
                this.conversionTypeField = value;
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
        public string convertedAmountLink
        {
            get
            {
                return this.convertedAmountLinkField;
            }
            set
            {
                this.convertedAmountLinkField = value;
            }
        }

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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class InteractiveFreeTextType_78544S
    {

        private FreeTextQualificationType_120769C freeTextQualificationField;

        private string[] descriptionField;

        /// <comentarios/>
        public FreeTextQualificationType_120769C freeTextQualification
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
        [System.Xml.Serialization.XmlElementAttribute("description")]
        public string[] description
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
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class ApplicationErrorInformationType
    {

        private string errorField;

        /// <comentarios/>
        public string error
        {
            get
            {
                return this.errorField;
            }
            set
            {
                this.errorField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class ApplicationErrorInformationType_78543S
    {

        private ApplicationErrorInformationType applicationErrorDetailField;

        /// <comentarios/>
        public ApplicationErrorInformationType applicationErrorDetail
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class Fare_MasterPricerTravelBoardSearchReplyErrorMessage
    {

        private ApplicationErrorInformationType_78543S applicationErrorField;

        private InteractiveFreeTextType_78544S errorMessageTextField;

        /// <comentarios/>
        public ApplicationErrorInformationType_78543S applicationError
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
        public InteractiveFreeTextType_78544S errorMessageText
        {
            get
            {
                return this.errorMessageTextField;
            }
            set
            {
                this.errorMessageTextField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class Fare_MasterPricerTravelBoardSearchReplyAmountInfoForAllPax
    {

        private MonetaryInformationDetailsType[] itineraryAmountsField;

        private Fare_MasterPricerTravelBoardSearchReplyAmountInfoForAllPaxAmountsPerSgt[] amountsPerSgtField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayItemAttribute("monetaryDetail", IsNullable = false)]
        public MonetaryInformationDetailsType[] itineraryAmounts
        {
            get
            {
                return this.itineraryAmountsField;
            }
            set
            {
                this.itineraryAmountsField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("amountsPerSgt")]
        public Fare_MasterPricerTravelBoardSearchReplyAmountInfoForAllPaxAmountsPerSgt[] amountsPerSgt
        {
            get
            {
                return this.amountsPerSgtField;
            }
            set
            {
                this.amountsPerSgtField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class Fare_MasterPricerTravelBoardSearchReplyAmountInfoForAllPaxAmountsPerSgt
    {

        private ReferencingDetailsType[] sgtRefField;

        private MonetaryInformationDetailsType[] amountsField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayItemAttribute("referencingDetail", IsNullable = false)]
        public ReferencingDetailsType[] sgtRef
        {
            get
            {
                return this.sgtRefField;
            }
            set
            {
                this.sgtRefField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayItemAttribute("monetaryDetail", IsNullable = false)]
        public MonetaryInformationDetailsType[] amounts
        {
            get
            {
                return this.amountsField;
            }
            set
            {
                this.amountsField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class Fare_MasterPricerTravelBoardSearchReplyAmountInfoPerPax
    {

        private SpecificTravellerDetailsType[] paxRefField;

        private FareInformationType_80868S paxAttributesField;

        private MonetaryInformationDetailsType[] itineraryAmountsField;

        private Fare_MasterPricerTravelBoardSearchReplyAmountInfoPerPaxAmountsPerSgt[] amountsPerSgtField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayItemAttribute("travellerDetails", IsNullable = false)]
        public SpecificTravellerDetailsType[] paxRef
        {
            get
            {
                return this.paxRefField;
            }
            set
            {
                this.paxRefField = value;
            }
        }

        /// <comentarios/>
        public FareInformationType_80868S paxAttributes
        {
            get
            {
                return this.paxAttributesField;
            }
            set
            {
                this.paxAttributesField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayItemAttribute("monetaryDetail", IsNullable = false)]
        public MonetaryInformationDetailsType[] itineraryAmounts
        {
            get
            {
                return this.itineraryAmountsField;
            }
            set
            {
                this.itineraryAmountsField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("amountsPerSgt")]
        public Fare_MasterPricerTravelBoardSearchReplyAmountInfoPerPaxAmountsPerSgt[] amountsPerSgt
        {
            get
            {
                return this.amountsPerSgtField;
            }
            set
            {
                this.amountsPerSgtField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class Fare_MasterPricerTravelBoardSearchReplyAmountInfoPerPaxAmountsPerSgt
    {

        private ReferencingDetailsType[] sgtRefField;

        private MonetaryInformationDetailsType[] amountsField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayItemAttribute("referencingDetail", IsNullable = false)]
        public ReferencingDetailsType[] sgtRef
        {
            get
            {
                return this.sgtRefField;
            }
            set
            {
                this.sgtRefField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayItemAttribute("monetaryDetail", IsNullable = false)]
        public MonetaryInformationDetailsType[] amounts
        {
            get
            {
                return this.amountsField;
            }
            set
            {
                this.amountsField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class Fare_MasterPricerTravelBoardSearchReplyFeeDetails
    {

        private ItemReferencesAndVersionsType_78564S feeReferenceField;

        private DiscountAndPenaltyInformationType feeInformationField;

        private AttributeInformationType[] feeParametersField;

        private ConversionRateDetailsTypeI[] convertedOrOriginalInfoField;

        /// <comentarios/>
        public ItemReferencesAndVersionsType_78564S feeReference
        {
            get
            {
                return this.feeReferenceField;
            }
            set
            {
                this.feeReferenceField = value;
            }
        }

        /// <comentarios/>
        public DiscountAndPenaltyInformationType feeInformation
        {
            get
            {
                return this.feeInformationField;
            }
            set
            {
                this.feeInformationField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayItemAttribute("feeParameter", IsNullable = false)]
        public AttributeInformationType[] feeParameters
        {
            get
            {
                return this.feeParametersField;
            }
            set
            {
                this.feeParametersField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayItemAttribute("conversionRateDetail", IsNullable = false)]
        public ConversionRateDetailsTypeI[] convertedOrOriginalInfo
        {
            get
            {
                return this.convertedOrOriginalInfoField;
            }
            set
            {
                this.convertedOrOriginalInfoField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class Fare_MasterPricerTravelBoardSearchReplyOfficeIdDetails
    {

        private UserIdentificationType officeIdInformationField;

        private ItemReferencesAndVersionsType_78536S officeIdReferenceField;

        /// <comentarios/>
        public UserIdentificationType officeIdInformation
        {
            get
            {
                return this.officeIdInformationField;
            }
            set
            {
                this.officeIdInformationField = value;
            }
        }

        /// <comentarios/>
        public ItemReferencesAndVersionsType_78536S officeIdReference
        {
            get
            {
                return this.officeIdReferenceField;
            }
            set
            {
                this.officeIdReferenceField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class Fare_MasterPricerTravelBoardSearchReplyFlightIndex
    {

        private OriginAndDestinationRequestType requestedSegmentRefField;

        private Fare_MasterPricerTravelBoardSearchReplyFlightIndexGroupOfFlights[] groupOfFlightsField;

        /// <comentarios/>
        public OriginAndDestinationRequestType requestedSegmentRef
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
        [System.Xml.Serialization.XmlElementAttribute("groupOfFlights")]
        public Fare_MasterPricerTravelBoardSearchReplyFlightIndexGroupOfFlights[] groupOfFlights
        {
            get
            {
                return this.groupOfFlightsField;
            }
            set
            {
                this.groupOfFlightsField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class Fare_MasterPricerTravelBoardSearchReplyFlightIndexGroupOfFlights
    {

        private ProposedSegmentType propFlightGrDetailField;

        private Fare_MasterPricerTravelBoardSearchReplyFlightIndexGroupOfFlightsFlightDetails[] flightDetailsField;

        /// <comentarios/>
        public ProposedSegmentType propFlightGrDetail
        {
            get
            {
                return this.propFlightGrDetailField;
            }
            set
            {
                this.propFlightGrDetailField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("flightDetails")]
        public Fare_MasterPricerTravelBoardSearchReplyFlightIndexGroupOfFlightsFlightDetails[] flightDetails
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class Fare_MasterPricerTravelBoardSearchReplyFlightIndexGroupOfFlightsFlightDetails
    {

        private TravelProductType flightInformationField;

        private FlightProductInformationType_141442S[] avlInfoField;

        private DateAndTimeInformationType[] technicalStopField;

        private CommercialAgreementsType commercialAgreementField;

        private HeaderInformationTypeI addInfoField;

        /// <comentarios/>
        public TravelProductType flightInformation
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
        [System.Xml.Serialization.XmlElementAttribute("avlInfo")]
        public FlightProductInformationType_141442S[] avlInfo
        {
            get
            {
                return this.avlInfoField;
            }
            set
            {
                this.avlInfoField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("technicalStop")]
        public DateAndTimeInformationType[] technicalStop
        {
            get
            {
                return this.technicalStopField;
            }
            set
            {
                this.technicalStopField = value;
            }
        }

        /// <comentarios/>
        public CommercialAgreementsType commercialAgreement
        {
            get
            {
                return this.commercialAgreementField;
            }
            set
            {
                this.commercialAgreementField = value;
            }
        }

        /// <comentarios/>
        public HeaderInformationTypeI addInfo
        {
            get
            {
                return this.addInfoField;
            }
            set
            {
                this.addInfoField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class Fare_MasterPricerTravelBoardSearchReplyRecommendation
    {

        private ItemNumberType_161497S itemNumberField;

        private InteractiveFreeTextType_78544S[] warningMessageField;

        private ReferencingDetailsType[] fareFamilyRefField;

        private MonetaryInformationDetailsType[] recPriceInfoField;

        private MiniRulesType[] miniRuleField;

        private ReferenceInfoType[] segmentFlightRefField;

        private Fare_MasterPricerTravelBoardSearchReplyRecommendationRecommandationSegmentsFareDetails[] recommandationSegmentsFareDetailsField;

        private Fare_MasterPricerTravelBoardSearchReplyRecommendationPaxFareProduct[] paxFareProductField;

        private Fare_MasterPricerTravelBoardSearchReplyRecommendationSpecificRecDetails[] specificRecDetailsField;

        /// <comentarios/>
        public ItemNumberType_161497S itemNumber
        {
            get
            {
                return this.itemNumberField;
            }
            set
            {
                this.itemNumberField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("warningMessage")]
        public InteractiveFreeTextType_78544S[] warningMessage
        {
            get
            {
                return this.warningMessageField;
            }
            set
            {
                this.warningMessageField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayItemAttribute("referencingDetail", IsNullable = false)]
        public ReferencingDetailsType[] fareFamilyRef
        {
            get
            {
                return this.fareFamilyRefField;
            }
            set
            {
                this.fareFamilyRefField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayItemAttribute("monetaryDetail", IsNullable = false)]
        public MonetaryInformationDetailsType[] recPriceInfo
        {
            get
            {
                return this.recPriceInfoField;
            }
            set
            {
                this.recPriceInfoField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("miniRule")]
        public MiniRulesType[] miniRule
        {
            get
            {
                return this.miniRuleField;
            }
            set
            {
                this.miniRuleField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("segmentFlightRef")]
        public ReferenceInfoType[] segmentFlightRef
        {
            get
            {
                return this.segmentFlightRefField;
            }
            set
            {
                this.segmentFlightRefField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("recommandationSegmentsFareDetails")]
        public Fare_MasterPricerTravelBoardSearchReplyRecommendationRecommandationSegmentsFareDetails[] recommandationSegmentsFareDetails
        {
            get
            {
                return this.recommandationSegmentsFareDetailsField;
            }
            set
            {
                this.recommandationSegmentsFareDetailsField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("paxFareProduct")]
        public Fare_MasterPricerTravelBoardSearchReplyRecommendationPaxFareProduct[] paxFareProduct
        {
            get
            {
                return this.paxFareProductField;
            }
            set
            {
                this.paxFareProductField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("specificRecDetails")]
        public Fare_MasterPricerTravelBoardSearchReplyRecommendationSpecificRecDetails[] specificRecDetails
        {
            get
            {
                return this.specificRecDetailsField;
            }
            set
            {
                this.specificRecDetailsField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class Fare_MasterPricerTravelBoardSearchReplyRecommendationRecommandationSegmentsFareDetails
    {

        private OriginAndDestinationRequestType recommendationSegRefField;

        private MonetaryInformationDetailsType[] segmentMonetaryInformationField;

        /// <comentarios/>
        public OriginAndDestinationRequestType recommendationSegRef
        {
            get
            {
                return this.recommendationSegRefField;
            }
            set
            {
                this.recommendationSegRefField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayItemAttribute("monetaryDetail", IsNullable = false)]
        public MonetaryInformationDetailsType[] segmentMonetaryInformation
        {
            get
            {
                return this.segmentMonetaryInformationField;
            }
            set
            {
                this.segmentMonetaryInformationField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class Fare_MasterPricerTravelBoardSearchReplyRecommendationPaxFareProduct
    {

        private PricingTicketingSubsequentType_144401S paxFareDetailField;

        private ReferencingDetailsType_195561C[] feeRefField;

        private TravellerReferenceInformationType[] paxReferenceField;

        private TaxType passengerTaxDetailsField;

        private Fare_MasterPricerTravelBoardSearchReplyRecommendationPaxFareProductFare[] fareField;

        private Fare_MasterPricerTravelBoardSearchReplyRecommendationPaxFareProductFareDetails[] fareDetailsField;

        /// <comentarios/>
        public PricingTicketingSubsequentType_144401S paxFareDetail
        {
            get
            {
                return this.paxFareDetailField;
            }
            set
            {
                this.paxFareDetailField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayItemAttribute("referencingDetail", IsNullable = false)]
        public ReferencingDetailsType_195561C[] feeRef
        {
            get
            {
                return this.feeRefField;
            }
            set
            {
                this.feeRefField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("paxReference")]
        public TravellerReferenceInformationType[] paxReference
        {
            get
            {
                return this.paxReferenceField;
            }
            set
            {
                this.paxReferenceField = value;
            }
        }

        /// <comentarios/>
        public TaxType passengerTaxDetails
        {
            get
            {
                return this.passengerTaxDetailsField;
            }
            set
            {
                this.passengerTaxDetailsField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("fare")]
        public Fare_MasterPricerTravelBoardSearchReplyRecommendationPaxFareProductFare[] fare
        {
            get
            {
                return this.fareField;
            }
            set
            {
                this.fareField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("fareDetails")]
        public Fare_MasterPricerTravelBoardSearchReplyRecommendationPaxFareProductFareDetails[] fareDetails
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class Fare_MasterPricerTravelBoardSearchReplyRecommendationPaxFareProductFare
    {

        private InteractiveFreeTextType_78559S pricingMessageField;

        private MonetaryInformationDetailsType[] monetaryInformationField;

        /// <comentarios/>
        public InteractiveFreeTextType_78559S pricingMessage
        {
            get
            {
                return this.pricingMessageField;
            }
            set
            {
                this.pricingMessageField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayItemAttribute("monetaryDetail", IsNullable = false)]
        public MonetaryInformationDetailsType[] monetaryInformation
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
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class Fare_MasterPricerTravelBoardSearchReplyRecommendationPaxFareProductFareDetails
    {

        private OriginAndDestinationRequestType segmentRefField;

        private Fare_MasterPricerTravelBoardSearchReplyRecommendationPaxFareProductFareDetailsGroupOfFares[] groupOfFaresField;

        private MonetaryInformationDetailsType[] psgSegMonetaryInformationField;

        private ProductInformationType[] majCabinField;

        /// <comentarios/>
        public OriginAndDestinationRequestType segmentRef
        {
            get
            {
                return this.segmentRefField;
            }
            set
            {
                this.segmentRefField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("groupOfFares")]
        public Fare_MasterPricerTravelBoardSearchReplyRecommendationPaxFareProductFareDetailsGroupOfFares[] groupOfFares
        {
            get
            {
                return this.groupOfFaresField;
            }
            set
            {
                this.groupOfFaresField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayItemAttribute("monetaryDetail", IsNullable = false)]
        public MonetaryInformationDetailsType[] psgSegMonetaryInformation
        {
            get
            {
                return this.psgSegMonetaryInformationField;
            }
            set
            {
                this.psgSegMonetaryInformationField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("majCabin")]
        public ProductInformationType[] majCabin
        {
            get
            {
                return this.majCabinField;
            }
            set
            {
                this.majCabinField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class Fare_MasterPricerTravelBoardSearchReplyRecommendationPaxFareProductFareDetailsGroupOfFares
    {

        private FlightProductInformationType productInformationField;

        private FareCalculationCodeDetailsType[] fareCalculationCodeDetailsField;

        private FareQualifierDetailsType ticketInfosField;

        private ReferencingDetailsType[] fareFamiliesRefField;

        /// <comentarios/>
        public FlightProductInformationType productInformation
        {
            get
            {
                return this.productInformationField;
            }
            set
            {
                this.productInformationField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("fareCalculationCodeDetails")]
        public FareCalculationCodeDetailsType[] fareCalculationCodeDetails
        {
            get
            {
                return this.fareCalculationCodeDetailsField;
            }
            set
            {
                this.fareCalculationCodeDetailsField = value;
            }
        }

        /// <comentarios/>
        public FareQualifierDetailsType ticketInfos
        {
            get
            {
                return this.ticketInfosField;
            }
            set
            {
                this.ticketInfosField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayItemAttribute("referencingDetail", IsNullable = false)]
        public ReferencingDetailsType[] fareFamiliesRef
        {
            get
            {
                return this.fareFamiliesRefField;
            }
            set
            {
                this.fareFamiliesRefField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class Fare_MasterPricerTravelBoardSearchReplyRecommendationSpecificRecDetails
    {

        private ItemReferencesAndVersionsType specificRecItemField;

        private Fare_MasterPricerTravelBoardSearchReplyRecommendationSpecificRecDetailsSpecificProductDetails[] specificProductDetailsField;

        /// <comentarios/>
        public ItemReferencesAndVersionsType specificRecItem
        {
            get
            {
                return this.specificRecItemField;
            }
            set
            {
                this.specificRecItemField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("specificProductDetails")]
        public Fare_MasterPricerTravelBoardSearchReplyRecommendationSpecificRecDetailsSpecificProductDetails[] specificProductDetails
        {
            get
            {
                return this.specificProductDetailsField;
            }
            set
            {
                this.specificProductDetailsField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class Fare_MasterPricerTravelBoardSearchReplyRecommendationSpecificRecDetailsSpecificProductDetails
    {

        private string[] productReferencesField;

        private Fare_MasterPricerTravelBoardSearchReplyRecommendationSpecificRecDetailsSpecificProductDetailsFareContextDetails[] fareContextDetailsField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayItemAttribute("paxFareNum", IsNullable = false)]
        public string[] productReferences
        {
            get
            {
                return this.productReferencesField;
            }
            set
            {
                this.productReferencesField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("fareContextDetails")]
        public Fare_MasterPricerTravelBoardSearchReplyRecommendationSpecificRecDetailsSpecificProductDetailsFareContextDetails[] fareContextDetails
        {
            get
            {
                return this.fareContextDetailsField;
            }
            set
            {
                this.fareContextDetailsField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class Fare_MasterPricerTravelBoardSearchReplyRecommendationSpecificRecDetailsSpecificProductDetailsFareContextDetails
    {

        private OriginAndDestinationRequestType_134833S requestedSegmentInfoField;

        private Fare_MasterPricerTravelBoardSearchReplyRecommendationSpecificRecDetailsSpecificProductDetailsFareContextDetailsCnxContextDetails[] cnxContextDetailsField;

        /// <comentarios/>
        public OriginAndDestinationRequestType_134833S requestedSegmentInfo
        {
            get
            {
                return this.requestedSegmentInfoField;
            }
            set
            {
                this.requestedSegmentInfoField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("cnxContextDetails")]
        public Fare_MasterPricerTravelBoardSearchReplyRecommendationSpecificRecDetailsSpecificProductDetailsFareContextDetailsCnxContextDetails[] cnxContextDetails
        {
            get
            {
                return this.cnxContextDetailsField;
            }
            set
            {
                this.cnxContextDetailsField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class Fare_MasterPricerTravelBoardSearchReplyRecommendationSpecificRecDetailsSpecificProductDetailsFareContextDetailsCnxContextDetails
    {

        private FlightProductInformationType_134801S fareCnxInfoField;

        /// <comentarios/>
        public FlightProductInformationType_134801S fareCnxInfo
        {
            get
            {
                return this.fareCnxInfoField;
            }
            set
            {
                this.fareCnxInfoField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class Fare_MasterPricerTravelBoardSearchReplyOtherSolutions
    {

        private SequenceDetailsTypeU referenceField;

        private Fare_MasterPricerTravelBoardSearchReplyOtherSolutionsAmtGroup[] amtGroupField;

        private Fare_MasterPricerTravelBoardSearchReplyOtherSolutionsPsgInfo[] psgInfoField;

        /// <comentarios/>
        public SequenceDetailsTypeU reference
        {
            get
            {
                return this.referenceField;
            }
            set
            {
                this.referenceField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("amtGroup")]
        public Fare_MasterPricerTravelBoardSearchReplyOtherSolutionsAmtGroup[] amtGroup
        {
            get
            {
                return this.amtGroupField;
            }
            set
            {
                this.amtGroupField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("psgInfo")]
        public Fare_MasterPricerTravelBoardSearchReplyOtherSolutionsPsgInfo[] psgInfo
        {
            get
            {
                return this.psgInfoField;
            }
            set
            {
                this.psgInfoField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class Fare_MasterPricerTravelBoardSearchReplyOtherSolutionsAmtGroup
    {

        private ReferencingDetailsType_234704C[] refField;

        private MonetaryInformationDetailsTypeI[] amountField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayItemAttribute("referenceDetails", IsNullable = false)]
        public ReferencingDetailsType_234704C[] @ref
        {
            get
            {
                return this.refField;
            }
            set
            {
                this.refField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayItemAttribute("monetaryDetails", IsNullable = false)]
        public MonetaryInformationDetailsTypeI[] amount
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
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class Fare_MasterPricerTravelBoardSearchReplyOtherSolutionsPsgInfo
    {

        private SegmentRepetitionControlDetailsTypeI[] refField;

        private FareInformationTypeI descriptionField;

        private FrequentTravellerIdentificationType[] freqTravellerField;

        private MonetaryInformationDetailsTypeI[] amountField;

        private FlightProductInformationType_161491S fareField;

        private AttributeTypeU[] attributeField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayItemAttribute("segmentControlDetails", IsNullable = false)]
        public SegmentRepetitionControlDetailsTypeI[] @ref
        {
            get
            {
                return this.refField;
            }
            set
            {
                this.refField = value;
            }
        }

        /// <comentarios/>
        public FareInformationTypeI description
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
        [System.Xml.Serialization.XmlArrayItemAttribute("frequentTravellerDetails", IsNullable = false)]
        public FrequentTravellerIdentificationType[] freqTraveller
        {
            get
            {
                return this.freqTravellerField;
            }
            set
            {
                this.freqTravellerField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayItemAttribute("monetaryDetails", IsNullable = false)]
        public MonetaryInformationDetailsTypeI[] amount
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
        public FlightProductInformationType_161491S fare
        {
            get
            {
                return this.fareField;
            }
            set
            {
                this.fareField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("attribute")]
        public AttributeTypeU[] attribute
        {
            get
            {
                return this.attributeField;
            }
            set
            {
                this.attributeField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class Fare_MasterPricerTravelBoardSearchReplyWarningInfo
    {

        private DummySegmentTypeI globalMessageMarkerField;

        private InteractiveFreeTextType globalMessageField;

        /// <comentarios/>
        public DummySegmentTypeI globalMessageMarker
        {
            get
            {
                return this.globalMessageMarkerField;
            }
            set
            {
                this.globalMessageMarkerField = value;
            }
        }

        /// <comentarios/>
        public InteractiveFreeTextType globalMessage
        {
            get
            {
                return this.globalMessageField;
            }
            set
            {
                this.globalMessageField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class Fare_MasterPricerTravelBoardSearchReplyGlobalInformation
    {

        private CodedAttributeInformationType[] attributesField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayItemAttribute("attributeDetails", IsNullable = false)]
        public CodedAttributeInformationType[] attributes
        {
            get
            {
                return this.attributesField;
            }
            set
            {
                this.attributesField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class Fare_MasterPricerTravelBoardSearchReplyServiceFeesGrp
    {

        private SelectionDetailsType serviceTypeInfoField;

        private Fare_MasterPricerTravelBoardSearchReplyServiceFeesGrpServiceFeeRefGrp[] serviceFeeRefGrpField;

        private Fare_MasterPricerTravelBoardSearchReplyServiceFeesGrpServiceCoverageInfoGrp[] serviceCoverageInfoGrpField;

        private DummySegmentTypeI globalMessageMarkerField;

        private Fare_MasterPricerTravelBoardSearchReplyServiceFeesGrpServiceFeeInfoGrp[] serviceFeeInfoGrpField;

        private Fare_MasterPricerTravelBoardSearchReplyServiceFeesGrpServiceDetailsGrp[] serviceDetailsGrpField;

        private Fare_MasterPricerTravelBoardSearchReplyServiceFeesGrpFreeBagAllowanceGrp[] freeBagAllowanceGrpField;

        /// <comentarios/>
        public SelectionDetailsType serviceTypeInfo
        {
            get
            {
                return this.serviceTypeInfoField;
            }
            set
            {
                this.serviceTypeInfoField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("serviceFeeRefGrp")]
        public Fare_MasterPricerTravelBoardSearchReplyServiceFeesGrpServiceFeeRefGrp[] serviceFeeRefGrp
        {
            get
            {
                return this.serviceFeeRefGrpField;
            }
            set
            {
                this.serviceFeeRefGrpField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("serviceCoverageInfoGrp")]
        public Fare_MasterPricerTravelBoardSearchReplyServiceFeesGrpServiceCoverageInfoGrp[] serviceCoverageInfoGrp
        {
            get
            {
                return this.serviceCoverageInfoGrpField;
            }
            set
            {
                this.serviceCoverageInfoGrpField = value;
            }
        }

        /// <comentarios/>
        public DummySegmentTypeI globalMessageMarker
        {
            get
            {
                return this.globalMessageMarkerField;
            }
            set
            {
                this.globalMessageMarkerField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("serviceFeeInfoGrp")]
        public Fare_MasterPricerTravelBoardSearchReplyServiceFeesGrpServiceFeeInfoGrp[] serviceFeeInfoGrp
        {
            get
            {
                return this.serviceFeeInfoGrpField;
            }
            set
            {
                this.serviceFeeInfoGrpField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("serviceDetailsGrp")]
        public Fare_MasterPricerTravelBoardSearchReplyServiceFeesGrpServiceDetailsGrp[] serviceDetailsGrp
        {
            get
            {
                return this.serviceDetailsGrpField;
            }
            set
            {
                this.serviceDetailsGrpField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("freeBagAllowanceGrp")]
        public Fare_MasterPricerTravelBoardSearchReplyServiceFeesGrpFreeBagAllowanceGrp[] freeBagAllowanceGrp
        {
            get
            {
                return this.freeBagAllowanceGrpField;
            }
            set
            {
                this.freeBagAllowanceGrpField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class Fare_MasterPricerTravelBoardSearchReplyServiceFeesGrpServiceFeeRefGrp
    {

        private ReferenceInfoType refInfoField;

        /// <comentarios/>
        public ReferenceInfoType refInfo
        {
            get
            {
                return this.refInfoField;
            }
            set
            {
                this.refInfoField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class Fare_MasterPricerTravelBoardSearchReplyServiceFeesGrpServiceCoverageInfoGrp
    {

        private ItemNumberType itemNumberInfoField;

        private Fare_MasterPricerTravelBoardSearchReplyServiceFeesGrpServiceCoverageInfoGrpServiceCovInfoGrp[] serviceCovInfoGrpField;

        /// <comentarios/>
        public ItemNumberType itemNumberInfo
        {
            get
            {
                return this.itemNumberInfoField;
            }
            set
            {
                this.itemNumberInfoField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("serviceCovInfoGrp")]
        public Fare_MasterPricerTravelBoardSearchReplyServiceFeesGrpServiceCoverageInfoGrpServiceCovInfoGrp[] serviceCovInfoGrp
        {
            get
            {
                return this.serviceCovInfoGrpField;
            }
            set
            {
                this.serviceCovInfoGrpField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class Fare_MasterPricerTravelBoardSearchReplyServiceFeesGrpServiceCoverageInfoGrpServiceCovInfoGrp
    {

        private SpecificTravellerDetailsType[] paxRefInfoField;

        private ActionDetailsType[] coveragePerFlightsInfoField;

        private TransportIdentifierType carrierInfoField;

        private ReferencingDetailsType_195561C[] refInfoField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayItemAttribute("travellerDetails", IsNullable = false)]
        public SpecificTravellerDetailsType[] paxRefInfo
        {
            get
            {
                return this.paxRefInfoField;
            }
            set
            {
                this.paxRefInfoField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("coveragePerFlightsInfo")]
        public ActionDetailsType[] coveragePerFlightsInfo
        {
            get
            {
                return this.coveragePerFlightsInfoField;
            }
            set
            {
                this.coveragePerFlightsInfoField = value;
            }
        }

        /// <comentarios/>
        public TransportIdentifierType carrierInfo
        {
            get
            {
                return this.carrierInfoField;
            }
            set
            {
                this.carrierInfoField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayItemAttribute("referencingDetail", IsNullable = false)]
        public ReferencingDetailsType_195561C[] refInfo
        {
            get
            {
                return this.refInfoField;
            }
            set
            {
                this.refInfoField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class Fare_MasterPricerTravelBoardSearchReplyServiceFeesGrpServiceFeeInfoGrp
    {

        private ItemNumberType itemNumberInfoField;

        private Fare_MasterPricerTravelBoardSearchReplyServiceFeesGrpServiceFeeInfoGrpServiceDetailsGrp[] serviceDetailsGrpField;

        /// <comentarios/>
        public ItemNumberType itemNumberInfo
        {
            get
            {
                return this.itemNumberInfoField;
            }
            set
            {
                this.itemNumberInfoField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("serviceDetailsGrp")]
        public Fare_MasterPricerTravelBoardSearchReplyServiceFeesGrpServiceFeeInfoGrpServiceDetailsGrp[] serviceDetailsGrp
        {
            get
            {
                return this.serviceDetailsGrpField;
            }
            set
            {
                this.serviceDetailsGrpField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class Fare_MasterPricerTravelBoardSearchReplyServiceFeesGrpServiceFeeInfoGrpServiceDetailsGrp
    {

        private ReferencingDetailsType_195561C[] refInfoField;

        private Fare_MasterPricerTravelBoardSearchReplyServiceFeesGrpServiceFeeInfoGrpServiceDetailsGrpServiceMatchedInfoGroup[] serviceMatchedInfoGroupField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayItemAttribute("referencingDetail", IsNullable = false)]
        public ReferencingDetailsType_195561C[] refInfo
        {
            get
            {
                return this.refInfoField;
            }
            set
            {
                this.refInfoField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("serviceMatchedInfoGroup")]
        public Fare_MasterPricerTravelBoardSearchReplyServiceFeesGrpServiceFeeInfoGrpServiceDetailsGrpServiceMatchedInfoGroup[] serviceMatchedInfoGroup
        {
            get
            {
                return this.serviceMatchedInfoGroupField;
            }
            set
            {
                this.serviceMatchedInfoGroupField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class Fare_MasterPricerTravelBoardSearchReplyServiceFeesGrpServiceFeeInfoGrpServiceDetailsGrpServiceMatchedInfoGroup
    {

        private SpecificTravellerDetailsType[] paxRefInfoField;

        private FareInformationType_80868S pricingInfoField;

        private MonetaryInformationDetailsType[] amountInfoField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayItemAttribute("travellerDetails", IsNullable = false)]
        public SpecificTravellerDetailsType[] paxRefInfo
        {
            get
            {
                return this.paxRefInfoField;
            }
            set
            {
                this.paxRefInfoField = value;
            }
        }

        /// <comentarios/>
        public FareInformationType_80868S pricingInfo
        {
            get
            {
                return this.pricingInfoField;
            }
            set
            {
                this.pricingInfoField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayItemAttribute("monetaryDetail", IsNullable = false)]
        public MonetaryInformationDetailsType[] amountInfo
        {
            get
            {
                return this.amountInfoField;
            }
            set
            {
                this.amountInfoField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class Fare_MasterPricerTravelBoardSearchReplyServiceFeesGrpServiceDetailsGrp
    {

        private SpecificDataInformationType serviceOptionInfoField;

        private Fare_MasterPricerTravelBoardSearchReplyServiceFeesGrpServiceDetailsGrpFeeDescriptionGrp feeDescriptionGrpField;

        /// <comentarios/>
        public SpecificDataInformationType serviceOptionInfo
        {
            get
            {
                return this.serviceOptionInfoField;
            }
            set
            {
                this.serviceOptionInfoField = value;
            }
        }

        /// <comentarios/>
        public Fare_MasterPricerTravelBoardSearchReplyServiceFeesGrpServiceDetailsGrpFeeDescriptionGrp feeDescriptionGrp
        {
            get
            {
                return this.feeDescriptionGrpField;
            }
            set
            {
                this.feeDescriptionGrpField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class Fare_MasterPricerTravelBoardSearchReplyServiceFeesGrpServiceDetailsGrpFeeDescriptionGrp
    {

        private ItemNumberType_80866S itemNumberInfoField;

        private AttributeType serviceAttributesInfoField;

        private SpecialRequirementsDetailsType serviceDescriptionInfoField;

        /// <comentarios/>
        public ItemNumberType_80866S itemNumberInfo
        {
            get
            {
                return this.itemNumberInfoField;
            }
            set
            {
                this.itemNumberInfoField = value;
            }
        }

        /// <comentarios/>
        public AttributeType serviceAttributesInfo
        {
            get
            {
                return this.serviceAttributesInfoField;
            }
            set
            {
                this.serviceAttributesInfoField = value;
            }
        }

        /// <comentarios/>
        public SpecialRequirementsDetailsType serviceDescriptionInfo
        {
            get
            {
                return this.serviceDescriptionInfoField;
            }
            set
            {
                this.serviceDescriptionInfoField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/FMPTBR_13_1_1A")]
    public partial class Fare_MasterPricerTravelBoardSearchReplyServiceFeesGrpFreeBagAllowanceGrp
    {

        private ExcessBaggageType freeBagAllownceInfoField;

        private ItemNumberIdentificationType_234878C[] itemNumberInfoField;

        /// <comentarios/>
        public ExcessBaggageType freeBagAllownceInfo
        {
            get
            {
                return this.freeBagAllownceInfoField;
            }
            set
            {
                this.freeBagAllownceInfoField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayItemAttribute("itemNumberDetails", IsNullable = false)]
        public ItemNumberIdentificationType_234878C[] itemNumberInfo
        {
            get
            {
                return this.itemNumberInfoField;
            }
            set
            {
                this.itemNumberInfoField = value;
            }
        }
    }

}

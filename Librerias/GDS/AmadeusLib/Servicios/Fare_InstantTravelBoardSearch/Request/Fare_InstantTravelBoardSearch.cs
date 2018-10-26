using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmadeusLib.Servicios.Fare_InstantTravelBoardSearch.Request
{
    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A", IsNullable = false)]
    public partial class Fare_InstantTravelBoardSearch
    {

        private NumberOfUnitDetailsType_270113C[] numberOfUnitField;

        private AttributeInformationType[] globalOptionsField;

        private TravellerReferenceInformationType[] paxReferenceField;

        private ConsumerReferenceIdentificationTypeI[] customerRefField;

        private AttributeList[] searchOptionsField;

        private FOPRepresentationType[] formOfPaymentByPassengerField;

        private FareInformationType[] solutionFamilyField;

        private GroupPassengerDetailsType[] passengerInfoGrpField;

        private Fare_InstantTravelBoardSearchFareFamilies[] fareFamiliesField;

        private Fare_InstantTravelBoardSearchFareOptions fareOptionsField;

        private MonetaryInformationType priceToBeatField;

        private TaxType[] taxInfoField;

        private TravelFlightInformationType_199258S travelFlightInfoField;

        private ValueSearchCriteriaType[] valueSearchField;

        private Fare_InstantTravelBoardSearchBuckets[] bucketsField;

        private Fare_InstantTravelBoardSearchItinerary[] itineraryField;

        private Fare_InstantTravelBoardSearchTicketChangeInfo ticketChangeInfoField;

        private Fare_InstantTravelBoardSearchCombinationFareFamilies[] combinationFareFamiliesField;

        private Fare_InstantTravelBoardSearchFeeOption[] feeOptionField;

        private Fare_InstantTravelBoardSearchOfficeIdDetails[] officeIdDetailsField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayItemAttribute("unitNumberDetail", IsNullable = false)]
        public NumberOfUnitDetailsType_270113C[] numberOfUnit
        {
            get
            {
                return this.numberOfUnitField;
            }
            set
            {
                this.numberOfUnitField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayItemAttribute("selectionDetails", IsNullable = false)]
        public AttributeInformationType[] globalOptions
        {
            get
            {
                return this.globalOptionsField;
            }
            set
            {
                this.globalOptionsField = value;
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
        [System.Xml.Serialization.XmlArrayItemAttribute("customerReferences", IsNullable = false)]
        public ConsumerReferenceIdentificationTypeI[] customerRef
        {
            get
            {
                return this.customerRefField;
            }
            set
            {
                this.customerRefField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("searchOptions")]
        public AttributeList[] searchOptions
        {
            get
            {
                return this.searchOptionsField;
            }
            set
            {
                this.searchOptionsField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("formOfPaymentByPassenger")]
        public FOPRepresentationType[] formOfPaymentByPassenger
        {
            get
            {
                return this.formOfPaymentByPassengerField;
            }
            set
            {
                this.formOfPaymentByPassengerField = value;
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
        [System.Xml.Serialization.XmlElementAttribute("passengerInfoGrp")]
        public GroupPassengerDetailsType[] passengerInfoGrp
        {
            get
            {
                return this.passengerInfoGrpField;
            }
            set
            {
                this.passengerInfoGrpField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("fareFamilies")]
        public Fare_InstantTravelBoardSearchFareFamilies[] fareFamilies
        {
            get
            {
                return this.fareFamiliesField;
            }
            set
            {
                this.fareFamiliesField = value;
            }
        }

        /// <comentarios/>
        public Fare_InstantTravelBoardSearchFareOptions fareOptions
        {
            get
            {
                return this.fareOptionsField;
            }
            set
            {
                this.fareOptionsField = value;
            }
        }

        /// <comentarios/>
        public MonetaryInformationType priceToBeat
        {
            get
            {
                return this.priceToBeatField;
            }
            set
            {
                this.priceToBeatField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("taxInfo")]
        public TaxType[] taxInfo
        {
            get
            {
                return this.taxInfoField;
            }
            set
            {
                this.taxInfoField = value;
            }
        }

        /// <comentarios/>
        public TravelFlightInformationType_199258S travelFlightInfo
        {
            get
            {
                return this.travelFlightInfoField;
            }
            set
            {
                this.travelFlightInfoField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("valueSearch")]
        public ValueSearchCriteriaType[] valueSearch
        {
            get
            {
                return this.valueSearchField;
            }
            set
            {
                this.valueSearchField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("buckets")]
        public Fare_InstantTravelBoardSearchBuckets[] buckets
        {
            get
            {
                return this.bucketsField;
            }
            set
            {
                this.bucketsField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("itinerary")]
        public Fare_InstantTravelBoardSearchItinerary[] itinerary
        {
            get
            {
                return this.itineraryField;
            }
            set
            {
                this.itineraryField = value;
            }
        }

        /// <comentarios/>
        public Fare_InstantTravelBoardSearchTicketChangeInfo ticketChangeInfo
        {
            get
            {
                return this.ticketChangeInfoField;
            }
            set
            {
                this.ticketChangeInfoField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("combinationFareFamilies")]
        public Fare_InstantTravelBoardSearchCombinationFareFamilies[] combinationFareFamilies
        {
            get
            {
                return this.combinationFareFamiliesField;
            }
            set
            {
                this.combinationFareFamiliesField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("feeOption")]
        public Fare_InstantTravelBoardSearchFeeOption[] feeOption
        {
            get
            {
                return this.feeOptionField;
            }
            set
            {
                this.feeOptionField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("officeIdDetails")]
        public Fare_InstantTravelBoardSearchOfficeIdDetails[] officeIdDetails
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
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
    public partial class NumberOfUnitDetailsType_270113C
    {

        private string numberOfUnitsField;

        private string typeOfUnitField;

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

        /// <comentarios/>
        public string typeOfUnit
        {
            get
            {
                return this.typeOfUnitField;
            }
            set
            {
                this.typeOfUnitField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
    public partial class ValueSearchCriteriaType
    {

        private string refField;

        private string criteriaNameField;

        private string criteriaCodeField;

        private string valueField;

        private CriteriaiDetaislType[] criteriaDetailsField;

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
        public string criteriaName
        {
            get
            {
                return this.criteriaNameField;
            }
            set
            {
                this.criteriaNameField = value;
            }
        }

        /// <comentarios/>
        public string criteriaCode
        {
            get
            {
                return this.criteriaCodeField;
            }
            set
            {
                this.criteriaCodeField = value;
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

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("criteriaDetails")]
        public CriteriaiDetaislType[] criteriaDetails
        {
            get
            {
                return this.criteriaDetailsField;
            }
            set
            {
                this.criteriaDetailsField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
    public partial class CriteriaiDetaislType
    {

        private string typeField;

        private string valueField;

        private string[] attributeField;

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

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("attribute")]
        public string[] attribute
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
    public partial class TravelProductType
    {

        private ProductDateTimeType_195546C productDateTimeField;

        private LocationIdentificationDetailsType[] locationField;

        private CompanyIdentificationType_195544C companyIdField;

        private string flightOrtrainNumberField;

        private AdditionalProductDetailsType productDetailField;

        private ProductFacilitiesType addProductDetailField;

        private CodedAttributeInformationType_247828C[] attributeDetailsField;

        /// <comentarios/>
        public ProductDateTimeType_195546C productDateTime
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
        public CompanyIdentificationType_195544C companyId
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
        public CodedAttributeInformationType_247828C[] attributeDetails
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
    public partial class ProductDateTimeType_195546C
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
    public partial class CompanyIdentificationType_195544C
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
    public partial class CodedAttributeInformationType_247828C
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
    public partial class TravelProductInformationTypeI
    {

        private ProductDateTimeTypeI flightDateField;

        private LocationTypeI boardPointDetailsField;

        private LocationTypeI offpointDetailsField;

        private CompanyIdentificationTypeI companyDetailsField;

        private ProductIdentificationDetailsTypeI flightIdentificationField;

        private string[] flightTypeDetailsField;

        /// <comentarios/>
        public ProductDateTimeTypeI flightDate
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
        public CompanyIdentificationTypeI companyDetails
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
        public ProductIdentificationDetailsTypeI flightIdentification
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
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
    public partial class CompanyIdentificationTypeI
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
    public partial class ProductIdentificationDetailsTypeI
    {

        private string flightNumberField;

        private string operationalSuffixField;

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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
    public partial class TravelFlightInformationType_199585S
    {

        private CabinIdentificationType_233500C cabinIdField;

        private CompanyIdentificationType_120719C[] companyIdentityField;

        private string[] flightDetailField;

        private ConnectPointDetailsType_195492C[] inclusionDetailField;

        private ConnectPointDetailsType[] exclusionDetailField;

        private NumberOfUnitDetailsTypeI[] unitNumberDetailField;

        /// <comentarios/>
        public CabinIdentificationType_233500C cabinId
        {
            get
            {
                return this.cabinIdField;
            }
            set
            {
                this.cabinIdField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("companyIdentity")]
        public CompanyIdentificationType_120719C[] companyIdentity
        {
            get
            {
                return this.companyIdentityField;
            }
            set
            {
                this.companyIdentityField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayItemAttribute("flightType", IsNullable = false)]
        public string[] flightDetail
        {
            get
            {
                return this.flightDetailField;
            }
            set
            {
                this.flightDetailField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("inclusionDetail")]
        public ConnectPointDetailsType_195492C[] inclusionDetail
        {
            get
            {
                return this.inclusionDetailField;
            }
            set
            {
                this.inclusionDetailField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("exclusionDetail")]
        public ConnectPointDetailsType[] exclusionDetail
        {
            get
            {
                return this.exclusionDetailField;
            }
            set
            {
                this.exclusionDetailField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("unitNumberDetail")]
        public NumberOfUnitDetailsTypeI[] unitNumberDetail
        {
            get
            {
                return this.unitNumberDetailField;
            }
            set
            {
                this.unitNumberDetailField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
    public partial class CabinIdentificationType_233500C
    {

        private string cabinQualifierField;

        private string[] cabinField;

        /// <comentarios/>
        public string cabinQualifier
        {
            get
            {
                return this.cabinQualifierField;
            }
            set
            {
                this.cabinQualifierField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("cabin")]
        public string[] cabin
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
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
    public partial class CompanyIdentificationType_120719C
    {

        private string carrierQualifierField;

        private string[] carrierIdField;

        /// <comentarios/>
        public string carrierQualifier
        {
            get
            {
                return this.carrierQualifierField;
            }
            set
            {
                this.carrierQualifierField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("carrierId")]
        public string[] carrierId
        {
            get
            {
                return this.carrierIdField;
            }
            set
            {
                this.carrierIdField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
    public partial class ConnectPointDetailsType_195492C
    {

        private string inclusionIdentifierField;

        private string locationIdField;

        private string airportCityQualifierField;

        /// <comentarios/>
        public string inclusionIdentifier
        {
            get
            {
                return this.inclusionIdentifierField;
            }
            set
            {
                this.inclusionIdentifierField = value;
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
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
    public partial class ConnectPointDetailsType
    {

        private string exclusionIdentifierField;

        private string locationIdField;

        private string airportCityQualifierField;

        /// <comentarios/>
        public string exclusionIdentifier
        {
            get
            {
                return this.exclusionIdentifierField;
            }
            set
            {
                this.exclusionIdentifierField = value;
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
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
    public partial class NumberOfUnitDetailsTypeI
    {

        private string numberOfUnitsField;

        private string typeOfUnitField;

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

        /// <comentarios/>
        public string typeOfUnit
        {
            get
            {
                return this.typeOfUnitField;
            }
            set
            {
                this.typeOfUnitField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
    public partial class TravelFlightInformationType_199258S
    {

        private CabinIdentificationType_233500C cabinIdField;

        private CompanyIdentificationType_275415C[] companyIdentityField;

        private string[] flightDetailField;

        private ConnectPointDetailsType_195492C[] inclusionDetailField;

        private ConnectPointDetailsType[] exclusionDetailField;

        private NumberOfUnitDetailsTypeI[] unitNumberDetailField;

        /// <comentarios/>
        public CabinIdentificationType_233500C cabinId
        {
            get
            {
                return this.cabinIdField;
            }
            set
            {
                this.cabinIdField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("companyIdentity")]
        public CompanyIdentificationType_275415C[] companyIdentity
        {
            get
            {
                return this.companyIdentityField;
            }
            set
            {
                this.companyIdentityField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayItemAttribute("flightType", IsNullable = false)]
        public string[] flightDetail
        {
            get
            {
                return this.flightDetailField;
            }
            set
            {
                this.flightDetailField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("inclusionDetail")]
        public ConnectPointDetailsType_195492C[] inclusionDetail
        {
            get
            {
                return this.inclusionDetailField;
            }
            set
            {
                this.inclusionDetailField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("exclusionDetail")]
        public ConnectPointDetailsType[] exclusionDetail
        {
            get
            {
                return this.exclusionDetailField;
            }
            set
            {
                this.exclusionDetailField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("unitNumberDetail")]
        public NumberOfUnitDetailsTypeI[] unitNumberDetail
        {
            get
            {
                return this.unitNumberDetailField;
            }
            set
            {
                this.unitNumberDetailField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
    public partial class CompanyIdentificationType_275415C
    {

        private string carrierQualifierField;

        private string[] carrierIdField;

        /// <comentarios/>
        public string carrierQualifier
        {
            get
            {
                return this.carrierQualifierField;
            }
            set
            {
                this.carrierQualifierField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("carrierId")]
        public string[] carrierId
        {
            get
            {
                return this.carrierIdField;
            }
            set
            {
                this.carrierIdField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
    public partial class TravelFlightInformationType
    {

        private CabinIdentificationType cabinIdField;

        private CompanyIdentificationType_120719C[] companyIdentityField;

        private string[] flightDetailField;

        private ConnectPointDetailsType_195492C[] inclusionDetailField;

        private ConnectPointDetailsType[] exclusionDetailField;

        private NumberOfUnitDetailsTypeI[] unitNumberDetailField;

        /// <comentarios/>
        public CabinIdentificationType cabinId
        {
            get
            {
                return this.cabinIdField;
            }
            set
            {
                this.cabinIdField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("companyIdentity")]
        public CompanyIdentificationType_120719C[] companyIdentity
        {
            get
            {
                return this.companyIdentityField;
            }
            set
            {
                this.companyIdentityField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayItemAttribute("flightType", IsNullable = false)]
        public string[] flightDetail
        {
            get
            {
                return this.flightDetailField;
            }
            set
            {
                this.flightDetailField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("inclusionDetail")]
        public ConnectPointDetailsType_195492C[] inclusionDetail
        {
            get
            {
                return this.inclusionDetailField;
            }
            set
            {
                this.inclusionDetailField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("exclusionDetail")]
        public ConnectPointDetailsType[] exclusionDetail
        {
            get
            {
                return this.exclusionDetailField;
            }
            set
            {
                this.exclusionDetailField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("unitNumberDetail")]
        public NumberOfUnitDetailsTypeI[] unitNumberDetail
        {
            get
            {
                return this.unitNumberDetailField;
            }
            set
            {
                this.unitNumberDetailField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
    public partial class CabinIdentificationType
    {

        private string cabinQualifierField;

        private string[] cabinField;

        /// <comentarios/>
        public string cabinQualifier
        {
            get
            {
                return this.cabinQualifierField;
            }
            set
            {
                this.cabinQualifierField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("cabin")]
        public string[] cabin
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
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
    public partial class TrafficRestrictionDetailsTypeI
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
    public partial class TicketingPriceSchemeType
    {

        private string referenceNumberField;

        private string nameField;

        private string statusField;

        private string descriptionField;

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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
    public partial class TaxType
    {

        private string withholdTaxSurchargeField;

        private TaxDetailsTypeI[] taxDetailField;

        /// <comentarios/>
        public string withholdTaxSurcharge
        {
            get
            {
                return this.withholdTaxSurchargeField;
            }
            set
            {
                this.withholdTaxSurchargeField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("taxDetail")]
        public TaxDetailsTypeI[] taxDetail
        {
            get
            {
                return this.taxDetailField;
            }
            set
            {
                this.taxDetailField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
    public partial class TaxDetailsTypeI
    {

        private string rateField;

        private string countryField;

        private string currencyField;

        private string typeField;

        private string amountQualifierField;

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
        public string amountQualifier
        {
            get
            {
                return this.amountQualifierField;
            }
            set
            {
                this.amountQualifierField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
    public partial class StructuredPeriodInformationType
    {

        private StructuredDateTimeType beginDateTimeField;

        private StructuredDateTimeType endDateTimeField;

        private FrequencyType frequencyField;

        /// <comentarios/>
        public StructuredDateTimeType beginDateTime
        {
            get
            {
                return this.beginDateTimeField;
            }
            set
            {
                this.beginDateTimeField = value;
            }
        }

        /// <comentarios/>
        public StructuredDateTimeType endDateTime
        {
            get
            {
                return this.endDateTimeField;
            }
            set
            {
                this.endDateTimeField = value;
            }
        }

        /// <comentarios/>
        public FrequencyType frequency
        {
            get
            {
                return this.frequencyField;
            }
            set
            {
                this.frequencyField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
    public partial class FrequencyType
    {

        private string qualifierField;

        private string[] valueField;

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
        [System.Xml.Serialization.XmlElementAttribute("value", DataType = "integer")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
    public partial class SelectionDetailsType
    {

        private SelectionDetailsInformationType carrierFeeDetailsField;

        private SelectionDetailsInformationTypeI[] otherSelectionDetailsField;

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

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("otherSelectionDetails")]
        public SelectionDetailsInformationTypeI[] otherSelectionDetails
        {
            get
            {
                return this.otherSelectionDetailsField;
            }
            set
            {
                this.otherSelectionDetailsField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
    public partial class SelectionDetailsInformationTypeI
    {

        private string optionField;

        private string optionInformationField;

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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
    public partial class ProductLocationDetailsTypeI
    {

        private string stationField;

        /// <comentarios/>
        public string station
        {
            get
            {
                return this.stationField;
            }
            set
            {
                this.stationField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
    public partial class ProductDateTimeTypeI_194598C
    {

        private string dateField;

        private string rtcDateField;

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
        public string rtcDate
        {
            get
            {
                return this.rtcDateField;
            }
            set
            {
                this.rtcDateField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
    public partial class PricingTicketingDetailsType
    {

        private string[] pricingTicketingField;

        private ProductDateTimeTypeI_194598C ticketingDateField;

        private CompanyIdentificationType companyIdField;

        private LocationDetailsTypeI sellingPointField;

        private LocationDetailsTypeI ticketingPointField;

        private LocationDetailsTypeI journeyOriginPointField;

        private AgentIdentificationType corporateIdField;

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

        /// <comentarios/>
        public ProductDateTimeTypeI_194598C ticketingDate
        {
            get
            {
                return this.ticketingDateField;
            }
            set
            {
                this.ticketingDateField = value;
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
        public LocationDetailsTypeI sellingPoint
        {
            get
            {
                return this.sellingPointField;
            }
            set
            {
                this.sellingPointField = value;
            }
        }

        /// <comentarios/>
        public LocationDetailsTypeI ticketingPoint
        {
            get
            {
                return this.ticketingPointField;
            }
            set
            {
                this.ticketingPointField = value;
            }
        }

        /// <comentarios/>
        public LocationDetailsTypeI journeyOriginPoint
        {
            get
            {
                return this.journeyOriginPointField;
            }
            set
            {
                this.journeyOriginPointField = value;
            }
        }

        /// <comentarios/>
        public AgentIdentificationType corporateId
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
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
    public partial class CompanyIdentificationType
    {
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
    public partial class LocationDetailsTypeI
    {

        private string locationIdField;

        private string countryField;

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
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
    public partial class AgentIdentificationType
    {

        private string arcNumberField;

        private string erspNumberField;

        private string iataNumberField;

        /// <comentarios/>
        public string arcNumber
        {
            get
            {
                return this.arcNumberField;
            }
            set
            {
                this.arcNumberField = value;
            }
        }

        /// <comentarios/>
        public string erspNumber
        {
            get
            {
                return this.erspNumberField;
            }
            set
            {
                this.erspNumberField = value;
            }
        }

        /// <comentarios/>
        public string iataNumber
        {
            get
            {
                return this.iataNumberField;
            }
            set
            {
                this.iataNumberField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
    public partial class ProductTypeDetailsType
    {

        private string sequenceNumberField;

        private string availabilityContextField;

        /// <comentarios/>
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

        /// <comentarios/>
        public string availabilityContext
        {
            get
            {
                return this.availabilityContextField;
            }
            set
            {
                this.availabilityContextField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
    public partial class ProductDateTimeType
    {

        private string dateField;

        private string timeField;

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
        public string time
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
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
    public partial class PassengerItineraryInformationType
    {

        private string bookingField;

        private string identifierField;

        private string statusField;

        private string itemNumberField;

        private ProductDateTimeType dateTimeDetailsField;

        private string designatorField;

        private string movementTypeField;

        private ProductTypeDetailsType productTypeDetailsField;

        /// <comentarios/>
        public string booking
        {
            get
            {
                return this.bookingField;
            }
            set
            {
                this.bookingField = value;
            }
        }

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
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
        public string itemNumber
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
        public ProductDateTimeType dateTimeDetails
        {
            get
            {
                return this.dateTimeDetailsField;
            }
            set
            {
                this.dateTimeDetailsField = value;
            }
        }

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
        public ProductTypeDetailsType productTypeDetails
        {
            get
            {
                return this.productTypeDetailsField;
            }
            set
            {
                this.productTypeDetailsField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
    public partial class NumberOfUnitDetailsType
    {

        private string numberOfUnitsField;

        private string typeOfUnitField;

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

        /// <comentarios/>
        public string typeOfUnit
        {
            get
            {
                return this.typeOfUnitField;
            }
            set
            {
                this.typeOfUnitField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
    public partial class MonetaryInformationType
    {

        private MonetaryInformationDetailsTypeI moneyInfoField;

        private MonetaryInformationDetailsTypeI_194597C[] additionalMoneyInfoField;

        /// <comentarios/>
        public MonetaryInformationDetailsTypeI moneyInfo
        {
            get
            {
                return this.moneyInfoField;
            }
            set
            {
                this.moneyInfoField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("additionalMoneyInfo")]
        public MonetaryInformationDetailsTypeI_194597C[] additionalMoneyInfo
        {
            get
            {
                return this.additionalMoneyInfoField;
            }
            set
            {
                this.additionalMoneyInfoField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
    public partial class MonetaryInformationDetailsTypeI
    {

        private string qualifierField;

        private string amountField;

        private string currencyField;

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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
    public partial class MonetaryInformationDetailsTypeI_194597C
    {

        private string qualifierField;

        private string amountField;

        private string currencyField;

        private string locationIdField;

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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
    public partial class MonetaryInformationDetailsTypeI_65141C
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
    public partial class MonetaryInformationDetailsTypeI_65140C
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
    public partial class MonetaryAndCabinInformationDetailsType
    {

        private string amountTypeField;

        private decimal amountField;

        private string currencyField;

        private string locationIdField;

        private string[] cabinClassDesignatorField;

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
        [System.Xml.Serialization.XmlElementAttribute("cabinClassDesignator")]
        public string[] cabinClassDesignator
        {
            get
            {
                return this.cabinClassDesignatorField;
            }
            set
            {
                this.cabinClassDesignatorField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
    public partial class ItemNumberType
    {

        private ItemNumberIdentificationType itemNumberIdField;

        /// <comentarios/>
        public ItemNumberIdentificationType itemNumberId
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
    public partial class FrequentTravellerIdentificationType_249074C
    {

        private string carrierField;

        private string numberField;

        private string customerReferenceField;

        private string tierLevelField;

        private string priorityCodeField;

        private string tierDescriptionField;

        private string typeField;

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
        public string customerReference
        {
            get
            {
                return this.customerReferenceField;
            }
            set
            {
                this.customerReferenceField = value;
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

        /// <comentarios/>
        public string tierDescription
        {
            get
            {
                return this.tierDescriptionField;
            }
            set
            {
                this.tierDescriptionField = value;
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
    public partial class FreeTextInformationType
    {

        private FreeTextDetailsType freeTextDetailsField;

        private string freeTextField;

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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
    public partial class FreeTextDetailsType
    {

        private string textSubjectQualifierField;

        private string informationTypeField;

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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
    public partial class FlightProductInformationType
    {

        private CabinProductDetailsType[] cabinProductField;

        private string[] contextDetailsField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("cabinProduct")]
        public CabinProductDetailsType[] cabinProduct
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
    public partial class PNRSegmentReferenceType
    {

        private string pnrSegmentTattooField;

        private string pnrSegmentQualifierField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
        public string pnrSegmentTattoo
        {
            get
            {
                return this.pnrSegmentTattooField;
            }
            set
            {
                this.pnrSegmentTattooField = value;
            }
        }

        /// <comentarios/>
        public string pnrSegmentQualifier
        {
            get
            {
                return this.pnrSegmentQualifierField;
            }
            set
            {
                this.pnrSegmentQualifierField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
    public partial class DepartureLocationType
    {

        private ArrivalLocationDetailsType_120834C departurePointField;

        private MultiCityOptionType[] depMultiCityField;

        private PNRSegmentReferenceType firstPnrSegmentRefField;

        private CodedAttributeInformationType_139508C[] attributeDetailsField;

        /// <comentarios/>
        public ArrivalLocationDetailsType_120834C departurePoint
        {
            get
            {
                return this.departurePointField;
            }
            set
            {
                this.departurePointField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("depMultiCity")]
        public MultiCityOptionType[] depMultiCity
        {
            get
            {
                return this.depMultiCityField;
            }
            set
            {
                this.depMultiCityField = value;
            }
        }

        /// <comentarios/>
        public PNRSegmentReferenceType firstPnrSegmentRef
        {
            get
            {
                return this.firstPnrSegmentRefField;
            }
            set
            {
                this.firstPnrSegmentRefField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("attributeDetails")]
        public CodedAttributeInformationType_139508C[] attributeDetails
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
    public partial class ArrivalLocationDetailsType_120834C
    {

        private string distanceField;

        private string distanceUnitField;

        private string locationIdField;

        private string airportCityQualifierField;

        private string latitudeField;

        private string longitudeField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
        public string distance
        {
            get
            {
                return this.distanceField;
            }
            set
            {
                this.distanceField = value;
            }
        }

        /// <comentarios/>
        public string distanceUnit
        {
            get
            {
                return this.distanceUnitField;
            }
            set
            {
                this.distanceUnitField = value;
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
        public string latitude
        {
            get
            {
                return this.latitudeField;
            }
            set
            {
                this.latitudeField = value;
            }
        }

        /// <comentarios/>
        public string longitude
        {
            get
            {
                return this.longitudeField;
            }
            set
            {
                this.longitudeField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
    public partial class MultiCityOptionType
    {

        private string locationIdField;

        private string airportCityQualifierField;

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
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
    public partial class CodedAttributeInformationType_139508C
    {

        private string typeField;

        private string[] valueField;

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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
    public partial class DateAndTimeInformationType_181295S
    {

        private DateAndTimeDetailsTypeI firstDateTimeDetailField;

        private DateAndTimeDetailsType_254619C rangeOfDateField;

        private DateAndTimeDetailsType tripDetailsField;

        /// <comentarios/>
        public DateAndTimeDetailsTypeI firstDateTimeDetail
        {
            get
            {
                return this.firstDateTimeDetailField;
            }
            set
            {
                this.firstDateTimeDetailField = value;
            }
        }

        /// <comentarios/>
        public DateAndTimeDetailsType_254619C rangeOfDate
        {
            get
            {
                return this.rangeOfDateField;
            }
            set
            {
                this.rangeOfDateField = value;
            }
        }

        /// <comentarios/>
        public DateAndTimeDetailsType tripDetails
        {
            get
            {
                return this.tripDetailsField;
            }
            set
            {
                this.tripDetailsField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
    public partial class DateAndTimeDetailsTypeI
    {

        private string timeQualifierField;

        private string dateField;

        private string timeField;

        private string timeWindowField;

        /// <comentarios/>
        public string timeQualifier
        {
            get
            {
                return this.timeQualifierField;
            }
            set
            {
                this.timeQualifierField = value;
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
        public string time
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
        public string timeWindow
        {
            get
            {
                return this.timeWindowField;
            }
            set
            {
                this.timeWindowField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
    public partial class DateAndTimeDetailsType_254619C
    {

        private string rangeQualifierField;

        private string dayIntervalField;

        private string timeAtdestinationField;

        /// <comentarios/>
        public string rangeQualifier
        {
            get
            {
                return this.rangeQualifierField;
            }
            set
            {
                this.rangeQualifierField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
        public string dayInterval
        {
            get
            {
                return this.dayIntervalField;
            }
            set
            {
                this.dayIntervalField = value;
            }
        }

        /// <comentarios/>
        public string timeAtdestination
        {
            get
            {
                return this.timeAtdestinationField;
            }
            set
            {
                this.timeAtdestinationField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
    public partial class DateAndTimeDetailsType
    {

        private string flexibilityQualifierField;

        private string tripIntervalField;

        private string tripDurationField;

        /// <comentarios/>
        public string flexibilityQualifier
        {
            get
            {
                return this.flexibilityQualifierField;
            }
            set
            {
                this.flexibilityQualifierField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
        public string tripInterval
        {
            get
            {
                return this.tripIntervalField;
            }
            set
            {
                this.tripIntervalField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
        public string tripDuration
        {
            get
            {
                return this.tripDurationField;
            }
            set
            {
                this.tripDurationField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
    public partial class DateAndTimeInformationType
    {

        private DateAndTimeDetailsType_120762C[] stopDetailsField;

        private object dummyNETField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("stopDetails")]
        public DateAndTimeDetailsType_120762C[] stopDetails
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
    public partial class DateAndTimeDetailsType_120762C
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
    public partial class DateAndTimeDetailsTypeI_120740C
    {

        private string qualifierField;

        private string dateField;

        private string timeField;

        private string qualifier2Field;

        private string reserved1Field;

        private string reserved2Field;

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
        public string time
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
        public string qualifier2
        {
            get
            {
                return this.qualifier2Field;
            }
            set
            {
                this.qualifier2Field = value;
            }
        }

        /// <comentarios/>
        public string reserved1
        {
            get
            {
                return this.reserved1Field;
            }
            set
            {
                this.reserved1Field = value;
            }
        }

        /// <comentarios/>
        public string reserved2
        {
            get
            {
                return this.reserved2Field;
            }
            set
            {
                this.reserved2Field = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
    public partial class CorporateIdentityType
    {

        private string corporateQualifierField;

        private string[] identityField;

        /// <comentarios/>
        public string corporateQualifier
        {
            get
            {
                return this.corporateQualifierField;
            }
            set
            {
                this.corporateQualifierField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("identity")]
        public string[] identity
        {
            get
            {
                return this.identityField;
            }
            set
            {
                this.identityField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
    public partial class CorporateFareInformationType
    {

        private CorporateFareIdentifiersType corporateFareIdentifiersField;

        /// <comentarios/>
        public CorporateFareIdentifiersType corporateFareIdentifiers
        {
            get
            {
                return this.corporateFareIdentifiersField;
            }
            set
            {
                this.corporateFareIdentifiersField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
    public partial class CorporateFareIdentifiersType
    {

        private string fareQualifierField;

        private string[] identifyNumberField;

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
        [System.Xml.Serialization.XmlElementAttribute("identifyNumber")]
        public string[] identifyNumber
        {
            get
            {
                return this.identifyNumberField;
            }
            set
            {
                this.identifyNumberField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
    public partial class ConversionRateDetailsType
    {

        private string conversionTypeField;

        private string currencyField;

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
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
    public partial class ConnectionDetailsTypeI
    {

        private string locationField;

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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
    public partial class CompanyRoleIdentificationType_120761C
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
    public partial class CommercialAgreementsType_78540S
    {

        private CompanyRoleIdentificationType_120761C codeshareDetailsField;

        private CompanyRoleIdentificationType_120761C[] otherCodeshareDetailsField;

        /// <comentarios/>
        public CompanyRoleIdentificationType_120761C codeshareDetails
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
        public CompanyRoleIdentificationType_120761C[] otherCodeshareDetails
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
    public partial class CompanyRoleIdentificationType
    {

        private string transportStageQualifierField;

        private string airlineDesignatorField;

        private string flightNumberField;

        private string operationalSuffixField;

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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
    public partial class CodedAttributeInformationType_277155C
    {

        private string feeTypeField;

        private string feeIdNumberField;

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
        public string feeIdNumber
        {
            get
            {
                return this.feeIdNumberField;
            }
            set
            {
                this.feeIdNumberField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
    public partial class CodedAttributeInformationType_254574C
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
    public partial class BucketInformationType
    {

        private string numberField;

        private string nameField;

        private string completionField;

        private string modeField;

        private string valueRefField;

        private string weightField;

        private string countField;

        private string attributeCountField;

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

        /// <comentarios/>
        public string completion
        {
            get
            {
                return this.completionField;
            }
            set
            {
                this.completionField = value;
            }
        }

        /// <comentarios/>
        public string mode
        {
            get
            {
                return this.modeField;
            }
            set
            {
                this.modeField = value;
            }
        }

        /// <comentarios/>
        public string valueRef
        {
            get
            {
                return this.valueRefField;
            }
            set
            {
                this.valueRefField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
        public string weight
        {
            get
            {
                return this.weightField;
            }
            set
            {
                this.weightField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
        public string count
        {
            get
            {
                return this.countField;
            }
            set
            {
                this.countField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
        public string attributeCount
        {
            get
            {
                return this.attributeCountField;
            }
            set
            {
                this.attributeCountField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
    public partial class BucketDetailsType
    {

        private string codeField;

        private string typeField;

        private AttributeDetailsType[] attributeField;

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
        [System.Xml.Serialization.XmlElementAttribute("attribute")]
        public AttributeDetailsType[] attribute
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
    public partial class AttributeDetailsType
    {

        private string requestedSgtField;

        private string[] valueField;

        /// <comentarios/>
        public string requestedSgt
        {
            get
            {
                return this.requestedSgtField;
            }
            set
            {
                this.requestedSgtField = value;
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
    public partial class BooleanExpressionRuleType
    {

        private ArithmeticEvaluationType booleanExpressionField;

        /// <comentarios/>
        public ArithmeticEvaluationType booleanExpression
        {
            get
            {
                return this.booleanExpressionField;
            }
            set
            {
                this.booleanExpressionField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
    public partial class ArithmeticEvaluationType
    {

        private string codeOperatorField;

        /// <comentarios/>
        public string codeOperator
        {
            get
            {
                return this.codeOperatorField;
            }
            set
            {
                this.codeOperatorField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
    public partial class AttributeType_61377S
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
    public partial class ArrivalLocationDetailsType
    {

        private string distanceField;

        private string distanceUnitField;

        private string locationIdField;

        private string airportCityQualifierField;

        private string latitudeField;

        private string longitudeField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
        public string distance
        {
            get
            {
                return this.distanceField;
            }
            set
            {
                this.distanceField = value;
            }
        }

        /// <comentarios/>
        public string distanceUnit
        {
            get
            {
                return this.distanceUnitField;
            }
            set
            {
                this.distanceUnitField = value;
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
        public string latitude
        {
            get
            {
                return this.latitudeField;
            }
            set
            {
                this.latitudeField = value;
            }
        }

        /// <comentarios/>
        public string longitude
        {
            get
            {
                return this.longitudeField;
            }
            set
            {
                this.longitudeField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
    public partial class ArrivalLocalizationType
    {

        private ArrivalLocationDetailsType arrivalPointDetailsField;

        private MultiCityOptionType[] arrivalMultiCityField;

        private CodedAttributeInformationType_139508C[] attributeDetailsField;

        /// <comentarios/>
        public ArrivalLocationDetailsType arrivalPointDetails
        {
            get
            {
                return this.arrivalPointDetailsField;
            }
            set
            {
                this.arrivalPointDetailsField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("arrivalMultiCity")]
        public MultiCityOptionType[] arrivalMultiCity
        {
            get
            {
                return this.arrivalMultiCityField;
            }
            set
            {
                this.arrivalMultiCityField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("attributeDetails")]
        public CodedAttributeInformationType_139508C[] attributeDetails
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
    public partial class MileageTimeDetailsTypeI
    {

        private string elapsedGroundTimeField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
        public string elapsedGroundTime
        {
            get
            {
                return this.elapsedGroundTimeField;
            }
            set
            {
                this.elapsedGroundTimeField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
    public partial class StationInformationTypeI
    {

        private string terminalField;

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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
    public partial class AdditionalProductTypeI
    {

        private string equipmentField;

        private string durationField;

        private string complexingFlightIndicatorField;

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
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
        public string duration
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
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
    public partial class AdditionalProductDetailsTypeI
    {

        private AdditionalProductTypeI legDetailsField;

        private StationInformationTypeI departureStationInfoField;

        private StationInformationTypeI arrivalStationInfoField;

        private MileageTimeDetailsTypeI mileageTimeDetailsField;

        /// <comentarios/>
        public AdditionalProductTypeI legDetails
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
        public StationInformationTypeI departureStationInfo
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
        public StationInformationTypeI arrivalStationInfo
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
    public partial class ProductIdentificationDetailsTypeI_50878C
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
    public partial class ActionIdentificationType
    {

        private string actionRequestCodeField;

        private ProductIdentificationDetailsTypeI_50878C productDetailsField;

        /// <comentarios/>
        public string actionRequestCode
        {
            get
            {
                return this.actionRequestCodeField;
            }
            set
            {
                this.actionRequestCodeField = value;
            }
        }

        /// <comentarios/>
        public ProductIdentificationDetailsTypeI_50878C productDetails
        {
            get
            {
                return this.productDetailsField;
            }
            set
            {
                this.productDetailsField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
    public partial class ReferenceInfoType
    {

        private ReferencingDetailsType[] referencingDetailField;

        private object dummyNETField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("referencingDetail")]
        public ReferencingDetailsType[] referencingDetail
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
    public partial class CodedAttributeInformationType_120742C
    {

        private string nameField;

        private string[] valueField;

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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
    public partial class ProductDateTimeTypeI_194583C
    {

        private string dateField;

        private string otherDateField;

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
        public string otherDate
        {
            get
            {
                return this.otherDateField;
            }
            set
            {
                this.otherDateField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
    public partial class CabinClassDesignationType
    {

        private string cabinDesignatorField;

        /// <comentarios/>
        public string cabinDesignator
        {
            get
            {
                return this.cabinDesignatorField;
            }
            set
            {
                this.cabinDesignatorField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
    public partial class MultipleIdentificationNumbersTypeI
    {

        private string corporateNumberIdentifierField;

        private string corporateNameField;

        /// <comentarios/>
        public string corporateNumberIdentifier
        {
            get
            {
                return this.corporateNumberIdentifierField;
            }
            set
            {
                this.corporateNumberIdentifierField = value;
            }
        }

        /// <comentarios/>
        public string corporateName
        {
            get
            {
                return this.corporateNameField;
            }
            set
            {
                this.corporateNameField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
    public partial class FareProductDetailsType
    {

        private string fareBasisField;

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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
    public partial class FareFamilyCriteriaType
    {

        private string[] carrierIdField;

        private string[] rdbField;

        private string[] fareFamilyInfoField;

        private FareProductDetailsType[] fareProductDetailField;

        private MultipleIdentificationNumbersTypeI[] corporateInfoField;

        private CabinClassDesignationType[] cabinProductField;

        private string cabinProcessingIdentifierField;

        private ProductDateTimeTypeI_194583C[] dateTimeDetailsField;

        private CodedAttributeInformationType_120742C[] otherCriteriaField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("carrierId")]
        public string[] carrierId
        {
            get
            {
                return this.carrierIdField;
            }
            set
            {
                this.carrierIdField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("rdb")]
        public string[] rdb
        {
            get
            {
                return this.rdbField;
            }
            set
            {
                this.rdbField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayItemAttribute("fareFamilyQual", IsNullable = false)]
        public string[] fareFamilyInfo
        {
            get
            {
                return this.fareFamilyInfoField;
            }
            set
            {
                this.fareFamilyInfoField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("fareProductDetail")]
        public FareProductDetailsType[] fareProductDetail
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
        [System.Xml.Serialization.XmlElementAttribute("corporateInfo")]
        public MultipleIdentificationNumbersTypeI[] corporateInfo
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
        [System.Xml.Serialization.XmlElementAttribute("cabinProduct")]
        public CabinClassDesignationType[] cabinProduct
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
        public string cabinProcessingIdentifier
        {
            get
            {
                return this.cabinProcessingIdentifierField;
            }
            set
            {
                this.cabinProcessingIdentifierField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("dateTimeDetails")]
        public ProductDateTimeTypeI_194583C[] dateTimeDetails
        {
            get
            {
                return this.dateTimeDetailsField;
            }
            set
            {
                this.dateTimeDetailsField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("otherCriteria")]
        public CodedAttributeInformationType_120742C[] otherCriteria
        {
            get
            {
                return this.otherCriteriaField;
            }
            set
            {
                this.otherCriteriaField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
    public partial class FareFamilyType_80157S
    {

        private string refNumberField;

        private string fareFamilynameField;

        private string hierarchyField;

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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
    public partial class FrequentTravellerIdentificationType
    {

        private string carrierField;

        private string numberField;

        private string customerReferenceField;

        private string statusField;

        private string tierLevelField;

        private string priorityCodeField;

        private string tierDescriptionField;

        private string companyCodeField;

        private string customerValueField;

        private string typeField;

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
        public string customerReference
        {
            get
            {
                return this.customerReferenceField;
            }
            set
            {
                this.customerReferenceField = value;
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

        /// <comentarios/>
        public string tierDescription
        {
            get
            {
                return this.tierDescriptionField;
            }
            set
            {
                this.tierDescriptionField = value;
            }
        }

        /// <comentarios/>
        public string companyCode
        {
            get
            {
                return this.companyCodeField;
            }
            set
            {
                this.companyCodeField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
        public string customerValue
        {
            get
            {
                return this.customerValueField;
            }
            set
            {
                this.customerValueField = value;
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
    public partial class SegmentRepetitionControlDetailsTypeI
    {

        private string quantityField;

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
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
    public partial class GroupPassengerDetailsType
    {

        private SegmentRepetitionControlDetailsTypeI[] passengerReferenceField;

        private GroupPassengerDetailsTypePsgDetailsInfo[] psgDetailsInfoField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayItemAttribute("segmentControlDetails", IsNullable = false)]
        public SegmentRepetitionControlDetailsTypeI[] passengerReference
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
        [System.Xml.Serialization.XmlElementAttribute("psgDetailsInfo")]
        public GroupPassengerDetailsTypePsgDetailsInfo[] psgDetailsInfo
        {
            get
            {
                return this.psgDetailsInfoField;
            }
            set
            {
                this.psgDetailsInfoField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
    public partial class GroupPassengerDetailsTypePsgDetailsInfo
    {

        private FareInformationTypeI discountPtcField;

        private FrequentTravellerIdentificationType[] flequentFlyerDetailsField;

        /// <comentarios/>
        public FareInformationTypeI discountPtc
        {
            get
            {
                return this.discountPtcField;
            }
            set
            {
                this.discountPtcField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayItemAttribute("frequentTravellerDetails", IsNullable = false)]
        public FrequentTravellerIdentificationType[] flequentFlyerDetails
        {
            get
            {
                return this.flequentFlyerDetailsField;
            }
            set
            {
                this.flequentFlyerDetailsField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
    public partial class FareDetailsType
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
    public partial class FareInformationType
    {

        private string valueQualifierField;

        private string valueField;

        private FareDetailsType fareDetailsField;

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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
    public partial class UniqueIdDescriptionType
    {

        private string passengerFeeRefQualifField;

        /// <comentarios/>
        public string passengerFeeRefQualif
        {
            get
            {
                return this.passengerFeeRefQualifField;
            }
            set
            {
                this.passengerFeeRefQualifField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
    public partial class ItemReferencesAndVersionsType
    {

        private string passengerFeeRefTypeField;

        private string passengerFeeRefNumberField;

        private UniqueIdDescriptionType otherCharacteristicsField;

        /// <comentarios/>
        public string passengerFeeRefType
        {
            get
            {
                return this.passengerFeeRefTypeField;
            }
            set
            {
                this.passengerFeeRefTypeField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
        public string passengerFeeRefNumber
        {
            get
            {
                return this.passengerFeeRefNumberField;
            }
            set
            {
                this.passengerFeeRefNumberField = value;
            }
        }

        /// <comentarios/>
        public UniqueIdDescriptionType otherCharacteristics
        {
            get
            {
                return this.otherCharacteristicsField;
            }
            set
            {
                this.otherCharacteristicsField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
    public partial class FormOfPaymentDetailsTypeI
    {

        private string typeField;

        private decimal chargedAmountField;

        private bool chargedAmountFieldSpecified;

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
        public decimal chargedAmount
        {
            get
            {
                return this.chargedAmountField;
            }
            set
            {
                this.chargedAmountField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool chargedAmountSpecified
        {
            get
            {
                return this.chargedAmountFieldSpecified;
            }
            set
            {
                this.chargedAmountFieldSpecified = value;
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
    public partial class FOPRepresentationType
    {

        private FormOfPaymentDetailsTypeI[] formOfPaymentDetailsField;

        private ItemReferencesAndVersionsType passengerFeeReferenceField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayItemAttribute("formOfPaymentDetails", IsNullable = false)]
        public FormOfPaymentDetailsTypeI[] formOfPaymentDetails
        {
            get
            {
                return this.formOfPaymentDetailsField;
            }
            set
            {
                this.formOfPaymentDetailsField = value;
            }
        }

        /// <comentarios/>
        public ItemReferencesAndVersionsType passengerFeeReference
        {
            get
            {
                return this.passengerFeeReferenceField;
            }
            set
            {
                this.passengerFeeReferenceField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
    public partial class AttributeDetails
    {

        private string qualifierField;

        private string[] valueField;

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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
    public partial class AttributeList
    {

        private string qualifierField;

        private AttributeDetails[] attributeDetailsField;

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
        [System.Xml.Serialization.XmlElementAttribute("attributeDetails")]
        public AttributeDetails[] attributeDetails
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
    public partial class ConsumerReferenceIdentificationTypeI
    {

        private string referenceQualifierField;

        private string referenceNumberField;

        private string referencePartyNameField;

        private string travellerReferenceNbrField;

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
        public string referencePartyName
        {
            get
            {
                return this.referencePartyNameField;
            }
            set
            {
                this.referencePartyNameField = value;
            }
        }

        /// <comentarios/>
        public string travellerReferenceNbr
        {
            get
            {
                return this.travellerReferenceNbrField;
            }
            set
            {
                this.travellerReferenceNbrField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
    public partial class AttributeInformationType
    {

        private string optionField;

        private string optionInformationField;

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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
    public partial class Fare_InstantTravelBoardSearchFareFamilies
    {

        private FareFamilyType_80157S familyInformationField;

        private FareFamilyCriteriaType familyCriteriaField;

        private Fare_InstantTravelBoardSearchFareFamiliesFareFamilySegment[] fareFamilySegmentField;

        private Fare_InstantTravelBoardSearchFareFamiliesOtherPossibleCriteria[] otherPossibleCriteriaField;

        /// <comentarios/>
        public FareFamilyType_80157S familyInformation
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
        public FareFamilyCriteriaType familyCriteria
        {
            get
            {
                return this.familyCriteriaField;
            }
            set
            {
                this.familyCriteriaField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("fareFamilySegment")]
        public Fare_InstantTravelBoardSearchFareFamiliesFareFamilySegment[] fareFamilySegment
        {
            get
            {
                return this.fareFamilySegmentField;
            }
            set
            {
                this.fareFamilySegmentField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("otherPossibleCriteria")]
        public Fare_InstantTravelBoardSearchFareFamiliesOtherPossibleCriteria[] otherPossibleCriteria
        {
            get
            {
                return this.otherPossibleCriteriaField;
            }
            set
            {
                this.otherPossibleCriteriaField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
    public partial class Fare_InstantTravelBoardSearchFareFamiliesFareFamilySegment
    {

        private ReferenceInfoType referenceInfoField;

        private FareFamilyCriteriaType familyCriteriaField;

        /// <comentarios/>
        public ReferenceInfoType referenceInfo
        {
            get
            {
                return this.referenceInfoField;
            }
            set
            {
                this.referenceInfoField = value;
            }
        }

        /// <comentarios/>
        public FareFamilyCriteriaType familyCriteria
        {
            get
            {
                return this.familyCriteriaField;
            }
            set
            {
                this.familyCriteriaField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
    public partial class Fare_InstantTravelBoardSearchFareFamiliesOtherPossibleCriteria
    {

        private BooleanExpressionRuleType logicalLinkField;

        private FareFamilyCriteriaType familyCriteriaField;

        private Fare_InstantTravelBoardSearchFareFamiliesOtherPossibleCriteriaFareFamilySegment[] fareFamilySegmentField;

        /// <comentarios/>
        public BooleanExpressionRuleType logicalLink
        {
            get
            {
                return this.logicalLinkField;
            }
            set
            {
                this.logicalLinkField = value;
            }
        }

        /// <comentarios/>
        public FareFamilyCriteriaType familyCriteria
        {
            get
            {
                return this.familyCriteriaField;
            }
            set
            {
                this.familyCriteriaField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("fareFamilySegment")]
        public Fare_InstantTravelBoardSearchFareFamiliesOtherPossibleCriteriaFareFamilySegment[] fareFamilySegment
        {
            get
            {
                return this.fareFamilySegmentField;
            }
            set
            {
                this.fareFamilySegmentField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
    public partial class Fare_InstantTravelBoardSearchFareFamiliesOtherPossibleCriteriaFareFamilySegment
    {

        private ReferenceInfoType referenceInfoField;

        private FareFamilyCriteriaType familyCriteriaField;

        /// <comentarios/>
        public ReferenceInfoType referenceInfo
        {
            get
            {
                return this.referenceInfoField;
            }
            set
            {
                this.referenceInfoField = value;
            }
        }

        /// <comentarios/>
        public FareFamilyCriteriaType familyCriteria
        {
            get
            {
                return this.familyCriteriaField;
            }
            set
            {
                this.familyCriteriaField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
    public partial class Fare_InstantTravelBoardSearchFareOptions
    {

        private PricingTicketingDetailsType pricingTickInfoField;

        private CorporateIdentityType[] corporateField;

        private TicketingPriceSchemeType ticketingPriceSchemeField;

        private CodedAttributeInformationType_277155C[] feeIdDescriptionField;

        private ConversionRateDetailsType[] conversionRateField;

        private FormOfPaymentDetailsTypeI[] formOfPaymentField;

        private FrequentTravellerIdentificationType_249074C[] frequentTravellerInfoField;

        private MonetaryAndCabinInformationDetailsType[] monetaryCabinInfoField;

        /// <comentarios/>
        public PricingTicketingDetailsType pricingTickInfo
        {
            get
            {
                return this.pricingTickInfoField;
            }
            set
            {
                this.pricingTickInfoField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayItemAttribute("corporateId", IsNullable = false)]
        public CorporateIdentityType[] corporate
        {
            get
            {
                return this.corporateField;
            }
            set
            {
                this.corporateField = value;
            }
        }

        /// <comentarios/>
        public TicketingPriceSchemeType ticketingPriceScheme
        {
            get
            {
                return this.ticketingPriceSchemeField;
            }
            set
            {
                this.ticketingPriceSchemeField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayItemAttribute("feeId", IsNullable = false)]
        public CodedAttributeInformationType_277155C[] feeIdDescription
        {
            get
            {
                return this.feeIdDescriptionField;
            }
            set
            {
                this.feeIdDescriptionField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayItemAttribute("conversionRateDetail", IsNullable = false)]
        public ConversionRateDetailsType[] conversionRate
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
        [System.Xml.Serialization.XmlArrayItemAttribute("formOfPaymentDetails", IsNullable = false)]
        public FormOfPaymentDetailsTypeI[] formOfPayment
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
        [System.Xml.Serialization.XmlArrayItemAttribute("frequentTravellerDetails", IsNullable = false)]
        public FrequentTravellerIdentificationType_249074C[] frequentTravellerInfo
        {
            get
            {
                return this.frequentTravellerInfoField;
            }
            set
            {
                this.frequentTravellerInfoField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayItemAttribute("moneyAndCabinInfo", IsNullable = false)]
        public MonetaryAndCabinInformationDetailsType[] monetaryCabinInfo
        {
            get
            {
                return this.monetaryCabinInfoField;
            }
            set
            {
                this.monetaryCabinInfoField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
    public partial class Fare_InstantTravelBoardSearchBuckets
    {

        private BucketInformationType bucketInfoField;

        private BucketDetailsType[] bucketDetailsField;

        /// <comentarios/>
        public BucketInformationType bucketInfo
        {
            get
            {
                return this.bucketInfoField;
            }
            set
            {
                this.bucketInfoField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("bucketDetails")]
        public BucketDetailsType[] bucketDetails
        {
            get
            {
                return this.bucketDetailsField;
            }
            set
            {
                this.bucketDetailsField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
    public partial class Fare_InstantTravelBoardSearchItinerary
    {

        private OriginAndDestinationRequestType requestedSegmentRefField;

        private DepartureLocationType departureLocalizationField;

        private ArrivalLocalizationType arrivalLocalizationField;

        private DateAndTimeInformationType_181295S timeDetailsField;

        private TravelFlightInformationType_199585S flightInfoField;

        private FareFamilyDetailsType[] familyInformationField;

        private ValueSearchCriteriaType[] valueSearchField;

        private Fare_InstantTravelBoardSearchItineraryGroupOfFlights[] groupOfFlightsField;

        private Fare_InstantTravelBoardSearchItineraryFlightInfoPNR[] flightInfoPNRField;

        private ActionIdentificationType requestedSegmentActionField;

        private CodedAttributeInformationType_254574C[] attributesField;

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
        public DepartureLocationType departureLocalization
        {
            get
            {
                return this.departureLocalizationField;
            }
            set
            {
                this.departureLocalizationField = value;
            }
        }

        /// <comentarios/>
        public ArrivalLocalizationType arrivalLocalization
        {
            get
            {
                return this.arrivalLocalizationField;
            }
            set
            {
                this.arrivalLocalizationField = value;
            }
        }

        /// <comentarios/>
        public DateAndTimeInformationType_181295S timeDetails
        {
            get
            {
                return this.timeDetailsField;
            }
            set
            {
                this.timeDetailsField = value;
            }
        }

        /// <comentarios/>
        public TravelFlightInformationType_199585S flightInfo
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
        [System.Xml.Serialization.XmlArrayItemAttribute("commercialFamilyDetails", IsNullable = false)]
        public FareFamilyDetailsType[] familyInformation
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
        [System.Xml.Serialization.XmlElementAttribute("valueSearch")]
        public ValueSearchCriteriaType[] valueSearch
        {
            get
            {
                return this.valueSearchField;
            }
            set
            {
                this.valueSearchField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("groupOfFlights")]
        public Fare_InstantTravelBoardSearchItineraryGroupOfFlights[] groupOfFlights
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

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("flightInfoPNR")]
        public Fare_InstantTravelBoardSearchItineraryFlightInfoPNR[] flightInfoPNR
        {
            get
            {
                return this.flightInfoPNRField;
            }
            set
            {
                this.flightInfoPNRField = value;
            }
        }

        /// <comentarios/>
        public ActionIdentificationType requestedSegmentAction
        {
            get
            {
                return this.requestedSegmentActionField;
            }
            set
            {
                this.requestedSegmentActionField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayItemAttribute("attributeDetails", IsNullable = false)]
        public CodedAttributeInformationType_254574C[] attributes
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
    public partial class Fare_InstantTravelBoardSearchItineraryGroupOfFlights
    {

        private ProposedSegmentType propFlightGrDetailField;

        private MonetaryInformationType priceToBeatField;

        private Fare_InstantTravelBoardSearchItineraryGroupOfFlightsFlightDetails[] flightDetailsField;

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
        public MonetaryInformationType priceToBeat
        {
            get
            {
                return this.priceToBeatField;
            }
            set
            {
                this.priceToBeatField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("flightDetails")]
        public Fare_InstantTravelBoardSearchItineraryGroupOfFlightsFlightDetails[] flightDetails
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
    public partial class Fare_InstantTravelBoardSearchItineraryGroupOfFlightsFlightDetails
    {

        private TravelProductType flightInformationField;

        private FlightProductInformationType[] avlInfoField;

        private DateAndTimeInformationType[] technicalStopField;

        private CommercialAgreementsType_78540S commercialAgreementField;

        private HeaderInformationTypeI addInfoField;

        private AdditionalProductDetailsTypeI[] terminalEquipmentDetailsField;

        private PassengerItineraryInformationType reservationInfoField;

        private MonetaryInformationType priceToBeatField;

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
        public FlightProductInformationType[] avlInfo
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
        public CommercialAgreementsType_78540S commercialAgreement
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

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("terminalEquipmentDetails")]
        public AdditionalProductDetailsTypeI[] terminalEquipmentDetails
        {
            get
            {
                return this.terminalEquipmentDetailsField;
            }
            set
            {
                this.terminalEquipmentDetailsField = value;
            }
        }

        /// <comentarios/>
        public PassengerItineraryInformationType reservationInfo
        {
            get
            {
                return this.reservationInfoField;
            }
            set
            {
                this.reservationInfoField = value;
            }
        }

        /// <comentarios/>
        public MonetaryInformationType priceToBeat
        {
            get
            {
                return this.priceToBeatField;
            }
            set
            {
                this.priceToBeatField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
    public partial class Fare_InstantTravelBoardSearchItineraryFlightInfoPNR
    {

        private TravelProductInformationTypeI travelResponseDetailsField;

        private StructuredPeriodInformationType timeTableDateField;

        private AdditionalProductDetailsTypeI[] terminalEquipmentDetailsField;

        private CommercialAgreementsType codeshareDataField;

        private FreeTextInformationType disclosureField;

        private ProductLocationDetailsTypeI[] stopDetailsField;

        private TrafficRestrictionDetailsTypeI[] trafficRestrictionDataField;

        private PassengerItineraryInformationType reservationInfoField;

        private Fare_InstantTravelBoardSearchItineraryFlightInfoPNRIncidentalStopInfo[] incidentalStopInfoField;

        /// <comentarios/>
        public TravelProductInformationTypeI travelResponseDetails
        {
            get
            {
                return this.travelResponseDetailsField;
            }
            set
            {
                this.travelResponseDetailsField = value;
            }
        }

        /// <comentarios/>
        public StructuredPeriodInformationType timeTableDate
        {
            get
            {
                return this.timeTableDateField;
            }
            set
            {
                this.timeTableDateField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("terminalEquipmentDetails")]
        public AdditionalProductDetailsTypeI[] terminalEquipmentDetails
        {
            get
            {
                return this.terminalEquipmentDetailsField;
            }
            set
            {
                this.terminalEquipmentDetailsField = value;
            }
        }

        /// <comentarios/>
        public CommercialAgreementsType codeshareData
        {
            get
            {
                return this.codeshareDataField;
            }
            set
            {
                this.codeshareDataField = value;
            }
        }

        /// <comentarios/>
        public FreeTextInformationType disclosure
        {
            get
            {
                return this.disclosureField;
            }
            set
            {
                this.disclosureField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayItemAttribute("routingDetails", IsNullable = false)]
        public ProductLocationDetailsTypeI[] stopDetails
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
        [System.Xml.Serialization.XmlArrayItemAttribute("trafficRestrictionDetails", IsNullable = false)]
        public TrafficRestrictionDetailsTypeI[] trafficRestrictionData
        {
            get
            {
                return this.trafficRestrictionDataField;
            }
            set
            {
                this.trafficRestrictionDataField = value;
            }
        }

        /// <comentarios/>
        public PassengerItineraryInformationType reservationInfo
        {
            get
            {
                return this.reservationInfoField;
            }
            set
            {
                this.reservationInfoField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("incidentalStopInfo")]
        public Fare_InstantTravelBoardSearchItineraryFlightInfoPNRIncidentalStopInfo[] incidentalStopInfo
        {
            get
            {
                return this.incidentalStopInfoField;
            }
            set
            {
                this.incidentalStopInfoField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
    public partial class Fare_InstantTravelBoardSearchItineraryFlightInfoPNRIncidentalStopInfo
    {

        private DateAndTimeDetailsTypeI_120740C[] dateTimeInfoField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayItemAttribute("dateTimeDetails", IsNullable = false)]
        public DateAndTimeDetailsTypeI_120740C[] dateTimeInfo
        {
            get
            {
                return this.dateTimeInfoField;
            }
            set
            {
                this.dateTimeInfoField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
    public partial class Fare_InstantTravelBoardSearchTicketChangeInfo
    {

        private TicketNumberDetailsTypeI[] ticketNumberDetailsField;

        private Fare_InstantTravelBoardSearchTicketChangeInfoTicketRequestedSegments[] ticketRequestedSegmentsField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayItemAttribute("documentDetails", IsNullable = false)]
        public TicketNumberDetailsTypeI[] ticketNumberDetails
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

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("ticketRequestedSegments")]
        public Fare_InstantTravelBoardSearchTicketChangeInfoTicketRequestedSegments[] ticketRequestedSegments
        {
            get
            {
                return this.ticketRequestedSegmentsField;
            }
            set
            {
                this.ticketRequestedSegmentsField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
    public partial class Fare_InstantTravelBoardSearchTicketChangeInfoTicketRequestedSegments
    {

        private ActionIdentificationType actionIdentificationField;

        private ConnectionDetailsTypeI[] connectPointDetailsField;

        /// <comentarios/>
        public ActionIdentificationType actionIdentification
        {
            get
            {
                return this.actionIdentificationField;
            }
            set
            {
                this.actionIdentificationField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayItemAttribute("connectionDetails", IsNullable = false)]
        public ConnectionDetailsTypeI[] connectPointDetails
        {
            get
            {
                return this.connectPointDetailsField;
            }
            set
            {
                this.connectPointDetailsField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
    public partial class Fare_InstantTravelBoardSearchCombinationFareFamilies
    {

        private ItemNumberType itemFFCNumberField;

        private NumberOfUnitDetailsType[] nbOfUnitsField;

        private ReferenceInfoType[] referenceInfoField;

        /// <comentarios/>
        public ItemNumberType itemFFCNumber
        {
            get
            {
                return this.itemFFCNumberField;
            }
            set
            {
                this.itemFFCNumberField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayItemAttribute("unitNumberDetail", IsNullable = false)]
        public NumberOfUnitDetailsType[] nbOfUnits
        {
            get
            {
                return this.nbOfUnitsField;
            }
            set
            {
                this.nbOfUnitsField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("referenceInfo")]
        public ReferenceInfoType[] referenceInfo
        {
            get
            {
                return this.referenceInfoField;
            }
            set
            {
                this.referenceInfoField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
    public partial class Fare_InstantTravelBoardSearchFeeOption
    {

        private SelectionDetailsType feeTypeInfoField;

        private MonetaryInformationDetailsTypeI_65140C[] rateTaxField;

        private Fare_InstantTravelBoardSearchFeeOptionFeeDetails[] feeDetailsField;

        /// <comentarios/>
        public SelectionDetailsType feeTypeInfo
        {
            get
            {
                return this.feeTypeInfoField;
            }
            set
            {
                this.feeTypeInfoField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayItemAttribute("monetaryDetails", IsNullable = false)]
        public MonetaryInformationDetailsTypeI_65140C[] rateTax
        {
            get
            {
                return this.rateTaxField;
            }
            set
            {
                this.rateTaxField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("feeDetails")]
        public Fare_InstantTravelBoardSearchFeeOptionFeeDetails[] feeDetails
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
    public partial class Fare_InstantTravelBoardSearchFeeOptionFeeDetails
    {

        private SpecificDataInformationType feeInfoField;

        private MonetaryInformationDetailsTypeI_65141C[] associatedAmountsField;

        private Fare_InstantTravelBoardSearchFeeOptionFeeDetailsFeeDescriptionGrp feeDescriptionGrpField;

        /// <comentarios/>
        public SpecificDataInformationType feeInfo
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
        [System.Xml.Serialization.XmlArrayItemAttribute("monetaryDetails", IsNullable = false)]
        public MonetaryInformationDetailsTypeI_65141C[] associatedAmounts
        {
            get
            {
                return this.associatedAmountsField;
            }
            set
            {
                this.associatedAmountsField = value;
            }
        }

        /// <comentarios/>
        public Fare_InstantTravelBoardSearchFeeOptionFeeDetailsFeeDescriptionGrp feeDescriptionGrp
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
    public partial class Fare_InstantTravelBoardSearchFeeOptionFeeDetailsFeeDescriptionGrp
    {

        private ItemNumberType_80866S itemNumberInfoField;

        private AttributeType_61377S serviceAttributesInfoField;

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
        public AttributeType_61377S serviceAttributesInfo
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
    public partial class Fare_InstantTravelBoardSearchOfficeIdDetails
    {

        private UserIdentificationType officeIdInformationField;

        private NumberOfUnitDetailsType[] nbOfUnitsField;

        private CodedAttributeInformationType[] uidOptionField;

        private PricingTicketingDetailsType pricingTickInfoField;

        private CorporateFareInformationType corporateFareInfoField;

        private TravelFlightInformationType travelFlightInfoField;

        private Fare_InstantTravelBoardSearchOfficeIdDetailsAirlineDistributionDetails[] airlineDistributionDetailsField;

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
        [System.Xml.Serialization.XmlArrayItemAttribute("unitNumberDetail", IsNullable = false)]
        public NumberOfUnitDetailsType[] nbOfUnits
        {
            get
            {
                return this.nbOfUnitsField;
            }
            set
            {
                this.nbOfUnitsField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayItemAttribute("attributeDetails", IsNullable = false)]
        public CodedAttributeInformationType[] uidOption
        {
            get
            {
                return this.uidOptionField;
            }
            set
            {
                this.uidOptionField = value;
            }
        }

        /// <comentarios/>
        public PricingTicketingDetailsType pricingTickInfo
        {
            get
            {
                return this.pricingTickInfoField;
            }
            set
            {
                this.pricingTickInfoField = value;
            }
        }

        /// <comentarios/>
        public CorporateFareInformationType corporateFareInfo
        {
            get
            {
                return this.corporateFareInfoField;
            }
            set
            {
                this.corporateFareInfoField = value;
            }
        }

        /// <comentarios/>
        public TravelFlightInformationType travelFlightInfo
        {
            get
            {
                return this.travelFlightInfoField;
            }
            set
            {
                this.travelFlightInfoField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("airlineDistributionDetails")]
        public Fare_InstantTravelBoardSearchOfficeIdDetailsAirlineDistributionDetails[] airlineDistributionDetails
        {
            get
            {
                return this.airlineDistributionDetailsField;
            }
            set
            {
                this.airlineDistributionDetailsField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/FIFRTQ_16_2_1A")]
    public partial class Fare_InstantTravelBoardSearchOfficeIdDetailsAirlineDistributionDetails
    {

        private OriginAndDestinationRequestType requestedSegmentRefField;

        private TravelFlightInformationType flightInfoField;

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
        public TravelFlightInformationType flightInfo
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
    }

}

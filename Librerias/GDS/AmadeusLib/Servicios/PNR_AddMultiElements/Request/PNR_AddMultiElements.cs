using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AmadeusLib.Servicios.PNR_AddMultiElements.Request
{
    
    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRADD_10_1_1A")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://xml.amadeus.com/PNRADD_10_1_1A", IsNullable = false)]
    public partial class PNR_AddMultiElements
    {

        private PNR_AddMultiElementsReservationInfo reservationInfoField;

        private decimal[] pnrActionsField;

        private PNR_AddMultiElementsTravellerInfo[] travellerInfoField;

        private PNR_AddMultiElementsOriginDestinationDetails[] originDestinationDetailsField;

        private PNR_AddMultiElementsDataElementsMaster dataElementsMasterField;

        /// <comentarios/>
        public PNR_AddMultiElementsReservationInfo reservationInfo
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
        [System.Xml.Serialization.XmlArrayItemAttribute("optionCode", IsNullable = false)]
        public decimal[] pnrActions
        {
            get
            {
                return this.pnrActionsField;
            }
            set
            {
                this.pnrActionsField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("travellerInfo")]
        public PNR_AddMultiElementsTravellerInfo[] travellerInfo
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
        [System.Xml.Serialization.XmlElementAttribute("originDestinationDetails")]
        public PNR_AddMultiElementsOriginDestinationDetails[] originDestinationDetails
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
        public PNR_AddMultiElementsDataElementsMaster dataElementsMaster
        {
            get
            {
                return this.dataElementsMasterField;
            }
            set
            {
                this.dataElementsMasterField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRADD_10_1_1A")]
    public partial class PNR_AddMultiElementsReservationInfo
    {

        private PNR_AddMultiElementsReservationInfoReservation reservationField;

        /// <comentarios/>
        public PNR_AddMultiElementsReservationInfoReservation reservation
        {
            get
            {
                return this.reservationField;
            }
            set
            {
                this.reservationField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRADD_10_1_1A")]
    public partial class PNR_AddMultiElementsReservationInfoReservation
    {

        private string companyIdField;

        private string controlNumberField;

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
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRADD_10_1_1A")]
    public partial class PNR_AddMultiElementsTravellerInfo
    {

        private PNR_AddMultiElementsTravellerInfoElementManagementPassenger elementManagementPassengerField;

        private PNR_AddMultiElementsTravellerInfoPassengerData[] passengerDataField;

        /// <comentarios/>
        public PNR_AddMultiElementsTravellerInfoElementManagementPassenger elementManagementPassenger
        {
            get
            {
                return this.elementManagementPassengerField;
            }
            set
            {
                this.elementManagementPassengerField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("passengerData")]
        public PNR_AddMultiElementsTravellerInfoPassengerData[] passengerData
        {
            get
            {
                return this.passengerDataField;
            }
            set
            {
                this.passengerDataField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRADD_10_1_1A")]
    public partial class PNR_AddMultiElementsTravellerInfoElementManagementPassenger
    {

        private PNR_AddMultiElementsTravellerInfoElementManagementPassengerReference referenceField;

        private string segmentNameField;

        /// <comentarios/>
        public PNR_AddMultiElementsTravellerInfoElementManagementPassengerReference reference
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
        public string segmentName
        {
            get
            {
                return this.segmentNameField;
            }
            set
            {
                this.segmentNameField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRADD_10_1_1A")]
    public partial class PNR_AddMultiElementsTravellerInfoElementManagementPassengerReference
    {

        private string qualifierField;

        private string numberField;

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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRADD_10_1_1A")]
    public partial class PNR_AddMultiElementsTravellerInfoPassengerData
    {

        private PNR_AddMultiElementsTravellerInfoPassengerDataTravellerInformation travellerInformationField;

        private PNR_AddMultiElementsTravellerInfoPassengerDataDateOfBirth dateOfBirthField;

        /// <comentarios/>
        public PNR_AddMultiElementsTravellerInfoPassengerDataTravellerInformation travellerInformation
        {
            get
            {
                return this.travellerInformationField;
            }
            set
            {
                this.travellerInformationField = value;
            }
        }

        /// <comentarios/>
        public PNR_AddMultiElementsTravellerInfoPassengerDataDateOfBirth dateOfBirth
        {
            get
            {
                return this.dateOfBirthField;
            }
            set
            {
                this.dateOfBirthField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRADD_10_1_1A")]
    public partial class PNR_AddMultiElementsTravellerInfoPassengerDataTravellerInformation
    {

        private PNR_AddMultiElementsTravellerInfoPassengerDataTravellerInformationTraveller travellerField;

        private PNR_AddMultiElementsTravellerInfoPassengerDataTravellerInformationPassenger[] passengerField;

        /// <comentarios/>
        public PNR_AddMultiElementsTravellerInfoPassengerDataTravellerInformationTraveller traveller
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

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("passenger")]
        public PNR_AddMultiElementsTravellerInfoPassengerDataTravellerInformationPassenger[] passenger
        {
            get
            {
                return this.passengerField;
            }
            set
            {
                this.passengerField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRADD_10_1_1A")]
    public partial class PNR_AddMultiElementsTravellerInfoPassengerDataTravellerInformationTraveller
    {

        private string surnameField;

        private string qualifierField;

        private decimal quantityField;

        private bool quantityFieldSpecified;

        /// <comentarios/>
        public string surname
        {
            get
            {
                return this.surnameField;
            }
            set
            {
                this.surnameField = value;
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
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool quantitySpecified
        {
            get
            {
                return this.quantityFieldSpecified;
            }
            set
            {
                this.quantityFieldSpecified = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRADD_10_1_1A")]
    public partial class PNR_AddMultiElementsTravellerInfoPassengerDataTravellerInformationPassenger
    {

        private string firstNameField;

        private string typeField;

        private string infantIndicatorField;

        private string identificationCodeField;

        /// <comentarios/>
        public string firstName
        {
            get
            {
                return this.firstNameField;
            }
            set
            {
                this.firstNameField = value;
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRADD_10_1_1A")]
    public partial class PNR_AddMultiElementsTravellerInfoPassengerDataDateOfBirth
    {

        private PNR_AddMultiElementsTravellerInfoPassengerDataDateOfBirthDateAndTimeDetails dateAndTimeDetailsField;

        /// <comentarios/>
        public PNR_AddMultiElementsTravellerInfoPassengerDataDateOfBirthDateAndTimeDetails dateAndTimeDetails
        {
            get
            {
                return this.dateAndTimeDetailsField;
            }
            set
            {
                this.dateAndTimeDetailsField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRADD_10_1_1A")]
    public partial class PNR_AddMultiElementsTravellerInfoPassengerDataDateOfBirthDateAndTimeDetails
    {

        private string qualifierField;

        private string dateField;

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
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRADD_10_1_1A")]
    public partial class PNR_AddMultiElementsOriginDestinationDetails
    {

        private PNR_AddMultiElementsOriginDestinationDetailsOriginDestination originDestinationField;

        private PNR_AddMultiElementsOriginDestinationDetailsItineraryInfo[] itineraryInfoField;

        /// <comentarios/>
        public PNR_AddMultiElementsOriginDestinationDetailsOriginDestination originDestination
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
        [System.Xml.Serialization.XmlElementAttribute("itineraryInfo")]
        public PNR_AddMultiElementsOriginDestinationDetailsItineraryInfo[] itineraryInfo
        {
            get
            {
                return this.itineraryInfoField;
            }
            set
            {
                this.itineraryInfoField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRADD_10_1_1A")]
    public partial class PNR_AddMultiElementsOriginDestinationDetailsOriginDestination
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRADD_10_1_1A")]
    public partial class PNR_AddMultiElementsOriginDestinationDetailsItineraryInfo
    {

        private PNR_AddMultiElementsOriginDestinationDetailsItineraryInfoElementManagementItinerary elementManagementItineraryField;

        private PNR_AddMultiElementsOriginDestinationDetailsItineraryInfoAirAuxItinerary airAuxItineraryField;

        private PNR_AddMultiElementsOriginDestinationDetailsItineraryInfoReference[] referenceForSegmentField;

        /// <comentarios/>
        public PNR_AddMultiElementsOriginDestinationDetailsItineraryInfoElementManagementItinerary elementManagementItinerary
        {
            get
            {
                return this.elementManagementItineraryField;
            }
            set
            {
                this.elementManagementItineraryField = value;
            }
        }

        /// <comentarios/>
        public PNR_AddMultiElementsOriginDestinationDetailsItineraryInfoAirAuxItinerary airAuxItinerary
        {
            get
            {
                return this.airAuxItineraryField;
            }
            set
            {
                this.airAuxItineraryField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayItemAttribute("reference", IsNullable = false)]
        public PNR_AddMultiElementsOriginDestinationDetailsItineraryInfoReference[] referenceForSegment
        {
            get
            {
                return this.referenceForSegmentField;
            }
            set
            {
                this.referenceForSegmentField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRADD_10_1_1A")]
    public partial class PNR_AddMultiElementsOriginDestinationDetailsItineraryInfoElementManagementItinerary
    {

        private PNR_AddMultiElementsOriginDestinationDetailsItineraryInfoElementManagementItineraryReference referenceField;

        private string segmentNameField;

        /// <comentarios/>
        public PNR_AddMultiElementsOriginDestinationDetailsItineraryInfoElementManagementItineraryReference reference
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
        public string segmentName
        {
            get
            {
                return this.segmentNameField;
            }
            set
            {
                this.segmentNameField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRADD_10_1_1A")]
    public partial class PNR_AddMultiElementsOriginDestinationDetailsItineraryInfoElementManagementItineraryReference
    {

        private string qualifierField;

        private string numberField;

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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRADD_10_1_1A")]
    public partial class PNR_AddMultiElementsOriginDestinationDetailsItineraryInfoAirAuxItinerary
    {

        private PNR_AddMultiElementsOriginDestinationDetailsItineraryInfoAirAuxItineraryTravelProduct travelProductField;

        private PNR_AddMultiElementsOriginDestinationDetailsItineraryInfoAirAuxItineraryMessageAction messageActionField;

        private PNR_AddMultiElementsOriginDestinationDetailsItineraryInfoAirAuxItineraryRelatedProduct relatedProductField;

        private PNR_AddMultiElementsOriginDestinationDetailsItineraryInfoAirAuxItinerarySelection[] selectionDetailsAirField;

        private PNR_AddMultiElementsOriginDestinationDetailsItineraryInfoAirAuxItineraryReservationInfoSell reservationInfoSellField;

        private PNR_AddMultiElementsOriginDestinationDetailsItineraryInfoAirAuxItineraryFreetextItinerary freetextItineraryField;

        /// <comentarios/>
        public PNR_AddMultiElementsOriginDestinationDetailsItineraryInfoAirAuxItineraryTravelProduct travelProduct
        {
            get
            {
                return this.travelProductField;
            }
            set
            {
                this.travelProductField = value;
            }
        }

        /// <comentarios/>
        public PNR_AddMultiElementsOriginDestinationDetailsItineraryInfoAirAuxItineraryMessageAction messageAction
        {
            get
            {
                return this.messageActionField;
            }
            set
            {
                this.messageActionField = value;
            }
        }

        /// <comentarios/>
        public PNR_AddMultiElementsOriginDestinationDetailsItineraryInfoAirAuxItineraryRelatedProduct relatedProduct
        {
            get
            {
                return this.relatedProductField;
            }
            set
            {
                this.relatedProductField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayItemAttribute("selection", IsNullable = false)]
        public PNR_AddMultiElementsOriginDestinationDetailsItineraryInfoAirAuxItinerarySelection[] selectionDetailsAir
        {
            get
            {
                return this.selectionDetailsAirField;
            }
            set
            {
                this.selectionDetailsAirField = value;
            }
        }

        /// <comentarios/>
        public PNR_AddMultiElementsOriginDestinationDetailsItineraryInfoAirAuxItineraryReservationInfoSell reservationInfoSell
        {
            get
            {
                return this.reservationInfoSellField;
            }
            set
            {
                this.reservationInfoSellField = value;
            }
        }

        /// <comentarios/>
        public PNR_AddMultiElementsOriginDestinationDetailsItineraryInfoAirAuxItineraryFreetextItinerary freetextItinerary
        {
            get
            {
                return this.freetextItineraryField;
            }
            set
            {
                this.freetextItineraryField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRADD_10_1_1A")]
    public partial class PNR_AddMultiElementsOriginDestinationDetailsItineraryInfoAirAuxItineraryTravelProduct
    {

        private PNR_AddMultiElementsOriginDestinationDetailsItineraryInfoAirAuxItineraryTravelProductProduct productField;

        private PNR_AddMultiElementsOriginDestinationDetailsItineraryInfoAirAuxItineraryTravelProductBoardpointDetail boardpointDetailField;

        private PNR_AddMultiElementsOriginDestinationDetailsItineraryInfoAirAuxItineraryTravelProductOffpointDetail offpointDetailField;

        private PNR_AddMultiElementsOriginDestinationDetailsItineraryInfoAirAuxItineraryTravelProductCompany companyField;

        private PNR_AddMultiElementsOriginDestinationDetailsItineraryInfoAirAuxItineraryTravelProductProductDetails productDetailsField;

        private PNR_AddMultiElementsOriginDestinationDetailsItineraryInfoAirAuxItineraryTravelProductFlightTypeDetails flightTypeDetailsField;

        private string processingIndicatorField;

        /// <comentarios/>
        public PNR_AddMultiElementsOriginDestinationDetailsItineraryInfoAirAuxItineraryTravelProductProduct product
        {
            get
            {
                return this.productField;
            }
            set
            {
                this.productField = value;
            }
        }

        /// <comentarios/>
        public PNR_AddMultiElementsOriginDestinationDetailsItineraryInfoAirAuxItineraryTravelProductBoardpointDetail boardpointDetail
        {
            get
            {
                return this.boardpointDetailField;
            }
            set
            {
                this.boardpointDetailField = value;
            }
        }

        /// <comentarios/>
        public PNR_AddMultiElementsOriginDestinationDetailsItineraryInfoAirAuxItineraryTravelProductOffpointDetail offpointDetail
        {
            get
            {
                return this.offpointDetailField;
            }
            set
            {
                this.offpointDetailField = value;
            }
        }

        /// <comentarios/>
        public PNR_AddMultiElementsOriginDestinationDetailsItineraryInfoAirAuxItineraryTravelProductCompany company
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

        /// <comentarios/>
        public PNR_AddMultiElementsOriginDestinationDetailsItineraryInfoAirAuxItineraryTravelProductProductDetails productDetails
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

        /// <comentarios/>
        public PNR_AddMultiElementsOriginDestinationDetailsItineraryInfoAirAuxItineraryTravelProductFlightTypeDetails flightTypeDetails
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
        public string processingIndicator
        {
            get
            {
                return this.processingIndicatorField;
            }
            set
            {
                this.processingIndicatorField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRADD_10_1_1A")]
    public partial class PNR_AddMultiElementsOriginDestinationDetailsItineraryInfoAirAuxItineraryTravelProductProduct
    {

        private string depDateField;

        private string depTimeField;

        private string arrDateField;

        private string arrTimeField;

        /// <comentarios/>
        public string depDate
        {
            get
            {
                return this.depDateField;
            }
            set
            {
                this.depDateField = value;
            }
        }

        /// <comentarios/>
        public string depTime
        {
            get
            {
                return this.depTimeField;
            }
            set
            {
                this.depTimeField = value;
            }
        }

        /// <comentarios/>
        public string arrDate
        {
            get
            {
                return this.arrDateField;
            }
            set
            {
                this.arrDateField = value;
            }
        }

        /// <comentarios/>
        public string arrTime
        {
            get
            {
                return this.arrTimeField;
            }
            set
            {
                this.arrTimeField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRADD_10_1_1A")]
    public partial class PNR_AddMultiElementsOriginDestinationDetailsItineraryInfoAirAuxItineraryTravelProductBoardpointDetail
    {

        private string cityCodeField;

        private string cityNameField;

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
        public string cityName
        {
            get
            {
                return this.cityNameField;
            }
            set
            {
                this.cityNameField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRADD_10_1_1A")]
    public partial class PNR_AddMultiElementsOriginDestinationDetailsItineraryInfoAirAuxItineraryTravelProductOffpointDetail
    {

        private string cityCodeField;

        private string cityNameField;

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
        public string cityName
        {
            get
            {
                return this.cityNameField;
            }
            set
            {
                this.cityNameField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRADD_10_1_1A")]
    public partial class PNR_AddMultiElementsOriginDestinationDetailsItineraryInfoAirAuxItineraryTravelProductCompany
    {

        private string identificationField;

        private string secondIdentificationField;

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
        public string secondIdentification
        {
            get
            {
                return this.secondIdentificationField;
            }
            set
            {
                this.secondIdentificationField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRADD_10_1_1A")]
    public partial class PNR_AddMultiElementsOriginDestinationDetailsItineraryInfoAirAuxItineraryTravelProductProductDetails
    {

        private string identificationField;

        private string classOfServiceField;

        private string subtypeField;

        private string descriptionField;

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

        /// <comentarios/>
        public string subtype
        {
            get
            {
                return this.subtypeField;
            }
            set
            {
                this.subtypeField = value;
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRADD_10_1_1A")]
    public partial class PNR_AddMultiElementsOriginDestinationDetailsItineraryInfoAirAuxItineraryTravelProductFlightTypeDetails
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRADD_10_1_1A")]
    public partial class PNR_AddMultiElementsOriginDestinationDetailsItineraryInfoAirAuxItineraryMessageAction
    {

        private PNR_AddMultiElementsOriginDestinationDetailsItineraryInfoAirAuxItineraryMessageActionBusiness businessField;

        /// <comentarios/>
        public PNR_AddMultiElementsOriginDestinationDetailsItineraryInfoAirAuxItineraryMessageActionBusiness business
        {
            get
            {
                return this.businessField;
            }
            set
            {
                this.businessField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRADD_10_1_1A")]
    public partial class PNR_AddMultiElementsOriginDestinationDetailsItineraryInfoAirAuxItineraryMessageActionBusiness
    {

        private string functionField;

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
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRADD_10_1_1A")]
    public partial class PNR_AddMultiElementsOriginDestinationDetailsItineraryInfoAirAuxItineraryRelatedProduct
    {

        private decimal quantityField;

        private bool quantityFieldSpecified;

        private string statusField;

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
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool quantitySpecified
        {
            get
            {
                return this.quantityFieldSpecified;
            }
            set
            {
                this.quantityFieldSpecified = value;
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
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRADD_10_1_1A")]
    public partial class PNR_AddMultiElementsOriginDestinationDetailsItineraryInfoAirAuxItinerarySelection
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRADD_10_1_1A")]
    public partial class PNR_AddMultiElementsOriginDestinationDetailsItineraryInfoAirAuxItineraryReservationInfoSell
    {

        private PNR_AddMultiElementsOriginDestinationDetailsItineraryInfoAirAuxItineraryReservationInfoSellReservation reservationField;

        /// <comentarios/>
        public PNR_AddMultiElementsOriginDestinationDetailsItineraryInfoAirAuxItineraryReservationInfoSellReservation reservation
        {
            get
            {
                return this.reservationField;
            }
            set
            {
                this.reservationField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRADD_10_1_1A")]
    public partial class PNR_AddMultiElementsOriginDestinationDetailsItineraryInfoAirAuxItineraryReservationInfoSellReservation
    {

        private string companyIdField;

        private string controlNumberField;

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
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRADD_10_1_1A")]
    public partial class PNR_AddMultiElementsOriginDestinationDetailsItineraryInfoAirAuxItineraryFreetextItinerary
    {

        private PNR_AddMultiElementsOriginDestinationDetailsItineraryInfoAirAuxItineraryFreetextItineraryFreetextDetail freetextDetailField;

        private string longFreetextField;

        /// <comentarios/>
        public PNR_AddMultiElementsOriginDestinationDetailsItineraryInfoAirAuxItineraryFreetextItineraryFreetextDetail freetextDetail
        {
            get
            {
                return this.freetextDetailField;
            }
            set
            {
                this.freetextDetailField = value;
            }
        }

        /// <comentarios/>
        public string longFreetext
        {
            get
            {
                return this.longFreetextField;
            }
            set
            {
                this.longFreetextField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRADD_10_1_1A")]
    public partial class PNR_AddMultiElementsOriginDestinationDetailsItineraryInfoAirAuxItineraryFreetextItineraryFreetextDetail
    {

        private string subjectQualifierField;

        private string typeField;

        private string statusField;

        private string companyIdField;

        /// <comentarios/>
        public string subjectQualifier
        {
            get
            {
                return this.subjectQualifierField;
            }
            set
            {
                this.subjectQualifierField = value;
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
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRADD_10_1_1A")]
    public partial class PNR_AddMultiElementsOriginDestinationDetailsItineraryInfoReference
    {

        private string qualifierField;

        private string numberField;

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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRADD_10_1_1A")]
    public partial class PNR_AddMultiElementsDataElementsMaster
    {

        private PNR_AddMultiElementsDataElementsMasterMarker1 marker1Field;

        private PNR_AddMultiElementsDataElementsMasterDataElementsIndiv[] dataElementsIndivField;

        /// <comentarios/>
        public PNR_AddMultiElementsDataElementsMasterMarker1 marker1
        {
            get
            {
                return this.marker1Field;
            }
            set
            {
                this.marker1Field = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("dataElementsIndiv")]
        public PNR_AddMultiElementsDataElementsMasterDataElementsIndiv[] dataElementsIndiv
        {
            get
            {
                return this.dataElementsIndivField;
            }
            set
            {
                this.dataElementsIndivField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRADD_10_1_1A")]
    public partial class PNR_AddMultiElementsDataElementsMasterMarker1
    {
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRADD_10_1_1A")]
    public partial class PNR_AddMultiElementsDataElementsMasterDataElementsIndiv
    {

        private PNR_AddMultiElementsDataElementsMasterDataElementsIndivElementManagementData elementManagementDataField;

        private PNR_AddMultiElementsDataElementsMasterDataElementsIndivPnrSecurity pnrSecurityField;

        private PNR_AddMultiElementsDataElementsMasterDataElementsIndivAccounting accountingField;

        private PNR_AddMultiElementsDataElementsMasterDataElementsIndivMiscellaneousRemark miscellaneousRemarkField;

        private PNR_AddMultiElementsDataElementsMasterDataElementsIndivServiceRequest serviceRequestField;

        private PNR_AddMultiElementsDataElementsMasterDataElementsIndivDateAndTimeInformation dateAndTimeInformationField;

        private PNR_AddMultiElementsDataElementsMasterDataElementsIndivTourCode tourCodeField;

        private PNR_AddMultiElementsDataElementsMasterDataElementsIndivTicketElement ticketElementField;

        private PNR_AddMultiElementsDataElementsMasterDataElementsIndivFreetextData freetextDataField;

        private PNR_AddMultiElementsDataElementsMasterDataElementsIndivStructuredAddress structuredAddressField;

        private PNR_AddMultiElementsDataElementsMasterDataElementsIndivOptionElement optionElementField;

        private PNR_AddMultiElementsDataElementsMasterDataElementsIndivPrinter printerField;

        private PNR_AddMultiElementsDataElementsMasterDataElementsIndivSeatGroup seatGroupField;

        private PNR_AddMultiElementsDataElementsMasterDataElementsIndivFareElement fareElementField;

        private PNR_AddMultiElementsDataElementsMasterDataElementsIndivFareDiscount fareDiscountField;

        private PNR_AddMultiElementsDataElementsMasterDataElementsIndivManualFareDocument manualFareDocumentField;

        private PNR_AddMultiElementsDataElementsMasterDataElementsIndivCommission commissionField;

        private PNR_AddMultiElementsDataElementsMasterDataElementsIndivOriginalIssue originalIssueField;

        private PNR_AddMultiElementsDataElementsMasterDataElementsIndivFop[] formOfPaymentField;

        private PNR_AddMultiElementsDataElementsMasterDataElementsIndivFopExtension[] fopExtensionField;

        private PNR_AddMultiElementsDataElementsMasterDataElementsIndivServiceDetails[] serviceDetailsField;

        private PNR_AddMultiElementsDataElementsMasterDataElementsIndivFrequentTravellerVerification frequentTravellerVerificationField;

        private PNR_AddMultiElementsDataElementsMasterDataElementsIndivTicketingCarrier ticketingCarrierField;

        private PNR_AddMultiElementsDataElementsMasterDataElementsIndivFarePrintOverride farePrintOverrideField;

        private PNR_AddMultiElementsDataElementsMasterDataElementsIndivFrequentTravellerData frequentTravellerDataField;

        private PNR_AddMultiElementsDataElementsMasterDataElementsIndivSecurityDetails[] accessLevelField;

        private PNR_AddMultiElementsDataElementsMasterDataElementsIndivReference[] referenceForDataElementField;

        /// <comentarios/>
        public PNR_AddMultiElementsDataElementsMasterDataElementsIndivElementManagementData elementManagementData
        {
            get
            {
                return this.elementManagementDataField;
            }
            set
            {
                this.elementManagementDataField = value;
            }
        }

        /// <comentarios/>
        public PNR_AddMultiElementsDataElementsMasterDataElementsIndivPnrSecurity pnrSecurity
        {
            get
            {
                return this.pnrSecurityField;
            }
            set
            {
                this.pnrSecurityField = value;
            }
        }

        /// <comentarios/>
        public PNR_AddMultiElementsDataElementsMasterDataElementsIndivAccounting accounting
        {
            get
            {
                return this.accountingField;
            }
            set
            {
                this.accountingField = value;
            }
        }

        /// <comentarios/>
        public PNR_AddMultiElementsDataElementsMasterDataElementsIndivMiscellaneousRemark miscellaneousRemark
        {
            get
            {
                return this.miscellaneousRemarkField;
            }
            set
            {
                this.miscellaneousRemarkField = value;
            }
        }

        /// <comentarios/>
        public PNR_AddMultiElementsDataElementsMasterDataElementsIndivServiceRequest serviceRequest
        {
            get
            {
                return this.serviceRequestField;
            }
            set
            {
                this.serviceRequestField = value;
            }
        }

        /// <comentarios/>
        public PNR_AddMultiElementsDataElementsMasterDataElementsIndivDateAndTimeInformation dateAndTimeInformation
        {
            get
            {
                return this.dateAndTimeInformationField;
            }
            set
            {
                this.dateAndTimeInformationField = value;
            }
        }

        /// <comentarios/>
        public PNR_AddMultiElementsDataElementsMasterDataElementsIndivTourCode tourCode
        {
            get
            {
                return this.tourCodeField;
            }
            set
            {
                this.tourCodeField = value;
            }
        }

        /// <comentarios/>
        public PNR_AddMultiElementsDataElementsMasterDataElementsIndivTicketElement ticketElement
        {
            get
            {
                return this.ticketElementField;
            }
            set
            {
                this.ticketElementField = value;
            }
        }

        /// <comentarios/>
        public PNR_AddMultiElementsDataElementsMasterDataElementsIndivFreetextData freetextData
        {
            get
            {
                return this.freetextDataField;
            }
            set
            {
                this.freetextDataField = value;
            }
        }

        /// <comentarios/>
        public PNR_AddMultiElementsDataElementsMasterDataElementsIndivStructuredAddress structuredAddress
        {
            get
            {
                return this.structuredAddressField;
            }
            set
            {
                this.structuredAddressField = value;
            }
        }

        /// <comentarios/>
        public PNR_AddMultiElementsDataElementsMasterDataElementsIndivOptionElement optionElement
        {
            get
            {
                return this.optionElementField;
            }
            set
            {
                this.optionElementField = value;
            }
        }

        /// <comentarios/>
        public PNR_AddMultiElementsDataElementsMasterDataElementsIndivPrinter printer
        {
            get
            {
                return this.printerField;
            }
            set
            {
                this.printerField = value;
            }
        }

        /// <comentarios/>
        public PNR_AddMultiElementsDataElementsMasterDataElementsIndivSeatGroup seatGroup
        {
            get
            {
                return this.seatGroupField;
            }
            set
            {
                this.seatGroupField = value;
            }
        }

        /// <comentarios/>
        public PNR_AddMultiElementsDataElementsMasterDataElementsIndivFareElement fareElement
        {
            get
            {
                return this.fareElementField;
            }
            set
            {
                this.fareElementField = value;
            }
        }

        /// <comentarios/>
        public PNR_AddMultiElementsDataElementsMasterDataElementsIndivFareDiscount fareDiscount
        {
            get
            {
                return this.fareDiscountField;
            }
            set
            {
                this.fareDiscountField = value;
            }
        }

        /// <comentarios/>
        public PNR_AddMultiElementsDataElementsMasterDataElementsIndivManualFareDocument manualFareDocument
        {
            get
            {
                return this.manualFareDocumentField;
            }
            set
            {
                this.manualFareDocumentField = value;
            }
        }

        /// <comentarios/>
        public PNR_AddMultiElementsDataElementsMasterDataElementsIndivCommission commission
        {
            get
            {
                return this.commissionField;
            }
            set
            {
                this.commissionField = value;
            }
        }

        /// <comentarios/>
        public PNR_AddMultiElementsDataElementsMasterDataElementsIndivOriginalIssue originalIssue
        {
            get
            {
                return this.originalIssueField;
            }
            set
            {
                this.originalIssueField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayItemAttribute("fop", IsNullable = false)]
        public PNR_AddMultiElementsDataElementsMasterDataElementsIndivFop[] formOfPayment
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
        [System.Xml.Serialization.XmlElementAttribute("fopExtension")]
        public PNR_AddMultiElementsDataElementsMasterDataElementsIndivFopExtension[] fopExtension
        {
            get
            {
                return this.fopExtensionField;
            }
            set
            {
                this.fopExtensionField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("serviceDetails")]
        public PNR_AddMultiElementsDataElementsMasterDataElementsIndivServiceDetails[] serviceDetails
        {
            get
            {
                return this.serviceDetailsField;
            }
            set
            {
                this.serviceDetailsField = value;
            }
        }

        /// <comentarios/>
        public PNR_AddMultiElementsDataElementsMasterDataElementsIndivFrequentTravellerVerification frequentTravellerVerification
        {
            get
            {
                return this.frequentTravellerVerificationField;
            }
            set
            {
                this.frequentTravellerVerificationField = value;
            }
        }

        /// <comentarios/>
        public PNR_AddMultiElementsDataElementsMasterDataElementsIndivTicketingCarrier ticketingCarrier
        {
            get
            {
                return this.ticketingCarrierField;
            }
            set
            {
                this.ticketingCarrierField = value;
            }
        }

        /// <comentarios/>
        public PNR_AddMultiElementsDataElementsMasterDataElementsIndivFarePrintOverride farePrintOverride
        {
            get
            {
                return this.farePrintOverrideField;
            }
            set
            {
                this.farePrintOverrideField = value;
            }
        }

        /// <comentarios/>
        public PNR_AddMultiElementsDataElementsMasterDataElementsIndivFrequentTravellerData frequentTravellerData
        {
            get
            {
                return this.frequentTravellerDataField;
            }
            set
            {
                this.frequentTravellerDataField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayItemAttribute("securityDetails", IsNullable = false)]
        public PNR_AddMultiElementsDataElementsMasterDataElementsIndivSecurityDetails[] accessLevel
        {
            get
            {
                return this.accessLevelField;
            }
            set
            {
                this.accessLevelField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayItemAttribute("reference", IsNullable = false)]
        public PNR_AddMultiElementsDataElementsMasterDataElementsIndivReference[] referenceForDataElement
        {
            get
            {
                return this.referenceForDataElementField;
            }
            set
            {
                this.referenceForDataElementField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRADD_10_1_1A")]
    public partial class PNR_AddMultiElementsDataElementsMasterDataElementsIndivElementManagementData
    {

        private PNR_AddMultiElementsDataElementsMasterDataElementsIndivElementManagementDataReference referenceField;

        private string segmentNameField;

        /// <comentarios/>
        public PNR_AddMultiElementsDataElementsMasterDataElementsIndivElementManagementDataReference reference
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
        public string segmentName
        {
            get
            {
                return this.segmentNameField;
            }
            set
            {
                this.segmentNameField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRADD_10_1_1A")]
    public partial class PNR_AddMultiElementsDataElementsMasterDataElementsIndivElementManagementDataReference
    {

        private string qualifierField;

        private string numberField;

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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRADD_10_1_1A")]
    public partial class PNR_AddMultiElementsDataElementsMasterDataElementsIndivPnrSecurity
    {

        private PNR_AddMultiElementsDataElementsMasterDataElementsIndivPnrSecuritySecurity[] securityField;

        private PNR_AddMultiElementsDataElementsMasterDataElementsIndivPnrSecuritySecurityInfo securityInfoField;

        private string indicatorField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("security")]
        public PNR_AddMultiElementsDataElementsMasterDataElementsIndivPnrSecuritySecurity[] security
        {
            get
            {
                return this.securityField;
            }
            set
            {
                this.securityField = value;
            }
        }

        /// <comentarios/>
        public PNR_AddMultiElementsDataElementsMasterDataElementsIndivPnrSecuritySecurityInfo securityInfo
        {
            get
            {
                return this.securityInfoField;
            }
            set
            {
                this.securityInfoField = value;
            }
        }

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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRADD_10_1_1A")]
    public partial class PNR_AddMultiElementsDataElementsMasterDataElementsIndivPnrSecuritySecurity
    {

        private string identificationField;

        private string accessModeField;

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
        public string accessMode
        {
            get
            {
                return this.accessModeField;
            }
            set
            {
                this.accessModeField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRADD_10_1_1A")]
    public partial class PNR_AddMultiElementsDataElementsMasterDataElementsIndivPnrSecuritySecurityInfo
    {

        private string creationDateField;

        private string agentCodeField;

        private string officeIdField;

        /// <comentarios/>
        public string creationDate
        {
            get
            {
                return this.creationDateField;
            }
            set
            {
                this.creationDateField = value;
            }
        }

        /// <comentarios/>
        public string agentCode
        {
            get
            {
                return this.agentCodeField;
            }
            set
            {
                this.agentCodeField = value;
            }
        }

        /// <comentarios/>
        public string officeId
        {
            get
            {
                return this.officeIdField;
            }
            set
            {
                this.officeIdField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRADD_10_1_1A")]
    public partial class PNR_AddMultiElementsDataElementsMasterDataElementsIndivAccounting
    {

        private PNR_AddMultiElementsDataElementsMasterDataElementsIndivAccountingAccount accountField;

        private string accountNumberOfUnitsField;

        /// <comentarios/>
        public PNR_AddMultiElementsDataElementsMasterDataElementsIndivAccountingAccount account
        {
            get
            {
                return this.accountField;
            }
            set
            {
                this.accountField = value;
            }
        }

        /// <comentarios/>
        public string accountNumberOfUnits
        {
            get
            {
                return this.accountNumberOfUnitsField;
            }
            set
            {
                this.accountNumberOfUnitsField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRADD_10_1_1A")]
    public partial class PNR_AddMultiElementsDataElementsMasterDataElementsIndivAccountingAccount
    {

        private string numberField;

        private string costNumberField;

        private string companyNumberField;

        private string clientReferenceField;

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
        public string costNumber
        {
            get
            {
                return this.costNumberField;
            }
            set
            {
                this.costNumberField = value;
            }
        }

        /// <comentarios/>
        public string companyNumber
        {
            get
            {
                return this.companyNumberField;
            }
            set
            {
                this.companyNumberField = value;
            }
        }

        /// <comentarios/>
        public string clientReference
        {
            get
            {
                return this.clientReferenceField;
            }
            set
            {
                this.clientReferenceField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRADD_10_1_1A")]
    public partial class PNR_AddMultiElementsDataElementsMasterDataElementsIndivMiscellaneousRemark
    {

        private PNR_AddMultiElementsDataElementsMasterDataElementsIndivMiscellaneousRemarkRemarks remarksField;

        /// <comentarios/>
        public PNR_AddMultiElementsDataElementsMasterDataElementsIndivMiscellaneousRemarkRemarks remarks
        {
            get
            {
                return this.remarksField;
            }
            set
            {
                this.remarksField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRADD_10_1_1A")]
    public partial class PNR_AddMultiElementsDataElementsMasterDataElementsIndivMiscellaneousRemarkRemarks
    {

        private string typeField;

        private string categoryField;

        private string freetextField;

        private string providerTypeField;

        private string currencyField;

        private decimal amountField;

        private bool amountFieldSpecified;

        private string[] officeIdField;

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
        public string freetext
        {
            get
            {
                return this.freetextField;
            }
            set
            {
                this.freetextField = value;
            }
        }

        /// <comentarios/>
        public string providerType
        {
            get
            {
                return this.providerTypeField;
            }
            set
            {
                this.providerTypeField = value;
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
        [System.Xml.Serialization.XmlElementAttribute("officeId")]
        public string[] officeId
        {
            get
            {
                return this.officeIdField;
            }
            set
            {
                this.officeIdField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRADD_10_1_1A")]
    public partial class PNR_AddMultiElementsDataElementsMasterDataElementsIndivServiceRequest
    {

        private PNR_AddMultiElementsDataElementsMasterDataElementsIndivServiceRequestSsr ssrField;

        private PNR_AddMultiElementsDataElementsMasterDataElementsIndivServiceRequestSsrb[] ssrbField;

        /// <comentarios/>
        public PNR_AddMultiElementsDataElementsMasterDataElementsIndivServiceRequestSsr ssr
        {
            get
            {
                return this.ssrField;
            }
            set
            {
                this.ssrField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("ssrb")]
        public PNR_AddMultiElementsDataElementsMasterDataElementsIndivServiceRequestSsrb[] ssrb
        {
            get
            {
                return this.ssrbField;
            }
            set
            {
                this.ssrbField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRADD_10_1_1A")]
    public partial class PNR_AddMultiElementsDataElementsMasterDataElementsIndivServiceRequestSsr
    {

        private string typeField;

        private string statusField;

        private decimal quantityField;

        private bool quantityFieldSpecified;

        private string companyIdField;

        private string indicatorField;

        private string boardpointField;

        private string offpointField;

        private string[] freetextField;

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
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool quantitySpecified
        {
            get
            {
                return this.quantityFieldSpecified;
            }
            set
            {
                this.quantityFieldSpecified = value;
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

        /// <comentarios/>
        public string boardpoint
        {
            get
            {
                return this.boardpointField;
            }
            set
            {
                this.boardpointField = value;
            }
        }

        /// <comentarios/>
        public string offpoint
        {
            get
            {
                return this.offpointField;
            }
            set
            {
                this.offpointField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("freetext")]
        public string[] freetext
        {
            get
            {
                return this.freetextField;
            }
            set
            {
                this.freetextField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRADD_10_1_1A")]
    public partial class PNR_AddMultiElementsDataElementsMasterDataElementsIndivServiceRequestSsrb
    {

        private string dataField;

        private string[] seatTypeField;

        /// <comentarios/>
        public string data
        {
            get
            {
                return this.dataField;
            }
            set
            {
                this.dataField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("seatType")]
        public string[] seatType
        {
            get
            {
                return this.seatTypeField;
            }
            set
            {
                this.seatTypeField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRADD_10_1_1A")]
    public partial class PNR_AddMultiElementsDataElementsMasterDataElementsIndivDateAndTimeInformation
    {

        private PNR_AddMultiElementsDataElementsMasterDataElementsIndivDateAndTimeInformationDateAndTime dateAndTimeField;

        /// <comentarios/>
        public PNR_AddMultiElementsDataElementsMasterDataElementsIndivDateAndTimeInformationDateAndTime dateAndTime
        {
            get
            {
                return this.dateAndTimeField;
            }
            set
            {
                this.dateAndTimeField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRADD_10_1_1A")]
    public partial class PNR_AddMultiElementsDataElementsMasterDataElementsIndivDateAndTimeInformationDateAndTime
    {

        private string firstDateField;

        private string movementTypeField;

        private string locationIdentificationField;

        /// <comentarios/>
        public string firstDate
        {
            get
            {
                return this.firstDateField;
            }
            set
            {
                this.firstDateField = value;
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
        public string locationIdentification
        {
            get
            {
                return this.locationIdentificationField;
            }
            set
            {
                this.locationIdentificationField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRADD_10_1_1A")]
    public partial class PNR_AddMultiElementsDataElementsMasterDataElementsIndivTourCode
    {

        private string passengerTypeField;

        private PNR_AddMultiElementsDataElementsMasterDataElementsIndivTourCodeFormatedTour formatedTourField;

        private PNR_AddMultiElementsDataElementsMasterDataElementsIndivTourCodeNetRemit netRemitField;

        private PNR_AddMultiElementsDataElementsMasterDataElementsIndivTourCodeFreeFormatTour freeFormatTourField;

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
        public PNR_AddMultiElementsDataElementsMasterDataElementsIndivTourCodeFormatedTour formatedTour
        {
            get
            {
                return this.formatedTourField;
            }
            set
            {
                this.formatedTourField = value;
            }
        }

        /// <comentarios/>
        public PNR_AddMultiElementsDataElementsMasterDataElementsIndivTourCodeNetRemit netRemit
        {
            get
            {
                return this.netRemitField;
            }
            set
            {
                this.netRemitField = value;
            }
        }

        /// <comentarios/>
        public PNR_AddMultiElementsDataElementsMasterDataElementsIndivTourCodeFreeFormatTour freeFormatTour
        {
            get
            {
                return this.freeFormatTourField;
            }
            set
            {
                this.freeFormatTourField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRADD_10_1_1A")]
    public partial class PNR_AddMultiElementsDataElementsMasterDataElementsIndivTourCodeFormatedTour
    {

        private string productIdField;

        private string yearField;

        private string companyIdField;

        private string approvalCodeField;

        private string partyIdField;

        /// <comentarios/>
        public string productId
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
        public string approvalCode
        {
            get
            {
                return this.approvalCodeField;
            }
            set
            {
                this.approvalCodeField = value;
            }
        }

        /// <comentarios/>
        public string partyId
        {
            get
            {
                return this.partyIdField;
            }
            set
            {
                this.partyIdField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRADD_10_1_1A")]
    public partial class PNR_AddMultiElementsDataElementsMasterDataElementsIndivTourCodeNetRemit
    {

        private string indicatorField;

        private string freetextField;

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

        /// <comentarios/>
        public string freetext
        {
            get
            {
                return this.freetextField;
            }
            set
            {
                this.freetextField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRADD_10_1_1A")]
    public partial class PNR_AddMultiElementsDataElementsMasterDataElementsIndivTourCodeFreeFormatTour
    {

        private string indicatorField;

        private string freetextField;

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

        /// <comentarios/>
        public string freetext
        {
            get
            {
                return this.freetextField;
            }
            set
            {
                this.freetextField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRADD_10_1_1A")]
    public partial class PNR_AddMultiElementsDataElementsMasterDataElementsIndivTicketElement
    {

        private string passengerTypeField;

        private PNR_AddMultiElementsDataElementsMasterDataElementsIndivTicketElementTicket ticketField;

        private string printOptionsField;

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
        public PNR_AddMultiElementsDataElementsMasterDataElementsIndivTicketElementTicket ticket
        {
            get
            {
                return this.ticketField;
            }
            set
            {
                this.ticketField = value;
            }
        }

        /// <comentarios/>
        public string printOptions
        {
            get
            {
                return this.printOptionsField;
            }
            set
            {
                this.printOptionsField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRADD_10_1_1A")]
    public partial class PNR_AddMultiElementsDataElementsMasterDataElementsIndivTicketElementTicket
    {

        private string indicatorField;

        private string dateField;

        private string timeField;

        private string officeIdField;

        private string freetextField;

        private string airlineCodeField;

        private string queueNumberField;

        private string queueCategoryField;

        private string[] sitaAddressField;

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
        public string officeId
        {
            get
            {
                return this.officeIdField;
            }
            set
            {
                this.officeIdField = value;
            }
        }

        /// <comentarios/>
        public string freetext
        {
            get
            {
                return this.freetextField;
            }
            set
            {
                this.freetextField = value;
            }
        }

        /// <comentarios/>
        public string airlineCode
        {
            get
            {
                return this.airlineCodeField;
            }
            set
            {
                this.airlineCodeField = value;
            }
        }

        /// <comentarios/>
        public string queueNumber
        {
            get
            {
                return this.queueNumberField;
            }
            set
            {
                this.queueNumberField = value;
            }
        }

        /// <comentarios/>
        public string queueCategory
        {
            get
            {
                return this.queueCategoryField;
            }
            set
            {
                this.queueCategoryField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("sitaAddress")]
        public string[] sitaAddress
        {
            get
            {
                return this.sitaAddressField;
            }
            set
            {
                this.sitaAddressField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRADD_10_1_1A")]
    public partial class PNR_AddMultiElementsDataElementsMasterDataElementsIndivFreetextData
    {

        private PNR_AddMultiElementsDataElementsMasterDataElementsIndivFreetextDataFreetextDetail freetextDetailField;

        private string longFreetextField;

        /// <comentarios/>
        public PNR_AddMultiElementsDataElementsMasterDataElementsIndivFreetextDataFreetextDetail freetextDetail
        {
            get
            {
                return this.freetextDetailField;
            }
            set
            {
                this.freetextDetailField = value;
            }
        }

        /// <comentarios/>
        public string longFreetext
        {
            get
            {
                return this.longFreetextField;
            }
            set
            {
                this.longFreetextField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRADD_10_1_1A")]
    public partial class PNR_AddMultiElementsDataElementsMasterDataElementsIndivFreetextDataFreetextDetail
    {

        private string subjectQualifierField;

        private string typeField;

        private string statusField;

        private string companyIdField;

        /// <comentarios/>
        public string subjectQualifier
        {
            get
            {
                return this.subjectQualifierField;
            }
            set
            {
                this.subjectQualifierField = value;
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
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRADD_10_1_1A")]
    public partial class PNR_AddMultiElementsDataElementsMasterDataElementsIndivStructuredAddress
    {

        private string informationTypeField;

        private PNR_AddMultiElementsDataElementsMasterDataElementsIndivStructuredAddressAddress addressField;

        private PNR_AddMultiElementsDataElementsMasterDataElementsIndivStructuredAddressOptionalData[] optionalDataField;

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
        public PNR_AddMultiElementsDataElementsMasterDataElementsIndivStructuredAddressAddress address
        {
            get
            {
                return this.addressField;
            }
            set
            {
                this.addressField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("optionalData")]
        public PNR_AddMultiElementsDataElementsMasterDataElementsIndivStructuredAddressOptionalData[] optionalData
        {
            get
            {
                return this.optionalDataField;
            }
            set
            {
                this.optionalDataField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRADD_10_1_1A")]
    public partial class PNR_AddMultiElementsDataElementsMasterDataElementsIndivStructuredAddressAddress
    {

        private string optionA1Field;

        private string optionTextA1Field;

        /// <comentarios/>
        public string optionA1
        {
            get
            {
                return this.optionA1Field;
            }
            set
            {
                this.optionA1Field = value;
            }
        }

        /// <comentarios/>
        public string optionTextA1
        {
            get
            {
                return this.optionTextA1Field;
            }
            set
            {
                this.optionTextA1Field = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRADD_10_1_1A")]
    public partial class PNR_AddMultiElementsDataElementsMasterDataElementsIndivStructuredAddressOptionalData
    {

        private string optionField;

        private string optionTextField;

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
        public string optionText
        {
            get
            {
                return this.optionTextField;
            }
            set
            {
                this.optionTextField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRADD_10_1_1A")]
    public partial class PNR_AddMultiElementsDataElementsMasterDataElementsIndivOptionElement
    {

        private PNR_AddMultiElementsDataElementsMasterDataElementsIndivOptionElementOptionDetail optionDetailField;

        /// <comentarios/>
        public PNR_AddMultiElementsDataElementsMasterDataElementsIndivOptionElementOptionDetail optionDetail
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
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRADD_10_1_1A")]
    public partial class PNR_AddMultiElementsDataElementsMasterDataElementsIndivOptionElementOptionDetail
    {

        private string officeIdField;

        private string dateField;

        private decimal queueField;

        private bool queueFieldSpecified;

        private decimal categoryField;

        private bool categoryFieldSpecified;

        private string freetextField;

        /// <comentarios/>
        public string officeId
        {
            get
            {
                return this.officeIdField;
            }
            set
            {
                this.officeIdField = value;
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
        public decimal queue
        {
            get
            {
                return this.queueField;
            }
            set
            {
                this.queueField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool queueSpecified
        {
            get
            {
                return this.queueFieldSpecified;
            }
            set
            {
                this.queueFieldSpecified = value;
            }
        }

        /// <comentarios/>
        public decimal category
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
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool categorySpecified
        {
            get
            {
                return this.categoryFieldSpecified;
            }
            set
            {
                this.categoryFieldSpecified = value;
            }
        }

        /// <comentarios/>
        public string freetext
        {
            get
            {
                return this.freetextField;
            }
            set
            {
                this.freetextField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRADD_10_1_1A")]
    public partial class PNR_AddMultiElementsDataElementsMasterDataElementsIndivPrinter
    {

        private PNR_AddMultiElementsDataElementsMasterDataElementsIndivPrinterIdentifierDetail identifierDetailField;

        private string officeField;

        private string teletypeAddressField;

        /// <comentarios/>
        public PNR_AddMultiElementsDataElementsMasterDataElementsIndivPrinterIdentifierDetail identifierDetail
        {
            get
            {
                return this.identifierDetailField;
            }
            set
            {
                this.identifierDetailField = value;
            }
        }

        /// <comentarios/>
        public string office
        {
            get
            {
                return this.officeField;
            }
            set
            {
                this.officeField = value;
            }
        }

        /// <comentarios/>
        public string teletypeAddress
        {
            get
            {
                return this.teletypeAddressField;
            }
            set
            {
                this.teletypeAddressField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRADD_10_1_1A")]
    public partial class PNR_AddMultiElementsDataElementsMasterDataElementsIndivPrinterIdentifierDetail
    {

        private string nameField;

        private string networkField;

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
        public string network
        {
            get
            {
                return this.networkField;
            }
            set
            {
                this.networkField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRADD_10_1_1A")]
    public partial class PNR_AddMultiElementsDataElementsMasterDataElementsIndivSeatGroup
    {

        private PNR_AddMultiElementsDataElementsMasterDataElementsIndivSeatGroupSeatRequest seatRequestField;

        private PNR_AddMultiElementsDataElementsMasterDataElementsIndivSeatGroupRailSeatReferenceInformation[] railSeatReferenceInformationField;

        private PNR_AddMultiElementsDataElementsMasterDataElementsIndivSeatGroupRailSeatPreferences railSeatPreferencesField;

        /// <comentarios/>
        public PNR_AddMultiElementsDataElementsMasterDataElementsIndivSeatGroupSeatRequest seatRequest
        {
            get
            {
                return this.seatRequestField;
            }
            set
            {
                this.seatRequestField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("railSeatReferenceInformation")]
        public PNR_AddMultiElementsDataElementsMasterDataElementsIndivSeatGroupRailSeatReferenceInformation[] railSeatReferenceInformation
        {
            get
            {
                return this.railSeatReferenceInformationField;
            }
            set
            {
                this.railSeatReferenceInformationField = value;
            }
        }

        /// <comentarios/>
        public PNR_AddMultiElementsDataElementsMasterDataElementsIndivSeatGroupRailSeatPreferences railSeatPreferences
        {
            get
            {
                return this.railSeatPreferencesField;
            }
            set
            {
                this.railSeatPreferencesField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRADD_10_1_1A")]
    public partial class PNR_AddMultiElementsDataElementsMasterDataElementsIndivSeatGroupSeatRequest
    {

        private PNR_AddMultiElementsDataElementsMasterDataElementsIndivSeatGroupSeatRequestSeat seatField;

        private PNR_AddMultiElementsDataElementsMasterDataElementsIndivSeatGroupSeatRequestSpecial[] specialField;

        /// <comentarios/>
        public PNR_AddMultiElementsDataElementsMasterDataElementsIndivSeatGroupSeatRequestSeat seat
        {
            get
            {
                return this.seatField;
            }
            set
            {
                this.seatField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("special")]
        public PNR_AddMultiElementsDataElementsMasterDataElementsIndivSeatGroupSeatRequestSpecial[] special
        {
            get
            {
                return this.specialField;
            }
            set
            {
                this.specialField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRADD_10_1_1A")]
    public partial class PNR_AddMultiElementsDataElementsMasterDataElementsIndivSeatGroupSeatRequestSeat
    {

        private string qualifierField;

        private string typeField;

        private string boardpointField;

        private string offpointField;

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
        public string boardpoint
        {
            get
            {
                return this.boardpointField;
            }
            set
            {
                this.boardpointField = value;
            }
        }

        /// <comentarios/>
        public string offpoint
        {
            get
            {
                return this.offpointField;
            }
            set
            {
                this.offpointField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRADD_10_1_1A")]
    public partial class PNR_AddMultiElementsDataElementsMasterDataElementsIndivSeatGroupSeatRequestSpecial
    {

        private string dataField;

        private string[] seatTypeField;

        /// <comentarios/>
        public string data
        {
            get
            {
                return this.dataField;
            }
            set
            {
                this.dataField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("seatType")]
        public string[] seatType
        {
            get
            {
                return this.seatTypeField;
            }
            set
            {
                this.seatTypeField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRADD_10_1_1A")]
    public partial class PNR_AddMultiElementsDataElementsMasterDataElementsIndivSeatGroupRailSeatReferenceInformation
    {

        private PNR_AddMultiElementsDataElementsMasterDataElementsIndivSeatGroupRailSeatReferenceInformationRailSeatReferenceDetails railSeatReferenceDetailsField;

        /// <comentarios/>
        public PNR_AddMultiElementsDataElementsMasterDataElementsIndivSeatGroupRailSeatReferenceInformationRailSeatReferenceDetails railSeatReferenceDetails
        {
            get
            {
                return this.railSeatReferenceDetailsField;
            }
            set
            {
                this.railSeatReferenceDetailsField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRADD_10_1_1A")]
    public partial class PNR_AddMultiElementsDataElementsMasterDataElementsIndivSeatGroupRailSeatReferenceInformationRailSeatReferenceDetails
    {

        private string coachNumberField;

        private string deckNumberField;

        private string seatNumberField;

        /// <comentarios/>
        public string coachNumber
        {
            get
            {
                return this.coachNumberField;
            }
            set
            {
                this.coachNumberField = value;
            }
        }

        /// <comentarios/>
        public string deckNumber
        {
            get
            {
                return this.deckNumberField;
            }
            set
            {
                this.deckNumberField = value;
            }
        }

        /// <comentarios/>
        public string seatNumber
        {
            get
            {
                return this.seatNumberField;
            }
            set
            {
                this.seatNumberField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRADD_10_1_1A")]
    public partial class PNR_AddMultiElementsDataElementsMasterDataElementsIndivSeatGroupRailSeatPreferences
    {

        private string seatRequestFunctionField;

        private string smokingIndicatorField;

        private PNR_AddMultiElementsDataElementsMasterDataElementsIndivSeatGroupRailSeatPreferencesClassDetails classDetailsField;

        private PNR_AddMultiElementsDataElementsMasterDataElementsIndivSeatGroupRailSeatPreferencesSeatConfiguration seatConfigurationField;

        /// <comentarios/>
        public string seatRequestFunction
        {
            get
            {
                return this.seatRequestFunctionField;
            }
            set
            {
                this.seatRequestFunctionField = value;
            }
        }

        /// <comentarios/>
        public string smokingIndicator
        {
            get
            {
                return this.smokingIndicatorField;
            }
            set
            {
                this.smokingIndicatorField = value;
            }
        }

        /// <comentarios/>
        public PNR_AddMultiElementsDataElementsMasterDataElementsIndivSeatGroupRailSeatPreferencesClassDetails classDetails
        {
            get
            {
                return this.classDetailsField;
            }
            set
            {
                this.classDetailsField = value;
            }
        }

        /// <comentarios/>
        public PNR_AddMultiElementsDataElementsMasterDataElementsIndivSeatGroupRailSeatPreferencesSeatConfiguration seatConfiguration
        {
            get
            {
                return this.seatConfigurationField;
            }
            set
            {
                this.seatConfigurationField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRADD_10_1_1A")]
    public partial class PNR_AddMultiElementsDataElementsMasterDataElementsIndivSeatGroupRailSeatPreferencesClassDetails
    {

        private string codeField;

        private string bookingClassField;

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
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRADD_10_1_1A")]
    public partial class PNR_AddMultiElementsDataElementsMasterDataElementsIndivSeatGroupRailSeatPreferencesSeatConfiguration
    {

        private string seatSpaceField;

        private string coachTypeField;

        private string seatEquipmentField;

        private string seatPositionField;

        private string seatDirectionField;

        private string seatDeckField;

        private string[] specialPassengerTypeField;

        /// <comentarios/>
        public string seatSpace
        {
            get
            {
                return this.seatSpaceField;
            }
            set
            {
                this.seatSpaceField = value;
            }
        }

        /// <comentarios/>
        public string coachType
        {
            get
            {
                return this.coachTypeField;
            }
            set
            {
                this.coachTypeField = value;
            }
        }

        /// <comentarios/>
        public string seatEquipment
        {
            get
            {
                return this.seatEquipmentField;
            }
            set
            {
                this.seatEquipmentField = value;
            }
        }

        /// <comentarios/>
        public string seatPosition
        {
            get
            {
                return this.seatPositionField;
            }
            set
            {
                this.seatPositionField = value;
            }
        }

        /// <comentarios/>
        public string seatDirection
        {
            get
            {
                return this.seatDirectionField;
            }
            set
            {
                this.seatDirectionField = value;
            }
        }

        /// <comentarios/>
        public string seatDeck
        {
            get
            {
                return this.seatDeckField;
            }
            set
            {
                this.seatDeckField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("specialPassengerType")]
        public string[] specialPassengerType
        {
            get
            {
                return this.specialPassengerTypeField;
            }
            set
            {
                this.specialPassengerTypeField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRADD_10_1_1A")]
    public partial class PNR_AddMultiElementsDataElementsMasterDataElementsIndivFareElement
    {

        private string generalIndicatorField;

        private string passengerTypeField;

        private string[] officeIdField;

        private string freetextLongField;

        /// <comentarios/>
        public string generalIndicator
        {
            get
            {
                return this.generalIndicatorField;
            }
            set
            {
                this.generalIndicatorField = value;
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
        [System.Xml.Serialization.XmlElementAttribute("officeId")]
        public string[] officeId
        {
            get
            {
                return this.officeIdField;
            }
            set
            {
                this.officeIdField = value;
            }
        }

        /// <comentarios/>
        public string freetextLong
        {
            get
            {
                return this.freetextLongField;
            }
            set
            {
                this.freetextLongField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRADD_10_1_1A")]
    public partial class PNR_AddMultiElementsDataElementsMasterDataElementsIndivFareDiscount
    {

        private string passengerTypeField;

        private PNR_AddMultiElementsDataElementsMasterDataElementsIndivFareDiscountDiscount[] discountField;

        private string birthDateField;

        private PNR_AddMultiElementsDataElementsMasterDataElementsIndivFareDiscountNumberDetail numberDetailField;

        private PNR_AddMultiElementsDataElementsMasterDataElementsIndivFareDiscountRpInformation rpInformationField;

        private PNR_AddMultiElementsDataElementsMasterDataElementsIndivFareDiscountCustomer customerField;

        private PNR_AddMultiElementsDataElementsMasterDataElementsIndivFareDiscountResidentDisc residentDiscField;

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
        [System.Xml.Serialization.XmlElementAttribute("discount")]
        public PNR_AddMultiElementsDataElementsMasterDataElementsIndivFareDiscountDiscount[] discount
        {
            get
            {
                return this.discountField;
            }
            set
            {
                this.discountField = value;
            }
        }

        /// <comentarios/>
        public string birthDate
        {
            get
            {
                return this.birthDateField;
            }
            set
            {
                this.birthDateField = value;
            }
        }

        /// <comentarios/>
        public PNR_AddMultiElementsDataElementsMasterDataElementsIndivFareDiscountNumberDetail numberDetail
        {
            get
            {
                return this.numberDetailField;
            }
            set
            {
                this.numberDetailField = value;
            }
        }

        /// <comentarios/>
        public PNR_AddMultiElementsDataElementsMasterDataElementsIndivFareDiscountRpInformation rpInformation
        {
            get
            {
                return this.rpInformationField;
            }
            set
            {
                this.rpInformationField = value;
            }
        }

        /// <comentarios/>
        public PNR_AddMultiElementsDataElementsMasterDataElementsIndivFareDiscountCustomer customer
        {
            get
            {
                return this.customerField;
            }
            set
            {
                this.customerField = value;
            }
        }

        /// <comentarios/>
        public PNR_AddMultiElementsDataElementsMasterDataElementsIndivFareDiscountResidentDisc residentDisc
        {
            get
            {
                return this.residentDiscField;
            }
            set
            {
                this.residentDiscField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRADD_10_1_1A")]
    public partial class PNR_AddMultiElementsDataElementsMasterDataElementsIndivFareDiscountDiscount
    {

        private string adjustmentReasonField;

        private string percentageField;

        private string statusField;

        private string staffNumberField;

        private string staffNameField;

        /// <comentarios/>
        public string adjustmentReason
        {
            get
            {
                return this.adjustmentReasonField;
            }
            set
            {
                this.adjustmentReasonField = value;
            }
        }

        /// <comentarios/>
        public string percentage
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
        public string staffNumber
        {
            get
            {
                return this.staffNumberField;
            }
            set
            {
                this.staffNumberField = value;
            }
        }

        /// <comentarios/>
        public string staffName
        {
            get
            {
                return this.staffNameField;
            }
            set
            {
                this.staffNameField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRADD_10_1_1A")]
    public partial class PNR_AddMultiElementsDataElementsMasterDataElementsIndivFareDiscountNumberDetail
    {

        private decimal unitsField;

        private string unitsQualifierField;

        /// <comentarios/>
        public decimal units
        {
            get
            {
                return this.unitsField;
            }
            set
            {
                this.unitsField = value;
            }
        }

        /// <comentarios/>
        public string unitsQualifier
        {
            get
            {
                return this.unitsQualifierField;
            }
            set
            {
                this.unitsQualifierField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRADD_10_1_1A")]
    public partial class PNR_AddMultiElementsDataElementsMasterDataElementsIndivFareDiscountRpInformation
    {

        private string companyIdField;

        private decimal referenceNumberField;

        private bool referenceNumberFieldSpecified;

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
        public decimal referenceNumber
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
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool referenceNumberSpecified
        {
            get
            {
                return this.referenceNumberFieldSpecified;
            }
            set
            {
                this.referenceNumberFieldSpecified = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRADD_10_1_1A")]
    public partial class PNR_AddMultiElementsDataElementsMasterDataElementsIndivFareDiscountCustomer
    {

        private string companyIdField;

        private string cardTypeField;

        private decimal cardNumberField;

        private bool cardNumberFieldSpecified;

        private string cardCheckField;

        private string ownerField;

        private string versionField;

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
        public string cardType
        {
            get
            {
                return this.cardTypeField;
            }
            set
            {
                this.cardTypeField = value;
            }
        }

        /// <comentarios/>
        public decimal cardNumber
        {
            get
            {
                return this.cardNumberField;
            }
            set
            {
                this.cardNumberField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool cardNumberSpecified
        {
            get
            {
                return this.cardNumberFieldSpecified;
            }
            set
            {
                this.cardNumberFieldSpecified = value;
            }
        }

        /// <comentarios/>
        public string cardCheck
        {
            get
            {
                return this.cardCheckField;
            }
            set
            {
                this.cardCheckField = value;
            }
        }

        /// <comentarios/>
        public string owner
        {
            get
            {
                return this.ownerField;
            }
            set
            {
                this.ownerField = value;
            }
        }

        /// <comentarios/>
        public string version
        {
            get
            {
                return this.versionField;
            }
            set
            {
                this.versionField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRADD_10_1_1A")]
    public partial class PNR_AddMultiElementsDataElementsMasterDataElementsIndivFareDiscountResidentDisc
    {

        private string idCardCodeField;

        private string idCardTypeField;

        private decimal cardNumberField;

        private bool cardNumberFieldSpecified;

        private string alphaCheckField;

        private string zipCodeField;

        private string certificateNumberField;

        /// <comentarios/>
        public string idCardCode
        {
            get
            {
                return this.idCardCodeField;
            }
            set
            {
                this.idCardCodeField = value;
            }
        }

        /// <comentarios/>
        public string idCardType
        {
            get
            {
                return this.idCardTypeField;
            }
            set
            {
                this.idCardTypeField = value;
            }
        }

        /// <comentarios/>
        public decimal cardNumber
        {
            get
            {
                return this.cardNumberField;
            }
            set
            {
                this.cardNumberField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool cardNumberSpecified
        {
            get
            {
                return this.cardNumberFieldSpecified;
            }
            set
            {
                this.cardNumberFieldSpecified = value;
            }
        }

        /// <comentarios/>
        public string alphaCheck
        {
            get
            {
                return this.alphaCheckField;
            }
            set
            {
                this.alphaCheckField = value;
            }
        }

        /// <comentarios/>
        public string zipCode
        {
            get
            {
                return this.zipCodeField;
            }
            set
            {
                this.zipCodeField = value;
            }
        }

        /// <comentarios/>
        public string certificateNumber
        {
            get
            {
                return this.certificateNumberField;
            }
            set
            {
                this.certificateNumberField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRADD_10_1_1A")]
    public partial class PNR_AddMultiElementsDataElementsMasterDataElementsIndivManualFareDocument
    {

        private string passengerTypeField;

        private PNR_AddMultiElementsDataElementsMasterDataElementsIndivManualFareDocumentDocument documentField;

        private string freeflowField;

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
        public PNR_AddMultiElementsDataElementsMasterDataElementsIndivManualFareDocumentDocument document
        {
            get
            {
                return this.documentField;
            }
            set
            {
                this.documentField = value;
            }
        }

        /// <comentarios/>
        public string freeflow
        {
            get
            {
                return this.freeflowField;
            }
            set
            {
                this.freeflowField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRADD_10_1_1A")]
    public partial class PNR_AddMultiElementsDataElementsMasterDataElementsIndivManualFareDocumentDocument
    {

        private string companyIdField;

        private string ticketNumberField;

        private string ticketNumberCdField;

        private string lastConjuctionField;

        private string lastConjuctionCDField;

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
        public string ticketNumber
        {
            get
            {
                return this.ticketNumberField;
            }
            set
            {
                this.ticketNumberField = value;
            }
        }

        /// <comentarios/>
        public string ticketNumberCd
        {
            get
            {
                return this.ticketNumberCdField;
            }
            set
            {
                this.ticketNumberCdField = value;
            }
        }

        /// <comentarios/>
        public string lastConjuction
        {
            get
            {
                return this.lastConjuctionField;
            }
            set
            {
                this.lastConjuctionField = value;
            }
        }

        /// <comentarios/>
        public string lastConjuctionCD
        {
            get
            {
                return this.lastConjuctionCDField;
            }
            set
            {
                this.lastConjuctionCDField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRADD_10_1_1A")]
    public partial class PNR_AddMultiElementsDataElementsMasterDataElementsIndivCommission
    {

        private string passengerTypeField;

        private string indicatorField;

        private PNR_AddMultiElementsDataElementsMasterDataElementsIndivCommissionCommissionInfo commissionInfoField;

        private PNR_AddMultiElementsDataElementsMasterDataElementsIndivCommissionOldCommission oldCommissionField;

        private decimal manualCappingField;

        private bool manualCappingFieldSpecified;

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

        /// <comentarios/>
        public PNR_AddMultiElementsDataElementsMasterDataElementsIndivCommissionCommissionInfo commissionInfo
        {
            get
            {
                return this.commissionInfoField;
            }
            set
            {
                this.commissionInfoField = value;
            }
        }

        /// <comentarios/>
        public PNR_AddMultiElementsDataElementsMasterDataElementsIndivCommissionOldCommission oldCommission
        {
            get
            {
                return this.oldCommissionField;
            }
            set
            {
                this.oldCommissionField = value;
            }
        }

        /// <comentarios/>
        public decimal manualCapping
        {
            get
            {
                return this.manualCappingField;
            }
            set
            {
                this.manualCappingField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool manualCappingSpecified
        {
            get
            {
                return this.manualCappingFieldSpecified;
            }
            set
            {
                this.manualCappingFieldSpecified = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRADD_10_1_1A")]
    public partial class PNR_AddMultiElementsDataElementsMasterDataElementsIndivCommissionCommissionInfo
    {

        private decimal percentageField;

        private bool percentageFieldSpecified;

        private decimal amountField;

        private bool amountFieldSpecified;

        private string vatIndicatorField;

        private string remitIndicatorField;

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
        public string vatIndicator
        {
            get
            {
                return this.vatIndicatorField;
            }
            set
            {
                this.vatIndicatorField = value;
            }
        }

        /// <comentarios/>
        public string remitIndicator
        {
            get
            {
                return this.remitIndicatorField;
            }
            set
            {
                this.remitIndicatorField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRADD_10_1_1A")]
    public partial class PNR_AddMultiElementsDataElementsMasterDataElementsIndivCommissionOldCommission
    {

        private decimal percentageField;

        private bool percentageFieldSpecified;

        private decimal amountField;

        private bool amountFieldSpecified;

        private string vatIndicatorField;

        private string remitIndicatorField;

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
        public string vatIndicator
        {
            get
            {
                return this.vatIndicatorField;
            }
            set
            {
                this.vatIndicatorField = value;
            }
        }

        /// <comentarios/>
        public string remitIndicator
        {
            get
            {
                return this.remitIndicatorField;
            }
            set
            {
                this.remitIndicatorField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRADD_10_1_1A")]
    public partial class PNR_AddMultiElementsDataElementsMasterDataElementsIndivOriginalIssue
    {

        private string passengerTypeField;

        private string voucherIndicatorField;

        private PNR_AddMultiElementsDataElementsMasterDataElementsIndivOriginalIssueIssue[] issueField;

        private decimal baseFareField;

        private bool baseFareFieldSpecified;

        private decimal totalTaxField;

        private bool totalTaxFieldSpecified;

        private decimal penaltyField;

        private bool penaltyFieldSpecified;

        private string freeflowField;

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
        public string voucherIndicator
        {
            get
            {
                return this.voucherIndicatorField;
            }
            set
            {
                this.voucherIndicatorField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("issue")]
        public PNR_AddMultiElementsDataElementsMasterDataElementsIndivOriginalIssueIssue[] issue
        {
            get
            {
                return this.issueField;
            }
            set
            {
                this.issueField = value;
            }
        }

        /// <comentarios/>
        public decimal baseFare
        {
            get
            {
                return this.baseFareField;
            }
            set
            {
                this.baseFareField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool baseFareSpecified
        {
            get
            {
                return this.baseFareFieldSpecified;
            }
            set
            {
                this.baseFareFieldSpecified = value;
            }
        }

        /// <comentarios/>
        public decimal totalTax
        {
            get
            {
                return this.totalTaxField;
            }
            set
            {
                this.totalTaxField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool totalTaxSpecified
        {
            get
            {
                return this.totalTaxFieldSpecified;
            }
            set
            {
                this.totalTaxFieldSpecified = value;
            }
        }

        /// <comentarios/>
        public decimal penalty
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
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool penaltySpecified
        {
            get
            {
                return this.penaltyFieldSpecified;
            }
            set
            {
                this.penaltyFieldSpecified = value;
            }
        }

        /// <comentarios/>
        public string freeflow
        {
            get
            {
                return this.freeflowField;
            }
            set
            {
                this.freeflowField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRADD_10_1_1A")]
    public partial class PNR_AddMultiElementsDataElementsMasterDataElementsIndivOriginalIssueIssue
    {

        private string airlineCodeField;

        private string documentNumberField;

        private string documentCDField;

        private string coupon1Field;

        private string coupon2Field;

        private string coupon3Field;

        private string coupon4Field;

        private string lastConjunctionField;

        private string exchangeDocumentCDField;

        private string lastConjunction1Field;

        private string lastConjunction2Field;

        private string lastConjunction3Field;

        private string lastConjunction4Field;

        private string cityCodeField;

        private string dateOfIssueField;

        private string iataNumberField;

        private string currencyField;

        private decimal amountField;

        private bool amountFieldSpecified;

        /// <comentarios/>
        public string airlineCode
        {
            get
            {
                return this.airlineCodeField;
            }
            set
            {
                this.airlineCodeField = value;
            }
        }

        /// <comentarios/>
        public string documentNumber
        {
            get
            {
                return this.documentNumberField;
            }
            set
            {
                this.documentNumberField = value;
            }
        }

        /// <comentarios/>
        public string documentCD
        {
            get
            {
                return this.documentCDField;
            }
            set
            {
                this.documentCDField = value;
            }
        }

        /// <comentarios/>
        public string coupon1
        {
            get
            {
                return this.coupon1Field;
            }
            set
            {
                this.coupon1Field = value;
            }
        }

        /// <comentarios/>
        public string coupon2
        {
            get
            {
                return this.coupon2Field;
            }
            set
            {
                this.coupon2Field = value;
            }
        }

        /// <comentarios/>
        public string coupon3
        {
            get
            {
                return this.coupon3Field;
            }
            set
            {
                this.coupon3Field = value;
            }
        }

        /// <comentarios/>
        public string coupon4
        {
            get
            {
                return this.coupon4Field;
            }
            set
            {
                this.coupon4Field = value;
            }
        }

        /// <comentarios/>
        public string lastConjunction
        {
            get
            {
                return this.lastConjunctionField;
            }
            set
            {
                this.lastConjunctionField = value;
            }
        }

        /// <comentarios/>
        public string exchangeDocumentCD
        {
            get
            {
                return this.exchangeDocumentCDField;
            }
            set
            {
                this.exchangeDocumentCDField = value;
            }
        }

        /// <comentarios/>
        public string lastConjunction1
        {
            get
            {
                return this.lastConjunction1Field;
            }
            set
            {
                this.lastConjunction1Field = value;
            }
        }

        /// <comentarios/>
        public string lastConjunction2
        {
            get
            {
                return this.lastConjunction2Field;
            }
            set
            {
                this.lastConjunction2Field = value;
            }
        }

        /// <comentarios/>
        public string lastConjunction3
        {
            get
            {
                return this.lastConjunction3Field;
            }
            set
            {
                this.lastConjunction3Field = value;
            }
        }

        /// <comentarios/>
        public string lastConjunction4
        {
            get
            {
                return this.lastConjunction4Field;
            }
            set
            {
                this.lastConjunction4Field = value;
            }
        }

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
        public string dateOfIssue
        {
            get
            {
                return this.dateOfIssueField;
            }
            set
            {
                this.dateOfIssueField = value;
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRADD_10_1_1A")]
    public partial class PNR_AddMultiElementsDataElementsMasterDataElementsIndivFop
    {

        private string identificationField;

        private decimal amountField;

        private bool amountFieldSpecified;

        private string creditCardCodeField;

        private string accountNumberField;

        private string expiryDateField;

        private string approvalCodeField;

        private string customerAccountNumberField;

        private string paymentTimeReferenceField;

        private string freetextField;

        private string currencyCodeField;

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
        public string creditCardCode
        {
            get
            {
                return this.creditCardCodeField;
            }
            set
            {
                this.creditCardCodeField = value;
            }
        }

        /// <comentarios/>
        public string accountNumber
        {
            get
            {
                return this.accountNumberField;
            }
            set
            {
                this.accountNumberField = value;
            }
        }

        /// <comentarios/>
        public string expiryDate
        {
            get
            {
                return this.expiryDateField;
            }
            set
            {
                this.expiryDateField = value;
            }
        }

        /// <comentarios/>
        public string approvalCode
        {
            get
            {
                return this.approvalCodeField;
            }
            set
            {
                this.approvalCodeField = value;
            }
        }

        /// <comentarios/>
        public string customerAccountNumber
        {
            get
            {
                return this.customerAccountNumberField;
            }
            set
            {
                this.customerAccountNumberField = value;
            }
        }

        /// <comentarios/>
        public string paymentTimeReference
        {
            get
            {
                return this.paymentTimeReferenceField;
            }
            set
            {
                this.paymentTimeReferenceField = value;
            }
        }

        /// <comentarios/>
        public string freetext
        {
            get
            {
                return this.freetextField;
            }
            set
            {
                this.freetextField = value;
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
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRADD_10_1_1A")]
    public partial class PNR_AddMultiElementsDataElementsMasterDataElementsIndivFopExtension
    {

        private decimal fopSequenceNumberField;

        private string passengerTypeField;

        private PNR_AddMultiElementsDataElementsMasterDataElementsIndivFopExtensionNewFopsDetails newFopsDetailsField;

        private PNR_AddMultiElementsDataElementsMasterDataElementsIndivFopExtensionExtFOP[] extFOPField;

        /// <comentarios/>
        public decimal fopSequenceNumber
        {
            get
            {
                return this.fopSequenceNumberField;
            }
            set
            {
                this.fopSequenceNumberField = value;
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
        public PNR_AddMultiElementsDataElementsMasterDataElementsIndivFopExtensionNewFopsDetails newFopsDetails
        {
            get
            {
                return this.newFopsDetailsField;
            }
            set
            {
                this.newFopsDetailsField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("extFOP")]
        public PNR_AddMultiElementsDataElementsMasterDataElementsIndivFopExtensionExtFOP[] extFOP
        {
            get
            {
                return this.extFOPField;
            }
            set
            {
                this.extFOPField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRADD_10_1_1A")]
    public partial class PNR_AddMultiElementsDataElementsMasterDataElementsIndivFopExtensionNewFopsDetails
    {

        private string cvDataField;

        private string printedFreeflowField;

        private string reportedFreeflowField;

        private string onoDataField;

        private string gwtDataField;

        private string chdDataField;

        private string delegationCodeField;

        private string mcoDocNumberField;

        private string mcoCouponNumberField;

        private decimal mcoIataNumberField;

        private bool mcoIataNumberFieldSpecified;

        private string mcoPlaceOfIssueField;

        private string mcoDateOfIssueField;

        private decimal iataNumberField;

        private bool iataNumberFieldSpecified;

        /// <comentarios/>
        public string cvData
        {
            get
            {
                return this.cvDataField;
            }
            set
            {
                this.cvDataField = value;
            }
        }

        /// <comentarios/>
        public string printedFreeflow
        {
            get
            {
                return this.printedFreeflowField;
            }
            set
            {
                this.printedFreeflowField = value;
            }
        }

        /// <comentarios/>
        public string reportedFreeflow
        {
            get
            {
                return this.reportedFreeflowField;
            }
            set
            {
                this.reportedFreeflowField = value;
            }
        }

        /// <comentarios/>
        public string onoData
        {
            get
            {
                return this.onoDataField;
            }
            set
            {
                this.onoDataField = value;
            }
        }

        /// <comentarios/>
        public string gwtData
        {
            get
            {
                return this.gwtDataField;
            }
            set
            {
                this.gwtDataField = value;
            }
        }

        /// <comentarios/>
        public string chdData
        {
            get
            {
                return this.chdDataField;
            }
            set
            {
                this.chdDataField = value;
            }
        }

        /// <comentarios/>
        public string delegationCode
        {
            get
            {
                return this.delegationCodeField;
            }
            set
            {
                this.delegationCodeField = value;
            }
        }

        /// <comentarios/>
        public string mcoDocNumber
        {
            get
            {
                return this.mcoDocNumberField;
            }
            set
            {
                this.mcoDocNumberField = value;
            }
        }

        /// <comentarios/>
        public string mcoCouponNumber
        {
            get
            {
                return this.mcoCouponNumberField;
            }
            set
            {
                this.mcoCouponNumberField = value;
            }
        }

        /// <comentarios/>
        public decimal mcoIataNumber
        {
            get
            {
                return this.mcoIataNumberField;
            }
            set
            {
                this.mcoIataNumberField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool mcoIataNumberSpecified
        {
            get
            {
                return this.mcoIataNumberFieldSpecified;
            }
            set
            {
                this.mcoIataNumberFieldSpecified = value;
            }
        }

        /// <comentarios/>
        public string mcoPlaceOfIssue
        {
            get
            {
                return this.mcoPlaceOfIssueField;
            }
            set
            {
                this.mcoPlaceOfIssueField = value;
            }
        }

        /// <comentarios/>
        public string mcoDateOfIssue
        {
            get
            {
                return this.mcoDateOfIssueField;
            }
            set
            {
                this.mcoDateOfIssueField = value;
            }
        }

        /// <comentarios/>
        public decimal iataNumber
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

        /// <comentarios/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool iataNumberSpecified
        {
            get
            {
                return this.iataNumberFieldSpecified;
            }
            set
            {
                this.iataNumberFieldSpecified = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRADD_10_1_1A")]
    public partial class PNR_AddMultiElementsDataElementsMasterDataElementsIndivFopExtensionExtFOP
    {

        private string referenceQualifierField;

        private string dataValueField;

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
        public string dataValue
        {
            get
            {
                return this.dataValueField;
            }
            set
            {
                this.dataValueField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRADD_10_1_1A")]
    public partial class PNR_AddMultiElementsDataElementsMasterDataElementsIndivServiceDetails
    {

        private PNR_AddMultiElementsDataElementsMasterDataElementsIndivServiceDetailsStatusDetails statusDetailsField;

        /// <comentarios/>
        public PNR_AddMultiElementsDataElementsMasterDataElementsIndivServiceDetailsStatusDetails statusDetails
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRADD_10_1_1A")]
    public partial class PNR_AddMultiElementsDataElementsMasterDataElementsIndivServiceDetailsStatusDetails
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRADD_10_1_1A")]
    public partial class PNR_AddMultiElementsDataElementsMasterDataElementsIndivFrequentTravellerVerification
    {

        private string actionRequestField;

        private PNR_AddMultiElementsDataElementsMasterDataElementsIndivFrequentTravellerVerificationCompany companyField;

        private PNR_AddMultiElementsDataElementsMasterDataElementsIndivFrequentTravellerVerificationAccount accountField;

        /// <comentarios/>
        public string actionRequest
        {
            get
            {
                return this.actionRequestField;
            }
            set
            {
                this.actionRequestField = value;
            }
        }

        /// <comentarios/>
        public PNR_AddMultiElementsDataElementsMasterDataElementsIndivFrequentTravellerVerificationCompany company
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

        /// <comentarios/>
        public PNR_AddMultiElementsDataElementsMasterDataElementsIndivFrequentTravellerVerificationAccount account
        {
            get
            {
                return this.accountField;
            }
            set
            {
                this.accountField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRADD_10_1_1A")]
    public partial class PNR_AddMultiElementsDataElementsMasterDataElementsIndivFrequentTravellerVerificationCompany
    {

        private string codeField;

        private string partnerCodeField;

        private string otherPartnerCodeField;

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
        public string partnerCode
        {
            get
            {
                return this.partnerCodeField;
            }
            set
            {
                this.partnerCodeField = value;
            }
        }

        /// <comentarios/>
        public string otherPartnerCode
        {
            get
            {
                return this.otherPartnerCodeField;
            }
            set
            {
                this.otherPartnerCodeField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRADD_10_1_1A")]
    public partial class PNR_AddMultiElementsDataElementsMasterDataElementsIndivFrequentTravellerVerificationAccount
    {

        private string numberQualifierField;

        private string numberField;

        /// <comentarios/>
        public string numberQualifier
        {
            get
            {
                return this.numberQualifierField;
            }
            set
            {
                this.numberQualifierField = value;
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
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRADD_10_1_1A")]
    public partial class PNR_AddMultiElementsDataElementsMasterDataElementsIndivTicketingCarrier
    {

        private string passengerTypeField;

        private PNR_AddMultiElementsDataElementsMasterDataElementsIndivTicketingCarrierCarrier carrierField;

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
        public PNR_AddMultiElementsDataElementsMasterDataElementsIndivTicketingCarrierCarrier carrier
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
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRADD_10_1_1A")]
    public partial class PNR_AddMultiElementsDataElementsMasterDataElementsIndivTicketingCarrierCarrier
    {

        private string airlineCodeField;

        private string optionInfoField;

        private string printerNumberField;

        private string languageField;

        /// <comentarios/>
        public string airlineCode
        {
            get
            {
                return this.airlineCodeField;
            }
            set
            {
                this.airlineCodeField = value;
            }
        }

        /// <comentarios/>
        public string optionInfo
        {
            get
            {
                return this.optionInfoField;
            }
            set
            {
                this.optionInfoField = value;
            }
        }

        /// <comentarios/>
        public string printerNumber
        {
            get
            {
                return this.printerNumberField;
            }
            set
            {
                this.printerNumberField = value;
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRADD_10_1_1A")]
    public partial class PNR_AddMultiElementsDataElementsMasterDataElementsIndivFarePrintOverride
    {

        private string passengerTypeField;

        private PNR_AddMultiElementsDataElementsMasterDataElementsIndivFarePrintOverrideOverride overrideField;

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
        public PNR_AddMultiElementsDataElementsMasterDataElementsIndivFarePrintOverrideOverride @override
        {
            get
            {
                return this.overrideField;
            }
            set
            {
                this.overrideField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRADD_10_1_1A")]
    public partial class PNR_AddMultiElementsDataElementsMasterDataElementsIndivFarePrintOverrideOverride
    {

        private string baseFareField;

        private string totalFareField;

        private string equivalentFareField;

        private string[] taxAmountField;

        /// <comentarios/>
        public string baseFare
        {
            get
            {
                return this.baseFareField;
            }
            set
            {
                this.baseFareField = value;
            }
        }

        /// <comentarios/>
        public string totalFare
        {
            get
            {
                return this.totalFareField;
            }
            set
            {
                this.totalFareField = value;
            }
        }

        /// <comentarios/>
        public string equivalentFare
        {
            get
            {
                return this.equivalentFareField;
            }
            set
            {
                this.equivalentFareField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("taxAmount")]
        public string[] taxAmount
        {
            get
            {
                return this.taxAmountField;
            }
            set
            {
                this.taxAmountField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRADD_10_1_1A")]
    public partial class PNR_AddMultiElementsDataElementsMasterDataElementsIndivFrequentTravellerData
    {

        private PNR_AddMultiElementsDataElementsMasterDataElementsIndivFrequentTravellerDataFrequentTraveller frequentTravellerField;

        /// <comentarios/>
        public PNR_AddMultiElementsDataElementsMasterDataElementsIndivFrequentTravellerDataFrequentTraveller frequentTraveller
        {
            get
            {
                return this.frequentTravellerField;
            }
            set
            {
                this.frequentTravellerField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRADD_10_1_1A")]
    public partial class PNR_AddMultiElementsDataElementsMasterDataElementsIndivFrequentTravellerDataFrequentTraveller
    {

        private string companyIdField;

        private string membershipNumberField;

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
        public string membershipNumber
        {
            get
            {
                return this.membershipNumberField;
            }
            set
            {
                this.membershipNumberField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRADD_10_1_1A")]
    public partial class PNR_AddMultiElementsDataElementsMasterDataElementsIndivSecurityDetails
    {

        private string typeOfEntityField;

        private string accessModeField;

        private string inhouseIdentificationField;

        /// <comentarios/>
        public string typeOfEntity
        {
            get
            {
                return this.typeOfEntityField;
            }
            set
            {
                this.typeOfEntityField = value;
            }
        }

        /// <comentarios/>
        public string accessMode
        {
            get
            {
                return this.accessModeField;
            }
            set
            {
                this.accessModeField = value;
            }
        }

        /// <comentarios/>
        public string inhouseIdentification
        {
            get
            {
                return this.inhouseIdentificationField;
            }
            set
            {
                this.inhouseIdentificationField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRADD_10_1_1A")]
    public partial class PNR_AddMultiElementsDataElementsMasterDataElementsIndivReference
    {

        private string qualifierField;

        private string numberField;

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
}

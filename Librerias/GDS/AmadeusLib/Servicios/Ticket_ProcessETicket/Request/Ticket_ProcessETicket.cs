using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmadeusLib.Servicios.Ticket_ProcessETicket.Request
{
    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TKTREQ_04_1_IA")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://xml.amadeus.com/TKTREQ_04_1_IA", IsNullable = false)]
    public partial class Ticket_ProcessETicket
    {

        private Ticket_ProcessETicketMsgActionDetails msgActionDetailsField;

        private Ticket_ProcessETicketReferenceInfo referenceInfoField;

        private Ticket_ProcessETicketTripInfo tripInfoField;

        private Ticket_ProcessETicketCreditCardInfo creditCardInfoField;

        private Ticket_ProcessETicketFfInfo ffInfoField;

        private Ticket_ProcessETicketTextInfo textInfoField;

        private Ticket_ProcessETicketTicketInfoGroup[] ticketInfoGroupField;

        private Ticket_ProcessETicketPaxInfoGroup paxInfoGroupField;

        /// <comentarios/>
        public Ticket_ProcessETicketMsgActionDetails msgActionDetails
        {
            get
            {
                return this.msgActionDetailsField;
            }
            set
            {
                this.msgActionDetailsField = value;
            }
        }

        /// <comentarios/>
        public Ticket_ProcessETicketReferenceInfo referenceInfo
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
        public Ticket_ProcessETicketTripInfo tripInfo
        {
            get
            {
                return this.tripInfoField;
            }
            set
            {
                this.tripInfoField = value;
            }
        }

        /// <comentarios/>
        public Ticket_ProcessETicketCreditCardInfo creditCardInfo
        {
            get
            {
                return this.creditCardInfoField;
            }
            set
            {
                this.creditCardInfoField = value;
            }
        }

        /// <comentarios/>
        public Ticket_ProcessETicketFfInfo ffInfo
        {
            get
            {
                return this.ffInfoField;
            }
            set
            {
                this.ffInfoField = value;
            }
        }

        /// <comentarios/>
        public Ticket_ProcessETicketTextInfo textInfo
        {
            get
            {
                return this.textInfoField;
            }
            set
            {
                this.textInfoField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("ticketInfoGroup")]
        public Ticket_ProcessETicketTicketInfoGroup[] ticketInfoGroup
        {
            get
            {
                return this.ticketInfoGroupField;
            }
            set
            {
                this.ticketInfoGroupField = value;
            }
        }

        /// <comentarios/>
        public Ticket_ProcessETicketPaxInfoGroup paxInfoGroup
        {
            get
            {
                return this.paxInfoGroupField;
            }
            set
            {
                this.paxInfoGroupField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TKTREQ_04_1_IA")]
    public partial class Ticket_ProcessETicketMsgActionDetails
    {

        private Ticket_ProcessETicketMsgActionDetailsMessageFunctionDetails messageFunctionDetailsField;

        /// <comentarios/>
        public Ticket_ProcessETicketMsgActionDetailsMessageFunctionDetails messageFunctionDetails
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TKTREQ_04_1_IA")]
    public partial class Ticket_ProcessETicketMsgActionDetailsMessageFunctionDetails
    {

        private string messageFunctionField;

        private string additionalMessageFunctionField;

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
        public string additionalMessageFunction
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TKTREQ_04_1_IA")]
    public partial class Ticket_ProcessETicketReferenceInfo
    {

        private Ticket_ProcessETicketReferenceInfoReservation reservationField;

        /// <comentarios/>
        public Ticket_ProcessETicketReferenceInfoReservation reservation
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TKTREQ_04_1_IA")]
    public partial class Ticket_ProcessETicketReferenceInfoReservation
    {

        private string companyIdField;

        private string controlNumberField;

        private string controlTypeField;

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
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TKTREQ_04_1_IA")]
    public partial class Ticket_ProcessETicketTripInfo
    {

        private Ticket_ProcessETicketTripInfoFlightDate flightDateField;

        private Ticket_ProcessETicketTripInfoBoardPointDetails boardPointDetailsField;

        private Ticket_ProcessETicketTripInfoOffpointDetails offpointDetailsField;

        private Ticket_ProcessETicketTripInfoCompanyDetails companyDetailsField;

        private Ticket_ProcessETicketTripInfoFlightIdentification flightIdentificationField;

        /// <comentarios/>
        public Ticket_ProcessETicketTripInfoFlightDate flightDate
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
        public Ticket_ProcessETicketTripInfoBoardPointDetails boardPointDetails
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
        public Ticket_ProcessETicketTripInfoOffpointDetails offpointDetails
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
        public Ticket_ProcessETicketTripInfoCompanyDetails companyDetails
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
        public Ticket_ProcessETicketTripInfoFlightIdentification flightIdentification
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
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TKTREQ_04_1_IA")]
    public partial class Ticket_ProcessETicketTripInfoFlightDate
    {

        private string departureDateField;

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
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TKTREQ_04_1_IA")]
    public partial class Ticket_ProcessETicketTripInfoBoardPointDetails
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TKTREQ_04_1_IA")]
    public partial class Ticket_ProcessETicketTripInfoOffpointDetails
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TKTREQ_04_1_IA")]
    public partial class Ticket_ProcessETicketTripInfoCompanyDetails
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TKTREQ_04_1_IA")]
    public partial class Ticket_ProcessETicketTripInfoFlightIdentification
    {

        private decimal flightNumberField;

        /// <comentarios/>
        public decimal flightNumber
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TKTREQ_04_1_IA")]
    public partial class Ticket_ProcessETicketCreditCardInfo
    {

        private Ticket_ProcessETicketCreditCardInfoFormOfPayment formOfPaymentField;

        /// <comentarios/>
        public Ticket_ProcessETicketCreditCardInfoFormOfPayment formOfPayment
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
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TKTREQ_04_1_IA")]
    public partial class Ticket_ProcessETicketCreditCardInfoFormOfPayment
    {

        private string typeField;

        private string vendorCodeField;

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
        public string vendorCode
        {
            get
            {
                return this.vendorCodeField;
            }
            set
            {
                this.vendorCodeField = value;
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TKTREQ_04_1_IA")]
    public partial class Ticket_ProcessETicketFfInfo
    {

        private Ticket_ProcessETicketFfInfoFrequentTravellerDetails frequentTravellerDetailsField;

        /// <comentarios/>
        public Ticket_ProcessETicketFfInfoFrequentTravellerDetails frequentTravellerDetails
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TKTREQ_04_1_IA")]
    public partial class Ticket_ProcessETicketFfInfoFrequentTravellerDetails
    {

        private string carrierField;

        private string numberField;

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
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TKTREQ_04_1_IA")]
    public partial class Ticket_ProcessETicketTextInfo
    {

        private Ticket_ProcessETicketTextInfoFreeTextQualification freeTextQualificationField;

        private string freeTextField;

        /// <comentarios/>
        public Ticket_ProcessETicketTextInfoFreeTextQualification freeTextQualification
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TKTREQ_04_1_IA")]
    public partial class Ticket_ProcessETicketTextInfoFreeTextQualification
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TKTREQ_04_1_IA")]
    public partial class Ticket_ProcessETicketTicketInfoGroup
    {

        private Ticket_ProcessETicketTicketInfoGroupTicket ticketField;

        private Ticket_ProcessETicketTicketInfoGroupCouponInfo[] couponInfoField;

        /// <comentarios/>
        public Ticket_ProcessETicketTicketInfoGroupTicket ticket
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
        [System.Xml.Serialization.XmlElementAttribute("couponInfo")]
        public Ticket_ProcessETicketTicketInfoGroupCouponInfo[] couponInfo
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TKTREQ_04_1_IA")]
    public partial class Ticket_ProcessETicketTicketInfoGroupTicket
    {

        private Ticket_ProcessETicketTicketInfoGroupTicketDocumentDetails documentDetailsField;

        /// <comentarios/>
        public Ticket_ProcessETicketTicketInfoGroupTicketDocumentDetails documentDetails
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TKTREQ_04_1_IA")]
    public partial class Ticket_ProcessETicketTicketInfoGroupTicketDocumentDetails
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TKTREQ_04_1_IA")]
    public partial class Ticket_ProcessETicketTicketInfoGroupCouponInfo
    {

        private Ticket_ProcessETicketTicketInfoGroupCouponInfoCouponDetails couponDetailsField;

        /// <comentarios/>
        public Ticket_ProcessETicketTicketInfoGroupCouponInfoCouponDetails couponDetails
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
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TKTREQ_04_1_IA")]
    public partial class Ticket_ProcessETicketTicketInfoGroupCouponInfoCouponDetails
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TKTREQ_04_1_IA")]
    public partial class Ticket_ProcessETicketPaxInfoGroup
    {

        private Ticket_ProcessETicketPaxInfoGroupPassenger passengerField;

        /// <comentarios/>
        public Ticket_ProcessETicketPaxInfoGroupPassenger passenger
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TKTREQ_04_1_IA")]
    public partial class Ticket_ProcessETicketPaxInfoGroupPassenger
    {

        private Ticket_ProcessETicketPaxInfoGroupPassengerPaxDetails paxDetailsField;

        private Ticket_ProcessETicketPaxInfoGroupPassengerOtherPaxDetails otherPaxDetailsField;

        /// <comentarios/>
        public Ticket_ProcessETicketPaxInfoGroupPassengerPaxDetails paxDetails
        {
            get
            {
                return this.paxDetailsField;
            }
            set
            {
                this.paxDetailsField = value;
            }
        }

        /// <comentarios/>
        public Ticket_ProcessETicketPaxInfoGroupPassengerOtherPaxDetails otherPaxDetails
        {
            get
            {
                return this.otherPaxDetailsField;
            }
            set
            {
                this.otherPaxDetailsField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TKTREQ_04_1_IA")]
    public partial class Ticket_ProcessETicketPaxInfoGroupPassengerPaxDetails
    {

        private string surnameField;

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
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TKTREQ_04_1_IA")]
    public partial class Ticket_ProcessETicketPaxInfoGroupPassengerOtherPaxDetails
    {

        private string givenNameField;

        /// <comentarios/>
        public string givenName
        {
            get
            {
                return this.givenNameField;
            }
            set
            {
                this.givenNameField = value;
            }
        }
    }
}

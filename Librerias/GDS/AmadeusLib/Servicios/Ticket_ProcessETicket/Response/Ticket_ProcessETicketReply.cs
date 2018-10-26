using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmadeusLib.Servicios.Ticket_ProcessETicket.Response
{
    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TKTRES_04_1_IA")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://xml.amadeus.com/TKTRES_04_1_IA", IsNullable = false)]
    public partial class Ticket_ProcessETicketReply
    {

        private Ticket_ProcessETicketReplyMsgActionDetails msgActionDetailsField;

        private Ticket_ProcessETicketReplyMatch matchField;

        private Ticket_ProcessETicketReplyErrorInfo errorInfoField;

        private Ticket_ProcessETicketReplyTicketGroup ticketGroupField;

        private Ticket_ProcessETicketReplyDocumentGroup[] documentGroupField;

        /// <comentarios/>
        public Ticket_ProcessETicketReplyMsgActionDetails msgActionDetails
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
        public Ticket_ProcessETicketReplyMatch match
        {
            get
            {
                return this.matchField;
            }
            set
            {
                this.matchField = value;
            }
        }

        /// <comentarios/>
        public Ticket_ProcessETicketReplyErrorInfo errorInfo
        {
            get
            {
                return this.errorInfoField;
            }
            set
            {
                this.errorInfoField = value;
            }
        }

        /// <comentarios/>
        public Ticket_ProcessETicketReplyTicketGroup ticketGroup
        {
            get
            {
                return this.ticketGroupField;
            }
            set
            {
                this.ticketGroupField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("documentGroup")]
        public Ticket_ProcessETicketReplyDocumentGroup[] documentGroup
        {
            get
            {
                return this.documentGroupField;
            }
            set
            {
                this.documentGroupField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TKTRES_04_1_IA")]
    public partial class Ticket_ProcessETicketReplyMsgActionDetails
    {

        private Ticket_ProcessETicketReplyMsgActionDetailsMessageFunctionDetails messageFunctionDetailsField;

        private string responseTypeField;

        /// <comentarios/>
        public Ticket_ProcessETicketReplyMsgActionDetailsMessageFunctionDetails messageFunctionDetails
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TKTRES_04_1_IA")]
    public partial class Ticket_ProcessETicketReplyMsgActionDetailsMessageFunctionDetails
    {

        private string messageFunctionField;

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
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TKTRES_04_1_IA")]
    public partial class Ticket_ProcessETicketReplyMatch
    {

        private Ticket_ProcessETicketReplyMatchQuantityDetails quantityDetailsField;

        /// <comentarios/>
        public Ticket_ProcessETicketReplyMatchQuantityDetails quantityDetails
        {
            get
            {
                return this.quantityDetailsField;
            }
            set
            {
                this.quantityDetailsField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TKTRES_04_1_IA")]
    public partial class Ticket_ProcessETicketReplyMatchQuantityDetails
    {

        private decimal numberOfUnitField;

        private string unitQualifierField;

        /// <comentarios/>
        public decimal numberOfUnit
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TKTRES_04_1_IA")]
    public partial class Ticket_ProcessETicketReplyErrorInfo
    {

        private Ticket_ProcessETicketReplyErrorInfoErrorDetails errorDetailsField;

        /// <comentarios/>
        public Ticket_ProcessETicketReplyErrorInfoErrorDetails errorDetails
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TKTRES_04_1_IA")]
    public partial class Ticket_ProcessETicketReplyErrorInfoErrorDetails
    {

        private string errorCodeField;

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
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TKTRES_04_1_IA")]
    public partial class Ticket_ProcessETicketReplyTicketGroup
    {

        private Ticket_ProcessETicketReplyTicketGroupTicketInfo ticketInfoField;

        private Ticket_ProcessETicketReplyTicketGroupTicketError ticketErrorField;

        private Ticket_ProcessETicketReplyTicketGroupCouponInfo couponInfoField;

        /// <comentarios/>
        public Ticket_ProcessETicketReplyTicketGroupTicketInfo ticketInfo
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
        public Ticket_ProcessETicketReplyTicketGroupTicketError ticketError
        {
            get
            {
                return this.ticketErrorField;
            }
            set
            {
                this.ticketErrorField = value;
            }
        }

        /// <comentarios/>
        public Ticket_ProcessETicketReplyTicketGroupCouponInfo couponInfo
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TKTRES_04_1_IA")]
    public partial class Ticket_ProcessETicketReplyTicketGroupTicketInfo
    {

        private Ticket_ProcessETicketReplyTicketGroupTicketInfoDocumentDetails documentDetailsField;

        /// <comentarios/>
        public Ticket_ProcessETicketReplyTicketGroupTicketInfoDocumentDetails documentDetails
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TKTRES_04_1_IA")]
    public partial class Ticket_ProcessETicketReplyTicketGroupTicketInfoDocumentDetails
    {

        private string numberField;

        private string typeField;

        private decimal numberOfBookletsField;

        private bool numberOfBookletsFieldSpecified;

        private string dataIndicatorField;

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
        public decimal numberOfBooklets
        {
            get
            {
                return this.numberOfBookletsField;
            }
            set
            {
                this.numberOfBookletsField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool numberOfBookletsSpecified
        {
            get
            {
                return this.numberOfBookletsFieldSpecified;
            }
            set
            {
                this.numberOfBookletsFieldSpecified = value;
            }
        }

        /// <comentarios/>
        public string dataIndicator
        {
            get
            {
                return this.dataIndicatorField;
            }
            set
            {
                this.dataIndicatorField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TKTRES_04_1_IA")]
    public partial class Ticket_ProcessETicketReplyTicketGroupTicketError
    {

        private Ticket_ProcessETicketReplyTicketGroupTicketErrorErrorDetails errorDetailsField;

        /// <comentarios/>
        public Ticket_ProcessETicketReplyTicketGroupTicketErrorErrorDetails errorDetails
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TKTRES_04_1_IA")]
    public partial class Ticket_ProcessETicketReplyTicketGroupTicketErrorErrorDetails
    {

        private string errorCodeField;

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
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TKTRES_04_1_IA")]
    public partial class Ticket_ProcessETicketReplyTicketGroupCouponInfo
    {

        private Ticket_ProcessETicketReplyTicketGroupCouponInfoCouponDetails couponDetailsField;

        /// <comentarios/>
        public Ticket_ProcessETicketReplyTicketGroupCouponInfoCouponDetails couponDetails
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TKTRES_04_1_IA")]
    public partial class Ticket_ProcessETicketReplyTicketGroupCouponInfoCouponDetails
    {

        private string cpnNumberField;

        private string cpnStatusField;

        private string cpnExchangeMediaField;

        private string settlementAuthorizationField;

        private string voluntaryIndicField;

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

        /// <comentarios/>
        public string cpnStatus
        {
            get
            {
                return this.cpnStatusField;
            }
            set
            {
                this.cpnStatusField = value;
            }
        }

        /// <comentarios/>
        public string cpnExchangeMedia
        {
            get
            {
                return this.cpnExchangeMediaField;
            }
            set
            {
                this.cpnExchangeMediaField = value;
            }
        }

        /// <comentarios/>
        public string settlementAuthorization
        {
            get
            {
                return this.settlementAuthorizationField;
            }
            set
            {
                this.settlementAuthorizationField = value;
            }
        }

        /// <comentarios/>
        public string voluntaryIndic
        {
            get
            {
                return this.voluntaryIndicField;
            }
            set
            {
                this.voluntaryIndicField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TKTRES_04_1_IA")]
    public partial class Ticket_ProcessETicketReplyDocumentGroup
    {

        private Ticket_ProcessETicketReplyDocumentGroupPassenger passengerField;

        private Ticket_ProcessETicketReplyDocumentGroupAgent agentField;

        private Ticket_ProcessETicketReplyDocumentGroupReservation[] reservationInfoField;

        private Ticket_ProcessETicketReplyDocumentGroupFareInfo fareInfoField;

        private Ticket_ProcessETicketReplyDocumentGroupFop fopField;

        private Ticket_ProcessETicketReplyDocumentGroupPricingInfo pricingInfoField;

        private Ticket_ProcessETicketReplyDocumentGroupOriginDestination originDestinationField;

        private Ticket_ProcessETicketReplyDocumentGroupTourInfo tourInfoField;

        private Ticket_ProcessETicketReplyDocumentGroupOriginatorInfo originatorInfoField;

        private Ticket_ProcessETicketReplyDocumentGroupCouponTotal couponTotalField;

        private Ticket_ProcessETicketReplyDocumentGroupTaxInfo[] taxInfoField;

        private Ticket_ProcessETicketReplyDocumentGroupTextData[] textDataField;

        private Ticket_ProcessETicketReplyDocumentGroupTicketInfoGroup[] ticketInfoGroupField;

        /// <comentarios/>
        public Ticket_ProcessETicketReplyDocumentGroupPassenger passenger
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

        /// <comentarios/>
        public Ticket_ProcessETicketReplyDocumentGroupAgent agent
        {
            get
            {
                return this.agentField;
            }
            set
            {
                this.agentField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayItemAttribute("reservation", IsNullable = false)]
        public Ticket_ProcessETicketReplyDocumentGroupReservation[] reservationInfo
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
        public Ticket_ProcessETicketReplyDocumentGroupFareInfo fareInfo
        {
            get
            {
                return this.fareInfoField;
            }
            set
            {
                this.fareInfoField = value;
            }
        }

        /// <comentarios/>
        public Ticket_ProcessETicketReplyDocumentGroupFop fop
        {
            get
            {
                return this.fopField;
            }
            set
            {
                this.fopField = value;
            }
        }

        /// <comentarios/>
        public Ticket_ProcessETicketReplyDocumentGroupPricingInfo pricingInfo
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
        public Ticket_ProcessETicketReplyDocumentGroupOriginDestination originDestination
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
        public Ticket_ProcessETicketReplyDocumentGroupTourInfo tourInfo
        {
            get
            {
                return this.tourInfoField;
            }
            set
            {
                this.tourInfoField = value;
            }
        }

        /// <comentarios/>
        public Ticket_ProcessETicketReplyDocumentGroupOriginatorInfo originatorInfo
        {
            get
            {
                return this.originatorInfoField;
            }
            set
            {
                this.originatorInfoField = value;
            }
        }

        /// <comentarios/>
        public Ticket_ProcessETicketReplyDocumentGroupCouponTotal couponTotal
        {
            get
            {
                return this.couponTotalField;
            }
            set
            {
                this.couponTotalField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("taxInfo")]
        public Ticket_ProcessETicketReplyDocumentGroupTaxInfo[] taxInfo
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
        [System.Xml.Serialization.XmlElementAttribute("textData")]
        public Ticket_ProcessETicketReplyDocumentGroupTextData[] textData
        {
            get
            {
                return this.textDataField;
            }
            set
            {
                this.textDataField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("ticketInfoGroup")]
        public Ticket_ProcessETicketReplyDocumentGroupTicketInfoGroup[] ticketInfoGroup
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
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TKTRES_04_1_IA")]
    public partial class Ticket_ProcessETicketReplyDocumentGroupPassenger
    {

        private Ticket_ProcessETicketReplyDocumentGroupPassengerPaxDetails paxDetailsField;

        private Ticket_ProcessETicketReplyDocumentGroupPassengerOtherPaxDetails otherPaxDetailsField;

        /// <comentarios/>
        public Ticket_ProcessETicketReplyDocumentGroupPassengerPaxDetails paxDetails
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
        public Ticket_ProcessETicketReplyDocumentGroupPassengerOtherPaxDetails otherPaxDetails
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TKTRES_04_1_IA")]
    public partial class Ticket_ProcessETicketReplyDocumentGroupPassengerPaxDetails
    {

        private string surnameField;

        private string typeField;

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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TKTRES_04_1_IA")]
    public partial class Ticket_ProcessETicketReplyDocumentGroupPassengerOtherPaxDetails
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

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TKTRES_04_1_IA")]
    public partial class Ticket_ProcessETicketReplyDocumentGroupAgent
    {

        private string companyIdNumberField;

        private Ticket_ProcessETicketReplyDocumentGroupAgentInternalIdDetails internalIdDetailsField;

        /// <comentarios/>
        public string companyIdNumber
        {
            get
            {
                return this.companyIdNumberField;
            }
            set
            {
                this.companyIdNumberField = value;
            }
        }

        /// <comentarios/>
        public Ticket_ProcessETicketReplyDocumentGroupAgentInternalIdDetails internalIdDetails
        {
            get
            {
                return this.internalIdDetailsField;
            }
            set
            {
                this.internalIdDetailsField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TKTRES_04_1_IA")]
    public partial class Ticket_ProcessETicketReplyDocumentGroupAgentInternalIdDetails
    {

        private string inhouseIdField;

        private string typeField;

        /// <comentarios/>
        public string inhouseId
        {
            get
            {
                return this.inhouseIdField;
            }
            set
            {
                this.inhouseIdField = value;
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TKTRES_04_1_IA")]
    public partial class Ticket_ProcessETicketReplyDocumentGroupReservation
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TKTRES_04_1_IA")]
    public partial class Ticket_ProcessETicketReplyDocumentGroupFareInfo
    {

        private Ticket_ProcessETicketReplyDocumentGroupFareInfoMonetaryDetails monetaryDetailsField;

        private Ticket_ProcessETicketReplyDocumentGroupFareInfoOtherMonetaryDetails[] otherMonetaryDetailsField;

        /// <comentarios/>
        public Ticket_ProcessETicketReplyDocumentGroupFareInfoMonetaryDetails monetaryDetails
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
        public Ticket_ProcessETicketReplyDocumentGroupFareInfoOtherMonetaryDetails[] otherMonetaryDetails
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TKTRES_04_1_IA")]
    public partial class Ticket_ProcessETicketReplyDocumentGroupFareInfoMonetaryDetails
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TKTRES_04_1_IA")]
    public partial class Ticket_ProcessETicketReplyDocumentGroupFareInfoOtherMonetaryDetails
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TKTRES_04_1_IA")]
    public partial class Ticket_ProcessETicketReplyDocumentGroupFop
    {

        private Ticket_ProcessETicketReplyDocumentGroupFopFormOfPayment formOfPaymentField;

        private Ticket_ProcessETicketReplyDocumentGroupFopOtherFormOfPayment[] otherFormOfPaymentField;

        /// <comentarios/>
        public Ticket_ProcessETicketReplyDocumentGroupFopFormOfPayment formOfPayment
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
        public Ticket_ProcessETicketReplyDocumentGroupFopOtherFormOfPayment[] otherFormOfPayment
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TKTRES_04_1_IA")]
    public partial class Ticket_ProcessETicketReplyDocumentGroupFopFormOfPayment
    {

        private string typeField;

        private string indicatorField;

        private decimal amountField;

        private bool amountFieldSpecified;

        private string vendorCodeField;

        private string creditCardNumberField;

        private string expiryDateField;

        private string approvalCodeField;

        private string sourceOfApprovalField;

        private decimal authorisedAmountField;

        private bool authorisedAmountFieldSpecified;

        private string addressVerificationField;

        private string customerAccountField;

        private string extendedPaymentField;

        private string fopFreeTextField;

        private string membershipStatusField;

        private string transactionInfoField;

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
        public string sourceOfApproval
        {
            get
            {
                return this.sourceOfApprovalField;
            }
            set
            {
                this.sourceOfApprovalField = value;
            }
        }

        /// <comentarios/>
        public decimal authorisedAmount
        {
            get
            {
                return this.authorisedAmountField;
            }
            set
            {
                this.authorisedAmountField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool authorisedAmountSpecified
        {
            get
            {
                return this.authorisedAmountFieldSpecified;
            }
            set
            {
                this.authorisedAmountFieldSpecified = value;
            }
        }

        /// <comentarios/>
        public string addressVerification
        {
            get
            {
                return this.addressVerificationField;
            }
            set
            {
                this.addressVerificationField = value;
            }
        }

        /// <comentarios/>
        public string customerAccount
        {
            get
            {
                return this.customerAccountField;
            }
            set
            {
                this.customerAccountField = value;
            }
        }

        /// <comentarios/>
        public string extendedPayment
        {
            get
            {
                return this.extendedPaymentField;
            }
            set
            {
                this.extendedPaymentField = value;
            }
        }

        /// <comentarios/>
        public string fopFreeText
        {
            get
            {
                return this.fopFreeTextField;
            }
            set
            {
                this.fopFreeTextField = value;
            }
        }

        /// <comentarios/>
        public string membershipStatus
        {
            get
            {
                return this.membershipStatusField;
            }
            set
            {
                this.membershipStatusField = value;
            }
        }

        /// <comentarios/>
        public string transactionInfo
        {
            get
            {
                return this.transactionInfoField;
            }
            set
            {
                this.transactionInfoField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TKTRES_04_1_IA")]
    public partial class Ticket_ProcessETicketReplyDocumentGroupFopOtherFormOfPayment
    {

        private string typeField;

        private string indicatorField;

        private decimal amountField;

        private bool amountFieldSpecified;

        private string vendorCodeField;

        private string creditCardNumberField;

        private string expiryDateField;

        private string approvalCodeField;

        private string sourceOfApprovalField;

        private decimal authorisedAmountField;

        private bool authorisedAmountFieldSpecified;

        private string addressVerificationField;

        private string customerAccountField;

        private string extendedPaymentField;

        private string fopFreeTextField;

        private string membershipStatusField;

        private string transactionInfoField;

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
        public string sourceOfApproval
        {
            get
            {
                return this.sourceOfApprovalField;
            }
            set
            {
                this.sourceOfApprovalField = value;
            }
        }

        /// <comentarios/>
        public decimal authorisedAmount
        {
            get
            {
                return this.authorisedAmountField;
            }
            set
            {
                this.authorisedAmountField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool authorisedAmountSpecified
        {
            get
            {
                return this.authorisedAmountFieldSpecified;
            }
            set
            {
                this.authorisedAmountFieldSpecified = value;
            }
        }

        /// <comentarios/>
        public string addressVerification
        {
            get
            {
                return this.addressVerificationField;
            }
            set
            {
                this.addressVerificationField = value;
            }
        }

        /// <comentarios/>
        public string customerAccount
        {
            get
            {
                return this.customerAccountField;
            }
            set
            {
                this.customerAccountField = value;
            }
        }

        /// <comentarios/>
        public string extendedPayment
        {
            get
            {
                return this.extendedPaymentField;
            }
            set
            {
                this.extendedPaymentField = value;
            }
        }

        /// <comentarios/>
        public string fopFreeText
        {
            get
            {
                return this.fopFreeTextField;
            }
            set
            {
                this.fopFreeTextField = value;
            }
        }

        /// <comentarios/>
        public string membershipStatus
        {
            get
            {
                return this.membershipStatusField;
            }
            set
            {
                this.membershipStatusField = value;
            }
        }

        /// <comentarios/>
        public string transactionInfo
        {
            get
            {
                return this.transactionInfoField;
            }
            set
            {
                this.transactionInfoField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TKTRES_04_1_IA")]
    public partial class Ticket_ProcessETicketReplyDocumentGroupPricingInfo
    {

        private string[] priceTicketDetailsField;

        private Ticket_ProcessETicketReplyDocumentGroupPricingInfoProductDateTimeDetails productDateTimeDetailsField;

        private Ticket_ProcessETicketReplyDocumentGroupPricingInfoLocationDetails locationDetailsField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayItemAttribute("indicators", IsNullable = false)]
        public string[] priceTicketDetails
        {
            get
            {
                return this.priceTicketDetailsField;
            }
            set
            {
                this.priceTicketDetailsField = value;
            }
        }

        /// <comentarios/>
        public Ticket_ProcessETicketReplyDocumentGroupPricingInfoProductDateTimeDetails productDateTimeDetails
        {
            get
            {
                return this.productDateTimeDetailsField;
            }
            set
            {
                this.productDateTimeDetailsField = value;
            }
        }

        /// <comentarios/>
        public Ticket_ProcessETicketReplyDocumentGroupPricingInfoLocationDetails locationDetails
        {
            get
            {
                return this.locationDetailsField;
            }
            set
            {
                this.locationDetailsField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TKTRES_04_1_IA")]
    public partial class Ticket_ProcessETicketReplyDocumentGroupPricingInfoProductDateTimeDetails
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TKTRES_04_1_IA")]
    public partial class Ticket_ProcessETicketReplyDocumentGroupPricingInfoLocationDetails
    {

        private string countryField;

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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TKTRES_04_1_IA")]
    public partial class Ticket_ProcessETicketReplyDocumentGroupOriginDestination
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TKTRES_04_1_IA")]
    public partial class Ticket_ProcessETicketReplyDocumentGroupTourInfo
    {

        private Ticket_ProcessETicketReplyDocumentGroupTourInfoTourInformationDetails tourInformationDetailsField;

        /// <comentarios/>
        public Ticket_ProcessETicketReplyDocumentGroupTourInfoTourInformationDetails tourInformationDetails
        {
            get
            {
                return this.tourInformationDetailsField;
            }
            set
            {
                this.tourInformationDetailsField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TKTRES_04_1_IA")]
    public partial class Ticket_ProcessETicketReplyDocumentGroupTourInfoTourInformationDetails
    {

        private string tourCodeField;

        /// <comentarios/>
        public string tourCode
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
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TKTRES_04_1_IA")]
    public partial class Ticket_ProcessETicketReplyDocumentGroupOriginatorInfo
    {

        private Ticket_ProcessETicketReplyDocumentGroupOriginatorInfoDeliveringSystem deliveringSystemField;

        private Ticket_ProcessETicketReplyDocumentGroupOriginatorInfoOriginIdentification originIdentificationField;

        private Ticket_ProcessETicketReplyDocumentGroupOriginatorInfoCascadingSystem cascadingSystemField;

        private string originatorTypeCodeField;

        private Ticket_ProcessETicketReplyDocumentGroupOriginatorInfoOriginDetails originDetailsField;

        private string originatorField;

        /// <comentarios/>
        public Ticket_ProcessETicketReplyDocumentGroupOriginatorInfoDeliveringSystem deliveringSystem
        {
            get
            {
                return this.deliveringSystemField;
            }
            set
            {
                this.deliveringSystemField = value;
            }
        }

        /// <comentarios/>
        public Ticket_ProcessETicketReplyDocumentGroupOriginatorInfoOriginIdentification originIdentification
        {
            get
            {
                return this.originIdentificationField;
            }
            set
            {
                this.originIdentificationField = value;
            }
        }

        /// <comentarios/>
        public Ticket_ProcessETicketReplyDocumentGroupOriginatorInfoCascadingSystem cascadingSystem
        {
            get
            {
                return this.cascadingSystemField;
            }
            set
            {
                this.cascadingSystemField = value;
            }
        }

        /// <comentarios/>
        public string originatorTypeCode
        {
            get
            {
                return this.originatorTypeCodeField;
            }
            set
            {
                this.originatorTypeCodeField = value;
            }
        }

        /// <comentarios/>
        public Ticket_ProcessETicketReplyDocumentGroupOriginatorInfoOriginDetails originDetails
        {
            get
            {
                return this.originDetailsField;
            }
            set
            {
                this.originDetailsField = value;
            }
        }

        /// <comentarios/>
        public string originator
        {
            get
            {
                return this.originatorField;
            }
            set
            {
                this.originatorField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TKTRES_04_1_IA")]
    public partial class Ticket_ProcessETicketReplyDocumentGroupOriginatorInfoDeliveringSystem
    {

        private string companyIdField;

        private string locationIdField;

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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TKTRES_04_1_IA")]
    public partial class Ticket_ProcessETicketReplyDocumentGroupOriginatorInfoOriginIdentification
    {

        private decimal originatorIdField;

        private bool originatorIdFieldSpecified;

        private string inHouseIdentification1Field;

        /// <comentarios/>
        public decimal originatorId
        {
            get
            {
                return this.originatorIdField;
            }
            set
            {
                this.originatorIdField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool originatorIdSpecified
        {
            get
            {
                return this.originatorIdFieldSpecified;
            }
            set
            {
                this.originatorIdFieldSpecified = value;
            }
        }

        /// <comentarios/>
        public string inHouseIdentification1
        {
            get
            {
                return this.inHouseIdentification1Field;
            }
            set
            {
                this.inHouseIdentification1Field = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TKTRES_04_1_IA")]
    public partial class Ticket_ProcessETicketReplyDocumentGroupOriginatorInfoCascadingSystem
    {

        private string companyIdField;

        private string locationIdField;

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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TKTRES_04_1_IA")]
    public partial class Ticket_ProcessETicketReplyDocumentGroupOriginatorInfoOriginDetails
    {

        private string codedCountryField;

        private string codedLanguageField;

        /// <comentarios/>
        public string codedCountry
        {
            get
            {
                return this.codedCountryField;
            }
            set
            {
                this.codedCountryField = value;
            }
        }

        /// <comentarios/>
        public string codedLanguage
        {
            get
            {
                return this.codedLanguageField;
            }
            set
            {
                this.codedLanguageField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TKTRES_04_1_IA")]
    public partial class Ticket_ProcessETicketReplyDocumentGroupCouponTotal
    {

        private Ticket_ProcessETicketReplyDocumentGroupCouponTotalQuantityDetails quantityDetailsField;

        /// <comentarios/>
        public Ticket_ProcessETicketReplyDocumentGroupCouponTotalQuantityDetails quantityDetails
        {
            get
            {
                return this.quantityDetailsField;
            }
            set
            {
                this.quantityDetailsField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TKTRES_04_1_IA")]
    public partial class Ticket_ProcessETicketReplyDocumentGroupCouponTotalQuantityDetails
    {

        private decimal numberOfUnitField;

        private string unitQualifierField;

        /// <comentarios/>
        public decimal numberOfUnit
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TKTRES_04_1_IA")]
    public partial class Ticket_ProcessETicketReplyDocumentGroupTaxInfo
    {

        private string taxCategoryField;

        private Ticket_ProcessETicketReplyDocumentGroupTaxInfoTaxDetails[] taxDetailsField;

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
        public Ticket_ProcessETicketReplyDocumentGroupTaxInfoTaxDetails[] taxDetails
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TKTRES_04_1_IA")]
    public partial class Ticket_ProcessETicketReplyDocumentGroupTaxInfoTaxDetails
    {

        private string rateField;

        private string countryCodeField;

        private string currencyCodeField;

        private string[] typeField;

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
        [System.Xml.Serialization.XmlElementAttribute("type")]
        public string[] type
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TKTRES_04_1_IA")]
    public partial class Ticket_ProcessETicketReplyDocumentGroupTextData
    {

        private Ticket_ProcessETicketReplyDocumentGroupTextDataFreeTextQualification freeTextQualificationField;

        private string[] freeTextField;

        /// <comentarios/>
        public Ticket_ProcessETicketReplyDocumentGroupTextDataFreeTextQualification freeTextQualification
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TKTRES_04_1_IA")]
    public partial class Ticket_ProcessETicketReplyDocumentGroupTextDataFreeTextQualification
    {

        private string textSubjectQualifierField;

        private string informationTypeField;

        private string statusField;

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
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TKTRES_04_1_IA")]
    public partial class Ticket_ProcessETicketReplyDocumentGroupTicketInfoGroup
    {

        private Ticket_ProcessETicketReplyDocumentGroupTicketInfoGroupTicketInfo ticketInfoField;

        private Ticket_ProcessETicketReplyDocumentGroupTicketInfoGroupCouponInfoGroup[] couponInfoGroupField;

        /// <comentarios/>
        public Ticket_ProcessETicketReplyDocumentGroupTicketInfoGroupTicketInfo ticketInfo
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
        [System.Xml.Serialization.XmlElementAttribute("couponInfoGroup")]
        public Ticket_ProcessETicketReplyDocumentGroupTicketInfoGroupCouponInfoGroup[] couponInfoGroup
        {
            get
            {
                return this.couponInfoGroupField;
            }
            set
            {
                this.couponInfoGroupField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TKTRES_04_1_IA")]
    public partial class Ticket_ProcessETicketReplyDocumentGroupTicketInfoGroupTicketInfo
    {

        private Ticket_ProcessETicketReplyDocumentGroupTicketInfoGroupTicketInfoDocumentDetails documentDetailsField;

        /// <comentarios/>
        public Ticket_ProcessETicketReplyDocumentGroupTicketInfoGroupTicketInfoDocumentDetails documentDetails
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TKTRES_04_1_IA")]
    public partial class Ticket_ProcessETicketReplyDocumentGroupTicketInfoGroupTicketInfoDocumentDetails
    {

        private string numberField;

        private string typeField;

        private decimal numberOfBookletsField;

        private bool numberOfBookletsFieldSpecified;

        private string dataIndicatorField;

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
        public decimal numberOfBooklets
        {
            get
            {
                return this.numberOfBookletsField;
            }
            set
            {
                this.numberOfBookletsField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool numberOfBookletsSpecified
        {
            get
            {
                return this.numberOfBookletsFieldSpecified;
            }
            set
            {
                this.numberOfBookletsFieldSpecified = value;
            }
        }

        /// <comentarios/>
        public string dataIndicator
        {
            get
            {
                return this.dataIndicatorField;
            }
            set
            {
                this.dataIndicatorField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TKTRES_04_1_IA")]
    public partial class Ticket_ProcessETicketReplyDocumentGroupTicketInfoGroupCouponInfoGroup
    {

        private Ticket_ProcessETicketReplyDocumentGroupTicketInfoGroupCouponInfoGroupCouponInfo couponInfoField;

        private Ticket_ProcessETicketReplyDocumentGroupTicketInfoGroupCouponInfoGroupFlightInfo flightInfoField;

        private Ticket_ProcessETicketReplyDocumentGroupTicketInfoGroupCouponInfoGroupStatusInfo statusInfoField;

        private Ticket_ProcessETicketReplyDocumentGroupTicketInfoGroupCouponInfoGroupFareBaseInfo fareBaseInfoField;

        private Ticket_ProcessETicketReplyDocumentGroupTicketInfoGroupCouponInfoGroupBaggageInfo baggageInfoField;

        private Ticket_ProcessETicketReplyDocumentGroupTicketInfoGroupCouponInfoGroupFfInfo ffInfoField;

        private Ticket_ProcessETicketReplyDocumentGroupTicketInfoGroupCouponInfoGroupDateAndTimeDetails[] validityDateInfoField;

        private Ticket_ProcessETicketReplyDocumentGroupTicketInfoGroupCouponInfoGroupCouponOrigin couponOriginField;

        /// <comentarios/>
        public Ticket_ProcessETicketReplyDocumentGroupTicketInfoGroupCouponInfoGroupCouponInfo couponInfo
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
        public Ticket_ProcessETicketReplyDocumentGroupTicketInfoGroupCouponInfoGroupFlightInfo flightInfo
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
        public Ticket_ProcessETicketReplyDocumentGroupTicketInfoGroupCouponInfoGroupStatusInfo statusInfo
        {
            get
            {
                return this.statusInfoField;
            }
            set
            {
                this.statusInfoField = value;
            }
        }

        /// <comentarios/>
        public Ticket_ProcessETicketReplyDocumentGroupTicketInfoGroupCouponInfoGroupFareBaseInfo fareBaseInfo
        {
            get
            {
                return this.fareBaseInfoField;
            }
            set
            {
                this.fareBaseInfoField = value;
            }
        }

        /// <comentarios/>
        public Ticket_ProcessETicketReplyDocumentGroupTicketInfoGroupCouponInfoGroupBaggageInfo baggageInfo
        {
            get
            {
                return this.baggageInfoField;
            }
            set
            {
                this.baggageInfoField = value;
            }
        }

        /// <comentarios/>
        public Ticket_ProcessETicketReplyDocumentGroupTicketInfoGroupCouponInfoGroupFfInfo ffInfo
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
        [System.Xml.Serialization.XmlArrayItemAttribute("dateAndTimeDetails", IsNullable = false)]
        public Ticket_ProcessETicketReplyDocumentGroupTicketInfoGroupCouponInfoGroupDateAndTimeDetails[] validityDateInfo
        {
            get
            {
                return this.validityDateInfoField;
            }
            set
            {
                this.validityDateInfoField = value;
            }
        }

        /// <comentarios/>
        public Ticket_ProcessETicketReplyDocumentGroupTicketInfoGroupCouponInfoGroupCouponOrigin couponOrigin
        {
            get
            {
                return this.couponOriginField;
            }
            set
            {
                this.couponOriginField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TKTRES_04_1_IA")]
    public partial class Ticket_ProcessETicketReplyDocumentGroupTicketInfoGroupCouponInfoGroupCouponInfo
    {

        private Ticket_ProcessETicketReplyDocumentGroupTicketInfoGroupCouponInfoGroupCouponInfoCouponDetails couponDetailsField;

        /// <comentarios/>
        public Ticket_ProcessETicketReplyDocumentGroupTicketInfoGroupCouponInfoGroupCouponInfoCouponDetails couponDetails
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TKTRES_04_1_IA")]
    public partial class Ticket_ProcessETicketReplyDocumentGroupTicketInfoGroupCouponInfoGroupCouponInfoCouponDetails
    {

        private string cpnNumberField;

        private string cpnStatusField;

        private string cpnExchangeMediaField;

        private string settlementAuthorizationField;

        private string voluntaryIndicField;

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

        /// <comentarios/>
        public string cpnStatus
        {
            get
            {
                return this.cpnStatusField;
            }
            set
            {
                this.cpnStatusField = value;
            }
        }

        /// <comentarios/>
        public string cpnExchangeMedia
        {
            get
            {
                return this.cpnExchangeMediaField;
            }
            set
            {
                this.cpnExchangeMediaField = value;
            }
        }

        /// <comentarios/>
        public string settlementAuthorization
        {
            get
            {
                return this.settlementAuthorizationField;
            }
            set
            {
                this.settlementAuthorizationField = value;
            }
        }

        /// <comentarios/>
        public string voluntaryIndic
        {
            get
            {
                return this.voluntaryIndicField;
            }
            set
            {
                this.voluntaryIndicField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TKTRES_04_1_IA")]
    public partial class Ticket_ProcessETicketReplyDocumentGroupTicketInfoGroupCouponInfoGroupFlightInfo
    {

        private Ticket_ProcessETicketReplyDocumentGroupTicketInfoGroupCouponInfoGroupFlightInfoFlightDate flightDateField;

        private Ticket_ProcessETicketReplyDocumentGroupTicketInfoGroupCouponInfoGroupFlightInfoBoardPointDetails boardPointDetailsField;

        private Ticket_ProcessETicketReplyDocumentGroupTicketInfoGroupCouponInfoGroupFlightInfoOffpointDetails offpointDetailsField;

        private Ticket_ProcessETicketReplyDocumentGroupTicketInfoGroupCouponInfoGroupFlightInfoCompanyDetails companyDetailsField;

        private Ticket_ProcessETicketReplyDocumentGroupTicketInfoGroupCouponInfoGroupFlightInfoFlightIdentification flightIdentificationField;

        private Ticket_ProcessETicketReplyDocumentGroupTicketInfoGroupCouponInfoGroupFlightInfoFlightTypeDetails flightTypeDetailsField;

        private decimal itemNumberField;

        private bool itemNumberFieldSpecified;

        /// <comentarios/>
        public Ticket_ProcessETicketReplyDocumentGroupTicketInfoGroupCouponInfoGroupFlightInfoFlightDate flightDate
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
        public Ticket_ProcessETicketReplyDocumentGroupTicketInfoGroupCouponInfoGroupFlightInfoBoardPointDetails boardPointDetails
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
        public Ticket_ProcessETicketReplyDocumentGroupTicketInfoGroupCouponInfoGroupFlightInfoOffpointDetails offpointDetails
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
        public Ticket_ProcessETicketReplyDocumentGroupTicketInfoGroupCouponInfoGroupFlightInfoCompanyDetails companyDetails
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
        public Ticket_ProcessETicketReplyDocumentGroupTicketInfoGroupCouponInfoGroupFlightInfoFlightIdentification flightIdentification
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
        public Ticket_ProcessETicketReplyDocumentGroupTicketInfoGroupCouponInfoGroupFlightInfoFlightTypeDetails flightTypeDetails
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
        public decimal itemNumber
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
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool itemNumberSpecified
        {
            get
            {
                return this.itemNumberFieldSpecified;
            }
            set
            {
                this.itemNumberFieldSpecified = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TKTRES_04_1_IA")]
    public partial class Ticket_ProcessETicketReplyDocumentGroupTicketInfoGroupCouponInfoGroupFlightInfoFlightDate
    {

        private string departureDateField;

        private string departureTimeField;

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
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TKTRES_04_1_IA")]
    public partial class Ticket_ProcessETicketReplyDocumentGroupTicketInfoGroupCouponInfoGroupFlightInfoBoardPointDetails
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TKTRES_04_1_IA")]
    public partial class Ticket_ProcessETicketReplyDocumentGroupTicketInfoGroupCouponInfoGroupFlightInfoOffpointDetails
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TKTRES_04_1_IA")]
    public partial class Ticket_ProcessETicketReplyDocumentGroupTicketInfoGroupCouponInfoGroupFlightInfoCompanyDetails
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TKTRES_04_1_IA")]
    public partial class Ticket_ProcessETicketReplyDocumentGroupTicketInfoGroupCouponInfoGroupFlightInfoFlightIdentification
    {

        private string flightNumberField;

        private string bookingClassField;

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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TKTRES_04_1_IA")]
    public partial class Ticket_ProcessETicketReplyDocumentGroupTicketInfoGroupCouponInfoGroupFlightInfoFlightTypeDetails
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TKTRES_04_1_IA")]
    public partial class Ticket_ProcessETicketReplyDocumentGroupTicketInfoGroupCouponInfoGroupStatusInfo
    {

        private string statusCodeField;

        /// <comentarios/>
        public string statusCode
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TKTRES_04_1_IA")]
    public partial class Ticket_ProcessETicketReplyDocumentGroupTicketInfoGroupCouponInfoGroupFareBaseInfo
    {

        private Ticket_ProcessETicketReplyDocumentGroupTicketInfoGroupCouponInfoGroupFareBaseInfoFareBasisDetails fareBasisDetailsField;

        /// <comentarios/>
        public Ticket_ProcessETicketReplyDocumentGroupTicketInfoGroupCouponInfoGroupFareBaseInfoFareBasisDetails fareBasisDetails
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TKTRES_04_1_IA")]
    public partial class Ticket_ProcessETicketReplyDocumentGroupTicketInfoGroupCouponInfoGroupFareBaseInfoFareBasisDetails
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TKTRES_04_1_IA")]
    public partial class Ticket_ProcessETicketReplyDocumentGroupTicketInfoGroupCouponInfoGroupBaggageInfo
    {

        private Ticket_ProcessETicketReplyDocumentGroupTicketInfoGroupCouponInfoGroupBaggageInfoBaggageDetails baggageDetailsField;

        /// <comentarios/>
        public Ticket_ProcessETicketReplyDocumentGroupTicketInfoGroupCouponInfoGroupBaggageInfoBaggageDetails baggageDetails
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
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TKTRES_04_1_IA")]
    public partial class Ticket_ProcessETicketReplyDocumentGroupTicketInfoGroupCouponInfoGroupBaggageInfoBaggageDetails
    {

        private decimal freeAllowanceField;

        private string quantityCodeField;

        private string unitQualifierField;

        /// <comentarios/>
        public decimal freeAllowance
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TKTRES_04_1_IA")]
    public partial class Ticket_ProcessETicketReplyDocumentGroupTicketInfoGroupCouponInfoGroupFfInfo
    {

        private Ticket_ProcessETicketReplyDocumentGroupTicketInfoGroupCouponInfoGroupFfInfoFrequentTravellerDetails frequentTravellerDetailsField;

        private Ticket_ProcessETicketReplyDocumentGroupTicketInfoGroupCouponInfoGroupFfInfoOtherFrequentTravellerDetails[] otherFrequentTravellerDetailsField;

        /// <comentarios/>
        public Ticket_ProcessETicketReplyDocumentGroupTicketInfoGroupCouponInfoGroupFfInfoFrequentTravellerDetails frequentTravellerDetails
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

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("otherFrequentTravellerDetails")]
        public Ticket_ProcessETicketReplyDocumentGroupTicketInfoGroupCouponInfoGroupFfInfoOtherFrequentTravellerDetails[] otherFrequentTravellerDetails
        {
            get
            {
                return this.otherFrequentTravellerDetailsField;
            }
            set
            {
                this.otherFrequentTravellerDetailsField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TKTRES_04_1_IA")]
    public partial class Ticket_ProcessETicketReplyDocumentGroupTicketInfoGroupCouponInfoGroupFfInfoFrequentTravellerDetails
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TKTRES_04_1_IA")]
    public partial class Ticket_ProcessETicketReplyDocumentGroupTicketInfoGroupCouponInfoGroupFfInfoOtherFrequentTravellerDetails
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TKTRES_04_1_IA")]
    public partial class Ticket_ProcessETicketReplyDocumentGroupTicketInfoGroupCouponInfoGroupDateAndTimeDetails
    {

        private string qualifierField;

        private string dateField;

        private decimal timeField;

        private bool timeFieldSpecified;

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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TKTRES_04_1_IA")]
    public partial class Ticket_ProcessETicketReplyDocumentGroupTicketInfoGroupCouponInfoGroupCouponOrigin
    {

        private Ticket_ProcessETicketReplyDocumentGroupTicketInfoGroupCouponInfoGroupCouponOriginDeliveringSystem deliveringSystemField;

        private Ticket_ProcessETicketReplyDocumentGroupTicketInfoGroupCouponInfoGroupCouponOriginOriginIdentification originIdentificationField;

        private Ticket_ProcessETicketReplyDocumentGroupTicketInfoGroupCouponInfoGroupCouponOriginCascadingSystem cascadingSystemField;

        private string originatorTypeCodeField;

        private Ticket_ProcessETicketReplyDocumentGroupTicketInfoGroupCouponInfoGroupCouponOriginOriginDetails originDetailsField;

        private string originatorField;

        /// <comentarios/>
        public Ticket_ProcessETicketReplyDocumentGroupTicketInfoGroupCouponInfoGroupCouponOriginDeliveringSystem deliveringSystem
        {
            get
            {
                return this.deliveringSystemField;
            }
            set
            {
                this.deliveringSystemField = value;
            }
        }

        /// <comentarios/>
        public Ticket_ProcessETicketReplyDocumentGroupTicketInfoGroupCouponInfoGroupCouponOriginOriginIdentification originIdentification
        {
            get
            {
                return this.originIdentificationField;
            }
            set
            {
                this.originIdentificationField = value;
            }
        }

        /// <comentarios/>
        public Ticket_ProcessETicketReplyDocumentGroupTicketInfoGroupCouponInfoGroupCouponOriginCascadingSystem cascadingSystem
        {
            get
            {
                return this.cascadingSystemField;
            }
            set
            {
                this.cascadingSystemField = value;
            }
        }

        /// <comentarios/>
        public string originatorTypeCode
        {
            get
            {
                return this.originatorTypeCodeField;
            }
            set
            {
                this.originatorTypeCodeField = value;
            }
        }

        /// <comentarios/>
        public Ticket_ProcessETicketReplyDocumentGroupTicketInfoGroupCouponInfoGroupCouponOriginOriginDetails originDetails
        {
            get
            {
                return this.originDetailsField;
            }
            set
            {
                this.originDetailsField = value;
            }
        }

        /// <comentarios/>
        public string originator
        {
            get
            {
                return this.originatorField;
            }
            set
            {
                this.originatorField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TKTRES_04_1_IA")]
    public partial class Ticket_ProcessETicketReplyDocumentGroupTicketInfoGroupCouponInfoGroupCouponOriginDeliveringSystem
    {

        private string companyIdField;

        private string locationIdField;

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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TKTRES_04_1_IA")]
    public partial class Ticket_ProcessETicketReplyDocumentGroupTicketInfoGroupCouponInfoGroupCouponOriginOriginIdentification
    {

        private decimal originatorIdField;

        private bool originatorIdFieldSpecified;

        private string inHouseIdentification1Field;

        /// <comentarios/>
        public decimal originatorId
        {
            get
            {
                return this.originatorIdField;
            }
            set
            {
                this.originatorIdField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool originatorIdSpecified
        {
            get
            {
                return this.originatorIdFieldSpecified;
            }
            set
            {
                this.originatorIdFieldSpecified = value;
            }
        }

        /// <comentarios/>
        public string inHouseIdentification1
        {
            get
            {
                return this.inHouseIdentification1Field;
            }
            set
            {
                this.inHouseIdentification1Field = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TKTRES_04_1_IA")]
    public partial class Ticket_ProcessETicketReplyDocumentGroupTicketInfoGroupCouponInfoGroupCouponOriginCascadingSystem
    {

        private string companyIdField;

        private string locationIdField;

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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TKTRES_04_1_IA")]
    public partial class Ticket_ProcessETicketReplyDocumentGroupTicketInfoGroupCouponInfoGroupCouponOriginOriginDetails
    {

        private string codedCountryField;

        private string codedLanguageField;

        /// <comentarios/>
        public string codedCountry
        {
            get
            {
                return this.codedCountryField;
            }
            set
            {
                this.codedCountryField = value;
            }
        }

        /// <comentarios/>
        public string codedLanguage
        {
            get
            {
                return this.codedLanguageField;
            }
            set
            {
                this.codedLanguageField = value;
            }
        }
    }
}

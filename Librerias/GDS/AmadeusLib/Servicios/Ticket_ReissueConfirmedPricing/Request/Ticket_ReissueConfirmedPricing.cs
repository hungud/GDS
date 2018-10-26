using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmadeusLib.Servicios.Ticket_ReissueConfirmedPricing.Request
{
    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TARCPQ_13_2_1A")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://xml.amadeus.com/TARCPQ_13_2_1A", IsNullable = false)]
    public partial class Ticket_ReissueConfirmedPricing
    {

        private Ticket_ReissueConfirmedPricingTicketInfo[] ticketInfoField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("ticketInfo")]
        public Ticket_ReissueConfirmedPricingTicketInfo[] ticketInfo
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
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TARCPQ_13_2_1A")]
    public partial class Ticket_ReissueConfirmedPricingTicketInfo
    {

        private TicketNumberTypeI paperticketDetailsFirstCouponField;

        private CouponInformationTypeI couponInfoFirstField;

        private Ticket_ReissueConfirmedPricingTicketInfoPaperInformation paperInformationField;

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
        public Ticket_ReissueConfirmedPricingTicketInfoPaperInformation paperInformation
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
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TARCPQ_13_2_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TARCPQ_13_2_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TARCPQ_13_2_1A")]
    public partial class DummySegmentTypeI
    {
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TARCPQ_13_2_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TARCPQ_13_2_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TARCPQ_13_2_1A")]
    public partial class Ticket_ReissueConfirmedPricingTicketInfoPaperInformation
    {

        private DummySegmentTypeI paperInformationDummyField;

        private TicketNumberTypeI paperticketDetailsLastCouponField;

        private CouponInformationTypeI papercouponInfoLastField;

        private Ticket_ReissueConfirmedPricingTicketInfoPaperInformationTicketRange ticketRangeField;

        /// <comentarios/>
        public DummySegmentTypeI paperInformationDummy
        {
            get
            {
                return this.paperInformationDummyField;
            }
            set
            {
                this.paperInformationDummyField = value;
            }
        }

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
        public Ticket_ReissueConfirmedPricingTicketInfoPaperInformationTicketRange ticketRange
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TARCPQ_13_2_1A")]
    public partial class Ticket_ReissueConfirmedPricingTicketInfoPaperInformationTicketRange
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
}

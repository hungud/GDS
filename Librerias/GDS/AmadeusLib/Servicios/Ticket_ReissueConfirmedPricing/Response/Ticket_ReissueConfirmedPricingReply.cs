using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmadeusLib.Servicios.Ticket_ReissueConfirmedPricing.Response
{
    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TARCPR_13_2_1A")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://xml.amadeus.com/TARCPR_13_2_1A", IsNullable = false)]
    public partial class Ticket_ReissueConfirmedPricingReply
    {

        private Ticket_ReissueConfirmedPricingReplyApplicationError applicationErrorField;

        private Ticket_ReissueConfirmedPricingReplyTicketInfo[] ticketInfoField;

        private Ticket_ReissueConfirmedPricingReplyTstInformation[] tstInformationField;

        /// <comentarios/>
        public Ticket_ReissueConfirmedPricingReplyApplicationError applicationError
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
        [System.Xml.Serialization.XmlElementAttribute("ticketInfo")]
        public Ticket_ReissueConfirmedPricingReplyTicketInfo[] ticketInfo
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
        [System.Xml.Serialization.XmlElementAttribute("tstInformation")]
        public Ticket_ReissueConfirmedPricingReplyTstInformation[] tstInformation
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
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TARCPR_13_2_1A")]
    public partial class Ticket_ReissueConfirmedPricingReplyApplicationError
    {

        private ApplicationErrorInformationType applicationErrorInfoField;

        private FreeTextInformationType errorTextField;

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
        public FreeTextInformationType errorText
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TARCPR_13_2_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TARCPR_13_2_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TARCPR_13_2_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TARCPR_13_2_1A")]
    public partial class UniqueIdDescriptionType
    {

        private string iDSequenceNumberField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
        public string iDSequenceNumber
        {
            get
            {
                return this.iDSequenceNumberField;
            }
            set
            {
                this.iDSequenceNumberField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TARCPR_13_2_1A")]
    public partial class ItemReferencesAndVersionsType
    {

        private string referenceTypeField;

        private string uniqueReferenceField;

        private UniqueIdDescriptionType iDDescriptionField;

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

        /// <comentarios/>
        public UniqueIdDescriptionType iDDescription
        {
            get
            {
                return this.iDDescriptionField;
            }
            set
            {
                this.iDDescriptionField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TARCPR_13_2_1A")]
    public partial class DummySegmentTypeI
    {
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TARCPR_13_2_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TARCPR_13_2_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TARCPR_13_2_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TARCPR_13_2_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TARCPR_13_2_1A")]
    public partial class FreeTextDetailsType
    {

        private string textSubjectQualifierField;

        private string informationTypeField;

        private string statusField;

        private string companyIdField;

        private string languageField;

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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TARCPR_13_2_1A")]
    public partial class FreeTextInformationType
    {

        private FreeTextDetailsType freeTextDetailsField;

        private string[] freeTextField;

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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TARCPR_13_2_1A")]
    public partial class Ticket_ReissueConfirmedPricingReplyTicketInfo
    {

        private TicketNumberTypeI ticketDetailsField;

        private CouponInformationTypeI couponInfoField;

        private Ticket_ReissueConfirmedPricingReplyTicketInfoPaperCouponLast paperCouponLastField;

        /// <comentarios/>
        public TicketNumberTypeI ticketDetails
        {
            get
            {
                return this.ticketDetailsField;
            }
            set
            {
                this.ticketDetailsField = value;
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
        public Ticket_ReissueConfirmedPricingReplyTicketInfoPaperCouponLast paperCouponLast
        {
            get
            {
                return this.paperCouponLastField;
            }
            set
            {
                this.paperCouponLastField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TARCPR_13_2_1A")]
    public partial class Ticket_ReissueConfirmedPricingReplyTicketInfoPaperCouponLast
    {

        private DummySegmentTypeI paperInformationDummyField;

        private TicketNumberTypeI ticketInformationField;

        private CouponInformationTypeI couponInfoField;

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
        public TicketNumberTypeI ticketInformation
        {
            get
            {
                return this.ticketInformationField;
            }
            set
            {
                this.ticketInformationField = value;
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TARCPR_13_2_1A")]
    public partial class Ticket_ReissueConfirmedPricingReplyTstInformation
    {

        private ItemReferencesAndVersionsType tstReferenceField;

        private ReferencingDetailsTypeI[] paxReferenceField;

        private ReferencingDetailsTypeI[] segReferenceField;

        /// <comentarios/>
        public ItemReferencesAndVersionsType tstReference
        {
            get
            {
                return this.tstReferenceField;
            }
            set
            {
                this.tstReferenceField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayItemAttribute("refDetails", IsNullable = false)]
        public ReferencingDetailsTypeI[] paxReference
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
        [System.Xml.Serialization.XmlArrayItemAttribute("refDetails", IsNullable = false)]
        public ReferencingDetailsTypeI[] segReference
        {
            get
            {
                return this.segReferenceField;
            }
            set
            {
                this.segReferenceField = value;
            }
        }
    }
}

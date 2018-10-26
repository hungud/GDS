using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmadeusLib.Servicios.Ticket_CreateTSTFromPricing.Response
{
    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TAUTCR_04_1_1A")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://xml.amadeus.com/TAUTCR_04_1_1A", IsNullable = false)]
    public partial class Ticket_CreateTSTFromPricingReply
    {

        private Ticket_CreateTSTFromPricingReplyApplicationError applicationErrorField;

        private Ticket_CreateTSTFromPricingReplyPnrLocatorData pnrLocatorDataField;

        private Ticket_CreateTSTFromPricingReplyTstList[] tstListField;

        /// <comentarios/>
        public Ticket_CreateTSTFromPricingReplyApplicationError applicationError
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
        public Ticket_CreateTSTFromPricingReplyPnrLocatorData pnrLocatorData
        {
            get
            {
                return this.pnrLocatorDataField;
            }
            set
            {
                this.pnrLocatorDataField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("tstList")]
        public Ticket_CreateTSTFromPricingReplyTstList[] tstList
        {
            get
            {
                return this.tstListField;
            }
            set
            {
                this.tstListField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TAUTCR_04_1_1A")]
    public partial class Ticket_CreateTSTFromPricingReplyApplicationError
    {

        private Ticket_CreateTSTFromPricingReplyApplicationErrorApplicationErrorInfo applicationErrorInfoField;

        private Ticket_CreateTSTFromPricingReplyApplicationErrorErrorText errorTextField;

        /// <comentarios/>
        public Ticket_CreateTSTFromPricingReplyApplicationErrorApplicationErrorInfo applicationErrorInfo
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
        public Ticket_CreateTSTFromPricingReplyApplicationErrorErrorText errorText
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TAUTCR_04_1_1A")]
    public partial class Ticket_CreateTSTFromPricingReplyApplicationErrorApplicationErrorInfo
    {

        private Ticket_CreateTSTFromPricingReplyApplicationErrorApplicationErrorInfoApplicationErrorDetail applicationErrorDetailField;

        /// <comentarios/>
        public Ticket_CreateTSTFromPricingReplyApplicationErrorApplicationErrorInfoApplicationErrorDetail applicationErrorDetail
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TAUTCR_04_1_1A")]
    public partial class Ticket_CreateTSTFromPricingReplyApplicationErrorApplicationErrorInfoApplicationErrorDetail
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TAUTCR_04_1_1A")]
    public partial class Ticket_CreateTSTFromPricingReplyApplicationErrorErrorText
    {

        private string errorFreeTextField;

        /// <comentarios/>
        public string errorFreeText
        {
            get
            {
                return this.errorFreeTextField;
            }
            set
            {
                this.errorFreeTextField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TAUTCR_04_1_1A")]
    public partial class Ticket_CreateTSTFromPricingReplyPnrLocatorData
    {

        private Ticket_CreateTSTFromPricingReplyPnrLocatorDataReservationInformation reservationInformationField;

        /// <comentarios/>
        public Ticket_CreateTSTFromPricingReplyPnrLocatorDataReservationInformation reservationInformation
        {
            get
            {
                return this.reservationInformationField;
            }
            set
            {
                this.reservationInformationField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TAUTCR_04_1_1A")]
    public partial class Ticket_CreateTSTFromPricingReplyPnrLocatorDataReservationInformation
    {

        private string controlNumberField;

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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TAUTCR_04_1_1A")]
    public partial class Ticket_CreateTSTFromPricingReplyTstList
    {

        private Ticket_CreateTSTFromPricingReplyTstListTstReference tstReferenceField;

        private Ticket_CreateTSTFromPricingReplyTstListRefDetails[] paxInformationField;

        /// <comentarios/>
        public Ticket_CreateTSTFromPricingReplyTstListTstReference tstReference
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
        public Ticket_CreateTSTFromPricingReplyTstListRefDetails[] paxInformation
        {
            get
            {
                return this.paxInformationField;
            }
            set
            {
                this.paxInformationField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TAUTCR_04_1_1A")]
    public partial class Ticket_CreateTSTFromPricingReplyTstListTstReference
    {

        private string referenceTypeField;

        private decimal uniqueReferenceField;

        private bool uniqueReferenceFieldSpecified;

        private Ticket_CreateTSTFromPricingReplyTstListTstReferenceIDDescription iDDescriptionField;

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
        public decimal uniqueReference
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
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool uniqueReferenceSpecified
        {
            get
            {
                return this.uniqueReferenceFieldSpecified;
            }
            set
            {
                this.uniqueReferenceFieldSpecified = value;
            }
        }

        /// <comentarios/>
        public Ticket_CreateTSTFromPricingReplyTstListTstReferenceIDDescription iDDescription
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TAUTCR_04_1_1A")]
    public partial class Ticket_CreateTSTFromPricingReplyTstListTstReferenceIDDescription
    {

        private decimal iDSequenceNumberField;

        /// <comentarios/>
        public decimal iDSequenceNumber
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TAUTCR_04_1_1A")]
    public partial class Ticket_CreateTSTFromPricingReplyTstListRefDetails
    {

        private string refQualifierField;

        private decimal refNumberField;

        private bool refNumberFieldSpecified;

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
        public decimal refNumber
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
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool refNumberSpecified
        {
            get
            {
                return this.refNumberFieldSpecified;
            }
            set
            {
                this.refNumberFieldSpecified = value;
            }
        }
    }
}

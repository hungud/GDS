using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmadeusLib.Servicios.DocIssuance_IssueTicket.Response
{
    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TTKTIR_09_1_1A")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://xml.amadeus.com/TTKTIR_09_1_1A", IsNullable = false)]
    public partial class DocIssuance_IssueTicketReply
    {

        private DocIssuance_IssueTicketReplyProcessingStatus processingStatusField;

        private DocIssuance_IssueTicketReplyErrorGroup errorGroupField;

        /// <comentarios/>
        public DocIssuance_IssueTicketReplyProcessingStatus processingStatus
        {
            get
            {
                return this.processingStatusField;
            }
            set
            {
                this.processingStatusField = value;
            }
        }

        /// <comentarios/>
        public DocIssuance_IssueTicketReplyErrorGroup errorGroup
        {
            get
            {
                return this.errorGroupField;
            }
            set
            {
                this.errorGroupField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TTKTIR_09_1_1A")]
    public partial class DocIssuance_IssueTicketReplyProcessingStatus
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TTKTIR_09_1_1A")]
    public partial class DocIssuance_IssueTicketReplyErrorGroup
    {

        private DocIssuance_IssueTicketReplyErrorGroupErrorOrWarningCodeDetails errorOrWarningCodeDetailsField;

        private DocIssuance_IssueTicketReplyErrorGroupErrorWarningDescription errorWarningDescriptionField;

        /// <comentarios/>
        public DocIssuance_IssueTicketReplyErrorGroupErrorOrWarningCodeDetails errorOrWarningCodeDetails
        {
            get
            {
                return this.errorOrWarningCodeDetailsField;
            }
            set
            {
                this.errorOrWarningCodeDetailsField = value;
            }
        }

        /// <comentarios/>
        public DocIssuance_IssueTicketReplyErrorGroupErrorWarningDescription errorWarningDescription
        {
            get
            {
                return this.errorWarningDescriptionField;
            }
            set
            {
                this.errorWarningDescriptionField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TTKTIR_09_1_1A")]
    public partial class DocIssuance_IssueTicketReplyErrorGroupErrorOrWarningCodeDetails
    {

        private DocIssuance_IssueTicketReplyErrorGroupErrorOrWarningCodeDetailsErrorDetails errorDetailsField;

        /// <comentarios/>
        public DocIssuance_IssueTicketReplyErrorGroupErrorOrWarningCodeDetailsErrorDetails errorDetails
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TTKTIR_09_1_1A")]
    public partial class DocIssuance_IssueTicketReplyErrorGroupErrorOrWarningCodeDetailsErrorDetails
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TTKTIR_09_1_1A")]
    public partial class DocIssuance_IssueTicketReplyErrorGroupErrorWarningDescription
    {

        private DocIssuance_IssueTicketReplyErrorGroupErrorWarningDescriptionFreeTextDetails freeTextDetailsField;

        private string freeTextField;

        /// <comentarios/>
        public DocIssuance_IssueTicketReplyErrorGroupErrorWarningDescriptionFreeTextDetails freeTextDetails
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TTKTIR_09_1_1A")]
    public partial class DocIssuance_IssueTicketReplyErrorGroupErrorWarningDescriptionFreeTextDetails
    {

        private string textSubjectQualifierField;

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
}

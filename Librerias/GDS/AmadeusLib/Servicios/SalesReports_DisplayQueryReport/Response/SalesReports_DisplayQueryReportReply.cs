using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmadeusLib.Servicios.SalesReports_DisplayQueryReport.Response
{
    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TSRQRR_10_1_1A")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://xml.amadeus.com/TSRQRR_10_1_1A", IsNullable = false)]
    public partial class SalesReports_DisplayQueryReportReply
    {

        private ErrorGroupType errorGroupField;

        private SalesReports_DisplayQueryReportReplyQueryReportDataDetails queryReportDataDetailsField;

        /// <comentarios/>
        public ErrorGroupType errorGroup
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

        /// <comentarios/>
        public SalesReports_DisplayQueryReportReplyQueryReportDataDetails queryReportDataDetails
        {
            get
            {
                return this.queryReportDataDetailsField;
            }
            set
            {
                this.queryReportDataDetailsField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TSRQRR_10_1_1A")]
    public partial class ErrorGroupType
    {

        private ApplicationErrorInformationType errorOrWarningCodeDetailsField;

        private FreeTextInformationType errorWarningDescriptionField;

        /// <comentarios/>
        public ApplicationErrorInformationType errorOrWarningCodeDetails
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
        public FreeTextInformationType errorWarningDescription
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TSRQRR_10_1_1A")]
    public partial class ApplicationErrorInformationType
    {

        private ApplicationErrorDetailType errorDetailsField;

        /// <comentarios/>
        public ApplicationErrorDetailType errorDetails
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TSRQRR_10_1_1A")]
    public partial class ApplicationErrorDetailType
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TSRQRR_10_1_1A")]
    public partial class StructuredPeriodInformationType
    {

        private StructuredDateTimeType beginDateTimeField;

        private StructuredDateTimeType endDateTimeField;

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
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TSRQRR_10_1_1A")]
    public partial class StructuredDateTimeType
    {

        private string yearField;

        private string monthField;

        private string dayField;

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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TSRQRR_10_1_1A")]
    public partial class ReferenceTypeI
    {

        private string lastItemIdentifierField;

        /// <comentarios/>
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TSRQRR_10_1_1A")]
    public partial class ProcessingInformationTypeI
    {

        private string numberOfItemsField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
        public string numberOfItems
        {
            get
            {
                return this.numberOfItemsField;
            }
            set
            {
                this.numberOfItemsField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TSRQRR_10_1_1A")]
    public partial class ActionDetailsTypeI
    {

        private ProcessingInformationTypeI numberOfItemsDetailsField;

        private ReferenceTypeI lastItemsDetailsField;

        /// <comentarios/>
        public ProcessingInformationTypeI numberOfItemsDetails
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
        public ReferenceTypeI lastItemsDetails
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TSRQRR_10_1_1A")]
    public partial class ReservationControlInformationDetailsTypeI
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TSRQRR_10_1_1A")]
    public partial class TravellerSurnameInformationTypeI
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TSRQRR_10_1_1A")]
    public partial class TravellerInformationTypeI
    {

        private TravellerSurnameInformationTypeI paxDetailsField;

        /// <comentarios/>
        public TravellerSurnameInformationTypeI paxDetails
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
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TSRQRR_10_1_1A")]
    public partial class FormOfPaymentDetailsTypeI
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
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TSRQRR_10_1_1A")]
    public partial class FormOfPaymentTypeI
    {

        private FormOfPaymentDetailsTypeI formOfPaymentField;

        /// <comentarios/>
        public FormOfPaymentDetailsTypeI formOfPayment
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TSRQRR_10_1_1A")]
    public partial class GeneralFopRepresentationType
    {

        private FormOfPaymentTypeI fopDescriptionField;

        private MonetaryInformationTypeI monetaryInfoField;

        /// <comentarios/>
        public FormOfPaymentTypeI fopDescription
        {
            get
            {
                return this.fopDescriptionField;
            }
            set
            {
                this.fopDescriptionField = value;
            }
        }

        /// <comentarios/>
        public MonetaryInformationTypeI monetaryInfo
        {
            get
            {
                return this.monetaryInfoField;
            }
            set
            {
                this.monetaryInfoField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TSRQRR_10_1_1A")]
    public partial class MonetaryInformationTypeI
    {

        private MonetaryInformationDetailsTypeI monetaryDetailsField;

        private MonetaryInformationDetailsTypeI[] otherMonetaryDetailsField;

        /// <comentarios/>
        public MonetaryInformationDetailsTypeI monetaryDetails
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
        public MonetaryInformationDetailsTypeI[] otherMonetaryDetails
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TSRQRR_10_1_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TSRQRR_10_1_1A")]
    public partial class TransactionInformationsType
    {

        private string codeField;

        private string typeField;

        private string issueIndicatorField;

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
        public string issueIndicator
        {
            get
            {
                return this.issueIndicatorField;
            }
            set
            {
                this.issueIndicatorField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TSRQRR_10_1_1A")]
    public partial class TransactionInformationForTicketingType
    {

        private TransactionInformationsType transactionDetailsField;

        /// <comentarios/>
        public TransactionInformationsType transactionDetails
        {
            get
            {
                return this.transactionDetailsField;
            }
            set
            {
                this.transactionDetailsField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TSRQRR_10_1_1A")]
    public partial class OriginatorIdentificationDetailsTypeI_85102C
    {

        private string originatorIdField;

        /// <comentarios/>
        public string originatorId
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
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TSRQRR_10_1_1A")]
    public partial class UserIdentificationType
    {

        private OriginatorIdentificationDetailsTypeI_85102C originIdentificationField;

        private string originatorField;

        /// <comentarios/>
        public OriginatorIdentificationDetailsTypeI_85102C originIdentification
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TSRQRR_10_1_1A")]
    public partial class TicketNumberDetailsTypeI
    {

        private string numberField;

        private string numberOfBookletsField;

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
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
        public string numberOfBooklets
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
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TSRQRR_10_1_1A")]
    public partial class TicketNumberTypeI
    {

        private TicketNumberDetailsTypeI documentDetailsField;

        private string statusField;

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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TSRQRR_10_1_1A")]
    public partial class ItemNumberIdentificationTypeI
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TSRQRR_10_1_1A")]
    public partial class ItemNumberTypeI
    {

        private ItemNumberIdentificationTypeI itemNumberDetailsField;

        /// <comentarios/>
        public ItemNumberIdentificationTypeI itemNumberDetails
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TSRQRR_10_1_1A")]
    public partial class OriginatorIdentificationDetailsTypeI
    {

        private string originatorIdField;

        private string inHouseIdentification1Field;

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
        public string originatorId
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TSRQRR_10_1_1A")]
    public partial class SourceTypeDetailsTypeI
    {

        private string sourceQualifier1Field;

        private string sourceQualifier2Field;

        /// <comentarios/>
        public string sourceQualifier1
        {
            get
            {
                return this.sourceQualifier1Field;
            }
            set
            {
                this.sourceQualifier1Field = value;
            }
        }

        /// <comentarios/>
        public string sourceQualifier2
        {
            get
            {
                return this.sourceQualifier2Field;
            }
            set
            {
                this.sourceQualifier2Field = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TSRQRR_10_1_1A")]
    public partial class AdditionalBusinessSourceInformationTypeI
    {

        private SourceTypeDetailsTypeI sourceTypeField;

        private OriginatorIdentificationDetailsTypeI originatorDetailsField;

        /// <comentarios/>
        public SourceTypeDetailsTypeI sourceType
        {
            get
            {
                return this.sourceTypeField;
            }
            set
            {
                this.sourceTypeField = value;
            }
        }

        /// <comentarios/>
        public OriginatorIdentificationDetailsTypeI originatorDetails
        {
            get
            {
                return this.originatorDetailsField;
            }
            set
            {
                this.originatorDetailsField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TSRQRR_10_1_1A")]
    public partial class StructuredDateTimeInformationType
    {

        private string businessSemanticField;

        private StructuredDateTimeType dateTimeField;

        /// <comentarios/>
        public string businessSemantic
        {
            get
            {
                return this.businessSemanticField;
            }
            set
            {
                this.businessSemanticField = value;
            }
        }

        /// <comentarios/>
        public StructuredDateTimeType dateTime
        {
            get
            {
                return this.dateTimeField;
            }
            set
            {
                this.dateTimeField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TSRQRR_10_1_1A")]
    public partial class CurrencyDetailsTypeU
    {

        private string currencyQualifierField;

        private string currencyIsoCodeField;

        /// <comentarios/>
        public string currencyQualifier
        {
            get
            {
                return this.currencyQualifierField;
            }
            set
            {
                this.currencyQualifierField = value;
            }
        }

        /// <comentarios/>
        public string currencyIsoCode
        {
            get
            {
                return this.currencyIsoCodeField;
            }
            set
            {
                this.currencyIsoCodeField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TSRQRR_10_1_1A")]
    public partial class CurrenciesTypeU
    {

        private CurrencyDetailsTypeU currencyDetailsField;

        /// <comentarios/>
        public CurrencyDetailsTypeU currencyDetails
        {
            get
            {
                return this.currencyDetailsField;
            }
            set
            {
                this.currencyDetailsField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TSRQRR_10_1_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TSRQRR_10_1_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TSRQRR_10_1_1A")]
    public partial class SalesReports_DisplayQueryReportReplyQueryReportDataDetails
    {

        private CurrenciesTypeU currencyInfoField;

        private StructuredDateTimeInformationType[] dateDetailsField;

        private SalesReports_DisplayQueryReportReplyQueryReportDataDetailsQueryReportDataOfficeGroup[] queryReportDataOfficeGroupField;

        private UserIdentificationType agentDetailsField;

        private ActionDetailsTypeI actionDetailsField;

        private StructuredPeriodInformationType salesPeriodDetailsField;

        /// <comentarios/>
        public CurrenciesTypeU currencyInfo
        {
            get
            {
                return this.currencyInfoField;
            }
            set
            {
                this.currencyInfoField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("dateDetails")]
        public StructuredDateTimeInformationType[] dateDetails
        {
            get
            {
                return this.dateDetailsField;
            }
            set
            {
                this.dateDetailsField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("queryReportDataOfficeGroup")]
        public SalesReports_DisplayQueryReportReplyQueryReportDataDetailsQueryReportDataOfficeGroup[] queryReportDataOfficeGroup
        {
            get
            {
                return this.queryReportDataOfficeGroupField;
            }
            set
            {
                this.queryReportDataOfficeGroupField = value;
            }
        }

        /// <comentarios/>
        public UserIdentificationType agentDetails
        {
            get
            {
                return this.agentDetailsField;
            }
            set
            {
                this.agentDetailsField = value;
            }
        }

        /// <comentarios/>
        public ActionDetailsTypeI actionDetails
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
        public StructuredPeriodInformationType salesPeriodDetails
        {
            get
            {
                return this.salesPeriodDetailsField;
            }
            set
            {
                this.salesPeriodDetailsField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TSRQRR_10_1_1A")]
    public partial class SalesReports_DisplayQueryReportReplyQueryReportDataDetailsQueryReportDataOfficeGroup
    {

        private AdditionalBusinessSourceInformationTypeI requestorAgencyDetailsField;

        private SalesReports_DisplayQueryReportReplyQueryReportDataDetailsQueryReportDataOfficeGroupDocumentData[] documentDataField;

        /// <comentarios/>
        public AdditionalBusinessSourceInformationTypeI requestorAgencyDetails
        {
            get
            {
                return this.requestorAgencyDetailsField;
            }
            set
            {
                this.requestorAgencyDetailsField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("documentData")]
        public SalesReports_DisplayQueryReportReplyQueryReportDataDetailsQueryReportDataOfficeGroupDocumentData[] documentData
        {
            get
            {
                return this.documentDataField;
            }
            set
            {
                this.documentDataField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TSRQRR_10_1_1A")]
    public partial class SalesReports_DisplayQueryReportReplyQueryReportDataDetailsQueryReportDataOfficeGroupDocumentData
    {

        private ItemNumberTypeI sequenceIdentificationField;

        private TicketNumberTypeI documentNumberField;

        private MonetaryInformationTypeI monetaryInformationField;

        private UserIdentificationType bookingAgentField;

        private TransactionInformationForTicketingType transactionDataDetailsField;

        private GeneralFopRepresentationType fopDetailsField;

        private TravellerInformationTypeI passengerNameField;

        private ReservationControlInformationDetailsTypeI[] reservationInformationField;

        /// <comentarios/>
        public ItemNumberTypeI sequenceIdentification
        {
            get
            {
                return this.sequenceIdentificationField;
            }
            set
            {
                this.sequenceIdentificationField = value;
            }
        }

        /// <comentarios/>
        public TicketNumberTypeI documentNumber
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
        public MonetaryInformationTypeI monetaryInformation
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

        /// <comentarios/>
        public UserIdentificationType bookingAgent
        {
            get
            {
                return this.bookingAgentField;
            }
            set
            {
                this.bookingAgentField = value;
            }
        }

        /// <comentarios/>
        public TransactionInformationForTicketingType transactionDataDetails
        {
            get
            {
                return this.transactionDataDetailsField;
            }
            set
            {
                this.transactionDataDetailsField = value;
            }
        }

        /// <comentarios/>
        public GeneralFopRepresentationType fopDetails
        {
            get
            {
                return this.fopDetailsField;
            }
            set
            {
                this.fopDetailsField = value;
            }
        }

        /// <comentarios/>
        public TravellerInformationTypeI passengerName
        {
            get
            {
                return this.passengerNameField;
            }
            set
            {
                this.passengerNameField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayItemAttribute("reservation", IsNullable = false)]
        public ReservationControlInformationDetailsTypeI[] reservationInformation
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
}

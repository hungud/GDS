using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmadeusLib.Servicios.SalesReports_DisplayQueryReport.Request
{
    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TSRQRQ_10_1_1A")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://xml.amadeus.com/TSRQRQ_10_1_1A", IsNullable = false)]
    public partial class SalesReports_DisplayQueryReport
    {

        private ActionDetailsTypeI actionDetailsField;

        private UserIdentificationType agentUserDetailsField;

        private StructuredDateTimeInformationType dateDetailsField;

        private CurrenciesTypeU currencyInfoField;

        private AdditionalBusinessSourceInformationTypeI agencyDetailsField;

        private StructuredPeriodInformationType salesPeriodDetailsField;

        private TransactionInformationForTicketingType[] transactionDataField;

        private FormOfPaymentTypeI formOfPaymentDetailsField;

        private TransportIdentifierType validatingCarrierDetailsField;

        private SelectionDetailsTypeI requestOptionField;

        private StatusDetailsTypeI[] salesIndicatorField;

        private ItemNumberIdentificationTypeI[] fromSequenceDocumentNumberField;

        private CodedAttributeInformationType[] attributeInfoField;

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
        public UserIdentificationType agentUserDetails
        {
            get
            {
                return this.agentUserDetailsField;
            }
            set
            {
                this.agentUserDetailsField = value;
            }
        }

        /// <comentarios/>
        public StructuredDateTimeInformationType dateDetails
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
        public AdditionalBusinessSourceInformationTypeI agencyDetails
        {
            get
            {
                return this.agencyDetailsField;
            }
            set
            {
                this.agencyDetailsField = value;
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

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("transactionData")]
        public TransactionInformationForTicketingType[] transactionData
        {
            get
            {
                return this.transactionDataField;
            }
            set
            {
                this.transactionDataField = value;
            }
        }

        /// <comentarios/>
        public FormOfPaymentTypeI formOfPaymentDetails
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
        public TransportIdentifierType validatingCarrierDetails
        {
            get
            {
                return this.validatingCarrierDetailsField;
            }
            set
            {
                this.validatingCarrierDetailsField = value;
            }
        }

        /// <comentarios/>
        public SelectionDetailsTypeI requestOption
        {
            get
            {
                return this.requestOptionField;
            }
            set
            {
                this.requestOptionField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayItemAttribute("statusInformation", IsNullable = false)]
        public StatusDetailsTypeI[] salesIndicator
        {
            get
            {
                return this.salesIndicatorField;
            }
            set
            {
                this.salesIndicatorField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayItemAttribute("itemNumberDetails", IsNullable = false)]
        public ItemNumberIdentificationTypeI[] fromSequenceDocumentNumber
        {
            get
            {
                return this.fromSequenceDocumentNumberField;
            }
            set
            {
                this.fromSequenceDocumentNumberField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayItemAttribute("attributeDetails", IsNullable = false)]
        public CodedAttributeInformationType[] attributeInfo
        {
            get
            {
                return this.attributeInfoField;
            }
            set
            {
                this.attributeInfoField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TSRQRQ_10_1_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TSRQRQ_10_1_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TSRQRQ_10_1_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TSRQRQ_10_1_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TSRQRQ_10_1_1A")]
    public partial class StatusDetailsTypeI
    {

        private string typeField;

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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TSRQRQ_10_1_1A")]
    public partial class SelectionDetailsInformationTypeI
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TSRQRQ_10_1_1A")]
    public partial class SelectionDetailsTypeI
    {

        private SelectionDetailsInformationTypeI selectionDetailsField;

        private SelectionDetailsInformationTypeI[] otherSelectionDetailsField;

        /// <comentarios/>
        public SelectionDetailsInformationTypeI selectionDetails
        {
            get
            {
                return this.selectionDetailsField;
            }
            set
            {
                this.selectionDetailsField = value;
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TSRQRQ_10_1_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TSRQRQ_10_1_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TSRQRQ_10_1_1A")]
    public partial class FormOfPaymentDetailsTypeI
    {

        private string typeField;

        private string vendorCodeField;

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
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TSRQRQ_10_1_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TSRQRQ_10_1_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TSRQRQ_10_1_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TSRQRQ_10_1_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TSRQRQ_10_1_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TSRQRQ_10_1_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TSRQRQ_10_1_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TSRQRQ_10_1_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TSRQRQ_10_1_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TSRQRQ_10_1_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TSRQRQ_10_1_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TSRQRQ_10_1_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TSRQRQ_10_1_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TSRQRQ_10_1_1A")]
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
}

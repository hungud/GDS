using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmadeusLib.Servicios.Ticket_DispalyTST.Response
{
    using System.Xml.Serialization;

    // 
    // Este código fuente fue generado automáticamente por xsd, Versión=4.6.1055.0.
    // 


    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TTSTRR_15_1_1A")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://xml.amadeus.com/TTSTRR_15_1_1A", IsNullable = false)]
    public partial class Ticket_DisplayTSTReply
    {

        private ActionDetailsTypeI scrollingInformationField;

        private ErrorGroupType errorGroupField;

        private Ticket_DisplayTSTReplyFareList[] fareListField;

        /// <comentarios/>
        public ActionDetailsTypeI scrollingInformation
        {
            get
            {
                return this.scrollingInformationField;
            }
            set
            {
                this.scrollingInformationField = value;
            }
        }

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
        [System.Xml.Serialization.XmlElementAttribute("fareList")]
        public Ticket_DisplayTSTReplyFareList[] fareList
        {
            get
            {
                return this.fareListField;
            }
            set
            {
                this.fareListField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TTSTRR_15_1_1A")]
    public partial class ActionDetailsTypeI
    {

        private ReferenceTypeI nextListInformationField;

        /// <comentarios/>
        public ReferenceTypeI nextListInformation
        {
            get
            {
                return this.nextListInformationField;
            }
            set
            {
                this.nextListInformationField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TTSTRR_15_1_1A")]
    public partial class ReferenceTypeI
    {

        private string remainingInformationField;

        private string remainingReferenceField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
        public string remainingInformation
        {
            get
            {
                return this.remainingInformationField;
            }
            set
            {
                this.remainingInformationField = value;
            }
        }

        /// <comentarios/>
        public string remainingReference
        {
            get
            {
                return this.remainingReferenceField;
            }
            set
            {
                this.remainingReferenceField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TTSTRR_15_1_1A")]
    public partial class UserIdentificationType
    {

        private OriginatorIdentificationDetailsTypeI originIdentificationField;

        private string originatorTypeCodeField;

        /// <comentarios/>
        public OriginatorIdentificationDetailsTypeI originIdentification
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
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TTSTRR_15_1_1A")]
    public partial class OriginatorIdentificationDetailsTypeI
    {

        private string inHouseIdentification1Field;

        private string inHouseIdentification2Field;

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

        /// <comentarios/>
        public string inHouseIdentification2
        {
            get
            {
                return this.inHouseIdentification2Field;
            }
            set
            {
                this.inHouseIdentification2Field = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TTSTRR_15_1_1A")]
    public partial class TravelProductInformationType
    {

        private LocationTypeI boardPointDetailsField;

        private LocationTypeI offpointDetailsField;

        private ProductTypeDetailsType flightTypeDetailsField;

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
        public ProductTypeDetailsType flightTypeDetails
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TTSTRR_15_1_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TTSTRR_15_1_1A")]
    public partial class ProductTypeDetailsType
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TTSTRR_15_1_1A")]
    public partial class TravelProductInformationTypeI
    {

        private LocationTypeI boardPointDetailsField;

        private LocationTypeI offpointDetailsField;

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
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TTSTRR_15_1_1A")]
    public partial class TransportIdentifierType_156498S
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TTSTRR_15_1_1A")]
    public partial class CompanyIdentificationTypeI
    {

        private string otherCompanyField;

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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TTSTRR_15_1_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TTSTRR_15_1_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TTSTRR_15_1_1A")]
    public partial class TaxTypeI
    {

        private string taxCategoryField;

        private TaxDetailsTypeI[] feeTaxDetailsField;

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
        [System.Xml.Serialization.XmlElementAttribute("feeTaxDetails")]
        public TaxDetailsTypeI[] feeTaxDetails
        {
            get
            {
                return this.feeTaxDetailsField;
            }
            set
            {
                this.feeTaxDetailsField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TTSTRR_15_1_1A")]
    public partial class TaxDetailsTypeI
    {

        private string rateField;

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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TTSTRR_15_1_1A")]
    public partial class StatusTypeI
    {

        private StatusDetailsTypeI firstStatusDetailsField;

        private StatusDetailsTypeI[] otherStatusDetailsField;

        /// <comentarios/>
        public StatusDetailsTypeI firstStatusDetails
        {
            get
            {
                return this.firstStatusDetailsField;
            }
            set
            {
                this.firstStatusDetailsField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("otherStatusDetails")]
        public StatusDetailsTypeI[] otherStatusDetails
        {
            get
            {
                return this.otherStatusDetailsField;
            }
            set
            {
                this.otherStatusDetailsField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TTSTRR_15_1_1A")]
    public partial class StatusDetailsTypeI
    {

        private string tstFlagField;

        /// <comentarios/>
        public string tstFlag
        {
            get
            {
                return this.tstFlagField;
            }
            set
            {
                this.tstFlagField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TTSTRR_15_1_1A")]
    public partial class SpecificDataInformationTypeI
    {

        private DataTypeInformationTypeI dataTypeInformationField;

        private DataInformationTypeI[] dataInformationField;

        /// <comentarios/>
        public DataTypeInformationTypeI dataTypeInformation
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
        public DataInformationTypeI[] dataInformation
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TTSTRR_15_1_1A")]
    public partial class DataTypeInformationTypeI
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TTSTRR_15_1_1A")]
    public partial class DataInformationTypeI
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TTSTRR_15_1_1A")]
    public partial class SelectionDetailsTypeI
    {

        private SelectionDetailsInformationTypeI selectionDetailsField;

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
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TTSTRR_15_1_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TTSTRR_15_1_1A")]
    public partial class ReferencingDetailsType
    {

        private string typeField;

        private string valueField;

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
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TTSTRR_15_1_1A")]
    public partial class ReferenceInfoType
    {

        private ReferencingDetailsType referenceDetailsField;

        /// <comentarios/>
        public ReferencingDetailsType referenceDetails
        {
            get
            {
                return this.referenceDetailsField;
            }
            set
            {
                this.referenceDetailsField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TTSTRR_15_1_1A")]
    public partial class RateTariffClassInformationType
    {

        private string rateTariffClassField;

        private string otherRateTariffClassField;

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

        /// <comentarios/>
        public string otherRateTariffClass
        {
            get
            {
                return this.otherRateTariffClassField;
            }
            set
            {
                this.otherRateTariffClassField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TTSTRR_15_1_1A")]
    public partial class PricingOrTicketingSubsequentType
    {

        private RateTariffClassInformationType fareBasisDetailsField;

        /// <comentarios/>
        public RateTariffClassInformationType fareBasisDetails
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TTSTRR_15_1_1A")]
    public partial class MonetaryInformationType
    {

        private MonetaryInformationDetailsType monetaryDetailsField;

        private MonetaryInformationDetailsType[] otherMonetaryDetailsField;

        /// <comentarios/>
        public MonetaryInformationDetailsType monetaryDetails
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
        public MonetaryInformationDetailsType[] otherMonetaryDetails
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TTSTRR_15_1_1A")]
    public partial class MonetaryInformationDetailsType
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TTSTRR_15_1_1A")]
    public partial class MonetaryInformationTypeI_133223S
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TTSTRR_15_1_1A")]
    public partial class MonetaryInformationDetailsTypeI
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TTSTRR_15_1_1A")]
    public partial class MonetaryInformationTypeI_133222S
    {

        private MonetaryInformationDetailsTypeI_193322C monetaryDetailsField;

        /// <comentarios/>
        public MonetaryInformationDetailsTypeI_193322C monetaryDetails
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
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TTSTRR_15_1_1A")]
    public partial class MonetaryInformationDetailsTypeI_193322C
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TTSTRR_15_1_1A")]
    public partial class MonetaryInformationTypeI_132703S
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TTSTRR_15_1_1A")]
    public partial class ItemNumberIdentificationType
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TTSTRR_15_1_1A")]
    public partial class InteractiveFreeTextTypeI_6759S
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TTSTRR_15_1_1A")]
    public partial class InteractiveFreeTextTypeI
    {

        private FreeTextQualificationTypeI freeTextQualificationField;

        private string freeTextField;

        /// <comentarios/>
        public FreeTextQualificationTypeI freeTextQualification
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TTSTRR_15_1_1A")]
    public partial class FreeTextQualificationTypeI
    {

        private string textSubjectQualifierField;

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
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TTSTRR_15_1_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TTSTRR_15_1_1A")]
    public partial class FareFamilyType
    {

        private string fareFamilynameField;

        private string hierarchyField;

        private FareFamilyDetailsType[] commercialFamilyDetailsField;

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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TTSTRR_15_1_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TTSTRR_15_1_1A")]
    public partial class DummySegmentTypeI
    {
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TTSTRR_15_1_1A")]
    public partial class DiscountPenaltyInformationType
    {

        private string fareQualifierField;

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
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TTSTRR_15_1_1A")]
    public partial class DiscountPenaltyMonetaryInformationType
    {

        private string functionField;

        private string amountTypeField;

        private string amountField;

        private string currencyField;

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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TTSTRR_15_1_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TTSTRR_15_1_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TTSTRR_15_1_1A")]
    public partial class AttributeInformationTypeU
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TTSTRR_15_1_1A")]
    public partial class ApplicationErrorInformationType_6594S
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TTSTRR_15_1_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TTSTRR_15_1_1A")]
    public partial class MileageTimeDetailsTypeI
    {

        private string totalMileageField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
        public string totalMileage
        {
            get
            {
                return this.totalMileageField;
            }
            set
            {
                this.totalMileageField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TTSTRR_15_1_1A")]
    public partial class AdditionalProductDetailsTypeI
    {

        private MileageTimeDetailsTypeI mileageTimeDetailsField;

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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TTSTRR_15_1_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TTSTRR_15_1_1A")]
    public partial class CodedAttributeType
    {

        private CodedAttributeInformationType[] attributeDetailsField;

        private object dummyNETField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("attributeDetails")]
        public CodedAttributeInformationType[] attributeDetails
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TTSTRR_15_1_1A")]
    public partial class UniqueIdDescriptionType
    {

        private string sequenceNumberField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
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
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TTSTRR_15_1_1A")]
    public partial class ItemReferencesAndVersionsType
    {

        private UniqueIdDescriptionType sequenceSectionField;

        /// <comentarios/>
        public UniqueIdDescriptionType sequenceSection
        {
            get
            {
                return this.sequenceSectionField;
            }
            set
            {
                this.sequenceSectionField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TTSTRR_15_1_1A")]
    public partial class BaggageDetailsTypeI
    {

        private string baggageQuantityField;

        private decimal baggageWeightField;

        private bool baggageWeightFieldSpecified;

        private string baggageTypeField;

        private string measureUnitField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
        public string baggageQuantity
        {
            get
            {
                return this.baggageQuantityField;
            }
            set
            {
                this.baggageQuantityField = value;
            }
        }

        /// <comentarios/>
        public decimal baggageWeight
        {
            get
            {
                return this.baggageWeightField;
            }
            set
            {
                this.baggageWeightField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool baggageWeightSpecified
        {
            get
            {
                return this.baggageWeightFieldSpecified;
            }
            set
            {
                this.baggageWeightFieldSpecified = value;
            }
        }

        /// <comentarios/>
        public string baggageType
        {
            get
            {
                return this.baggageTypeField;
            }
            set
            {
                this.baggageTypeField = value;
            }
        }

        /// <comentarios/>
        public string measureUnit
        {
            get
            {
                return this.measureUnitField;
            }
            set
            {
                this.measureUnitField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TTSTRR_15_1_1A")]
    public partial class ExcessBaggageTypeI
    {

        private BaggageDetailsTypeI bagAllowanceDetailsField;

        /// <comentarios/>
        public BaggageDetailsTypeI bagAllowanceDetails
        {
            get
            {
                return this.bagAllowanceDetailsField;
            }
            set
            {
                this.bagAllowanceDetailsField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TTSTRR_15_1_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TTSTRR_15_1_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TTSTRR_15_1_1A")]
    public partial class DiscountPenaltyInformationTypeI
    {

        private string zapOffTypeField;

        private decimal zapOffAmountField;

        private bool zapOffAmountFieldSpecified;

        private string zapOffPercentageField;

        /// <comentarios/>
        public string zapOffType
        {
            get
            {
                return this.zapOffTypeField;
            }
            set
            {
                this.zapOffTypeField = value;
            }
        }

        /// <comentarios/>
        public decimal zapOffAmount
        {
            get
            {
                return this.zapOffAmountField;
            }
            set
            {
                this.zapOffAmountField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool zapOffAmountSpecified
        {
            get
            {
                return this.zapOffAmountFieldSpecified;
            }
            set
            {
                this.zapOffAmountFieldSpecified = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
        public string zapOffPercentage
        {
            get
            {
                return this.zapOffPercentageField;
            }
            set
            {
                this.zapOffPercentageField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TTSTRR_15_1_1A")]
    public partial class AdditionalFareQualifierDetailsTypeI
    {

        private string primaryCodeField;

        private string fareBasisCodeField;

        private string ticketDesignatorField;

        private string discTktDesignatorField;

        /// <comentarios/>
        public string primaryCode
        {
            get
            {
                return this.primaryCodeField;
            }
            set
            {
                this.primaryCodeField = value;
            }
        }

        /// <comentarios/>
        public string fareBasisCode
        {
            get
            {
                return this.fareBasisCodeField;
            }
            set
            {
                this.fareBasisCodeField = value;
            }
        }

        /// <comentarios/>
        public string ticketDesignator
        {
            get
            {
                return this.ticketDesignatorField;
            }
            set
            {
                this.ticketDesignatorField = value;
            }
        }

        /// <comentarios/>
        public string discTktDesignator
        {
            get
            {
                return this.discTktDesignatorField;
            }
            set
            {
                this.discTktDesignatorField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TTSTRR_15_1_1A")]
    public partial class FareDetailsTypeI
    {

        private string qualifierField;

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
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TTSTRR_15_1_1A")]
    public partial class FareQualifierDetailsTypeI
    {

        private string movementTypeField;

        private FareDetailsTypeI fareDetailsField;

        private AdditionalFareQualifierDetailsTypeI fareBasisDetailsField;

        private DiscountPenaltyInformationTypeI zapOffDetailsField;

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
        public FareDetailsTypeI fareDetails
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
        public AdditionalFareQualifierDetailsTypeI fareBasisDetails
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

        /// <comentarios/>
        public DiscountPenaltyInformationTypeI zapOffDetails
        {
            get
            {
                return this.zapOffDetailsField;
            }
            set
            {
                this.zapOffDetailsField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TTSTRR_15_1_1A")]
    public partial class ProductIdentificationDetailsTypeI
    {

        private string identificationField;

        private string classOfServiceField;

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
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TTSTRR_15_1_1A")]
    public partial class CompanyIdentificationTypeI_27116C
    {

        private string carrierCodeField;

        /// <comentarios/>
        public string carrierCode
        {
            get
            {
                return this.carrierCodeField;
            }
            set
            {
                this.carrierCodeField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TTSTRR_15_1_1A")]
    public partial class LocationTypeI_27121C
    {

        private string cityCodeField;

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
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TTSTRR_15_1_1A")]
    public partial class TravelProductInformationTypeI_15391S
    {

        private LocationTypeI_27121C departureCityField;

        private LocationTypeI_27121C arrivalCityField;

        private CompanyIdentificationTypeI_27116C airlineDetailField;

        private ProductIdentificationDetailsTypeI segmentDetailField;

        private string ticketingStatusField;

        /// <comentarios/>
        public LocationTypeI_27121C departureCity
        {
            get
            {
                return this.departureCityField;
            }
            set
            {
                this.departureCityField = value;
            }
        }

        /// <comentarios/>
        public LocationTypeI_27121C arrivalCity
        {
            get
            {
                return this.arrivalCityField;
            }
            set
            {
                this.arrivalCityField = value;
            }
        }

        /// <comentarios/>
        public CompanyIdentificationTypeI_27116C airlineDetail
        {
            get
            {
                return this.airlineDetailField;
            }
            set
            {
                this.airlineDetailField = value;
            }
        }

        /// <comentarios/>
        public ProductIdentificationDetailsTypeI segmentDetail
        {
            get
            {
                return this.segmentDetailField;
            }
            set
            {
                this.segmentDetailField = value;
            }
        }

        /// <comentarios/>
        public string ticketingStatus
        {
            get
            {
                return this.ticketingStatusField;
            }
            set
            {
                this.ticketingStatusField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TTSTRR_15_1_1A")]
    public partial class ConnectionDetailsTypeI
    {

        private string routingInformationField;

        private string connexTypeField;

        /// <comentarios/>
        public string routingInformation
        {
            get
            {
                return this.routingInformationField;
            }
            set
            {
                this.routingInformationField = value;
            }
        }

        /// <comentarios/>
        public string connexType
        {
            get
            {
                return this.connexTypeField;
            }
            set
            {
                this.connexTypeField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TTSTRR_15_1_1A")]
    public partial class ConnectionTypeI
    {

        private ConnectionDetailsTypeI connecDetailsField;

        /// <comentarios/>
        public ConnectionDetailsTypeI connecDetails
        {
            get
            {
                return this.connecDetailsField;
            }
            set
            {
                this.connecDetailsField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TTSTRR_15_1_1A")]
    public partial class DiscountPenaltyMonetaryInformationTypeI
    {

        private string penaltyTypeField;

        private string penaltyQualifierField;

        private decimal penaltyAmountField;

        private bool penaltyAmountFieldSpecified;

        private string discountCodeField;

        private string penaltyCurrencyField;

        /// <comentarios/>
        public string penaltyType
        {
            get
            {
                return this.penaltyTypeField;
            }
            set
            {
                this.penaltyTypeField = value;
            }
        }

        /// <comentarios/>
        public string penaltyQualifier
        {
            get
            {
                return this.penaltyQualifierField;
            }
            set
            {
                this.penaltyQualifierField = value;
            }
        }

        /// <comentarios/>
        public decimal penaltyAmount
        {
            get
            {
                return this.penaltyAmountField;
            }
            set
            {
                this.penaltyAmountField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool penaltyAmountSpecified
        {
            get
            {
                return this.penaltyAmountFieldSpecified;
            }
            set
            {
                this.penaltyAmountFieldSpecified = value;
            }
        }

        /// <comentarios/>
        public string discountCode
        {
            get
            {
                return this.discountCodeField;
            }
            set
            {
                this.discountCodeField = value;
            }
        }

        /// <comentarios/>
        public string penaltyCurrency
        {
            get
            {
                return this.penaltyCurrencyField;
            }
            set
            {
                this.penaltyCurrencyField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TTSTRR_15_1_1A")]
    public partial class DiscountAndPenaltyInformationTypeI
    {

        private string infoQualifierField;

        private DiscountPenaltyMonetaryInformationTypeI[] penDisDataField;

        /// <comentarios/>
        public string infoQualifier
        {
            get
            {
                return this.infoQualifierField;
            }
            set
            {
                this.infoQualifierField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("penDisData")]
        public DiscountPenaltyMonetaryInformationTypeI[] penDisData
        {
            get
            {
                return this.penDisDataField;
            }
            set
            {
                this.penDisDataField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TTSTRR_15_1_1A")]
    public partial class ConversionRateDetailsTypeI
    {

        private string currencyCodeField;

        private decimal amountField;

        private bool amountFieldSpecified;

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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TTSTRR_15_1_1A")]
    public partial class ConversionRateTypeI
    {

        private ConversionRateDetailsTypeI firstRateDetailField;

        private ConversionRateDetailsTypeI secondRateDetailField;

        /// <comentarios/>
        public ConversionRateDetailsTypeI firstRateDetail
        {
            get
            {
                return this.firstRateDetailField;
            }
            set
            {
                this.firstRateDetailField = value;
            }
        }

        /// <comentarios/>
        public ConversionRateDetailsTypeI secondRateDetail
        {
            get
            {
                return this.secondRateDetailField;
            }
            set
            {
                this.secondRateDetailField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TTSTRR_15_1_1A")]
    public partial class MonetaryInformationTypeI
    {

        private MonetaryInformationDetailsTypeI_260502C fareDataMainInformationField;

        private MonetaryInformationDetailsTypeI_260502C[] fareDataSupInformationField;

        /// <comentarios/>
        public MonetaryInformationDetailsTypeI_260502C fareDataMainInformation
        {
            get
            {
                return this.fareDataMainInformationField;
            }
            set
            {
                this.fareDataMainInformationField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("fareDataSupInformation")]
        public MonetaryInformationDetailsTypeI_260502C[] fareDataSupInformation
        {
            get
            {
                return this.fareDataSupInformationField;
            }
            set
            {
                this.fareDataSupInformationField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TTSTRR_15_1_1A")]
    public partial class MonetaryInformationDetailsTypeI_260502C
    {

        private string fareDataQualifierField;

        private string fareAmountField;

        private string fareCurrencyField;

        private string fareLocationField;

        /// <comentarios/>
        public string fareDataQualifier
        {
            get
            {
                return this.fareDataQualifierField;
            }
            set
            {
                this.fareDataQualifierField = value;
            }
        }

        /// <comentarios/>
        public string fareAmount
        {
            get
            {
                return this.fareAmountField;
            }
            set
            {
                this.fareAmountField = value;
            }
        }

        /// <comentarios/>
        public string fareCurrency
        {
            get
            {
                return this.fareCurrencyField;
            }
            set
            {
                this.fareCurrencyField = value;
            }
        }

        /// <comentarios/>
        public string fareLocation
        {
            get
            {
                return this.fareLocationField;
            }
            set
            {
                this.fareLocationField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TTSTRR_15_1_1A")]
    public partial class DutyTaxFeeAccountDetailTypeU
    {

        private string isoCountryField;

        /// <comentarios/>
        public string isoCountry
        {
            get
            {
                return this.isoCountryField;
            }
            set
            {
                this.isoCountryField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TTSTRR_15_1_1A")]
    public partial class DutyTaxFeeTypeDetailsTypeU
    {

        private string taxIdentifierField;

        /// <comentarios/>
        public string taxIdentifier
        {
            get
            {
                return this.taxIdentifierField;
            }
            set
            {
                this.taxIdentifierField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TTSTRR_15_1_1A")]
    public partial class DutyTaxFeeDetailsTypeU
    {

        private string taxQualifierField;

        private DutyTaxFeeTypeDetailsTypeU taxIdentificationField;

        private DutyTaxFeeAccountDetailTypeU taxTypeField;

        private string taxNatureField;

        private string taxExemptField;

        /// <comentarios/>
        public string taxQualifier
        {
            get
            {
                return this.taxQualifierField;
            }
            set
            {
                this.taxQualifierField = value;
            }
        }

        /// <comentarios/>
        public DutyTaxFeeTypeDetailsTypeU taxIdentification
        {
            get
            {
                return this.taxIdentificationField;
            }
            set
            {
                this.taxIdentificationField = value;
            }
        }

        /// <comentarios/>
        public DutyTaxFeeAccountDetailTypeU taxType
        {
            get
            {
                return this.taxTypeField;
            }
            set
            {
                this.taxTypeField = value;
            }
        }

        /// <comentarios/>
        public string taxNature
        {
            get
            {
                return this.taxNatureField;
            }
            set
            {
                this.taxNatureField = value;
            }
        }

        /// <comentarios/>
        public string taxExempt
        {
            get
            {
                return this.taxExemptField;
            }
            set
            {
                this.taxExemptField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TTSTRR_15_1_1A")]
    public partial class FreeTextDetailsType_260638C
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

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TTSTRR_15_1_1A")]
    public partial class FreeTextInformationType_185885S
    {

        private FreeTextDetailsType_260638C freeTextDetailsField;

        private string[] freeTextField;

        /// <comentarios/>
        public FreeTextDetailsType_260638C freeTextDetails
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TTSTRR_15_1_1A")]
    public partial class AttributeInformationTypeU_37514C
    {

        private string fieldUpdatedField;

        /// <comentarios/>
        public string fieldUpdated
        {
            get
            {
                return this.fieldUpdatedField;
            }
            set
            {
                this.fieldUpdatedField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TTSTRR_15_1_1A")]
    public partial class AttributeType_21097S
    {

        private AttributeInformationTypeU_37514C criteriaDetailsField;

        /// <comentarios/>
        public AttributeInformationTypeU_37514C criteriaDetails
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TTSTRR_15_1_1A")]
    public partial class MonetaryInformationTypeI_185763S
    {

        private MonetaryInformationDetailsTypeI_260502C fareDataMainInformationField;

        private MonetaryInformationDetailsTypeI_260502C[] fareDataSupInformationField;

        /// <comentarios/>
        public MonetaryInformationDetailsTypeI_260502C fareDataMainInformation
        {
            get
            {
                return this.fareDataMainInformationField;
            }
            set
            {
                this.fareDataMainInformationField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("fareDataSupInformation")]
        public MonetaryInformationDetailsTypeI_260502C[] fareDataSupInformation
        {
            get
            {
                return this.fareDataSupInformationField;
            }
            set
            {
                this.fareDataSupInformationField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TTSTRR_15_1_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TTSTRR_15_1_1A")]
    public partial class CompanyIdentificationTypeI_27095C
    {

        private string carrierCodeField;

        /// <comentarios/>
        public string carrierCode
        {
            get
            {
                return this.carrierCodeField;
            }
            set
            {
                this.carrierCodeField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TTSTRR_15_1_1A")]
    public partial class TransportIdentifierType
    {

        private CompanyIdentificationTypeI_27095C carrierInformationField;

        /// <comentarios/>
        public CompanyIdentificationTypeI_27095C carrierInformation
        {
            get
            {
                return this.carrierInformationField;
            }
            set
            {
                this.carrierInformationField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TTSTRR_15_1_1A")]
    public partial class StructuredDateTimeType_270736C
    {

        private string yearField;

        private string monthField;

        private string dayField;

        private string hourField;

        private string minutesField;

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

        /// <comentarios/>
        public string hour
        {
            get
            {
                return this.hourField;
            }
            set
            {
                this.hourField = value;
            }
        }

        /// <comentarios/>
        public string minutes
        {
            get
            {
                return this.minutesField;
            }
            set
            {
                this.minutesField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TTSTRR_15_1_1A")]
    public partial class StructuredDateTimeInformationType_193776S
    {

        private string businessSemanticField;

        private StructuredDateTimeType_270736C dateTimeField;

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
        public StructuredDateTimeType_270736C dateTime
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TTSTRR_15_1_1A")]
    public partial class FareDetailsType
    {

        private string fareCategoryField;

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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TTSTRR_15_1_1A")]
    public partial class FareInformationType
    {

        private FareDetailsType fareDetailsField;

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
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TTSTRR_15_1_1A")]
    public partial class UniqueIdDescriptionType_208242C
    {

        private string iDSequenceNumberField;

        private string iDQualifierField;

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

        /// <comentarios/>
        public string iDQualifier
        {
            get
            {
                return this.iDQualifierField;
            }
            set
            {
                this.iDQualifierField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TTSTRR_15_1_1A")]
    public partial class ItemReferencesAndVersionsType_144071S
    {

        private string referenceTypeField;

        private string uniqueReferenceField;

        private UniqueIdDescriptionType_208242C iDDescriptionField;

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
        public UniqueIdDescriptionType_208242C iDDescription
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TTSTRR_15_1_1A")]
    public partial class RateTariffClassInformationTypeI
    {

        private string tstIndicatorField;

        /// <comentarios/>
        public string tstIndicator
        {
            get
            {
                return this.tstIndicatorField;
            }
            set
            {
                this.tstIndicatorField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TTSTRR_15_1_1A")]
    public partial class PricingTicketingSubsequentTypeI
    {

        private RateTariffClassInformationTypeI tstInformationField;

        private string fcmiField;

        private string reportedFcmiField;

        /// <comentarios/>
        public RateTariffClassInformationTypeI tstInformation
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

        /// <comentarios/>
        public string fcmi
        {
            get
            {
                return this.fcmiField;
            }
            set
            {
                this.fcmiField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
        public string reportedFcmi
        {
            get
            {
                return this.reportedFcmiField;
            }
            set
            {
                this.reportedFcmiField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TTSTRR_15_1_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TTSTRR_15_1_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TTSTRR_15_1_1A")]
    public partial class ApplicationErrorDetailType_216820C
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TTSTRR_15_1_1A")]
    public partial class ApplicationErrorInformationType
    {

        private ApplicationErrorDetailType_216820C errorDetailsField;

        /// <comentarios/>
        public ApplicationErrorDetailType_216820C errorDetails
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TTSTRR_15_1_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TTSTRR_15_1_1A")]
    public partial class Ticket_DisplayTSTReplyFareList
    {

        private PricingTicketingSubsequentTypeI pricingInformationField;

        private ItemReferencesAndVersionsType_144071S fareReferenceField;

        private FareInformationType fareIndicatorsField;

        private StructuredDateTimeInformationType_193776S[] lastTktDateField;

        private TransportIdentifierType validatingCarrierField;

        private ReferencingDetailsTypeI[] paxSegReferenceField;

        private MonetaryInformationTypeI_185763S fareDataInformationField;

        private Ticket_DisplayTSTReplyFareListReasonCode[] reasonCodeField;

        private Ticket_DisplayTSTReplyFareListTaxInformation[] taxInformationField;

        private ConversionRateTypeI bankerRatesField;

        private Ticket_DisplayTSTReplyFareListPassengerInformation[] passengerInformationField;

        private string[] originDestinationField;

        private Ticket_DisplayTSTReplyFareListSegmentInformation[] segmentInformationField;

        private CodedAttributeType[] otherPricingInfoField;

        private StatusTypeI statusInformationField;

        private UserIdentificationType[] officeDetailsField;

        private Ticket_DisplayTSTReplyFareListWarningInformation[] warningInformationField;

        private Ticket_DisplayTSTReplyFareListAutomaticReissueInfo automaticReissueInfoField;

        private Ticket_DisplayTSTReplyFareListCarrierFeesGroup[] carrierFeesGroupField;

        private FormOfPaymentDetailsTypeI[] contextualFopField;

        private AdditionalProductDetailsTypeI mileageField;

        private Ticket_DisplayTSTReplyFareListFareComponentDetailsGroup[] fareComponentDetailsGroupField;

        private DummySegmentTypeI endFareListField;

        /// <comentarios/>
        public PricingTicketingSubsequentTypeI pricingInformation
        {
            get
            {
                return this.pricingInformationField;
            }
            set
            {
                this.pricingInformationField = value;
            }
        }

        /// <comentarios/>
        public ItemReferencesAndVersionsType_144071S fareReference
        {
            get
            {
                return this.fareReferenceField;
            }
            set
            {
                this.fareReferenceField = value;
            }
        }

        /// <comentarios/>
        public FareInformationType fareIndicators
        {
            get
            {
                return this.fareIndicatorsField;
            }
            set
            {
                this.fareIndicatorsField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("lastTktDate")]
        public StructuredDateTimeInformationType_193776S[] lastTktDate
        {
            get
            {
                return this.lastTktDateField;
            }
            set
            {
                this.lastTktDateField = value;
            }
        }

        /// <comentarios/>
        public TransportIdentifierType validatingCarrier
        {
            get
            {
                return this.validatingCarrierField;
            }
            set
            {
                this.validatingCarrierField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayItemAttribute("refDetails", IsNullable = false)]
        public ReferencingDetailsTypeI[] paxSegReference
        {
            get
            {
                return this.paxSegReferenceField;
            }
            set
            {
                this.paxSegReferenceField = value;
            }
        }

        /// <comentarios/>
        public MonetaryInformationTypeI_185763S fareDataInformation
        {
            get
            {
                return this.fareDataInformationField;
            }
            set
            {
                this.fareDataInformationField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("reasonCode")]
        public Ticket_DisplayTSTReplyFareListReasonCode[] reasonCode
        {
            get
            {
                return this.reasonCodeField;
            }
            set
            {
                this.reasonCodeField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("taxInformation")]
        public Ticket_DisplayTSTReplyFareListTaxInformation[] taxInformation
        {
            get
            {
                return this.taxInformationField;
            }
            set
            {
                this.taxInformationField = value;
            }
        }

        /// <comentarios/>
        public ConversionRateTypeI bankerRates
        {
            get
            {
                return this.bankerRatesField;
            }
            set
            {
                this.bankerRatesField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("passengerInformation")]
        public Ticket_DisplayTSTReplyFareListPassengerInformation[] passengerInformation
        {
            get
            {
                return this.passengerInformationField;
            }
            set
            {
                this.passengerInformationField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayItemAttribute("cityCode", IsNullable = false)]
        public string[] originDestination
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
        [System.Xml.Serialization.XmlElementAttribute("segmentInformation")]
        public Ticket_DisplayTSTReplyFareListSegmentInformation[] segmentInformation
        {
            get
            {
                return this.segmentInformationField;
            }
            set
            {
                this.segmentInformationField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("otherPricingInfo")]
        public CodedAttributeType[] otherPricingInfo
        {
            get
            {
                return this.otherPricingInfoField;
            }
            set
            {
                this.otherPricingInfoField = value;
            }
        }

        /// <comentarios/>
        public StatusTypeI statusInformation
        {
            get
            {
                return this.statusInformationField;
            }
            set
            {
                this.statusInformationField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("officeDetails")]
        public UserIdentificationType[] officeDetails
        {
            get
            {
                return this.officeDetailsField;
            }
            set
            {
                this.officeDetailsField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("warningInformation")]
        public Ticket_DisplayTSTReplyFareListWarningInformation[] warningInformation
        {
            get
            {
                return this.warningInformationField;
            }
            set
            {
                this.warningInformationField = value;
            }
        }

        /// <comentarios/>
        public Ticket_DisplayTSTReplyFareListAutomaticReissueInfo automaticReissueInfo
        {
            get
            {
                return this.automaticReissueInfoField;
            }
            set
            {
                this.automaticReissueInfoField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("carrierFeesGroup")]
        public Ticket_DisplayTSTReplyFareListCarrierFeesGroup[] carrierFeesGroup
        {
            get
            {
                return this.carrierFeesGroupField;
            }
            set
            {
                this.carrierFeesGroupField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayItemAttribute("formOfPayment", IsNullable = false)]
        public FormOfPaymentDetailsTypeI[] contextualFop
        {
            get
            {
                return this.contextualFopField;
            }
            set
            {
                this.contextualFopField = value;
            }
        }

        /// <comentarios/>
        public AdditionalProductDetailsTypeI mileage
        {
            get
            {
                return this.mileageField;
            }
            set
            {
                this.mileageField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("fareComponentDetailsGroup")]
        public Ticket_DisplayTSTReplyFareListFareComponentDetailsGroup[] fareComponentDetailsGroup
        {
            get
            {
                return this.fareComponentDetailsGroupField;
            }
            set
            {
                this.fareComponentDetailsGroupField = value;
            }
        }

        /// <comentarios/>
        public DummySegmentTypeI endFareList
        {
            get
            {
                return this.endFareListField;
            }
            set
            {
                this.endFareListField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TTSTRR_15_1_1A")]
    public partial class Ticket_DisplayTSTReplyFareListReasonCode
    {

        private AttributeType_21097S reasonCodesField;

        private FreeTextInformationType_185885S[] reasonCodeCommentField;

        /// <comentarios/>
        public AttributeType_21097S reasonCodes
        {
            get
            {
                return this.reasonCodesField;
            }
            set
            {
                this.reasonCodesField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("reasonCodeComment")]
        public FreeTextInformationType_185885S[] reasonCodeComment
        {
            get
            {
                return this.reasonCodeCommentField;
            }
            set
            {
                this.reasonCodeCommentField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TTSTRR_15_1_1A")]
    public partial class Ticket_DisplayTSTReplyFareListTaxInformation
    {

        private DutyTaxFeeDetailsTypeU taxDetailsField;

        private MonetaryInformationTypeI amountDetailsField;

        /// <comentarios/>
        public DutyTaxFeeDetailsTypeU taxDetails
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

        /// <comentarios/>
        public MonetaryInformationTypeI amountDetails
        {
            get
            {
                return this.amountDetailsField;
            }
            set
            {
                this.amountDetailsField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TTSTRR_15_1_1A")]
    public partial class Ticket_DisplayTSTReplyFareListPassengerInformation
    {

        private DiscountAndPenaltyInformationTypeI penDisInformationField;

        private ReferencingDetailsTypeI[] passengerReferenceField;

        /// <comentarios/>
        public DiscountAndPenaltyInformationTypeI penDisInformation
        {
            get
            {
                return this.penDisInformationField;
            }
            set
            {
                this.penDisInformationField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayItemAttribute("refDetails", IsNullable = false)]
        public ReferencingDetailsTypeI[] passengerReference
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
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TTSTRR_15_1_1A")]
    public partial class Ticket_DisplayTSTReplyFareListSegmentInformation
    {

        private ConnectionTypeI connexInformationField;

        private TravelProductInformationTypeI_15391S segDetailsField;

        private FareQualifierDetailsTypeI[] fareQualifierField;

        private StructuredDateTimeInformationType[] validityInformationField;

        private ExcessBaggageTypeI bagAllowanceInformationField;

        private ReferencingDetailsTypeI[] segmentReferenceField;

        private ItemReferencesAndVersionsType sequenceInformationField;

        /// <comentarios/>
        public ConnectionTypeI connexInformation
        {
            get
            {
                return this.connexInformationField;
            }
            set
            {
                this.connexInformationField = value;
            }
        }

        /// <comentarios/>
        public TravelProductInformationTypeI_15391S segDetails
        {
            get
            {
                return this.segDetailsField;
            }
            set
            {
                this.segDetailsField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("fareQualifier")]
        public FareQualifierDetailsTypeI[] fareQualifier
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
        [System.Xml.Serialization.XmlElementAttribute("validityInformation")]
        public StructuredDateTimeInformationType[] validityInformation
        {
            get
            {
                return this.validityInformationField;
            }
            set
            {
                this.validityInformationField = value;
            }
        }

        /// <comentarios/>
        public ExcessBaggageTypeI bagAllowanceInformation
        {
            get
            {
                return this.bagAllowanceInformationField;
            }
            set
            {
                this.bagAllowanceInformationField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayItemAttribute("refDetails", IsNullable = false)]
        public ReferencingDetailsTypeI[] segmentReference
        {
            get
            {
                return this.segmentReferenceField;
            }
            set
            {
                this.segmentReferenceField = value;
            }
        }

        /// <comentarios/>
        public ItemReferencesAndVersionsType sequenceInformation
        {
            get
            {
                return this.sequenceInformationField;
            }
            set
            {
                this.sequenceInformationField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TTSTRR_15_1_1A")]
    public partial class Ticket_DisplayTSTReplyFareListWarningInformation
    {

        private ApplicationErrorInformationType_6594S warningCodeField;

        private InteractiveFreeTextTypeI_6759S warningTextField;

        /// <comentarios/>
        public ApplicationErrorInformationType_6594S warningCode
        {
            get
            {
                return this.warningCodeField;
            }
            set
            {
                this.warningCodeField = value;
            }
        }

        /// <comentarios/>
        public InteractiveFreeTextTypeI_6759S warningText
        {
            get
            {
                return this.warningTextField;
            }
            set
            {
                this.warningTextField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TTSTRR_15_1_1A")]
    public partial class Ticket_DisplayTSTReplyFareListAutomaticReissueInfo
    {

        private TicketNumberTypeI ticketInfoField;

        private CouponInformationTypeI couponInfoField;

        private Ticket_DisplayTSTReplyFareListAutomaticReissueInfoPaperCouponRange paperCouponRangeField;

        private MonetaryInformationTypeI_132703S baseFareInfoField;

        private Ticket_DisplayTSTReplyFareListAutomaticReissueInfoFirstDpiGroup firstDpiGroupField;

        private Ticket_DisplayTSTReplyFareListAutomaticReissueInfoSecondDpiGroup secondDpiGroupField;

        /// <comentarios/>
        public TicketNumberTypeI ticketInfo
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
        public Ticket_DisplayTSTReplyFareListAutomaticReissueInfoPaperCouponRange paperCouponRange
        {
            get
            {
                return this.paperCouponRangeField;
            }
            set
            {
                this.paperCouponRangeField = value;
            }
        }

        /// <comentarios/>
        public MonetaryInformationTypeI_132703S baseFareInfo
        {
            get
            {
                return this.baseFareInfoField;
            }
            set
            {
                this.baseFareInfoField = value;
            }
        }

        /// <comentarios/>
        public Ticket_DisplayTSTReplyFareListAutomaticReissueInfoFirstDpiGroup firstDpiGroup
        {
            get
            {
                return this.firstDpiGroupField;
            }
            set
            {
                this.firstDpiGroupField = value;
            }
        }

        /// <comentarios/>
        public Ticket_DisplayTSTReplyFareListAutomaticReissueInfoSecondDpiGroup secondDpiGroup
        {
            get
            {
                return this.secondDpiGroupField;
            }
            set
            {
                this.secondDpiGroupField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TTSTRR_15_1_1A")]
    public partial class Ticket_DisplayTSTReplyFareListAutomaticReissueInfoPaperCouponRange
    {

        private TicketNumberTypeI ticketInfoField;

        private CouponInformationTypeI couponInfoField;

        /// <comentarios/>
        public TicketNumberTypeI ticketInfo
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TTSTRR_15_1_1A")]
    public partial class Ticket_DisplayTSTReplyFareListAutomaticReissueInfoFirstDpiGroup
    {

        private DiscountPenaltyMonetaryInformationType[] penaltyField;

        private MonetaryInformationTypeI_133223S reissueInfoField;

        private MonetaryInformationTypeI_133223S oldTaxInfoField;

        private MonetaryInformationTypeI_132703S reissueBalanceInfoField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayItemAttribute("discountPenaltyDetails", IsNullable = false)]
        public DiscountPenaltyMonetaryInformationType[] penalty
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
        public MonetaryInformationTypeI_133223S reissueInfo
        {
            get
            {
                return this.reissueInfoField;
            }
            set
            {
                this.reissueInfoField = value;
            }
        }

        /// <comentarios/>
        public MonetaryInformationTypeI_133223S oldTaxInfo
        {
            get
            {
                return this.oldTaxInfoField;
            }
            set
            {
                this.oldTaxInfoField = value;
            }
        }

        /// <comentarios/>
        public MonetaryInformationTypeI_132703S reissueBalanceInfo
        {
            get
            {
                return this.reissueBalanceInfoField;
            }
            set
            {
                this.reissueBalanceInfoField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TTSTRR_15_1_1A")]
    public partial class Ticket_DisplayTSTReplyFareListAutomaticReissueInfoSecondDpiGroup
    {

        private DiscountPenaltyMonetaryInformationType[] penaltyField;

        private MonetaryInformationTypeI_133223S residualValueInfoField;

        private MonetaryInformationTypeI_133223S oldTaxInfoField;

        private MonetaryInformationTypeI_132703S issueBalanceInfoField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayItemAttribute("discountPenaltyDetails", IsNullable = false)]
        public DiscountPenaltyMonetaryInformationType[] penalty
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
        public MonetaryInformationTypeI_133223S residualValueInfo
        {
            get
            {
                return this.residualValueInfoField;
            }
            set
            {
                this.residualValueInfoField = value;
            }
        }

        /// <comentarios/>
        public MonetaryInformationTypeI_133223S oldTaxInfo
        {
            get
            {
                return this.oldTaxInfoField;
            }
            set
            {
                this.oldTaxInfoField = value;
            }
        }

        /// <comentarios/>
        public MonetaryInformationTypeI_132703S issueBalanceInfo
        {
            get
            {
                return this.issueBalanceInfoField;
            }
            set
            {
                this.issueBalanceInfoField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TTSTRR_15_1_1A")]
    public partial class Ticket_DisplayTSTReplyFareListCarrierFeesGroup
    {

        private SelectionDetailsTypeI carrierFeeTypeField;

        private Ticket_DisplayTSTReplyFareListCarrierFeesGroupCarrierFeeInfo[] carrierFeeInfoField;

        /// <comentarios/>
        public SelectionDetailsTypeI carrierFeeType
        {
            get
            {
                return this.carrierFeeTypeField;
            }
            set
            {
                this.carrierFeeTypeField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("carrierFeeInfo")]
        public Ticket_DisplayTSTReplyFareListCarrierFeesGroupCarrierFeeInfo[] carrierFeeInfo
        {
            get
            {
                return this.carrierFeeInfoField;
            }
            set
            {
                this.carrierFeeInfoField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TTSTRR_15_1_1A")]
    public partial class Ticket_DisplayTSTReplyFareListCarrierFeesGroupCarrierFeeInfo
    {

        private SpecificDataInformationTypeI carrierFeeSubcodeField;

        private InteractiveFreeTextTypeI commercialNameField;

        private MonetaryInformationTypeI_133222S feeAmountField;

        private TaxTypeI[] feeTaxField;

        /// <comentarios/>
        public SpecificDataInformationTypeI carrierFeeSubcode
        {
            get
            {
                return this.carrierFeeSubcodeField;
            }
            set
            {
                this.carrierFeeSubcodeField = value;
            }
        }

        /// <comentarios/>
        public InteractiveFreeTextTypeI commercialName
        {
            get
            {
                return this.commercialNameField;
            }
            set
            {
                this.commercialNameField = value;
            }
        }

        /// <comentarios/>
        public MonetaryInformationTypeI_133222S feeAmount
        {
            get
            {
                return this.feeAmountField;
            }
            set
            {
                this.feeAmountField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("feeTax")]
        public TaxTypeI[] feeTax
        {
            get
            {
                return this.feeTaxField;
            }
            set
            {
                this.feeTaxField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TTSTRR_15_1_1A")]
    public partial class Ticket_DisplayTSTReplyFareListFareComponentDetailsGroup
    {

        private ItemNumberIdentificationType[] fareComponentIDField;

        private TravelProductInformationTypeI marketFareComponentField;

        private MonetaryInformationType monetaryInformationField;

        private PricingOrTicketingSubsequentType componentClassInfoField;

        private DiscountPenaltyInformationType[] fareQualifiersDetailField;

        private FareFamilyType fareFamilyDetailsField;

        private TransportIdentifierType_156498S fareFamilyOwnerField;

        private AttributeInformationTypeU[] fareComponentServiceAttributesField;

        private Ticket_DisplayTSTReplyFareListFareComponentDetailsGroupCouponDetailsGroup[] couponDetailsGroupField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayItemAttribute("itemNumberDetails", IsNullable = false)]
        public ItemNumberIdentificationType[] fareComponentID
        {
            get
            {
                return this.fareComponentIDField;
            }
            set
            {
                this.fareComponentIDField = value;
            }
        }

        /// <comentarios/>
        public TravelProductInformationTypeI marketFareComponent
        {
            get
            {
                return this.marketFareComponentField;
            }
            set
            {
                this.marketFareComponentField = value;
            }
        }

        /// <comentarios/>
        public MonetaryInformationType monetaryInformation
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
        public PricingOrTicketingSubsequentType componentClassInfo
        {
            get
            {
                return this.componentClassInfoField;
            }
            set
            {
                this.componentClassInfoField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayItemAttribute("discountDetails", IsNullable = false)]
        public DiscountPenaltyInformationType[] fareQualifiersDetail
        {
            get
            {
                return this.fareQualifiersDetailField;
            }
            set
            {
                this.fareQualifiersDetailField = value;
            }
        }

        /// <comentarios/>
        public FareFamilyType fareFamilyDetails
        {
            get
            {
                return this.fareFamilyDetailsField;
            }
            set
            {
                this.fareFamilyDetailsField = value;
            }
        }

        /// <comentarios/>
        public TransportIdentifierType_156498S fareFamilyOwner
        {
            get
            {
                return this.fareFamilyOwnerField;
            }
            set
            {
                this.fareFamilyOwnerField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayItemAttribute("criteriaDetails", IsNullable = false)]
        public AttributeInformationTypeU[] fareComponentServiceAttributes
        {
            get
            {
                return this.fareComponentServiceAttributesField;
            }
            set
            {
                this.fareComponentServiceAttributesField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("couponDetailsGroup")]
        public Ticket_DisplayTSTReplyFareListFareComponentDetailsGroupCouponDetailsGroup[] couponDetailsGroup
        {
            get
            {
                return this.couponDetailsGroupField;
            }
            set
            {
                this.couponDetailsGroupField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TTSTRR_15_1_1A")]
    public partial class Ticket_DisplayTSTReplyFareListFareComponentDetailsGroupCouponDetailsGroup
    {

        private ReferenceInfoType productIdField;

        private TravelProductInformationType flightConnectionTypeField;

        /// <comentarios/>
        public ReferenceInfoType productId
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
        public TravelProductInformationType flightConnectionType
        {
            get
            {
                return this.flightConnectionTypeField;
            }
            set
            {
                this.flightConnectionTypeField = value;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmadeusLib.Servicios.Ticket_CancelDocument.Request
{
    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TRCANQ_11_1_1A")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://xml.amadeus.com/TRCANQ_11_1_1A", IsNullable = false)]
    public partial class Ticket_CancelDocument
    {

        private TicketNumberTypeI documentNumberDetailsField;

        private ItemNumberTypeI[] sequenceNumberRangesField;

        private StatusType voidOptionField;

        private OfficeSettingsDetailsType stockProviderDetailsField;

        private AdditionalBusinessSourceInformationType targetOfficeDetailsField;

        /// <comentarios/>
        public TicketNumberTypeI documentNumberDetails
        {
            get
            {
                return this.documentNumberDetailsField;
            }
            set
            {
                this.documentNumberDetailsField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("sequenceNumberRanges")]
        public ItemNumberTypeI[] sequenceNumberRanges
        {
            get
            {
                return this.sequenceNumberRangesField;
            }
            set
            {
                this.sequenceNumberRangesField = value;
            }
        }

        /// <comentarios/>
        public StatusType voidOption
        {
            get
            {
                return this.voidOptionField;
            }
            set
            {
                this.voidOptionField = value;
            }
        }

        /// <comentarios/>
        public OfficeSettingsDetailsType stockProviderDetails
        {
            get
            {
                return this.stockProviderDetailsField;
            }
            set
            {
                this.stockProviderDetailsField = value;
            }
        }

        /// <comentarios/>
        public AdditionalBusinessSourceInformationType targetOfficeDetails
        {
            get
            {
                return this.targetOfficeDetailsField;
            }
            set
            {
                this.targetOfficeDetailsField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TRCANQ_11_1_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TRCANQ_11_1_1A")]
    public partial class TicketNumberDetailsTypeI
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TRCANQ_11_1_1A")]
    public partial class StatusType
    {

        private StatusDetailsType statusInformationField;

        /// <comentarios/>
        public StatusDetailsType statusInformation
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
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TRCANQ_11_1_1A")]
    public partial class StatusDetailsType
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TRCANQ_11_1_1A")]
    public partial class OfficeSettingsDetailsType
    {

        private DocumentInfoFromOfficeSettingType officeSettingsDetailsField;

        /// <comentarios/>
        public DocumentInfoFromOfficeSettingType officeSettingsDetails
        {
            get
            {
                return this.officeSettingsDetailsField;
            }
            set
            {
                this.officeSettingsDetailsField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TRCANQ_11_1_1A")]
    public partial class DocumentInfoFromOfficeSettingType
    {

        private string marketIataCodeField;

        private string stockProviderCodeField;

        /// <comentarios/>
        public string marketIataCode
        {
            get
            {
                return this.marketIataCodeField;
            }
            set
            {
                this.marketIataCodeField = value;
            }
        }

        /// <comentarios/>
        public string stockProviderCode
        {
            get
            {
                return this.stockProviderCodeField;
            }
            set
            {
                this.stockProviderCodeField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TRCANQ_11_1_1A")]
    public partial class OriginatorIdentificationDetailsType
    {

        private string inHouseIdentification2Field;

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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TRCANQ_11_1_1A")]
    public partial class AdditionalBusinessSourceInformationType
    {

        private OriginatorIdentificationDetailsType originatorDetailsField;

        /// <comentarios/>
        public OriginatorIdentificationDetailsType originatorDetails
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TRCANQ_11_1_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TRCANQ_11_1_1A")]
    public partial class ItemNumberTypeI
    {

        private ItemNumberIdentificationTypeI[] itemNumberDetailsField;

        private object dummyNETField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("itemNumberDetails")]
        public ItemNumberIdentificationTypeI[] itemNumberDetails
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
}

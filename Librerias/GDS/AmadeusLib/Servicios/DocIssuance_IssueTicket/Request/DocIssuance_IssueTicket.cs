using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AmadeusLib.Servicios.DocIssuance_IssueTicket.Request
{

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TTKTIQ_09_1_1A")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://xml.amadeus.com/TTKTIQ_09_1_1A", IsNullable = false)]
    public partial class DocIssuance_IssueTicket
    {

        private DocIssuance_IssueTicketAgentInfo agentInfoField;

        private DocIssuance_IssueTicketOverrideDate overrideDateField;

        private DocIssuance_IssueTicketSelection[] selectionField;

        private DocIssuance_IssueTicketPaxSelection[] paxSelectionField;

        private DocIssuance_IssueTicketStock stockField;

        private DocIssuance_IssueTicketOptionGroup[] optionGroupField;

        private DocIssuance_IssueTicketInfantOrAdultAssociation infantOrAdultAssociationField;

        private DocIssuance_IssueTicketOtherCompoundOptions[] otherCompoundOptionsField;

        /// <comentarios/>
        public DocIssuance_IssueTicketAgentInfo agentInfo
        {
            get
            {
                return this.agentInfoField;
            }
            set
            {
                this.agentInfoField = value;
            }
        }

        /// <comentarios/>
        public DocIssuance_IssueTicketOverrideDate overrideDate
        {
            get
            {
                return this.overrideDateField;
            }
            set
            {
                this.overrideDateField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("selection")]
        public DocIssuance_IssueTicketSelection[] selection
        {
            get
            {
                return this.selectionField;
            }
            set
            {
                this.selectionField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("paxSelection")]
        public DocIssuance_IssueTicketPaxSelection[] paxSelection
        {
            get
            {
                return this.paxSelectionField;
            }
            set
            {
                this.paxSelectionField = value;
            }
        }

        /// <comentarios/>
        public DocIssuance_IssueTicketStock stock
        {
            get
            {
                return this.stockField;
            }
            set
            {
                this.stockField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("optionGroup")]
        public DocIssuance_IssueTicketOptionGroup[] optionGroup
        {
            get
            {
                return this.optionGroupField;
            }
            set
            {
                this.optionGroupField = value;
            }
        }

        /// <comentarios/>
        public DocIssuance_IssueTicketInfantOrAdultAssociation infantOrAdultAssociation
        {
            get
            {
                return this.infantOrAdultAssociationField;
            }
            set
            {
                this.infantOrAdultAssociationField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("otherCompoundOptions")]
        public DocIssuance_IssueTicketOtherCompoundOptions[] otherCompoundOptions
        {
            get
            {
                return this.otherCompoundOptionsField;
            }
            set
            {
                this.otherCompoundOptionsField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TTKTIQ_09_1_1A")]
    public partial class DocIssuance_IssueTicketAgentInfo
    {

        private DocIssuance_IssueTicketAgentInfoInternalIdDetails internalIdDetailsField;

        /// <comentarios/>
        public DocIssuance_IssueTicketAgentInfoInternalIdDetails internalIdDetails
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TTKTIQ_09_1_1A")]
    public partial class DocIssuance_IssueTicketAgentInfoInternalIdDetails
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TTKTIQ_09_1_1A")]
    public partial class DocIssuance_IssueTicketOverrideDate
    {

        private string businessSemanticField;

        private DocIssuance_IssueTicketOverrideDateDateTime dateTimeField;

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
        public DocIssuance_IssueTicketOverrideDateDateTime dateTime
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TTKTIQ_09_1_1A")]
    public partial class DocIssuance_IssueTicketOverrideDateDateTime
    {

        private string yearField;

        private decimal monthField;

        private decimal dayField;

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
        public decimal month
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
        public decimal day
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TTKTIQ_09_1_1A")]
    public partial class DocIssuance_IssueTicketSelection
    {

        private DocIssuance_IssueTicketSelectionReferenceDetails[] referenceDetailsField;

        private object dummyNETField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("referenceDetails")]
        public DocIssuance_IssueTicketSelectionReferenceDetails[] referenceDetails
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TTKTIQ_09_1_1A")]
    public partial class DocIssuance_IssueTicketSelectionReferenceDetails
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TTKTIQ_09_1_1A")]
    public partial class DocIssuance_IssueTicketPaxSelection
    {

        private DocIssuance_IssueTicketPaxSelectionPassengerReference passengerReferenceField;

        /// <comentarios/>
        public DocIssuance_IssueTicketPaxSelectionPassengerReference passengerReference
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TTKTIQ_09_1_1A")]
    public partial class DocIssuance_IssueTicketPaxSelectionPassengerReference
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TTKTIQ_09_1_1A")]
    public partial class DocIssuance_IssueTicketStock
    {

        private DocIssuance_IssueTicketStockStockTicketNumberDetails stockTicketNumberDetailsField;

        /// <comentarios/>
        public DocIssuance_IssueTicketStockStockTicketNumberDetails stockTicketNumberDetails
        {
            get
            {
                return this.stockTicketNumberDetailsField;
            }
            set
            {
                this.stockTicketNumberDetailsField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TTKTIQ_09_1_1A")]
    public partial class DocIssuance_IssueTicketStockStockTicketNumberDetails
    {

        private string qualifierField;

        private string controlNumberField;

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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TTKTIQ_09_1_1A")]
    public partial class DocIssuance_IssueTicketOptionGroup
    {

        private DocIssuance_IssueTicketOptionGroupSwitches switchesField;

        private DocIssuance_IssueTicketOptionGroupSubCompoundOptions[] subCompoundOptionsField;

        private DocIssuance_IssueTicketOptionGroupOverrideAlternativeDate overrideAlternativeDateField;

        /// <comentarios/>
        public DocIssuance_IssueTicketOptionGroupSwitches switches
        {
            get
            {
                return this.switchesField;
            }
            set
            {
                this.switchesField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("subCompoundOptions")]
        public DocIssuance_IssueTicketOptionGroupSubCompoundOptions[] subCompoundOptions
        {
            get
            {
                return this.subCompoundOptionsField;
            }
            set
            {
                this.subCompoundOptionsField = value;
            }
        }

        /// <comentarios/>
        public DocIssuance_IssueTicketOptionGroupOverrideAlternativeDate overrideAlternativeDate
        {
            get
            {
                return this.overrideAlternativeDateField;
            }
            set
            {
                this.overrideAlternativeDateField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TTKTIQ_09_1_1A")]
    public partial class DocIssuance_IssueTicketOptionGroupSwitches
    {

        private DocIssuance_IssueTicketOptionGroupSwitchesStatusDetails statusDetailsField;

        /// <comentarios/>
        public DocIssuance_IssueTicketOptionGroupSwitchesStatusDetails statusDetails
        {
            get
            {
                return this.statusDetailsField;
            }
            set
            {
                this.statusDetailsField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TTKTIQ_09_1_1A")]
    public partial class DocIssuance_IssueTicketOptionGroupSwitchesStatusDetails
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TTKTIQ_09_1_1A")]
    public partial class DocIssuance_IssueTicketOptionGroupSubCompoundOptions
    {

        private DocIssuance_IssueTicketOptionGroupSubCompoundOptionsCriteriaDetails criteriaDetailsField;

        /// <comentarios/>
        public DocIssuance_IssueTicketOptionGroupSubCompoundOptionsCriteriaDetails criteriaDetails
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TTKTIQ_09_1_1A")]
    public partial class DocIssuance_IssueTicketOptionGroupSubCompoundOptionsCriteriaDetails
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TTKTIQ_09_1_1A")]
    public partial class DocIssuance_IssueTicketOptionGroupOverrideAlternativeDate
    {

        private string businessSemanticField;

        private DocIssuance_IssueTicketOptionGroupOverrideAlternativeDateDateTime dateTimeField;

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
        public DocIssuance_IssueTicketOptionGroupOverrideAlternativeDateDateTime dateTime
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TTKTIQ_09_1_1A")]
    public partial class DocIssuance_IssueTicketOptionGroupOverrideAlternativeDateDateTime
    {

        private string yearField;

        private decimal monthField;

        private decimal dayField;

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
        public decimal month
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
        public decimal day
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TTKTIQ_09_1_1A")]
    public partial class DocIssuance_IssueTicketInfantOrAdultAssociation
    {

        private DocIssuance_IssueTicketInfantOrAdultAssociationPaxDetails paxDetailsField;

        /// <comentarios/>
        public DocIssuance_IssueTicketInfantOrAdultAssociationPaxDetails paxDetails
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TTKTIQ_09_1_1A")]
    public partial class DocIssuance_IssueTicketInfantOrAdultAssociationPaxDetails
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TTKTIQ_09_1_1A")]
    public partial class DocIssuance_IssueTicketOtherCompoundOptions
    {

        private DocIssuance_IssueTicketOtherCompoundOptionsAttributeDetails attributeDetailsField;

        /// <comentarios/>
        public DocIssuance_IssueTicketOtherCompoundOptionsAttributeDetails attributeDetails
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
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TTKTIQ_09_1_1A")]
    public partial class DocIssuance_IssueTicketOtherCompoundOptionsAttributeDetails
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
}

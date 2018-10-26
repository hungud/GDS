using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmadeusLib.Servicios.Ticket_CreateTSTFromPricing.Request
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TAUTCQ_04_1_1A")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://xml.amadeus.com/TAUTCQ_04_1_1A", IsNullable = false)]
    public partial class Ticket_CreateTSTFromPricing
    {

        private Ticket_CreateTSTFromPricingPnrLocatorData pnrLocatorDataField;

        private Ticket_CreateTSTFromPricingPsaList[] psaListField;

        /// <comentarios/>
        public Ticket_CreateTSTFromPricingPnrLocatorData pnrLocatorData
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
        [System.Xml.Serialization.XmlElementAttribute("psaList")]
        public Ticket_CreateTSTFromPricingPsaList[] psaList
        {
            get
            {
                return this.psaListField;
            }
            set
            {
                this.psaListField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TAUTCQ_04_1_1A")]
    public partial class Ticket_CreateTSTFromPricingPnrLocatorData
    {

        private Ticket_CreateTSTFromPricingPnrLocatorDataReservationInformation reservationInformationField;

        /// <comentarios/>
        public Ticket_CreateTSTFromPricingPnrLocatorDataReservationInformation reservationInformation
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TAUTCQ_04_1_1A")]
    public partial class Ticket_CreateTSTFromPricingPnrLocatorDataReservationInformation
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TAUTCQ_04_1_1A")]
    public partial class Ticket_CreateTSTFromPricingPsaList
    {

        private Ticket_CreateTSTFromPricingPsaListItemReference itemReferenceField;

        private Ticket_CreateTSTFromPricingPsaListRefDetails[] paxReferenceField;

        /// <comentarios/>
        public Ticket_CreateTSTFromPricingPsaListItemReference itemReference
        {
            get
            {
                return this.itemReferenceField;
            }
            set
            {
                this.itemReferenceField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayItemAttribute("refDetails", IsNullable = false)]
        public Ticket_CreateTSTFromPricingPsaListRefDetails[] paxReference
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
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TAUTCQ_04_1_1A")]
    public partial class Ticket_CreateTSTFromPricingPsaListItemReference
    {

        private string referenceTypeField;

        private decimal uniqueReferenceField;

        private bool uniqueReferenceFieldSpecified;

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
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TAUTCQ_04_1_1A")]
    public partial class Ticket_CreateTSTFromPricingPsaListRefDetails
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

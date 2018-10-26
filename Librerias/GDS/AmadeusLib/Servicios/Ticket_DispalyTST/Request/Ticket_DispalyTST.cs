using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmadeusLib.Servicios.Ticket_DispalyTST.Request
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/TTSTRQ_15_1_1A")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://xml.amadeus.com/TTSTRQ_15_1_1A", IsNullable = false)]
    public partial class Ticket_DisplayTST
    {

        private CodedAttributeType displayModeField;

        private ReservationControlInformationTypeI pnrLocatorDataField;

        private ActionDetailsTypeI scrollingInformationField;

        private ItemReferencesAndVersionsType[] tstReferenceField;

        private ReferencingDetailsTypeI[] psaInformationField;

        /// <comentarios/>
        public CodedAttributeType displayMode
        {
            get
            {
                return this.displayModeField;
            }
            set
            {
                this.displayModeField = value;
            }
        }

        /// <comentarios/>
        public ReservationControlInformationTypeI pnrLocatorData
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
        [System.Xml.Serialization.XmlElementAttribute("tstReference")]
        public ItemReferencesAndVersionsType[] tstReference
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
        public ReferencingDetailsTypeI[] psaInformation
        {
            get
            {
                return this.psaInformationField;
            }
            set
            {
                this.psaInformationField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TTSTRQ_15_1_1A")]
    public partial class CodedAttributeType
    {

        private CodedAttributeInformationType attributeDetailsField;

        /// <comentarios/>
        public CodedAttributeInformationType attributeDetails
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TTSTRQ_15_1_1A")]
    public partial class CodedAttributeInformationType
    {

        private string attributeTypeField;

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
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TTSTRQ_15_1_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TTSTRQ_15_1_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TTSTRQ_15_1_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TTSTRQ_15_1_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TTSTRQ_15_1_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TTSTRQ_15_1_1A")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.amadeus.com/TTSTRQ_15_1_1A")]
    public partial class ReservationControlInformationTypeI
    {

        private ReservationControlInformationDetailsTypeI reservationInformationField;

        /// <comentarios/>
        public ReservationControlInformationDetailsTypeI reservationInformation
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

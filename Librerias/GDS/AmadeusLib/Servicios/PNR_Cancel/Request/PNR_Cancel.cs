using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AmadeusLib.Servicios.PNR_Cancel.Request
{
   
    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRXCL_10_1_1A")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://xml.amadeus.com/PNRXCL_10_1_1A", IsNullable = false)]
    public partial class PNR_Cancel
    {

        private PNR_CancelReservationInfo reservationInfoField;

        private decimal[] pnrActionsField;

        private PNR_CancelCancelElements[] cancelElementsField;

        /// <comentarios/>
        public PNR_CancelReservationInfo reservationInfo
        {
            get
            {
                return this.reservationInfoField;
            }
            set
            {
                this.reservationInfoField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayItemAttribute("optionCode", IsNullable = false)]
        public decimal[] pnrActions
        {
            get
            {
                return this.pnrActionsField;
            }
            set
            {
                this.pnrActionsField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("cancelElements")]
        public PNR_CancelCancelElements[] cancelElements
        {
            get
            {
                return this.cancelElementsField;
            }
            set
            {
                this.cancelElementsField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRXCL_10_1_1A")]
    public partial class PNR_CancelReservationInfo
    {

        private PNR_CancelReservationInfoReservation reservationField;

        /// <comentarios/>
        public PNR_CancelReservationInfoReservation reservation
        {
            get
            {
                return this.reservationField;
            }
            set
            {
                this.reservationField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRXCL_10_1_1A")]
    public partial class PNR_CancelReservationInfoReservation
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRXCL_10_1_1A")]
    public partial class PNR_CancelCancelElements
    {

        private string entryTypeField;

        private PNR_CancelCancelElementsElement[] elementField;

        /// <comentarios/>
        public string entryType
        {
            get
            {
                return this.entryTypeField;
            }
            set
            {
                this.entryTypeField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("element")]
        public PNR_CancelCancelElementsElement[] element
        {
            get
            {
                return this.elementField;
            }
            set
            {
                this.elementField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRXCL_10_1_1A")]
    public partial class PNR_CancelCancelElementsElement
    {

        private string identifierField;

        private decimal numberField;

        private bool numberFieldSpecified;

        private decimal subElementField;

        private bool subElementFieldSpecified;

        /// <comentarios/>
        public string identifier
        {
            get
            {
                return this.identifierField;
            }
            set
            {
                this.identifierField = value;
            }
        }

        /// <comentarios/>
        public decimal number
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
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool numberSpecified
        {
            get
            {
                return this.numberFieldSpecified;
            }
            set
            {
                this.numberFieldSpecified = value;
            }
        }

        /// <comentarios/>
        public decimal subElement
        {
            get
            {
                return this.subElementField;
            }
            set
            {
                this.subElementField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool subElementSpecified
        {
            get
            {
                return this.subElementFieldSpecified;
            }
            set
            {
                this.subElementFieldSpecified = value;
            }
        }
    }
}

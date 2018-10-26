using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AmadeusLib.Servicios.Command_Cryptic.Request
{

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/HSFREQ_07_3_1A")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://xml.amadeus.com/HSFREQ_07_3_1A", IsNullable = false)]
    public partial class Command_Cryptic
    {

        private Command_CrypticMessageAction messageActionField;

        private Command_CrypticNumberOfUnits numberOfUnitsField;

        private Command_CrypticIntelligentWorkstationInfo intelligentWorkstationInfoField;

        private Command_CrypticLongTextString longTextStringField;

        /// <comentarios/>
        public Command_CrypticMessageAction messageAction
        {
            get
            {
                return this.messageActionField;
            }
            set
            {
                this.messageActionField = value;
            }
        }

        /// <comentarios/>
        public Command_CrypticNumberOfUnits numberOfUnits
        {
            get
            {
                return this.numberOfUnitsField;
            }
            set
            {
                this.numberOfUnitsField = value;
            }
        }

        /// <comentarios/>
        public Command_CrypticIntelligentWorkstationInfo intelligentWorkstationInfo
        {
            get
            {
                return this.intelligentWorkstationInfoField;
            }
            set
            {
                this.intelligentWorkstationInfoField = value;
            }
        }

        /// <comentarios/>
        public Command_CrypticLongTextString longTextString
        {
            get
            {
                return this.longTextStringField;
            }
            set
            {
                this.longTextStringField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/HSFREQ_07_3_1A")]
    public partial class Command_CrypticMessageAction
    {

        private Command_CrypticMessageActionMessageFunctionDetails messageFunctionDetailsField;

        private string responseTypeField;

        /// <comentarios/>
        public Command_CrypticMessageActionMessageFunctionDetails messageFunctionDetails
        {
            get
            {
                return this.messageFunctionDetailsField;
            }
            set
            {
                this.messageFunctionDetailsField = value;
            }
        }

        /// <comentarios/>
        public string responseType
        {
            get
            {
                return this.responseTypeField;
            }
            set
            {
                this.responseTypeField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/HSFREQ_07_3_1A")]
    public partial class Command_CrypticMessageActionMessageFunctionDetails
    {

        private string businessFunctionField;

        private string messageFunctionField;

        private string[] additionalMessageFunctionField;

        /// <comentarios/>
        public string businessFunction
        {
            get
            {
                return this.businessFunctionField;
            }
            set
            {
                this.businessFunctionField = value;
            }
        }

        /// <comentarios/>
        public string messageFunction
        {
            get
            {
                return this.messageFunctionField;
            }
            set
            {
                this.messageFunctionField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("additionalMessageFunction")]
        public string[] additionalMessageFunction
        {
            get
            {
                return this.additionalMessageFunctionField;
            }
            set
            {
                this.additionalMessageFunctionField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/HSFREQ_07_3_1A")]
    public partial class Command_CrypticNumberOfUnits
    {

        private Command_CrypticNumberOfUnitsNumberOfUnitsDetails1 numberOfUnitsDetails1Field;

        private Command_CrypticNumberOfUnitsNumberOfUnitsDetails2[] numberOfUnitsDetails2Field;

        /// <comentarios/>
        public Command_CrypticNumberOfUnitsNumberOfUnitsDetails1 numberOfUnitsDetails1
        {
            get
            {
                return this.numberOfUnitsDetails1Field;
            }
            set
            {
                this.numberOfUnitsDetails1Field = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("numberOfUnitsDetails2")]
        public Command_CrypticNumberOfUnitsNumberOfUnitsDetails2[] numberOfUnitsDetails2
        {
            get
            {
                return this.numberOfUnitsDetails2Field;
            }
            set
            {
                this.numberOfUnitsDetails2Field = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/HSFREQ_07_3_1A")]
    public partial class Command_CrypticNumberOfUnitsNumberOfUnitsDetails1
    {

        private decimal unitsField;

        private string unitsQualifierField;

        /// <comentarios/>
        public decimal units
        {
            get
            {
                return this.unitsField;
            }
            set
            {
                this.unitsField = value;
            }
        }

        /// <comentarios/>
        public string unitsQualifier
        {
            get
            {
                return this.unitsQualifierField;
            }
            set
            {
                this.unitsQualifierField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/HSFREQ_07_3_1A")]
    public partial class Command_CrypticNumberOfUnitsNumberOfUnitsDetails2
    {

        private decimal unitsField;

        private bool unitsFieldSpecified;

        private string unitsQualifierField;

        /// <comentarios/>
        public decimal units
        {
            get
            {
                return this.unitsField;
            }
            set
            {
                this.unitsField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool unitsSpecified
        {
            get
            {
                return this.unitsFieldSpecified;
            }
            set
            {
                this.unitsFieldSpecified = value;
            }
        }

        /// <comentarios/>
        public string unitsQualifier
        {
            get
            {
                return this.unitsQualifierField;
            }
            set
            {
                this.unitsQualifierField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/HSFREQ_07_3_1A")]
    public partial class Command_CrypticIntelligentWorkstationInfo
    {

        private string companyIdentificationField;

        /// <comentarios/>
        public string companyIdentification
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/HSFREQ_07_3_1A")]
    public partial class Command_CrypticLongTextString
    {

        private string textStringDetailsField;

        /// <comentarios/>
        public string textStringDetails
        {
            get
            {
                return this.textStringDetailsField;
            }
            set
            {
                this.textStringDetailsField = value;
            }
        }
    }

}

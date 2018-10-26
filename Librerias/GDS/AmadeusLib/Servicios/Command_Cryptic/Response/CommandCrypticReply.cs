using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AmadeusLib.Servicios.Command_Cryptic.Response
{

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/HSFRES_07_3_1A")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://xml.amadeus.com/HSFRES_07_3_1A", IsNullable = false)]
    public partial class Command_CrypticReply
    {

        private Command_CrypticReplyMessageActionDetails messageActionDetailsField;

        private Command_CrypticReplyLongTextString longTextStringField;

        /// <comentarios/>
        public Command_CrypticReplyMessageActionDetails messageActionDetails
        {
            get
            {
                return this.messageActionDetailsField;
            }
            set
            {
                this.messageActionDetailsField = value;
            }
        }

        /// <comentarios/>
        public Command_CrypticReplyLongTextString longTextString
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/HSFRES_07_3_1A")]
    public partial class Command_CrypticReplyMessageActionDetails
    {

        private Command_CrypticReplyMessageActionDetailsMessageFunctionDetails messageFunctionDetailsField;

        private string responseTypeField;

        /// <comentarios/>
        public Command_CrypticReplyMessageActionDetailsMessageFunctionDetails messageFunctionDetails
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/HSFRES_07_3_1A")]
    public partial class Command_CrypticReplyMessageActionDetailsMessageFunctionDetails
    {

        private string businessFunctionField;

        private string messageFunctionField;

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
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/HSFRES_07_3_1A")]
    public partial class Command_CrypticReplyLongTextString
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

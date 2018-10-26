using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmadeusLib.Servicios.PNR_Retrieve.Request
{
    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRRET_10_1_1A")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://xml.amadeus.com/PNRRET_10_1_1A", IsNullable = false)]
    public partial class PNR_Retrieve
    {

        private PNR_RetrieveSettings settingsField;

        private PNR_RetrieveRetrievalFacts retrievalFactsField;

        /// <comentarios/>
        public PNR_RetrieveSettings settings
        {
            get
            {
                return this.settingsField;
            }
            set
            {
                this.settingsField = value;
            }
        }

        /// <comentarios/>
        public PNR_RetrieveRetrievalFacts retrievalFacts
        {
            get
            {
                return this.retrievalFactsField;
            }
            set
            {
                this.retrievalFactsField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRRET_10_1_1A")]
    public partial class PNR_RetrieveSettings
    {

        private decimal[] optionsField;

        private PNR_RetrieveSettingsPrinter printerField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayItemAttribute("optionCode", IsNullable = false)]
        public decimal[] options
        {
            get
            {
                return this.optionsField;
            }
            set
            {
                this.optionsField = value;
            }
        }

        /// <comentarios/>
        public PNR_RetrieveSettingsPrinter printer
        {
            get
            {
                return this.printerField;
            }
            set
            {
                this.printerField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRRET_10_1_1A")]
    public partial class PNR_RetrieveSettingsPrinter
    {

        private PNR_RetrieveSettingsPrinterIdentifierDetail identifierDetailField;

        private string officeField;

        private string teletypeAddressField;

        /// <comentarios/>
        public PNR_RetrieveSettingsPrinterIdentifierDetail identifierDetail
        {
            get
            {
                return this.identifierDetailField;
            }
            set
            {
                this.identifierDetailField = value;
            }
        }

        /// <comentarios/>
        public string office
        {
            get
            {
                return this.officeField;
            }
            set
            {
                this.officeField = value;
            }
        }

        /// <comentarios/>
        public string teletypeAddress
        {
            get
            {
                return this.teletypeAddressField;
            }
            set
            {
                this.teletypeAddressField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRRET_10_1_1A")]
    public partial class PNR_RetrieveSettingsPrinterIdentifierDetail
    {

        private string nameField;

        private string networkField;

        /// <comentarios/>
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <comentarios/>
        public string network
        {
            get
            {
                return this.networkField;
            }
            set
            {
                this.networkField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRRET_10_1_1A")]
    public partial class PNR_RetrieveRetrievalFacts
    {

        private PNR_RetrieveRetrievalFactsRetrieve retrieveField;

        private PNR_RetrieveRetrievalFactsReservationOrProfileIdentifier reservationOrProfileIdentifierField;

        private PNR_RetrieveRetrievalFactsPersonalFacts personalFactsField;

        private PNR_RetrieveRetrievalFactsFrequentFlyer frequentFlyerField;

        private PNR_RetrieveRetrievalFactsAccounting accountingField;

        /// <comentarios/>
        public PNR_RetrieveRetrievalFactsRetrieve retrieve
        {
            get
            {
                return this.retrieveField;
            }
            set
            {
                this.retrieveField = value;
            }
        }

        /// <comentarios/>
        public PNR_RetrieveRetrievalFactsReservationOrProfileIdentifier reservationOrProfileIdentifier
        {
            get
            {
                return this.reservationOrProfileIdentifierField;
            }
            set
            {
                this.reservationOrProfileIdentifierField = value;
            }
        }

        /// <comentarios/>
        public PNR_RetrieveRetrievalFactsPersonalFacts personalFacts
        {
            get
            {
                return this.personalFactsField;
            }
            set
            {
                this.personalFactsField = value;
            }
        }

        /// <comentarios/>
        public PNR_RetrieveRetrievalFactsFrequentFlyer frequentFlyer
        {
            get
            {
                return this.frequentFlyerField;
            }
            set
            {
                this.frequentFlyerField = value;
            }
        }

        /// <comentarios/>
        public PNR_RetrieveRetrievalFactsAccounting accounting
        {
            get
            {
                return this.accountingField;
            }
            set
            {
                this.accountingField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRRET_10_1_1A")]
    public partial class PNR_RetrieveRetrievalFactsRetrieve
    {

        private string typeField;

        private string serviceField;

        private string tattooField;

        private string officeField;

        private string targetSystemField;

        private string option1Field;

        private string option2Field;

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
        public string service
        {
            get
            {
                return this.serviceField;
            }
            set
            {
                this.serviceField = value;
            }
        }

        /// <comentarios/>
        public string tattoo
        {
            get
            {
                return this.tattooField;
            }
            set
            {
                this.tattooField = value;
            }
        }

        /// <comentarios/>
        public string office
        {
            get
            {
                return this.officeField;
            }
            set
            {
                this.officeField = value;
            }
        }

        /// <comentarios/>
        public string targetSystem
        {
            get
            {
                return this.targetSystemField;
            }
            set
            {
                this.targetSystemField = value;
            }
        }

        /// <comentarios/>
        public string option1
        {
            get
            {
                return this.option1Field;
            }
            set
            {
                this.option1Field = value;
            }
        }

        /// <comentarios/>
        public string option2
        {
            get
            {
                return this.option2Field;
            }
            set
            {
                this.option2Field = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRRET_10_1_1A")]
    public partial class PNR_RetrieveRetrievalFactsReservationOrProfileIdentifier
    {

        private PNR_RetrieveRetrievalFactsReservationOrProfileIdentifierReservation reservationField;

        /// <comentarios/>
        public PNR_RetrieveRetrievalFactsReservationOrProfileIdentifierReservation reservation
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRRET_10_1_1A")]
    public partial class PNR_RetrieveRetrievalFactsReservationOrProfileIdentifierReservation
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRRET_10_1_1A")]
    public partial class PNR_RetrieveRetrievalFactsPersonalFacts
    {

        private PNR_RetrieveRetrievalFactsPersonalFactsTravellerInformation travellerInformationField;

        private PNR_RetrieveRetrievalFactsPersonalFactsProductInformation productInformationField;

        private PNR_RetrieveRetrievalFactsPersonalFactsTicket ticketField;

        /// <comentarios/>
        public PNR_RetrieveRetrievalFactsPersonalFactsTravellerInformation travellerInformation
        {
            get
            {
                return this.travellerInformationField;
            }
            set
            {
                this.travellerInformationField = value;
            }
        }

        /// <comentarios/>
        public PNR_RetrieveRetrievalFactsPersonalFactsProductInformation productInformation
        {
            get
            {
                return this.productInformationField;
            }
            set
            {
                this.productInformationField = value;
            }
        }

        /// <comentarios/>
        public PNR_RetrieveRetrievalFactsPersonalFactsTicket ticket
        {
            get
            {
                return this.ticketField;
            }
            set
            {
                this.ticketField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRRET_10_1_1A")]
    public partial class PNR_RetrieveRetrievalFactsPersonalFactsTravellerInformation
    {

        private PNR_RetrieveRetrievalFactsPersonalFactsTravellerInformationTraveller travellerField;

        private PNR_RetrieveRetrievalFactsPersonalFactsTravellerInformationPassenger passengerField;

        /// <comentarios/>
        public PNR_RetrieveRetrievalFactsPersonalFactsTravellerInformationTraveller traveller
        {
            get
            {
                return this.travellerField;
            }
            set
            {
                this.travellerField = value;
            }
        }

        /// <comentarios/>
        public PNR_RetrieveRetrievalFactsPersonalFactsTravellerInformationPassenger passenger
        {
            get
            {
                return this.passengerField;
            }
            set
            {
                this.passengerField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRRET_10_1_1A")]
    public partial class PNR_RetrieveRetrievalFactsPersonalFactsTravellerInformationTraveller
    {

        private string surnameField;

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
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRRET_10_1_1A")]
    public partial class PNR_RetrieveRetrievalFactsPersonalFactsTravellerInformationPassenger
    {

        private string firstNameField;

        /// <comentarios/>
        public string firstName
        {
            get
            {
                return this.firstNameField;
            }
            set
            {
                this.firstNameField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRRET_10_1_1A")]
    public partial class PNR_RetrieveRetrievalFactsPersonalFactsProductInformation
    {

        private PNR_RetrieveRetrievalFactsPersonalFactsProductInformationProduct productField;

        private PNR_RetrieveRetrievalFactsPersonalFactsProductInformationBoardpointDetail boardpointDetailField;

        private PNR_RetrieveRetrievalFactsPersonalFactsProductInformationOffpointDetail offpointDetailField;

        private PNR_RetrieveRetrievalFactsPersonalFactsProductInformationCompany companyField;

        private PNR_RetrieveRetrievalFactsPersonalFactsProductInformationProductDetails productDetailsField;

        /// <comentarios/>
        public PNR_RetrieveRetrievalFactsPersonalFactsProductInformationProduct product
        {
            get
            {
                return this.productField;
            }
            set
            {
                this.productField = value;
            }
        }

        /// <comentarios/>
        public PNR_RetrieveRetrievalFactsPersonalFactsProductInformationBoardpointDetail boardpointDetail
        {
            get
            {
                return this.boardpointDetailField;
            }
            set
            {
                this.boardpointDetailField = value;
            }
        }

        /// <comentarios/>
        public PNR_RetrieveRetrievalFactsPersonalFactsProductInformationOffpointDetail offpointDetail
        {
            get
            {
                return this.offpointDetailField;
            }
            set
            {
                this.offpointDetailField = value;
            }
        }

        /// <comentarios/>
        public PNR_RetrieveRetrievalFactsPersonalFactsProductInformationCompany company
        {
            get
            {
                return this.companyField;
            }
            set
            {
                this.companyField = value;
            }
        }

        /// <comentarios/>
        public PNR_RetrieveRetrievalFactsPersonalFactsProductInformationProductDetails productDetails
        {
            get
            {
                return this.productDetailsField;
            }
            set
            {
                this.productDetailsField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRRET_10_1_1A")]
    public partial class PNR_RetrieveRetrievalFactsPersonalFactsProductInformationProduct
    {

        private string depDateField;

        private string depTimeField;

        private string arrDateField;

        /// <comentarios/>
        public string depDate
        {
            get
            {
                return this.depDateField;
            }
            set
            {
                this.depDateField = value;
            }
        }

        /// <comentarios/>
        public string depTime
        {
            get
            {
                return this.depTimeField;
            }
            set
            {
                this.depTimeField = value;
            }
        }

        /// <comentarios/>
        public string arrDate
        {
            get
            {
                return this.arrDateField;
            }
            set
            {
                this.arrDateField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRRET_10_1_1A")]
    public partial class PNR_RetrieveRetrievalFactsPersonalFactsProductInformationBoardpointDetail
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRRET_10_1_1A")]
    public partial class PNR_RetrieveRetrievalFactsPersonalFactsProductInformationOffpointDetail
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRRET_10_1_1A")]
    public partial class PNR_RetrieveRetrievalFactsPersonalFactsProductInformationCompany
    {

        private string codeField;

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
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRRET_10_1_1A")]
    public partial class PNR_RetrieveRetrievalFactsPersonalFactsProductInformationProductDetails
    {

        private decimal identificationField;

        private string subtypeField;

        /// <comentarios/>
        public decimal identification
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
        public string subtype
        {
            get
            {
                return this.subtypeField;
            }
            set
            {
                this.subtypeField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRRET_10_1_1A")]
    public partial class PNR_RetrieveRetrievalFactsPersonalFactsTicket
    {

        private string airlineField;

        private string ticketNumberField;

        /// <comentarios/>
        public string airline
        {
            get
            {
                return this.airlineField;
            }
            set
            {
                this.airlineField = value;
            }
        }

        /// <comentarios/>
        public string ticketNumber
        {
            get
            {
                return this.ticketNumberField;
            }
            set
            {
                this.ticketNumberField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRRET_10_1_1A")]
    public partial class PNR_RetrieveRetrievalFactsFrequentFlyer
    {

        private PNR_RetrieveRetrievalFactsFrequentFlyerFrequentTraveller frequentTravellerField;

        /// <comentarios/>
        public PNR_RetrieveRetrievalFactsFrequentFlyerFrequentTraveller frequentTraveller
        {
            get
            {
                return this.frequentTravellerField;
            }
            set
            {
                this.frequentTravellerField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRRET_10_1_1A")]
    public partial class PNR_RetrieveRetrievalFactsFrequentFlyerFrequentTraveller
    {

        private string companyIdField;

        private string membershipNumberField;

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
        public string membershipNumber
        {
            get
            {
                return this.membershipNumberField;
            }
            set
            {
                this.membershipNumberField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRRET_10_1_1A")]
    public partial class PNR_RetrieveRetrievalFactsAccounting
    {

        private PNR_RetrieveRetrievalFactsAccountingAccount accountField;

        /// <comentarios/>
        public PNR_RetrieveRetrievalFactsAccountingAccount account
        {
            get
            {
                return this.accountField;
            }
            set
            {
                this.accountField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xml.amadeus.com/PNRRET_10_1_1A")]
    public partial class PNR_RetrieveRetrievalFactsAccountingAccount
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
}

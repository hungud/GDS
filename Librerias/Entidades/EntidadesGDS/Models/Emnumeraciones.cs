namespace EntidadesGDS
{
    // =============================
    // emnumeraciones

    #region "emnumeraciones"

    public enum EnumTipoMensaje
    {
        Alerta,
        Error
    }

    public enum EnumAplicaciones
    {
        Interagencia,
        SabreRed,
        Turbo,
        SistemaCentral,
        MotorEmisionesSrv,
        RobotAnulaciones,
        Pta
    }

    public enum EnumRepuestaSimple
    {
        Si = 1,
        No = 0
    }

    public enum EnumTipoGds
    {
        Amadeus = 0,
        Sabre = 1,
        Worldspan = 2,
        Kiu = 3,
        Resiber = 4,
        TravelAce = 5,  
    }

    public enum EnumTipoSegmento
    {
        AIR,
        CAR,
        HHT,
        INS
    }

    public enum EnumTipoRutaItinerario
    {
        Nacional,
        Internacional
    }

    public enum EnumTipoViaje
    {
        RT,
        OW
    }

    public enum EnumTipoVuelo
    {
        ON,
        OFF
    }

    public enum EnumTipoFormaPago
    {
        CASH,
        CARD
    }

    public enum EnumTipoFormaPagoComision
    {
        CASH,
        CARD,
        CARDCASH
    }

    public enum EnumCodigoTarifa
    {
        PV,
        PL
    }

    public enum EnumTipoTarifa
    {
        FV,
        IT
    }

    public enum EnumTipoDocumento
    {
        DNI,                   // DNI
        CarnetExtranjeria,     // CE
        Pasaporte              // PAS
    }

    public enum EnumTipoComprobanteFacturacion
    {
        DC,
        FC,
        BV
    }

    public enum EnumTipoDocumentoFacturacion
    {
        RUC,                   // RUC
        DNI,                   // DNI
        CarnetExtranjeria,     // CE
        Pasaporte              // PAS
    }

    public enum EnumSexo
    {
        M,
        F
    }

    public enum EnumTipoCodigoComision
    {
        NetRemit,                   
        TourCode
    }

    public enum EnumTipoComentario
    {
        AlphaCoded,
        ClientAddress,
        Corporate,
        DeliveryAddress,
        General,
        GroupName,
        Hidden,
        Historical,
        Invoice,
        Itinerary
    }

    public enum EnumQueueNavigation
    {
        I,
        IR,
        E,
        EL,
        ER,
        QR,
        QXI,            // Sali e Ignorar
        QXIR,
        QXE,
        QXR,            // Remover
        QXER
    }

    public enum EnumQueueDirection 
    {
        I,              // Ignorar
        E,              // Cerrar
        L,
        U
    }

    public enum EnumSpecialServiceInfoType
    {
        FOID,
        DOCS,
        INFT
    }

    public enum EnumTipoOADP
    {
        Itinerario = 1,
        Boleto = 2,
        Emd = 3,
        Voucher = 4,
        Cupon = 5,
        AutotizacionExch = 6,
    }

    public enum EnumHeaderPassengerReceipt
    {
        DuplicadoTKT = 1,
        Boleto = 2,
        Emd = 3,
    }

    public enum EnumTypeTravelItineraryReadKiu
    {
        Itinetario = 14,
        Boleto = 30,
    }

    public enum EnumTransactionType
    {
        Stateless,
        Start,
        InSeries,
        End
    }

    public enum EnumEnvironment
    {
        Prod,
        Test,
    }
    #endregion
}

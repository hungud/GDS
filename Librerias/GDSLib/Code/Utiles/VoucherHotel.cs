using EntidadesGDS.Hotel;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDSLib.Utiles
{
    public class VoucherHotel
    {
        public RQ_SegmentoHotelBase _SegmentoHotel { get; set; }
        
        private static BaseColor BACKGROUND_TABLE_TITULO = new BaseColor(192, 198, 200);
        private static BaseColor BORDER_TABLE_TITULO = new BaseColor(238, 134, 21);
        private static Font FUENTE_TITULO = FontFactory.GetFont("Arial", 12, BaseColor.BLACK);
        private static Font FUENTE_TEXTO = FontFactory.GetFont("Arial", 10, BaseColor.BLACK);
        private static Font FUENTE_HEADER_TITULO = FontFactory.GetFont("Arial", 8, BaseColor.BLACK);
        private static Font FUENTE_VOUCHER = FontFactory.GetFont("Arial", 13, BaseColor.BLACK);

        #region generacionPDF

        public void buildVoucher()
        {
            Document document = new Document(PageSize.A4, 40, 40, 40, 40);
            MemoryStream memoryStream = new MemoryStream();
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(@"D:\pdf\reporte_v3.pdf", FileMode.Create));
            //PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);
            document.Open();

            builderHeader(ref document);
            buildPasajeros(ref document);
            buildHotel(ref document);
            if (!string.IsNullOrWhiteSpace(_SegmentoHotel.Observacion))
            {
                buildObservaciones(ref document);
            }

            document.Close();
        }

        private PdfPCell CreateCell(string target)
        {
            return new PdfPCell(new Phrase(target, FUENTE_TEXTO))
            {
                Border = iTextSharp.text.Rectangle.NO_BORDER,
                Padding = 7f
            };
        }

        private PdfPCell CreateCellForTitle(string target)
        {
            return new PdfPCell(new Phrase(target, FUENTE_TITULO))
            {
                Padding = 7,
                VerticalAlignment = PdfPCell.ALIGN_CENTER,
                BackgroundColor = BACKGROUND_TABLE_TITULO,
                BorderColor = BORDER_TABLE_TITULO
            };
        }

        private void buildPasajeros(ref Document document)
        {
            PdfPTable table_pasajeros = new PdfPTable(1);
            PdfPCell celda_titulo_pasajero = CreateCellForTitle("Pasajeros");
            celda_titulo_pasajero.Border = iTextSharp.text.Rectangle.NO_BORDER;
            celda_titulo_pasajero.BorderWidthLeft = 0.5f;
            celda_titulo_pasajero.BorderWidthTop = 0.5f;
            celda_titulo_pasajero.BorderWidthBottom = 0.5f;
            table_pasajeros.AddCell(celda_titulo_pasajero);
            _SegmentoHotel.Pasajeros.ForEach(pasajero =>
            {
                table_pasajeros.AddCell(CreateCell(pasajero.Nombre + " " + pasajero.Apellido));
            });

            PdfPTable table_alojamiento = new PdfPTable(2);
            table_alojamiento.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
            PdfPCell celda_titulo_alojamiento = CreateCellForTitle("Alojamiento");
            celda_titulo_alojamiento.Border = iTextSharp.text.Rectangle.NO_BORDER;
            celda_titulo_alojamiento.BorderWidthRight = 0.5f;
            celda_titulo_alojamiento.BorderWidthTop = 0.5f;
            celda_titulo_alojamiento.BorderWidthBottom = 0.5f;
            celda_titulo_alojamiento.Colspan = 2;

            table_alojamiento.AddCell(celda_titulo_alojamiento);
            table_alojamiento.AddCell(CreateCell("Check In"));
            table_alojamiento.AddCell(CreateCell(_SegmentoHotel.FechaInicioReserva));
            table_alojamiento.AddCell(CreateCell("Check Out"));
            table_alojamiento.AddCell(CreateCell(_SegmentoHotel.FechaFinReserva));

            PdfPCell space = CreateCell("\n");
            space.Colspan = 2;
            table_alojamiento.AddCell(space);

            table_alojamiento.AddCell(CreateCell("Tipo de Habitación"));
            table_alojamiento.AddCell(CreateCell(_SegmentoHotel.TipoHabitacion.Valor));
            table_alojamiento.AddCell(CreateCell("Forma Pago"));
            table_alojamiento.AddCell(CreateCell(_SegmentoHotel.PagoEn.Equals("D") ? "Destino" :  "Agencia"));

            PdfPCell celda_alojamiento = new PdfPCell(table_alojamiento)
            {
                Border = iTextSharp.text.Rectangle.NO_BORDER
            };

            PdfPCell celda_pasajeros = new PdfPCell(table_pasajeros)
            {
                Border = iTextSharp.text.Rectangle.NO_BORDER
            };

            PdfPTable headerPasajero = new PdfPTable(2)
            {
                WidthPercentage = 100,
                SpacingBefore = 12,
                PaddingTop = 50f
            };
            headerPasajero.SetWidths(new float[] { 58, 42 });
            headerPasajero.AddCell(celda_pasajeros);
            headerPasajero.AddCell(celda_alojamiento);

            document.Add(headerPasajero);
        }

        private void builderHeader(ref Document document)
        {
            PdfPTable tabla_header = new PdfPTable(3);
            tabla_header.WidthPercentage = 100;
            tabla_header.SetWidths(new float[] { 25, 50, 25f });

            iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(@"D:\pdf\nmlogo.jpg");
            logo.ScaleToFit(200, 55);

            tabla_header.AddCell(new PdfPCell(logo)
            {
                Border = iTextSharp.text.Rectangle.NO_BORDER,
                BorderColorBottom = new BaseColor(94, 95, 95),
                BorderWidthBottom = 2f
            });

            PdfPTable tabla_informacion = new PdfPTable(1);
            tabla_informacion.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
            tabla_informacion.AddCell(new Phrase("Av. Jose Pardo 801", FUENTE_HEADER_TITULO));
            tabla_informacion.AddCell(new Phrase("Miraflores - Lima - Perú", FUENTE_HEADER_TITULO));
            tabla_informacion.AddCell(new Phrase("Tel. Horario de oficina: (511) 610-9380", FUENTE_HEADER_TITULO));
            tabla_informacion.AddCell(new Phrase("Tel. Emergencia: (511) 626-9399", FUENTE_HEADER_TITULO));

            tabla_header.AddCell(new PdfPCell(tabla_informacion)
            {
                Border = iTextSharp.text.Rectangle.NO_BORDER,
                BorderColorBottom = new BaseColor(94, 95, 95),
                BorderWidthBottom = 2f,
                PaddingBottom = 12f,
                PaddingLeft = 25f,
                PaddingTop = 10f
            });

            PdfPTable tabla_voucher = new PdfPTable(1);
            tabla_voucher.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
            tabla_voucher.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            tabla_voucher.AddCell(new PdfPCell(new Phrase("Voucher", FUENTE_VOUCHER))
            {
                Border = iTextSharp.text.Rectangle.NO_BORDER,
                HorizontalAlignment = PdfPCell.ALIGN_CENTER,
                BorderWidthLeft = 1f,
                BorderWidthRight = 1f,
                BorderWidthTop = 1f,
                BorderColor = new BaseColor(94, 95, 95)
            });

            tabla_voucher.AddCell(new PdfPCell(new Phrase("N° " + _SegmentoHotel.CodigoReservaHotel, FUENTE_VOUCHER))
            {
                Border = iTextSharp.text.Rectangle.NO_BORDER,
                PaddingTop = 3,
                HorizontalAlignment = PdfPCell.ALIGN_CENTER,
                VerticalAlignment = PdfPCell.ALIGN_CENTER,
                BorderWidthLeft = 1f,
                BorderWidthRight = 1f,
                BorderWidthBottom = 1f,
                BorderColor = new BaseColor(94, 95, 95)
            });

            tabla_header.AddCell(new PdfPCell(tabla_voucher)
            {
                Border = iTextSharp.text.Rectangle.NO_BORDER,
                BorderColorBottom = new BaseColor(94, 95, 95),
                BorderWidthBottom = 2f,
                PaddingBottom = 20f,
                PaddingLeft = 10f,
                PaddingTop = 10f
            });
            document.Add(tabla_header);
        }

        private void buildHotel(ref Document document)
        {
            PdfPCell celdaTitulo = CreateCellForTitle("Datos Hotel");
            celdaTitulo.Colspan = 2;

            PdfPTable tablaPrincipal = new PdfPTable(2)
            {
                SpacingBefore = 12,
                PaddingTop = 8f,
                WidthPercentage = 100
            };
            tablaPrincipal.SetWidths(new float[] { 15, 85 });
            tablaPrincipal.AddCell(celdaTitulo);
            tablaPrincipal.AddCell(CreateCell("Nombre"));
            tablaPrincipal.AddCell(CreateCell(_SegmentoHotel.Hotel.Nombre));
            tablaPrincipal.AddCell(CreateCell("Dirección"));
            tablaPrincipal.AddCell(CreateCell(_SegmentoHotel.Hotel.Direccion));
            tablaPrincipal.AddCell(CreateCell("Email"));
            tablaPrincipal.AddCell(CreateCell(!string.IsNullOrWhiteSpace(_SegmentoHotel.Hotel.Correo) ? _SegmentoHotel.Hotel.Correo : "-" ));
            tablaPrincipal.AddCell(CreateCell("Teléfono"));
            tablaPrincipal.AddCell(CreateCell(_SegmentoHotel.Hotel.Telefono));
            document.Add(tablaPrincipal);
        }

        private void buildObservaciones(ref Document document)
        {
            PdfPCell celda_1 = CreateCellForTitle("Observaciones");
            PdfPTable tablaPrincipal = new PdfPTable(1)
            {
                SpacingBefore = 12,
                PaddingTop = 50f,
                WidthPercentage = 100
            };
            tablaPrincipal.AddCell(celda_1);
            tablaPrincipal.AddCell(CreateCell(_SegmentoHotel.Observacion));
            document.Add(tablaPrincipal);
        }


        #endregion


    }
}

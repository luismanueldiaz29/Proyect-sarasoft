using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace BLL {
    public class Infraestructura {
        decimal totalFactura = 0;
        public void GuardarPdf(IList<Cliente> clientes, string ruta) {
            FileStream fileStream = new FileStream(ruta, FileMode.Create);
            Document document = new Document(iTextSharp.text.PageSize.LETTER, 10, 30, 30, 10);
            PdfWriter pw = PdfWriter.GetInstance(document, fileStream);

            document.AddTitle("Sarasoft");
            document.AddAuthor("Proyecto Sarasoft");

            document.Open();

            document.Add(new Paragraph("Lista de clientes de la tienda"+"         "+"prueba"));
            document.Add(new Paragraph("\n"));
            document.Add(LlenarTabla(clientes));
            

            document.Close();

        }

        public PdfPTable LlenarTabla(IList<Cliente> clientes)
        {
            PdfPTable tabla = new PdfPTable(9);

            tabla.AddCell(new Paragraph("Identificación"));
            tabla.AddCell(new Paragraph("Primer nombre"));
            tabla.AddCell(new Paragraph("Segundo nombre"));
            tabla.AddCell(new Paragraph("Primer apellido"));
            tabla.AddCell(new Paragraph("Segundo apellido"));
            tabla.AddCell(new Paragraph("Direccion"));
            tabla.AddCell(new Paragraph("telefono #1"));
            tabla.AddCell(new Paragraph("telefono #2"));
            tabla.AddCell(new Paragraph("Correo"));
            foreach (var item in clientes)
            {
                tabla.AddCell(item.IdCliente);
                tabla.AddCell(item.Nombre1);
                tabla.AddCell(item.Nombre2);
                tabla.AddCell(item.Apellido1);
                tabla.AddCell(item.Apellido2);
                tabla.AddCell(item.Direccion);
                tabla.AddCell(item.Telefono1);
                tabla.AddCell(item.Telefono2);
                tabla.AddCell(item.Correo);

            }

            return tabla;
        }
        public void GuardarFactura(IList<Detalle> detalles, string ruta, Factura factura)
        {
            FileStream fs = new FileStream(ruta, FileMode.Create);
            Document document = new Document(iTextSharp.text.PageSize.LEGAL, 40, 40, 40, 40);
            PdfWriter pw = PdfWriter.GetInstance(document, fs);

            document.AddTitle("sarasoft");
            document.AddCreator("Proyecto Sarasoft");

            document.Open();
            DateTime fecha = DateTime.Now;
            string fechaactual = fecha.ToString();
            // Escribimos el encabezamiento en el documento
            document.Add(new Paragraph(fechaactual));
            document.Add(Chunk.NEWLINE);
            //margenes
            var content = pw.DirectContent;
            var pageBorderRect = new Rectangle(document.PageSize);

            pageBorderRect.Left += document.LeftMargin;
            pageBorderRect.Right -= document.RightMargin;
            pageBorderRect.Top -= document.TopMargin;
            pageBorderRect.Bottom += document.BottomMargin;

            content.SetColorStroke(BaseColor.BLACK);
            content.Rectangle(pageBorderRect.Left, pageBorderRect.Bottom, pageBorderRect.Width, pageBorderRect.Height);
            content.Stroke();
            //pie de pagina 

            PdfPTable tabFot = new PdfPTable(new float[] { 1F });
            PdfPCell cell;
            tabFot.TotalWidth = 50F;
            cell = new PdfPCell(new Phrase("Sarasoft", FontFactory.GetFont("ARIAL", 8, iTextSharp.text.Font.BOLD)));
            tabFot.AddCell(cell);
            tabFot.WriteSelectedRows(0, -1, 500, document.Bottom, pw.DirectContent);

            // logo
            string rutaimagen = @"C:\Users\AISM\Downloads\ProyectoTienda3 Díaz(5)\Resources\temp20190715-56303-ymuzcz.png";
            iTextSharp.text.Image imagen = iTextSharp.text.Image.GetInstance(rutaimagen);
            imagen.BorderWidth = 0;
            imagen.Alignment = Element.ALIGN_CENTER;
            float percentage = 0.0f;
            percentage = 150 / imagen.Width;
            imagen.ScalePercent(percentage * 100);
            document.Add(imagen);

            Paragraph tienda = new Paragraph("SARASOFT\n");
            tienda.Alignment = Element.ALIGN_CENTER;
            document.Add(tienda);
            Paragraph asteriscos = new Paragraph("**********\n");
            asteriscos.Alignment = Element.ALIGN_CENTER;
            document.Add(asteriscos);
            Paragraph direccion = new Paragraph("Dir: Barrio El Cerro.Peñoncito, Bolívar\n");
            direccion.Alignment = Element.ALIGN_CENTER;
            document.Add(direccion);
            Paragraph telefono = new Paragraph("Tel: 3243454563\n");
            telefono.Alignment = Element.ALIGN_CENTER;
            document.Add(telefono);
            document.Add(new Paragraph("\n"));
            Paragraph detalle = new Paragraph("Factura de venta\n");
            detalle.Alignment = Element.ALIGN_CENTER;
            document.Add(detalle);

            Paragraph NoFact = new Paragraph("No fact:" + factura.Codigo + "\n");
            NoFact.Alignment = Element.ALIGN_CENTER;
            document.Add(NoFact);
            Paragraph fecha_ = new Paragraph("Fecha creacion:" + factura.Fecha + "\n");
            fecha_.Alignment = Element.ALIGN_CENTER;
            document.Add(fecha_);
            Paragraph fechaImpresion = new Paragraph("Fecha impresion:" + DateTime.Now.ToString() + "\n");
            fechaImpresion.Alignment = Element.ALIGN_CENTER;
            document.Add(fechaImpresion);
            document.Add(new Paragraph("\n"));


            //lo que dimos en clase 
            document.Add(new Paragraph("                       Lista de Productos comprados", FontFactory.GetFont("ARIAL BLACK", 20, iTextSharp.text.Font.BOLD)));

            document.Add(new Paragraph("\n"));
            document.Add(LlenarTabla2(detalles));

            document.Add(new Paragraph("\n"));
            Paragraph totalPagar = new Paragraph("Total pagar:" + totalFactura + "\n");
            totalPagar.Alignment = Element.ALIGN_CENTER; 
            document.Add(totalPagar);
            document.Add(new Paragraph("\n"));
            Paragraph saludo = new Paragraph("Gracias por preferirnos\n");
            saludo.Alignment = Element.ALIGN_CENTER;
            document.Add(saludo);

            document.Close();

        }
        public PdfPTable LlenarTabla2(IList<Detalle> detalles)
        {
            PdfPTable tabla = new PdfPTable(5);

            
            tabla.AddCell(new Paragraph("Nombre producto"));
            
            tabla.AddCell(new Paragraph("Cantidad"));
            tabla.AddCell(new Paragraph("Costo"));
            tabla.AddCell(new Paragraph("Presentacion"));
            tabla.AddCell(new Paragraph("Subtotal"));
            
            

            foreach (var item in detalles)
            {
                
                tabla.AddCell(item.NombreProducto);
                
                tabla.AddCell(Convert.ToString(item.CantidadVendida));
                tabla.AddCell(Convert.ToString(item.Costo));
                tabla.AddCell(Convert.ToString(item.Presentacion));
                tabla.AddCell(Convert.ToString(item.SubTotal));

                totalFactura = totalFactura + item.SubTotal;


            }
            
            return tabla;
        }
    }
}

using System;
using System.Drawing;
using System.IO;
using APICadastroCliente.Models;
using iTextSharp.text;
using iTextSharp.text.html;
using iTextSharp.text.pdf;
using Rectangle = System.Drawing.Rectangle;

namespace APICadastroCliente.API.Services.Shared
{
    public class Usefuls
    {
        public static void clientesPdf(string pathDirectory, IEnumerable<Cliente> clientes)
        {

            // Criação do documento
            Document document = new Document();

            // Caminho para salvar o arquivo PDF
            string path = String.Concat(pathDirectory, "/wwwroot/temp/arquivo.pdf");

            // Criação do escritor de PDF
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(path, FileMode.Create));

            // Abertura do documento
            document.Open();

            PdfPTable table = new PdfPTable(6);
            PdfPCell cel = new PdfPCell();
            bool flag = false;

            Paragraph p0 = new Paragraph("Relatório de Clientes", FontFactory.GetFont("Times New Roman", 15, Font.BOLD, BaseColor.BLACK));
            p0.Alignment = Element.ALIGN_CENTER;
            document.Add(p0);
            document.Add(new Paragraph("\n"));

            cel.HorizontalAlignment = 1;
            table.TotalWidth = 560f;
            table.LockedWidth = true;

            cel.Phrase = new Phrase("Lista de Clientes", FontFactory.GetFont("Times New Roman", 13, Font.BOLD, BaseColor.WHITE));
            cel.Colspan = 6;
            cel.BackgroundColor = BaseColor.ORANGE;
            table.AddCell(cel);

            cel.Colspan = 1;
            cel.BackgroundColor = BaseColor.BLUE;

            cel.Phrase = new Phrase("ID", FontFactory.GetFont("Times New Roman", 11, Font.BOLD, BaseColor.WHITE));
            table.AddCell(cel);

            cel.Phrase = new Phrase("NOME", FontFactory.GetFont("Times New Roman", 11, Font.BOLD, BaseColor.WHITE));
            table.AddCell(cel);

            cel.Phrase = new Phrase("CPF", FontFactory.GetFont("Times New Roman", 11, Font.BOLD, BaseColor.WHITE));
            table.AddCell(cel);

            cel.Phrase = new Phrase("RG", FontFactory.GetFont("Times New Roman", 11, Font.BOLD, BaseColor.WHITE));
            table.AddCell(cel);

            cel.Phrase = new Phrase("DATA NASCIMENTO", FontFactory.GetFont("Times New Roman", 11, Font.BOLD, BaseColor.WHITE));
            table.AddCell(cel);

            cel.Phrase = new Phrase("OCUPAÇÃO", FontFactory.GetFont("Times New Roman", 11, Font.BOLD, BaseColor.WHITE));
            table.AddCell(cel);

            //cel.Phrase = new Phrase("EMAIL", FontFactory.GetFont("Times New Roman", 11, Font.BOLD, BaseColor.WHITE));
            //table.AddCell(cel);


            //cel.Phrase = new Phrase("DATA CASTRADO", FontFactory.GetFont("Times New Roman", 11, Font.BOLD, BaseColor.WHITE));
            //table.AddCell(cel);


            //cel.Phrase = new Phrase("LOGRADOURO", FontFactory.GetFont("Times New Roman", 11, Font.BOLD, BaseColor.WHITE));
            //table.AddCell(cel);


            //cel.Phrase = new Phrase("Nº", FontFactory.GetFont("Times New Roman", 11, Font.BOLD, BaseColor.WHITE));
            //table.AddCell(cel);


            //cel.Phrase = new Phrase("CIDADE", FontFactory.GetFont("Times New Roman", 11, Font.BOLD, BaseColor.WHITE));
            //table.AddCell(cel);


            //cel.Phrase = new Phrase("UF", FontFactory.GetFont("Times New Roman", 11, Font.BOLD, BaseColor.WHITE));
            //table.AddCell(cel);

            cel.BackgroundColor = BaseColor.WHITE;

            foreach (var m in clientes)
            {
                if (flag)
                {
                    cel.BackgroundColor = BaseColor.GRAY;
                }
                cel.Phrase = new Phrase(m.ClienteId.ToString(), FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK));
                table.AddCell(cel);

                cel.Phrase = new Phrase(m.Nome.ToString(), FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK));
                table.AddCell(cel);

                cel.Phrase = new Phrase(m.Cpf.ToString(), FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK));
                table.AddCell(cel);

                cel.Phrase = new Phrase(m.Rg.ToString(), FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK));
                table.AddCell(cel);

                cel.Phrase = new Phrase(m.DataNascimento.ToString(), FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK));
                table.AddCell(cel);

                cel.Phrase = new Phrase(m.Ocupacao.ToString(), FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK));
                table.AddCell(cel);

                //cel.Phrase = new Phrase(m.Email.ToString(), FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK));
                //table.AddCell(cel);

                //cel.Phrase = new Phrase(m.DataCadastro.ToString(), FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK));
                //table.AddCell(cel);

                //cel.Phrase = new Phrase(m.Endereco.Logradouro.ToString(), FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK));
                //table.AddCell(cel);

                //cel.Phrase = new Phrase(m.Endereco.Numero.ToString(), FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK));
                //table.AddCell(cel);

                //cel.Phrase = new Phrase(m.Endereco.Cidade.ToString(), FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK));
                //table.AddCell(cel);

                //cel.Phrase = new Phrase(m.Endereco.Estado.ToString(), FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK));
                //table.AddCell(cel);

                cel.BackgroundColor = BaseColor.WHITE;
                flag = !flag;
            }

            document.Add(table);

            // Fechamento do documento
            document.Close();

        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WkHtmlToPdfDotNet;
using WkHtmlToPdfDotNet.Contracts;

namespace RadfordHr
{
    public class PDFHelper
    {
        private readonly IConverter converter;

        public PDFHelper(IConverter converter)
        {
            this.converter = converter;
        }
        public byte[] PdfSharpConvert(string html)
        {
            try
            {
                var doc = new HtmlToPdfDocument()
                {
                    GlobalSettings = {
                    ColorMode = WkHtmlToPdfDotNet.ColorMode.Color,
                    Orientation = WkHtmlToPdfDotNet.Orientation.Portrait,
                    PaperSize = WkHtmlToPdfDotNet.PaperKind.A4,
                },
                    Objects = {
                    new ObjectSettings() {
                        PagesCount = true,
                        FooterSettings = { FontSize = 9, Right = "Page [page] of [toPage]", Line = true, Spacing = 2.812 },
                        HtmlContent = html,
                        UseLocalLinks = true,
                        UseExternalLinks = true,
                        WebSettings = { DefaultEncoding = "utf-8" }
                    }
                }
                };

                byte[] pdf = this.converter.Convert(doc);
                return pdf;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

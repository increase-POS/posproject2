using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Text;
using Microsoft.Reporting.WinForms;

namespace Microsoft.Reporting.WinForms
{
    public static class LocalReportExtensions
    {

        private static int m_currentPageIndex;
        private static IList<Stream> m_streams;
        private static PageSettings m_pageSettings;

        public static Stream CreateStream(string name,
          string fileNameExtension, Encoding encoding,
          string mimeType, bool willSeek)
        {
            Stream stream = new MemoryStream();
            m_streams.Add(stream);
            return stream;
        }

        public static void Export(LocalReport report, bool print = true)
        {
            PaperSize paperSize = m_pageSettings.PaperSize;
            Margins margins = m_pageSettings.Margins;

            // The device info string defines the page range to print as well as the size of the page.
            // A start and end page of 0 means generate all pages.
            string deviceInfo = string.Format(
                CultureInfo.InvariantCulture,
                "<DeviceInfo>" +
                    "<OutputFormat>EMF</OutputFormat>" +
                    "<PageWidth>{5}</PageWidth>" +
                    "<PageHeight>{4}</PageHeight>" +
                    "<MarginTop>{0}</MarginTop>" +
                    "<MarginLeft>{1}</MarginLeft>" +
                    "<MarginRight>{2}</MarginRight>" +
                    "<MarginBottom>{3}</MarginBottom>" +
                "</DeviceInfo>",
                ToInches(margins.Top),
                ToInches(margins.Left),
                ToInches(margins.Right),
                ToInches(margins.Bottom),
                ToInches(paperSize.Height),
                ToInches(paperSize.Width));

            Warning[] warnings;
            m_streams = new List<Stream>();
            report.Render("Image", deviceInfo, CreateStream,
               out warnings);
            foreach (Stream stream in m_streams)
                stream.Position = 0;

            if (print)
            {
                Print();
            }
        }
        public static void ExportToPDF(LocalReport report, String DirPath, String Filename)
        {/*
            Warning[] warnings;
            string[] streamIds;
            string mimeType = string.Empty;
            string encoding = string.Empty;
            string extension = string.Empty;

            var bytes = report.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);

            string fullpath = Path.Combine(DirPath, Filename);
            using (FileStream stream = new FileStream(fullpath.ToString(), FileMode.Create))
            {
                stream.Write(bytes, 0, bytes.Length);
                stream.Close();
            }
           
            */

            string deviceInfo = "<DeviceInfo>" +
                    "  <OutputFormat>PDF</OutputFormat>" +
                  
                    "  <EmbedFonts>None</EmbedFonts>" +
                    "</DeviceInfo>";
            string mimeType;
            string encoding;
            string fileNameExtension;
            Warning[] warnings;
            string[] streams;
            string fullpath = Path.Combine(DirPath, Filename);
            byte[] renderedBytes = report.Render("PDF", deviceInfo, out mimeType, out encoding, out fileNameExtension, out streams, out warnings);

            byte[] Bytes = report.Render(format: "PDF", deviceInfo: deviceInfo);
            // File.SetAttributes(savePath, FileAttributes.Normal);

            using (FileStream stream = new FileStream(fullpath, FileMode.Create))
            {
                stream.Write(Bytes, 0, Bytes.Length);
            }

        }

        // Handler for PrintPageEvents
        public static void PrintPage(object sender, PrintPageEventArgs e)
        {
            Stream pageToPrint = m_streams[m_currentPageIndex];
            pageToPrint.Position = 0;

            // Load each page into a Metafile to draw it.
            using (Metafile pageMetaFile = new Metafile(pageToPrint))
            {
                Rectangle adjustedRect = new Rectangle(
                        e.PageBounds.Left - (int)e.PageSettings.HardMarginX,
                        e.PageBounds.Top - (int)e.PageSettings.HardMarginY,
                        e.PageBounds.Width,
                        e.PageBounds.Height);

                // Draw a white background for the report
                e.Graphics.FillRectangle(Brushes.White, adjustedRect);

                // Draw the report content
                e.Graphics.DrawImage(pageMetaFile, adjustedRect);

                // Prepare for next page.  Make sure we haven't hit the end.
                m_currentPageIndex++;
                e.HasMorePages = m_currentPageIndex < m_streams.Count;
            }
        }

        public static void Print()
        {
            if (m_streams == null || m_streams.Count == 0)
                throw new Exception("Error: no stream to print.");
            PrintDocument printDoc = new PrintDocument();
            if (!printDoc.PrinterSettings.IsValid)
            {
                throw new Exception("Error: cannot find the default printer.");
            }
            else
            {
                printDoc.PrintPage += new PrintPageEventHandler(PrintPage);
                m_currentPageIndex = 0;
                printDoc.Print();
            }
        }

        public static void PrintToPrinter(this LocalReport report)
        {
            m_pageSettings = new PageSettings();
            ReportPageSettings reportPageSettings = report.GetDefaultPageSettings();

            m_pageSettings.PaperSize = reportPageSettings.PaperSize;
            m_pageSettings.Margins = reportPageSettings.Margins;

            Export(report);
        }

        public static void DisposePrint()
        {
            if (m_streams != null)
            {
                foreach (Stream stream in m_streams)
                    stream.Close();
                m_streams = null;
            }
        }

        private static string ToInches(int hundrethsOfInch)
        {
            double inches = hundrethsOfInch / 100.0;
            return inches.ToString(CultureInfo.InvariantCulture) + "in";
        }
    }
}
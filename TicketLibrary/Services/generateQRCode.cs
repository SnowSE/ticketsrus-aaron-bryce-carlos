using QRCoder;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketLibrary.Services
{
    public class generateQRCode
    {


        public static string GenerateQRCodeBase64(string qrCodeText)
        {
            if (!string.IsNullOrEmpty(qrCodeText))
            {
                using MemoryStream ms = new();
                QRCodeGenerator qrCodeGenerate = new();
                QRCodeData qrCodeData = qrCodeGenerate.CreateQrCode(qrCodeText, QRCodeGenerator.ECCLevel.Q);
                QRCode qrCode = new(qrCodeData);
                using Bitmap qrBitMap = qrCode.GetGraphic(20);
                qrBitMap.Save(ms, ImageFormat.Png);
                string base64 = Convert.ToBase64String(ms.ToArray());
                return string.Format("data:image/png;base64,{0}", base64);
            }

            return "";
            /*using (MemoryStream ms = new MemoryStream())
            {
                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrCodeText, QRCodeGenerator.ECCLevel.Q);
                QRCode qrCode = new QRCode(qrCodeData);
                using (Bitmap qrCodeImage = qrCode.GetGraphic(20))
                {
                    qrCodeImage.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    byte[] qrCodeBytes = ms.ToArray();
                    return Convert.ToBase64String(qrCodeBytes);
                }
            }*/
        }
    }
}

using Admin.Common.Attributes;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Common.Helpers
{
    [SingleInstance]
    public class VerifyCodeHelper
    {
        private string GenerateRandom(int length)
        {
            var chars= new StringBuilder();
            char[] charcter = {'1','2','3','4','5','6','7','8','9','0',
                'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z',
                'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'
            };
            Random random = new Random();
            for (int i = 0; i < length; i++) {
                chars.Append(charcter[random.Next(charcter.Length)]);
            }
            return chars.ToString();
        }

        private byte[] Draw(out string code, int length = 4) {
            int codeW = 110;
            int codeH = 36;
            int fontSize = 21;

            Color[] color = {Color.Black,Color.Blue,Color.Green};
            string[] fonts = new[] { "Times New Roman", "Verdana", "Arial", "Gungsuh", "Impact" };

            code = GenerateRandom(length);

            using (Bitmap bitmap =new Bitmap(codeW, codeH))
            using (Graphics graphics = Graphics.FromImage(bitmap))
            using (MemoryStream ms = new MemoryStream()) {
                graphics.Clear(Color.White);
                Random random = new Random();
                //画噪线
                for (int i = 0; i < 1; i++) {
                    int x1 = random.Next(codeW);
                    int y1 = random.Next(codeH);
                    int x2 = random.Next(codeW);
                    int y2 = random.Next(codeH);
                    Color clr = color[random.Next(color.Length)];
                    graphics.DrawLine(new Pen(clr),x1,y2,x2,y2);
                }

                //画验证码
                {
                    string fnt;
                    Font ft;
                    Color clr;
                    for (int i = 0; i < code.Length; i++) {
                        fnt = fonts[random.Next(fonts.Length)];
                        ft = new Font(fnt,fontSize);
                        clr = color[random.Next(color.Length)];
                        graphics.DrawString(code[i].ToString(),ft,new SolidBrush(clr),(float)i*24+2,(float)0);
                    }
                }

                bitmap.Save(ms,ImageFormat.Png);
                return ms.ToArray();
            }
        }

        private byte[] GenCode(out string code,int length=4) {
            int codeW = 110;
            int codeH = 36;
            int fontSize = 20;

            SKColor[] color = { SKColors.Black, SKColors.Blue, SKColors.Green };
            string[] fonts = new[] { "Times New Roman", "Verdana", "Arial", "Gungsuh", "Impact" };

            code = GenerateRandom(length);

            SKBitmap bitmap = new SKBitmap(codeW,codeH);
            using (SKCanvas canvas = new SKCanvas(bitmap)) {
                
                canvas.DrawColor (SKColors.White);

                #region 画噪线
                Random random = new Random();
                SKPaint sKPaint = new SKPaint() {Color=color[random.Next(color.Length)] };
                int x1=random.Next(codeW);
                int y1 = random.Next(codeH);
                int x2 = random.Next(codeW);
                int y2 = random.Next(codeH);
                canvas.DrawLine(x1,y1,x2,y2,sKPaint);
                #endregion

                #region 验证码
                SKRect size = new SKRect();
                float temp = (bitmap.Width / 4 - size.Size.Width) / 2;
                float temp1 = bitmap.Height - (bitmap.Height - size.Size.Height) / 2;
                sKPaint = new SKPaint() {
                    TextSize = 20,
                    IsAntialias = true,
                    Typeface = SKTypeface.FromFamilyName(fonts[random.Next(fonts.Length)]),
                    Color = new SKColor((byte)random.Next(0, 255), (byte)random.Next(0, 255), (byte)random.Next(0, 255))
                };
                for (int i = 0; i < code.Length; i++) {
                    canvas.DrawText(code[i].ToString(), temp+20*i,temp1, sKPaint);
                }
                #endregion

                SKImage img = SKImage.FromBitmap(bitmap);
                SKData sd = img.Encode();
                var ms = sd.AsStream();
                byte[] bytes = new byte[ms.Length];
                ms.Read(bytes,0,bytes.Length);
                ms.Seek(0,SeekOrigin.Begin);
                return bytes;
            }
        }

        public string GetBase64String(out string code, int length=4) {
            return Convert.ToBase64String(GenCode(out code,length));
        }
    }
}

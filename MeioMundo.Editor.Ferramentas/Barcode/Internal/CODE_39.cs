using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Drawing;
using System.IO;
using System.Windows.Media.Imaging;

namespace MeioMundo.Editor.Ferramentas.Barcode.Internal
{
    public class CODE_39
    {
        public static System.Windows.Media.FontFamily Font { get => new System.Windows.Media.FontFamily(new Uri("pack://application:,,,/Tools;Component/"), "./Barcode/Fonts/#Code 39"); }



        public static BitmapImage Draw(Internal.Code code, Internal.Size size)
        {


            Bitmap bitmap = new Bitmap(13*3*code.Content.Length+3, size.Height);
            Graphics g = Graphics.FromImage(bitmap);
            g.FillRectangle(System.Drawing.Brushes.White, 0, 0, bitmap.Width, bitmap.Height);

            //code.Content = "*01*";

            for (int i = 0; i < code.Content.Length; i++)
            {
                g.DrawImage(CharToImage(Chars.ToChar(code.Content[i]), size.Height, 3), i * 13 * 3, 0);
            }
            //g.DrawImage(CharToImage(Chars._asterisk, size.Height, 3), 0, 0);
            //g.DrawImage(CharToImage(Chars._0, size.Height, 3), 13* 3, 0);
            //g.DrawImage(CharToImage(Chars._asterisk, size.Height, 3), 13 * 6, 0);



            MemoryStream ms = new MemoryStream();
            ((System.Drawing.Bitmap)bitmap).Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);

            BitmapImage image = new BitmapImage();
            
            image.BeginInit();
            ms.Seek(0, SeekOrigin.Begin);
            image.StreamSource = ms;
            image.EndInit();

            return image;       
             
        }
        public static Image CharToImage(byte[] c, int height, int X_Scale)
        {
            if (X_Scale == 0)
                X_Scale = 1;
            Bitmap bitmap = new Bitmap((c.Length * X_Scale), height);


            Graphics g = Graphics.FromImage(bitmap);
            g.FillRectangle(System.Drawing.Brushes.White, 0, 0, bitmap.Width, height);
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 1)
                    g.FillRectangle(System.Drawing.Brushes.Black, (i * X_Scale), 0, 1 * X_Scale, height);
            }


            return bitmap;
        }

        public struct Chars
        {
            /// <value>*</value>
            public static byte[] _asterisk => new byte[] { 0, 1, 0, 0, 1, 0, 1, 1, 0, 1, 1, 0, 1 };
            public static byte[] _0 => new byte[] { 0, 1, 0, 1, 0, 0, 1, 1, 0, 1, 1, 0, 1 };
            public static byte[] _1 => new byte[] { 0, 1, 1, 0, 1, 0, 0, 1, 0, 1, 0, 1, 1 };
            public static byte[] _2 => new byte[] { 0, 1, 0, 1, 1, 0, 0, 1, 0, 1, 0, 1, 1 };
            public static byte[] _3 => new byte[] { 0, 1, 1, 0, 1, 1, 0, 0, 1, 0, 1, 0, 1 };
            public static byte[] _4 => new byte[] { 0, 1, 0, 1, 0, 0, 1, 1, 0, 1, 0, 1, 1 };
            public static byte[] _5 => new byte[] { 0, 1, 1, 0, 1, 0, 0, 1, 1, 0, 1, 0, 1 };
            public static byte[] _6 => new byte[] { 0, 1, 0, 1, 1, 0, 0, 1, 1, 0, 1, 0, 1 };
            public static byte[] _7 => new byte[] { 0, 1, 0, 1, 0, 0, 1, 0, 1, 1, 0, 1, 1 };
            public static byte[] _8 => new byte[] { 0, 1, 1, 0, 1, 0, 0, 1, 0, 1, 1, 0, 1 };
            public static byte[] _9 => new byte[] { 0, 1, 0, 1, 1, 0, 0, 1, 0, 1, 1, 0, 1 };
            public static byte[] _A => new byte[] { 0, 1, 1, 0, 1, 0, 1, 0, 0, 1, 0, 1, 1 };
            public static byte[] _B => new byte[] { 0, 1, 0, 1, 1, 0, 1, 0, 0, 1, 0, 1, 1 };
            public static byte[] _C => new byte[] { 0, 1, 1, 0, 1, 1, 0, 1, 0, 0, 1, 0, 1 };
            public static byte[] _D => new byte[] { 0, 1, 0, 1, 0, 1, 1, 0, 0, 1, 0, 1, 1 };
            public static byte[] _E => new byte[] { 0, 1, 1, 0, 1, 0, 1, 1, 0, 0, 1, 0, 1 };
            public static byte[] _F => new byte[] { 0, 1, 0, 1, 1, 0, 1, 1, 0, 0, 1, 0, 1 };
            public static byte[] _G => new byte[] { 0, 1, 0, 1, 0, 1, 0, 0, 1, 1, 0, 1, 1 };
            public static byte[] _H => new byte[] { 0, 1, 1, 0, 1, 0, 1, 0, 0, 1, 1, 0, 1 };
            public static byte[] _I => new byte[] { 0, 1, 0, 1, 1, 0, 1, 0, 0, 1, 1, 0, 1 };
            public static byte[] _J => new byte[] { 0, 1, 0, 1, 0, 1, 1, 0, 0, 1, 1, 0, 1 };
            public static byte[] _K => new byte[] { 0, 1, 1, 0, 1, 0, 1, 0, 1, 0, 0, 1, 1 };
            public static byte[] _L => new byte[] { 0, 1, 0, 1, 1, 0, 1, 0, 1, 0, 0, 1, 1 };
            public static byte[] _M => new byte[] { 0, 1, 1, 0, 1, 1, 0, 1, 0, 1, 0, 0, 1 };
            public static byte[] _N => new byte[] { 0, 1, 0, 1, 0, 1, 1, 0, 1, 0, 0, 1, 1 };
            public static byte[] _O => new byte[] { 0, 1, 1, 0, 1, 0, 1, 1, 0, 1, 0, 0, 1 };
            public static byte[] _P => new byte[] { 0, 1, 0, 1, 1, 0, 1, 1, 0, 1, 0, 0, 1 };
            public static byte[] _Q => new byte[] { 0, 1, 0, 1, 0, 1, 0, 1, 1, 0, 0, 1, 1 };
            public static byte[] _R => new byte[] { 0, 1, 1, 0, 1, 0, 1, 0, 1, 1, 0, 0, 1 };
            public static byte[] _S => new byte[] { 0, 1, 0, 1, 1, 0, 1, 0, 1, 1, 0, 0, 1 };
            public static byte[] _T => new byte[] { 0, 1, 0, 1, 0, 1, 1, 0, 1, 1, 0, 0, 1 };
            public static byte[] _U => new byte[] { 0, 1, 1, 0, 0, 1, 0, 1, 0, 1, 0, 1, 1 };
            public static byte[] _V => new byte[] { 0, 1, 0, 0, 1, 1, 0, 1, 0, 1, 0, 1, 1 };
            public static byte[] _W => new byte[] { 0, 1, 1, 0, 0, 1, 1, 0, 1, 0, 1, 0, 1 };
            public static byte[] _X => new byte[] { 0, 1, 0, 0, 1, 0, 1, 1, 0, 1, 0, 1, 1 };
            public static byte[] _Y => new byte[] { 0, 1, 1, 0, 0, 1, 0, 1, 1, 0, 1, 0, 1 };
            public static byte[] _Z => new byte[] { 0, 1, 0, 0, 1, 1, 0, 1, 1, 0, 1, 0, 1 };
            


            public static byte[] ToChar(char c)
            {
                c = c.ToString().ToUpper().ToCharArray()[0];
                byte[] data = new byte[] { };
                switch (c)
                {
                    case '*':
                        return _asterisk;
                    case '0':
                        return _0;
                    case '1':
                        return _1;
                    case '2':
                        return _2;
                    case '3':
                        return _3;
                    case '4':
                        return _4;
                    case '5':
                        return _5;
                    case '6':
                        return _6;
                    case '7':
                        return _7;
                    case '8':
                        return _8;
                    case '9':
                        return _9;
                    case 'A':
                        return _A;
                    case 'B':
                        return _B;
                    case 'C':
                        return _C;
                    case 'D':
                        return _D;
                    case 'E':
                        return _E;
                    case 'F':
                        return _F;
                    case 'G':
                        return _G;
                    case 'H':
                        return _H;
                    case 'I': 
                        return _I;
                    case 'J':
                        return _J;
                    case 'K':
                        return _K;
                    case 'L':
                        return _L;
                    case 'M':
                        return _M;
                    case 'N':
                        return _N;
                    case 'O':
                        return _O;
                    case 'P':
                        return _P;
                    case 'Q':
                        return _Q;
                    case 'R':
                        return _R;
                    case 'S':
                        return _S;
                    case 'T':
                        return _T;
                    case 'U':
                        return _U;
                    case 'V':
                        return _V;
                    case 'W':
                        return _W;
                    case 'X':
                        return _X;
                    case 'Y':
                        return _Y;
                    case 'Z':
                        return _Z;
                    default:
                        return new byte[] { };
                }
            }
        }
    }
}

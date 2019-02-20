using System;
using System.Drawing;

namespace TTI
{
    class Program
    {
        static void Main(string[] args)
        {
			GetInput();
        }
		
		static void GetInput() {
			Console.WriteLine("ttb + ENTER = text till bild");
			Console.WriteLine("bg + ENTER = bild genomskinlig");
			Console.WriteLine("ttgb + ENTER = text till genomskinlig bild");
			Console.WriteLine("h + ENTER = hjälp");
			Console.WriteLine("e + ENTER = avsluta");
			while(true) {
				Console.WriteLine("Vad vill du göra?");
				var operation = Console.ReadLine();
				if(operation = "h") {
					Console.WriteLine("text till bild + ENTER = gör en .txt fil till en bild fil (.png)");
					Console.WriteLine("bild genomskinlig + ENTER = gör vit bakgrund hos en .png fil genomskinlig");
					Console.WriteLine("text till genomskinlig bild + ENTER = gör de båda övre funktionerna på samma gång");
				} else if(operation = "text till bild" || operation = "ttb") {
					Console.WriteLine("var finns textdokumentet (.txt)? (plats på hårdskivan)");
					var filePath = Console.ReadLine();
					TextToImage(filePath);
					Console.WriteLine("texten konverterad till bild!");
				} else if(operation = "bild genomskinlig" || operation = "bg") {
					
				} else if(operation = "text till genomskinlig bild" || operation = "ttgb") {
					
				} else if(operation = "e") {
					break;
				} else{
					Console.WriteLine("detta gick inte att tolka, försök igen eller få hjälp med 'h + ENTER'");
				}
			}
		}
		
		static void TextToImage(string path) {
			string text = System.IO.File.ReadAllText(path);
			Image img = DrawText(text,"Arial","BLACK","WHITE");
			path = path.Replace("txt","png");
			img.Save(path, System.Drawing.Imaging.ImageFormat.Png);
		}
		
		static void Transparentify(string path) {
			Bitmap bm = new Bitmap (path);
			e.Graphics.DrawImage(bm, 0, 0, bm.Width, bm.Height);
			Color backColor = myBitmap.GetPixel(1, 1);
			bm.MakeTransparent(backColor);
			e.Graphics.DrawImage(bm, bm.Width, 0, bm.Width, bm.Height);
			bm.Save(path);
		}
		
		//credit Kazar (https://stackoverflow.com/questions/2070365/how-to-generate-an-image-from-text-on-fly-at-runtime)
		private Image DrawText(String text, Font font, Color textColor, Color backColor) {
			Image img = new Bitmap(1, 1);
			Graphics drawing = Graphics.FromImage(img);
			SizeF textSize = drawing.MeasureString(text, font);
			img.Dispose();
			drawing.Dispose();
			img = new Bitmap((int) textSize.Width, (int)textSize.Height);
			drawing = Graphics.FromImage(img);
			drawing.Clear(backColor);
			Brush textBrush = new SolidBrush(textColor);
			drawing.DrawString(text, font, textBrush, 0, 0);
			drawing.Save();
			textBrush.Dispose();
			drawing.Dispose();
			return img;
		}
    }
}

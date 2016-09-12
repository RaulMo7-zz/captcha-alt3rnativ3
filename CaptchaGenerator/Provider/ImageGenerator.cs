using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using Provider.Model;

namespace Provider
{
    public class ImageGenerator
    {
        public Captcha Generate()
        {
            int width = 200;
            int height = 120;

            int y;
            var x = y = 10;
            var w = 150;
            var h = 80;

            using (Bitmap bmp = new Bitmap(width, height))
            {

                using (Graphics g = Graphics.FromImage(bmp))
                {

                    Rectangle rect1 = new Rectangle(x, y, w, h);
                    // Draw the text and the surrounding rectangle.
                    g.FillRectangle(
                        brush: new SolidBrush(
                            color: Color.Azure
                        ),
                        rect: rect1
                    );

                    return GenerateSumAnswer(g, rect1, bmp);

                }
            }
        }

        private Captcha GenerateSumAnswer(Graphics g, Rectangle rect1, Bitmap bmp)
        {

            StringFormat stringFormat = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            Random rndOperations = new Random();
            int rndNumber1 = rndOperations.Next(1, 20);
            int rndNumber2 = rndOperations.Next(1, 20);
            int answer = rndNumber1 + rndNumber2;
            int[] possibleAnswers = { answer, rndOperations.Next(20, 40), rndOperations.Next(20, 40) };

            string textAnswer = $"{rndNumber1} + {rndNumber2}";
            using (Font font1 = new Font(FontFamily.GenericSansSerif, 20, FontStyle.Italic))
            {
                g.DrawString(textAnswer, font1, Brushes.Brown, rect1, stringFormat);
            }

            g.DrawRectangle(Pens.Black, rect1);

            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            bmp.Save(stream, ImageFormat.Png);
            byte[] imageBytes = stream.ToArray();

            int[] unorderedAnswers = possibleAnswers.OrderBy(x => rndOperations.Next()).ToArray();
            string base64String = Convert.ToBase64String(imageBytes);

            return new Captcha { Answers = unorderedAnswers, Base64 = base64String, Id = Guid.NewGuid(), QuestionType= QuestionType.Sum };
        }
    }
}

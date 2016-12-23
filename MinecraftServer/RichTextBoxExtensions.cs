using System.Drawing;
using System.Windows.Forms;

namespace MinecraftServer
{
    public static class RichTextBoxExtensions
    {
        public static RichTextBox SetColor(this RichTextBox box, Color color)
        {
            box.SelectionColor = color;
            return box;
        }

        public static RichTextBox SetBackColor(this RichTextBox box, Color backColor)
        {
            box.SelectionBackColor = backColor;
            return box;
        }

        public static RichTextBox SetFont(this RichTextBox box, Font font)
        {
            box.SelectionFont = font;
            return box;
        }

        public static RichTextBox AppendText(this RichTextBox box, string text, Color color)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;

            box.SelectionColor = color;
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;

            return box;
        }

        public static RichTextBox AppendText(this RichTextBox box, string text, Color color, Color backColor)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;

            box.SelectionColor = color;
            box.SelectionBackColor = backColor;
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;

            return box;
        }

        public static RichTextBox AppendText(this RichTextBox box, string text, Font font)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;

            box.SelectionFont = font;
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;

            return box;
        }

        public static RichTextBox AppendText(this RichTextBox box, string text, Color color, Font font)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;

            box.SelectionFont = font;
            box.SelectionColor = color;
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;

            return box;
        }

        public static RichTextBox AppendText(this RichTextBox box, string text, Color color, Color backColor, Font font)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;

            box.SelectionFont = font;
            box.SelectionColor = color;
            box.SelectionBackColor = backColor;
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;

            return box;
        }
    }
}

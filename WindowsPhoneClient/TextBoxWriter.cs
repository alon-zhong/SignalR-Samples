using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Controls;

namespace WindowsPhoneClient
{
    class TextBoxWriter : TextWriter
    {
        SynchronizationContext _context;
        TextBox _textBox;

        public TextBoxWriter(SynchronizationContext context, TextBox textBox)
        {
            _context = context;
            _textBox = textBox;
        }

        public override void WriteLine(string value)
        {
            _context.Post(delegate
            {
                _textBox.Text = _textBox.Text + value + Environment.NewLine;
            }, null);
        }

        public override void WriteLine(string format, params object[] args)
        {
            _context.Post(delegate
            {
                _textBox.Text = _textBox.Text + string.Format(format, args) + Environment.NewLine;
            }, null);
        }

        public override Encoding Encoding
        {
            get { throw new NotImplementedException(); }
        }

        public override void Write(char value)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using ICSharpCode.AvalonEdit.CodeCompletion;
using ICSharpCode.AvalonEdit.Document;
using ICSharpCode.AvalonEdit.Editing;

namespace MyDataBase.Models.TextProcessing
{
    class MyCompletionData:ICompletionData
    {
        public MyCompletionData(string text)
        {
            this.Text = text;
        }
        public void Complete(TextArea textArea, ISegment completionSegment, EventArgs insertionRequestEventArgs)
        {
            textArea.Document.Replace(completionSegment, this.Text);
        }

        public ImageSource Image
        {
            get { return null; }
        }

        public string Text { get; private set; }

        public object Content
        {
            get { return this.Text; }
        }

        public object Description {
            get { return "Description for " + this.Text; }}
        public double Priority { get; private set; }
    }
}

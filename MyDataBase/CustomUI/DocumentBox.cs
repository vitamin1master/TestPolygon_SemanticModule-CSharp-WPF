using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;

namespace MyDataBase.CustomUI
{
    public class DocumentBox:RichTextBox
    {
        protected override void OnTextChanged(TextChangedEventArgs e)
        {
            if (e.Changes.Count > 0)
                ChangeIndicator = true;
            base.OnTextChanged(e);
            //Document = base.Document;
        }

        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            if (e.Property == DocumentProperty)
                base.Document = (FlowDocument)FlagDocument;
            base.OnPropertyChanged(e);
        }

        public bool ChangeIndicator;

        public bool ResetChangeIndicator()
        {
            var sup = ChangeIndicator;
            ChangeIndicator = false;
            return sup;
        }

        public static readonly DependencyProperty DocumentProperty = DependencyProperty.Register("FlagDocument",
            typeof(FlagFlowDocument), typeof(DocumentBox));

        public FlagFlowDocument FlagDocument
        {
            get
            {
                if ((FlagFlowDocument)GetValue(DocumentProperty) == null)
                    return new FlagFlowDocument();
                return (FlagFlowDocument)GetValue(DocumentProperty);
            }
            set { SetValue(DocumentProperty, value); }
        }
    }
}
using System.Windows.Documents;

namespace MyDataBase.CustomUI
{
    public class FlagFlowDocument:FlowDocument
    {
        //Change document flag program logic and not the user's activities
        public bool Flag;
        public FlagFlowDocument():base()
        {
            Flag = false;
        }
    }
}

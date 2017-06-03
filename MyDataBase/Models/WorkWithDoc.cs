using System;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using MyDataBase.CustomUI;
using Block = MyDataBase.Models.SemanticModule.Block;

namespace MyDataBase.Models
{
    public class WorkWithDoc
    {
        //public static void SplittingParagraphs(string text, ServiceWords serviceWords, FlagFlowDocument document)
        //{
        //    document.Blocks.Clear();
        //    string[] lines = text.Split(new string[] { "\r\n" }, StringSplitOptions.None);
        //    Paragraph par = new Paragraph();
        //    Run run;
        //    foreach (string line in lines)
        //    {

        //        string[] words = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        //        foreach (string word in words)
        //        {
        //            run = new Run(word + " ");
        //            if (serviceWords.Exists(word))
        //                run.Foreground = Brushes.Blue;
        //            par.Inlines.Add(run);
        //        }
        //        document.Blocks.Add(par);
        //    }
        //}

        //public static void change1(FlagFlowDocument document, ServiceWords serviceWords)
        //{
        //    Run run;
        //    Block block = document.Blocks.FirstBlock;
        //    while (block != null)
        //    {
        //        TextRange range = new TextRange(block.ContentStart, block.ContentEnd);
        //        string line = range.Text;
        //        string[] words = line.Split(new char[] { ' ' }, StringSplitOptions.None);
        //        (block as Paragraph).Inlines.Clear();
        //        foreach (string word in words)
        //        {
        //            if (serviceWords.Exists(word))
        //            {
        //                int index = line.IndexOf(word, StringComparison.Ordinal);
        //                if (index != 0)
        //                {
        //                    int sizeWord = word.Length;
        //                    string cutLine = line.Substring(0, index);
        //                    line = line.Substring(index);
        //                    run = new Run(cutLine);
        //                    (block as Paragraph).Inlines.Add(run);
        //                    cutLine = line.Substring(0, sizeWord);
        //                    line = line.Substring(sizeWord);
        //                    run = new Run(cutLine);
        //                    run.Foreground = Brushes.Blue;
        //                    (block as Paragraph).Inlines.Add(run);
        //                }

        //            }
        //        }
        //        if (line != "")
        //        {
        //            run = new Run(line);
        //            (block as Paragraph).Inlines.Add(run);
        //        }
        //        block = block.NextBlock;
        //    }
        //}
        //public static void OnTextChanged(FlagFlowDocument thisDocument, ServiceWords serviceWords)
        //{
        //    if (thisDocument.Blocks.FirstBlock != null)
        //    {
        //        TextRange range = new TextRange(thisDocument.ContentStart, thisDocument.ContentEnd);
        //        string text = range.Text;
        //        //SplittingParagraphs(text,serviceWords,thisDocument);
        //        change1(thisDocument, serviceWords);
        //    }
        //}

        //public static void StartPackage(FlagFlowDocument document, InfoUser thisUser)
        //{
        //    if (File.Exists("c:\\WPFUsers\\" + thisUser.Login + ".rtf"))
        //    {
        //        FileStream fs = new FileStream("c:\\WPFUsers\\" + thisUser.Login + ".rtf", FileMode.Open, FileAccess.Read);
        //        TextRange range = new TextRange(document.ContentStart, document.ContentEnd);
        //        document.Flag = true;
        //        range.Load(fs, DataFormats.Rtf);
        //        document.Flag = false;
        //    }
        //    else
        //    {
        //        document.Flag = true;
        //        document.FontFamily = new FontFamilyConverter().ConvertFromString("Times New Roman") as FontFamily;
        //        Paragraph par = new Paragraph(new Run("Welcom, dear " + thisUser.Login + " "));
        //        par.FontSize = 18;
        //        document.Blocks.Add(par);
        //        par = new Paragraph(new Run("I am new RichTextBox"));
        //        par.FontSize = 14;
        //        document.Blocks.Add(par);
        //        document.LineHeight = 6;

        //        using (FileStream fs = new FileStream("c:\\WPFUsers\\" + thisUser.Login + ".rtf", FileMode.OpenOrCreate, FileAccess.Write))
        //        {
        //            TextRange range = new TextRange(document.ContentStart, document.ContentEnd);
        //            range.Save(fs, DataFormats.Rtf);
        //        }
        //        document.Flag = false;
        //    }
        //}
    }
}

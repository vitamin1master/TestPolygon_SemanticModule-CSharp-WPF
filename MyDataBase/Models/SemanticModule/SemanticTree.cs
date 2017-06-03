using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Input;
using MyDataBase.Commands.TreeTraversalCommands;
using MyDataBase.Models.SemanticModule.Errors;
using MyDataBase.Models.SemanticModule.LogicalBlocks;
using MyDataBase.Models.TextProcessing;

namespace MyDataBase.Models.SemanticModule
{
    public class SemanticTree
    {
        private TreeSlider _splitingSlider;
        private Block Head;
        private static int getPriority(char simbol)
        {
            switch (simbol)
            {
                case '{':
                    return 0;
                case '}':
                    return 1;
                case ';':
                    return 2;
                default:
                    return 3;
            }
        }

        private Block performConstruction(string text, List<int> characterIndexes, Block Head)
        {
            _splitingSlider = new TreeSlider(Head);
            SplitBlocksThisLevel(_splitingSlider, text, characterIndexes);
            if (Head.Equals(_splitingSlider.GetHeadThisLevel()) == false)
                Head = _splitingSlider.GetHeadThisLevel();
            if (Head.Text == null)
                throw new TreeIsEmptyException("Tree is empty");
            return Head;
        }

        private void leftRound(Block slider, ICommand command)
        {
            if (slider.LevelBelow!=null)
                leftRound(slider.LevelBelow, command);
            if (command.CanExecute(slider))
                command.Execute(slider);
            if (slider.Next!=null)
                leftRound(slider.Next, command);

        }
        public static void SplitBlocksThisLevel(TreeSlider _splitingSlider, string text, List<int> characterIndexes, int startIndexBlock=0)
        {
            Stack<char> charStack = new Stack<char>();
            int iStart = 0;
            int iSlider = 0;
            int slider = 0;
            while (slider<characterIndexes.Count)
            {
                if ((startIndexBlock < characterIndexes[slider]) &&
                    (startIndexBlock + text.Length > characterIndexes[slider]))
                {
                    if (getPriority(text[characterIndexes[slider] - startIndexBlock]) == 3)
                        throw new FalseMeaningAtCharacterIndexes(
                            "In the stack there is an index different from the separating symbols");
                    iSlider = characterIndexes[slider] - startIndexBlock;
                    int simbolPriority = getPriority(text[iSlider]);
                    if (charStack.Count > 0)
                    {

                        if (simbolPriority == 0 || simbolPriority == 2)
                        {
                            charStack.Push(text[iSlider]);
                        }
                        if (simbolPriority == 1)
                        { 
                            char stackSimbol = charStack.Pop();
                            while (getPriority(stackSimbol) != 0)
                                stackSimbol = charStack.Pop();
                            if (charStack.Count == 0 && getPriority(stackSimbol) >= simbolPriority)
                                throw new MySyntaxErrorException("There is no opening parenthesis in the stack");
                            if (charStack.Count == 0 && getPriority(stackSimbol) < simbolPriority)
                            {
                                string textInBlock = text.Substring(iStart, iSlider - iStart);
                                _splitingSlider.AddToLevelBelow(textInBlock, characterIndexes, iStart + startIndexBlock);
                                iStart = iSlider + 1;
                                iSlider = iStart;
                            }
                        }
                    }
                    else
                    {
                        if (simbolPriority == 1)
                            throw new MySyntaxErrorException("A closing parenthesis is thrown into the empty stack");
                        else
                        {
                            string textInBlock = text.Substring(iStart, iSlider - iStart);
                            bool blockEndsWithSemicolon=false;
                            if (simbolPriority == 2)
                                blockEndsWithSemicolon = true;
                            _splitingSlider.AddToThisLevel(textInBlock, iStart + startIndexBlock, blockEndsWithSemicolon);
                            _splitingSlider=_splitingSlider.NextThisLevel();
                            iStart = iSlider + 1;
                            if (simbolPriority == 0)
                                charStack.Push(text[iSlider]);
                        }
                    }
                }
                slider++;
            }
            if (slider >= characterIndexes.Count && charStack.Count > 0)
                throw new MySyntaxErrorException("There is no closing bracket in the stack");
        }

        public SemanticTree(string text, List<int> characterIndexes)
        {
            Head=new Block();
            try
            {
                Head=performConstruction(text, characterIndexes, Head);
            }
            catch (TreeIsEmptyException)
            {
            }
            catch (MissingTitleException)
            {

            }
            catch (MySyntaxErrorException)
            {

            }
            catch (FalseMeaningAtCharacterIndexes)
            {

            }

        }
        public TreeSlider GetSlider()
        {
            return new TreeSlider(Head);
        }

        public void UpdateVariableList(UserVariables userVariables)
        {
            UpdateVariableListCommand command=new UpdateVariableListCommand(userVariables);
            leftRound(Head,command);
            userVariables.RemoveAllUnusedVaribles();
            userVariables.SetVariablePresenceIndicatorToFalse();
        }

        public void DrawTree(Canvas panel)
        {
            SemanticTreeDrawCommand command = new SemanticTreeDrawCommand(panel);
            leftRound(Head, command);
        }

        public int GetLevelAtWhichCaretOffset(int caretOffset)
        {
            AtWhatBlockCaretOffsetCommand command = new AtWhatBlockCaretOffsetCommand(caretOffset);
            leftRound(Head, command);
            if (command.Result != null)
                return command.Result.LevelNumber;
            return 0;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDataBase.Models.TextProcessing
{
    public class UserVariables
    {
        protected List<VariableInfo> _variablesList;

        public int Count
        {
            get { return _variablesList.Count; }
            private set { Count = _variablesList.Count; }
        }

        public UserVariables()
        {
            _variablesList = new List<VariableInfo>();
        }

        public void AddVariable(string name, string type, int levelNumber, bool variablePresenceIndicator)
        {
            _variablesList.Add(new VariableInfo(name, type, levelNumber, variablePresenceIndicator));
        }

        public void ClearAll()
        {
            _variablesList.Clear();
        }

        public int Exists(string name, string type, int levelNumber)
        {
            int i = 0;
            int iMax = _variablesList.Count;
            while (i < iMax)
            {
                if (_variablesList[i].Name == name && _variablesList[i].Type == type &&
                    _variablesList[i].LevelNumber == levelNumber)
                    return i;
                i++;
            }
            return -1;
        }
        public bool Exists(string name, string type)
        {
            int i = 0;
            int iMax = _variablesList.Count;
            while (i < iMax)
            {
                if (_variablesList[i].Name == name && _variablesList[i].Type == type)
                    return true;
                i++;
            }
            return false;
        }
        public bool Exists(string name)
        {
            int i = 0;
            int iMax = _variablesList.Count;
            while (i < iMax)
            {
                if (_variablesList[i].Name == name)
                    return true;
                i++;
            }
            return false;
        }
         public VariableInfo this[int number]
        {
             get { return _variablesList[number]; }
            set { _variablesList[number] = value; }
        }

        public void Remove(string name, string type, int levelNumber)
        {
            int i = 0;
            int iMax = _variablesList.Count;
            while (i < iMax)
            {
                if (_variablesList[i].Name == name && _variablesList[i].Type == type &&
                    _variablesList[i].LevelNumber == levelNumber)
                {
                    VariableInfo info = _variablesList[i];
                    _variablesList.Remove(info);
                    break;
                }
                i++;
            }
        }
        public void Remove(string name, string type)
        {
            int i = 0;
            int iMax = _variablesList.Count;
            while (i < iMax)
            {
                if (_variablesList[i].Name == name && _variablesList[i].Type == type)
                {
                    VariableInfo info = _variablesList[i];
                    _variablesList.Remove(info);
                    break;
                }
                i++;
            }
        }

        public void Remove(VariableInfo varInfo)
        {
            if (_variablesList.Contains(varInfo))
                _variablesList.Remove(varInfo);
        }

        public void RemoveAllUnusedVaribles()
        {
            int i = 0;
            while (i<_variablesList.Count)
            {
                if (_variablesList[i].VariablePresenceIndicator == false)
                    Remove(_variablesList[i]);
                i++;
            }

        }

        public void SetVariablePresenceIndicatorToFalse()
        {
            int i = 0;
            while (i < _variablesList.Count)
            {
                _variablesList[i].VariablePresenceIndicator = false;
                i++;
            }
        }
    }
}

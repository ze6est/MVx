using UnityEngine.Events;

namespace MVVM.Model
{
    public class MvvmModel
    {
        private int _intValue;
        private string _stringValue;

        public event UnityAction<int> IntValueChanged;
        public event UnityAction<string> StringValueChanged;

        public void ChangeIntValue(int value)
        {
            _intValue = value;
            IntValueChanged?.Invoke(_intValue);
        }

        public void ChangeStringValue(string value)
        {
            _stringValue = value;
            StringValueChanged?.Invoke(_stringValue);
        }
    }
}
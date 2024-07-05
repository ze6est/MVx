using UnityEngine.Events;

namespace MVP.Model
{
    public class MvpModel
    {
        private int _intValue;
        private string _stringValue;

        public event UnityAction<int> IntValueChanged;

        public void IncrementIntValue()
        {
            _intValue++;
            IntValueChanged?.Invoke(_intValue);
        }
        
        public void DecrementIntValue()
        {
            _intValue--;
            IntValueChanged?.Invoke(_intValue);
        }

        public void SetStringValue(string value) => 
            _stringValue = value;
    }
}
using System;
using MVVM.Model;
using UnityEngine.Events;

namespace MVVM.ViewModel
{
    public class MvvmViewModel : IDisposable
    {
        private int _intValue;
        private string _stringValue;

        private MvvmModel _mvvmModel;

        public event UnityAction<int> IntValueChanged;
        public event UnityAction<string> StringValueChanged;

        public MvvmViewModel(MvvmModel mvvmModel)
        {
            _mvvmModel = mvvmModel;

            _mvvmModel.IntValueChanged += OnIntValueChanged;
            _mvvmModel.StringValueChanged += OnStringValueChanged;
        }
        
        public void IncrementIntValue()
        {
            _intValue++;
            _mvvmModel.ChangeIntValue(_intValue);
            IntValueChanged?.Invoke(_intValue);
        }
        
        public void DecrementIntValue()
        {
            _intValue--;
            _mvvmModel.ChangeIntValue(_intValue);
            IntValueChanged?.Invoke(_intValue);
        }
        
        public void SetStringValue(string value)
        {
            _stringValue = value;
            _mvvmModel.ChangeStringValue(_stringValue);
            StringValueChanged?.Invoke(_stringValue);
        }
        
        public void Dispose()
        {
            _mvvmModel.IntValueChanged -= OnIntValueChanged;
            _mvvmModel.StringValueChanged -= OnStringValueChanged;
        }

        private void OnIntValueChanged(int value)
        {
            _intValue = value;
            IntValueChanged?.Invoke(_intValue);
        }

        private void OnStringValueChanged(string value)
        {
            _stringValue = value;
            StringValueChanged?.Invoke(_stringValue);
        }
    }
}

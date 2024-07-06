using MVVM.ViewModel;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MVVM.View
{
    public class MvvmView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _intValue;
        [SerializeField] private TextMeshProUGUI _stringValue;

        [SerializeField] private Button _incrementButton;
        [SerializeField] private Button _decrementButton;

        [SerializeField] private TMP_InputField _inputField;

        private MvvmViewModel _mvvmViewModel;

        public void Construct(MvvmViewModel mvvmViewModel)
        {
            _mvvmViewModel = mvvmViewModel;
            
            _mvvmViewModel.IntValueChanged += OnIntValueChanged;
            _mvvmViewModel.StringValueChanged += OnStringValueChanged;
        }
        
        private void Awake()
        {
            _incrementButton.onClick.AddListener(OnIncrementButtonClick);
            _decrementButton.onClick.AddListener(OnDecrementButtonClick);
            _inputField.onValueChanged.AddListener(OnInputFieldValueChanged);
        }

        private void OnDestroy()
        {
            _incrementButton.onClick.RemoveListener(OnIncrementButtonClick);
            _decrementButton.onClick.RemoveListener(OnDecrementButtonClick);
            _inputField.onValueChanged.RemoveListener(OnInputFieldValueChanged);
            
            _mvvmViewModel.IntValueChanged -= OnIntValueChanged;
            _mvvmViewModel.StringValueChanged -= OnStringValueChanged;
        }

        private void OnIncrementButtonClick() => 
            _mvvmViewModel.IncrementIntValue();

        private void OnDecrementButtonClick() => 
            _mvvmViewModel.DecrementIntValue();

        private void OnInputFieldValueChanged(string value) => 
            _mvvmViewModel.SetStringValue(value);
        
        private void OnIntValueChanged(int value) => 
            _intValue.text = value.ToString();

        private void OnStringValueChanged(string value) => 
            _stringValue.text = value;
    }
}
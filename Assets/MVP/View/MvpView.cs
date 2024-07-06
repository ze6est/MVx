using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace MVP.View
{
    public class MvpView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _intValue;
        [SerializeField] private TextMeshProUGUI _stringValue;

        [SerializeField] private Button _incrementButton;
        [SerializeField] private Button _decrementButton;

        [SerializeField] private TMP_InputField _inputField;

        public event UnityAction IncrementButtonClick;
        public event UnityAction DecrementButtonClick;
        public event UnityAction<string> InputFieldValueChanged;

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
        }

        public void UpdateIntValue(int value) => 
            _intValue.text = value.ToString();

        public void UpdateStringValue(string value) => 
            _stringValue.text = value;

        private void OnIncrementButtonClick() => 
            IncrementButtonClick?.Invoke();

        private void OnDecrementButtonClick() => 
            DecrementButtonClick?.Invoke();

        private void OnInputFieldValueChanged(string value) => 
            InputFieldValueChanged?.Invoke(value);
    }
}
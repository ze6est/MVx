using MVC.Model;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace MVC.View
{
    public class MvcView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _intValue;
        [SerializeField] private TextMeshProUGUI _stringValue;

        [SerializeField] private Button _incrementButton;
        [SerializeField] private Button _decrementButton;

        [SerializeField] private TMP_InputField _inputField;

        private MvcModel _model;

        public event UnityAction IncrementButtonClick;
        public event UnityAction DecrementButtonClick;
        public event UnityAction<string> InputFieldValueChanged;

        public void Construct(MvcModel model)
        {
            _model = model;
        }

        private void Awake()
        {
            _incrementButton.onClick.AddListener(OnIncrementButtonClick);
            _decrementButton.onClick.AddListener(OnDecrementButtonClick);
            _inputField.onValueChanged.AddListener(OnInputFieldValueChanged);
        }

        private void Update()
        {
            _intValue.text = _model.IntValue.ToString();
            _stringValue.text = _model.StringValue;
        }

        private void OnDestroy()
        {
            _incrementButton.onClick.RemoveListener(OnIncrementButtonClick);
            _decrementButton.onClick.RemoveListener(OnDecrementButtonClick);
        }

        private void OnIncrementButtonClick()
        {
            IncrementButtonClick?.Invoke();
        }
        
        private void OnDecrementButtonClick()
        {
            DecrementButtonClick?.Invoke();
        }

        private void OnInputFieldValueChanged(string value)
        {
            InputFieldValueChanged?.Invoke(value);
        }
    }
}

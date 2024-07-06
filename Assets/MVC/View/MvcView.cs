using MVC.Controller;
using MVC.Model;
using TMPro;
using UnityEngine;
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
        private MvcController _mvcController;

        public void Construct(MvcModel model, MvcController mvcController)
        {
            _model = model;
            _mvcController = mvcController;
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
            _inputField.onValueChanged.RemoveListener(OnInputFieldValueChanged);
        }

        private void OnIncrementButtonClick() => 
            _mvcController.IncrementIntValue();

        private void OnDecrementButtonClick() => 
            _mvcController.DecrementIntValue();

        private void OnInputFieldValueChanged(string value) => 
            _mvcController.SetStringValue(value);
    }
}
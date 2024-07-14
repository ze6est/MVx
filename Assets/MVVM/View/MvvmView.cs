using MVVM.ViewModel;
using TMPro;
using UniRx;
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

        private readonly CompositeDisposable _disposable = new();
        private MvvmViewModel _mvvmViewModel;

        public void Construct(MvvmViewModel mvvmViewModel)
        {
            _mvvmViewModel = mvvmViewModel;

            _mvvmViewModel.Score.Subscribe(value => 
                _intValue.text = value.ToString())
                .AddTo(_disposable);

            _mvvmViewModel.TextValue.Subscribe(value => 
                _stringValue.text = value)
                .AddTo(_disposable);
        }
        
        private void Awake()
        {
            _incrementButton.OnClickAsObservable().Subscribe(_ => 
                _mvvmViewModel.IncrementIntValue())
                .AddTo(_disposable);

            _decrementButton.OnClickAsObservable().Subscribe(_ => 
                _mvvmViewModel.DecrementIntValue())
                .AddTo(_disposable);

            _inputField.onValueChanged.AsObservable().Subscribe(text => 
                _mvvmViewModel.SetStringValue(text))
                .AddTo(_disposable);
        }

        private void OnDestroy() => 
            _disposable.Clear();
    }
}
using System;
using MVVM.Model;
using UniRx;

namespace MVVM.ViewModel
{
    public class MvvmViewModel : IDisposable
    {
        public readonly ReactiveProperty<int> Score = new();
        public readonly ReactiveProperty<string> TextValue = new();

        private readonly CompositeDisposable _disposable = new();
        private readonly MvvmModel _mvvmModel;

        public MvvmViewModel(MvvmModel mvvmModel)
        {
            _mvvmModel = mvvmModel;

            _mvvmModel.Score.Subscribe(value => 
                Score.Value = value)
                .AddTo(_disposable);

            _mvvmModel.TextValue.Subscribe(value => 
                TextValue.Value = value)
                .AddTo(_disposable);
        }
        
        public void IncrementIntValue()
        {
            Score.Value++;
            _mvvmModel.ChangeIntValue(Score.Value);
        }
        
        public void DecrementIntValue()
        {
            Score.Value--;
            _mvvmModel.ChangeIntValue(Score.Value);
        }
        
        public void SetStringValue(string value)
        {
            TextValue.Value = value;
            _mvvmModel.ChangeStringValue(TextValue.Value);
        }
        
        public void Dispose() => 
            _disposable.Clear();
    }
}
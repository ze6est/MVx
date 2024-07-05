using System;
using MVP.Model;
using MVP.View;

namespace MVP.Presenter
{
    public class MvpPresenter : IDisposable
    {
        private readonly MvpModel _mvpModel;
        private readonly MvpView _mvpView;
        
        public MvpPresenter(MvpModel mvpModel, MvpView mvpView)
        {
            _mvpModel = mvpModel;
            _mvpView = mvpView;

            _mvpView.IncrementButtonClick += OnIncrementButtonClick;
            _mvpView.DecrementButtonClick += OnDecrementButtonClick;
            _mvpView.InputFieldValueChanged += OnInputFieldValueChanged;

            _mvpModel.IntValueChanged += OnIntValueChanged;
        }

        public void Dispose()
        {
            _mvpView.IncrementButtonClick -= OnIncrementButtonClick;
            _mvpView.DecrementButtonClick -= OnDecrementButtonClick;
            _mvpView.InputFieldValueChanged -= OnInputFieldValueChanged;
            
            _mvpModel.IntValueChanged -= OnIntValueChanged;
        }

        private void OnIncrementButtonClick() => 
            _mvpModel.IncrementIntValue();

        private void OnDecrementButtonClick() => 
            _mvpModel.DecrementIntValue();

        private void OnInputFieldValueChanged(string value)
        {
            _mvpModel.SetStringValue(value);
            _mvpView.UpdateStringValue(value);
        }
        
        private void OnIntValueChanged(int value) => 
            _mvpView.UpdateIntValue(value);
    }
}
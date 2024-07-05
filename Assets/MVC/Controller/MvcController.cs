using System;
using MVC.Model;
using MVC.View;

namespace MVC.Controller
{
    public class MvcController : IDisposable
    {
        private readonly MvcModel _model;
        private readonly MvcView _view;

        public MvcController(MvcModel model, MvcView view)
        {
            _model = model;
            _view = view;
            
            _view.IncrementButtonClick += OnIncrementButtonClick;
            _view.DecrementButtonClick += OnDecrementButtonClick;
            _view.InputFieldValueChanged += OnInputFieldValueChanged;
        }
        
        public void Dispose()
        {
            _view.IncrementButtonClick -= OnIncrementButtonClick;
            _view.DecrementButtonClick -= OnDecrementButtonClick;
            _view.InputFieldValueChanged -= OnInputFieldValueChanged;
        }

        private void OnIncrementButtonClick() => 
            _model.IncrementIntValue();

        private void OnDecrementButtonClick() => 
            _model.DecrementIntValue();

        private void OnInputFieldValueChanged(string value) => 
            _model.SetStringValue(value);
    }
}
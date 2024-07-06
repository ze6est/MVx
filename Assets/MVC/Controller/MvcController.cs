using MVC.Model;

namespace MVC.Controller
{
    public class MvcController
    {
        private readonly MvcModel _model;

        public MvcController(MvcModel model) => 
            _model = model;

        public void IncrementIntValue() =>
            _model.IncrementIntValue();

        public void DecrementIntValue() =>
            _model.DecrementIntValue();

        public void SetStringValue(string value) =>
            _model.SetStringValue(value);
    }
}
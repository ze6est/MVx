namespace MVC.Model
{
    public class MvcModel
    {
        private int _intValue;
        private string _stringValue;

        public int IntValue => _intValue;
        public string StringValue => _stringValue;

        public void IncrementIntValue()
        {
            _intValue++;
        }
        
        public void DecrementIntValue()
        {
            _intValue--;
        }

        public void SetStringValue(string value)
        {
            _stringValue = value;
        }
    }
}

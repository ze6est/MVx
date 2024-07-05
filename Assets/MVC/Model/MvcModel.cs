namespace MVC.Model
{
    public class MvcModel
    {
        public int IntValue;
        public string StringValue;

        public void IncrementIntValue() => 
            IntValue++;

        public void DecrementIntValue() => 
            IntValue--;

        public void SetStringValue(string value) => 
            StringValue = value;
    }
}
using UniRx;

namespace MVVM.Model
{
    public class MvvmModel
    {
        public readonly ReactiveProperty<int> Score = new(0);
        public readonly ReactiveProperty<string> TextValue = new();

        public void ChangeIntValue(int value) => 
            Score.Value = value;

        public void ChangeStringValue(string value) => 
            TextValue.Value = value;
    }
}
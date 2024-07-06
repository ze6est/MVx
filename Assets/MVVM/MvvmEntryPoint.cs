using MVVM.Model;
using MVVM.View;
using MVVM.ViewModel;
using UnityEngine;

namespace MVVM
{
    public class MvvmEntryPoint : MonoBehaviour
    {
        [SerializeField] private MvvmView _mvvmView;

        private MvvmModel _mvvmModel;
        private MvvmViewModel _mvvmVieModel;

        private void Awake()
        {
            _mvvmModel = new MvvmModel();
            _mvvmVieModel = new MvvmViewModel(_mvvmModel);
            _mvvmView.Construct(_mvvmVieModel);
        }

        private void OnDestroy() => 
            _mvvmVieModel.Dispose();
    }
}

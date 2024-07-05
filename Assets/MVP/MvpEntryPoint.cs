using MVP.Model;
using MVP.Presenter;
using MVP.View;
using UnityEngine;

namespace MVP
{
    public class MvpEntryPoint : MonoBehaviour
    {
        [SerializeField] private MvpView _mvpView;

        private MvpModel _mvpModel;
        private MvpPresenter _mvpPresenter;

        private void Awake()
        {
            _mvpModel = new MvpModel();
            _mvpPresenter = new MvpPresenter(_mvpModel, _mvpView);
        }

        private void OnDestroy() => 
            _mvpPresenter.Dispose();
    }
}
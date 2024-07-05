using MVC.Controller;
using MVC.Model;
using MVC.View;
using UnityEngine;

namespace MVC
{
    public class MvcEntryPoint : MonoBehaviour
    {
        [SerializeField] private MvcView _mvcView;

        private MvcModel _mvcModel;
        private MvcController _mvcController;

        private void Awake()
        {
            _mvcModel = new MvcModel();
            _mvcView.Construct(_mvcModel);
            _mvcController = new MvcController(_mvcModel, _mvcView);
        }

        private void OnDestroy()
        {
            _mvcController.Dispose();
        }
    }
}

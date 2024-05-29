using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Karting.UI.Core
{
    public abstract class UIScreen : UIComponent
    {
        [SerializeField]
        private Button _backButton;
        [SerializeField]
        private UIScreen _returnsTo;

        public UnityAction<UIScreen> OnReturn { get; set; }

        private void Start()
        {
            _backButton.onClick.AddListener(Return);
        }

        private void Return()
        {
            if (OnReturn is null)
            {
                return;
            }

            OnReturn(_returnsTo);
        }
    }
}
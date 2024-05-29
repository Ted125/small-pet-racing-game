using UnityEngine;
using UnityEngine.UI;

namespace Karting.UI.Core
{
    public class UIPopup : UIComponent
    {
        [SerializeField]
        private Button _closeButton;

        private void Start()
        {
            _closeButton.onClick.AddListener(() => gameObject.SetActive(false));
        }
    }
}
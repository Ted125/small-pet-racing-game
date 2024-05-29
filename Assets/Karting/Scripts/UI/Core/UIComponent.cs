using UnityEngine;

namespace Karting.UI.Core
{
    public class UIComponent : MonoBehaviour
    {
        public bool Visible { get; private set; }

        private void OnEnable()
        {
            Show();
        }

        private void OnDisable()
        {
            Hide();
        }

        public void Show()
        {
            if (Visible)
            {
                return;
            }

            Visible = true;
            OnShow();
        }

        public void Hide()
        {
            if (!Visible)
            {
                return;
            }

            Visible = false;
            OnHide();
        }

        protected virtual void OnShow() { }

        protected virtual void OnHide() { }
    }
}
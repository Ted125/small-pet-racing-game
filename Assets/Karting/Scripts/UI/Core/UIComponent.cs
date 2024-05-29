using UnityEngine;

namespace Karting.UI.Core
{
    public abstract class UIComponent : MonoBehaviour
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

        protected abstract void OnShow();

        protected abstract void OnHide();
    }
}
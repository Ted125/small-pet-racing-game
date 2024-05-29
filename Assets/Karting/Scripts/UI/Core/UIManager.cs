using System.Collections.Generic;
using Karting.Utilities;
using UnityEngine;

namespace Karting.UI.Core
{
    public class UIManager : Singleton<UIManager>
    {
        [SerializeField] private List<UIScreen> _screenPrefabs = new List<UIScreen>();
        [SerializeField] private List<UIPopup> _popupPrefabs = new List<UIPopup>();
        [SerializeField] private Canvas _canvas;

        public UIScreen CurrentScreen { get { return _screenStack.Count > 0 ? _screenStack.Peek() : null; } }
        public UIPopup CurrentPopup { get { return _popupStack.Count > 0 ? _popupStack.Peek() : null; } }

        private Stack<UIScreen> _screenStack = new Stack<UIScreen>();
        private Stack<UIPopup> _popupStack = new Stack<UIPopup>();

        public void ShowScreen<T>() where T : UIScreen
        {
            var existingScreen = FindObjectOfType<T>(true);

            if (existingScreen is not null)
            {
                if (CurrentScreen != existingScreen)
                {
                    if (CurrentScreen is not null)
                    {
                        CurrentScreen.gameObject.SetActive(false);
                        _screenStack.Pop();
                    }

                    _screenStack.Push(existingScreen);
                }

                CurrentScreen.gameObject.SetActive(true);
            }
            else
            {
                var newScreenPrefab = _screenPrefabs.Find(prefab => prefab is T);

                if (newScreenPrefab is null)
                {
                    return;
                }

                var newScreen = Instantiate(newScreenPrefab, _canvas.transform);

                if (CurrentScreen is not null)
                {
                    CurrentScreen.gameObject.SetActive(false);
                    _screenStack.Pop();
                }

                _screenStack.Push(newScreen);
                CurrentScreen.gameObject.SetActive(true);
            }
        }

        public void ShowPopup<T>() where T : UIPopup
        {
            var existingPopup = FindObjectOfType<T>(true);

            if (existingPopup is not null)
            {
                if (CurrentPopup != existingPopup)
                {
                    _popupStack.Push(existingPopup);
                }

                CurrentPopup.gameObject.SetActive(true);
            }
            else
            {
                var newPopupPrefab = _popupPrefabs.Find(prefab => prefab is T);

                if (newPopupPrefab is null)
                {
                    return;
                }

                var newPopup = Instantiate(newPopupPrefab, _canvas.transform);
                _popupStack.Push(newPopup);
                CurrentPopup.gameObject.SetActive(true);
            }
        }
    }
}
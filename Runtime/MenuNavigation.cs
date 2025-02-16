using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace DiegeticMainMenu
{
    [RequireComponent(typeof(PlayerInput))]
    public class MenuNavigation : MonoBehaviour
    {
        private GameObject _lastSelected;
        private bool _doHighlight;

        private void OnEnable()
        {
            MenuManager.Instance.OnMenuChanged += OnMenuChanged;
        }

        private void OnDisable()
        {
            MenuManager.Instance.OnMenuChanged -= OnMenuChanged;
        }

        private void OnClick()
        {
            EnableMouseNavigation();
        }

        private void OnLook()
        {
            EnableMouseNavigation();
        }

        private void OnNavigate()
        {
            EnableKeyboardNavigation();
        }

        private void OnMenuChanged()
        {
            if (_lastSelected)
                _lastSelected = MenuManager.Instance.CurrentMenu.FirstSelected.gameObject;

            if (_doHighlight)
                EventSystem.current.SetSelectedGameObject(_lastSelected);
        }

        private void EnableMouseNavigation()
        {
            EventSystem.current.SetSelectedGameObject(null);
            _doHighlight = false;
        }

        private void EnableKeyboardNavigation()
        {
            _doHighlight = true;

            if (EventSystem.current.currentSelectedGameObject)
            {
                _lastSelected = EventSystem.current.currentSelectedGameObject;
                return;
            }

            if (_lastSelected)
                EventSystem.current.SetSelectedGameObject(_lastSelected);
            else
            {
                var firstSelectable = MenuManager.Instance.CurrentMenu.FirstSelected;
                EventSystem.current.SetSelectedGameObject(firstSelectable.gameObject);
            }
        }
    }
}
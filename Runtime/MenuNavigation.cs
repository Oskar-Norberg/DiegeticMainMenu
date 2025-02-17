using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace DiegeticMainMenu
{
    [RequireComponent(typeof(PlayerInput))]
    public class MenuNavigation : MonoBehaviour
    {
        private Dictionary<Menu, GameObject> _lastSelected = new Dictionary<Menu, GameObject>();
        private bool _doHighlight;

        private void OnEnable()
        {
            MenuManager.Instance.OnMenuChanged += OnMenuChanged;
            MenuManager.Instance.OnMenuBack += OnMenuBack;
        }

        private void OnDisable()
        {
            MenuManager.Instance.OnMenuChanged -= OnMenuChanged;
            MenuManager.Instance.OnMenuBack -= OnMenuBack;
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
            Navigate();
        }

        private void OnMenuChanged()
        {
            var currentMenu = MenuManager.Instance.CurrentMenu;

            if (!_lastSelected.ContainsKey(MenuManager.Instance.CurrentMenu))
                _lastSelected[currentMenu] = currentMenu.FirstSelected.gameObject;

            if (!_doHighlight)
                return;

            EventSystem.current.SetSelectedGameObject(_lastSelected[currentMenu]);
        }

        private void OnMenuBack()
        {
            _lastSelected.Remove(MenuManager.Instance.CurrentMenu);
        }

        private void EnableMouseNavigation()
        {
            EventSystem.current.SetSelectedGameObject(null);
            _doHighlight = false;
        }

        private void EnableKeyboardNavigation()
        {
            _doHighlight = true;
        }

        private void Navigate()
        {
            var currentMenu = MenuManager.Instance.CurrentMenu;

            if (!EventSystem.current.currentSelectedGameObject)
            {
                GameObject selected = null;
                if (_lastSelected.TryGetValue(currentMenu, out var value))
                    selected = value;
                else
                    selected = currentMenu.FirstSelected.gameObject;
                
                EventSystem.current.SetSelectedGameObject(selected);
            }

            _lastSelected[currentMenu] = EventSystem.current.currentSelectedGameObject;
        }
    }
}
using UnityEngine;
using UnityEngine.UI;

namespace DiegeticMainMenu
{
    [RequireComponent(typeof(Button))]
    public class MenuSwitcherButton : MonoBehaviour
    {
        [SerializeField] private Menu menuToGoTo;

        private Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(SwitchMenu);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(SwitchMenu);
        }

        private void SwitchMenu()
        {
            MenuManager.Instance.SwitchMenu(menuToGoTo);
        }
    }
}
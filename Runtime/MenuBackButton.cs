using UnityEngine;
using UnityEngine.UI;

namespace DiegeticMainMenu
{
    [RequireComponent(typeof(Button))]
    public class MenuBackButton : MonoBehaviour
    {
        private Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(Back);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(Back);
        }

        private void Back()
        {
            MenuManager.Instance.Back();
        }
    }
}
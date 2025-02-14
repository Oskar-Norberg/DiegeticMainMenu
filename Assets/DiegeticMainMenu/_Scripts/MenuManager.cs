using DiegeticMainMenu.Singleton;
using UnityEngine;

namespace DiegeticMainMenu
{
    public class MenuManager : Singleton<MenuManager>
    {
        [SerializeField] private Menu startingMenu;

        private Menu _currentMenu;

        protected override void Awake()
        {
            base.Awake();

            SwitchMenu(startingMenu);
        }

        public void SwitchMenu(Menu menu)
        {
            _currentMenu?.SetActive(false);
            menu.SetActive(true);

            _currentMenu = menu;
        }
    }
}
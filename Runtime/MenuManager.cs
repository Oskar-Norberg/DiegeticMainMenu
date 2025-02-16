using System.Collections.Generic;
using DiegeticMainMenu.Singleton;
using UnityEngine;

namespace DiegeticMainMenu
{
    public class MenuManager : Singleton<MenuManager>
    {
        [SerializeField] private Menu startingMenu;

        private Stack<Menu> _menuStack = new Stack<Menu>();

        protected override void Awake()
        {
            base.Awake();

            EnterSubMenu(startingMenu);
        }

        public void EnterSubMenu(Menu menu)
        {
            if (_menuStack.Count > 0)
                _menuStack.Peek()?.SetActive(false);
            
            _menuStack.Push(menu);
            _menuStack.Peek().SetActive(true);
        }
        
        public void Back()
        {
            if (_menuStack.Count <= 1)
                return;
            
            _menuStack.Pop().SetActive(false);
            _menuStack.Peek().SetActive(true);
        }
    }
}
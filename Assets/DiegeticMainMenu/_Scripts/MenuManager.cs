using System;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance { get; private set; }

    [SerializeField] private Menu startingMenu;

    private Menu _currentMenu;
    
    private void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
            return;
        }
        
        Instance = this;
        
        SwitchMenu(startingMenu);
    }
    
    public void SwitchMenu(Menu menu)
    {
        _currentMenu?.SetActive(false);
        menu.SetActive(false);
        
        _currentMenu = menu;
    }
}

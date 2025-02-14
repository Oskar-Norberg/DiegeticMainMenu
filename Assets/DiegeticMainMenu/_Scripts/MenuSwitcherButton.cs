using UnityEngine;

public class MenuSwitcherButton : MonoBehaviour
{
    [SerializeField] private Menu menuToGoTo;

    public void SwitchMenu()
    {
        MenuManager.Instance.SwitchMenu(menuToGoTo);
    }
}

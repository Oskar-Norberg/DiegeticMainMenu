using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace DiegeticMainMenu
{
    public class Menu : MonoBehaviour
    {
        private const int ActivatedPriority = 10;
        [Header("Menu Properties")]
        [SerializeField] private bool hideWhenInactive = false;
        
        [Header("Menu References")]
        [SerializeField] private Selectable firstSelected;
        [SerializeField] private CinemachineCamera cinemachineCamera;

        private int _cachedPriority;

        private void Awake()
        {
            _cachedPriority = cinemachineCamera.Priority;
            SetActive(false);
        }

        public void SetActive(bool active)
        {
            if (hideWhenInactive)
                gameObject.SetActive(active);
            
            cinemachineCamera.gameObject.SetActive(active);
            cinemachineCamera.Priority = active ? ActivatedPriority : _cachedPriority;

            if (active)
                EventSystem.current.SetSelectedGameObject(firstSelected.gameObject);
        }
    }
}
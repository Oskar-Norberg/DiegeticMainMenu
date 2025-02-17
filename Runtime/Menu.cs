using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace DiegeticMainMenu
{
    public class Menu : MonoBehaviour
    {
        private const int ActivatedPriority = 10;

        [Header("Menu Properties")] [SerializeField]
        private bool hideWhenInactive = false;

        [Header("Menu References")] [SerializeField]
        private Selectable firstSelected;

        [SerializeField] private CinemachineCamera cinemachineCamera;
        [SerializeField] public UnityAction OnMenuActivated;

        public Selectable FirstSelected => firstSelected;

        private int _cachedPriority;

        private void Awake()
        {
            if (!firstSelected)
                Debug.LogWarning("No first selected object assigned to menu: " + name);
            if (!cinemachineCamera)
                Debug.LogWarning("No cinemachine camera assigned to menu: " + name);

            _cachedPriority = cinemachineCamera.Priority;
            SetActive(false);
        }

        public void SetActive(bool active)
        {
            if (hideWhenInactive)
                gameObject.SetActive(active);
                OnMenuActivated?.Invoke();

            cinemachineCamera.gameObject.SetActive(active);
            cinemachineCamera.Priority = active ? ActivatedPriority : _cachedPriority;
        }
    }
}
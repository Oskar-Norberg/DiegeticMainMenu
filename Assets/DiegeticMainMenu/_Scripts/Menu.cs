using Unity.Cinemachine;
using UnityEngine;

public class Menu : MonoBehaviour
{
    private const int ActivatedPriority = 10;
    
    [SerializeField] private CinemachineCamera cinemachineCamera;

    private int _cachedPriority;

    private void Awake()
    {
        _cachedPriority = cinemachineCamera.Priority;
    }

    public void SetActive(bool active)
    {
        cinemachineCamera.gameObject.SetActive(active);
        cinemachineCamera.Priority = active ? ActivatedPriority : _cachedPriority;
    }
}

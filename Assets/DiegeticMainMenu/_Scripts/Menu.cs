using Unity.Cinemachine;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private CinemachineCamera cinemachineCamera;

    public void SetActive(bool active)
    {
        cinemachineCamera.gameObject.SetActive(true);
    }
}

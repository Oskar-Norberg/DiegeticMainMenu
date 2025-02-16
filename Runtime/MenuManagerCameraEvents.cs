using System;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.Events;

public class MenuManagerCameraEvents : MonoBehaviour
{
    [SerializeField] public UnityEvent onBlendStarted;
    
    private void OnEnable()
    {
        CinemachineCore.BlendCreatedEvent.AddListener(BlendStarted);
    }

    private void OnDisable()
    {
        CinemachineCore.BlendCreatedEvent.RemoveListener(BlendStarted);
    }

    private void BlendStarted(CinemachineCore.BlendEventParams blendEventParams)
    {
        onBlendStarted.Invoke();
    }
}

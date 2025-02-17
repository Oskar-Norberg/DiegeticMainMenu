using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.Events;

public class MenuManagerCameraEvents : MonoBehaviour
{
    [SerializeField] public UnityEvent onBlendStarted;
    [SerializeField] public UnityEvent onBlendFinished;
    
    private void OnEnable()
    {
        CinemachineCore.BlendCreatedEvent.AddListener(BlendStarted);
        CinemachineCore.BlendFinishedEvent.AddListener(BlendFinished);
    }

    private void OnDisable()
    {
        CinemachineCore.BlendCreatedEvent.RemoveListener(BlendStarted);
        CinemachineCore.BlendFinishedEvent.RemoveListener(BlendFinished);
    }

    private void BlendStarted(CinemachineCore.BlendEventParams blendEventParams)
    {
        onBlendStarted.Invoke();
    }

    private void BlendFinished(ICinemachineMixer cinemachineMixer, ICinemachineCamera cinemachineCamera)
    {
        onBlendFinished.Invoke();
    }
}

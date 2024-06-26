using Cinemachine;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager Instance;

    [SerializeField] CinemachineVirtualCamera[] cameras;
    [SerializeField] CinemachineImpulseSource impulseSource;

    private void Awake()
    {
        Instance = this;
    }

    public void ChangeCamera(int index)
    {
        foreach (var cam in cameras)
        {
            cam.Priority = 0;
        }
        cameras[index].Priority = 10;
    }

    public void ZoomInZoomOutEffect()
    {
        impulseSource.GenerateImpulse();
    }

    public void Shaking(int index, bool shakeState)
    {
        if (shakeState)
        {
            cameras[index].GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 0.15f;
        }
        else
        {
            cameras[index].GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 0f;
        }
    }

    public void SetLookAtTarget(int index,Transform target)
    {
        cameras[index].LookAt = target;
    }
}

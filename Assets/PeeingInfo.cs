using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeeingInfo : MonoBehaviour
{
    public Animator Camera;
    public void PlayPeeng()
    {
        Camera.Play("CameraWhilePeeing");
    }
}

using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CryingBabyArea : MonoBehaviour
{
    public Video2 v2;

    private void OnMouseDown()
    {

        v2.nurse.Play("walking");
        Vector3[] pathPositions = new Vector3[v2.paths.Length];
        for (int i = 0; i < pathPositions.Length; i++)
        {
            pathPositions[i] = v2.paths[i].position;
        }
        v2.nurse.transform.DOPath(pathPositions, 2, PathType.CatmullRom, PathMode.Full3D, 7).SetLookAt(-1).SetEase(Ease.Linear).OnComplete(() =>
        {
            // v2.nurse.transform.DORotateQuaternion(v2.paths[3].rotation, 0.5f);
            v2.nurse.Play("Idle");
            v2.cameraAnim.Play("CamraToNurse");
        });
    }
}

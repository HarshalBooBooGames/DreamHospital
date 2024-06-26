using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeManager : MonoBehaviour
{
    public Video2 v2;
    public Transform parent;
    public GameObject baby;
    public Transform baby2;
    bool cantrack;
    void Update()
    {
        if (cantrack)
            baby.transform.localPosition = baby2.localPosition;
    }
    public void TakeBaby()
    {
      //  v2.OffBaby();
        baby.transform.parent = parent;
        cantrack = true;
    }
}

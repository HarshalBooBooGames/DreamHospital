using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedInfo : MonoBehaviour
{
    public Outline outline;
    public Video2 v2;
    private void OnMouseDown()
    {
        v2.OffOutLine();
        outline.enabled = true;
        v2.ChooseAnimator.Play("Button");

    }

}

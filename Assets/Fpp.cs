using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fpp : MonoBehaviour
{
    public Video3 v3;


    public void Surgone()
    {
        v3.surgone.gameObject.SetActive(true);
    }
    public void SurgOff()
    {
        v3.surgone.gameObject.SetActive(false);
    }
    public void OnUi()
    {
        v3.SelectUi.gameObject.SetActive(true);
        
    }
    public void onHairs()
    {
        v3.hairs.gameObject.SetActive(true);
    }
    public void OnBaby()
    {
        v3.DrawLine.gameObject.SetActive(false);
       v3.Knife.gameObject.SetActive(true);
       v3.cutCg.alpha = 1;
       // v3.line.gameObject.SetActive(true);
       // v3.babay.gameObject.SetActive(true);
    }
    public void OfSaw()
    {
        v3.saw.gameObject.SetActive(false);
    }
    public void OnCutter()
    {
        v3.currtuns.Play("ShutDoor");
    }
    public void OnSug()
    {
        v3.Cutter.gameObject.SetActive(true);
        
    }

    public void DrawLine()
    {
        v3.DrawLine.gameObject.SetActive(true);
    }
    public void OnTick()
    {
        v3.cuttick.gameObject.SetActive(true);
    }
    public void OpenCurr()
    {
        v3.currtuns.Play("OpenCurr");
    }
   
}

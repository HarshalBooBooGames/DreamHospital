using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Video3 : MonoBehaviour
{
    public Animator camAni;
    public GameObject Glouse;
    public Animator surgone;
    public Animator trimer;
    public GameObject trimertick;
    public CanvasGroup trimerCG;
    public GameObject cuttick;
    public CanvasGroup cutCg;
    public GameObject Knife;
    public CanvasGroup sawCg;
    public GameObject SelectUi;
    public GameObject babay;
    public GameObject saw;
    public GameObject Cutter;
    public Animator currtuns;
    public GameObject line;
    public GameObject DrawLine;
    public Animator paperAnim;
    public GameObject hairs;
    public GameObject paperTick;
    public GameObject GirlObj;
    public GameObject PregObj;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            camAni.Play("StartCam");
            trimerCG.alpha = 1f;
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            Glouse.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            trimer.Play("RazorClip");
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            cuttick.SetActive(true);
            Knife.SetActive(false);
            cutCg.alpha = .7f;
            camAni.Play("AfterCut");
            sawCg.alpha = 1.0f;
            babay.SetActive(false);
            line.gameObject.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            camAni.Play("TakingSaw");
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            paperAnim.gameObject.SetActive(true);
            camAni.Play("WearingGlows");
            paperTick.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            camAni.Play("CloseCur");
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            SelectUi.gameObject.SetActive(false);
            camAni.Play("OpenCurr");
            GirlObj.SetActive(true);
            PregObj.SetActive(false);
        }
       

    }
}

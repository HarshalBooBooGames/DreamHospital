using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrimmerControl : MonoBehaviour
{
    public Video3 v3;
    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Contains("Hairs"))
        {
            Destroy(other.gameObject);
        }
    }
    public void DoneWithTrim()
    {
        v3.trimertick.SetActive(true);
        v3.trimerCG.alpha = 0.7f;
        //v3.trimertick.GetComponent<Animator>().enabled = false;
        v3.camAni.Play("AfterShave");
        v3.cutCg.alpha = 1f;
    }
    
}

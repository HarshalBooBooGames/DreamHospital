using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dor : MonoBehaviour
{
   public  Animator animator;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "OpenDoor")
        {
            animator.Play("DorOpen");
        }
    }
}

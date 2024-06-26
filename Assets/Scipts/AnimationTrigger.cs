using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTrigger : MonoBehaviour
{
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private int i;
    public void StopAnim()
    {
        i++;
        if(i== 2)
        {
            animator.enabled = false;
        }
    }
}

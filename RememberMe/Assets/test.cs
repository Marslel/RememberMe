using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (anim != null)
            {
                // play Bounce but start at a quarter of the way though
                anim.SetTrigger("Play");
            }
        }
    }

    public AnimationClip FindAnimation (Animator animator, string name) 
    {
    foreach (AnimationClip clip in animator.runtimeAnimatorController.animationClips)
    {
        if (clip.name == name)
        {
            return clip;
        }
    }

    return null;
    }
}

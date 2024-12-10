using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine.SceneManagement;

public class AnimationManager : MonoBehaviour
{
    [SerializeField]
    private bool hasAnimator = false;
    private Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(!hasAnimator)
        {
            animator = transform.parent.GetComponent<Animator>();
        }
        else
        {
            animator = GetComponent<Animator>();
        }
    }
    
    public void PlayAnimation(string animationName)
    {
        animator.SetTrigger(animationName);
    }
    
}

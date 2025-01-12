using UnityEngine;

public class InteractDoor : Interactable
{
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public override void Interact()
    {
        //Debug.Log("abcd");
        anim.SetTrigger("Advanced");
    }

}

using UnityEngine;

public class Door : Interactable
{
    [SerializeField] private Animator anim;

    public override void Interact()
    {
        anim.SetTrigger("Advanced");
    }
}

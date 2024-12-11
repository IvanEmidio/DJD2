using UnityEngine;

public class InteractionOverall : Interactable
{
    [SerializeField] private Animator anim;

    public override void Interact()
    {
        anim.SetTrigger("Advanced");
    }
}

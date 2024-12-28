using UnityEngine;

public class InteractionOverall : Interactable
{
    [SerializeField] private Animator anim;
    private bool _puzzleComplete = false;

    public override void Interact()
    {   
        if(_puzzleComplete)
            anim.SetTrigger("Advanced");
    }

    public void IsComplete()
    {
        _puzzleComplete = true;
    }
}

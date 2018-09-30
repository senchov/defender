using UnityEngine;
using Assets.Scripts.View;

public class AtackAnimatorScript : StateMachineBehaviour
{
    private IAtackable Atackable;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Atackable == null)
        {
            Atackable = animator.gameObject.GetComponent<IAtackable>();
            if (Atackable == null)
                Debug.LogError("IAtackable is absent on " + animator.gameObject.name);

        }        

        Atackable.Atack();
    }
}

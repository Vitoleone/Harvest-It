using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [Header("Attributes")] 
    [SerializeField] private Animator playerAnimator;
    [Header("Settings")] 
    [SerializeField] private float movespeedMultiplier;
    public void ManageAnimations(Vector3 moveVector)
    {
        if (moveVector.magnitude > 0)
        {
            PlayRunAnimation();
            playerAnimator.SetFloat("MoveSpeed",moveVector.magnitude * movespeedMultiplier);
            playerAnimator.transform.forward = moveVector.normalized;
        }
        else
        {
            PlayIdleAnimation();
        }
    }

    void PlayRunAnimation()
    {
        playerAnimator.Play("Run");
    }
    void PlayIdleAnimation()
    {
        playerAnimator.Play("PlayerIdleAnim");
    }
}

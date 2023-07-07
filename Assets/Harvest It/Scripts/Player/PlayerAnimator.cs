using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [Header("Attributes")] 
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private ParticleSystem waterParticles;
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
    public void PlaySeedingAnimation()
    {
        playerAnimator.SetLayerWeight(1,1);
    }
    public void StopSeedingAnimation()
    {
        playerAnimator.SetLayerWeight(1,0);
    }

    public void StopWateringAnimation()
    {
        playerAnimator.SetLayerWeight(2,0);
        waterParticles.Stop();
    }

    public void PlayWateringAnimation()
    {
        playerAnimator.SetLayerWeight(2,1);
    }
}

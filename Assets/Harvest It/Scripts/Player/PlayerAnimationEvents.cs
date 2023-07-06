using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationEvents : MonoBehaviour
{
    [Header("Attributes")] 
    [SerializeField] private ParticleSystem seedParticles;

    void PlaySeedParticles()
    {
        seedParticles.Play();
    }
}

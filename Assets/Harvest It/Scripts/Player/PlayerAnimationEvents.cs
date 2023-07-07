using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationEvents : MonoBehaviour
{
    [Header("Attributes")] 
    [SerializeField] private ParticleSystem seedParticles;
    [SerializeField] private ParticleSystem waterParticles;

    void PlaySeedParticles()
    {
        seedParticles.Play();
    }

    void PlayWaterParticles()
    {
        waterParticles.Play();
    }
    void StopWaterParticles()
    {
        waterParticles.Stop();
    }
}

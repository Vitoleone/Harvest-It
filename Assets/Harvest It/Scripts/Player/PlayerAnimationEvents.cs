using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerAnimationEvents : MonoBehaviour
{
    [Header("Attributes")] 
    [SerializeField] private ParticleSystem seedParticles;
    [SerializeField] private ParticleSystem waterParticles;

    [Header("Attributes")] 
    [SerializeField] private UnityEvent startHarvesting;
    [SerializeField] private UnityEvent stopHarvesting;
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

    void StartHarvesting()
    {
        startHarvesting?.Invoke();
    }

    void StopHarvesting()
    {
        stopHarvesting?.Invoke();
    }
}

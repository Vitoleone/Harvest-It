using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine.Utility;
using UnityEngine;

public class TransactionEffectManager : MonoBehaviour
{
    public static TransactionEffectManager instance;
    
    [Header("Attributes")] 
    [SerializeField] private ParticleSystem coinPS;
    [SerializeField] private RectTransform coinsImageTransform;
    [Header("Settings")]
    [SerializeField]private float moveSpeed;
    private int coinsAmount;
    private Camera camera;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        camera = Camera.main;
    }

    [NaughtyAttributes.Button()]
    private void PlayCoinParticlesTest()
    {
        PlayCoinPartcile(100);
    }

    public void PlayCoinPartcile(int amount)
    {
        if(coinPS.isPlaying)
            return;
        
        ParticleSystem.Burst burst = coinPS.emission.GetBurst(0);
        burst.count = amount;
        coinPS.emission.SetBurst(0,burst);
        coinsAmount = amount;
        ParticleSystem.MainModule main = coinPS.main;
        main.gravityModifier = 2;
        coinPS.Play();

        StartCoroutine(PlayCoinPArticlesCourutine());
    }
    

    IEnumerator PlayCoinPArticlesCourutine()
    {
        yield return new WaitForSeconds(1);
        ParticleSystem.MainModule main = coinPS.main;
        main.gravityModifier = 0;
        ParticleSystem.Particle[] particles = new ParticleSystem.Particle[coinsAmount];
        coinPS.GetParticles(particles);

        Vector3 direction = (coinsImageTransform.position - camera.transform.position).normalized;
        Vector3 targetPosition = camera.transform.position + direction * Vector3.Distance(camera.transform.position,coinPS.transform.position);
        while (coinPS.isPlaying)
        {
            coinPS.GetParticles(particles);
            for (int i = 0; i < particles.Length; i++)
            {
                if(particles[i].remainingLifetime <= 0)
                    continue;
                
                particles[i].position = Vector3.MoveTowards(particles[i].position, targetPosition,moveSpeed * Time.deltaTime);
                if (Vector3.Distance(particles[i].position, targetPosition) < 0.01f)
                {
                    CashManager.instance.AddCoins(1);
                    particles[i].position += Vector3.up * 10000;
                }
            }
            coinPS.SetParticles(particles);
            yield return null;
        }
        coinPS.SetParticles(particles);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crop : MonoBehaviour
{
    [Header("Attrivutes")] 
    [SerializeField] private ParticleSystem harvestParticle;

    public void Grown()
    {
        gameObject.LeanScale(Vector3.one * 5.1f, 1.75f).setEase(LeanTweenType.easeOutBack);
    }

    public void Harvested()
    {
        gameObject.LeanScale(Vector3.zero, 1f).setEase(LeanTweenType.easeOutBack).setOnComplete(() =>
        {
            Destroy(gameObject);
        });
        harvestParticle.gameObject.SetActive(true);
        harvestParticle.transform.parent = null;
        harvestParticle.Play();
    }
}

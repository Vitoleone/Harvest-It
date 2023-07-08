using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class WaterParticle : MonoBehaviour
{
    public static Action<Vector3[]> onWaterCollided;
    private void OnParticleCollision(GameObject other)
    {
        ParticleSystem particle = GetComponent<ParticleSystem>();
        List<ParticleCollisionEvent> collisionEvents = new List<ParticleCollisionEvent>();
        int eventCount = particle.GetCollisionEvents(other, collisionEvents);

        Vector3[] collisionParticlePosition = new Vector3[eventCount];

        for (int i = 0; i < eventCount; i++)
        {
            collisionParticlePosition[i] = collisionEvents[i].intersection;
        }
        onWaterCollided?.Invoke(collisionParticlePosition);
        Debug.Log("Water Collided");
    }
}

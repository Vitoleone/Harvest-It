using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCropInteraction : MonoBehaviour
{
    [Header("Attributes")] 
    [SerializeField] private Material[] materials;
    void Update()
    {
        for (int i = 0; i < materials.Length; i++)
        {
            materials[i].SetVector("_PlayerPosition",transform.position);
        }
    }
}

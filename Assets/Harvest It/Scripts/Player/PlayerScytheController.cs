using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerScytheController : MonoBehaviour
{
    public static PlayerScytheController instance;
    public ScytheData[] allScytheDatas;
    public ScytheData currentScythe;
    public GameObject scythePrefab;
    private void Awake()
    {
        if (instance != null)
            return;
        else
            instance = this;
    }

    private void Start()
    {
        LoadScythe();
    }

    private void OnDestroy()
    {
        SaveScythe();
    }

    public void SaveScythe()
    {
        PlayerPrefs.SetInt("CurrentScythe",GetIndexOfScythe(currentScythe));
    }
    public void LoadScythe()
    {
        currentScythe = allScytheDatas[PlayerPrefs.GetInt("CurrentScythe",0)];
        ChangeMaterial();
    }

    public void ChangeMaterial()
    {
        scythePrefab.GetComponent<Renderer>().materials[0].color = currentScythe.stickMaterialColor;
        scythePrefab.GetComponent<Renderer>().materials[1].color = currentScythe.bladeMaterialColor;

    }
    
    public int GetIndexOfScythe(ScytheData scytheData)
    {
        for (int i = 0; i < allScytheDatas.Length; i++)
        {
            if (allScytheDatas[i] == scytheData)
            {
                return i;
            }
        }

        return -1;
    }
}

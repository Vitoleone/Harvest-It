using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class PlayerScytheController : MonoBehaviour
{
    public static PlayerScytheController instance;
    public ScytheData[] allScytheDatas;
    public ScytheData currentScythe;
    public GameObject scythePrefab;
    [Header("UI Actions")] 
    public UnityAction<ScytheItemSectionDataHolder> onBuyedScythe;
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

    public void ChangeCurrentScythe(ScytheData data)
    {
        currentScythe = data;
        ChangeMaterial();
    }

    public void ChangeMaterial()
    {
        scythePrefab.GetComponent<Renderer>().materials[0].color = currentScythe.stickMaterialColor;
        scythePrefab.GetComponent<Renderer>().materials[1].color = currentScythe.bladeMaterialColor;
        Debug.Log("Değiştirildi");

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

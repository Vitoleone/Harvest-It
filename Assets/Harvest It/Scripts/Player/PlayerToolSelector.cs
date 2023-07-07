using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerToolSelector : MonoBehaviour
{
    public enum Tool { None, Seeding, Watering, Harvesting }
    private Tool activeTool;

    [Header("Attributes")]
    [SerializeField] private Image[] toolImages;
    [Header("Settings")] 
    [SerializeField] private Color selectedToolColor;
    [Header("Actions")] 
    public Action<Tool> onToolSelected;  

    private void Start()
    {
        SelectTool(0);
    }

    public void SelectTool(int toolIndex)
    {
        activeTool = (Tool)toolIndex;
        for (int i = 0; i < toolImages.Length; i++)
        {
            if (i == toolIndex)
                toolImages[i].color = selectedToolColor;
            else
                toolImages[i].color = Color.white;
        }
        onToolSelected?.Invoke(activeTool);
    }

    public bool CanSeed()
    {
        return activeTool == Tool.Seeding;
    }
    public bool CanWater()
    {
        return activeTool == Tool.Watering;
    }
    public bool CanHarvest()
    {
        return activeTool == Tool.Harvesting;
    }
}

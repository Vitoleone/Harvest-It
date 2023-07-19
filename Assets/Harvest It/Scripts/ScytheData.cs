using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptables/ScytheData", fileName = "ScytheData")]
public class ScytheData : ScriptableObject
{
    [Header("Settings")] 
    public string name;
    public int price;
    public int damage;
    public Color stickMaterialColor;
    public Color bladeMaterialColor;
    
}

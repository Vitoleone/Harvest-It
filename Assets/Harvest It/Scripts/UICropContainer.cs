using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UICropContainer : MonoBehaviour
{

    [Header("Attributes")] 
    [SerializeField] private Image cropIcon;
    [SerializeField] private TextMeshProUGUI amount;

    public void Configure(Sprite cropIcon, int amount)
    {
        this.cropIcon.sprite = cropIcon;
        this.amount.text = amount.ToString();
    }

    public void UpdateAmount(int amount)
    {
        this.amount.text = amount.ToString();
    }
}

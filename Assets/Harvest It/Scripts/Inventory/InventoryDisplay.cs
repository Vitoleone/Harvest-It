using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryDisplay : MonoBehaviour
{
    [Header("Attributes")] 
    [SerializeField] private UICropContainer uiCropContainerPrefab;
    [SerializeField] private Transform cropContainerParent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Configure(Inventory inventory)
    {
        InventoryItem[] items = inventory.GetInventoryItems();
        for (int i = 0; i < items.Length; i++)
        {
            Sprite cropIcon = DataManager.instance.GetSpriteFromCropType(items[i].cropType);
            int cropAmount = items[i].amount; 
            UICropContainer cropContainer = Instantiate(uiCropContainerPrefab,cropContainerParent);
            
            cropContainer.Configure(cropIcon,cropAmount);
        }
    }

    public void UpdateDisplay(Inventory inventory)
    {
        InventoryItem[] items = inventory.GetInventoryItems();
        UICropContainer containerInstance;
            
        for (int i = 0; i < items.Length; i++)
        {
            if (i < cropContainerParent.childCount)
            {
                containerInstance = cropContainerParent.GetChild(i).GetComponent<UICropContainer>();
                containerInstance.gameObject.SetActive(true);
            }
            else
            {
                containerInstance = Instantiate(uiCropContainerPrefab,cropContainerParent);
            }
            Sprite cropIcon = DataManager.instance.GetSpriteFromCropType(items[i].cropType);
            int cropAmount = items[i].amount;
            containerInstance.Configure(cropIcon,cropAmount);
        }
        int remainingContainers = cropContainerParent.childCount - items.Length;
        if(remainingContainers <= 0)
            return;
        for (int i = 0; i < remainingContainers; i++)
        {
            cropContainerParent.GetChild(items.Length + i).gameObject.SetActive(false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CropSystem : MonoBehaviour
{
    // Start is called before the first frame update
    private Dictionary<InventoryItemData, InventoryItem> m_cropDictionary;
    public List<InventoryItem> crops {get; private set;}
    public static CropSystem currentCrops;
    public delegate void CropInventory();
    public event CropInventory onPlantCropsEvent;
    public event CropInventory onHarvestCropsEvent;

    public event CropInventory PlantGrowthEvent;
    public void Awake(){
        currentCrops = this;
    } 

    void Update(){
        if(Input.GetKeyDown(KeyCode.G)){
            PlantGrowthEvent?.Invoke();
        }
    }

}

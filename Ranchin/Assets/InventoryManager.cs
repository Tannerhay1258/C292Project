using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private GameObject m_slotPrefab;
    // Start is called before the first frame update
    void Start()
    {
        InventorySystem.current.onInventoryChangedEvent += OnUpdateInventory;
    }

    private void OnUpdateInventory(){
        foreach(Transform t in transform){
            Destroy(t.gameObject);
        }
        DrawInventory();
    }
    public void DrawInventory(){
        foreach(InventoryItem item in InventorySystem.current.inventory){
            AddInventorySlot(item);
        }
    }

    public void AddInventorySlot(InventoryItem item){
        GameObject obj = Instantiate(m_slotPrefab);
        obj.transform.SetParent(transform);

        Slot sl = obj.GetComponent<Slot>();
        sl.set(item);
    }
}

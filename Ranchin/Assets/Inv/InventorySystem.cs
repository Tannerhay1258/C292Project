using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
public class InventorySystem : MonoBehaviour
{
    private Dictionary<InventoryItemData, InventoryItem> m_itemDictionary;
    public List<InventoryItem> inventory {get; private set;}

    public int index;
    public static InventorySystem current;
    public delegate void Inventory();
    public event Inventory onInventoryChangedEvent;
    public void Awake(){
        current = this;
        inventory = new List<InventoryItem>();
        m_itemDictionary = new Dictionary<InventoryItemData, InventoryItem>();
        index = 0; 
    }

    public InventoryItem Get(InventoryItemData refrenceData){
        if (m_itemDictionary.TryGetValue(refrenceData, out InventoryItem value)){
            return value;
        }
        return null;
    }

    public void Add(InventoryItemData refrenceData){
        if(m_itemDictionary.TryGetValue(refrenceData, out InventoryItem value)){
            value.AddToStack();
        } else {
            InventoryItem newItem = new InventoryItem(refrenceData);
            inventory.Add(newItem);
            m_itemDictionary.Add(refrenceData, newItem);
            this.increaseIndex();
        }
        onInventoryChangedEvent?.Invoke();
    }

    public void Remove(InventoryItemData refrenceData){
        if(m_itemDictionary.TryGetValue(refrenceData, out InventoryItem value)){
            value.RemoveFromStack();
            if(value.stackSize == 0){
                inventory.Remove(value);
                m_itemDictionary.Remove(refrenceData);
                this.decreaseIndex();
            }
        }
        onInventoryChangedEvent?.Invoke();
    }

    public InventoryItem getIndex(){
        if (inventory.Count == 0 ){
            return null;
        }
        return inventory[index];
    }
    public void increaseIndex(){
        index = (index + 1) % inventory.Count;
        onInventoryChangedEvent?.Invoke();
    }

    public void decreaseIndex(){
        if (index == 0){
            index = inventory.Count-1;
        } else {
            index -= 1;
        }
        onInventoryChangedEvent?.Invoke();
    }
}


public class InventoryItem{
    public InventoryItemData data {get; private set;}
    public int stackSize {get; private set; }
    public InventoryItem(InventoryItemData source){
        data = source;
        AddToStack();
    }
    
    public void AddToStack(){
        stackSize++;
    }
    public void RemoveFromStack(){
        stackSize--;
    }
}
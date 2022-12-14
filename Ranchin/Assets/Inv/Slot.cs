using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Slot : MonoBehaviour
{
    [SerializeField] private Image m_icon;
    [SerializeField] private TextMeshProUGUI m_label;
    [SerializeField] private GameObject m_stackObj;
    [SerializeField] private TextMeshProUGUI m_stackLabel;
    [SerializeField] private Image m_selected;




    public void set(InventoryItem item){
        m_icon.sprite = item.data.icon;
        m_label.text = item.data.displayName;
        if (item.stackSize <= 1){
            m_stackObj.SetActive(false);
        }
        m_stackLabel.text = item.stackSize.ToString();
        m_selected.gameObject.SetActive(false);
    }
    
    public void setHilighted(InventoryItem item){
        m_icon.sprite = item.data.icon;
        m_label.text = item.data.displayName;
        if (item.stackSize <= 1){
            m_stackObj.SetActive(false);
        }

        m_stackLabel.text = item.stackSize.ToString();
    }
}

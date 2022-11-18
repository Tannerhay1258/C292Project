using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class BuyThisItem : MonoBehaviour
{
    [SerializeField] InventoryItemData seedBag;

	public Button yourButton;

	void Start () {
		Button btn = yourButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick(){
        tryBuy();
	}

    void tryBuy(){
            int money = GameState.Instance.getMoney();
            if(money >= seedBag.value){
                GameState.Instance.decreaseMoney(seedBag.value);
                InventorySystem.current.Add(seedBag);
                AudioManager.current.playSell();
            }
    }
}
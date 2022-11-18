using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowShopSell : MonoBehaviour
{
    // Start is called before the first frame update
   // Start is called before the first frame update
    [SerializeField] GameObject shop;
    private bool inshop = false;

    void Update(){
        if(inshop){
            if(Input.GetKeyDown(KeyCode.E)){
                InventoryItem inhand = InventorySystem.current.getIndex();
                if(inhand.data.value > 0){
                    GameState.Instance.IncreaseMoney(inhand.data.value);
                    InventorySystem.current.Remove(inhand.data);
                    AudioManager.current.playSell();
                }
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        shop.SetActive(false);
        inshop = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        shop.SetActive(true);
        inshop = true;
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameState : MonoBehaviour
{
    int _money = 20;
    [SerializeField] TextMeshProUGUI _moneyText;
    public static GameState Instance;
    void Awake() {
        Instance = this;
    }
    // Start is called before the first frame updat
    public void IncreaseMoney(int amount){
        _money += amount;
        _moneyText.text = "" + _money;
    }

    public void decreaseMoney(int amount){
        _money -= amount;
        _moneyText.text = "" + _money;
    }

    public int getMoney(){
        return _money;
    }
}

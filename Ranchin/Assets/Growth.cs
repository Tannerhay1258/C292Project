using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Growth : MonoBehaviour
{
    [SerializeField] Sprite stageSeed;
    [SerializeField] Sprite stage1;
    [SerializeField] Sprite stage2;
    [SerializeField] Sprite stage3;
    [SerializeField] Sprite stage4;
    int stage = 0;
    [SerializeField] GameObject produce;
    private SpriteRenderer spriteR;

    void Start(){
        spriteR = gameObject.GetComponent<SpriteRenderer>();
        CropSystem.currentCrops.PlantGrowthEvent += Grow;
    }

    private void Grow(){
        stage += 1;
        if (stage == 1){
            spriteR.sprite = stage1;
        } else if (stage == 2){
            spriteR.sprite = stage2;
        } else if (stage == 3) {
            spriteR.sprite = stage3;
        } else if (stage == 4){
            spriteR.sprite = stage4;
        }
    }
    public bool harvest(){
        if (stage >= 4){
            Instantiate(produce, transform.position, transform.rotation);
            Destroy(this.gameObject);
            return true;
        }
        return false;
    }
}

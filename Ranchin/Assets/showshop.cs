using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showshop : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject shop;

    void OnTriggerExit2D(Collider2D other)
    {
        shop.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        shop.SetActive(true);
    }
}

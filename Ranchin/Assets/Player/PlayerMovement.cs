using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;

    public Animator animator;

    Vector2 movement;

    public Tilemap farmland;
    public Tilemap plants;
    public TileBase tilledDirt;
    public TileBase dirt;
    public TileBase seed;

    // Update is called once per frame
    void Update()
    {
        // Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);


        Vector3Int farmlandMapTile = farmland.WorldToCell(transform.position);
        // Debug.Log(farmland.GetTile(farmlandMapTile));
        TileBase tile = farmland.GetTile(farmlandMapTile);
        if(tile){
            if (tile.name == "dirt" && Input.GetKeyDown(KeyCode.E)){
                farmland.SetTile(farmlandMapTile, tilledDirt);
                Debug.Log(farmland.GetTile(farmlandMapTile));
            }
            if (tile.name == "dirtplowed" && Input.GetKeyDown(KeyCode.P)){
                plants.SetTile(farmlandMapTile, seed);
            }
        }
    }
    void FixedUpdate(){
        // Movement
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}

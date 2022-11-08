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

    public Tilemap highlightMap;
    public Tile highlight;
    public TileBase tilledDirt;
    public TileBase dirt;
    public TileBase seed;
    public GameObject seeds;
    private Vector3Int lastPostion;
    private bool canHarvest;

    void Start(){
        lastPostion = new Vector3Int(0,0);
        canHarvest = true;
    }
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
        highlightMap.SetTile(lastPostion, null);
        highlightMap.SetTile(farmlandMapTile, highlight);
        if(tile){
            if (tile.name == "dirt" && Input.GetKeyDown(KeyCode.E)){
                farmland.SetTile(farmlandMapTile, tilledDirt);
                Debug.Log(farmland.GetTile(farmlandMapTile));
            }
            if (tile.name == "dirtplowed" && Input.GetKeyDown(KeyCode.P)){
                if (plants.GetTile(farmlandMapTile) == null){
                    //plants.SetTile(farmlandMapTile, seed)
                    plants.SetTile(farmlandMapTile, tilledDirt);
                    Instantiate(seeds, farmlandMapTile + new Vector3(.5f,.5f,0), transform.rotation);
                }
            }
        }
        lastPostion = farmlandMapTile;
        if(Input.GetKeyDown(KeyCode.E)){
            canHarvest = true;
            rb.WakeUp();
        }
    }
    void FixedUpdate(){
        // Movement
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.name.Contains("Produce")){
            col.gameObject.GetComponent<ItemObject>().OnHandlePickupItem();
        }
    }
    void OnTriggerStay2D(Collider2D col){
        if (col.gameObject.name.Contains("Crop")){
            if(!canHarvest){
                return;
            }
            if(col.GetComponent<Growth>().harvest()){
                Vector3Int tilePos = farmland.WorldToCell(col.gameObject.transform.position);

                farmland.SetTile(tilePos, dirt);

                plants.SetTile(tilePos, null);
            }
            canHarvest = false;
        }
    }
}


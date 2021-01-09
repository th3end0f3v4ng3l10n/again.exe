using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shopTrig : MonoBehaviour
{
    public Sprite sprite;
    GameObject shop_near;


    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("GameObject2 collided with " + col.name);

        if (col.gameObject.tag == "Player")
        {
            Vector2 size = new Vector2(1, 1);
            Vector2 position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + 0.2f);
            shop_near = new GameObject("shop near");
            shop_near.transform.position = position;
            shop_near.transform.localScale = size;
            SpriteRenderer renderer = shop_near.AddComponent<SpriteRenderer>();
            renderer.sprite = sprite;
        }        
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        Destroy(shop_near); 
    }
}

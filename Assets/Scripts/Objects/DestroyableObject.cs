using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableObject : MonoBehaviour {

    public GameObject coin;
    public int spriteNumber = 0;
    public Sprite[] ObjectSprite;
    public Vector2 lowestHighestCoinamount;

    SpriteRenderer spriteRenderer;

    int coinDropAmount;

    private void OnValidate()
    {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        coinDropAmount = (int)Random.Range(lowestHighestCoinamount.x, lowestHighestCoinamount.y);
    }

    public void SpriteUpdate()
    {
        spriteNumber++;
        if (spriteNumber >= ObjectSprite.Length)
        {
            RemoveObject();
            DestroyAndInstatiate();
            return;
        }
        spriteRenderer.sprite = ObjectSprite[spriteNumber];
    }

    void RemoveObject()
    {
        spriteRenderer.enabled = false;
        this.gameObject.GetComponent<Collider2D>().enabled = false;
    }

    void DestroyAndInstatiate()
    {
        Destroy(this.gameObject, 2);
        for (int i = 0; i < coinDropAmount; i++)
        {
            Instantiate(coin, this.transform.position, Quaternion.identity);
        }
    }
}

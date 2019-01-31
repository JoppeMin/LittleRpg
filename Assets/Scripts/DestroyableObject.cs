using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableObject : MonoBehaviour {

    public float rarityValue;
    public GameObject coin;
    public int spriteNumber = 0;
    public Sprite[] ObjectSprite;

    int coinDropAmount;

    private void Start()
    {
        coinDropAmount = Random.Range(0, 4);
    }
    void Update () {
        SpriteUpdate();
    }

    void SpriteUpdate()
    {
        if (spriteNumber >= ObjectSprite.Length)
        {
            
            Destroy(this.gameObject, rarityValue); 
            for (int i = 0; i < coinDropAmount; i++)
            {
                Instantiate(coin, this.transform.position, Quaternion.identity);
            }
        }
        this.GetComponent<SpriteRenderer>().sprite = ObjectSprite[spriteNumber];
    }
}

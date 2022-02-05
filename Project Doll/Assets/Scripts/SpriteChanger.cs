using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteChanger : MonoBehaviour
{
    // Start is called before the first frame update
    SpriteRenderer spriteRenderer;
    [SerializeField] Sprite newSprite;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void ChangeSprite()
    {
        spriteRenderer.sprite = newSprite;
    }
}

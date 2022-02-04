using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSprite : MonoBehaviour {
    public void ChangeSpriteTo(Sprite sprite) {
        GetComponent<SpriteRenderer>().sprite = sprite;
    }
}

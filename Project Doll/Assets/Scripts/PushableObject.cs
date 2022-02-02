using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushableObject : MonoBehaviour
{
    Player player;
    float playerMovespeed;
    Vector3 delta;
    bool moving;

    // Start is called before the first frame update
    private void Start()
    {
        player = FindObjectOfType<Player>();
        playerMovespeed = player.GetPlayerMovespeed();
    }

    private void Update()
    {
        MoveObject();
    }

    public void MoveObject()
    {
        if (moving)
        {
            Debug.Log("moving");
            transform.position = new Vector2(player.transform.position.x + delta.x, player.transform.position.y + delta.y);
            Debug.Log(transform.position);
        }
    }

    public void ToggleMove()
    {
        moving = !moving;
        delta = transform.position - player.transform.position;
        Physics2D.IgnoreCollision(player.GetComponent<BoxCollider2D>(), GetComponent<BoxCollider2D>(), moving);
    }
}

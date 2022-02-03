using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushableObject : Interactables
{
    [SerializeField] float distanceFromPlayer = 0.1f;

    Player player;
    float playerMovespeed;
    Vector3 delta;
    bool moving;
    float deltaX;
    float deltaY;
    RaycastHit2D hit;
    BoxCollider2D boxCollider;

    // Start is called before the first frame update
    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        player = FindObjectOfType<Player>();
        playerMovespeed = player.GetPlayerMovespeed();
    }

    private void FixedUpdate()
    {
        MoveObject();
    }

    public void MoveObject()
    {
        if (moving)
        {
            /*
            Debug.Log("moving");
            transform.position = new Vector2(player.transform.position.x + delta.x, player.transform.position.y + delta.y);
            Debug.Log(transform.position);*/

            
            deltaY = Input.GetAxisRaw("Vertical") * Time.deltaTime * playerMovespeed;
            deltaX = Input.GetAxisRaw("Horizontal") * Time.deltaTime * playerMovespeed;
            Debug.Log(Mathf.Sign(deltaY));
            Debug.Log(deltaX);

            // y axis
            hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, deltaY), boxCollider.size.y + Mathf.Abs(deltaY), LayerMask.GetMask("BlockFOV"));
            //player.SetPushableObject(hit.collider);
            if (hit.collider == null)
            {
                // Move 
                transform.position = new Vector2(player.transform.position.x + delta.x, player.transform.position.y + delta.y);
            }
            else
            Debug.Log(hit.collider);
            
            
            // x axis
            hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(deltaX, 0), boxCollider.size.x + Mathf.Abs(deltaX), LayerMask.GetMask("BlockFOV"));
            //player.SetPushableObject(hit.collider);
            if (hit.collider == null)
            {
                // Move
                transform.position = new Vector2(player.transform.position.x + delta.x, player.transform.position.y + delta.y);
            }
            else
            Debug.Log(hit.collider);
        }
    }

    public void ToggleMove()
    {
        moving = !moving;
        player.ToggleIsCarrying();
        player.SetPushableObject(GetComponent<PushableObject>());
        delta = transform.position - player.transform.position;
        delta = new Vector3(delta.x, delta.y, delta.z);
        Physics2D.IgnoreCollision(player.GetComponent<BoxCollider2D>(), GetComponent<BoxCollider2D>(), moving);
    }

    public Collider2D GetPushableObjectColliderX()
    {
        deltaX = Input.GetAxisRaw("Horizontal") * Time.deltaTime * playerMovespeed;
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(deltaX, 0), boxCollider.size.x + Mathf.Abs(deltaX), LayerMask.GetMask("BlockFOV"));
        return hit.collider;
    }

    public Collider2D GetPushableObjectColliderY()
    {
        deltaY = Input.GetAxisRaw("Vertical") * Time.deltaTime * playerMovespeed;
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, deltaY), boxCollider.size.y + Mathf.Abs(deltaY), LayerMask.GetMask("BlockFOV"));
        return hit.collider;
    }
}

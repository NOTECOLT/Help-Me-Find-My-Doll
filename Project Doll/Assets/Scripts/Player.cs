using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Config params
    [SerializeField] float playerMovespeed = 100f;
    [SerializeField] float interactDistance = 10f;
    [SerializeField] string[] layerMaskInteractables;
    [SerializeField] bool isCarrying; // for debug
    // Cached references
    FOV fov;
    BoxCollider2D boxCollider;

    // Variables
    float[] directionFacing;
    RaycastHit2D raycastHitInteractables;
    RaycastHit2D hit;
    float deltaX;
    float deltaY;
    Collider2D carriedObjectRaycastHit;


    PushableObject carriedObjectCollider;
    Collider2D pushableObjectHit;

    // Start is called before the first frame update
    void Start()
    {
        fov = FindObjectOfType<FOV>();
        directionFacing = new float[2];
        fov.SetDirection(Vector3.right);
        boxCollider = GetComponent<BoxCollider2D>();
        isCarrying = false;
    }

    // Update is called once per frame
    private void Update()
    {
        FindInteractables();
    }


    void FixedUpdate()
    {
        if (!PuzzleInterfaceManager.Instance.hasActiveInterface) // Prevent player from moving when there is an active puzzle
            Move();
        SetPlayerFOV(deltaX, deltaY);
    }

    private void Move()
    {
        deltaX = Input.GetAxisRaw("Horizontal") * Time.deltaTime * playerMovespeed;
        deltaY = Input.GetAxisRaw("Vertical") * Time.deltaTime * playerMovespeed;

        if (!isCarrying)
        {
            // y axis
            hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, deltaY), Mathf.Abs(deltaY), LayerMask.GetMask("BlockFOV", "Interactables"));
            if (hit.collider == null)
            {
                // Move 
                transform.position = new Vector2(transform.position.x, transform.position.y + deltaY);
            }
            
            // x axis
            hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(deltaX, 0), Mathf.Abs(deltaX), LayerMask.GetMask("BlockFOV", "Interactables"));
            if (hit.collider == null)
            {
                // Move
                transform.position = new Vector2(transform.position.x + deltaX, transform.position.y);
            }
        }

        if (isCarrying)
        {
            // y axis
            hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, deltaY), Mathf.Abs(deltaY), LayerMask.GetMask("BlockFOV"));
            pushableObjectHit = carriedObjectCollider.GetPushableObjectColliderY();
            if (hit.collider == null && pushableObjectHit == null)
            {
                // Move 
                transform.position = new Vector2(transform.position.x, transform.position.y + deltaY);
            }

            // x axis
            hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(deltaX, 0), Mathf.Abs(deltaX), LayerMask.GetMask("BlockFOV"));
            pushableObjectHit = carriedObjectCollider.GetPushableObjectColliderX();
            if (hit.collider == null && pushableObjectHit == null)
            {
                // Move
                transform.position = new Vector2(transform.position.x + deltaX, transform.position.y);
            }
        }


        /*
        // Moves player
        deltaX = Input.GetAxisRaw("Horizontal") * Time.deltaTime * playerMovespeed;
        deltaY = Input.GetAxisRaw("Vertical") * Time.deltaTime * playerMovespeed;

        transform.position = new Vector2(transform.position.x + deltaX, transform.position.y + deltaY);
        */
    }

    private Vector2 GetPlayerDirection()
    {
        // Get player direction based on movement input
        // Turns movement input into vector and uses that vector to get angle
        // Returns direction vector to be used in raycast in FindInteractables()

        if (!isCarrying)
        {
            if (Input.GetAxisRaw("Vertical") != 0)
            {
                directionFacing[1] = Input.GetAxisRaw("Vertical");
                directionFacing[0] = 0;
            }
            if (Input.GetAxisRaw("Horizontal") != 0)
            {
                directionFacing[0] = Input.GetAxisRaw("Horizontal");
                directionFacing[1] = 0;
            }
        }
        
        
        
        
        Vector2 directionVector = new Vector2(directionFacing[0], directionFacing[1]);
        // Debug.Log(GetAngleFromVector(directionVector));
        return directionVector;
        //Debug.Log(directionFacing[0]);
    }
    public float GetPlayerMovespeed()
    {
        return playerMovespeed;
    }
    private void FindInteractables() {
        // Uses raycast2D to check if there are interactables that can be interacted with
        Debug.DrawRay(transform.position, GetPlayerDirection(), Color.white, 0.01f);

        raycastHitInteractables = Physics2D.BoxCast(transform.position, boxCollider.size, 0, GetPlayerDirection(), interactDistance, LayerMask.GetMask(layerMaskInteractables));
        //raycastHitInteractables = Physics2D.Raycast(transform.position, GetPlayerDirection(), interactDistance, layerMaskInteractables);

         if (raycastHitInteractables)
        {
            raycastHitInteractables.collider.SendMessage("OnAction");
            carriedObjectRaycastHit = raycastHitInteractables.collider;
        }
    }

    private void SetPlayerFOV(float deltaX, float deltaY)
    {
        // Moves FOV cone and direction based on player's movement
        fov.SetOrigin(transform.position);
        if (!(Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0))
        {
            if (!isCarrying)
            {
                fov.SetDirection(new Vector3(-directionFacing[1], directionFacing[0]));
            }
            
        }
    }

    public static float GetAngleFromVector(Vector2 vector)
    {
        // Calculates for angle in degrees from input vector
        float angle = Mathf.Atan2(vector.y, vector.x) * Mathf.Rad2Deg;
        return Mathf.RoundToInt(angle);
    }

    public void ToggleIsCarrying()
    {
        isCarrying = !isCarrying;
    }

    public void SetPushableObject(PushableObject objectBeingMoved)
    {
        this.carriedObjectCollider = objectBeingMoved;
    }

    public void SetPushableCollider(Collider2D pushCollider)
    {

    }
}

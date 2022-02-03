using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingTextFollow : MonoBehaviour
{
    GameObject target;
    [SerializeField] float offset = 2;
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            transform.position = new Vector3(target.transform.position.x, target.transform.position.y + offset, target.transform.position.z);
        }
    }

    public void SetToFollow(GameObject target)
    {
        this.target = target;
    }

    public void SetOffset(float offset)
    {
        this.offset = offset;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create FOVProfile")]
public class FOVProfiles : ScriptableObject
{
    // Configuration parameters
    [Header("FOV settings")]
    [SerializeField] float fov = 90f;
    [SerializeField] float viewDistance = 10f;

    // Start is called before the first frame update
    public float GetFOV()
    {
        return fov;
    }

    public float GetViewDistance()
    {
        return viewDistance;
    }
}

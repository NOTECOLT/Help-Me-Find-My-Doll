using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOV : MonoBehaviour
{
    // Config params
    [SerializeField] private LayerMask layerMask;

    [Header("FOV Settings")]
    [SerializeField] float fov = 130f;
    [SerializeField] int rayCount = 2;
    [SerializeField] float viewDistance = 10f;

    // Variables
    Vector3 origin;
    float angleIncrease;
    float angle;
    float viewAngleSetting;
    // Cached references
    Mesh mesh;

    // Start is called before the first frame update
    void Start()
    {  
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        
        viewAngleSetting = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        CreateFOV();
    }

    private void CreateFOV()
    {
        Vector3[] vertices = new Vector3[rayCount + 1 + 1];
        Vector2[] uv = new Vector2[vertices.Length];
        int[] triangles = new int[rayCount * 3];

        angleIncrease = fov / rayCount;
        vertices[0] = origin;
        angle = viewAngleSetting;
        int vertexIndex = 1;
        int triangleIndex = 0;
        for (int i = 0; i <= rayCount; i++)
        {
            Vector3 vertex;
            RaycastHit2D raycastHit2D = Physics2D.Raycast(origin, GetVectorFromAngle(angle), viewDistance, layerMask);

            if (raycastHit2D.collider == null)
            {
                vertex = origin + GetVectorFromAngle(angle) * viewDistance;
            }
            else
            {
                vertex = raycastHit2D.point;
            }
            vertices[vertexIndex] = vertex;

            if (i > 0)
            {
                triangles[triangleIndex + 0] = 0;
                triangles[triangleIndex + 1] = vertexIndex - 1;
                triangles[triangleIndex + 2] = vertexIndex;

                triangleIndex += 3;
            }

            vertexIndex++;
            angle -= angleIncrease;
        }


        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;
        mesh.bounds = new Bounds(origin, Vector3.one * 1000f); ;
    }

    public void SetOrigin(Vector3 origin)
    {
        this.origin = origin;
    }

    public void SetDirection(Vector3 aimDirection)
    {
        // viewAngleSetting = GetAngleFromVector(aimDirection) - 20; //- (fov/2f);
        viewAngleSetting = GetAngleFromVector(aimDirection) - ((180f-fov)/2f);
    }

    public static Vector3 GetVectorFromAngle(float angle)
    {
        float angleRad = angle * (Mathf.PI / 180f);
        return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
    }

    public static float GetAngleFromVector(Vector3 vector)
    {
        vector = vector.normalized;
        float angle = Mathf.Atan2(vector.y, vector.x) * Mathf.Rad2Deg;
        if(angle < 0)
        {
            angle += 360;
        }
        return Mathf.RoundToInt(angle);
    }

    public void SetFOVSettings(float fov, float viewDistance)
    {
        viewAngleSetting = viewAngleSetting - (this.fov - fov) / 2;
        this.fov = fov;
        this.viewDistance = viewDistance;
        angleIncrease = this.fov / rayCount; 
    }
}

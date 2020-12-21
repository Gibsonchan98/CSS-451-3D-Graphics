using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class CylinderMesh : MonoBehaviour
{
    public int N; //width 
    public int M; //height
    public int[] t;
    private bool manipulated;

    private float theta;
    private float delta;
    private int vertices; 
    private int triangles; 

    private float height;
    private float radius;
    private Vector3[] radiusA;
    private float rotation;

    private Vector3[] v;
    private Vector3[] n;
    private Mesh theMesh;


    // Start is called before the first frame update
    void Start()
    {
        N = 8; M = 8;
        vertices = (N + 1) * (M + 1);
        triangles = N * M * 2;

        v = new Vector3[vertices];   // 2x2 mesh needs 3x3 vertices
        t = new int[triangles * 3];         // Number of triangles: 2x2 mesh and 2x triangles on each mesh-unit
        n = new Vector3[vertices];   // MUST be the same as number of vertices 
        radiusA = new Vector3[M];

        radius = 1;
        height = 8;
        rotation = 180;
        manipulated = false;

        if (!manipulated)
            setRadius();

        Reset();
        computeMesh(rotation, radius, height / 2);
    }
    void computeMesh(float rot, float r, float h)
    {
        theMesh = GetComponent<MeshFilter>().mesh;   // get the mesh component
        theMesh.Clear();    // delete whatever is there!!

        vertices = (N + 1) * (M + 1);
        triangles = N * M * 2;

        v = new Vector3[vertices];   // 2x2 mesh needs 3x3 vertices
        t = new int[triangles * 3];         // Number of triangles: 2x2 mesh and 2x triangles on each mesh-unit
        n = new Vector3[vertices];   // MUST be the same as number of vertices

        if (!manipulated)
            setRadius();

        delta = rot / N;

        for (int i = 0; i <= M; i++){
            for (int j = 0; j <= N; j++){
                int index = j + (i * (N + 1));
                v[index] = new Vector3(radiusA[i].x * Mathf.Cos(toRad(theta)), radiusA[i].y, radiusA[i].z * Mathf.Sin(toRad(theta)));
                n[index] = new Vector3(0, 1, 0);
                theta += delta;
            }
            theta = 0;
        }

        //set up triangles
        for (int i = 0, k = 0; i < M; i++) {
            for (int j = 0; j < N; j++){
                int t1, t2, t3, t4, t5, t6;  //go per square
                t1 = i * (N + 1) + j;
                t2 = j + ((i + 1) * (N + 1));
                t3 = t2 + 1;

                t4 = t1;
                t5 = t3;
                t6 = t4 + 1;

                t[k++] = t1;
                t[k++] = t2;
                t[k++] = t3;

                t[k++] = t4;
                t[k++] = t5;
                t[k++] = t6;
            }
        }

        theMesh.vertices = v; //  new Vector3[3];
        theMesh.triangles = t; //  new int[3];
        theMesh.normals = n;

        InitControllers(v);
        InitNormals(v, n);
    }

    void setRadius()
    {
        if (radiusA.Length != M + 1)
            radiusA = new Vector3[M + 1];
        float h = height / 2;
        float rowH = height / M;
        for (int i = 0; i < radiusA.Length; i++)
        {
            radiusA[i] = new Vector3(radius, h, radius);
            h -= rowH;
        }
    }

    public void LayerManipulation(Vector3 newPos, int index)
    {
        theta = delta;
        //manipulate this layer only
        for (int j = index + 1; j <= index + N; j++)
        {
            mControllers[j].transform.localPosition = new Vector3(newPos.x * Mathf.Cos(toRad(theta)), newPos.y, newPos.x * Mathf.Sin(toRad(theta)));
            theta += delta;
        }

        radiusA[index / (N + 1)] = new Vector3(newPos.x, newPos.y, newPos.x);
    }


    // Update is called once per frame
    void Update()
    {
        Mesh theMesh = GetComponent<MeshFilter>().mesh;
        Vector3[] v = theMesh.vertices;
        Vector3[] n = theMesh.normals;
        for (int i = 0; i < mControllers.Length; i++)
        {
            v[i] = mControllers[i].transform.localPosition;
        }

        ComputeNormals(v, n);

        theMesh.vertices = v;
        theMesh.normals = n;

    }
    float toRad(float deg)
    {
        return deg * Mathf.PI / 180.0f;
    }

    public void ResetMesh()
    {
        Reset();
        computeMesh(rotation, radius, height / 2);
    }

    public void setRotation(float val)
    {
        rotation = val;
        Reset();
        computeMesh(rotation, radius, height / 2);
    }

    public void AlterM(int val)
    {
        if (M != val) {
            M = val;
        }
        Reset();
        manipulated = false;
        computeMesh(rotation, radius, height / 2);
    }

    public void AlterN(int val) {
        if (N != val) {
            N = val;
        }           
        Reset();
        computeMesh(rotation, radius, height / 2);
    }

    public void ResolutionChange(int val) {
        if (N != val) {
            N = val; 
        }
        if (M != val) {
            M = val;
        }
        Reset();
        computeMesh(rotation, radius, height / 2);
    }

    public void Elongate(int val) {
        height = val;
        M = (int)height * 2;
        Reset();
        manipulated = false;
        computeMesh(rotation, radius, height / 2);
    }

    private void Reset()
    {
        foreach (Transform child in gameObject.transform)
        {
            DestroyObject(child.gameObject);
        }
    }

    public void setMani(bool state) {
        manipulated = state;
    }
}

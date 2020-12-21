using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** ======================== PLANE CLASS ======================== **\
 * The purpose of this class is to handle the triangle shard thingies
 * Sorry, I forgot what they're called, but it's the TRIANGLES. 
 */
public class Plane : MonoBehaviour
{

    Mesh meshFilterRef = null;
    int row = 1;  // Number of row cubes
    int col = 1;  // Number of column cubes

    GameObject[] mControllers;  // The sphere controllers on the object
    GameObject[] mLines;        // The cylinders

    float xLen = 2f;    // Global Dimensions of the plane when you 
                        // reset all the values
    float zLen = 2f;   // Global Dimension of the plane when you
                        // reset all the values

    bool showVertices = false;

    // TRS Image Transform
    //      The following variables are for manipulating the image transform.
    float defaultXLen = 1f;
    float defaultYLen = 1f;
    Matrix3x3 uvTransform;
    Vector2[] originalUVVals;

    /** 
     *  The purpose of this function is to initialize the triangles into
     *  their proper positions.
     *  
     */
    void Start()
    {
        uvTransform = Matrix3x3.identity;
        meshFilterRef = GetComponent<MeshFilter>().mesh;
        Vector3[] v = new Vector3[4];   // Vertices
        Vector3[] n = new Vector3[4];   // IDK what dis is
        int[] t = new int[6];           // Coordinates of all points
        Vector2[] uv = new Vector2[4];
        originalUVVals = uv;

        v[0] = new Vector3(-1, 0, -1);
        v[1] = new Vector3(1, 0, -1);
        v[2] = new Vector3(-1,0,1);
        v[3] = new Vector3(1, 0, 1);

        t[0] = 0;
        t[1] = 2;
        t[2] = 3;

        t[3] = 0;
        t[4] = 3;
        t[5] = 1;

        n[0] = new Vector3(0, 1, 0);
        n[1] = new Vector3(0, 1, 0);
        n[2] = new Vector3(0, 1, 0);
        n[3] = new Vector3(0, 1, 0);

        uv[0] = new Vector2(0f, 0f);
        uv[1] = new Vector2(0f, 1f);
        uv[2] = new Vector2(1f, 0f);
        uv[3] = new Vector2(1f, 1f);


        meshFilterRef.vertices = v;
        meshFilterRef.triangles = t;
        meshFilterRef.normals = n;
        meshFilterRef.uv = uv;
        originalUVVals = uv;

        InitializeControllers(v);
        updateVertices();
    }

    /**
     *  The purpose of this function is to initialize the spheres that
     *  control the mesh.
     *
     */
    void InitializeControllers(Vector3[] v) {
        mControllers = new GameObject[v.Length];
        mLines = new GameObject[v.Length];
        for (int index = 0; index < v.Length; index++) {
            mControllers[index] = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            mControllers[index].transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            mControllers[index].transform.localPosition = v[index];
            mControllers[index].transform.parent = this.transform;

            mLines[index] = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            mLines[index].transform.localScale = new Vector3(0.01f, 1f, 0.01f);
            Vector3 newPos = v[index];
            newPos.y = v[index].y + 1f;
            mLines[index].transform.localPosition = newPos;
            mLines[index].transform.parent = this.transform;
        }
    }

    /** 
     * 
     */
    void Update()
    {
        Vector3[] v = meshFilterRef.vertices;
        Vector3[] n = meshFilterRef.normals;
        int[] t = meshFilterRef.triangles;

        for (int index = 0; index < mControllers.Length; index++) {
            v[index] = mControllers[index].transform.localPosition;
            //Vector3 newPos = v[index];
            //newPos.y = v[index].y + 1f;
            mLines[index].transform.localPosition = v[index] + (n[index]);
            mLines[index].transform.localRotation = Quaternion.FromToRotation(Vector3.up, n[index]);
        }

        meshFilterRef.vertices = v;
        UpdateNormals(v, t);
        updateVertices();
    }

    /**
     *  This is updates the normals of each vertice given the v (vertice pos)
     *  , n (normal vector), and t (the reference of each triangle vertices).
     *  This function returns a vector of the new normals.
     */
    void UpdateNormals(Vector3[] v, int[] t) {

        Vector3[] faceNormals = new Vector3[2 * (row) * (col)];
        int[] numbersAdded = new int[v.Length];
        Vector3[] newV = new Vector3[v.Length];


        // Loops through all the triangles
        for (int index = 0; index < faceNormals.Length; index++) {
            int currIndex = index * 3;

            Vector3 pointA = v[t[currIndex]];
            Vector3 pointB = v[t[currIndex + 1]];
            Vector3 pointC = v[t[currIndex + 2]];

            Vector3 lineA = pointB - pointA;
            Vector3 lineB = pointC - pointA;

            faceNormals[index] = Vector3.Cross(lineA, lineB).normalized;

            newV[t[currIndex]] += faceNormals[index];
            newV[t[currIndex + 1]] += faceNormals[index];
            newV[t[currIndex + 2]] += faceNormals[index];

            numbersAdded[t[currIndex]]++;
            numbersAdded[t[currIndex + 1]]++;
            numbersAdded[t[currIndex + 2]]++;
        }

        for (int index = 0; index < numbersAdded.Length; index++) {
            newV[index] = (newV[index] / numbersAdded[index]).normalized;
        }

        meshFilterRef.normals = newV;

        //print("Normals Updated");
    }

    /**
     *  The parameter rows is the new number of rows to set row to and
     *  columns is to set for col variable as well. This only works
     *  for flat plane objects!!!! Since I'm not motivated enough to make
     *  a general purpose one.
     */
    public void ChangeResolution(int newRow, int newCol) {
        this.row = newRow;
        this.col = newCol;

        Vector3[] v = new Vector3[(1 + newRow) * (1 + newCol)];     // Total New Vertices
        Vector3[] n = new Vector3[v.Length];                        // Total number of normal vertices, same as v
        int[] t = new int[6 * newRow * newCol];                     // 6 values per square
        Vector2[] uv = new Vector2[(v.Length)];

        float xDist = xLen / col;
        float zDist = zLen / row;

        float xCenter = xLen / 2f;
        float zCenter = zLen / 2f;

        float uvXDist = defaultXLen / col;
        float uvYDist = defaultYLen / row;

        // Default verticies normal
        for (int index = 0; index < n.Length; index++) {
            n[index] = new Vector3(0,1,0);
        }

        for (int rowIndex = 0; rowIndex < 1 + row; rowIndex++) {

            for (int colIndex = 0; colIndex < 1 + col; colIndex++) {
                int currIndex = ((col + 1) * rowIndex) + colIndex;

                // Calculates the vertex values
                float xVal = (colIndex * xDist) - xCenter;
                float zVal = (rowIndex * zDist) - zCenter;
                v[currIndex] = new Vector3(xVal,0,zVal);

                // Calculates the UV values
                float uvXVal = (colIndex * uvXDist);
                float uvYVal = (rowIndex * uvYDist);
                uv[currIndex] = new Vector2(uvXVal, uvYVal);

                Debug.Log("Index:" + currIndex + "UV X Val:" + uvXVal + ", UV Y Val:" + uvYVal);

            }

        }

        int tempCount = 0;
        for (int rowCount = 0; rowCount < newRow; rowCount++) {

            for (int colCount = 0; colCount < newCol; colCount++) {

                int currIndx = ((col + 1) * rowCount) + colCount;
                int trianglePt = tempCount * 6;

                t[trianglePt] = currIndx;
                t[trianglePt + 1] = currIndx + newCol + 1;
                t[trianglePt + 2] = currIndx + newCol + 2;
                t[trianglePt + 3] = currIndx;
                t[trianglePt + 4] = currIndx + newCol + 2;
                t[trianglePt + 5] = currIndx + 1;

                tempCount++;

            }

        }

        Mesh tempMesh = new Mesh();     // New mesh
        tempMesh.vertices = v;          // Set new mesh vertices
        tempMesh.normals = n;           // Set new mesh normal vectors
        tempMesh.triangles = t;         // Set new mesh triangle vertices
        tempMesh.uv = uv;               // Set new mesh UV values (BROKEN)
        tempMesh.uv2 = uv;
        originalUVVals = uv;            // Copies initilized UV values
        GetComponent<MeshFilter>().mesh = tempMesh; // Sets new mesh
        meshFilterRef = tempMesh;                   // sets reference mesh to new mesh
        UpdateControllers();                        // Updates the spheres and cylinders
        //ApplyUVTransform();
        //noUpdate = false;
    }

    void UpdateControllers() {
        for (int index = 0; index < mControllers.Length; index++) {
            if (mControllers[index] != null) {
                Destroy(mControllers[index]);
            }
            if (mLines[index] != null) {
                Destroy(mLines[index]);
            }
        }
        Vector3[] v = meshFilterRef.vertices;
        Vector3[] n = meshFilterRef.normals;
        int[] t = meshFilterRef.triangles;

        InitializeControllers(v);

        for (int index = 0; index < mControllers.Length; index++) {
            v[index] = mControllers[index].transform.localPosition;
            mLines[index].transform.localPosition = v[index] + (n[index]);
            mLines[index].transform.localRotation = Quaternion.FromToRotation(Vector3.up, n[index]);
        }

        meshFilterRef.vertices = v;
    }

    void updateVertices() {
        if (showVertices) {
            for (int index = 0; index < mControllers.Length; index++) {
                mControllers[index].SetActive(true);
                mLines[index].SetActive(true);
            }
        } else {
            for (int index = 0; index < mControllers.Length; index++) {
                mControllers[index].SetActive(false);
                mLines[index].SetActive(false);
            }
        }
    }

    public void show() {
        showVertices = true;
    }

    public void hide() {
        showVertices = false;
    }

    public void SetUVMatrixTransform(Matrix3x3 input) {
        uvTransform = input;
    }

    /**
     *  This function should be called whenever the UV is changed.
     */
    public void ApplyUVTransform() {
        
        if (originalUVVals != null) {
            Vector2[] uv = new Vector2[originalUVVals.Length];
            for (int index = 0; index < uv.Length; index++) {
                uv[index] = Matrix3x3.MultiplyVector2(uvTransform, originalUVVals[index]);
            }
            meshFilterRef.uv = uv;
        }
    }

}

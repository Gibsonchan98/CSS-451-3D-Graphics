using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class CylinderMesh : MonoBehaviour
{
    LineSegment[] mNormals;

    void InitNormals(Vector3[] v, Vector3[] n)
    {
        mNormals = new LineSegment[v.Length];
        for (int i = 0; i < v.Length; i++)
        {
            GameObject o = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            mNormals[i] = o.AddComponent<LineSegment>();
            mNormals[i].SetWidth(0.05f);
            mNormals[i].transform.SetParent(this.transform);
        }
        UpdateNormals(v, n);
    }

    void UpdateNormals(Vector3[] v, Vector3[] n)
    {
        for (int i = 0; i < v.Length; i++)
        {
            mNormals[i].SetEndPoints(v[i], v[i] - 1.0f * n[i]);
        }
    }

    Vector3 AvgNormal(Vector3[] v, int a, int b, int c)
    {
        Vector3 first = v[b] - v[a];
        Vector3 second = v[c] - v[a];
        return Vector3.Cross(first, second).normalized;
    }

    void ComputeNormals(Vector3[] v, Vector3[] n)
    {
        //Array for normal vectors of triangles 
        Vector3[] tN = new Vector3[triangles];

        //get vectors related to triangle 
        for (int i = 0; i < triangles; i++)
        {
            int t1 = t[i * 3]; 
            int t2 = t[i * 3 + 1];
            int t3 = t[i * 3 + 2];
            tN[i] = AvgNormal(v, t1, t2, t3);
        }

        n[0] = (tN[0] + tN[1]).normalized;
        n[N] = tN[N * 2 - 1].normalized;
        n[vertices - (N + 1)] = tN[(N * 2) * (M - 1)].normalized;
        n[vertices - 1] = (tN[triangles - 1] + tN[triangles - 2]).normalized;

        int Tnum = 1;
        int Tnum2 = triangles - (2 * N); //bottom triangle 
        for (int tb = 1; tb < N; tb++)
        {
            n[tb] = (tN[Tnum] + tN[Tnum + 1] + tN[Tnum + 2]).normalized;
            n[vertices - (N + 1) + tb] = (tN[Tnum2] + tN[Tnum2 + 1] + tN[Tnum2 + 2]).normalized;
            Tnum += 2;
            Tnum2 += 2;
        }

       
        int rT = (N * 2) - 1;
        int lT = 0;
        for (int a = N + 1; a < (N + 1) * M; a += (N + 1))
        {
            n[a] = (tN[lT] + tN[lT+ (N * 2)] + tN[lT + (N * 2) + 1]).normalized;
            lT += (N * 2);
            n[a + N] = (tN[rT] + tN[rT - 1] + tN[rT + (N * 2)]).normalized;
            rT += (N * 2);
        }


        int iT = 0;
        for (int d = 1; d < M; d++)
        {
            for (int c = 1; c < N; c++)
            {
                n[c + (d * (N + 1))] = (tN[iT] + tN[iT + 1] + tN[iT + 2]
                    + tN[iT + (N * 2) + 1] + tN[iT + (N * 2) + 2] + tN[iT + (N * 2) + 3]).normalized;
                iT += 2;
            }
            iT += 2;
        }
        UpdateNormals(v, n);
    }
}

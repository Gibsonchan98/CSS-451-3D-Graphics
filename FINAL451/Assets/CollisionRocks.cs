using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionRocks : MonoBehaviour
{
    public KelvinSceneNode Node;
    public List<Transform> rocks;
    Matrix4x4 m;
    Vector3 pos; 

    // Start is called before the first frame update
    void Start()
    {
        m = Node.GetMatrix();
        pos = new Vector3(m.GetColumn(3).x, m.GetColumn(3).y, m.GetColumn(3).z);
    }

    // Update is called once per frame
    void Update()
    {
        m = Node.GetMatrix();
        pos = new Vector3(m.GetColumn(3).x, m.GetColumn(3).y, m.GetColumn(3).z);
        for (int i = 0; i < rocks.Count; i++)
        {
            Vector3 temp = pos - rocks[i].position;
            if (temp.magnitude < 5)
            {
                rocks[i].GetComponent<Renderer>().enabled = false;
            }
            if (rocks[i].GetComponent<Renderer>().enabled == false)
            {
                GameObject tempG = rocks[i].gameObject;
                rocks.RemoveAt(i);
                Destroy(tempG);
                tempG = null; 
            }
        }
    }
}

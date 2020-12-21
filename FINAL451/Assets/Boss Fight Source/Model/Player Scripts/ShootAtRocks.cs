using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAtRocks : MonoBehaviour
{
    public List<Transform> rocks;
    public GunScript gun;
    Vector3 laserPosition;
    bool stat;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        laserPosition = gun.getLaser().transform.position;
        for (int i = 0; i < rocks.Count; i++) {
            Vector3 temp = laserPosition - rocks[i].position;
            if (temp.magnitude < 5) {
                rocks[i].GetComponent<Renderer>().enabled = false;
            }
            if (rocks[i].GetComponent<Renderer>().enabled == false) {
                stat = true;
                GameObject tempG = rocks[i].gameObject;
                rocks.RemoveAt(i);
                Destroy(tempG);
                tempG = null;
            }
        }
    }

    public bool hitRock() {
        return true;
    }
}

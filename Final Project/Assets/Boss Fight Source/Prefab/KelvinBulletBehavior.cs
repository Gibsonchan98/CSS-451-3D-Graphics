using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KelvinBulletBehavior : MonoBehaviour
{
    GameObject Player, Temp = null;
    public List<string> playerParts;
    protected Matrix4x4 Xform, C;
    Vector3 velocity;
    float D, t;
    bool hit;
    KelvinSceneNode Node;
    //HealthInteraction h;
    // Start is called before the first frame update
    void Start()
    {
        t = 80;
        hit = false;
    }


    // Update is called once per frame
    void Update()
    {
        Vector3 temp = transform.localPosition;
        transform.localPosition += D / t * -transform.up;
        if (D < 15)
        {
            hit = true;
        }
        Destroy(gameObject, 4);
    }

    public void Move(Vector3 d)
    {
        velocity = d;
        D = velocity.magnitude;
        velocity.Normalize();
    }

    public void setPlayer(GameObject player)
    {
        Player = player;
        InitializeList();
    }

    void InitializeList()
    {
        foreach (Transform child in Player.transform)
        {
            playerParts.Add(child.name);
        }
    }

    public void SetMatrix(Matrix4x4 m, Matrix4x4 c, KelvinSceneNode N)
    {
        Xform = m;
        Node = N;
        C = c;
    }

    public void setT(float val)
    {
        t = val;
    }

    public bool bulletHit()
    {
        return hit;
    }
}

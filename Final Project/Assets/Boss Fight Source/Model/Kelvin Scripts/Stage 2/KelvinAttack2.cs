using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KelvinAttack2 : MonoBehaviour
{
    public KelvinSceneNode Node, LeafNode, Arm;
    public GameObject Player;
    public KelvinNodePrimitive Child;

    Matrix4x4 pos;
    GameObject bullet;
    KelvinBulletBehavior bulletB;
    Vector3 pP, d, posV;
    // Start is called before the first frame update
    void Start()
    {
        //Destroy unecessary objects
        Destroy(LeafNode.PrimitiveList[0].gameObject);
        Destroy(LeafNode.PrimitiveList[1].gameObject);
        LeafNode.PrimitiveList.Clear();
        Node.transform.localScale = new Vector3(3, 5, 3);
        Node.NodeOrigin = new Vector3(0, 11, 0);
        Vector3 q = Arm.transform.eulerAngles;
        q.z += 20;
        Arm.transform.eulerAngles = q;
        LeafNode.NodeOrigin = new Vector3(0, -0.3f, 0.3f);
        Node = transform.GetComponent<KelvinSceneNode>();
        //get position from Matrix4x4
        pos = Node.GetMatrix();
        posV = new Vector3(pos.GetColumn(3).x, pos.GetColumn(3).y, pos.GetColumn(3).z);
        AddProjectile();
        InvokeRepeating("SpawnProjectile", 4, 4);
    }

    void SpawnProjectile()
    {
        LeafNode.PrimitiveList.RemoveAt(0);
        AddProjectile();
    }

    void AddProjectile()
    {
        bullet = Instantiate(Resources.Load("Bullet")) as GameObject;
        Child = bullet.transform.GetComponent<KelvinNodePrimitive>();
        LeafNode.SetChild(Child);
        bulletB = bullet.GetComponent<KelvinBulletBehavior>();
        bulletB.setPlayer(Player);
        bulletB.SetMatrix(LeafNode.GetMatrix(), Child.GetPosition(), LeafNode);
        ProjectileMove();
    }

    void ProjectileMove()
    {
        pP = Player.transform.localPosition;
        d = pP - bullet.transform.localPosition;
        bulletB.Move(d);
    }
    // Update is called once per frame
    void Update()
    {
        TurnToPlayer();
        pos = Node.GetMatrix();
        posV = new Vector3(pos.GetColumn(3).x, pos.GetColumn(3).y, pos.GetColumn(3).z);
    }

    private void MoveToPlayer()
    {
        Vector3 velocity = Player.transform.localPosition - posV;
        float D = velocity.magnitude;
        velocity.Normalize();
        Vector3 temp = transform.localPosition;
        temp += (D / 120) * velocity;
        //restriction on y movement
        transform.localPosition = new Vector3(temp.x, 0f, temp.z);
    }

    private void TurnToPlayer()
    {
        Vector3 V = Player.transform.localPosition - posV;
        //Robot turns with player
        if (V.magnitude > 10)
        {
            float angle = Vector3.Dot(transform.forward, V / V.magnitude);
            transform.localRotation *= Quaternion.AngleAxis(angle * 50, Vector3.up);
            MoveToPlayer();
        }

    }

    public KelvinBulletBehavior GetBullet()
    {
        return bulletB;
    }
    private void robotSpin()
    {


    }
}

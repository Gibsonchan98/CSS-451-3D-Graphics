using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class KelvinAttack1 : MonoBehaviour
{
    public KelvinSceneNode Node, Torso, Hand, Leaf; //for torso section
    public GameObject Player; //to get direction and location of target
    Quaternion iniL, iniH;
    Matrix4x4 pos, leafPos;
    Vector3 posV, dir;
    // Start is called before the first frame update
    void Start()
    {
        dir = Vector3.right;
        Node = transform.GetComponent<KelvinSceneNode>();
        //get position from Matrix4x4
        pos = Node.GetMatrix();
        posV = new Vector3(pos.GetColumn(3).x, pos.GetColumn(3).y, pos.GetColumn(3).z);
        iniH = Hand.transform.localRotation;
        iniL = Leaf.transform.localRotation;

    }

    // Update is called once per frame
    void Update()
    {

        Vector3 V = Player.transform.localPosition - posV;
        //check if player is withing paremeters
        if (V.magnitude < 10)
        {
            Debug.Log("Close to robot");
            //swing sword
            SwordMove();
        }
        else
        {
            //Robot turns to face player
            if (Hand.transform.localRotation != iniH)
            {
                initialStance();
            }
            float angle = Vector3.Dot(transform.forward, V / V.magnitude);
            transform.localRotation *= Quaternion.AngleAxis(angle * 50, Vector3.up);
        }

        leafPos = Leaf.GetMatrix();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class KelvinMainController : MonoBehaviour
{
    void mouseEvents()
    {
        //Player shoots with left control
        if (Input.GetMouseButtonDown(0))
            World.shoot();
    }
}

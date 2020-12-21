using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class CreationTargetInteraction : MonoBehaviour
{
    Vector3 newPosition;
    // Start is called before the first frame update
    void Start()
    {
        newPosition = transform.position; 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
                SetNewPosition();        
        }
    }

    void SetNewPosition() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit)) {
            //check if in position 
            if (hit.collider.CompareTag("Shape")) {
               //DESTROY SHAPE
                return;
            }
            //check if in bound
            newPosition = hit.point;

            if (newPosition.x > 6)
            {
                newPosition.x = 6.5f;
            }
            else if(newPosition.x < -6){
                newPosition.x = -6.5f;
            }

            if (newPosition.z > 6)
            {
                newPosition.z = 6.3f;
            }
            else if (newPosition.z < -6)
            {
                newPosition.z = -6.3f;
            }

            transform.position = newPosition;

        
        }
    
    }
}

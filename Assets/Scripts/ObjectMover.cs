using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    public bool tryingToMoveObject = false;
    bool objectMoving = false;
    GameObject objectInSelection;
    public ManagerGeneral managerGeneral;

    void Update()
    {
        if (tryingToMoveObject == true)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (Input.GetMouseButtonDown(0))
                {
                    objectInSelection = hit.collider.gameObject;
                    if (objectInSelection.tag == "Assets")
                    {
                        objectMoving = true;
                        tryingToMoveObject = false;
                    }
                }
            }
        }
        else if (objectMoving == true)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            objectInSelection.SetActive(false);
            if (Physics.Raycast(ray, out hit))
            {
                objectInSelection.transform.position = hit.point;
            }
            objectInSelection.SetActive(true);
            
            if (Input.GetMouseButtonDown(0))
            {
                objectMoving = false;
                managerGeneral.MenuPopupActivation();
            }
        }
    }
}

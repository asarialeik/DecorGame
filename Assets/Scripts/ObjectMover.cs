using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    public bool tryingToMoveObject = false;
    bool objectMoving = false;
    GameObject objectInSelection;
    [SerializeField]
    GameObject circle;
    public ManagerGeneral managerGeneral;

    void Update()
    {
        if (tryingToMoveObject == true)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                objectInSelection = hit.collider.gameObject;
                if (objectInSelection.tag == "Assets")
                {
                    circle.SetActive(true);
                    circle.transform.parent = objectInSelection.transform;
                    circle.transform.position = objectInSelection.transform.position;
                    if (Input.GetMouseButtonDown(0))
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
                circle.SetActive(false);
                managerGeneral.MenuPopupActivation();
            }
        }
    }
}

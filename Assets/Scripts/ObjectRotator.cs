using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotator : MonoBehaviour
{
    public bool tryingToRotateObject = false;
    bool objectInRotation = false;
    GameObject objectInSelection;
    public ManagerGeneral managerGeneral;

    void Update()
    {
        if (tryingToRotateObject == true)
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
                        tryingToRotateObject = false;
                        objectInRotation = true;
                    }
                }
            }
        }
        else if (objectInRotation == true)
        {
            ObjectRotation();
        }
    }

    void ObjectRotation()
    {
        /// Moves clockwise
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            objectInSelection.transform.Rotate(Vector3.up, -5f);
        }
        ///Moves anticlockwise
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            objectInSelection.transform.Rotate(Vector3.up, 5f);
        }
        
        if (Input.GetMouseButtonDown(0))
        {
            objectInRotation = false ;
            managerGeneral.MenuPopupActivation();
        }
    }
}

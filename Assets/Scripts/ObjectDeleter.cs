using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDeleter : MonoBehaviour
{
    public bool tryingToDeleteObject = false;
    GameObject objectInSelection;
    public ManagerGeneral managerGeneral;

    void Update()
    {
        if (tryingToDeleteObject == true)
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
                        objectInSelection.SetActive(false);
                        managerGeneral.MenuPopupActivation();
                    }
                }
            }
        }
    }
}

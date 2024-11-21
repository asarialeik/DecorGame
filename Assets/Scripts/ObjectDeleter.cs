using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class ObjectDeleter : MonoBehaviour
{
    public bool tryingToDeleteObject = false;
    GameObject objectInSelection;
    [SerializeField]
    GameObject circle;
    public ManagerGeneral managerGeneral;

    void Update()
    {
        if (tryingToDeleteObject == true)
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
                        Destroy (objectInSelection);
                        circle.SetActive(false);
                        managerGeneral.MenuPopupActivation();
                    }
                }
            }
        }
    }
}

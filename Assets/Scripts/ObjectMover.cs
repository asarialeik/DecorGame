using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    [SerializeField]
    bool tryingToMoveObject = false;
    bool objectMoving = false;
    [SerializeField]
    GameObject objectInMovement;
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
                    objectInMovement = hit.collider.gameObject;
                    objectMoving = true;
                    tryingToMoveObject = false;
                }
            }
        }

        if (objectMoving == true)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                objectInMovement.SetActive(false);
                if (Physics.Raycast(ray, out hit))
                {
                    objectInMovement.transform.position = hit.point;
                }
                objectInMovement.SetActive(true);

                if (Input.GetMouseButtonDown(1))
                {
                    objectMoving = false;
                    managerGeneral.MenuPopupActivation();
                }
            }
        }
    }

    public void MovingObject()
    {
        tryingToMoveObject = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScalator : MonoBehaviour
{
    public bool tryingToScalateObject = false;
    bool objectInScalation = false;
    GameObject objectInSelection;
    [SerializeField]
    GameObject circle;
    public ManagerGeneral managerGeneral;
    float number = 30;
    float punto0;
    float aSumar;

    void Update()
    {
        if (tryingToScalateObject == true)
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
                        punto0 = Input.mousePosition.y;
                        tryingToScalateObject = false;
                        objectInScalation = true;
                    }
                }
            }
        }
        else if (objectInScalation == true)
        {
            ObjectScalation();
        }
    }

    void ObjectScalation()
    {
        /// Moves clockwise
        /// //Input.MousePosition
        /*if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            LeanTween.scale(objectInSelection, objectInSelection.transform.localScale + Vector3.one/number, 0.25f);
        }
        ///Moves anticlockwise
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            LeanTween.scale(objectInSelection, objectInSelection.transform.localScale - Vector3.one/ number, 0.25f);
        }*/
        aSumar = Input.mousePosition.y - punto0;
        LeanTween.scale(objectInSelection, objectInSelection.transform.localScale + (Vector3.one * aSumar) / 1000, 0.25f);

        if (Input.GetMouseButtonDown(0))
        {
            objectInScalation = false;
            circle.SetActive(false);
            managerGeneral.MenuPopupActivation();
        }
    }
}

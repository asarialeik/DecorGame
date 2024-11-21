using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCreator : MonoBehaviour
{
    [SerializeField]
    GameObject objetoACrear;
    GameObject objetoCreado;
    [SerializeField]
    GameObject circle;
    public ManagerGeneral managerGeneral;
    bool positioning = false;

    private void Update()
    {
        if (positioning == true)
        {
            objetoCreado.SetActive(false);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                objetoCreado.transform.position = hit.point;
            }
            objetoCreado.SetActive(true);

            if (Input.GetMouseButtonDown(0))
            {
                positioning = false;
                circle.SetActive(false);
                managerGeneral.MenuPopupActivation();
            }
        }
    }

    public void ObjectCreation()
    {
        objetoACrear.SetActive(true);
        objetoCreado = Instantiate(objetoACrear, Vector3.zero, Quaternion.identity);
        circle.SetActive(true);
        circle.transform.parent = objetoCreado.transform;
        circle.transform.position = objetoCreado.transform.position;
        positioning = true;
    }
}

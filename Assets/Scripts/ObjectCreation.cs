using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCreator : MonoBehaviour
{
    [SerializeField]
    GameObject objetoACrear;
    GameObject objetoCreado;
    public ManagerGeneral managerGeneral;
    bool positioning = false;

    private void Update()
    {
        if (positioning == true)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                objetoCreado.transform.position = hit.point;
            }

            if (Input.GetMouseButtonDown(0))
            {
                positioning = false;
                managerGeneral.MenuPopupActivation();
            }
        }
    }

    public void ObjectCreation()
    {
        objetoACrear.SetActive(true);
        objetoCreado = Instantiate(objetoACrear, Vector3.zero, Quaternion.identity);
        positioning = true;
    }
}

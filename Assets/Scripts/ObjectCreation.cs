using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCreator : MonoBehaviour
{
    [SerializeField]
    GameObject objetoCreado;

    private void Update()
    {
        if (objetoCreado.activeSelf)
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                objetoCreado.transform.position = hit.point;
            }

        }
    }

    public void ObjectCreation()
    {
        objetoCreado.SetActive(true);
        Instantiate(objetoCreado, Vector3.zero, Quaternion.identity);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseAim : MonoBehaviour
{
    public Transform terreno;
    public Vector3 escala;
    // Update is called once per frame
    void Update()
    {
        Ray mousePos = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        transform.position = mousePos.GetPoint(100);
        if (Physics.Raycast(mousePos, 1000))
        {
            transform.position = mousePos.GetPoint(terreno.position.magnitude);
            transform.localScale = escala;
        }
        else
        {
            transform.localScale = Vector3.one;
        }
    }
}

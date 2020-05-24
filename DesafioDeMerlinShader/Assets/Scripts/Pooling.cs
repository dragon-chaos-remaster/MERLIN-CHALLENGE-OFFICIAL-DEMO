using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pooling : MonoBehaviour
{
    public List<GameObject> listaDeObjetos = new List<GameObject>();
    public GameObject objeto;

    public bool vaiCrescer;
    public int numeroDeObjetos;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numeroDeObjetos; i++)
        {
            GameObject obj = Instantiate(objeto);
            obj.SetActive(false);
            listaDeObjetos.Add(obj);
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < listaDeObjetos.Count; i++)
        {
            if (!listaDeObjetos[i].activeInHierarchy)
            {
                return listaDeObjetos[i];
            }
            
        }
        if (vaiCrescer)
        {
            GameObject aux = Instantiate(objeto);
            //aux.SetActive(false);
            listaDeObjetos.Add(aux);
            return aux;
        }
        return null;
    }
}

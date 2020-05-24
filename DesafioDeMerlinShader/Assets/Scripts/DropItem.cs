using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour
{
    int numero;
    [Range(0, 100)]
    public int controleDrop;
    public GameObject item;
    public Transform ondeNasce;
    
    // Start is called before the first frame update
    
    void OnDisable()
    {
        Dropando();
    }

    public void Dropando()
    {
        numero = Random.Range(0 , 100);
        //Debug.LogError(numero);
        if (numero > controleDrop)
        {
            Instantiate(item, ondeNasce.position, ondeNasce.rotation);
        }
    }



}


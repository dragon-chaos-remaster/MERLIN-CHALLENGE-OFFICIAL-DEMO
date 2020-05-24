using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaoSei : MonoBehaviour
{
    public GameObject hitGelo;
    public Transform ondeNasce;


    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == ("chao"))
        {
            Instantiate(hitGelo, ondeNasce.position, ondeNasce.rotation);
            Destroy(gameObject);
        }
    }
}

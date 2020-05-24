using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{

    public GameObject hitDoFogo;
    public Transform ondeNasce;
    public GameObject pegaFogo;

    // Start is called before the first frame update
    void Start()
    {
        ondeNasce = GetComponent<Transform>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == ("chao") || other.tag == ("BossCaveira"))
        {
            FindObjectOfType<AudioManager>().Play("explosão");
            Instantiate(hitDoFogo, ondeNasce.position, ondeNasce.rotation);
            Instantiate(pegaFogo, ondeNasce.position, ondeNasce.rotation);
            Destroy(gameObject);
        }
    }
}

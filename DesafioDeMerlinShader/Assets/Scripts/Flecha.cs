using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flecha : MonoBehaviour
{

    Rigidbody fisica;
    public Transform flecha;
    public float velocidadeProjetil;

    [SerializeField] float tempoViva = 0;
    float auxTempoViva;
    float tempoAtual = 1;
    public float tempoDestruicao;

    public GameObject hitFlecha;
    public Transform ondeNasce;

    //[SerializeField] Pooling pooling;
    // Start is called before the first frame update
    void Start()
    {
        auxTempoViva = tempoViva;
        fisica = GetComponent<Rigidbody>();
        flecha = GetComponent<Transform>();
        //pooling = GameObject.Find("PoolingArrow").GetComponent<Pooling>();
        //fisica.AddForce(flecha.forward * velocidadeProjetil);

    }

    // Update is called once per frame
    void Update()
    {
        fisica.velocity = flecha.forward * velocidadeProjetil * Time.deltaTime;

        tempoViva += tempoAtual * Time.deltaTime;
        if (tempoViva >= tempoDestruicao)
        {
           
            //Destroy(gameObject);
            gameObject.SetActive(false);
            //print("Is: " + gameObject.activeInHierarchy);
            tempoViva = auxTempoViva;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "player")
        {           
            Instantiate(hitFlecha, ondeNasce.position, ondeNasce.rotation);
            
            //Destroy(gameObject);
            gameObject.SetActive(false);
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueBasico : MonoBehaviour
{
    Rigidbody fisica;
    public Transform foguinho;
    public float velocidadeProjetil;
    //[SerializeField] RockEnemy inimigoPedra;
    float tempoViva = 0;
    float tempoAtual = 1;
    public float tempoDestruicao;

    public GameObject hitBasico;
    public Transform ondeNasce;
    // Start is called before the first frame update
    void Start()
    {
        fisica = GetComponent<Rigidbody>();
        foguinho = GetComponent<Transform>();
        
        //fisica.AddForce(foguinho.forward * velocidadeProjetil);
    }

    private void FixedUpdate()
    {
        fisica.velocity = foguinho.forward * velocidadeProjetil * Time.deltaTime;
    }
    void Update()
    {
        tempoViva += tempoAtual * Time.deltaTime;
       
        if (tempoViva >= tempoDestruicao)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.transform.tag)
        {
            case "inimigoFraco":
                Instantiate(hitBasico, ondeNasce.position, ondeNasce.rotation);
                Destroy(gameObject);
                break;
            case "inimigoTerra":
                Instantiate(hitBasico, ondeNasce.position, ondeNasce.rotation);
                Destroy(gameObject);
                break;
            case "inimigoPedra":
                //inimigoPedra.enemySpotted = true;
                Instantiate(hitBasico, ondeNasce.position, ondeNasce.rotation);
                Destroy(gameObject);
                break;
            case "BossCaveira":
                Instantiate(hitBasico, ondeNasce.position, ondeNasce.rotation);
                Destroy(gameObject);
                break;
            case "inimigoMadeira":
                Instantiate(hitBasico, ondeNasce.position, ondeNasce.rotation);
                Destroy(gameObject);
                break;
            case "inimigoPedraMinion":
                //inimigoPedra.enemySpotted = true;
                Instantiate(hitBasico, ondeNasce.position, ondeNasce.rotation);
                Destroy(gameObject);
                break;
        }

    }
}

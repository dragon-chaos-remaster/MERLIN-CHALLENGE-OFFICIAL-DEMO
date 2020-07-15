using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raio : MonoBehaviour
{
    public GameObject hitRaio;
    public Transform ondeNasce;

    [SerializeField] LayerMask layerDeInimigos;

    Rigidbody fisica;

    public Transform raio;
    public float velocidadeProjetil;

    public int limiteDeRicochete;
    int ricochetes;
    // Start is called before the first frame update
    void Start()
    {
        fisica = GetComponent<Rigidbody>();
        raio = GetComponent<Transform>();

        //fisica.AddForce(raio.forward * velocidadeProjetil);

    }
    void Awake()
    {
        FindObjectOfType<AudioManager>().Play("raio");
    }
    // Update is called once per frame
    void Update()
    {
        
        if(ricochetes >= limiteDeRicochete)
        {
            ricochetes = 0;
            Destroy(gameObject);
        }
    }
    void FixedUpdate()
    {
        fisica.velocity = raio.forward * velocidadeProjetil * Time.deltaTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        TomaDano[] inimigos = FindObjectsOfType<TomaDano>();
        Transform inimigoMaisPerto = null;
        for (int i = 0; i < inimigos.Length; i++)
        {
            //Verificar se não estou checando o cara que acabei de bater:
            if (inimigos[i].transform != other.gameObject.transform)
            {

                //Checar se eu to procurando o primeiro inimigo ou se o que eu estou procurando está mais perto do que o outro que eu achei que estava mais perto
                if (inimigoMaisPerto == null || Vector3.Distance(inimigoMaisPerto.position, raio.position) > Vector3.Distance(inimigos[i].transform.position, raio.position))
                {
                    inimigoMaisPerto = inimigos[i].transform;
                   
                    //print(inimigos[i].transform);
                }
            }

        }
        if (other.gameObject.CompareTag("inimigoTerra") || other.gameObject.CompareTag("inimigoFraco") || other.gameObject.CompareTag("inimigoMadeira"))
        {
            //print(ricochetes);
            ricochetes++;
        }
        else
        {
            ricochetes++;
        }
        raio.LookAt(inimigoMaisPerto);
    }
    
}
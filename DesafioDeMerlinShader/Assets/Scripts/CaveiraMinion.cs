using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveiraMinion : MonoBehaviour
{

    public GameObject projetil;
    public Transform ondeNasco;
    Transform target;

    public float tempoDeEspera = 5;
    public float tempoAtual;
    public float tempo = 1;

    [SerializeField] GameObject nossoMestre;
    [SerializeField] Pooling pooling;


    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("player").transform;
        pooling = GameObject.FindWithTag("PoolingArrow").GetComponent<Pooling>();
        nossoMestre = GameObject.Find("chefaocaveira_low").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(target.gameObject == null && Pause.pausado)
        {
            return;
        }
        if (BossCaveira.contagemCaveira >= 4 || tempoAtual >= 3 || (!nossoMestre.activeInHierarchy)) /*!GameObject.FindWithTag("BossCaveira").gameObject.activeInHierarchy)*/
        {
            gameObject.SetActive(false);
        }
        
        OlhandoProPlayer();
        transform.LookAt(target);
        tempoAtual += tempo * Time.deltaTime;
        if (tempoAtual >= tempoDeEspera)
        {
            GameObject aux = pooling.GetPooledObject();
            if(aux != null)
            {
                aux.SetActive(true);
                //print("Oi");
                aux.transform.position = ondeNasco.position;
                aux.transform.rotation = ondeNasco.rotation;
            }
            tempo = 1;
            tempoAtual = 0;
        }

    }
    void OlhandoProPlayer()
    {
        Vector3 targetPos = new Vector3(target.position.x, transform.position.y, target.position.z);
        transform.LookAt(targetPos);
    }

}

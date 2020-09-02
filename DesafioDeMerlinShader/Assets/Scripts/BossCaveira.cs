using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCaveira : MonoBehaviour
{

    public float rotacao;
    //public Transform eixoCentral;
    //public Transform eixoLateralUm;
    //public Transform eixoLateralDois;

    public Transform[] eixos = new Transform[3];

    [SerializeField] List<Transform> ondeMinionsNascem = new List<Transform>();
    
    //public GameObject projetil;

    [SerializeField] Pooling pooling;
    [SerializeField] Pooling minionsPooling;

    //public Transform caveiraUm;
    //public Transform caveiraDois;
    //public Transform caveiraTres;
    //public Transform caveiraQuatro;

    //public Transform ondeNascoUm;
    //public Transform ondeNascoDois;
    //public Transform ondeNascoTres;
    //public Transform ondeNascoQuatro;

    [SerializeField] Transform pezin;

    public float tempoDeEspera = 5;
    public float tempoAtual;
    public float tempo = 1;
    public bool podeSummon = true;

    static public int contagemCaveira = 0;

    bool roleta = true;
    bool caveira = false;

    [SerializeField] float distanceValue;

    public float tempoDuracaoRoleta = 5;
    public float tempoAtualRoleta;
    public float tempoRoleta = 1;

    [SerializeField] TomaDano dano;
    //[SerializeField] Snared snare;

    private void Start()
    {
        distanceValue = Mathf.Clamp(distanceValue, 8.39f, 20f);
        dano = GetComponent<TomaDano>();
        //snare = GetComponent<Snared>();
    }
    // Update is called once per frame
    void Update()
    {
        
        if (roleta)
        {
            distanceValue += Time.deltaTime;
            pezin.position = (Vector3.up * distanceValue);
            //print(distanceValue);
            StartCoroutine(RoletaRussa());
        }
        if (caveira)
        {
            distanceValue -= Time.deltaTime;
            pezin.position = (Vector3.up * distanceValue);
            if(pezin.position.y <= 8.41f)
            {
                distanceValue = 8.42f;
            }
            
            //distanceValue = Time.deltaTime - transform.position.y;
            CaveiraFantasma();
        }
        //snare.Desnare(2f);

    }
    void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "bolaFogo":
                dano.TomarDanos(10);
                break;
            case "Raio":

                dano.TomarDanos(5);
                break;
            case "NaoSei":
                //snare.Snare();
                dano.TomarDanos(3);
                break;
            case "ataqueBasico":

                dano.TomarDanos(5);
                break;
            case "pegaFogo":

                dano.TomarDanos(1);
                break;
        }
    }
    IEnumerator RoletaRussa()
    {
        tempoAtualRoleta += tempoRoleta * Time.deltaTime;
        if (tempoAtualRoleta >= tempoDuracaoRoleta)
        {
            roleta = false;
            caveira = true;
            tempoAtualRoleta = 0;
            tempoRoleta = 1;
            podeSummon = true;
            contagemCaveira = 0;
        }
        //0 - Central , 1 - Lateral Um, 2 - Lateral Doisa
        eixos[0].Rotate(0, rotacao, 0);
        eixos[1].Rotate(0, rotacao + 90, 0);
        eixos[2].Rotate(0, rotacao - 90, 0);

        GameObject aux = pooling.GetPooledObject();
        if (aux != null)
        {
            //Instantiate(projetil, eixoLateralUm.position, eixoLateralUm.rotation);
            //Instantiate(projetil, eixoLateralDois.position, eixoLateralDois.rotation);
            
            aux.transform.position = eixos[Random.Range(1, 2)].position;
            aux.transform.rotation = eixos[Random.Range(1, 2)].rotation;
            aux.SetActive(true);
            yield return new WaitForSeconds(0.35f);
        }
    }

    void CaveiraFantasma()
    {


        if (podeSummon)
        {
            //Instantiate(caveiraUm, ondeNascoUm.position, ondeNascoUm.rotation);
            //Instantiate(caveiraDois, ondeNascoDois.position, ondeNascoDois.rotation);
            //Instantiate(caveiraTres, ondeNascoTres.position, ondeNascoTres.rotation);
            //Instantiate(caveiraQuatro, ondeNascoQuatro.position, ondeNascoQuatro.rotation);
            
           
            
            for(int i = 0;i < ondeMinionsNascem.Count; i++)
            {
                GameObject aux = minionsPooling.GetPooledObject();
                if (aux != null)
                {
                    aux.transform.position = ondeMinionsNascem[i].position;
                    aux.transform.rotation = ondeMinionsNascem[i].rotation;
                    aux.SetActive(true);
                }
            }
                
            
            podeSummon = false;
            tempo = 1;
            tempoAtual = 0;
            contagemCaveira++;

        }


        tempoAtual += tempo * Time.deltaTime;
        if (tempoAtual >= tempoDeEspera)
        {
            podeSummon = true;
        }
        if (contagemCaveira >= 4)
        {
            caveira = false;
            roleta = true;
            podeSummon = false;

        }

    }
}

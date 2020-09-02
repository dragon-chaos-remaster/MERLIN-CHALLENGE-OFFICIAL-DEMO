using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Magia : MonoBehaviour
{
    // Variaveis das habilidades
    public bool bolaFogo = false;
    public bool raio = false;
    public bool seiLa = false;


    public GameObject player;

    //variaveis para spawn de habilidades
    public GameObject fireBall;
    public GameObject choque;
    public GameObject naoSei;

    public Transform cagadorDeMagia;


    protected RaycastHit hit;

    public LayerMask hitavel;

    // Start is called before the first frame update






    public float manaRegenSegundo = 0.1f;
    public float manaMax = 100f;
    public float updatedMana = 100f;
    public float custoManaFogo = 25f;
    public float custoManaRaio = 15f;
    public float custoManaRaiz = 20f;
    public Text quantidadeMana;
    public Image barraMana;

    public Transform ataqueBasico;
    public Transform ataquePoint;

    public Transform raizes;
    public Transform raizesPoint;

    public Transform choquePoint;

    public float tempoAtaque;
    private float waitFireRate = 1;
    public bool podeAtacar = true;


    CoolDown coolDown;
    void Start()
    {
        coolDown = GetComponent<CoolDown>();
    }


    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            barraMana.fillAmount = updatedMana / 100;
            quantidadeMana.text = (int)updatedMana + " Mana ";
            updatedMana += manaRegenSegundo * Time.deltaTime;

            if (updatedMana > manaMax)
            {
                updatedMana = 100;
            }
            if (updatedMana < 0)
            {
                updatedMana = 0;
            }

            SkillCheck();
            Atacando();
            TempoTiro();
        }
        if (!player.activeInHierarchy)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }




    void SkillCheck()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            bolaFogo = true;
            raio = false;
            seiLa = false;

        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            bolaFogo = false;
            raio = true;
            seiLa = false;

        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            bolaFogo = false;
            raio = false;
            seiLa = true;


        }

        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            bolaFogo = false;
            raio = false;
            seiLa = false;
        }
        bool teclaM = Input.GetKeyDown(KeyCode.M);
        bool teclaN = Input.GetKeyDown(KeyCode.N);

        if (teclaM && GameObject.FindWithTag("inimigoTerra").activeInHierarchy)
        {
            GameObject.FindWithTag("inimigoTerra").SetActive(false);
            
        }
        if (teclaN && GameObject.FindWithTag("inimigoMadeira").activeInHierarchy)
        {
            GameObject.FindWithTag("inimigoMadeira").SetActive(false);

        }



    }



    void Atacando()
    {
        if ((Input.GetKeyDown(KeyCode.Alpha1)) && (!EventSystem.current.IsPointerOverGameObject()))
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 10000, hitavel) && (bolaFogo) && (updatedMana >= custoManaFogo) && (coolDown.podeAtacarFogo))
            {

                GameObject aux = Instantiate(fireBall, new Vector3(hit.point.x, 20, hit.point.z), Quaternion.Euler(hit.normal));
                updatedMana -= custoManaFogo;
                coolDown.podeAtacarFogo = false;
                coolDown.waitFireRateFogo = 1;
            }
        }
        if ((Input.GetKeyDown(KeyCode.Alpha2)) && (!EventSystem.current.IsPointerOverGameObject()))
        {
            //print("pei");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 10000, hitavel) && (raio) && (updatedMana >= custoManaRaio) && (coolDown.podeAtacarRaio))
            {
                GameObject aux = Instantiate(choque, choquePoint.position, choquePoint.rotation);
                updatedMana -= custoManaRaio;
                coolDown.podeAtacarRaio = false;
                coolDown.waitFireRateRaio = 1;
            }
        }
        if ((Input.GetKeyDown(KeyCode.Alpha3)) && (!EventSystem.current.IsPointerOverGameObject()))
        {
           // print("pei");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 10000, hitavel) && (seiLa) && (updatedMana >= custoManaRaiz) && (coolDown.podeAtacarSnare))
            {
                Transform aux = Instantiate(raizes, raizesPoint.position, raizesPoint.rotation);
                updatedMana -= custoManaRaiz;
                coolDown.podeAtacarSnare = false;
                coolDown.waitFireRateSnare = 1;
            }




        }
        if ((Input.GetMouseButtonDown(0)) && (!EventSystem.current.IsPointerOverGameObject()))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 10000, hitavel) && (podeAtacar))
            {
                Instantiate(ataqueBasico, ataquePoint.position, ataquePoint.rotation);
                podeAtacar = false;
                waitFireRate = 1f;

            }
        }
    }
    void TempoTiro()
    {
        if (!podeAtacar)
        {
            waitFireRate += waitFireRate * Time.deltaTime;
        }

        if (waitFireRate >= tempoAtaque)
        {
            podeAtacar = true;
        }
    }

}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.AI;
using System.Linq;
using UnityEngine.SceneManagement;
public enum SpawnState { SPAWNANDO, ESPERANDO, CONTANDO };

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] Animator animator;
    public Pooling[] pooledObjects;

    // TODOS PRECISAM ESTAR VERDADEIROS
    [SerializeField] public bool[] activateBoss;
    // TODOS PRECISAM ESTAR VERDADEIROS

    [SerializeField] public List<GameObject> bosses = new List<GameObject>();

    [SerializeField] GameObject secondBossExplosion;
    [SerializeField] GameObject[] bridgeWalls;
    [SerializeField] TimeManager tempo;

    public int waveRound = 0;
    //[SerializeField] Pause pauses;
    //Referência ao Golpe do vilão DIO BRANDO, de Jojo's Bizarre Adventures: Stardust Crusaders, onde ele para o Tempo 
    bool zaWarudo = true;
    bool gameCompleted;
    //KONO DIO DA

    //public bool apenasAtiradores;
    //public bool apenasMelees;

    //[SerializeField] CameraChange whenCameraChanges;

    [System.Serializable]
    public class Wave
    {
        //public bool apenasAtiradores;
        //public bool apenasMelees;
        //public bool apenasPedras;
        //public bool[] estaNaIlha;
        public bool[] apenas = new bool[5];
        public string nome;
        public Transform[] inimigo;
        public int quantidade;
        public float ritmo;
    }

    public List<Wave> waves = new List<Wave>();

    [SerializeField] RespawnManager[] ilhaSpawns = new RespawnManager[3];
    //[SerializeField] Dictionary<int, Transform[]> transforms = new Dictionary<int, Transform[]>();

    public List<Transform> spawnPoints = new List<Transform>();
    int spawnLimiter = 0;
    public TextMeshProUGUI[] contagemRegressiva;

    #region SINGLETON
    static WaveSpawner instance;
    public static WaveSpawner Instance { get { return instance; } }
    private void Awake()
    {
        instance = this;
    }
    #endregion
    //[SerializeField] GameObject player;

    int waveCountPointer;
    private int proximaWave = 0;
    bool spawnEnemies;
    //public List<GameObject> enemyList = new List<GameObject>();
    public float contadorDaWave;
    public float tempoEntreWaves = 5f;
    //public Transform ondeOInimigoEsta, ondeOInimigoSpawna;
    private float procurarContador = 1f;
    private SpawnState estado = SpawnState.CONTANDO;
    void Start()
    {
        //animator = GetComponent<Animator>();
        if (spawnPoints.Count == 0)
        {
            Debug.LogError("ERRO: Não foi encontrado nenhum Ponto de Spawn dos Inimigos na Cena. FAVOR COLOCAR: " + spawnPoints.Count + " PARA A CENA");
        }

        for (int i = 0; i < pooledObjects[1].listaDeObjetos.Count; i++)
        {
            pooledObjects[1].listaDeObjetos[i].AddComponent<CogumeloBoom>();
        }
        //transforms.Add(whenCameraChanges.nIlha, spawnPoints);

        contadorDaWave = tempoEntreWaves;

    }
    void Update()
    {
        if (Pause.pausado)
        {
            return;
        }

        if (estado == SpawnState.ESPERANDO)
        {
            //Checar se os inimigos ainda estão vivos
            if (!InimigoVivo())
            {
                Debug.Log(waves.Capacity);
                animator.SetBool("Vitoria", true);
                OnWaveCompleted();
                if (!bosses[0].activeInHierarchy)
                {
                    WaveCount.Instance.numeroDaWave++;
                    WaveCount.Instance.waveClear.gameObject.SetActive(true);
                    contagemRegressiva[0].gameObject.SetActive(true);
                    contagemRegressiva[1].gameObject.SetActive(true);

                    //WaveCount.Instance.goToNextIsland.SetActive(true);
                }
                for (int i = 0; i < bosses[1].transform.childCount; i++)
                {
                    if (!bosses[1].transform.GetChild(i).gameObject.activeInHierarchy && i == 11)
                    {
                        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                    }
                }
                //print("Wave Completa");
                //zaWarudo = true;
                return;
                //Começa um novo round
            }
            else
            {
                return;
            }
        }
        int someInt = (int)contadorDaWave;
        contagemRegressiva[0].text = someInt.ToString();
        contagemRegressiva[1].text = someInt.ToString();
        if (!zaWarudo)
        {
            Time.fixedDeltaTime = .02f;
        }
        if (contadorDaWave <= 0)
        {
            animator.SetBool("Vitoria", false);
            WaveCount.Instance.waveClear.gameObject.SetActive(false);
            contagemRegressiva[0].gameObject.SetActive(false);
            contagemRegressiva[1].gameObject.SetActive(false);
            WaveCount.Instance.goToNextIsland.SetActive(false);
            bridgeWalls[0].SetActive(true);
            zaWarudo = false;
            if (estado != SpawnState.SPAWNANDO)
            {
                //Começa a spawnar a Wave
                StartCoroutine(CanSpawn(waves[proximaWave]));
            }
        }
        else
        {
            contadorDaWave -= Time.deltaTime;
        }
    }
    bool InimigoVivo()
    {
        procurarContador -= Time.deltaTime;
        if (procurarContador <= 0f)
        {
            //if (gameCompleted)
            //{
            //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            //}
            procurarContador = 1f;
            if ((GameObject.FindGameObjectWithTag("inimigoFraco") == null && GameObject.FindGameObjectWithTag("inimigoTerra") == null && GameObject.FindGameObjectWithTag("inimigoMadeira") == null) && (!bosses[0].activeInHierarchy/* && activateBoss[1]*/ /*!bosses[1].GetComponentInChildren<SphereCollider>().enabled || !bosses[1].activeInHierarchy*/))
            {
                for (int i = 0; i < bosses[1].transform.childCount; i++)
                {
                    if (!bosses[1].transform.GetChild(i).gameObject.activeInHierarchy && i == 11)
                    {
                        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                    }
                }
                //FREEZE FRAME NO ULTIMO INIMIGO
                tempo.FreezeFrame();
                
                //print(GameObject.FindGameObjectWithTag("Enemy").ToString());
                return false;
            }
        }
        return true;
    }
    void OnWaveCompleted()
    {
        estado = SpawnState.CONTANDO;
        contadorDaWave = tempoEntreWaves;
        // tempo.FreezeFrame();
        //WaveCount.Instance.waveClear.gameObject.SetActive(true);
        if (proximaWave + 1 > waves.Count - 1)
        {
            if (activateBoss[0])
            {
                bosses[0].SetActive(true);
                activateBoss[0] = false;
                StopAllCoroutines();
            }
            else if (activateBoss[1])
            {
                secondBossExplosion.SetActive(true);
                activateBoss[1] = false;
                StopAllCoroutines();
            }
            Invoke("RestartEveryWave", 1f);
        }
        else
        {
            proximaWave++;
        }

    }
    void RestartEveryWave()
    {
        proximaWave = 0;
        waveRound++;       
        if (waveRound == 1)
        {
            activateBoss[0] = true;
            spawnLimiter = 3;
            for (int i = 0; i < waves.Count; i++)
            {
                waves[i].apenas[2] = true;
            }
            //waves[proximaWave].apenas[2] = true;
            for (int i = 0; i < 5; i++)
            {              
                spawnPoints.Add(ilhaSpawns[1].listaDeSpawns[i].transform);
            }
        }
        if (waveRound == 2)
        {
            activateBoss[1] = true;
            for (int i = 0; i < waves.Count; i++)
            {
                waves[i].apenas[1] = true;
            }
            spawnLimiter = 8;
            for (int i = 0; i < 3; i++)
            {
                spawnPoints.Add(ilhaSpawns[2].listaDeSpawns[i].transform);
            }
        }
        for (int i = 0; i < bridgeWalls.Length; i++)
        {
            bridgeWalls[i].SetActive(false);
        }
        WaveCount.Instance.goToNextIsland.SetActive(true);
    }
    IEnumerator CanSpawn(Wave wave)
    {
        if (!bosses[0].activeInHierarchy)
        {
            estado = SpawnState.SPAWNANDO;
            waveCountPointer = wave.quantidade;
            //O Spawn
            for (int i = 0; i < wave.quantidade; i++)
            {
                SpawnEnemy();
                yield return new WaitForSeconds(1f / wave.ritmo);
            }
        }
        //Fim do Spawn
        estado = SpawnState.ESPERANDO;

        yield break;
    }
    void SpawnEnemy()
    {
        List<int> podemSpawnar = new List<int>();
        for(int i = 0; i < waves[proximaWave].apenas.Length; i++)
        {
            if (waves[proximaWave].apenas[i])
            {
                podemSpawnar.Add(i);
            }
        }

        GameObject aux = pooledObjects[podemSpawnar[Random.Range(0, podemSpawnar.Count)]].GetPooledObject();
        SetEnemyToSpawn(aux);

        //if (waves[proximaWave].apenas[0])
        //{
        //    GameObject aux = pooledObjects[0].GetPooledObject();
        //    SetEnemyToSpawn(aux);
        //}
        //if (waves[proximaWave].apenas[1])
        //{
        //    GameObject aux = pooledObjects[1].GetPooledObject();
        //    SetEnemyToSpawn(aux);
        //}
        //if (waves[proximaWave].apenas[2])
        //{
        //    GameObject aux = pooledObjects[2].GetPooledObject();
        //    SetEnemyToSpawn(aux);
        //}
        //if (waves[proximaWave].apenas[3])
        //{
        //    GameObject aux = pooledObjects[3].GetPooledObject();
        //    SetEnemyToSpawn(aux);
        //}
        //else
        //{
        //    GameObject aux = pooledObjects[Random.Range(0, pooledObjects.Length)].GetPooledObject();
        //    SetEnemyToSpawn(aux);
        //}


    }

    public void SetEnemyToSpawn(GameObject enemy)
    {
        if (enemy != null)
        {
            //print("Entro");

            Transform randomPos = spawnPoints[Random.Range(spawnLimiter, spawnPoints.Count)];
            enemy.SetActive(true);
            enemy.GetComponent<NavMeshAgent>().Warp(randomPos.position);
            //SetEnemyToSpawn();


            //enemy.transform.rotation = randomPos.rotation;
        }


    }
}

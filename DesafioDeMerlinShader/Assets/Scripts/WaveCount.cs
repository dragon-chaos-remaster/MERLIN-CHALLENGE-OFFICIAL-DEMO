using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WaveCount : MonoBehaviour
{
    public TextMeshProUGUI waveCounter;
    public Image waveClear;
    public GameObject goToNextIsland;
    public int numeroDaWave;
    public int numeroDeWaves;

    int numeroDeWavesGLOBAL = 50;
    public float contagem = 3f;

    private float timer = 0f;

    #region Singleton
    private static WaveCount instance;
    public static WaveCount Instance { get { return instance; } }
    void Awake()
    {
        instance = this;
    }
    #endregion

    void Start()
    {
        //waveCounter = GetComponent<TextMeshProUGUI>();
        //waveClear = GetComponent<TextMeshProUGUI>();

        PlayerPrefs.SetInt("WavesTotal", numeroDeWavesGLOBAL);
    }
    // Update is called once per frame
    void Update()
    { 
        //print(timer);
        timer += Time.deltaTime;
        if(timer >= contagem)
        { 
            timer = 0;
            waveCounter.text = "WAVE " + numeroDaWave.ToString();
            //numeroDaWave++;
        }
       /* if(numeroDaWave >= numeroDeWaves)
        {
            //StopAllCoroutines();
            waveClear.gameObject.SetActive(true);
            StartCoroutine(WaveCleared(waveClear.text));
            
        }*/
        
       
    }
    IEnumerator WaveCleared(string frase)
    {
        //waveClear.set = "";
        foreach (char letra in frase.ToCharArray())
        {
            //waveClear.text += letra;
            yield return null;
        }
        yield break;
    }
}

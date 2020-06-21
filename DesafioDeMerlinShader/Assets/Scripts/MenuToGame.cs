using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuToGame : MonoBehaviour
{
    [SerializeField] GameObject loadingSet;
    [SerializeField] RectTransform slider;

    [SerializeField] GameObject CREDITOS;
    bool isOnCredits;

    [SerializeField] GameObject thisGuy;
    [SerializeField] ParticleSystem manyParticles;
    // Start is called before the first frame update
    public void Tran_SITION(int index)
    {
        iTween.PunchScale(thisGuy, iTween.Hash("z", 10f, "amount", thisGuy.transform.localScale));
        loadingSet.SetActive(true);
        StartCoroutine(Transicao(index));
    }
    public void ShowCredits()
    {
        CREDITOS.SetActive(true);
        isOnCredits = true;
    }
    public void HideCredits()
    {
        CREDITOS.SetActive(false);
        isOnCredits = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FindObjectOfType<AudioManager>().Play("re");
            Tran_SITION(1);
        }
        if(Input.GetButtonDown("Fire1") && CREDITOS.activeInHierarchy)
        {
            HideCredits();
        }
    }
    IEnumerator Transicao(int buildNumber)
    {
        //var em = manyParticles.emission;
        //em.rateOverTime = 90;
        manyParticles.gameObject.SetActive(false);
        //slider.offsetMax += new Vector2(-10f * Time.deltaTime, slider.offsetMax.y);
        //print("Ema");
        yield return new WaitForSeconds(1f);
        AsyncOperation operacao = SceneManager.LoadSceneAsync(buildNumber);
        
        while (!operacao.isDone)
        {
            float progresso = Mathf.Clamp01(operacao.progress / 0.9f);
            slider.offsetMax -= new Vector2(progresso * -1500f * Time.deltaTime, slider.offsetMax.y);
            //xRect.x = Mathf.Clamp(xRect.x, 0f, 1366f);
            yield return null;
        }
        
    }
}

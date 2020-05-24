using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetScene : MonoBehaviour
{
    public GameObject player;
    // Update is called once per frame
    void Update()
    {
        if (!player.activeInHierarchy)
        {
            StartCoroutine(RestartTheGaym());
        }
    }
    IEnumerator RestartTheGaym()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

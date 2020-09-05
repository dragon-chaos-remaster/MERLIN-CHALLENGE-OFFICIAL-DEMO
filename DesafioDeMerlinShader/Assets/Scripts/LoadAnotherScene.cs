using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadAnotherScene : MonoBehaviour
{
    //[SerializeField] Scene cena;
    public void GoToMenuScene()
    {
        SceneManager.LoadScene(0);

    }

    public void GoToScene(int buildIndex)
    {
        SceneManager.LoadScene(buildIndex);
    }
}

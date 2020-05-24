using UnityEngine;
using System;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public Som[] sons;

    public static AudioManager instance;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        foreach (Som s in sons)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.clip = s.som;
        }
    }
    //Recebe o nome do Som/Música que deseja tocar (O nome precisa estar escrito IGUAL na janela do Inspector
    public void Play(string nome)
    {
        Som pointer = Array.Find(sons, som => som.nomeDoSom == nome);
        if(pointer == null)
        {
            Debug.LogError("Som " + nome + "não encontrado!!");
            return;
        }
        pointer.source.Play();
    }
}
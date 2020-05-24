using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public float intensidadeDoSlowMotion = 0.05f;
    public float duracaoDoSlowMotion = 2f;

    //[SerializeField]Pause pausou;

    void Update()
    {
        if (!Pause.pausado)
        {
            Time.timeScale += (1 / duracaoDoSlowMotion) * Time.unscaledDeltaTime;
            Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
        }
        else
        {
            Time.timeScale = 0f;
        }
    }
    public void FreezeFrame()
    {
        Time.timeScale = intensidadeDoSlowMotion;
        Time.fixedDeltaTime = Time.timeScale * .02f;
    }
}

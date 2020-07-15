using UnityEngine;

public class ControleJogador : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    float speedFixa;
    Rigidbody fisica;
    RaycastHit hit;
    Vector3 movimento;

    [SerializeField] string pisandoEmQueIlha;


    private Animator animator;
    public float duracaoSnare;
    float tempo;

    //ector3 posicaoDoMundo = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    void Start()
    {
        animator = GetComponent<Animator>();
        fisica = GetComponent<Rigidbody>();
        Cursor.visible = false;
        speedFixa = speed;
        //FindObjectOfType<AudioManager>().Play("mainTheme");
    }

    private void Update()
    {
        if (animator == null)
            return;
        float axisX = Input.GetAxisRaw("Vertical");
        float axixZ = Input.GetAxisRaw("Horizontal");

        movimento = new Vector3((axisX), movimento.y, -(axixZ));
        movimento = movimento.normalized * speed;
        fisica.velocity = new Vector3(movimento.x,fisica.velocity.y,movimento.z);

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 1000))
        {
            Vector3 playerToMouse = (hit.point - transform.position).normalized;
            playerToMouse.y = 0;
            Quaternion newRot = Quaternion.LookRotation(playerToMouse);
            fisica.MoveRotation(newRot);
        }

        PlayAnim(axisX, axixZ);

        if (speed == 0)
        {
            tempo += tempo * Time.deltaTime;
            if (tempo >= duracaoSnare)
            {
                FindObjectOfType<AudioManager>().Play("revertSnare");
                speed = speedFixa;
            }

        }

        if (speed != 0)
        {
            tempo = 1;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == pisandoEmQueIlha)
        {
            for (int i = 0; i < WaveSpawner.Instance.spawnPoints.Count; i++)
            {
                WaveSpawner.Instance.spawnPoints[i].position = transform.forward * 10;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "NaoSei")
        {
            FindObjectOfType<AudioManager>().Play("snare");
            speed = 0;
        }
    }

    void PlayAnim(float x, float y)
    {
        animator.SetFloat("VelX", x);
        animator.SetFloat("VelY", y);
    }
    // Update is called once per frame
    //void FixedUpdate()
    //{

    //    if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
    //    {
    //        Vector3 playerToMouse = hit.point - transform.position;
    //        playerToMouse.y = 0;
    //        Quaternion newRot = Quaternion.LookRotation(playerToMouse);
    //        fisica.MoveRotation(newRot);
    //    }
    //    //Apenas inverti os valores do movimento baseado no Angulo da Camera, se preferir que a camera fique do jeito Original, basta retirar as 2 barrinhas "//" da linha abaixo e apagar a linha invertida

    //    movimento = new Vector3((Input.GetAxisRaw("Horizontal")), 0f, (Input.GetAxisRaw("Vertical")));
    //    movimento = new Vector3((Input.GetAxisRaw("Vertical")), 0f, -(Input.GetAxisRaw("Horizontal")));
    //    movimento = movimento.normalized * speed * Time.fixedDeltaTime;
    //    fisica.MovePosition(transform.position + movimento);

    //}

}

using UnityEngine;
using System.Collections;

public class InstanciadorStars : MonoBehaviour {

    public GameObject[] objetos;

    private bool isEsquerda = true;
    public float velocidade = 5f;
    public float mxDelay;

    public float instanciadorTempo = 5f;
    public float instanciadorDelay = 3f;

    private float timeMovimento = 0f;
    private int valorMinimo = 0;
    // Use this for initialization
    void Start()
    {
        InvokeRepeating("Spawn", instanciadorTempo, instanciadorDelay);
    }

    // Update is called once per frame
    void Update()
    {
        Movimentar();
    }

    void Spawn()
    {
        //int index = Random.Range(valorMinimo, objetos.Length);
        Instantiate(objetos[0], transform.position, objetos[0].transform.rotation);
    }

    void Movimentar()
    {
        timeMovimento += Time.deltaTime;
        
        if (timeMovimento <= mxDelay)
        {

            if (isEsquerda)
            {
                
                transform.Translate(-Vector2.right * velocidade * Time.deltaTime);
                transform.eulerAngles = new Vector2(0, 0);
            }

            else
            {
                transform.Translate(-Vector2.right * velocidade * Time.deltaTime);
                transform.eulerAngles = new Vector2(0, 180);
            }
        }
        else
        {
            
            isEsquerda = !isEsquerda;
            timeMovimento = 0;
        }
    }
}


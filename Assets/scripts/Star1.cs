using UnityEngine;
using System.Collections;

public class Star1 : MonoBehaviour {


    private float timeVida;
    public float tempoMax;

    // Use this for initialization
    void Start()
    {
        timeVida = 0;
    }

    // Update is called once per frame
    void Update()
    {

        timeVida += Time.deltaTime;
        if (timeVida >= tempoMax)
        {
            Destroy(gameObject);
            timeVida = 0;
        }
    }

    void OnCollisionEnter2D(Collision2D colisor)
    {
        if (colisor.gameObject.tag == "Player")
        {
            ScoreManager.score += 5;
            Destroy(gameObject);
        }
    }
}

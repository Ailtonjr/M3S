using UnityEngine;
using System.Collections;


public class Inimigo : MonoBehaviour {
    public Transform inimigo;
    private Animator animator;
    public Transform head;
    static int atakState = Animator.StringToHash("Monstar_Morre");

    public static bool morto = false;

    public bool isDireita = true;
    public float velocidade = 5f;
    public float mxDelay;
    public bool andar = true;
    public bool isHead = false;

    private float timeMovimento = 0f;

    // Use this for initialization
    void Start()
    {
        animator = inimigo.GetComponent<Animator>();
		morto = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (andar)
        {
            Movimentar();
        }
        else if(morto)
        {
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("Restart"))
            {
                if (inimigo.tag == "InimigoB")
                {
                    ScoreManager.score += 10;
                    InstanciadorB.enemyQtdB--;
                    Destroy(gameObject);
                }
                if (inimigo.tag == "InimigoA")
                {
                    ScoreManager.score += 10;
                    InstanciadorA.enemyQtdA--;
                    Destroy(gameObject);
                }
            }
        }
    }

    void Movimentar()
    {
        isHead = Physics2D.Linecast(this.transform.position, head.position, 1 << LayerMask.NameToLayer("Player"));
		if (!isHead) {
			timeMovimento += Time.deltaTime;
			if (timeMovimento <= mxDelay) {
				if (isDireita) {
					transform.Translate (Vector2.right * velocidade * Time.deltaTime);
					transform.eulerAngles = new Vector2 (0, 0);
				} else {
					transform.Translate (Vector2.right * velocidade * Time.deltaTime);
					transform.eulerAngles = new Vector2 (0, 180);
				}
			} else {
				isDireita = !isDireita;
				timeMovimento = 0;
			}
        } else
        {
            animator.SetTrigger("morrer");
            morto = true;
            andar = false;
        }
    }

    void OnCollisionEnter2D(Collision2D colisor)
    {
        if (!isHead) {
			if (colisor.gameObject.tag == "Player") {
				var player = colisor.gameObject.transform.GetComponent<Player> ();
				player.PerdeVida (1);
				andar = false;
				animator.SetBool ("andar", false);
			}
		}
    }
}

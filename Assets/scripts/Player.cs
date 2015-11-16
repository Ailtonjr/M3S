using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour {
	
	public float velocidade;
	
	public Transform player;
	private Animator animator;
	
	public bool isGrounded;
	public float force;
	
	public float jumpTime = 0.4f;
	public float jumpDeley = 0.4f;
	public bool jumped;
	public Transform ground;
    public int vidaAtual;

	
	// Use this for initialization
	void Start () {
		animator = player.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if(vidaAtual > 0)
        {
            Movimentar();
        }
	}

    void Movimentar()
    {
        isGrounded = Physics2D.Linecast(this.transform.position, ground.position, 1 << LayerMask.NameToLayer("Plataforma"));

        animator.SetFloat("run", Mathf.Abs(Input.GetAxis("Horizontal")));


        if (Input.GetAxisRaw("Horizontal") > 0 && player.position.x < 5.4028)
        {
            transform.Translate(Vector2.right * velocidade * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 0);
        }

		if (Input.GetAxisRaw("Horizontal") < 0 && player.position.x > (-5.45))
        {
            transform.Translate(Vector2.right * velocidade * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 180);
        }

        if (Input.GetButtonDown("Jump") && isGrounded && !jumped)
        {
            GetComponent<Rigidbody2D>().AddForce(transform.up * force);
            jumpTime = jumpDeley;
            animator.SetTrigger("jump");
            jumped = true;
        }

        if (jumpTime > 0)
        {
            jumpTime -= Time.deltaTime;
        }

        if (jumpTime <= 0 && isGrounded && jumped)
        {
            animator.SetTrigger("ground");
            jumped = false;
        }
    }

    public void PerdeVida(int dano)
    {
        vidaAtual -= dano;

        if (vidaAtual <= 0)
        {
            animator.SetTrigger("death");
        }
    }
}
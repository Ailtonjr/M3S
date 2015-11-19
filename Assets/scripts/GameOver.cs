using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {
    public Player player;

    Animator anim;



	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	    if(player.vidaAtual <= 0)
        {
            anim.SetTrigger("GameOver");
        }
	}
}

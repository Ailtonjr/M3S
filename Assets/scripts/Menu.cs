using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {
    public Texture2D btnMenuPlay;
    public Texture2D titulo;
    public Texture2D btnVoltar;
    public GUISkin skinMenu;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {
        GUI.skin = skinMenu;

        GUI.DrawTexture(new Rect(Screen.width/2 - titulo.width/2,150,titulo.width,titulo.height),titulo);

        bool play = GUI.Button(new Rect(Screen.width - 164, Screen.height - 100, 64, 64), btnMenuPlay);

        bool exit = GUI.Button(new Rect(Screen.width - 100, Screen.height - 100, 64, 64), btnVoltar);

        if (play)
        {
            Application.LoadLevel("main_scene");
        }

        if (exit)
        {
            Application.Quit();
        }
    }
}

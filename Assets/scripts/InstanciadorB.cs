using UnityEngine;
using System.Collections;

public class InstanciadorB : MonoBehaviour {
	
	public Transform enemyPrefabB;
    public float spawnRate = 3f;
    public int minimo;
    public static int enemyQtdB = 1;

	// Use this for initialization
	void Start () {
        if(enemyQtdB < minimo)
        {
            Invoke("Spawn", spawnRate);
            enemyQtdB++;
        }
    }

    void Update()
    {
        if (enemyQtdB < minimo)
        {
            Invoke("Spawn", spawnRate);
            enemyQtdB++;
        }
    }
	
	void Spawn()
	{
        var enemyTransform = Instantiate(enemyPrefabB) as Transform;
        enemyTransform.position = transform.position;
		enemyTransform.tag = "InimigoB";
	}
}


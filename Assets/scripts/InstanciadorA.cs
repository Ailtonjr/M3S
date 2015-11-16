using UnityEngine;
using System.Collections;

public class InstanciadorA : MonoBehaviour {


    public Transform enemyPrefabA;
    public float spawnRate = 3f;
    public int minimo;
    public static int enemyQtdA = 1;

    // Use this for initialization
    void Start()
    {
        if (enemyQtdA < minimo)
        {
            Invoke("Spawn", spawnRate);
            enemyQtdA++;
        }
    }

    void Update()
    {
        if (enemyQtdA < minimo)
        {
            Invoke("Spawn", spawnRate);
            enemyQtdA++;
        }
    }

    void Spawn()
    {
        var enemyTransform = Instantiate(enemyPrefabA) as Transform;
        enemyTransform.position = transform.position;
        enemyTransform.tag = "InimigoA";
    }
}

using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float minHeight, maxHeight;
    [SerializeField] private GameObject[] prefabs;
    [SerializeField] private float spawnTime, maxSpeed, decreaseSpeed;
    [SerializeField] private int numSpawnsToGhangeSpeed;

    private int numSpawns;

    void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            int randomIndex = Random.Range(0,prefabs.Length);
            
            // Creacion del objeto
            Instantiate(prefabs[randomIndex],GetRandomPosition(), Quaternion.identity);
            numSpawns++;
            // Aumento de la velocidad
            IncreaseSpeed();
            yield return new WaitForSeconds(spawnTime);

        }
    }

    private void IncreaseSpeed()
    {
        if (numSpawns % numSpawnsToGhangeSpeed == 0)
        {
            spawnTime -= decreaseSpeed;
            if (spawnTime <= maxSpeed)
            {
                spawnTime = maxSpeed;
            }
        }
    }

    private Vector2 GetRandomPosition()
    {
        // Altura aleatoria
        float randomHeight = Random.Range(minHeight, maxHeight);
        // vector con la posicion en x del spawner y la altura aleatoria
        Vector2 randomPosition = new Vector2(transform.position.x, randomHeight);
        return randomPosition;
    }

    public void StopSpawn()
    {
        StopAllCoroutines();
    }
}

using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject powerupPrefab;
    [SerializeField] private GameObject enemyPrefab;
   
    private void Start()
    {
        StartCoroutine(EnemySpawnRoutine());
        StartCoroutine(PowerupSpawnRoutine());
    }
    IEnumerator EnemySpawnRoutine()
    {
            while(true)
            {
                Instantiate(enemyPrefab, new Vector3(Random.Range(-1.8f,1.8f), 5.50f, 0), Quaternion.identity);
                yield return new WaitForSeconds(2.0f);
            }    
    }

    IEnumerator PowerupSpawnRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(15.0f);
            Instantiate(powerupPrefab, new Vector3(Random.Range(-2.1f, 2.10f), 5.40f, 0), Quaternion.identity);
        }
    }



}

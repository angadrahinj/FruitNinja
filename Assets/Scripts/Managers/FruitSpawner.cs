using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class FruitSpawner : MonoBehaviour
{
    private BoxCollider spawnArea;

    public GameObject[] fruitPrefabs;

    public GameObject bombPrefab;

    [Range(0f, 1f)]    
    public float bombChance = 0.05f;

    public float minSpawnDelay = 0.25f;
    public float maxSpawnDelay = 1f;

    public float minAngle = -15f;
    public float maxAngle = 15f;

    public float minForce = 18f;
    public float maxForce = 22f;

    public float maxLifetime = 5f;


    private void Awake()
    {
        spawnArea = GetComponent<BoxCollider>();
    }

    private void OnEnable()
    {
        StartCoroutine(SpawnFruit());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    private IEnumerator SpawnFruit()
    {
        yield return new WaitForSeconds(2f);

        

        while (enabled)
        {
            GameObject prefab = fruitPrefabs[Random.Range(0, fruitPrefabs.Length)];

            if (Random.value < bombChance)
            {
                prefab = bombPrefab;
            }

            Vector3 spawnPosition = FindRandomSpawnPoint();
            Quaternion rotation = Quaternion.Euler(0f, 0f, Random.Range(minAngle, maxAngle));

            GameObject fruit = Instantiate(prefab, spawnPosition, rotation);
            Destroy(fruit, maxLifetime);

            float force = Random.Range(minForce, maxForce);
            fruit.GetComponent<Rigidbody>().AddForce(fruit.transform.up * force, ForceMode.Impulse);

            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
        }
    }

    private Vector3 FindRandomSpawnPoint()
    {
        Vector3 spawnPosition = new Vector3();
        spawnPosition.x = Random.Range(spawnArea.bounds.max.x, spawnArea.bounds.min.x);
        spawnPosition.y = Random.Range(spawnArea.bounds.max.y, spawnArea.bounds.min.y);
        spawnPosition.z = Random.Range(spawnArea.bounds.max.z, spawnArea.bounds.min.z);

        return spawnPosition;
    }
}

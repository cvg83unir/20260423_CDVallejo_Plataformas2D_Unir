using System;
using System.Collections;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] GameObject enemyPreFab;
    [SerializeField] float timeBetweenEnemies = 4f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(GenerateEnemies());   
    }

    IEnumerator GenerateEnemies()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeBetweenEnemies);
            GameObject newEnemy = Instantiate(enemyPreFab, transform.position, Quaternion.identity);
            newEnemy.GetComponent<AIControl>().SetTarget(target);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

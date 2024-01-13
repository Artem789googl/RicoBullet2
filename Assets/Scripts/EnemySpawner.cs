using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // ссылка на префаб врага
    public int numberOfEnemies = 3; // количество врагов для создания
    public float spawnDelay = 1.0f; // задержка между созданием врагов

    private void Start()
    {
        // Вызываем метод для создания врагов с заданной задержкой
        InvokeRepeating("SpawnEnemy", 0f, spawnDelay);
    }

    private void SpawnEnemy()
    {
        // Получаем размеры BoxCollider2D
        BoxCollider2D collider = GetComponent<BoxCollider2D>();
        Vector2 colliderSize = collider.bounds.size;

        // Получаем центр BoxCollider2D
        Vector2 colliderCenter = collider.bounds.center;

        // Создаем врага в зоне появления
        Vector2 spawnPosition = new Vector2(
            Random.Range(colliderCenter.x - colliderSize.x / 2f, colliderCenter.x + colliderSize.x / 2f),
            Random.Range(colliderCenter.y - colliderSize.y / 2f, colliderCenter.y + colliderSize.y / 2f)
        );

        GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

        // Уменьшаем количество врагов, если нужно
        numberOfEnemies--;

        // Если создали все враги, отменяем вызов метода
        if (numberOfEnemies <= 0)
        {
            CancelInvoke("SpawnEnemy");
        }
    }
}


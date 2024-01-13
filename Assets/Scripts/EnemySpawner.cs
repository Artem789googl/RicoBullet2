using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // ������ �� ������ �����
    public int numberOfEnemies = 3; // ���������� ������ ��� ��������
    public float spawnDelay = 1.0f; // �������� ����� ��������� ������

    private void Start()
    {
        // �������� ����� ��� �������� ������ � �������� ���������
        InvokeRepeating("SpawnEnemy", 0f, spawnDelay);
    }

    private void SpawnEnemy()
    {
        // �������� ������� BoxCollider2D
        BoxCollider2D collider = GetComponent<BoxCollider2D>();
        Vector2 colliderSize = collider.bounds.size;

        // �������� ����� BoxCollider2D
        Vector2 colliderCenter = collider.bounds.center;

        // ������� ����� � ���� ���������
        Vector2 spawnPosition = new Vector2(
            Random.Range(colliderCenter.x - colliderSize.x / 2f, colliderCenter.x + colliderSize.x / 2f),
            Random.Range(colliderCenter.y - colliderSize.y / 2f, colliderCenter.y + colliderSize.y / 2f)
        );

        GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

        // ��������� ���������� ������, ���� �����
        numberOfEnemies--;

        // ���� ������� ��� �����, �������� ����� ������
        if (numberOfEnemies <= 0)
        {
            CancelInvoke("SpawnEnemy");
        }
    }
}


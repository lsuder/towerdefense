using System;
using System.Collections;
using UnityEngine;
using TMPro;

public class WaveSpawner : MonoBehaviour {
    public Transform enemyPrefab;
    public Transform spawnPoint;
    public float timeBetweenWaves = 5.5f;
    public float spawnEnemyTime = 0.4f;
    public TMP_Text countdownText;
    private float countdown = 2f;
    private int enemiesCount = 1;

    // Update is called once per frame
    void Update() {
        

        if (countdown <= 0) {
            SpawnWave();
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;
        countdownText.text = Mathf.Round(countdown).ToString();
    }

    private void SpawnWave() {
        for (int i = 0; i < enemiesCount; i++) {
            StartCoroutine(SpawnEnemy(i));
        }

        enemiesCount++;
    }

    private IEnumerator SpawnEnemy(int i) {
        yield return new WaitForSeconds(spawnEnemyTime * i);
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}

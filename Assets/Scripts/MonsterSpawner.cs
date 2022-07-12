using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> _monsters;

    [SerializeField] private Transform _observerPosition;

    [SerializeField] private List<GameObject> _spawnedMonsters;

    private bool isSpawnEnable = true;

    public static Action OnMonsterSpawned;

    private void Start()
    {
        GameController.KillAllMonsters += DestroyMonsters;
        GameController.KillAllMonsters += StopSpawningMonsters;

        GameController.BoosterKillAll += DestroyMonsters;
        GameController.BoosterStopSpawnigFor5sec += StartStopSpawningMonsters;
    }

    public void StartSpawningMonsters()
    {
        isSpawnEnable = true;
        StartCoroutine(SpawnMonsterWithRandomInterval());
    }

    private IEnumerator SpawnMonsterWithRandomInterval()
    {
        if (isSpawnEnable)
        {
            float difficultyDelta = GameController.DifficultyLevel * 0.1f;

            float interval = Random.Range(2f - difficultyDelta, 4f - difficultyDelta);

            yield return new WaitForSeconds(interval);

            SpawnMonster();

            StartCoroutine(SpawnMonsterWithRandomInterval());
        }
    }

    private void StopSpawningMonsters()
    {
        isSpawnEnable = false;
    }

    private void SpawnMonster()
    {
        Quaternion _rotation = Quaternion.Euler(0f, 0f, 0f);
        GameObject spawnedMoster =  Instantiate(randomMonsterFromList(), RandomPosition(), _rotation);
        spawnedMoster.transform.LookAt(_observerPosition);

        _spawnedMonsters.Add(spawnedMoster);

        OnMonsterSpawned?.Invoke();
    }

    private void StartStopSpawningMonsters()
    {
        StartCoroutine(StopSpawningMonstersFor5sec());
    }

    private IEnumerator StopSpawningMonstersFor5sec()
    {
        isSpawnEnable = false;

        yield return new WaitForSeconds(5);

        isSpawnEnable = true;

        StartCoroutine(SpawnMonsterWithRandomInterval());
    }

    private void DestroyMonsters()
    {
        foreach (var monster in _spawnedMonsters)
        {
            Destroy(monster);
        }

        _spawnedMonsters.Clear();
    }

    private GameObject randomMonsterFromList()
    {
        int monsterNumber = Random.Range(0, _monsters.Count);

        return _monsters[monsterNumber];
    }

    private Vector3 RandomPosition()
    {
        float x = Random.Range(3.32f, 3.9f);
        float z = Random.Range(-0.8f, -0.3f);
        float y = 0.82f;

        return new Vector3(x, y, z);
    }

}

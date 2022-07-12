using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public sealed class GameController: MonoBehaviour 
{
    [SerializeField] private LeaderBoard _leaderBoard;
    [SerializeField] private TMP_InputField _playerName;
    [SerializeField] private List<GameObject> _boosters;

    private static int _gameScore;
    private static int _monsterCount;
    private static int _difficultyLevel;

    public static int GameScore { get => _gameScore; }
    public static int DifficultyLevel { get => _difficultyLevel; }

    private const int DIFFICULTY_EDGE = 100;
    private const int SCORE_FOR_ONE_MONSTER = 10;
    private const int ENDGAME_QUANTITY_OF_MONSTERS = 10;

    public UnityEvent OnGameEnd;
    public static Action GameGonnaHarder;
    public static Action KillAllMonsters;
    public static Action OnLeaderBoardAdd;
    public static Action BoosterKillAll;
    public static Action BoosterStopSpawnigFor5sec;

    private void Start()
    {
        MonsterSpawner.OnMonsterSpawned += IncreaseMonstersCount;
        Monster.OnMonsterDead += DecreaseMonstersCount;
    }

    private void IncreaseMonstersCount()
    {
        _monsterCount++;

        if (_monsterCount >= ENDGAME_QUANTITY_OF_MONSTERS)
        {
            OnGameEnd?.Invoke();
            KillAllMonsters.Invoke();

            _monsterCount = 0;
            _difficultyLevel = 0;
        }
    }

    private void DecreaseMonstersCount()
    {
        _monsterCount--;
        _gameScore += SCORE_FOR_ONE_MONSTER;

        if (_gameScore >= DIFFICULTY_EDGE && ((_gameScore % DIFFICULTY_EDGE) == 0))
        {
            _difficultyLevel++;

            GiveRandomBooster();
        }
    }

    public void AddInLeaderboard()
    {
        if (_playerName.text == "")
        {
            _leaderBoard.Leaders.Add("NoName" + " " + GameScore.ToString());
        }
        else
        {
            _leaderBoard.Leaders.Add(_playerName.text + " " + GameScore.ToString());
        }

        _gameScore = 0;

        OnLeaderBoardAdd?.Invoke();
    }

    private void GiveRandomBooster()
    {
        int randomMonsterNumber = Random.Range(0, _boosters.Count);

        if (_boosters[randomMonsterNumber].activeInHierarchy == true)
        {
            GiveRandomBooster();
        }
        else
        {
            _boosters[randomMonsterNumber].SetActive(true);
        }
    }

    public void KilAllByBooster()
    {
        BoosterKillAll?.Invoke();

        _monsterCount = 0;
    }

    public void StopSpawningByBooster()
    {
        BoosterStopSpawnigFor5sec?.Invoke();
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}

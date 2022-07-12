using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedMonster : Monster
{
    private void Start()
    {
        _health = 30 + GameController.DifficultyLevel * 10;
    }
}

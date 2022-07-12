using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueMonster : Monster
{
    private void Start()
    {
        _health = 50 + GameController.DifficultyLevel * 10;
    }

}

using System;
using UnityEngine;

public abstract class Monster : MonoBehaviour
{
    protected int _health;

    public static Action OnMosnterPunched;
    public static Action OnMonsterDead;

    protected void OnMouseDown()
    {
        ReduceMosterHealth();
    }

    protected void ReduceMosterHealth()
    {
        _health -= 10;

        OnMosnterPunched?.Invoke();

        if (_health < 0)
        {
            DestroyMonster();
        }
    }

    protected void DestroyMonster()
    {
        OnMonsterDead?.Invoke();
        Destroy(gameObject);
    }
}

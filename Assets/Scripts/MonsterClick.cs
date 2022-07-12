using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider))]
public class MonsterClick : MonoBehaviour
{
    public UnityEvent click = new UnityEvent();

    private void OnMouseDown()
    {
        click.Invoke();
    }
}

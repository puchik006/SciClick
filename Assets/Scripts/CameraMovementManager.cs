using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementManager : MonoBehaviour
{
    [SerializeField] private List<Transform> _cameraPositionsList;

    public void MoveCameraToPosition(int cameraPos)
    {
        Camera.main.transform.position = _cameraPositionsList[cameraPos].position;
        Camera.main.transform.rotation = _cameraPositionsList[cameraPos].rotation;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow1 : MonoBehaviour
{
    public Transform target;
    

    private void Start() =>
        target = GameManager.instance.player.transform;

    private void LateUpdate()
    { 
        transform.position = new Vector3(target.position.x, transform.position.y, transform.position.z);
    }
}

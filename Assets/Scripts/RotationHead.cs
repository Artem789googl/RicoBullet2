using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationHead : MonoBehaviour
{
    [SerializeField] private Transform Head;

    void Update()
    {
        var direction = Head.position - transform.position;
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
        
    }
}

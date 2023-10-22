using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField][Range(1f, 5f)] private float _angularSpeed = 1f;
    [SerializeField] private Transform _target;

    private float _angleY;

    private void Start()
    {
        _angleY = transform.position.y;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.E))
            _angleY -= _angularSpeed;

        if (Input.GetKey((KeyCode.Q)))
            _angleY += _angularSpeed;

        transform.position = _target.transform.position;
        transform.rotation = Quaternion.Euler(0, _angleY, 0);


    }
}

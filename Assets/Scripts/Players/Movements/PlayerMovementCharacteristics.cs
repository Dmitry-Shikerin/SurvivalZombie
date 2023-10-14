using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Characteristics", menuName = "Movement/MovementCharacteristics", order = 51)]
public class PlayerMovementCharacteristics : ScriptableObject
{
    [SerializeField] private bool _cursorVisible = true;
    [SerializeField] private float _movementSpeed = 1f;
    [SerializeField] private float _runSpeed = 3f;
    [SerializeField] private float _angularSpeed = 150f;
    [SerializeField] private float _gravity = 2f;

    public bool CursorVisible => _cursorVisible;
    public float MovementSpeed => _movementSpeed;
    public float RunSpeed => _runSpeed;
    public float AngularSpeed => _angularSpeed;
    public float Gravity => _gravity;
}

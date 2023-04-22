using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/**
 * This component moves its object when the player clicks the arrow keys.
 * Part of this code is from the Ex4_A project by our instructor.
 */
public class InputMover : MonoBehaviour
{
    [Tooltip("Speed of movement, in meters per second")]
    [SerializeField]
    float speed = 10f;

    [SerializeField]
    GameObject topRightLimitGameObject;

    [SerializeField]
    GameObject bottomLeftLimitGameObject;

    [SerializeField]
    InputAction moveHorizontal = new InputAction(type: InputActionType.Button);

    [SerializeField]
    InputAction moveVertical = new InputAction(type: InputActionType.Button);

    private Vector3 topRightLimit;
    private Vector3 bottomLeftLimit;

    void Start()
    {
        bottomLeftLimit = bottomLeftLimitGameObject.transform.position;
        topRightLimit = topRightLimitGameObject.transform.position;
    }

    void OnEnable()
    {
        moveHorizontal.Enable();
        moveVertical.Enable();
    }

    void OnDisable()
    {
        moveHorizontal.Disable();
        moveVertical.Disable();
    }

    void Update()
    {
        float horizontal = moveHorizontal.ReadValue<float>();
        float vertical = moveVertical.ReadValue<float>();
        if ((transform.position.x <= bottomLeftLimit.x))
        {
            horizontal = 1;
        }
        if ((transform.position.y <= bottomLeftLimit.y))
        {
            vertical = 1;
        }
        if ((transform.position.x >= topRightLimit.x))
        {
            horizontal = -1;
        }
        if ((transform.position.y >= topRightLimit.y))
        {
            vertical = -1;
        }
        Vector3 movementVector = new Vector3(horizontal, vertical, 0) * speed * Time.deltaTime;
        transform.position += movementVector;
    }
}

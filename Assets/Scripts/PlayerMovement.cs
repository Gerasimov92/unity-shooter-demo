using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private static readonly int X = Animator.StringToHash("X");
    private static readonly int Y = Animator.StringToHash("Y");

    private Animator _animator;
    private Camera _mainCamera;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _mainCamera = Camera.main;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        Vector2 input;
        input.x = Input.GetAxis("Horizontal");
        input.y = Input.GetAxis("Vertical");
        _animator.SetFloat(X, input.x);
        _animator.SetFloat(Y, input.y);

        if (input.sqrMagnitude < 0.01) return;

        var targetDirection = CalcTargetDirection(input).normalized;
        UpdateRotation(targetDirection);
    }

    private Vector3 CalcTargetDirection(Vector2 input)
    {
        var forward = _mainCamera.transform.TransformDirection(Vector3.forward);
        forward.y = 0;
        var right = _mainCamera.transform.TransformDirection(Vector3.right);
        return input.x * right + input.y * forward;
    }

    private void UpdateRotation(Vector3 direction)
    {
        var freeRotation = Quaternion.LookRotation(direction, transform.up);
        var differenceRotation = freeRotation.eulerAngles.y - transform.eulerAngles.y;
        var eulerY = transform.eulerAngles.y;

        if (differenceRotation < 0 || differenceRotation > 0) eulerY = freeRotation.eulerAngles.y;
        var euler = new Vector3(0, eulerY, 0);

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(euler), 10 * Time.deltaTime);
    }
}

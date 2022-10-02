using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class TeleportToBall : MonoBehaviour
{
    [SerializeField] Transform _ball;
    [SerializeField] Transform _headset;
    [SerializeField] Transform _rightHand;
    [SerializeField] float slowDown;

    Rigidbody _rb;
    [SerializeField] InputActionProperty grabActionRight;
    [SerializeField] InputActionProperty grabActionLeft;

    void Start()
    {
        grabActionRight.action.started += TeleportPlayerToBall;
        _rb = GetComponent<Rigidbody>();
    }

    private void TeleportPlayerToBall(InputAction.CallbackContext obj)
    {
        Debug.Log("Teleportig");
        transform.position = _ball.position;
        _rb.velocity = _ball.GetComponent<Rigidbody>().velocity;
        _ball.position = _rightHand.position;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _rb.velocity = new Vector3(_rb.velocity.x * slowDown, _rb.velocity.y, _rb.velocity.z * slowDown);
    }
}

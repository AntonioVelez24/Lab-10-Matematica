using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody _rigidbody;
    private float direction;
    // Start is called before the first frame update
    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector2(speed * direction, _rigidbody.velocity.y);
    }
    public void ReadMovement(InputAction.CallbackContext context)
    {
        direction = context.ReadValue<float>();
    }
}

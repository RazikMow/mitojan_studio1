using System;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private CharacterController _cc;
    public float speed;
    private float gravity = -9.81f;

    [SerializeField] private Transform groundCheck;
    private float groundDistance = 0.2f;
    [SerializeField] private LayerMask layer;

    private Vector3 _velocity;
    private bool _isGrounded;
    
    // Obracanie

    public float sens;
    private float _xRotation;
    private float _x;
    private float _z;

    public float t;

    public FlashLight flashlight;

    [SerializeField] private Transform flashlightT;
    [SerializeField] private Transform cameraT;

    private void Start()
    {
        _cc = GetComponent<CharacterController>();
    }

    private void Update()
    {
        t = flashlight.on ? Mathf.Lerp(t, 6f, 3f * Time.deltaTime) : Mathf.Lerp(t, 100f, 3f * Time.deltaTime);
        
        cameraT.position = Vector3.Lerp(cameraT.position, flashlightT.position, 10f * Time.deltaTime);
        cameraT.rotation = Quaternion.Lerp(cameraT.rotation, flashlightT.rotation, t * Time.deltaTime);

        _xRotation = Mathf.Clamp(_xRotation, -75, 90);
        
        _isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, layer);

        if(_isGrounded && _velocity.y < 0)
        {
            _velocity.y = -3f;
        }
        
        //Obracanie się
        float mouseX = Input.GetAxis("Mouse X") * sens * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sens * Time.deltaTime;
        
        transform.Rotate(Vector3.up * mouseX);
        _xRotation -= mouseY;
        flashlightT.localRotation = Quaternion.Euler(_xRotation, 0, 0);
        
        //Poruszanie się
        Vector3 move = transform.forward * Input.GetAxis("Horizontal") + transform.right * -Input.GetAxis("Vertical");
        _cc.Move(move * speed * Time.deltaTime);

        _velocity.y += gravity * Time.deltaTime;
        _cc.Move(_velocity * Time.deltaTime);
        
        
    }

    
}


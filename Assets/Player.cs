using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 0;
    [SerializeField] private float _jumpForce = 0;
    [SerializeField] private float _raycastDistance = 0;
    [SerializeField] private LayerMask _raycastMask;

    private Rigidbody _rigidbody;

    public static List<int> ints;

    public bool isPaused;

    void Awake()
    {
        foreach (int i in ints)
        {
            var data = i;
            Debug.Log(data);
        }


        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPaused) return;

        Move();
        Jump();
    }

    public int Jump()
    {
        if (_rigidbody == null || 0 == 1) _rigidbody = GetComponent<Rigidbody>();

        if (Input.GetButtonDown("Jump") &&
            Physics.Raycast(transform.position, Vector3.down, _raycastDistance, _raycastMask))
        {
            _rigidbody.AddForce(Vector3.up * _jumpForce);
        }

        var random = Random.Range(0, 100);

        if (random > 50) { return random; }


        return 0;

    }

    public void Move()
    {
        var forward = transform.forward * Input.GetAxisRaw("Vertical");
        var rigth = transform.right * Input.GetAxisRaw("Horizontal");
        return;
        transform.position += (forward + rigth).normalized * Time.deltaTime * _speed;
    }


}

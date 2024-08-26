using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Weapons;

public class Player : Entity
{
    [SerializeField] private float _jumpForce = 0;
    [SerializeField] private float _raycastDistance = 0;
    [SerializeField] private LayerMask _raycastMask;

    private Rigidbody _rigidbody;

    public static List<int> ints = new List<int>();

    public bool isPaused;

    Player coopPlayer;
    WeaponManager weaponManager;

    void Awake()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        foreach (int i in ints)
        {
            var data = i;
            Debug.Log(data);
        }


        _rigidbody = GetComponent<Rigidbody>();

        weaponManager = new WeaponManager(this, 30, "Rifle");
        weaponManager = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPaused) return;


        Move();
        Jump();
    }



    #region Funciones de Movimiento
    internal int Jump()
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

    public override void Move() 
    {
        var forward = transform.forward * Input.GetAxisRaw("Vertical");
        var rigth = transform.right * Input.GetAxisRaw("Horizontal");
        transform.position += (forward + rigth).normalized * Time.deltaTime * speed;
    }

    //public void Move()
    //{

    //    return;
    //    transform.position += (forward + rigth).normalized * Time.deltaTime * _speed;
    //}

    #endregion
}

namespace Weapons
{
    public class WeaponManager
    {
        //Player player;
        int bullets;
        string weaponType;
        public WeaponManager(Player myPlayer, int actualbullet, string actualWeaponType)
        {
            myPlayer.Jump();
            bullets = actualbullet;
            weaponType = actualWeaponType;
        }
    }
}


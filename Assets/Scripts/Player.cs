using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Weapons;

public class Player : Entity, IDamagable
{
    [SerializeField] private float _jumpForce = 0;
    [SerializeField] private float _raycastDistance = 0;
    [SerializeField] private LayerMask _raycastMask;

    [SerializeField] private Transform _footTransform;

    [SerializeField] private Weapon _fist;

    private Rigidbody _rigidbody;

    public static List<int> ints = new List<int>();

    public bool isPaused;

    Player coopPlayer;
    WeaponManager weaponManager;

    public float Life 
    {
        get 
        {
            return life;
        }
        private set 
        {
            if (value > maxLife)
            {
                life = maxLife;
            }
            else
            {
                life = value;
            }
        }
    }

    public float GetLife { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

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

        weaponManager = new WeaponManager(this, _fist);
    }

    void Update()
    {
        if (isPaused) return;


        Move();
        Jump();

        if (Input.GetMouseButtonDown(0))
            weaponManager.Shoot();

        //LoQueSea(5f, 10, "A", "B", "C");
        //LoQueSea(5f);

        string myName = "";
        float damage= 10;
        if(LoQueSea(out myName, damage))
        {
            Debug.Log("Aca");
        }
    }

    public bool LoQueSea(out string name, float dmg, int life = 0, params string[] strings)
    {
        name = "Maine";
        dmg = 0f;

        return true;
    }

    public void LoQueSea()
    {

    }

    private void Die()
    {
        GameManager.LoadLevel("Main Menu");
    }

    public void ReciveDamage(float damage)
    {
        Life -= damage;

        if (Life < 0) Die();
    }



    #region Funciones de Movimiento
    internal int Jump()
    {
        if (_rigidbody == null || 0 == 1) _rigidbody = GetComponent<Rigidbody>();

        if (Input.GetButtonDown("Jump") &&
              Physics.Raycast(_footTransform.position, Vector3.down, _raycastDistance, _raycastMask))
        {
            var actualVelocity = _rigidbody.velocity;
            actualVelocity.y = 0;
            _rigidbody.velocity = actualVelocity;
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

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(_footTransform.position, _footTransform.position + Vector3.down * _raycastDistance);
    }

    public void Health(float damage)
    {
        throw new System.NotImplementedException();
    }

    public override void Attack()
    {
        
    }
}
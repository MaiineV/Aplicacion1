using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
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

    public delegate void MovementDelegate();
    public MovementDelegate movement = delegate { };

    public Action<float> Damage = delegate { };

    public Func<float, float, bool> CalculateMax;

    private Vector3 velocity;

    private Plataform actualPlataform;

    private LinkedList<string> namesList;



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
        namesList = new LinkedList<string>("Pepe");

        movement += Move;
        movement += Jump;

        Damage = TakeDamage;

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

        movement();

        #region Keycodes
        if (Input.GetKeyDown(KeyCode.P))
        {
            movement = AirMovement;

        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            movement = Move;
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            Damage = delegate { };
            StartCoroutine(WaitNoDamage());
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            Damage(10f);
        }

        if (Input.GetMouseButtonDown(0))
            weaponManager.Shoot();

        if (Input.GetMouseButtonDown(1))
        {
            namesList.Add("Pepe" + UnityEngine.Random.Range(0,100));
        }



        #endregion

        string myName = "";
        float damage = 10;
        if (LoQueSea(out myName, damage))
        {
            //Debug.Log("Aca");
        }
    }

    public void AddItems(List<Item> newItems) { }


    IEnumerator WaitNoDamage() 
    {
        yield return new WaitForSeconds(1);
        Damage = TakeDamage;
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
        Damage(damage);
    }

    private void TakeDamage(float damage)
    {
        Life -= damage;

        if (Life < 0) Die();

        EventManager.Trigger(EventType.OnPlayerDamage, Life);
    }



    #region Funciones de Movimiento
    internal void Jump()
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
    }

    public override void Move()
    {
        var forward = transform.forward * Input.GetAxisRaw("Vertical");
        var rigth = transform.right * Input.GetAxisRaw("Horizontal");
        velocity = (forward + rigth).normalized * speed;

        if (actualPlataform != null)
        {
            velocity += actualPlataform.dir;
        }
        velocity.y = _rigidbody.velocity.y;
        _rigidbody.velocity = velocity;
    }

    private void AirMovement()
    {
        var forward = transform.forward * Input.GetAxisRaw("Vertical");
        var rigth = transform.up * Input.GetAxisRaw("Horizontal");
        transform.localPosition += (forward + rigth).normalized * Time.deltaTime * speed;
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

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Plataform")) return;

        var plataform = other.GetComponent<Plataform>();

        if (plataform == null) return;

        actualPlataform = plataform;
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Plataform")) return;

        var plataform = other.GetComponent<Plataform>();

        if (plataform == null || plataform != actualPlataform) return;

        actualPlataform = null; 
    }
}
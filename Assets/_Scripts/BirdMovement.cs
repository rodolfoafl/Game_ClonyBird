using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BirdMovement : MonoBehaviour {

	Vector3 velocity = Vector3.zero;

    public float forwardSpeed = 1f;
    public float flapSpeed = 9.8f;

    private bool _didFlap = false;
    private bool _dead = false;
    private float _deathCooldown;

    private Rigidbody2D _rb2d;
    private Animator _animator;
    private Transform _birdSprite;

    public Animator Animator
    {
        get
        {
            return _animator;
        }
    }

    public bool Dead
    {
        get
        {
            return _dead;
        }

        set
        {
            _dead = value;
        }
    }

    public float DeathCooldown
    {
        get
        {
            return _deathCooldown;
        }

        set
        {
            _deathCooldown = value;
        }
    }

    // Use this for initialization
    void Start () {
        _rb2d = GetComponent<Rigidbody2D>();
        _animator = GetComponentInChildren<Animator>();
        _birdSprite = transform.GetChild(0);

    }

    void Update() {
        if (_dead)
        {
            _deathCooldown -= Time.deltaTime;
            if (_deathCooldown <= 0)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                }
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _didFlap = true;
            }
        }
    }

    void FixedUpdate() {
        if (_dead)
        {
            return;
        }

        _rb2d.AddForce(Vector2.right * forwardSpeed);

        if (_didFlap)
        {
            _rb2d.AddForce(Vector2.up * flapSpeed);

            _animator.SetTrigger("Flap");
            _didFlap = false;
        }

        if (_rb2d.velocity.y > 0) {
            _birdSprite.rotation = Quaternion.Euler(Vector3.zero);
        } else
        {
            float angle = Mathf.Lerp(0, -90, -_rb2d.velocity.y / 3f);
            _birdSprite.rotation = Quaternion.Euler(0, 0, angle);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGParallax : MonoBehaviour {

    private Rigidbody2D _player;

    [SerializeField] float velocity;

    void Start()
    {
        Rigidbody2D player_rb2d = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();

        if (player_rb2d == null)
        {
            Debug.Log("Couldn't find an object with tag 'Player'!");
            return;
        }

        _player = player_rb2d;
    }

    void FixedUpdate() {
        float vel = _player.velocity.x * velocity;
        transform.position = transform.position + Vector3.right * vel * Time.deltaTime;
    }
}

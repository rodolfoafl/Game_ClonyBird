using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathOnCollision : MonoBehaviour {

    private BirdMovement _bdm;

    void Awake() {
        _bdm = GetComponent<BirdMovement>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        _bdm.Animator.SetTrigger("Death");
        _bdm.Dead = true;
        _bdm.DeathCooldown = 0.5f;
    }
}

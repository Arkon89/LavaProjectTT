using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Animator))]
public class CharHP : MonoBehaviour
{
    private bool _isDead = false;
    private int _charHealth = 100;
    private Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void GetDamage()
    {
        if(_isDead)
            return;

        if(_charHealth > 0)
        {
            _charHealth -= 100;
        }

        if(_charHealth <= 0)
        {
            _charHealth = 0;
            Death();
        }
    }

    private void Death()
    {
        _animator.enabled = false;
        Time.timeScale = 0.5f;
    }
}

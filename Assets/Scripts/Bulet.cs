using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class Bulet : MonoBehaviour
{
    private Vector3 _basePosition;
    private Rigidbody _rigidbody;
    [SerializeField] private float _speed = 1f;
    [SerializeField] private BulletPower _bulletPower;

    private void Start() 
    {
        _basePosition = transform.position;
        _rigidbody = GetComponent<Rigidbody>();
    }
    private void GoBackToPool()
    {
        transform.position = _basePosition;
        _rigidbody.velocity = Vector3.zero;
    }

    private void OnCollisionEnter(Collision other) {
        CharHP charHP = other.collider.GetComponentInParent<CharHP>();
        if(charHP != null)
        {            
            Vector3 direction = GetDirection(other.transform.position);
            charHP.GetDamage();
            if(other.gameObject.TryGetComponent(out Rigidbody rigidbody))
            {
                rigidbody.AddForce(direction * _bulletPower._power, ForceMode.Impulse);
                Debug.DrawRay(other.gameObject.transform.position, direction, Color.green, 3f);
            }                      
        }
        Debug.Log(other.collider);
        GoBackToPool();
    }

    public void Shooting(Vector3 tatgetPosition)
    {        
        Vector3 direction = GetDirection(tatgetPosition);        
        _rigidbody.velocity = direction * _speed;
    }

    private Vector3 GetDirection(Vector3 tatgetPosition)
    {
        return tatgetPosition - transform.position;
    }

    
}

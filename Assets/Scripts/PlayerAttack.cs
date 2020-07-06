using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerAttack : MonoBehaviour
{
    Camera _camera;
    void Start()
    {
        _camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonUp(0))
        {
            Attack();
        }
    }

    private void Attack()
    {
        int characterLayer = LayerMask.NameToLayer("Character");

        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Debug.DrawRay(ray.origin, ray.direction, Color.red, 3f);
        
        if(Physics.Raycast(ray, out hit, float.MaxValue, 1 << characterLayer))
        {
            Debug.Log(hit.transform.gameObject);
            FindObjectOfType<Bulet>().Shooting(hit.point);
        }


        
    }


}

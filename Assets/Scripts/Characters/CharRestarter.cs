using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharRestarter : MonoBehaviour
{
    private Vector3 _basePosition;
    private void Start() 
    {
        _basePosition = transform.position;
    }
    
    public void LetRastart()
    {
        if(TryGetComponent(out Animator animator))
        {
            Time.timeScale = 1f;
            animator.enabled = true;
            transform.position = _basePosition;
        }
    }
    
    
}

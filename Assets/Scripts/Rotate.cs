using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private float xSpeed;
    [SerializeField] private float ySpeed;
    [SerializeField] private float zSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(360 * xSpeed * Time.deltaTime, 360 * ySpeed * Time.deltaTime, 360 * zSpeed * Time.deltaTime); 
    }
}

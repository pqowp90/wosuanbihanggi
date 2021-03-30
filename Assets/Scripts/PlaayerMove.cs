using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaayerMove : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;
    private Vector2 targerPosition = new Vector2(0,-10);
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            targerPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        //transform.position = targerPosition;
        transform.localPosition = Vector2.MoveTowards(transform.localPosition, targerPosition, speed * Time.deltaTime);
    }
}

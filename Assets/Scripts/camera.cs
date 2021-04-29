using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    private float SHAKEtimeremaining, shakepower, shakefadetime, shakerotation, rotationmultiplier = 15f;
    public float zoom, speed, fstzoom;
    public Vector2 velocity;
    public GameObject player;
    public GameObject hihi;
    public Vector3 target;
    private Vector2 targerPosition;
    void Start()
    {
        Application.targetFrameRate = 60;
        fstzoom = GetComponent<Camera>().orthographicSize;
    }

 
    public void LateUpdate()
    {
        target = player.transform.position;
        float posX = Mathf.SmoothDamp(transform.position.x, target.x, ref velocity.x, 0.8f);
        float posY = Mathf.SmoothDamp(transform.position.y, target.y, ref velocity.y, 0.8f);
        transform.position = new Vector3(posX, posY, transform.position.z);
        if (SHAKEtimeremaining > 0)
        {
            SHAKEtimeremaining -= Time.deltaTime;
            float xAmount = Random.Range(-1f, 1f) * shakepower;
            float yAmount = Random.Range(-1f, 1f) * shakepower;

            transform.position += new Vector3(xAmount, yAmount, 0f);
            shakepower = Mathf.MoveTowards(shakepower, 0f, shakefadetime * Time.deltaTime);
            shakerotation = Mathf.MoveTowards(shakerotation, 0f, shakefadetime * Time.deltaTime * rotationmultiplier);
        }
        //transform.rotation = Quaternion.Euler(0f,0f,shakerotation * Random.Range(-1f,1f));

  

    }
    public void startshake(float length, float power)
    {
        SHAKEtimeremaining = length;
        shakepower = power;

        shakefadetime = power / length;

        shakerotation = power * rotationmultiplier;
    }

}

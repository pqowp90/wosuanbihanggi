using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHotdog : ememyMove
{
    [SerializeField]
    private GameObject bulletPrefab;
    private GameObject newBullet;
    private Vector2 diff = Vector2.zero;
    [SerializeField]
    private float speedhi=5f;
    [SerializeField]
    private float fireRate = 0.5f;
    private float timer = 0f;
    private float rotationZ = 0f;
    



    protected override void Move()
    {
        transform.Translate(Vector3.left*Time.deltaTime*movemove*speedhi);

        timer += Time.deltaTime;
        if(timer >= fireRate){
            timer = 0f;
            newBullet = Instantiate(bulletPrefab,transform);
            diff = GameManager.Instance.player.transform.position - transform.position;
            diff.Normalize();
            rotationZ = Mathf.Atan2(diff.y,diff.x)*Mathf.Rad2Deg;
            newBullet.transform.rotation = Quaternion.Euler(0f,0f,rotationZ-90f);
            newBullet.transform.parent=null;
        }
    }
}

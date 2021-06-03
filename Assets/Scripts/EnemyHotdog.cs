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
    [SerializeField]
    private Sprite image;



    protected override void Move()
    {
        transform.Translate(Vector3.left*Time.deltaTime*movemove*speedhi);

        timer += Time.deltaTime;
        if(timer >= fireRate){
            timer = 0f;
            diff = GameManager.Instance.player.transform.position - transform.position;
            diff.Normalize();
            rotationZ = Mathf.Atan2(diff.y,diff.x)*Mathf.Rad2Deg;
            SpawnOrInstantiate();
        }
    }
    private void SpawnOrInstantiate(){
        GameObject bullet=null;
        if(GameManager.Instance.poolManager.transform.childCount>0){
            bullet = GameManager.Instance.poolManager.transform.GetChild(0).gameObject;
            bullet.transform.SetParent(transform);
            bullet.transform.position = transform.position;
            bullet.layer = 8;
            bullet.SetActive(true);
        }else{
        bullet = Instantiate(bulletPrefab,transform);
        }
        if(bullet != null){
            bullet.transform.SetParent(null);
            bullet.layer = 8;
            bullet.transform.rotation = Quaternion.Euler(0f,0f,rotationZ-90f);
            bullet.GetComponent<misa>().speed = 10;
            bullet.GetComponent<SpriteRenderer>().sprite = image;
        }
    }
}

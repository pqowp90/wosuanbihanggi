using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SibaBoss : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {
        
    }
    public void StartBoss(){
        StartCoroutine(Boss());
    }
    private  IEnumerator Boss(){
        yield return new WaitForSeconds(1f);
        
    }
}

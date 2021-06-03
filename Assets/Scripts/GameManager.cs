using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                var obj = FindObjectOfType<GameManager>();
                if (obj != null)
                    instance = obj;
                else
                {
                    var newSingleton = new GameObject("GameManager").AddComponent<GameManager>();
                    instance = newSingleton;
                }
            }
            return instance;
        }
        private set
        {
            instance = value;
        }
    }
    public PlaayerMove player{get; private set;}
    [SerializeField]
    private Text textScore=null;
    [SerializeField]
    private Text textLife=null;
    [SerializeField]
    private Text textBestScore=null;
    [SerializeField]
    private GameObject enemyCroissantPrefab;
    [SerializeField]
    private GameObject enemyHotdogPrefab;
    private long score = 0;
    private long bestScore = 0;
    [SerializeField]
    private int life=3;
    [SerializeField]
    private GameObject bossSiba;
    private Coroutine Spawnhihi;
    private Coroutine Spawnhihihi;
    public bool isBoss{get;private set;}
    
    public Vector2 MinPosition {get; private set;}
    public Vector2 MaxPosition {get; private set;}
    public float addSpeed;
    public poolManager poolManager{get; private set;}
    

    
    void Awake()
    {
        bestScore = PlayerPrefs.GetInt("BEST");
        //player = GameObject.Find("Player");
        player = FindObjectOfType<PlaayerMove>();
        MinPosition = new Vector2(-7f,-13f);
        MaxPosition = new Vector2(7f,13f);
        Spawnhihi = StartCoroutine(SpawnCroissant());
        poolManager = FindObjectOfType<poolManager>();
        Spawnhihihi = StartCoroutine(SpawnHotdog());
    }
    private void Update() {
        addSpeed+=Time.deltaTime;    
    }
    public void AddScore(long addScore){
        score += addScore;
        if(bestScore<score){
            bestScore = score;
            PlayerPrefs.SetInt("BEST",(int)bestScore);
        }
        UpdateUI();
        if(bossSiba==null) return;
        if(score >= 200&&!isBoss){
            bossSiba.SetActive(true);
            isBoss=true;
            if(Spawnhihi==null) return;
            StopCoroutine(Spawnhihi);
            if(Spawnhihihi==null) return;
            StopCoroutine(Spawnhihihi);
            bossSiba.GetComponent<Animator>().SetTrigger("startBoss");
            bossSiba.GetComponent<SibaBoss>().StartBoss();
        }
    }
    public void UpdateUI(){
        //textScore.text = "SCORE\n"+score.ToString();
         textScore.text = string.Format("SCORE\n{0}",score);
         textLife.text = string.Format("LIFE\n{0}",life);
         textBestScore.text = string.Format("BEST\n{0}",bestScore);
    }
    public void Dead(){
        life--;
        UpdateUI();
        if(life<=0){
            SceneManager.LoadScene("gameover");
        }
    }
    private IEnumerator SpawnCroissant(){
        while(true){
            
            float spawnDeley = 0f;
            spawnDeley = Random.Range(2f,5f);
            float RandomX = 0f;
            RandomX = Random.Range(-7f,7f);

        
            for(int i=0;i<6;i++){
                yield return new WaitForSeconds(0.2f);
                Instantiate(enemyCroissantPrefab, new Vector2(RandomX,20f),Quaternion.identity);
            }
            yield return new WaitForSeconds(spawnDeley);
        }
    }
    private IEnumerator SpawnHotdog(){
        while(true){
            
            float spawnDeley = 0f;
            spawnDeley = Random.Range(4f,7f);
            int RandomX = 1;
            RandomX = Random.Range(-1,1);
            if(RandomX==0)
                RandomX = 1;
        
            yield return new WaitForSeconds(0.2f);
            Instantiate(enemyHotdogPrefab, new Vector2(RandomX*9f,5f),Quaternion.identity);
            yield return new WaitForSeconds(spawnDeley);
        }
    }
    public void StartGoGo(){
        isBoss=false;
        Spawnhihi = StartCoroutine(SpawnCroissant());
        Spawnhihihi = StartCoroutine(SpawnHotdog());
    }


}

using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public void retry(){
        SceneManager.LoadScene("Main");
    }
}

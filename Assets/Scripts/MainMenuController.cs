using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartButton()
    {
        GetComponent<Animator>().SetBool("isStarting", true);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}

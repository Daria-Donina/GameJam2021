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

    public void TutorialButton()
    {
        GetComponent<Animator>().SetInteger("MenuIndex", 1);
    }

    public void TutorialToMainButton()
    {
        GetComponent<Animator>().SetInteger("MenuIndex", 2);
    }

    public void AboutButton()
    {
        GetComponent<Animator>().SetInteger("MenuIndex", 3);
    }

    public void AboutToMainButton()
    {
        GetComponent<Animator>().SetInteger("MenuIndex", 4);
    }

    public void StartButton()
    {
        GetComponent<Animator>().SetInteger("MenuIndex", 5);
    }

    public void StartGame()
    {
        SceneManager.LoadSceneAsync(1);
    }
}

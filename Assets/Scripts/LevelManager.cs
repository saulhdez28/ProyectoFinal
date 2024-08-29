using UnityEngine;
using UnityEngine.SceneManagement; //

public class LevelManager : MonoState<LevelManager>

{
    int sceneCount;

    protected override void Awake()
    {
        base.Awake();
        sceneCount = SceneManager.sceneCountInBuildSettings - 1;
    }
    public void FirstScene()
    {
        //si estoy en la misma escena
        if (SceneManager.GetActiveScene().buildIndex == 0) 
        {
            //Salgase no haga nada
            return; 
        }
        //Esta es la primera escena
        SceneManager.LoadScene(0); 
    }
    public void LastScene()
    {
        // Esto me dice si estoy en la ultima escena no cargue por que ya estoy ahi
        if (SceneManager.GetActiveScene().buildIndex == sceneCount) 
        {
            return;
        }
        // si no carguela
        SceneManager.LoadScene(sceneCount); 
    }

    public void NextScene()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        if (currentScene >= sceneCount)
        {
            return;
        }
        SceneManager.LoadScene(currentScene + 1);
    }
    public void PreviousScene()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        if (currentScene <= 0)
        {
            return;
        }
        SceneManager.LoadScene(currentScene - 1);
    }

    public void GameOver()
    {
        if (SceneManager.GetActiveScene().buildIndex == sceneCount)
        {
            return;
        }
        SceneManager.LoadScene(3);
    }

}
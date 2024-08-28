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
        if (SceneManager.GetActiveScene().buildIndex == 0) //si estoy en la misma escena
        {
            return; //Salgase no haga nada
        }
        SceneManager.LoadScene(0); //Esta es la primera escena
    }
    public void LastScene()
    {
        if (SceneManager.GetActiveScene().buildIndex == sceneCount) // Esto me dice si estoy en la ultima escena no cargue por que ya estoy ahi
        {
            return;
        }
        SceneManager.LoadScene(sceneCount); // si no carguela
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
}
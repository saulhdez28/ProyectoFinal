using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverController : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI _name;

    [SerializeField]
    TextMeshProUGUI enemies;

    [SerializeField]
    TextMeshProUGUI medCases;

    public void RePlay()
    {
        //StateManager.Instance.setName(textbox.text);
        StateManager.Instance.setCollectables(0);
        StateManager.Instance.setEnemiesDestroyed(0);
        LevelManager.Instance.FirstScene();
    }

    void Start()
    {
        // Accede a la instancia de StateManager
        StateManager stateManager = StateManager.Instance;


        // Obtiene los datos del StateManager
        string playerName = stateManager.getName();
        int enemiesDestroyed = stateManager.getEnemiesDestroyed();
        int collectables = stateManager.getCollectables();


        // Configura los campos de texto
        _name.text = playerName;
        enemies.text = "ZOMBIES DEFEATED: " + enemiesDestroyed;
        medCases.text = " MEDCASES FOUNDED: " + collectables;
    }
}

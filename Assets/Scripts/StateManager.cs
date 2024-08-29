using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : Singleton<StateManager>
{
    string _name;
    public int _enemiesDestroyed = 0;
    public int _collectables = 0;

    public string getName()
    {
        return _name;
    }

    public void setName(string newName)
    {
        _name = newName;
    }

    public int getEnemiesDestroyed()
    {
        return _enemiesDestroyed;
    }

    public void setEnemiesDestroyed()
    {
        _enemiesDestroyed++;
    }

    public void setEnemiesDestroyed(int enemiesDestroyed)
    {
        _enemiesDestroyed = enemiesDestroyed;
    }

    public int getCollectables()
    {
        return _collectables;
    }

    public void setCollectables()
    {
        _collectables++;
    }

    public void setCollectables(int collectables)
    {
        _collectables = collectables;
    }
}
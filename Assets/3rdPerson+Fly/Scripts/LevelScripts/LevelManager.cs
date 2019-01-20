using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {


    private int _numEnemies; // Amount of enemies to kill depending on the current level
    private int _enemiesKilled; // Amount of enemies killed at the moment
    private float tSpawn, tShowing;

    // Use this for initialization
    void Start () {
        InitLevel();
    }
	
	/*// Update is called once per frame
	void LateUpdate () {
		
	}*/

    private void InitLevel()
    {
        _enemiesKilled = 0;
        _numEnemies = GameManager.instance.DetermineNumEnemies();
       
        GameManager.instance.DetermineTimes(out tSpawn, out tShowing);

        for (int j = 0; j < GameManager.instance.DetermineNumSpawns(); j++)
            GameManager.instance.spawns[j].Init(this, tSpawn, tShowing);

        Debug.Log("LEVEL STARTED");
    }

    public void LevelOver()
    {
        Debug.Log("GAME OVER");
        // Aparecer un menu con la opcion de reiniciar,...
    }

    public void EnemyKilled()
    {
        _enemiesKilled++;
        if(_enemiesKilled == _numEnemies)
        {          
            Debug.Log("LEVEL WON");

            if(GameManager.instance.GetLevel() < 5)
            {
                GameManager.instance.NextLevel();
                InitLevel();
            }
            


            //SceneManager.LoadScene(0); // Cambiar despues los indice de las escenas y hacerlo con botones del menu.

            // Aparecer un menu con la opcion de pasar al siguiente nivel o salir,...
        }
    }

}

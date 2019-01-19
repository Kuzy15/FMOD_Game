using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {


    private int _numEnemies; // Amount of enemies to kill depending on the current level
    private int _enemiesKilled; // Amount of enemies killed at the moment
    //private List<CharacterSpawn> _spawns; // Contains the character spawns of each level

	// Use this for initialization
	void Start () {

        _numEnemies = GameManager.instance.DetermineNumEnemies();

        float tSpawn, tShowing;
        GameManager.instance.DetermineTimes(out tSpawn, out tShowing);

       /* _spawns = new List<CharacterSpawn>(GameManager.instance.DetermineNumSpawns());
        for (int i = 0; i < GameManager.instance.DetermineNumSpawns(); i++)      
            _spawns.Add(GameManager.instance.spawns[i]);*/


        for(int j = 0; j < GameManager.instance.DetermineNumSpawns(); j++)
            GameManager.instance.spawns[j].Init(this, tSpawn, tShowing);

    }
	
	/*// Update is called once per frame
	void LateUpdate () {
		
	}*/

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
            
            // Aparecer un menu con la opcion de pasar al siguiente nivel o salir,...
        }
    }

}

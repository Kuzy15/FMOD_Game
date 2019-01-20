using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;
    public List<CharacterSpawn> spawns;

    private int _level;

    // Use this for initialization
    void Awake()
    {
       
        if (instance == null)
        {
            instance = this;

            _level = 1;

            DontDestroyOnLoad(gameObject);
        }

        Debug.Log(_level);
    }

	/*// Update is called once per frame
	void Update () {
		
	}*/

    public int GetLevel()
    {
        return _level;
    }

    public void NextLevel() // Pass to the next level
    {
        if(_level <= 4) // En principio 4 niveles
            _level += 1;
    }

    public int DetermineNumEnemies() // Determine the enemies' number of the current level
    {
        return _level * 3 + 3;  // RETOCAR
    }

    public int DetermineNumSpawns()
    {
        /*if(_level == 1 || _level == 2)
        {
            return 3;
        }

        return _level * 2 - 2; // RETOCAR*/

        int num = 0;

        switch (_level) // En principio 5 niveles
        {
            case 1:
                num = 1;
                break;
            case 2:
                num = 2;
                break;
            case 3:
                num = 3;
                break;
            case 4:
                num = 3;
                break;
            case 5:
                num = 4;
                break;
        }

        return num;
    }

    public void DetermineTimes(out float tSpawn, out float tShowing)
    {
        tSpawn = 0.0f;
        tShowing = 0.0f;

        switch (_level) // En principio 5 niveles
        {
            case 1:
                tSpawn = 5.0f;
                tShowing = 3.0f;
                break;
            case 2:
                tSpawn = 7.0f;
                tShowing = 5.0f;
                break;
            case 3:
                tSpawn = 7.0f;
                tShowing = 3.0f;
                break;
            case 4:
                tSpawn = 8.0f;
                tShowing = 6.0f;
                break;
            case 5:
                tSpawn = 8.0f;
                tShowing = 6.0f;
                break;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButtonX : MonoBehaviour
{
    private Button button;
    private GameManagerX gameManagerX;
    public int difficulty;

    // Start is called before the first frame update
    void Start()
    {
        gameManagerX = GameObject.Find("Game Manager").GetComponent<GameManagerX>();
        button = GetComponent<Button>();
        button.onClick.AddListener(SetDifficulty);
    }

    /* When a button is clicked, call the StartGame() method
     * and pass it the difficulty value (1, 2, 3) from the button 
    */
    void SetDifficulty()
    {
        Debug.Log(button.gameObject.name + " was clicked");

        if(button.gameObject.name == "Easy Button")
        {
            gameManagerX.StartGame(1);
        }

        else if (button.gameObject.name == "Medium Button")
        {
            gameManagerX.StartGame(2);
        }

        else if (button.gameObject.name == "Hard Button")
        {
            gameManagerX.StartGame(3);
        }
    }
}
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic; // Make sure to include the TextMesh Pro namespace





//public class LeaderboardManager : MonoBehaviour
//{
//    public TMP_Text[] leaderboardText; // An array to hold the TextMesh Pro UI elements for the leaderboard

    // Call this method to update the leaderboard UI
//   public void UpdateLeaderboard(Player[] players)
//    {
        // Sort players by score
      //  Array.Sort(players, (player1, player2) => player2.score.CompareTo(player1.score));

        // Update the UI elements with the player's data
//        for (int i = 0; i < players.Length; i++)
 //       {
//            leaderboardText[i].text = $"{i + 1}. {players[i].playerName} - {players[i].score}";
 //       }
 //   }
//}

// A simple Player class for demonstration purposes
public class Player
{
    public string playerName;
    public int score;
}

public class LeaderboardForm : MonoBehaviour
{

    public TMP_Text label;
    public TMP_InputField field;
    public TMP_Text lebelscore;
    public TMP_InputField field2;

    public dreamloLeaderBoard dreamlo;
    public string playerName;
    public int score;

    // Start is called before the first frame update
    void Start()
    {
        loadLeaderboard();


    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Submit()
      {
        //   Debug.Log("Player Name" + field2.text);
        //   Debug.Log("Score " + field.text);
        Debug.Log("Player User name : " + field.text);
        Debug.Log("Player score : " + field2.text);
        //  Debug.Log("Player Rank : " + data.Scores*.rank.ToString());
        dreamlo.AddScore(field.text, /*int.Parse(field2.text*/ PlayerPrefs.GetInt ("coins"));

    }

    public void loadLeaderboard ()
    {

    }
}
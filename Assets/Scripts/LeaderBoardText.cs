using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

public class LeaderBoardText : MonoBehaviour
{
    [SerializeField] private Text _leaderboardText;

    [SerializeField] private LeaderBoard _leaderBoard;

    private List<LeaderBoardNote> _sortedLeaderBoard = new List<LeaderBoardNote>();

    private void Start()
    {
        AddLeader();

        GameController.OnLeaderBoardAdd += AddLeader;
    }

    private void AddLeader()
    {
        _leaderboardText.text = "";

        string buffer = "";

        string[] leadersArray = _leaderBoard.Leaders.ToArray();

        string[] splittedString = null;

        _sortedLeaderBoard.Clear();

        for (int i = 0; i < leadersArray.Length; i++)
        {
            splittedString = null;

            splittedString = leadersArray[i].Split(" ");

            _sortedLeaderBoard.Add(new LeaderBoardNote(splittedString[0], int.Parse(splittedString[1])));
        }

        
        var sortedLeaders = from l in _sortedLeaderBoard
                            orderby l._leadersScore descending
                            select l;

        foreach (var sl in sortedLeaders)
        {
            Debug.Log(sl._leadersName + " " + sl._leadersScore);

            buffer = buffer + sl._leadersName + " " + sl._leadersScore + "\r\n";
        }


        _leaderboardText.text = buffer; 
    }
}

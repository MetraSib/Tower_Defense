using Proyecto26;
using UnityEngine;
using UnityEngine.UI;

public class EnemiesScore : MonoBehaviour
{
    private Text enemiesDied;

    public static int score;

    User user = new User();

    private void Start()
    {
        enemiesDied = GetComponent<Text>();
        RetrieveFromDatabase();
    }

    public void PlusEnemy()
    {
        score++;
        enemiesDied.text = score.ToString();
        PostToDatabase();
    }

    private void PostToDatabase()
    {
        User user = new User();
        RestClient.Put("https://test-firebase-81e55-default-rtdb.firebaseio.com/" + ".json", user);
    }

    private void RetrieveFromDatabase()
    {
        RestClient.Get<User>("https://test-firebase-81e55-default-rtdb.firebaseio.com/" + ".json").Then(response =>
        {
            user = response;
            score = user.userScore;
            enemiesDied.text = score.ToString();
        });
    }

}



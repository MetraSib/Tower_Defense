using System;

[Serializable]
public class User
{
    public int userScore;

    public User()
    {
        userScore = EnemiesScore.score;
    }
}
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewWaveButtons : MonoBehaviour
{
    public void FirstWave ()
    {
        CurrentWaveStatic.currentWave = 1;
        SceneManager.LoadScene(1);
        
    }

    public void SecondWave()
    {
        CurrentWaveStatic.currentWave = 2;
        SceneManager.LoadScene(1);
    }

    public void ThirdWave()
    {
        CurrentWaveStatic.currentWave = 3;
        SceneManager.LoadScene(1);
    }
}

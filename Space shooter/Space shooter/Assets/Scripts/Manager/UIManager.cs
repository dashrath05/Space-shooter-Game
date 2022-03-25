using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UIManager : MonoBehaviour
{
    [SerializeField] private Text liveCount;
    [SerializeField] private Player player;
    [SerializeField] private Text score;
    [SerializeField] private Text finalScore;

    //GameAudio
    [SerializeField]private Text sound;
    private bool muted = false;
    private string onSound = "ON SOUND";
    private string offSound = "OFF SOUND";



    private void Update()
    {
        liveCount.text = player.lives.ToString();
        score.text = ObjectPool.instance.score.ToString();
        finalScore.text = ObjectPool.instance.score.ToString();
    }

   
    //Audio 
    public void OnButtonPress()
    {
        if (muted == false)
        {
            muted = true;
            AudioListener.pause = true;
        }
        else
        {
            muted = false;
            AudioListener.pause = false;
        }
        UpdateButtonText();
    }

    private void UpdateButtonText()
    {
        if (muted == false)
        {
            sound.text = onSound;

        }
        else
        {
            sound.text = offSound;

        }
    }

    public void Pause()
    {
        Time.timeScale = 0;
    }
    public void Resume()
    {
        Time.timeScale = 1;
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Main");
    }
}

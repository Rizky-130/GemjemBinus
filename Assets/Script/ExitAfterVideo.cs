using UnityEngine;
using UnityEngine.Video;

public class ExitAfterVideo : MonoBehaviour
{
    public VideoPlayer videoPlayer;

    void Start()
    {
    
        videoPlayer.Play();

        // event saat video selesai
        videoPlayer.loopPointReached += OnVideoEnd;
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        Debug.Log("Video selesai, keluar game...");

        QuitGame();
    }

    void QuitGame()
    {
        Application.Quit();

        // ini supaya bisa kelihatan di editor (karena di editor tidak benar-benar quit)
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
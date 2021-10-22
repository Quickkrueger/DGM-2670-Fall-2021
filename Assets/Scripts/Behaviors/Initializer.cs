using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

[System.Serializable]
public class MyEvent : UnityEvent<PaletteData, PaletteData>
{
}
public class Initializer : MonoBehaviour
{
    
    public PaletteData basePalette;
    public PaletteData UIPalette;
    
    [SerializeField]
    public MyEvent UIStart;

    public UnityEvent startEvent;
    // Start is called before the first frame update
    void Start()
    {
        Pause();
        UIStart.Invoke(basePalette, UIPalette);
        startEvent.Invoke();
    }

    public void Pause()
    {
        Time.timeScale = 0;
    }

    public void UnPause()
    {
        Time.timeScale = 1;
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

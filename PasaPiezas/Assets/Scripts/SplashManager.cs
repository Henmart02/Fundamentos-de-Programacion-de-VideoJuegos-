using UnityEngine;

public class SplashManager : MonoBehaviour
{
    public GameObject splashPanel;
    public GameObject menuPanel;

    private bool canSkip = true;

    void Update()
    {
        if (!canSkip) return;

        if (Input.anyKeyDown)
        {
            SkipSplash();
        }
    }

    void SkipSplash()
    {
        splashPanel.SetActive(false);
        menuPanel.SetActive(true);
    }

    void Start()
{
    Invoke("EnableSkip", 2f); // espera 2 segundos
}

void EnableSkip()
{
    canSkip = true;
}
}
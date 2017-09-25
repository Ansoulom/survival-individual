using UnityEngine.SceneManagement;

public class PlayerDeath : DeathComponent
{
    public string DeathScene;


    public override void Kill()
    {
        SceneManager.LoadScene(DeathScene);
    }
}

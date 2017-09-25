using UnityEngine;

public class HealthUI : MonoBehaviour
{
    private int _health;
    private Combateer _player;
    public Heart[] Hearts;

    // Use this for initialization
    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Combateer>();
        _health = _player.Health;
        UpdateHearts();
    }


    // Update is called once per frame
    private void Update()
    {
        _health = _player.Health;
        UpdateHearts();
    }


    private void UpdateHearts()
    {
        for (var i = 0; i < Hearts.Length; ++i)
            Hearts[i].SetFilled(_health > i);
    }
}
using UnityEngine;

public class TimedObjectRemover : MonoBehaviour
{
    private Timer _timer;
    public float TimeToDie;

    // Use this for initialization
    private void Start()
    {
        _timer = new Timer(TimeToDie);
    }

    // Update is called once per frame
    private void Update()
    {
        if (_timer.Update(Time.deltaTime))
            Destroy(gameObject);
    }
}
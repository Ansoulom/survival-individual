public class Timer
{
    private readonly float targetTime;

    public Timer(float maxTime)
    {
        targetTime = maxTime;
        TimePassed = 0f;
    }

    public float PercentDone
    {
        get { return TimePassed / targetTime; }
    }


    public float TimePassed { get; private set; }


    public bool IsDone
    {
        get { return TimePassed >= targetTime; }
    }

    public bool Update(float timePassed)
    {
        TimePassed += timePassed;
        return TimePassed >= targetTime;
    }

    public void ResetToSurplus()
    {
        if (TimePassed >= targetTime)
            TimePassed -= targetTime;
    }

    public void Reset()
    {
        TimePassed = 0f;
    }
}
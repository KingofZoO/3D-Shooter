using System;

public class MyTimer
{
    private DateTime startTime;
    private float elapsedTime;
    private TimeSpan timeInterval;

    public void Start(float elapsedTime)
    {
        this.elapsedTime = elapsedTime;
        startTime = DateTime.Now;
        timeInterval = TimeSpan.Zero;
    }

    public void Update()
    {
        if (elapsedTime > 0)
        {
            timeInterval = DateTime.Now - startTime;

            if (timeInterval.TotalSeconds > elapsedTime)
                elapsedTime = 0;
        }
        else if (elapsedTime == 0)
            elapsedTime = -1;
    }

    public bool IsEvent()
    {
        return elapsedTime == 0;
    }
}

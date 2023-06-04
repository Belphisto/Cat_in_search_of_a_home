using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using View;
using Model;

public class TimeController 
{
    private readonly TimeModel timeModel;
    private readonly TimeView timeView;

    public TimeController(TimeModel timeModel, TimeView timeView)
    {
        this.timeModel = timeModel;
        this.timeView = timeView;
    }

    public void UpdateTime()
    {
        timeModel.UpdateTime();
        timeView.UpdateTime(timeModel.currentTime);
    }
    
    public void ResetTime()
    {
        timeModel.ResetTime();
        timeView.UpdateTime(timeModel.currentTime);
    }
}

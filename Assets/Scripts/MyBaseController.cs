using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyNameSpace;

/// <summary>
/// Базовый класс контроллеров
/// </summary>
public abstract class MyBaseController : MyBaseObjectScene
{
    public bool Enabled
    {
        get { return enabled; }
        set { enabled = value; }
    }
}

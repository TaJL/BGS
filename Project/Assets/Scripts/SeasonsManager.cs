using System;
using ReusedCode;

public class SeasonsManager : SingletonMonoBehaviour<SeasonsManager>
{
    public ESeason Current {get; private set;}

    protected override void Awake()
    {
        base.Awake();
        Current = (ESeason)UnityEngine.Random.Range(1, Enum.GetValues(typeof(ESeason)).Length);
    }
}

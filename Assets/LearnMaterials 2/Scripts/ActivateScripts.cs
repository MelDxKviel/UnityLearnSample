using System.Collections.Generic;
using UnityEngine;

public class ActivateScripts : SampleScript
{
    public List<SampleScript> scriptsList = new List<SampleScript>();


    [ContextMenu("Запустить скрипты")]
    public override void Use()
    {
        foreach (var sampleScript in scriptsList)
        {
            sampleScript.Use();
        }
    }
}

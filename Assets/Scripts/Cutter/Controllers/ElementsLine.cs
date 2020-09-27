//by Homa.K
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementsLine : BaseObject
{
    public List<CutElementObject> lineElements = new List<CutElementObject>();

    public override void init()
    {
        base.init();
    }

    public void randomFillLine(LineCreatorSettings settings)
    {
        foreach(CutElementObject obj in lineElements)
        {
            obj.setElemDefinition(settings.getRandomElement());
        }
    }

    public void randomUpdateLine(LineCreatorSettings settings)
    {
        foreach (CutElementObject obj in lineElements)
        {
            if (obj.elemState == CutElementObject.ElementState.EMPTY)
            {
                obj.setElemDefinition(settings.getRandomElement());
            }
        }
    }
}

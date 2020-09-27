using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : BaseObject
{
    public ElementsLine[] lines;
    public LineCreatorSettings settings;
    public override void init()
    {
        base.init();
        randomFillEntireMap();
    }

    private void randomFillEntireMap()
    {
        foreach(ElementsLine line in lines)
        {
            line.randomFillLine(settings);
        }
    }

    public override void onFixedUpdate(float fixedDelta)
    {
        base.onFixedUpdate(fixedDelta);
        //przechodzimy po całej mapie i szukamy pustych miejsc
        for(int a=0;a<lines.Length;++a)
        {
            lines[a].randomUpdateLine(settings);
        }
    }

}

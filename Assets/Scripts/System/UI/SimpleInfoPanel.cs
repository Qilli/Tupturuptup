using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SimpleInfoPanel : BaseObject
{
    public TextMeshProUGUI[] texts;
    public virtual void TogglePanel(bool show)
    {
        gameObject.SetActive(show);
    }

    public void deactivateAll()
    {
        foreach(TextMeshProUGUI t in texts)
        {
            t.gameObject.SetActive(false);
        }
    }


    public void setText(int index, string text)
    {
        texts[index].gameObject.SetActive(true);
        texts[index].text = text;
    }

    public void setScreenPosition
        (Vector2 pos)
    {
        transform.position = pos;
    }

}

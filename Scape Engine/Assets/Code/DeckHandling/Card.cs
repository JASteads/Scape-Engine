using UnityEngine;
using UnityEngine.UI;

public abstract class Card
{
    public string name, desc;
    Button container;
    Image splash;

    public Card(string name, string desc, Transform parent)
    {
        this.name = name;
        this.desc = desc;

        InterfaceTool.ButtonSetup(name, parent, out Image cardImg, 
            out container, null, null);
        InterfaceTool.FormatRect(cardImg, new Vector2(150, 400), Vector2.zero);

        InterfaceTool.ImgSetup("Splash Art",
            container.transform, out splash, true);
        InterfaceTool.FormatRect(splash, new Vector2(120, 200),
            new Vector2(0, 50));
        
    }

    public abstract void OnClick();
}
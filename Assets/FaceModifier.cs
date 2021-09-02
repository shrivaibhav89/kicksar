using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FaceModifier : MonoBehaviour
{
    // Start is called before the first frame update
    public void changeSkinColor(Image img)
    {
        myface.skinmat.color = img.color;
    }

    public void changeeyeColor(Image img)
    {
       EyeTracker.leyemat.mainTexture = img.sprite.texture;
        EyeTracker.reyemat.mainTexture = img.sprite.texture;
    }
}

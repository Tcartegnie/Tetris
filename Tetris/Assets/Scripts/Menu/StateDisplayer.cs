using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StateDisplayer : MonoBehaviour
{
    public Image picture;

    public void SetCasePicture(Sprite sprite)
	{
		picture.sprite = sprite;
	}
}

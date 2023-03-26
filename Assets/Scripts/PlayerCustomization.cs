using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCustomization : MonoBehaviour
{
    [Header("Sprite to Change")]
    public SpriteRenderer bodyPart;

    [Header("List of Options")]
    public List<Sprite> options = new List<Sprite>();

    private int currOption = 0;

    public void nextOption(){
        currOption++;
        if(currOption>= options.Count){
            currOption = 0;
        }
        bodyPart.sprite = options[currOption];
    }

    public void previousOption(){
        currOption--;
        if(currOption<=0){
            currOption = options.Count -1;
        }
        bodyPart.sprite = options[currOption];
    }

    public void randomize(){
        currOption = Random.Range(0,options.Count-1);
        bodyPart.sprite = options[currOption];
    }


}

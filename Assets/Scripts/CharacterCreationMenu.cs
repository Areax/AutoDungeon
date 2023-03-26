using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCreationMenu : MonoBehaviour
{
    public List<PlayerCustomization> customizations = new List<PlayerCustomization>();

    public void randomizeCharacter(){
        foreach (PlayerCustomization clothing in customizations){
            clothing.randomize();
        }
    }

}

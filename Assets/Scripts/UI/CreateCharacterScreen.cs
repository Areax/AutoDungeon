using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreateCharacterScreen : MonoBehaviour
{
    public void continueGame(){
        SceneManager.LoadScene("EnterDungeon");
    }

    public void backScreen(){
        SceneManager.LoadScene("StartScreen");
    }
}

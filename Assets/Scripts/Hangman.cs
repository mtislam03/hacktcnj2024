using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

public class Hangman : MonoBehaviour
{
    
    private string word;
    private bool[] guessed;
   
    public void SetWord(string word){
        this.word = word;
        for (int i = 0; i < word.Length; i++){
            guessed[i] = 0;
        }
    }
    
    // Update is called once per frame
    public bool CheckGuess(char guess)
    {
        bool hit = false;
        char lowGuess = char.ToLower(guess);
        string lowWord = String.ToLower(word);
        

        for (int i = 0; i < word.Length; i++){
            if(lowWord[i] == lowGuess) {
                guessed[i] = 1;
                hit = true;
            }
        }
        return hit;
    }

    public string GetRepr(){
        string output = "";
        for (int i = 0; i < word.Length; i++){
            if (guessed[i] == 1){
                output += word[i];
            } else{
                output += "_";
            }
        }
        return output;
    }

    public bool CheckWin(){
        for (int i = 0; i < word.Length; i++){
            if (guessed[i] == 0){
                return false;
            }
        }
        return true;
    }
}

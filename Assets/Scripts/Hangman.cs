using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

public class Hangman : MonoBehaviour
{
    private bool revealed;
    private string word;
    private bool[] guessed;

    private void Start()
    {
        revealed = false;
    }

    public void Reveal()
    {
        revealed = true;
    }

    public void SetWord(string word){
        this.word = word;
        for (int i = 0; i < word.Length; i++){
            guessed[i] = false;
        }
    }
    
    // Update is called once per frame
    public bool CheckGuess(char guess)
    {
        bool hit = false;
        char lowGuess = char.ToLower(guess);
        string lowWord = word.ToLower();
        

        for (int i = 0; i < word.Length; i++){
            if(lowWord[i] == lowGuess) {
                guessed[i] = true;
                hit = true;
            }
        }
        return hit;
    }

    public string GetRepr(){
        if (!revealed) return "";
        string output = "";
        for (int i = 0; i < word.Length; i++){
            if (guessed[i]){
                output += word[i];
            } else{
                output += "_";
            }
        }
        return output;
    }

    public bool CheckWin(){
        for (int i = 0; i < word.Length; i++){
            if (!guessed[i]){
                return false;
            }
        }
        return true;
    }
}

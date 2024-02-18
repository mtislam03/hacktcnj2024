using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

public class Hangman : Game
{
    private string word;
    private bool[] guessed;

    private void Start()
    {
        SetWord(WordGenerator.GetWord(WordGenerator.WordType.ANIMALS));
    }

    public void SetWord(string word){
        this.word = word;
        guessed = new bool[word.Length];
        for (int i = 0; i < word.Length; i++){
            guessed[i] = false;
        }
    }
    
    // Update is called once per frame
    private bool CheckGuess(char guess)
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
        if (!hit) Deactivate();
        return hit && !DidWin();
    }

    public override string GetPreview()
    {
        return GetRepr();
    }

    public override string GetName()
    {
        return "Hangman";
    }


    private string GetRepr(){
        if (!Revealed) return "";
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

    public override bool DidWin(){
        for (int i = 0; i < word.Length; i++){
            if (!guessed[i]){
                return false;
            }
        }
        return true;
    }

    public override bool TakeInput(Event e)
    {
        if (e.isKey && e.keyCode.ToString().Length == 1)
        {
            return CheckGuess(e.keyCode.ToString()[0]);
        }
        return true;
    }
}

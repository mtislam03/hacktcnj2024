using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

public class Hangman : MonoBehaviour
{
    public AudioClip goodLetterClip;
    public AudioClip badLetterClip;
    public AudioClip repeatLetterClip;
    public AudioClip winTileClip;

    private string word;
    private bool[] guessed;
    // 26-character array; if a character is entered, it is set to 1 and skipped in the future
    // if the character is in the target word, it is set to 2 instead
    private int[] guessedLetters;
    private bool revealed;
    private bool active;

    public bool Revealed
    {
        get => revealed;
    }

    public bool Inactive
    {
        get => !active;
    }

    public void Activate()
    {
        active = true;
        revealed = true;
    }

    public void Deactivate()
    {
        active = false;
    }

    private void Start()
    {
        revealed = false;
        active = false;
        guessedLetters = new int[26];
        SetWord(WordGenerator.GetWord(WordGenerator.WordType.ANIMALS));
    }
    public void InitCat(WordGenerator.WordType cat)
    {
        SetWord(WordGenerator.GetWord(cat));
    }

    public void SetWord(string word){
        this.word = word;
        guessed = new bool[word.Length];
        for (int i = 0; i < word.Length; i++)
        {
            guessed[i] = false;
        }
        for (int i = 0; i < guessedLetters.Length; i++)
        {
            guessedLetters[i] = 0;
        }
    }

    // CheckGuess returns true only if the current player can keep guessing letters
    // (invalid input or correct letter but not a win)
    private bool CheckGuess(char guess)
    {
        bool hit = false;
        char lowGuess = char.ToLower(guess);
        string lowWord = word.ToLower();

        int letterPos = lowGuess - 'a';
        if (letterPos < 0 || letterPos >= 26 || guessedLetters[letterPos] > 0)
        {
            AudioManager.Instance.PlayEffect(repeatLetterClip);
            return true;
        }

        guessedLetters[letterPos] = 1;
        for (int i = 0; i < word.Length; i++){
            if(lowWord[i] == lowGuess) {
                guessed[i] = true;
                hit = true;
                guessedLetters[letterPos] = 2;
            }
        }
        if (!hit)
        {
            Deactivate();
            AudioManager.Instance.PlayEffect(badLetterClip);
        } else AudioManager.Instance.PlayEffect(goodLetterClip);
        return hit && !DidWin();
    }

    // returns a list of all letters guessed but not in the target word
    public List<char> GetWrongLetters()
    {
        List<char> letters = new List<char>();

        for (int i = 0; i < 26; i++)
        {
            if (guessedLetters[i] == 1) letters.Add((char) (i + 'a'));
        }
        return letters;
    }

    public string GetRepr(){
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

    public bool DidWin(){
        for (int i = 0; i < word.Length; i++){
            if (!guessed[i]){
                return false;
            }
        }
        AudioManager.Instance.PlayEffect(winTileClip);
        return true;
    }

    public bool TakeInput(Event e)
    {
        if (e.isKey && e.type == EventType.KeyDown)
        {
            if (e.keyCode.ToString().Length == 1) return CheckGuess(e.keyCode.ToString()[0]);
        }
        return true;
    }
}

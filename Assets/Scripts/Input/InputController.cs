using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InputController : MonoBehaviour {

	public TMP_InputField inputField;

	public string[] ARTICLES = new string[] { "A", "AN", "THE" };
	public string[] PREPOSITIONS = new string[] {"OF", "WITH", "AT", "FROM", "INTO", "DURING", "INCLUDING",
																											"UNTIL", "AGAINST", "AMONG", "THROUGHOUT", "DESPITE",
																											"TOWARDS", "UPON", "CONCERNING", "TO", "IN", "FOR", "BY",
																											"ABOUT", "LIKE", "BEFORE", "AFTER", "SINCE", "WITHOUT",
																											"WITHIN", "ALONG", "FOLLOWING", "BEYOND", "PLUS", "EXCEPT",
																											"BUT", "NEAR"};

	void Awake() {
		inputField.onSubmit.AddListener(GetInput);
	}


	void GetInput(string input) {
		GameController.Instance.ActionController.DoAction(ParseInput(input), input);
		inputField.ActivateInputField();
		inputField.text = null;
	}


	string ParseInput(string input) {
		string parsedInput = RemovePunctuation(input);
		parsedInput = parsedInput.ToUpper();
		List<string> parsedWords = ParseWords(parsedInput.Split(' '));
		return string.Join(" ", parsedWords.ToArray());
	}


	string RemovePunctuation(string input) {
		var stringBuilder = new StringBuilder();

		foreach (char c in input) {
			if(!char.IsPunctuation(c))
				stringBuilder.Append(c);
		}

		return stringBuilder.ToString();
	}


	List<string> ParseWords(string[] words) {
		List<string> parsedWords = new List<string>();

		for (int i = 0; i < words.Length; i++) {
			if (RemoveArticles(words[i]))
				continue;
			if (RemovePrepositions(words[i]))
				continue;
			parsedWords.Add(words[i]);
		}

		return parsedWords;
	}


	bool RemoveArticles(string word) {
		for (int j = 0; j < ARTICLES.Length; j++) {
			if (word == ARTICLES[j]) {
				return true;
			}
		}
		return false;
	}

	
	bool RemovePrepositions(string word) {
		for (int j = 0; j < PREPOSITIONS.Length; j++) {
			if (word == PREPOSITIONS[j]) {
				return true;
			}
		}
		return false;
	}

}

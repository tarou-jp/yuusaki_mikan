using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionManager : MonoBehaviour
{
	[SerializeField] Text QuestionTextOnPanel;

	public void SetQuestionOnQuestionPanel(string text)
	{
		QuestionTextOnPanel.text = text;
	}
}

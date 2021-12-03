using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Ash.RobotStats
{
	public class StatDisplay : MonoBehaviour
	{
		public Text NameText;
		public Text ValueText;

		[NonSerialized]
		public CharacterStat Stat;

		private void OnValidate()
		{
			Text[] texts = GetComponentsInChildren<Text>();
			NameText = texts[0];
			ValueText = texts[1];
		}

		
	}
}

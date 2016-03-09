using UnityEngine;
using System;
using System.Collections;

public class PuzzleObjectController : MonoBehaviour {

	public InGameButton caveBossEntranceButton1;
	public InGameButton caveBossEntranceButton2;
	public InGameButton caveBossEntranceButton3;

	public InGameButton enchForestBarrierButton1;
	public InGameButton enchForestBarrierButton2;
	public InGameButton enchForestBarrierButton3;


	public void OnLoadUpdate (int[] caveBossEntranceButtons, int[] enchForestBarrierButtons) {

		// Press the buttons!
		if (Convert.ToBoolean(caveBossEntranceButtons[0])) {
			caveBossEntranceButton1.PressButton();
		}

		if (Convert.ToBoolean(caveBossEntranceButtons[1])) {
			caveBossEntranceButton2.PressButton();
		}

		if (Convert.ToBoolean(caveBossEntranceButtons[2])) {
			caveBossEntranceButton3.PressButton();
		}

		if (Convert.ToBoolean(enchForestBarrierButtons[0])) {
			enchForestBarrierButton1.PressButton();
		}

		if (Convert.ToBoolean(enchForestBarrierButtons[1])) {
			enchForestBarrierButton2.PressButton();
		}

		if (Convert.ToBoolean(enchForestBarrierButtons[2])) {
			enchForestBarrierButton3.PressButton();
		}

	}

	public int[] GetPuzzleObjectsStatus () {
		int[] puzzleObjecstStatusArray = new int[6];

		puzzleObjecstStatusArray[0] = Convert.ToInt16(caveBossEntranceButton1.IsButtonPressed());
		puzzleObjecstStatusArray[1] = Convert.ToInt16(caveBossEntranceButton2.IsButtonPressed());
		puzzleObjecstStatusArray[2] = Convert.ToInt16(caveBossEntranceButton3.IsButtonPressed());
		puzzleObjecstStatusArray[3] = Convert.ToInt16(enchForestBarrierButton1.IsButtonPressed());
		puzzleObjecstStatusArray[4] = Convert.ToInt16(enchForestBarrierButton2.IsButtonPressed());
		puzzleObjecstStatusArray[5] = Convert.ToInt16(enchForestBarrierButton3.IsButtonPressed());


		return puzzleObjecstStatusArray;
	}
}

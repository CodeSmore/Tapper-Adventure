using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;

public class UnityAdsExample : MonoBehaviour {
	private PlayerClass playerClass;

	void Start () {
		playerClass = GameObject.FindObjectOfType<PlayerClass>();
	}

	public void ShowAd() {
   		if (Advertisement.IsReady())
    	{
      		Advertisement.Show();
    	}
  	}

	public void ShowRewardedAd()
  	{
    	if (Advertisement.IsReady("rewardedVideo"))
    	{
     			var options = new ShowOptions { resultCallback = HandleShowResult };
      			Advertisement.Show("rewardedVideo", options);
    	}
    }

    private void HandleShowResult(ShowResult result)
    {
    	switch (result)
    	{
    		case ShowResult.Finished:
        		Debug.Log("The ad was successfully shown.");
        		playerClass.CompleteRecovery();
        // YOUR CODE TO REWARD THE GAMER
        // Give coins etc.
        		break;
      		case ShowResult.Skipped:
        		Debug.Log("The ad was skipped before reaching the end.");
        		break;
     		case ShowResult.Failed:
        		Debug.LogError("The ad failed to be shown.");
        		break;
    	}
  	}
}

using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;

//--this is for unlocking another character, it uses sendmessage to call the unlock script

public class RewardedAd : MonoBehaviour
{
    public string zoneId = "rewardedVideo";
    // public int rewardQty = 250;


    void FixedUpdate()
    {
		if(Input.GetKey("space") ) {
		// 	if(Advertisement.isInitialized && Advertisement.IsReady()) {
		// 		Advertisement.Show();
		// 	}

			StartRewardedAd();
		}
		
    }

    public void StartRewardedAd()
    {
    	Debug.Log("start rewarded ad");

    	if (string.IsNullOrEmpty (zoneId)) zoneId = null;

    	ShowOptions options = new ShowOptions();
        options.resultCallback = HandleShowResult;

    	Advertisement.Show (zoneId, options);
    }

    private void HandleShowResult (ShowResult result)
    {
        Debug.Log("finished rewarded ad");

        switch (result)
        {
        case ShowResult.Finished:
            Debug.Log ("Video completed. User rewarded ");
            SendMessage("unlockSelectedCharacter");
            break;
        case ShowResult.Skipped:
            Debug.LogWarning ("Video was skipped.");
            break;
        case ShowResult.Failed:
            Debug.LogError ("Video failed to show.");
            break;
        }
    }

}
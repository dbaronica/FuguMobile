using UnityEngine;

using UnityEngine.SocialPlatforms.GameCenter;

namespace Fugu {
	
	sealed public class GameCenter : MonoBehaviour {

		public bool showAchievementBanners = true;
		// Use this for initialization
		void Start () {
#if UNITY_IPHONE && !P31_GC
		Social.localUser.Authenticate ( success => {
      	  if (success && showAchievementBanners) {
				GameCenterPlatform.ShowDefaultAchievementCompletionBanner(showAchievementBanners);
				Debug.Log ("Authenticated "+Social.localUser.userName);
        	}
			else {
				Debug.Log ("Failed to authenticate "+Social.localUser.userName);
			}
		}
    	);
#endif
#if UNITY_IPHONE && P31_GC
			GameCenterBinding.authenticateLocalPlayer();
			if (showAchievementBanners) {
				GameCenterBinding.showCompletionBannerForAchievements();
			}
#endif
	}
		
	static public void Achievement(string name) {
			Achievement(name,100.0f);
		}
		
	static public void Achievement(string name, float progress) {
		if (IsAuthenticated ()) {
#if UNITY_IPHONE && !P31_GC
			Social.ReportProgress(name,progress, success => {
#if FUGU_DEBUG
			if (success) {
				Debug.Log("Achievement "+name+" reported successfully");
			} else {
				Debug.Log("Failed to report achievement "+name);
			}
#endif
		});
#endif
#if UNITY_IPHONE && P31_GC
			GameCenterBinding.reportAchievement(name,progress);
#endif
		}
}

	static public void Score(string name,long score) {
			if (IsAuthenticated ()) {
#if UNITY_IPHONE && !P31_GC
			  Social.ReportScore (score, name, success => {
#if FUGU_DEBUG
			if (success) {
				Debug.Log("Posted "+score+" on leaderboard "+name);
			} else {
				Debug.Log("Failed to post "+score+" on leaderboard "+name);
			}
#endif
		});
#endif
#if UNITY_IPHONE && P31_GC
				GameCenterBinding.reportScore(score, name);
#endif
			}
}

	static public bool IsAuthenticated() {
#if !UNITY_IPHONE
			return false;
#endif
#if UNITY_IPHONE && !P31_GC
			return Social.localUser.authenticated;
#endif
#if UNITY_IPHONE && P31_GC
			return GameCenterBinding.isPlayerAuthenticated();
#endif
		}

			static public string GetName() {
			if (!IsAuthenticated ()) {
				return "Player";
			} else {
#if UNITY_IPHONE && !P31_GC
				return Social.localUser.userName;
#endif
				#if UNITY_IPHONE && P31_GC
				return GameCenterBinding.playerAlias();
				#endif
			}
		}

		static public void ShowLeaderboard() {
#if UNITY_IPHONE && !P31_GC
			Social.ShowLeaderboardUI ();
#endif
#if UNITY_IPHONE && P31_GC
			GameCenterBinding.showLeaderboardWithTimeScope (GameCenterLeaderboardTimeScope.AllTime);
#endif
		}

		static public void ShowAchievements() {
			#if UNITY_IPHONE && !P31_GC
			Social.ShowAchievementsUI ();
			#endif
			#if UNITY_IPHONE && P31_GC
			GameCenterBinding.showAchievements ();
			#endif
		}
	
}
}

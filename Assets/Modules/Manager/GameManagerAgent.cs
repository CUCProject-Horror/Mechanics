using UnityEngine;
using UnityEngine.Video;

namespace Game {
	[CreateAssetMenu(menuName = "Game/GameManagerAgent")]
	public class GameManagerAgent : ScriptableObject {
		public GameManager game => GameManager.instance;

		public void OnVidItemView(VideoClip thisClip) {
			game.vid.gameObject.SetActive(true);
			game.vid.PlayVidInBag(thisClip);
			game.vid.isInventory = true;
		}

		public void Pry(PlayerPry pry) {
			game.Prying = pry;
		}

		public void TVStateChange(int state) {
			game.TVState(state);
		}
		public void ProtagonistStateChange() => game.State = GameManager.StateEnum.Protagonist;

		public void ChangeInputState(int state)
		{
			game.ChangeInputState(state);
		}

		public void InventoryStateChange() {
			//game.InventoryState();
		}

		public void InspectItem(Item item) {
			//game.InspectItem(item);
		}

		public void StartConversation(string name) {
			game.ds.StopConversation();
			game.ds.StartConversation(name);
		}

		public void EndConversation() {
			game.ds.StopConversation();
		}

		public void SwitchScene(int sceneNum) {
			game.sceneChange.sceneNum = sceneNum;
		}

		public void SwitchCutscene(int cutsceneNum) {
			game.sceneChange.cutsceneNum = cutsceneNum;
		}

		public void Log(string message) {
			Debug.Log(message);
		}

		public void CanOrient(bool canOrient)
        {
			game.input.canOrient = canOrient;
        }

		public void UiChangeState(string thisState)
        {
			game.ui.AddState(thisState);
        }//��ĳ��UI��һ��string������ǰUIState

		public void UiRemoveCurrentState()
        {
			game.ui.RemoveLastState();
        }//�ر�ĳ��UIʱɾ������State

		public void RemoveItem(Item item)
        {
			game.protagonist.inventory.Deprive(item);
        }

	}
}

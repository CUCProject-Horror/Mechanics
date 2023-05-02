using UnityEngine;
using Game.Ui;
using System.Collections.Generic;
using System.Linq;

namespace Game {
	public class UiManager : MonoBehaviour {
		#region Internal fields
		Stack<UiPage> pageStack = new Stack<UiPage>();
		List<string> stateList = new List<string>();
		#endregion

		#region Serialized fields
		public GameObject uiBackground;
		public PauseUi pauseUi;
		public InventoryUi inventoryUi;
		public CategoryUi categoryUi;
		#endregion

		#region Public interfaces
		public UiPage Current => pageStack.Count == 0 ? null : pageStack.Peek();
		public string CurrentState => stateList.Count == 0 ? "Null" : stateList.Last();

		public void Open(UiPage page) {
			if(pageStack.Contains(page)) {
				if(pageStack.Peek() == page)
					return;
				throw new UnityException($"UI page {page.name} is already open in stack");
			}
			if(pageStack.Count != 0) {
				var top = pageStack.Peek();
				top.Selectable = false;
			}
			else {
				if(uiBackground)
					uiBackground.SetActive(true);
			}
			pageStack.Push(page);
			page.gameObject.SetActive(true);
			page.enabled = true;
			page.Selectable = true;
		}

		public void Close() {
			if(pageStack.Count == 0)
				return;
			var top = pageStack.Pop();
			top.gameObject.SetActive(false);
			if(pageStack.Count == 0) {
				GameManager.instance.State = GameManager.StateEnum.Protagonist;
				if(uiBackground)
					uiBackground.SetActive(false);
				return;
			}
			pageStack.Peek().Selectable = true;
		}

		public void AddState(string stateName) {
			stateList.Add(stateName);
		}

		public void RemoveLastState() {
			stateList.RemoveAt(stateList.Count - 1);
		}
		#endregion
	}
}
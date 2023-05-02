using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;
using NaughtyAttributes;

namespace Game {
	public enum ItemType {
		Collective, Prop, CD, Treasure,
	}

	public abstract class Item : ScriptableObject {
		public static Dictionary<ItemType, string> itemTypeNames = new Dictionary<ItemType, string> {
			{ ItemType.Collective, "�ռ�Ʒ" },
			{ ItemType.Prop, "����" },
			{ ItemType.CD, "¼���" },
			{ ItemType.Treasure, "����" },
		};

		public new string name;
		public ItemType type;
		public GameObject prefab;
		public Sprite selectSprite;
		public bool showDescription = true;
		[ShowIf("showDescription")]
		[ResizableTextArea]
		public string description;

		public UnityEvent onView;
	}
}
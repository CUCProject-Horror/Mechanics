using UnityEngine;
using UnityEngine.Events;
using NaughtyAttributes;

namespace Game {
	public class ItemSource : MonoBehaviour {
		#region Inspector fields
		public Item item;
		public bool infinite = false;
		[HideIf("infinite")] public uint count = 1;
		[HideIf("infinite")] public bool destroyOnEmpty;
		public UnityEvent onDeliver;
		[HideIf("infinite")] public UnityEvent onEmpty;
		public bool inspectOnDeliver = true;
		#endregion

		#region Public interfaces
		public void Deliver(Inventory inventory) {
			if(item == null) {
				Debug.LogWarning("Item to deliver is null");
				return;
			}
			inventory.Add(item);
			onDeliver.Invoke();
			if(!infinite) {
				--count;
				if(destroyOnEmpty && count == 0) {
					onEmpty.Invoke();
					Destroy(gameObject);
				}
			}
			if(inspectOnDeliver)
				GameManager.instance.InspectItem(item);
		}

		public void DeliverToProtagonist() {
			Inventory inventory = GameManager.instance.protagonist.inventory;
			if(inventory == null)
				return;
			Deliver(inventory);
		}
		#endregion

		#region Life cycle
		void Start() {
			Instantiate(item.prefab, transform);
		}

		void OnDrawGizmos() {
			var prefab = item?.prefab!;
			if (!prefab)
				return;
			Mesh mesh = prefab.GetComponentInChildren<MeshFilter>()?.sharedMesh;
			if(mesh)
				Gizmos.DrawMesh(mesh, transform.position, transform.rotation, prefab.transform.localScale);
			else
				Gizmos.DrawCube(transform.position, Vector3.one);
		}
		#endregion
	}
}
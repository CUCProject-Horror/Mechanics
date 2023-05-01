using System.Collections.Generic;
using Avocado.DeveloperCheatConsole.Scripts.Core;
using Avocado.DeveloperCheatConsole.Scripts.Core.Commands;
using UnityEngine;

    public class LevelOneCommand : MonoBehaviour
    {
        public GameObject player;
        public Transform jumpScareOne;
        public Transform startRoom;

        private void Awake()
        {
            DeveloperConsole.Instance.AddCommand(new DevCommand("TP_JumpScare1_1", "Teleport to jump scare1_1 position", () => {
                player.GetComponent<CharacterController>().enabled = false;
                player.transform.position = jumpScareOne.position;
                player.GetComponent<CharacterController>().enabled = true;
            }));//���͵�1_1JumpScare��

        DeveloperConsole.Instance.AddCommand(new DevCommand("TP_StartRoom", "Teleport to StartRoom1_1 position", () => {
            player.GetComponent<CharacterController>().enabled = false;
            player.transform.position = startRoom.position;
            player.GetComponent<CharacterController>().enabled = true;
        }));//���͵�StartRoom1_1��
    }
    }

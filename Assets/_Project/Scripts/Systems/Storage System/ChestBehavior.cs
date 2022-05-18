using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ACoolTeam
{
    public class ChestBehavior : MonoBehaviour
    {
        [SerializeField] private List<ItemObject> _chestItems;    //put chest items here
        [SerializeField] private InventoryObject _playerInv;    //link player inventory

        private PlayerInput _playerInput;
        private bool _playerInBounds;

        private void Awake()
        {
            _playerInput = new PlayerInput();
            _playerInput.Player.Interact.started += Interact;
        }

        private void OnEnable()
        {
            _playerInput.Enable();
        }

        private void OnDisable()
        {
            _playerInput.Disable();
        }

        private void Interact(InputAction.CallbackContext obj)
        {
            if (_playerInBounds)
            {
                foreach (ItemObject item in _chestItems)
                {
                    _playerInv.AddItem(new Item(item), 1);
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player")) _playerInBounds = true; 
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("Player")) _playerInBounds = false;
        }
    }
}

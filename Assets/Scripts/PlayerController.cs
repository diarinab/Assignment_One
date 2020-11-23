using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
   [SerializeField] private float player_speed = 1f;

   private Rigidbody playerRigidbody;

   private float movement_X;
   private float movement_Y;

   private int collectablesTotalCount, collectablesCounter;

   private Stopwatch stopwatch;
   
   private void Start()
   {
      playerRigidbody = GetComponent<Rigidbody>();

      collectablesTotalCount = collectablesCounter = GameObject.FindGameObjectsWithTag("Collectable").Length;

      stopwatch = Stopwatch.StartNew();
   }

   private void OnMove(InputValue inputValue)
   {
      Vector2 movementVector = inputValue.Get<Vector2>();

      movement_X = movementVector.x;
      movement_Y = movementVector.y;
   }

   private void FixedUpdate()
   {
      Vector3 movement = new Vector3(movement_X, 0f, movement_Y);

      playerRigidbody.AddForce(movement * player_speed);
   }

   private void OnTriggerEnter(Collider other)
   {
      if (other.gameObject.CompareTag("Collectable"))
      {
         other.gameObject.SetActive(false);

         collectablesCounter--;
         if (collectablesCounter == 0)
         {
            UnityEngine.Debug.Log("YOU MADE IT!");
            UnityEngine.Debug.Log($"It took you {stopwatch.Elapsed} to find all {collectablesTotalCount} coins");

#if UNITY_EDITOR
            UnityEditor.EditorApplication.ExitPlaymode();
#endif
         }
         else
         {
            UnityEngine.Debug.Log(
               $"You've already collected {collectablesTotalCount - collectablesCounter} of {collectablesTotalCount} coins! Go on!");
         }
      }
      else if (other.gameObject.CompareTag("Enemy"))
      {
         UnityEngine.Debug.Log("Try again...");
#if UNITY_EDITOR
         UnityEditor.EditorApplication.ExitPlaymode();
#endif
      }
   }
   }

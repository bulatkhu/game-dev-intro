using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleField : MonoBehaviour {
    // Initialize Health and states of the game
    int playerHP = 10;
    int dragonHP = 10;
    bool dragonCharge = false;
    bool finished = false;
    bool defend = false;

    // Start is called before the first frame update
    void Start() {
        Debug.Log("A dragon is attacking you! Use \"1\" to attack. Use \"2\" to heal yourself. Use \"3\" to defend and decrease the next incoming damage. And with \"4\" you use a special attack that can either deal massive damage to the dragon or miss and leave you vulnerable.");
    }

    void FinishGame() {
        playerHP = 0;
        Debug.Log("The dragon countered your attack and you are no match for it! You can restart by pressing Spacebar.");
        finished = true;
    }

    void HandleAttack() {
        if (Input.GetKeyUp(KeyCode.Alpha1)) {
            if (dragonCharge == false) {
                dragonHP -= Random.Range(1, 3);
                Debug.Log("You hit the dragon! It has " + dragonHP + " HP remaining.");
                HandleAITurn();
            } else
            {
                FinishGame();
            }
        }
    }

    void HandleHeal() {
        if (Input.GetKeyUp(KeyCode.Alpha2)) {
            if (dragonCharge == false) {
                playerHP += 2;
                if (playerHP > 10) {
                    playerHP = 10;
                }
                Debug.Log("You healed yourself and now have " + playerHP + " HP.");
                HandleAITurn();
            } else {
                FinishGame();
            }
        }
    }

    void HandleDefend() {
        if (Input.GetKeyUp(KeyCode.Alpha3)) {
            defend = true;

            if (dragonCharge == false) {
                Debug.Log("You are now defending yourself and will receive less damage on the next turn.");
            } else {
                Debug.Log("You are now defending yourself and the next incoming attack from the dragon will deal less damage.");
            }

            HandleAITurn();
        }
    }

    void HandleSpecialAttack() {
        if (Input.GetKeyUp(KeyCode.Alpha4)) {
            if (dragonCharge == false) {
                if (Random.value <= 0.8f) {
                    dragonHP -= Random.Range(3, 5);
                    Debug.Log("You hit the dragon with your special attack! It has " + dragonHP + " HP remaining.");
                } else {
                    playerHP -= 2;
                    Debug.Log("You missed with your special attack and hurt yourself! You have " + playerHP + " HP remaining.");
                }

                HandleAITurn();
            } else {
                FinishGame();
            }
        }
    }

    void HandleGameOver() {
        if (dragonHP <= 0 && playerHP <= 0) {
            Debug.Log("You and the dragon are both defeated! You can restart by pressing Spacebar.");
            finished = true;
        } else if (dragonHP <= 0) {
            Debug.Log("You defeated the dragon! You can restart by pressing Spacebar.");
            finished = true;
        } else if (playerHP <= 0) {
            FinishGame();
        }
    }

    // Update is called once per frame
    void Update() {
        // restart the game
        if (Input.GetKeyUp(KeyCode.Space) && finished == true) {
            playerHP = 10;
            dragonHP = 10;
            dragonCharge = false;
            finished = false;
            defend = false;
            Debug.Log("New dragon attack!");
        }

        if (finished == false) {
            // Attack
            this.HandleAttack();

            // Heal
            this.HandleHeal();

            // Defend
            this.HandleDefend();

            // Special Attack
            this.HandleSpecialAttack();

            // Game Over
            this.HandleGameOver();
        }
    }
    
    void HandleAITurn() {
        if (dragonCharge == true) {
            dragonCharge = false;
            defend = false;
        } else if (Random.value <= 0.65f) {
            if (defend == true) {
                Debug.Log("You defended the dragon's attack and received less damage.");
                defend = false;
            } else { 
                playerHP -= Random.Range(2, 5);
                Debug.Log("The dragon attacked you and you have " + playerHP + " HP remaining!");
            }
        } else {
            dragonCharge = true;
            Debug.Log("The dragon is charging a powerful attack. You must defend yourself on the next turn!");
        }
    }
}
﻿using System;
using System.Collections.Generic;

namespace DeckGenerator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Card> deck = PopulateDeck();
            byte cardsNum = IntroScreen(deck);
            for(byte i=0;i<cardsNum;i++)
            {
                if (!DisplayCard(deck, i, cardsNum))
                    i = cardsNum;
                
            }
        }


        public static List<Card> PopulateDeck()
        {
            List<Card> cards = new List<Card>();
            cards.Add(new Card(true, "Balance", "Your mind suffers a wrenching alteration, causing your Alignment to change. Lawful becomes chaotic, good becomes evil, and vice versa. If you are true neutral or unaligned, this card has no Effect on you."));
            cards.Add(new Card(true, "Comet", "If you single-handedly defeat the next Hostile monster or group of Monsters you encounter, you gain Experience Points enough to gain one level. Otherwise, this card has no Effect."));
            cards.Add(new Card(false, "Donjon", "You disappear and become entombed in a state of suspended animation in an extradimensional Sphere. Everything you were wearing and carrying stays behind in the space you occupied when you disappeared. You remain Imprisoned until you are found and removed from the Sphere. You can't be located by any Divination magic, but a wish spell can reveal the Location of your prison. You draw no more cards."));
            cards.Add(new Card(true, "Euryale", "The card's medusa-like visage Curses you. You take a -2 penalty on Saving Throws while Cursed in this way. Only a god or the magic of The Fates card can end this curse."));
            cards.Add(new Card(true, "The Fates", "Reality's fabric unravels and spins anew, allowing you to avoid or erase one event as if it never happened. You can use the card's magic as soon as you draw the card or at any other time before you die.\r\n"));
            cards.Add(new Card(true, "Flames", "A powerful devil becomes your enemy. The devil seeks your ruin and plagues your life, savoring your suffering before attempting to slay you. This enmity lasts until either you or the devil dies."));
            cards.Add(new Card(true, "Aberration", "Character loses a random limb or body part. Roll 1d4.\r\n1- Left Arm\r\n2- Left Leg\r\n3- Right Leg\r\n4- Right Arm\r\n"));
            cards.Add(new Card(true, "Gem", " Twenty-five pieces of jewelry worth 2,000 gp each or fifty gems worth 1,000 gp each appear at your feet."));
            cards.Add(new Card(true, "Idiot", "Permanently reduce your Intelligence by 1d4 + 1 (to a minimum score of 1). You can draw one additional card beyond your declared draws.\r\n"));
            cards.Add(new Card(true, "Key", "A rare or rarer Magic Weapon with which you are proficient appears in your hands. The DM chooses the weapon.\r\n"));
            cards.Add(new Card(true, "Knight", "You gain the service of a 4th-level Fighter who appears in a space you choose within 30 feet of you. The Fighter is of the same race as you and serves you loyally until death, believing the fates have drawn him or her to you. You control this character."));
            cards.Add(new Card(true, "Moon", "You are granted the ability to cast the wish spell 1d3 times"));
            cards.Add(new Card(true, "Rogue", "A nonplayer character of the DM's choice becomes Hostile toward you. The identity of your new enemy isn't known until the NPC or someone else reveals it. Nothing less than a wish spell or Divine Intervention can end the NPC's hostility toward you."));
            cards.Add(new Card(true, "Ruin", "All forms of Wealth that you carry or own, other than magic items, are lost to you. Portable property vanishes. Businesses, buildings, and land you own are lost in a way that alters reality the least. Any documentation that proves you should own something lost to this card also disappears.\r\n"));
            cards.Add(new Card(true, "Skull", "You summon an avatar of death-a ghostly Humanoid Skeleton clad in a tattered black robe and carrying a spectral scythe. It appears in a space of the DM's choice within 10 feet of you and Attacks you, warning all others that you must win the battle alone. The avatar fights until you die or it drops to 0 Hit Points, whereupon it disappears. If anyone tries to help you, the helper summons its own Avatar of Death. A creature slain by an Avatar of Death can't be restored to life.\r\n"));
            cards.Add(new Card(true, "Star", "Increase one of your Ability Scores by 2. The score can exceed 20 but can't exceed 24"));
            cards.Add(new Card(true, "Sun", "You gain 50,000 XP, and a wondrous item (which the DM determines randomly) appears in your hands."));
            cards.Add(new Card(true, "Invidia", "Character loses one of their powers, either a spell, spell-like ability, extraordinary ability, or if need be, a feat or proficiency. This power is picked up by one of their allies at random (best if someone in their party). This exchange of power lasts for 1 week."));
            cards.Add(new Card(true, "Throne", "You gain Proficiency in the Persuasion skill, and you double your Proficiency bonus on checks made with that skill. In addition, you gain rightful ownership of a small keep somewhere in the world. However, the keep is currently in the hands of Monsters, which you must clear out before you can claim the keep as yours.\r\n"));
            cards.Add(new Card(true, "Vizier", "At any time you choose within one year of drawing this card, you can ask a question in meditation and mentally receive a truthful answer to that question. Besides information, the answer helps you solve a puzzling problem or other dilemma. In other words, the knowledge comes with Wisdom on how to apply it.\r\n"));
            cards.Add(new Card(false, "The Void", "This black card Spells Disaster. Your soul is drawn from your body and contained in an object in a place of the DM's choice. One or more powerful beings guard the place. While your soul is trapped in this way, your body is Incapacitated. A wish spell can't restore your soul, but the spell reveals the Location of the object that holds it. You draw no more cards."));
            cards.Add(new Card(true, "Jester", "You gain 10,000 XP, or you can draw two additional cards beyond your declared draws."));

            return cards;
        }

        public static byte IntroScreen(List<Card> deck)
        {
            byte cardsNum;

            Console.WriteLine("Hail and well met traveller! Welcome to the deck of many things generator!");
            Console.WriteLine("How many cards would you like to draw fair traveller?");
            Console.WriteLine("Number of cards: ");
            while(!byte.TryParse(Console.ReadLine(), out cardsNum) || cardsNum > deck.Count || cardsNum < 0)
            {
                if(cardsNum > deck.Count)
                    Console.WriteLine("Trickery be afoot! That is more cards than there is in the deck traveller, please input another number.");
                else
                    Console.WriteLine("Trickery be afoot! Please input a positive number traveller.");

                Console.WriteLine("Number of cards: ");
            }
            return cardsNum;
        }

        public static bool DisplayCard(List<Card> deck, byte currentNum, byte totalNum)
        {
            bool newCard = false;
            int cardNum =0;
            string response;
            Random random = new Random();
            while(!newCard)
            {
                Console.Clear();
                Console.WriteLine($"Card Number- {currentNum + 1} of {totalNum}");
                cardNum = random.Next(0,deck.Count);
                while(deck[cardNum]._drawn == true)
                {
                    cardNum = random.Next(0, deck.Count);
                }
                Console.WriteLine(deck[cardNum].Name);
                Console.WriteLine();
                Console.WriteLine(deck[cardNum].Description);
                Console.WriteLine();
                Console.WriteLine("Was this card already drawn? (y/n)");

                response = Console.ReadLine();
                while(response.ToLower() != "y" && response.ToLower() != "n")
                {
                    Console.WriteLine("Trickery be afoot! Please input y or n");
                    response = Console.ReadLine();
                }

                if (response == "n")
                    newCard = true;
                

                deck[cardNum]._drawn = true;

            }

            return deck[cardNum]._continue;
        }
    }
}

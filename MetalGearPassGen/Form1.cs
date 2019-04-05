/**
 *  @file           Form1.cs / FormMetalGearPassGen
 *  @brief          Password Generator for the Nintendo Entertainment System Game Metal Gear
 *  @copyright      Shawn M. Crawford 2019
 *  @date           04/04/2019
 *
 *  @remark Author  Shawn M. Crawford (sleepy9090)
 *
 *  @note           Uses the guide by Doug Babcock from https://www.dougbabcock.com/mg-passwords.txt (Attached)
 *
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MetalGearPassGen
{
    public partial class FormMetalGearPassGen : Form
    {
        public FormMetalGearPassGen()
        {
            InitializeComponent();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            populateComboBoxes();
            textBoxPassword.ReadOnly = true;
        }

        private void populateComboBoxes()
        {
            for (int x = 0; x <= 255; x++)
            {
                comboBoxHandGunRounds.Items.Add(x);
                comboBoxSMGunRounds.Items.Add(x);
            }
            comboBoxHandGunRounds.SelectedIndex = 0;
            comboBoxSMGunRounds.SelectedIndex = 0;

            for (int x = 0; x <= 20; x++)
            {
                comboBoxLandMinesCount.Items.Add(x);
                comboBoxPExplosivesCount.Items.Add(x);
                comboBoxRGMissilesCount.Items.Add(x);
            }
            comboBoxLandMinesCount.SelectedIndex = 0;
            comboBoxPExplosivesCount.SelectedIndex = 0;
            comboBoxRGMissilesCount.SelectedIndex = 0;

            for (int x = 0; x <= 90; x++)
            {
                comboBoxGrenadeLauncherRounds.Items.Add(x);
            }
            comboBoxGrenadeLauncherRounds.SelectedIndex = 0;

            for (int x = 0; x <= 30; x++)
            {
                comboBoxRocketLauncherRounds.Items.Add(x);
            }
            comboBoxRocketLauncherRounds.SelectedIndex = 0;

            for (int x = 0; x <= 15; x++)
            {
                comboBoxRations.Items.Add(x);
            }
            comboBoxRations.SelectedIndex = 0;
        }

        /**
         * Bits-to-digit key:
         * ------------------
         * 00000: 1  00001: 2  00010: 3  00011: 4
         * 00100: 5  00101: 6  00110: A  00111: B
         * 01000: C  01001: D  01010: E  01011: F
         * 01100: G  01101: H  01110: I  01111: J
         * 10000: K  10001: L  10010: M  10011: N
         * 10100: O  10101: P  10110: Q  10111: R
         * 11000: S  11001: T  11010: U  11011: V
         * 11100: W  11101: X  11110: Y  11111: Z
         **/
        private string bitsIntArrayToCharString(int[] bits)
        {
            string charString = "";
            string bitsString = "";
            for (int x = 0; x < 5; x++)
            {
                bitsString += bits[x].ToString();
            }

            switch (bitsString)
            {
                case "00000":
                    charString = "1";
                    break;
                case "00001":
                    charString = "2";
                    break;
                case "00010":
                    charString = "3";
                    break;
                case "00011":
                    charString = "4";
                    break;
                case "00100":
                    charString = "5";
                    break;
                case "00101":
                    charString = "6";
                    break;
                case "00110":
                    charString = "A";
                    break;
                case "00111":
                    charString = "B";
                    break;
                case "01000":
                    charString = "C";
                    break;
                case "01001":
                    charString = "D";
                    break;
                case "01010":
                    charString = "E";
                    break;
                case "01011":
                    charString = "F";
                    break;
                case "01100":
                    charString = "G";
                    break;
                case "01101":
                    charString = "H";
                    break;
                case "01110":
                    charString = "I";
                    break;
                case "01111":
                    charString = "J";
                    break;
                case "10000":
                    charString = "K";
                    break;
                case "10001":
                    charString = "L";
                    break;
                case "10010":
                    charString = "M";
                    break;
                case "10011":
                    charString = "N";
                    break;
                case "10100":
                    charString = "O";
                    break;
                case "10101":
                    charString = "P";
                    break;
                case "10110":
                    charString = "Q";
                    break;
                case "10111":
                    charString = "R";
                    break;
                case "11000":
                    charString = "S";
                    break;
                case "11001":
                    charString = "T";
                    break;
                case "11010":
                    charString = "U";
                    break;
                case "11011":
                    charString = "V";
                    break;
                case "11100":
                    charString = "W";
                    break;
                case "11101":
                    charString = "X";
                    break;
                case "11110":
                    charString = "Y";
                    break;
                case "11111":
                    charString = "Z";
                    break;
                default:
                    // Invalid - Should not happen
                    charString = "?";
                    break;
            }
            
            return charString;
        }

        /**
         * Last Digit Value conversion key:
         * --------------------------------
         * '1':  0    '2':  1    '3':  2     '4':  3
         * '5':  4    '6':  5    'A':  6     'B':  7
         * 'C':  8    'D':  9    'E': 10     'F': 11
         * 'G': 12    'H': 13    'I': 14     'J': 15
         * 'K': 16    'L': 17    'M': 18     'N': 19
         * 'O': 20    'P': 21    'Q': 22     'R': 23
         * 'S': 24    'T': 25    'U': 26     'V': 27
         * 'W': 28    'X': 29    'Y': 30     'Z': 31
         **/
        private int getLastDigitIntValue(string charString)
        {
            int lastDigitIntValue = 0;

            switch (charString)
            {
                case "1":
                    lastDigitIntValue = 0;
                    break;
                case "2":
                    lastDigitIntValue = 1;
                    break;
                case "3":
                    lastDigitIntValue = 2;
                    break;
                case "4":
                    lastDigitIntValue = 3;
                    break;
                case "5":
                    lastDigitIntValue = 4;
                    break;
                case "6":
                    lastDigitIntValue = 5;
                    break;
                case "A":
                    lastDigitIntValue = 6;
                    break;
                case "B":
                    lastDigitIntValue = 7;
                    break;
                case "C":
                    lastDigitIntValue = 8;
                    break;
                case "D":
                    lastDigitIntValue = 9;
                    break;
                case "E":
                    lastDigitIntValue = 10;
                    break;
                case "F":
                    lastDigitIntValue = 11;
                    break;
                case "G":
                    lastDigitIntValue = 12;
                    break;
                case "H":
                    lastDigitIntValue = 13;
                    break;
                case "I":
                    lastDigitIntValue = 14;
                    break;
                case "J":
                    lastDigitIntValue = 15;
                    break;
                case "K":
                    lastDigitIntValue = 16;
                    break;
                case "L":
                    lastDigitIntValue = 17;
                    break;
                case "M":
                    lastDigitIntValue = 18;
                    break;
                case "N":
                    lastDigitIntValue = 19;
                    break;
                case "O":
                    lastDigitIntValue = 20;
                    break;
                case "P":
                    lastDigitIntValue = 21;
                    break;
                case "Q":
                    lastDigitIntValue = 22;
                    break;
                case "R":
                    lastDigitIntValue = 23;
                    break;
                case "S":
                    lastDigitIntValue = 24;
                    break;
                case "T":
                    lastDigitIntValue = 25;
                    break;
                case "U":
                    lastDigitIntValue = 26;
                    break;
                case "V":
                    lastDigitIntValue = 27;
                    break;
                case "W":
                    lastDigitIntValue = 28;
                    break;
                case "X":
                    lastDigitIntValue = 29;
                    break;
                case "Y":
                    lastDigitIntValue = 30;
                    break;
                case "Z":
                    lastDigitIntValue = 31;
                    break;
                default:
                    // Invalid - Should not happen
                    lastDigitIntValue = 0;
                    break;
            }

            return lastDigitIntValue;
        }

        private string getLastDigitStringCharValue(int lastDigitInt)
        {
            string charString = "";

            switch (lastDigitInt)
            {
                case 0:
                    charString = "1";
                    break;
                case 1:
                    charString = "2";
                    break;
                case 2:
                    charString = "3";
                    break;
                case 3:
                    charString = "4";
                    break;
                case 4:
                    charString = "5";
                    break;
                case 5:
                    charString = "6";
                    break;
                case 6:
                    charString = "A";
                    break;
                case 7:
                    charString = "B";
                    break;
                case 8:
                    charString = "C";
                    break;
                case 9:
                    charString = "D";
                    break;
                case 10:
                    charString = "E";
                    break;
                case 11:
                    charString = "F";
                    break;
                case 12:
                    charString = "G";
                    break;
                case 13:
                    charString = "H";
                    break;
                case 14:
                    charString = "I";
                    break;
                case 15:
                    charString = "J";
                    break;
                case 16:
                    charString = "K";
                    break;
                case 17:
                    charString = "L";
                    break;
                case 18:
                    charString = "M";
                    break;
                case 19:
                    charString = "N";
                    break;
                case 20:
                    charString = "O";
                    break;
                case 21:
                    charString = "P";
                    break;
                case 22:
                    charString = "Q";
                    break;
                case 23:
                    charString = "R";
                    break;
                case 24:
                    charString = "S";
                    break;
                case 25:
                    charString = "T";
                    break;
                case 26:
                    charString = "U";
                    break;
                case 27:
                    charString = "V";
                    break;
                case 28:
                    charString = "W";
                    break;
                case 29:
                    charString = "X";
                    break;
                case 30:
                    charString = "Y";
                    break;
                case 31:
                    charString = "Z";
                    break;
                default:
                    // Invalid - Should not happen
                    charString = "?";
                    break;
            }

            return charString;
        }

        /** Password Table:
        +-------------+-------------+-------------+-------------+-------------+
        |VermonCaTaffy|SuperComputer|       Rank+4|       Rank+2|       Rank+1|
        |         Tank|    Bull Tank|   Shotgunner|    Twin Shot|MachineGunKid|
        |        M.Gun|      Missile|    Explosive|         Mine|     Hand Gun|
        |  Prisoner #1|  Prisoner #2|  Prisoner #3|  Prisoner #4|  Prisoner #5|
        |  Prisoner #6|  Prisoner #7|  Prisoner #8|  Prisoner #9| Prisoner #10|
        |             |             |             |             |             |
        | Prisoner #11| Prisoner #12| Prisoner #13| Prisoner #14|XXXXXXXXXXXXX|
        |        Card5|        Card4|        Card3|        Card2|        Card1|
        |     B.B.Suit|    Cardboard|   Binoculars|      Gasmask|   Cigarettes|
        |        Light|     Antidote|      Antenna|       Armour|     Detector|
        |XXXXXXXXXXXXX|    Rations+8|    Rations+4|    Rations+2|    Rations+1|
        |             |             |             |             |             |
        |  Hand Gun+16|   Hand Gun+8|   Hand Gun+4|   Hand Gun+2|   Hand Gun+1|
        |   Missile+16|    Missile+8|    Missile+4|    Missile+2|    Missile+1|
        | Explosive+16|  Explosive+8|  Explosive+4|  Explosive+2|  Explosive+1|
        |      Mine+16|       Mine+8|       Mine+4|       Mine+2|       Mine+1|
        |     M.Gun+16|      M.Gun+8|      M.Gun+4|      M.Gun+2|      M.Gun+1|
        |             |             |             |             |             |
        |Grenade L.+16| Grenade L.+8| Grenade L.+4| Grenade L.+2| Grenade L.+1|
        | Rocket L.+16|  Rocket L.+8|  Rocket L.+4|  Rocket L.+2|  Rocket L.+1|
        |Grenade L.+64|Grenade L.+32|    M.Gun+128|     M.Gun+64|     M.Gun+32|
        |      Goggles|      Uniform|  Coward Duck| Fire Trooper|       Arnold|
        |       Oxygen|      Compass|     Silencer|    Rocket L.|   Grenade L.|
        |             |             |             |             |             |
        |    Captured!|XXXXXXXXXXXXX|XXXXXXXXXXXXX| Prisoner #15| Prisoner #16|
        |  Hand Gun+64|  Hand Gun+32| Prisoner #17| Prisoner #18| Prisoner #19|
        |        Glove|  Transmitter| Prisoner #20| Prisoner #21| Prisoner #22|
        |  Equip.Recov| Hand Gun+128|        Card8|        Card7|        Card6|
        |             |             |             |             |             |
        +-------------+-------------+-------------+-------------+-------------+
        **/
        private void buttonGeneratePassword_Click(object sender, EventArgs e)
        {
            #region Variables
            int[] bits1 = new int[5];
            int[] bits2 = new int[5];
            int[] bits3 = new int[5];
            int[] bits4 = new int[5];
            int[] bits5 = new int[5];

            int[] bits6 = new int[5];
            int[] bits7 = new int[5];
            int[] bits8 = new int[5];
            int[] bits9 = new int[5];
            int[] bits10 = new int[5];

            int[] bits11 = new int[5];
            int[] bits12 = new int[5];
            int[] bits13 = new int[5];
            int[] bits14 = new int[5];
            int[] bits15 = new int[5];

            int[] bits16 = new int[5];
            int[] bits17 = new int[5];
            int[] bits18 = new int[5];
            int[] bits19 = new int[5];
            int[] bits20 = new int[5];

            int[] bits21 = new int[5];
            int[] bits22 = new int[5];
            int[] bits23 = new int[5];
            int[] bits24 = new int[5];
            int[] bits25 = new int[5];

            string digit1String = "";
            string digit2String = "";
            string digit3String = "";
            string digit4String = "";
            string digit5String = "";

            string digit6String = "";
            string digit7String = "";
            string digit8String = "";
            string digit9String = "";
            string digit10String = "";

            string digit11String = "";
            string digit12String = "";
            string digit13String = "";
            string digit14String = "";
            string digit15String = "";

            string digit16String = "";
            string digit17String = "";
            string digit18String = "";
            string digit19String = "";
            string digit20String = "";

            string digit21String = "";
            string digit22String = "";
            string digit23String = "";
            string digit24String = "";
            string digit25String = "";
            #endregion

            #region Bosses 1
            bits1[0] = checkBoxVermonCaTaffy.Checked ? 1 : 0;
            bits1[1] = checkBoxSupercomputer.Checked ? 1 : 0;
            #endregion

            #region Stars
            bits1[2] = radioButtonFourStar.Checked ? 1 : 0;
            bits1[3] = radioButtonTwoStar.Checked ? 1 : 0;
            bits1[4] = radioButtonOneStar.Checked ? 1 : 0;
            #endregion

            #region Bosses 2
            bits2[0] = checkBoxTank.Checked ? 1 : 0;
            bits2[1] = checkBoxBullTank.Checked ? 1 : 0;
            bits2[2] = checkBoxShotgunner.Checked ? 1 : 0;
            bits2[3] = checkBoxTwinShot.Checked ? 1 : 0;
            bits2[4] = checkBoxMachineGunKid.Checked ? 1 : 0;
            #endregion

            #region Weapons 1
            bits3[0] = checkBoxSMGun.Checked ? 1 : 0;
            bits3[1] = checkBoxRGMissile.Checked ? 1 : 0;
            bits3[2] = checkBoxPExplosives.Checked ? 1 : 0;
            bits3[3] = checkBoxLandMines.Checked ? 1 : 0;
            bits3[4] = checkBoxHandGun.Checked ? 1 : 0;
            #endregion

            #region Prisoners 1
            bits4[0] = checkBoxPrisoner1.Checked ? 1 : 0;
            bits4[1] = checkBoxPrisoner2.Checked ? 1 : 0;
            bits4[2] = checkBoxPrisoner3.Checked ? 1 : 0;
            bits4[3] = checkBoxPrisoner4.Checked ? 1 : 0;
            bits4[4] = checkBoxPrisoner5.Checked ? 1 : 0;

            bits5[0] = checkBoxPrisoner6.Checked ? 1 : 0;
            bits5[1] = checkBoxPrisoner7.Checked ? 1 : 0;
            bits5[2] = checkBoxPrisoner8.Checked ? 1 : 0;
            bits5[3] = checkBoxPrisoner9.Checked ? 1 : 0;
            bits5[4] = checkBoxPrisoner10.Checked ? 1 : 0;

            bits6[0] = checkBoxPrisoner11.Checked ? 1 : 0;
            bits6[1] = checkBoxPrisoner12.Checked ? 1 : 0;
            bits6[2] = checkBoxPrisoner13.Checked ? 1 : 0;
            bits6[3] = checkBoxPrisoner14.Checked ? 1 : 0;
            #endregion

            #region Unassigned 1
            bits6[4] = 0;
            #endregion

            #region Cards 1
            bits7[0] = checkBoxCard5.Checked ? 1 : 0;
            bits7[1] = checkBoxCard4.Checked ? 1 : 0;
            bits7[2] = checkBoxCard3.Checked ? 1 : 0;
            bits7[3] = checkBoxCard2.Checked ? 1 : 0;
            bits7[4] = checkBoxCard1.Checked ? 1 : 0;
            #endregion

            #region Equipment 1
            bits8[0] = checkBoxBombBlastSuit.Checked ? 1 : 0;
            bits8[1] = checkBoxCardboardBox.Checked ? 1 : 0;
            bits8[2] = checkBoxBinoculars.Checked ? 1 : 0;
            bits8[3] = checkBoxGasMask.Checked ? 1 : 0;
            bits8[4] = checkBoxCigarettes.Checked ? 1 : 0;

            bits9[0] = checkBoxFlashlight.Checked ? 1 : 0;
            bits9[1] = checkBoxAntidote.Checked ? 1 : 0;
            bits9[2] = checkBoxAntenna.Checked ? 1 : 0;
            bits9[3] = checkBoxBodyArmor.Checked ? 1 : 0;
            bits9[4] = checkBoxMineDetector.Checked ? 1 : 0;
            #endregion

            #region Unassigned 2
            bits10[0] = 0;
            #endregion

            #region Rations
            int numberOfRations = (int)comboBoxRations.SelectedItem; // 0..15
            if(numberOfRations >= 8)
            {
                bits10[1] = 1;
                numberOfRations = numberOfRations - 8;
            }
            else
            {
                bits10[1] = 0;
            }

            if (numberOfRations >= 4)
            {
                bits10[2] = 1;
                numberOfRations = numberOfRations - 4;
            }
            else
            {
                bits10[2] = 0;
            }

            if (numberOfRations >= 2)
            {
                bits10[3] = 1;
                numberOfRations = numberOfRations - 2;
            }
            else
            {
                bits10[3] = 0;
            }

            if (numberOfRations >= 1)
            {
                bits10[4] = 1;
                numberOfRations = numberOfRations - 1;
            }
            else
            {
                bits10[4] = 0;
            }
            #endregion

            #region Hand Gun Rounds
            int numberOfHandGunRounds = (int)comboBoxHandGunRounds.SelectedItem; // 0..255
            if (numberOfHandGunRounds >= 128)
            {
                bits24[1] = 1;
                numberOfHandGunRounds = numberOfHandGunRounds - 128;
            }
            else
            {
                bits24[1] = 0;
            }

            if (numberOfHandGunRounds >= 64)
            {
                bits22[0] = 1;
                numberOfHandGunRounds = numberOfHandGunRounds - 64;
            }
            else
            {
                bits22[0] = 0;
            }

            if (numberOfHandGunRounds >= 32)
            {
                bits22[1] = 1;
                numberOfHandGunRounds = numberOfHandGunRounds - 32;
            }
            else
            {
                bits22[1] = 0;
            }

            if (numberOfHandGunRounds >= 16)
            {
                bits11[0] = 1;
                numberOfHandGunRounds = numberOfHandGunRounds - 16;
            }
            else
            {
                bits11[0] = 0;
            }

            if (numberOfHandGunRounds >= 8)
            {
                bits11[1] = 1;
                numberOfHandGunRounds = numberOfHandGunRounds - 8;
            }
            else
            {
                bits11[1] = 0;
            }

            if (numberOfHandGunRounds >= 4)
            {
                bits11[2] = 1;
                numberOfHandGunRounds = numberOfHandGunRounds - 4;
            }
            else
            {
                bits11[2] = 0;
            }

            if (numberOfHandGunRounds >= 2)
            {
                bits11[3] = 1;
                numberOfHandGunRounds = numberOfHandGunRounds - 2;
            }
            else
            {
                bits11[3] = 0;
            }

            if (numberOfHandGunRounds >= 1)
            {
                bits11[4] = 1;
                numberOfHandGunRounds = numberOfHandGunRounds - 1;
            }
            else
            {
                bits11[4] = 0;
            }
            #endregion

            #region Missiles
            int numberOfMissiles = (int)comboBoxRGMissilesCount.SelectedItem; // 0..16
            if (numberOfMissiles >= 16)
            {
                bits12[0] = 1;
                numberOfMissiles = numberOfMissiles - 16;
            }
            else
            {
                bits12[0] = 0;
            }

            if (numberOfMissiles >= 8)
            {
                bits12[1] = 1;
                numberOfMissiles = numberOfMissiles - 8;
            }
            else
            {
                bits12[1] = 0;
            }

            if (numberOfMissiles >= 4)
            {
                bits12[2] = 1;
                numberOfMissiles = numberOfMissiles - 4;
            }
            else
            {
                bits12[2] = 0;
            }

            if (numberOfMissiles >= 4)
            {
                bits12[3] = 1;
                numberOfMissiles = numberOfMissiles - 2;
            }
            else
            {
                bits12[3] = 0;
            }

            if (numberOfMissiles >= 4)
            {
                bits12[4] = 1;
                numberOfMissiles = numberOfMissiles - 1;
            }
            else
            {
                bits12[4] = 0;
            }
            #endregion

            #region Explosives
            int numberOfExplosives = (int)comboBoxPExplosivesCount.SelectedItem; // 0..16
            if (numberOfExplosives >= 16)
            {
                bits13[0] = 1;
                numberOfExplosives = numberOfExplosives - 16;
            }
            else
            {
                bits13[0] = 0;
            }

            if (numberOfExplosives >= 8)
            {
                bits13[1] = 1;
                numberOfExplosives = numberOfExplosives - 8;
            }
            else
            {
                bits13[1] = 0;
            }

            if (numberOfExplosives >= 4)
            {
                bits13[2] = 1;
                numberOfExplosives = numberOfExplosives - 4;
            }
            else
            {
                bits13[2] = 0;
            }

            if (numberOfExplosives >= 2)
            {
                bits13[3] = 1;
                numberOfExplosives = numberOfExplosives - 2;
            }
            else
            {
                bits13[3] = 0;
            }

            if (numberOfExplosives >= 1)
            {
                bits13[4] = 1;
                numberOfExplosives = numberOfExplosives - 1;
            }
            else
            {
                bits13[4] = 0;
            }
            #endregion

            #region Mines
            int numberOfMines = (int)comboBoxLandMinesCount.SelectedItem; // 0..16
            if (numberOfMines >= 16)
            {
                bits14[0] = 1;
                numberOfMines = numberOfMines - 16;
            }
            else
            {
                bits14[0] = 0;
            }

            if (numberOfMines >= 8)
            {
                bits14[1] = 1;
                numberOfMines = numberOfMines - 8;
            }
            else
            {
                bits14[1] = 0;
            }

            if (numberOfMines >= 4)
            {
                bits14[2] = 1;
                numberOfMines = numberOfMines - 4;
            }
            else
            {
                bits14[2] = 0;
            }

            if (numberOfMines >= 2)
            {
                bits14[3] = 1;
                numberOfMines = numberOfMines - 2;
            }
            else
            {
                bits14[3] = 0;
            }

            if (numberOfMines >= 1)
            {
                bits14[4] = 1;
                numberOfMines = numberOfMines - 1;
            }
            else
            {
                bits14[4] = 0;
            }
            #endregion

            #region Sub-Machine Gun Rounds
            int numberOfSubMachineRounds = (int)comboBoxSMGunRounds.SelectedItem; // 0..255
            if (numberOfSubMachineRounds >= 128)
            {
                bits18[2] = 1;
                numberOfSubMachineRounds = numberOfSubMachineRounds - 128;
            }
            else
            {
                bits18[2] = 0;
            }

            if (numberOfSubMachineRounds >= 64)
            {
                bits18[3] = 1;
                numberOfSubMachineRounds = numberOfSubMachineRounds - 64;
            }
            else
            {
                bits18[3] = 0;
            }

            if (numberOfSubMachineRounds >= 32)
            {
                bits18[4] = 1;
                numberOfSubMachineRounds = numberOfSubMachineRounds - 32;
            }
            else
            {
                bits18[4] = 0;
            }

            if (numberOfSubMachineRounds >= 16)
            {
                bits15[0] = 1;
                numberOfSubMachineRounds = numberOfSubMachineRounds - 16;
            }
            else
            {
                bits15[0] = 0;
            }

            if (numberOfSubMachineRounds >= 8)
            {
                bits15[1] = 1;
                numberOfSubMachineRounds = numberOfSubMachineRounds - 8;
            }
            else
            {
                bits15[1] = 0;
            }

            if (numberOfSubMachineRounds >= 4)
            {
                bits15[2] = 1;
                numberOfSubMachineRounds = numberOfSubMachineRounds - 4;
            }
            else
            {
                bits15[2] = 0;
            }

            if (numberOfSubMachineRounds >= 2)
            {
                bits15[3] = 1;
                numberOfSubMachineRounds = numberOfSubMachineRounds - 2;
            }
            else
            {
                bits15[3] = 0;
            }

            if (numberOfSubMachineRounds >= 1)
            {
                bits15[4] = 1;
                numberOfSubMachineRounds = numberOfSubMachineRounds - 1;
            }
            else
            {
                bits15[4] = 0;
            }
            #endregion

            #region Grenade Launcher Rounds
            int numberOfGrenadeLauncherRounds = (int)comboBoxGrenadeLauncherRounds.SelectedItem; // 0..90
            if (numberOfGrenadeLauncherRounds >= 64)
            {
                bits18[0] = 1;
                numberOfGrenadeLauncherRounds = numberOfGrenadeLauncherRounds - 64;
            }
            else
            {
                bits18[0] = 0;
            }

            if (numberOfGrenadeLauncherRounds >= 32)
            {
                bits18[1] = 1;
                numberOfGrenadeLauncherRounds = numberOfGrenadeLauncherRounds - 32;
            }
            else
            {
                bits18[1] = 0;
            }

            if (numberOfGrenadeLauncherRounds >= 16)
            {
                bits16[0] = 1;
                numberOfGrenadeLauncherRounds = numberOfGrenadeLauncherRounds - 16;
            }
            else
            {
                bits16[0] = 0;
            }

            if (numberOfGrenadeLauncherRounds >= 8)
            {
                bits16[1] = 1;
                numberOfGrenadeLauncherRounds = numberOfGrenadeLauncherRounds - 8;
            }
            else
            {
                bits16[1] = 0;
            }

            if (numberOfGrenadeLauncherRounds >= 4)
            {
                bits16[2] = 1;
                numberOfGrenadeLauncherRounds = numberOfGrenadeLauncherRounds - 4;
            }
            else
            {
                bits16[2] = 0;
            }

            if (numberOfGrenadeLauncherRounds >= 2)
            {
                bits16[3] = 1;
                numberOfGrenadeLauncherRounds = numberOfGrenadeLauncherRounds - 2;
            }
            else
            {
                bits16[3] = 0;
            }

            if (numberOfGrenadeLauncherRounds >= 1)
            {
                bits16[4] = 1;
                numberOfGrenadeLauncherRounds = numberOfGrenadeLauncherRounds - 1;
            }
            else
            {
                bits16[4] = 0;
            }
            #endregion

            #region Rocket Launcher Rounds
            int numberOfRocketLauncherRounds = (int)comboBoxRocketLauncherRounds.SelectedItem; // 0..16
            if (numberOfRocketLauncherRounds >= 16)
            {
                bits17[0] = 1;
                numberOfRocketLauncherRounds = numberOfRocketLauncherRounds - 16;
            }
            else
            {
                bits17[0] = 0;
            }

            if (numberOfRocketLauncherRounds >= 8)
            {
                bits17[1] = 1;
                numberOfRocketLauncherRounds = numberOfRocketLauncherRounds - 8;
            }
            else
            {
                bits17[1] = 0;
            }

            if (numberOfRocketLauncherRounds >= 4)
            {
                bits17[2] = 1;
                numberOfRocketLauncherRounds = numberOfRocketLauncherRounds - 4;
            }
            else
            {
                bits17[2] = 0;
            }

            if (numberOfRocketLauncherRounds >= 2)
            {
                bits17[3] = 1;
                numberOfRocketLauncherRounds = numberOfRocketLauncherRounds - 2;
            }
            else
            {
                bits17[3] = 0;
            }

            if (numberOfRocketLauncherRounds >= 1)
            {
                bits17[4] = 1;
                numberOfRocketLauncherRounds = numberOfRocketLauncherRounds - 1;
            }
            else
            {
                bits17[4] = 0;
            }
            #endregion

            #region Equipment 2
            bits19[0] = checkBoxBinoculars.Checked ? 1 : 0;
            bits19[1] = checkBoxEnemyUniform.Checked ? 1 : 0;
            #endregion

            #region Bossses 3
            bits19[2] = checkBoxCowardDuck.Checked ? 1 : 0;
            bits19[3] = checkBoxFireTrooper.Checked ? 1 : 0;
            bits19[4] = checkBoxArnold.Checked ? 1 : 0;
            #endregion

            #region Equipment 3
            bits20[0] = checkBoxOxygenTank.Checked ? 1 : 0;
            bits20[1] = checkBoxCompass.Checked ? 1 : 0;
            bits20[2] = checkBoxSilencer.Checked ? 1 : 0;
            #endregion

            #region Weapons 2
            bits20[3] = checkBoxRocketLauncher.Checked ? 1 : 0;
            bits20[4] = checkBoxGrenadeLauncher.Checked ? 1 : 0;
            #endregion

            #region Special Events 1
            bits21[0] = checkBoxIveBeenCaptured.Checked ? 1 : 0;
            #endregion

            #region Unassigned 3
            bits21[1] = 0;
            bits21[2] = 0;
            #endregion

            #region Prisoners 2
            bits21[3] = checkBoxPrisoner15.Checked ? 1 : 0;
            bits21[4] = checkBoxPrisoner16.Checked ? 1 : 0;

            bits22[2] = checkBoxPrisoner17.Checked ? 1 : 0;
            bits22[3] = checkBoxPrisoner18.Checked ? 1 : 0;
            bits22[4] = checkBoxPrisoner19.Checked ? 1 : 0;
            #endregion

            #region Equipment 4
            bits23[0] = checkBoxIronGlove.Checked ? 1 : 0;
            bits23[1] = checkBoxTransmitter.Checked ? 1 : 0;
            #endregion

            #region Prisoners 3
            bits23[2] = checkBoxPrisoner20.Checked ? 1 : 0;
            bits23[3] = checkBoxPrisoner21.Checked ? 1 : 0;
            bits23[4] = checkBoxPrisoner22.Checked ? 1 : 0;
            #endregion

            #region Special Events 2
            bits24[0] = checkBoxIveRecoveredMyEquipmentAfterwards.Checked ? 1 : 0;
            #endregion

            #region Cards 2
            bits24[2] = checkBoxCard8.Checked ? 1 : 0;
            bits24[3] = checkBoxCard7.Checked ? 1 : 0;
            bits24[4] = checkBoxCard6.Checked ? 1 : 0;
            #endregion

            #region Bits to Digits
            digit1String = bitsIntArrayToCharString(bits1);
            digit2String = bitsIntArrayToCharString(bits2);
            digit3String = bitsIntArrayToCharString(bits3);
            digit4String = bitsIntArrayToCharString(bits4);
            digit5String = bitsIntArrayToCharString(bits5);

            digit6String = bitsIntArrayToCharString(bits6);
            digit7String = bitsIntArrayToCharString(bits7);
            digit8String = bitsIntArrayToCharString(bits8);
            digit9String = bitsIntArrayToCharString(bits9);
            digit10String = bitsIntArrayToCharString(bits10);

            digit11String = bitsIntArrayToCharString(bits11);
            digit12String = bitsIntArrayToCharString(bits12);
            digit13String = bitsIntArrayToCharString(bits13);
            digit14String = bitsIntArrayToCharString(bits14);
            digit15String = bitsIntArrayToCharString(bits15);

            digit16String = bitsIntArrayToCharString(bits16);
            digit17String = bitsIntArrayToCharString(bits17);
            digit18String = bitsIntArrayToCharString(bits18);
            digit19String = bitsIntArrayToCharString(bits19);
            digit20String = bitsIntArrayToCharString(bits20);

            digit21String = bitsIntArrayToCharString(bits21);
            digit22String = bitsIntArrayToCharString(bits22);
            digit23String = bitsIntArrayToCharString(bits23);
            digit24String = bitsIntArrayToCharString(bits24);
            #endregion

            #region Get last Digit Int Value
            int lastDigitIntValue = getLastDigitIntValue(digit1String) + getLastDigitIntValue(digit2String) + getLastDigitIntValue(digit3String) + getLastDigitIntValue(digit4String) + getLastDigitIntValue(digit5String) +
                getLastDigitIntValue(digit6String) + getLastDigitIntValue(digit7String) + getLastDigitIntValue(digit8String) + getLastDigitIntValue(digit9String) + getLastDigitIntValue(digit10String) +
                getLastDigitIntValue(digit11String) + getLastDigitIntValue(digit12String) + getLastDigitIntValue(digit13String) + getLastDigitIntValue(digit14String) + getLastDigitIntValue(digit15String) +
                getLastDigitIntValue(digit16String) + getLastDigitIntValue(digit17String) + getLastDigitIntValue(digit18String) + getLastDigitIntValue(digit19String) + getLastDigitIntValue(digit20String) +
                getLastDigitIntValue(digit21String) + getLastDigitIntValue(digit22String) + getLastDigitIntValue(digit23String) + getLastDigitIntValue(digit24String);

            if (lastDigitIntValue > 507)
            {
                lastDigitIntValue += 2;
            }

            lastDigitIntValue += 7;

            while (lastDigitIntValue >= 32)
            {
                lastDigitIntValue -= 32;
            }

            digit25String = getLastDigitStringCharValue(lastDigitIntValue);
            #endregion

            #region Password
            textBoxPassword.Text = digit1String + digit2String + digit3String + digit4String + digit5String + " " +
                digit6String + digit7String + digit8String + digit9String + digit10String + " " +
                digit11String + digit12String + digit13String + digit14String + digit15String + " " +
                digit16String + digit17String + digit18String + digit19String + digit20String + " " +
                digit21String + digit22String + digit23String + digit24String + digit25String;
            #endregion
        }
    }
}

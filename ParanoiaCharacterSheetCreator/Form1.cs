using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//早苗さんかわいい
namespace PCSC
{
    public partial class Form1 : Form
    {
        public StatusForm sForm = null;
        Random DiceRoll = new System.Random();
        public int SP = 30;
        public int ADDs = 0;
        public int bAGI1, bAGI2, bAGI3, bAGI4, bAGI5;
        public int bIMP1, bIMP2, bIMP3, bIMP4, bIMP5, bIMP6, bIMP7, bIMP8, bIMP9;
        public int bMEC1, bMEC2, bMEC3, bMEC4, bMEC5, bMEC6, bMEC7, bMEC8;
        public int bDEX1, bDEX2, bDEX3, bDEX4, bDEX5;//早苗さんかわいいいいいい
        public int bSEN1, bSEN2, bSEN3, bSEN4, bSEN5, bSEN6, bSEN7, bSEN8, bSEN9, bSEN10, bSEN11, bSEN12;
        public int dAGI, dIMP, dMEC, dDEX, dSEN;
        public bool[] AU = new bool[5];
        public bool[] AD = new bool[5];
        public bool[] IU = new bool[9];
        public bool[] ID = new bool[9];
        public bool[] MU = new bool[8];
        public bool[] MD = new bool[8];
        public bool[] DU = new bool[5];
        public bool[] DD = new bool[5];
        public bool[] SU = new bool[12];
        public bool[] SD = new bool[12];
        public bool passFile = true;
        public bool StatusForm = false;
        private void AGIboolReset()
        {
            for (int i = 0; i < AU.Length; i++)
            {
                AU[i] = false;
                AD[i] = false;
            }
        }
        private void IMPboolReset()
        {
            for (int i = 0; i < IU.Length; i++)
            {
                IU[i] = false;
                ID[i] = false;
            }
        }
        private void MECboolReset()
        {
            for (int i = 0; i < MU.Length; i++)
            {
                MU[i] = false;
                MD[i] = false;
            }
        }
        private void DEXboolReset()
        {
            for (int i = 0; i < DU.Length; i++)
            {
                DU[i] = false;
                DD[i] = false;
            }
        }
        private void SENboolReset()
        {
            for (int i = 0; i < SU.Length; i++)
            {
                SU[i] = false;
                SD[i] = false;
            }
        }

        public Form1()
        {
            this.MaximizeBox = false;
            InitializeComponent();
            ResetPoint();
        }//早苗さんかわいすぎる

        private void STR_D_Click(object sender, EventArgs e)
        {
            var dice = 0;
            dice = DiceRoll.Next(1, 21);
            STR.Value = dice;
            StatusFormLoad();
        }
        private void END_D_Click(object sender, EventArgs e)
        {
            var dice = 0;
            dice = DiceRoll.Next(1, 21);
            END.Value = dice;
            END_CHANGE(dice);
        }
        private void END_CHANGE(int d) {
            int dice = d;
            if (dice <= 4) { Macho.Value = 0; ATK_Bonus.Value = -1; Max_Carry.Value = 20; HP.Value = 4; }
            else if (5 <= dice && dice <= 8) { Macho.Value = 0; ATK_Bonus.Value = 0; Max_Carry.Value = 25; HP.Value = 5; }
            else if (9 <= dice && dice <= 10) { Macho.Value = 1; ATK_Bonus.Value = 0; Max_Carry.Value = 30; HP.Value = 5; }
            else if (11 <= dice && dice <= 14) { Macho.Value = 1; ATK_Bonus.Value = 1; Max_Carry.Value = 35; HP.Value = 6; }
            else if (15 <= dice && dice <= 20) { Macho.Value = 2; ATK_Bonus.Value = 2; Max_Carry.Value = 40; HP.Value = 6; }
        }
        private void DEX_D_Click(object sender, EventArgs e)
        {
            var dice = DiceRoll.Next(1, 21);
            DEX.Value = dice;
            dDEX = dice;
            DEXboolReset();
            DEX_DICE(dice);
            DiceClick();
        }
        private void DEX_DICE(int d) {
            ////初期化////
            ResetDice();
            ResetColor();
            SetColor();
            ////メイン////
            int dice = d;
            string t = null;
            string t_Energy = null;
            string t_Plw = null;
            string t_SoH = null;
            string s = null;
            string s_Energy = null;
            string s_Plw = null;
            string s_SoH = null;
            int i, ti = 0;
            int ti_Energy = 0;
            int ti_Plw = 0;
            int ti_SoH = 0;
            if (dice <= 3) ti = 0;
            else if (4 <= dice && dice <= 6) ti = 1;
            else if (7 <= dice && dice <= 10) ti = 2;
            else if (11 <= dice && dice <= 14) ti = 3;
            else if (15 <= dice && dice <= 17) ti = 4;
            else if (18 <= dice && dice <= 20) ti = 5;
            ti_Energy = ti;
            ti_Plw = ti;
            ti_SoH = ti;
            if (ServiceGroup.SelectedIndex == 0) { ti_Energy = ti + 2; }
            if (ServiceGroup.SelectedIndex == 3) { ti_Plw = ti + 2; ti_Energy = ti + 2;  }
            if (ServiceGroup.SelectedIndex == 4) { ti_SoH = ti + 2;  }
            t = ti.ToString();
            t_Energy = ti_Energy.ToString();
            t_Plw = ti_Plw.ToString();
            t_SoH = ti_SoH.ToString();
            DEX_1_B.Text = t_Energy;
            DEX_2_B.Text = t;
            DEX_3_B.Text = t_Plw;
            DEX_4_B.Text = t;
            DEX_5_B.Text = t_SoH;
            i = int.Parse(t) + ADDs;
            ti_Energy = ti_Energy + ADDs;
            ti_Plw = ti_Plw + ADDs;
            ti_SoH = ti_SoH + ADDs;
            s = i.ToString();
            s_Energy = ti_Energy.ToString();
            s_Plw = ti_Plw.ToString();
            s_SoH = ti_SoH.ToString();
            DEX_1_S.Text = s_Energy;
            DEX_2_S.Text = s;
            DEX_3_S.Text = s_Plw;
            DEX_4_S.Text = s;
            DEX_5_S.Text = s_SoH;

        }
        private void AGI_D_Click(object sender, EventArgs e)
        {
            var dice = DiceRoll.Next(1, 21);
            AGI.Value = dice;
            dAGI = dice;
            AGIboolReset();
            AGI_DICE(dice);
            DiceClick();
        }
        private void AGI_DICE(int d){
            ////初期化////
            ResetDice();
            ResetColor();
            SetColor();
            ////メイン////
            int dice = d;
            string t_Braw = null;
            string t_Melee = null;
            string t_Prim = null;
            string t_Sneak = null;
            string t_Gre = null;
            string s_Braw = null;
            string s_Melee = null;
            string s_Prim = null;
            string s_Sneak = null;
            string s_Gre = null;
            int ti=0;
            int ti_Braw = 0;
            int ti_Melee = 0;
            int ti_Prim = 0;
            int ti_Sneak = 0;
            int ti_Gre = 0;
            if (dice <= 3) ti = 0;
            else if (4 <= dice && dice <= 6) ti = 1;
            else if (7 <= dice && dice <= 10) ti = 2;
            else if (11 <= dice && dice <= 14) ti = 3;
            else if (15 <= dice && dice <= 17) ti = 4;
            else if (18 <= dice && dice <= 20) ti = 5;
            ti_Braw = ti;
            ti_Melee = ti;
            ti_Prim = ti;
            ti_Sneak = ti;
            ti_Gre = ti;
            if (ServiceGroup.SelectedIndex == 0) { ti_Braw = ti + 2; ti_Melee = ti + 2; ti_Sneak = ti + 2;  }
            if (ServiceGroup.SelectedIndex == 3) { ti_Prim = ti + 2; ti_Gre = ti + 2; }
            t_Braw = ti_Braw.ToString();
            t_Melee = ti_Melee.ToString();
            t_Prim = ti_Prim.ToString();
            t_Sneak = ti_Sneak.ToString();
            t_Gre = ti_Gre.ToString();
            AGI_1_B.Text = t_Braw;
            AGI_2_B.Text = t_Melee;
            AGI_3_B.Text = t_Prim;
            AGI_4_B.Text = t_Sneak;
            AGI_5_B.Text = t_Gre;
            ti_Braw = ti_Braw + ADDs;
            ti_Melee = ti_Melee + ADDs;
            ti_Prim = ti_Prim + ADDs;
            ti_Sneak = ti_Sneak + ADDs;
            ti_Gre = ti_Gre + ADDs;
            s_Braw = ti_Braw.ToString();
            s_Melee = ti_Melee.ToString();
            s_Prim = ti_Prim.ToString();
            s_Sneak = ti_Sneak.ToString();
            s_Gre = ti_Gre.ToString();
            AGI_1_S.Text = s_Braw;
            AGI_2_S.Text = s_Melee;
            AGI_3_S.Text = s_Prim;
            AGI_4_S.Text = s_Sneak;
            AGI_5_S.Text = s_Gre;
        }
        private void IMP_D_Click(object sender, EventArgs e)
        {
            var dice = DiceRoll.Next(1, 21);
            IMP.Value = dice;
            dIMP = dice;
            IMPboolReset();
            IMP_DICE(dice);
            DiceClick();
        }
        private void IMP_DICE(int d) {
            ////初期化////
            ResetDice();
            ResetColor();
            SetColor();
            ////メイン////
            int dice = d;
            string t_Boot = null;
            string t_Bribery = null;
            string t_Con = null;
            string t_FastTalk = null;
            string t_Forgery = null;
            string t_Intimi = null;
            string t_Moti = null;
            string t_Phych = null;
            string t_Spuri = null;
            string s_Boot = null;
            string s_Bribery = null;
            string s_Con = null;
            string s_FastTalk = null;
            string s_Forgery = null;
            string s_Intimi = null;
            string s_Moti = null;
            string s_Phych = null;
            string s_Spuri = null;
            int ti = 0;
            int ti_Boot = 0;
            int ti_Bribery = 0;
            int ti_Con = 0;
            int ti_FastTalk = 0;
            int ti_Forgery = 0;
            int ti_Intimi = 0;
            int ti_Moti = 0;
            int ti_Phych = 0;
            int ti_Spuri = 0;
            if (dice <= 3) ti = 0;
            else if (4 <= dice && dice <= 6) ti = 1;
            else if (7 <= dice && dice <= 10) ti = 2;
            else if (11 <= dice && dice <= 14) ti = 3;
            else if (15 <= dice && dice <= 17) ti = 4;
            else if (18 <= dice && dice <= 20) ti = 5;
            ti_Boot = ti;
            ti_Bribery = ti;
            ti_Con = ti;
            ti_FastTalk = ti;
            ti_Forgery = ti;
            ti_Intimi = ti;
            ti_Moti = ti;
            ti_Phych = ti;
            ti_Spuri = ti;
            if (ServiceGroup.SelectedIndex == 0) { ti_Intimi = ti + 2; ti_Phych = ti + 2; }
            if (ServiceGroup.SelectedIndex == 1) { ti_Spuri = ti + 2; }
            if (ServiceGroup.SelectedIndex == 2) { ti_Boot = ti + 2; ti_Con = ti + 2; ti_Forgery = ti + 2; ti_Moti = ti + 2;  }
            if (ServiceGroup.SelectedIndex == 4) { ti_Bribery = ti + 2;  ti_FastTalk = ti + 2; ti_Forgery = ti + 2; }
            if (ServiceGroup.SelectedIndex == 5) { ti_Spuri = ti + 2;  }
            if (ServiceGroup.SelectedIndex == 7) { ti_Con = ti + 2; ti_FastTalk = ti + 2; ti_Intimi = ti + 2; ti_Moti = ti + 2; ti_Phych = ti + 2;}
            t_Boot = ti_Boot.ToString();
            t_Bribery = ti_Bribery.ToString();
            t_Con = ti_Con.ToString();
            t_FastTalk = ti_FastTalk.ToString();
            t_Forgery = ti_Forgery.ToString();
            t_Intimi = ti_Intimi.ToString();
            t_Moti = ti_Moti.ToString();
            t_Phych = ti_Phych.ToString();
            t_Spuri = ti_Spuri.ToString();

            IMP_1_B.Text = t_Boot;
            IMP_2_B.Text = t_Bribery;
            IMP_3_B.Text = t_Con;
            IMP_4_B.Text = t_FastTalk;
            IMP_5_B.Text = t_Forgery;
            IMP_6_B.Text = t_Intimi;
            IMP_7_B.Text = t_Moti;
            IMP_8_B.Text = t_Phych;
            IMP_9_B.Text = t_Spuri;

            ti_Boot = ti_Boot + ADDs;
            ti_Bribery = ti_Bribery + ADDs;
            ti_Con = ti_Con + ADDs;
            ti_FastTalk = ti_FastTalk + ADDs;
            ti_Forgery = ti_Forgery + ADDs;
            ti_Intimi = ti_Intimi + ADDs;
            ti_Moti = ti_Moti + ADDs;
            ti_Phych = ti_Phych + ADDs;
            ti_Spuri = ti_Spuri + ADDs;

            s_Boot = ti_Boot.ToString();
            s_Bribery = ti_Bribery.ToString();
            s_Con = ti_Con.ToString();
            s_FastTalk = ti_FastTalk.ToString();
            s_Forgery = ti_Forgery.ToString();
            s_Intimi = ti_Intimi.ToString();
            s_Moti = ti_Moti.ToString();
            s_Phych = ti_Phych.ToString();
            s_Spuri = ti_Spuri.ToString();

            IMP_1_S.Text = s_Boot;
            IMP_2_S.Text = s_Bribery;
            IMP_3_S.Text = s_Con;
            IMP_4_S.Text = s_FastTalk;
            IMP_5_S.Text = s_Forgery;
            IMP_6_S.Text = s_Intimi;
            IMP_7_S.Text = s_Moti;
            IMP_8_S.Text = s_Phych;
            IMP_9_S.Text = s_Spuri;
        }
        private void SEN_D_Click(object sender, EventArgs e)
        {
            var dice = DiceRoll.Next(1, 21);
            SEN.Value = dice;
            dSEN = dice;
            SENboolReset();
            SEN_DICE(dice);
            DiceClick();
        }
        private void SEN_DICE(int d){
            ////初期化////
            ResetDice();
            ResetColor();
            SetColor();
            ////メイン////
            int dice = d;
            string t = null;
            string t_Bio = null;
            string t_Chemi = null;
            string t_Com = null;
            string t_Demo = null;
            string t_Erec = null;
            string t_Medic = null;
            string t_Mecha = null;
            string t_Phych = null;
            string t_Surviv = null;
            string t_Nuc = null;
            string t_Secur = null;
            string s = null;
            string s_Bio = null;
            string s_Chemi = null;
            string s_Com = null;
            string s_Demo = null;
            string s_Erec = null;
            string s_Medic = null;
            string s_Mecha = null;
            string s_Phych = null;
            string s_Surviv = null;
            string s_Nuc = null;
            string s_Secur = null;
            int i, ti = 0;
            int ti_Bio = 0;
            int ti_Chemi = 0;
            int ti_Com = 0;
            int ti_Demo = 0;
            int ti_Erec = 0;
            int ti_Medic = 0;
            int ti_Mecha = 0;
            int ti_Phych = 0;
            int ti_Surviv = 0;
            int ti_Nuc = 0;
            int ti_Secur = 0;
            if (dice <= 3) ti = 0;
            else if (4 <= dice && dice <= 6) ti = 1;
            else if (7 <= dice && dice <= 10) ti = 2;
            else if (11 <= dice && dice <= 14) ti = 3;
            else if (15 <= dice && dice <= 17) ti = 4;
            else if (18 <= dice && dice <= 20) ti = 5;

            ti_Bio = ti;
            ti_Chemi = ti;
            ti_Com = ti;
            ti_Demo = ti;
            ti_Erec = ti;
            ti_Medic = ti;
            ti_Mecha = ti;
            ti_Phych = ti;
            ti_Surviv = ti;
            ti_Nuc = ti;
            ti_Secur = ti;

            if (ServiceGroup.SelectedIndex == 0) { ti_Phych = ti + 2; ti_Secur = ti + 2; }
            if (ServiceGroup.SelectedIndex == 1) { ti_Erec = ti + 2; ti_Mecha = ti + 2; }
            if (ServiceGroup.SelectedIndex == 2) { ti_Bio = ti + 2; ti_Medic = ti + 2; }
            if (ServiceGroup.SelectedIndex == 3) { ti_Surviv = ti + 2; ti_Demo = ti + 2;  }
            if (ServiceGroup.SelectedIndex == 4) { ti_Bio = ti + 2; }
            if (ServiceGroup.SelectedIndex == 5) { ti_Chemi = ti + 2; ti_Erec = ti + 2; ti_Nuc = ti + 2;  }
            if (ServiceGroup.SelectedIndex == 6) { ti_Bio = ti + 2; ti_Chemi = ti + 2; ti_Com = ti + 2; ti_Erec = ti + 2; }
            if (ServiceGroup.SelectedIndex == 7) { ti_Com = ti + 2; ti_Phych = ti + 2; ti_Secur = ti + 2; }

            t = ti.ToString();
            t_Bio = ti_Bio.ToString();
            t_Chemi = ti_Chemi.ToString();
            t_Com = ti_Com.ToString();
            t_Demo = ti_Demo.ToString();
            t_Erec = ti_Erec.ToString();
            t_Medic = ti_Medic.ToString();
            t_Mecha = ti_Mecha.ToString();
            t_Phych = ti_Phych.ToString();
            t_Surviv = ti_Surviv.ToString();
            t_Nuc = ti_Nuc.ToString();
            t_Secur = ti_Secur.ToString();

            SEN_1_B.Text = t_Bio;
            SEN_2_B.Text = t_Chemi;
            SEN_3_B.Text = t_Com;
            SEN_4_B.Text = t_Demo;
            SEN_5_B.Text = t_Erec;
            SEN_6_B.Text = t_Medic;
            SEN_7_B.Text = t_Mecha;
            SEN_8_B.Text = t_Phych;
            SEN_9_B.Text = t_Surviv;
            SEN_10_B.Text = t_Nuc;
            SEN_11_B.Text = t;
            SEN_12_B.Text = t_Secur;

            i = int.Parse(t) + ADDs;
            ti_Bio = ti_Bio + ADDs;
            ti_Chemi = ti_Chemi + ADDs;
            ti_Com = ti_Com + ADDs;
            ti_Demo = ti_Demo + ADDs;
            ti_Erec = ti_Erec + ADDs;
            ti_Medic = ti_Medic + ADDs;
            ti_Mecha = ti_Mecha + ADDs;
            ti_Phych = ti_Phych + ADDs;
            ti_Surviv = ti_Surviv + ADDs;
            ti_Nuc = ti_Nuc + ADDs;
            ti_Secur = ti_Secur + ADDs;
            
            s = i.ToString();
            s_Bio = ti_Bio.ToString();
            s_Chemi = ti_Chemi.ToString();
            s_Com = ti_Com.ToString();
            s_Demo = ti_Demo.ToString();
            s_Erec = ti_Erec.ToString();
            s_Medic = ti_Medic.ToString();
            s_Mecha = ti_Mecha.ToString();
            s_Phych = ti_Phych.ToString();
            s_Surviv = ti_Surviv.ToString();
            s_Nuc = ti_Nuc.ToString();
            s_Secur = ti_Secur.ToString();
            
            SEN_1_S.Text = s_Bio;
            SEN_2_S.Text = s_Chemi;
            SEN_3_S.Text = s_Com;
            SEN_4_S.Text = s_Demo;
            SEN_5_S.Text = s_Erec;
            SEN_6_S.Text = s_Medic;
            SEN_7_S.Text = s_Mecha;
            SEN_8_S.Text = s_Phych;
            SEN_9_S.Text = s_Surviv;
            SEN_10_S.Text = s_Nuc;
            SEN_11_S.Text = s;
            SEN_12_S.Text = s_Secur;
        }
        private void MEC_D_Click(object sender, EventArgs e)
        {
            var dice = DiceRoll.Next(1, 21);
            MEC.Value = dice;
            dMEC = dice;
            MECboolReset();
            MEC_DICE(dice);
            DiceClick();
        }
        private void MEC_DICE(int d){
            ////初期化////
            ResetDice();
            ResetColor();
            SetColor();
            ////メイン////
            int dice = d;
            string t_Milibot = null;
            string t_Civbot = null;
            string t_Vehi = null;
            string t_Habit = null;
            string t_Jurry = null;
            string t_Gvehi = null;
            string t_Avehi = null;
            string t_Vult = null;
            string s_Milibot = null;
            string s_Civbot = null;
            string s_Vehi = null;
            string s_Habit = null;
            string s_Jurry = null;
            string s_Gvehi = null;
            string s_Avehi = null;
            string s_Vult = null;
            int ti = 0;
            int ti_Milibot = 0;
            int ti_Civbot = 0;
            int ti_Vehi = 0;
            int ti_Habit = 0;
            int ti_Jurry = 0;
            int ti_Gvehi = 0;
            int ti_Avehi = 0;
            int ti_Vult = 0;
            if (dice <= 3) ti = 0;
            else if (4 <= dice && dice <= 6) ti = 1;
            else if (7 <= dice && dice <= 10) ti = 2;
            else if (11 <= dice && dice <= 14) ti = 3;
            else if (15 <= dice && dice <= 17) ti = 4;
            else if (18 <= dice && dice <= 20) ti = 5;

            ti_Milibot = ti;
            ti_Civbot = ti;
            ti_Vehi = ti;
            ti_Habit = ti;
            ti_Jurry = ti;
            ti_Gvehi = ti;
            ti_Avehi = ti;
            ti_Vult = ti;

            if (ServiceGroup.SelectedIndex == 1) { ti_Civbot = ti + 2; ti_Habit = ti + 2; ti_Jurry = ti + 2; ti_Gvehi = ti + 2;}
            if (ServiceGroup.SelectedIndex == 2) { ti_Civbot = ti + 2; }
            if (ServiceGroup.SelectedIndex == 3) { ti_Vult = ti + 2; }
            if (ServiceGroup.SelectedIndex == 4) { ti_Civbot = ti + 2; ti_Habit = ti + 2; }
            if (ServiceGroup.SelectedIndex == 5) { ti_Vehi = ti + 2; ti_Gvehi = ti + 2; ti_Avehi = ti + 2; }
            if (ServiceGroup.SelectedIndex == 6) { ti_Milibot = ti + 2; ti_Civbot = ti + 2; ti_Jurry = ti + 2;}
            
            t_Milibot = ti_Milibot.ToString();
            t_Civbot = ti_Civbot.ToString();
            t_Vehi = ti_Vehi.ToString();
            t_Habit = ti_Habit.ToString();
            t_Jurry = ti_Jurry.ToString();
            t_Gvehi = ti_Gvehi.ToString();
            t_Avehi = ti_Avehi.ToString();
            t_Vult = ti_Vult.ToString();

            MEC_1_B.Text = t_Milibot;
            MEC_2_B.Text = t_Civbot;
            MEC_3_B.Text = t_Vehi;
            MEC_4_B.Text = t_Habit;
            MEC_5_B.Text = t_Jurry;
            MEC_6_B.Text = t_Gvehi;
            MEC_7_B.Text = t_Avehi;
            MEC_8_B.Text = t_Vult;

            ti_Milibot = ti_Milibot + ADDs;
            ti_Civbot = ti_Civbot + ADDs;
            ti_Vehi = ti_Vehi + ADDs;
            ti_Habit = ti_Habit + ADDs;
            ti_Jurry = ti_Jurry + ADDs;
            ti_Gvehi = ti_Gvehi + ADDs;
            ti_Avehi = ti_Avehi + ADDs;
            ti_Vult = ti_Vult + ADDs;

            s_Milibot = ti_Milibot.ToString();
            s_Civbot = ti_Civbot.ToString();
            s_Vehi = ti_Vehi.ToString();
            s_Habit = ti_Habit.ToString();
            s_Jurry = ti_Jurry.ToString();
            s_Gvehi = ti_Gvehi.ToString();
            s_Avehi = ti_Avehi.ToString();
            s_Vult = ti_Vult.ToString();

            MEC_1_S.Text = s_Milibot;
            MEC_2_S.Text = s_Civbot;
            MEC_3_S.Text = s_Vehi;
            MEC_4_S.Text = s_Habit;
            MEC_5_S.Text = s_Jurry;
            MEC_6_S.Text = s_Gvehi;
            MEC_7_S.Text = s_Avehi;
            MEC_8_S.Text = s_Vult;
        }
        private void MUT_D_Click(object sender, EventArgs e)
        {
            var dice = 0;
            dice = DiceRoll.Next(1, 21);
            MUT.Value = dice;
            StatusFormLoad();
        }
        private void END_ValueChanged(object sender, EventArgs e)
        {
            string s = END.Value.ToString();
            int i = int.Parse(s);
            END_CHANGE(i);
            StatusFormLoad();
        }
        private void DEX_ValueChanged(object sender, EventArgs e)
        {
           int dex = int.Parse(DEX.Value.ToString());
           //DEX_DICE(dex);
           NumChangeDEX();
        }
        private void AGI_ValueChanged(object sender, EventArgs e)
        {
            string s = AGI.Value.ToString();
            int i = int.Parse(s);
            //AGI_DICE(i);
            NumChangeAGI();
        }
        private void IMP_ValueChanged(object sender, EventArgs e)
        {
            string s = IMP.Value.ToString();
            int i = int.Parse(s);
            //IMP_DICE(i);
            NumChangeIMP();
        }
        private void SEN_ValueChanged(object sender, EventArgs e)
        {
            string s = SEN.Value.ToString();
            int i = int.Parse(s);
            //SEN_DICE(i);
            NumChangeSEN();
        }
        private void MEC_ValueChanged(object sender, EventArgs e)
        {
            string s = MEC.Value.ToString();
            int i = int.Parse(s);
            //MEC_DICE(i);
            NumChangeMEC();
        }
        private void ServiceGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResetPoint();
            StatusFormLoad();
        }



        ////自作関数////
        private void ResetPoint() {
            string dex_s = DEX.Value.ToString();
            string agi_s = AGI.Value.ToString();
            string imp_s = IMP.Value.ToString();
            string sen_s = SEN.Value.ToString();
            string mec_s = MEC.Value.ToString();
            int dex_i = int.Parse(dex_s);
            int agi_i = int.Parse(agi_s);
            int imp_i = int.Parse(imp_s);
            int sen_i = int.Parse(sen_s);
            int mec_i = int.Parse(mec_s);
            DEX_DICE(dex_i);
            AGI_DICE(agi_i);
            IMP_DICE(imp_i);
            SEN_DICE(sen_i);
            MEC_DICE(mec_i);
            SP = 30;
            SkillPoint1.Text = SP.ToString();
            SkillPoint2.Text = SP.ToString();
            SkillPoint3.Text = SP.ToString();
        }
        private void ResetDice() {
            SP = 30;
            SkillPoint1.Text = SP.ToString();
            SkillPoint2.Text = SP.ToString();
            SkillPoint3.Text = SP.ToString();
        }
        private void ResetColor() {
            IMP_1_B.ForeColor = SystemColors.WindowText;
            IMP_2_B.ForeColor = SystemColors.WindowText;
            IMP_3_B.ForeColor = SystemColors.WindowText;
            IMP_4_B.ForeColor = SystemColors.WindowText;
            IMP_5_B.ForeColor = SystemColors.WindowText;
            IMP_6_B.ForeColor = SystemColors.WindowText;
            IMP_7_B.ForeColor = SystemColors.WindowText;
            IMP_8_B.ForeColor = SystemColors.WindowText;
            IMP_9_B.ForeColor = SystemColors.WindowText;
            DEX_1_B.ForeColor = SystemColors.WindowText;
            DEX_2_B.ForeColor = SystemColors.WindowText;
            DEX_3_B.ForeColor = SystemColors.WindowText;
            DEX_4_B.ForeColor = SystemColors.WindowText;
            DEX_5_B.ForeColor = SystemColors.WindowText;
            SEN_1_B.ForeColor = SystemColors.WindowText;
            SEN_2_B.ForeColor = SystemColors.WindowText;
            SEN_3_B.ForeColor = SystemColors.WindowText;
            SEN_4_B.ForeColor = SystemColors.WindowText;
            SEN_5_B.ForeColor = SystemColors.WindowText;
            SEN_6_B.ForeColor = SystemColors.WindowText;
            SEN_7_B.ForeColor = SystemColors.WindowText;
            SEN_8_B.ForeColor = SystemColors.WindowText;
            SEN_9_B.ForeColor = SystemColors.WindowText;
            SEN_10_B.ForeColor = SystemColors.WindowText;
            SEN_11_B.ForeColor = SystemColors.WindowText;
            SEN_12_B.ForeColor = SystemColors.WindowText;
            MEC_1_B.ForeColor = SystemColors.WindowText;
            MEC_2_B.ForeColor = SystemColors.WindowText;
            MEC_3_B.ForeColor = SystemColors.WindowText;
            MEC_4_B.ForeColor = SystemColors.WindowText;
            MEC_5_B.ForeColor = SystemColors.WindowText;
            MEC_6_B.ForeColor = SystemColors.WindowText;
            MEC_7_B.ForeColor = SystemColors.WindowText;
            MEC_8_B.ForeColor = SystemColors.WindowText;
            AGI_1_B.ForeColor = SystemColors.WindowText;
            AGI_2_B.ForeColor = SystemColors.WindowText;
            AGI_3_B.ForeColor = SystemColors.WindowText;
            AGI_4_B.ForeColor = SystemColors.WindowText;
            AGI_5_B.ForeColor = SystemColors.WindowText;
        }
        private void SetColor() {
            if (ServiceGroup.SelectedIndex == 0) { 
                SEN_8_B.ForeColor = Color.Red; 
                SEN_12_B.ForeColor = Color.Red;
                IMP_6_B.ForeColor = Color.Red;
                IMP_8_B.ForeColor = Color.Red;
                AGI_1_B.ForeColor = Color.Red; 
                AGI_2_B.ForeColor = Color.Red; 
                AGI_4_B.ForeColor = Color.Red;
                DEX_1_B.ForeColor = Color.Red;
            }
            if (ServiceGroup.SelectedIndex == 1) { 
                SEN_5_B.ForeColor = Color.Red; 
                SEN_7_B.ForeColor = Color.Red; 
                MEC_2_B.ForeColor = Color.Red; 
                MEC_4_B.ForeColor = Color.Red; 
                MEC_5_B.ForeColor = Color.Red; 
                MEC_6_B.ForeColor = Color.Red;
                IMP_9_B.ForeColor = Color.Red; 
            }
            if (ServiceGroup.SelectedIndex == 2) { 
                SEN_1_B.ForeColor = Color.Red; 
                SEN_6_B.ForeColor = Color.Red;
                MEC_2_B.ForeColor = Color.Red;
                IMP_1_B.ForeColor = Color.Red;
                IMP_3_B.ForeColor = Color.Red; 
                IMP_5_B.ForeColor = Color.Red; 
                IMP_7_B.ForeColor = Color.Red;
            }
            if (ServiceGroup.SelectedIndex == 3) { 
                SEN_4_B.ForeColor = Color.Red; 
                SEN_9_B.ForeColor = Color.Red;
                MEC_8_B.ForeColor = Color.Red;
                AGI_3_B.ForeColor = Color.Red; 
                AGI_5_B.ForeColor = Color.Red;
                DEX_3_B.ForeColor = Color.Red;
                DEX_1_B.ForeColor = Color.Red;
            }
            if (ServiceGroup.SelectedIndex == 4) { 
                SEN_1_B.ForeColor = Color.Red;
                MEC_2_B.ForeColor = Color.Red; 
                MEC_4_B.ForeColor = Color.Red;
                IMP_2_B.ForeColor = Color.Red; 
                IMP_4_B.ForeColor = Color.Red;
                IMP_5_B.ForeColor = Color.Red;
                DEX_5_B.ForeColor = Color.Red;
            }
            if (ServiceGroup.SelectedIndex == 5) { 
                SEN_2_B.ForeColor = Color.Red; 
                SEN_5_B.ForeColor = Color.Red; 
                SEN_10_B.ForeColor = Color.Red;
                MEC_3_B.ForeColor = Color.Red; 
                MEC_6_B.ForeColor = Color.Red; 
                MEC_7_B.ForeColor = Color.Red;
                IMP_9_B.ForeColor = Color.Red;
            }
            if (ServiceGroup.SelectedIndex == 6) { 
                SEN_1_B.ForeColor = Color.Red; 
                SEN_2_B.ForeColor = Color.Red; 
                SEN_3_B.ForeColor = Color.Red; 
                SEN_5_B.ForeColor = Color.Red;
                MEC_1_B.ForeColor = Color.Red; 
                MEC_2_B.ForeColor = Color.Red; 
                MEC_5_B.ForeColor = Color.Red; 
            }
            if (ServiceGroup.SelectedIndex == 7) { 
                SEN_3_B.ForeColor = Color.Red; 
                SEN_8_B.ForeColor = Color.Red;
                SEN_12_B.ForeColor = Color.Red;
                IMP_3_B.ForeColor = Color.Red; 
                IMP_4_B.ForeColor = Color.Red; 
                IMP_6_B.ForeColor = Color.Red; 
                IMP_7_B.ForeColor = Color.Red; 
                IMP_8_B.ForeColor = Color.Red; 
            }

        }
        private void DiceClick() { 
            DEX_DICE(int.Parse(DEX.Value.ToString()));
            AGI_DICE(int.Parse(AGI.Value.ToString()));
            IMP_DICE(int.Parse(IMP.Value.ToString()));
            SEN_DICE(int.Parse(SEN.Value.ToString()));
            MEC_DICE(int.Parse(MEC.Value.ToString()));
            StatusFormLoad();
        }
        private void NumChangeAGI()
        {
            /*
             * else if (4 <= dice && dice <= 6) ti = 1;
             * else if (7 <= dice && dice <= 10) ti = 2;
             * else if (11 <= dice && dice <= 14) ti = 3;
             * else if (15 <= dice && dice <= 17) ti = 4;
             * else if (18 <= dice && dice <= 20) ti = 5;
             */

            int[] bint = new int[5]{
                    int.Parse(AGI_1_B.Text),
                    int.Parse(AGI_2_B.Text),
                    int.Parse(AGI_3_B.Text),
                    int.Parse(AGI_4_B.Text),
                    int.Parse(AGI_5_B.Text)
            };
            int[] sint = new int[5]{
                    int.Parse(AGI_1_S.Text),
                    int.Parse(AGI_2_S.Text),
                    int.Parse(AGI_3_S.Text),
                    int.Parse(AGI_4_S.Text),
                    int.Parse(AGI_5_S.Text)
            };
            if (dAGI < AGI.Value)
            {
                if (dAGI != 4 && dAGI != 5 && 4 <= AGI.Value && AGI.Value <= 6 && AU[0] == false)
                {
                    for (int i = 0; i < bint.Length; i++)
                    {
                        bint[i]++;
                        sint[i]++;
                    }
                    AGI_1_B.Text = bint[0].ToString();
                    AGI_2_B.Text = bint[1].ToString();
                    AGI_3_B.Text = bint[2].ToString();
                    AGI_4_B.Text = bint[3].ToString();
                    AGI_5_B.Text = bint[4].ToString();
                    AGI_1_S.Text = sint[0].ToString();
                    AGI_2_S.Text = sint[1].ToString();
                    AGI_3_S.Text = sint[2].ToString();
                    AGI_4_S.Text = sint[3].ToString();
                    AGI_5_S.Text = sint[4].ToString();
                    AU[0] = true;
                    if (AD[0] == true) AD[0] = false;
                }
                else if (dAGI != 7 && dAGI != 8 && dAGI != 9 && 7 <= AGI.Value && AGI.Value <= 10 && AU[1] == false)
                {
                    for (int i = 0; i < bint.Length; i++)
                    {
                        bint[i]++;
                        sint[i]++;
                    }
                    AGI_1_B.Text = bint[0].ToString();
                    AGI_2_B.Text = bint[1].ToString();
                    AGI_3_B.Text = bint[2].ToString();
                    AGI_4_B.Text = bint[3].ToString();
                    AGI_5_B.Text = bint[4].ToString();
                    AGI_1_S.Text = sint[0].ToString();
                    AGI_2_S.Text = sint[1].ToString();
                    AGI_3_S.Text = sint[2].ToString();
                    AGI_4_S.Text = sint[3].ToString();
                    AGI_5_S.Text = sint[4].ToString();
                    AU[1] = true;
                    if (AD[1] == true) AD[1] = false;
                }
                else if (dAGI != 11 && dAGI != 12 && dAGI != 13 && 11 <= AGI.Value && AGI.Value <= 14 && AU[2] == false)
                {
                    for (int i = 0; i < bint.Length; i++)
                    {
                        bint[i]++;
                        sint[i]++;
                    }
                    AGI_1_B.Text = bint[0].ToString();
                    AGI_2_B.Text = bint[1].ToString();
                    AGI_3_B.Text = bint[2].ToString();
                    AGI_4_B.Text = bint[3].ToString();
                    AGI_5_B.Text = bint[4].ToString();
                    AGI_1_S.Text = sint[0].ToString();
                    AGI_2_S.Text = sint[1].ToString();
                    AGI_3_S.Text = sint[2].ToString();
                    AGI_4_S.Text = sint[3].ToString();
                    AGI_5_S.Text = sint[4].ToString();
                    AU[2] = true;
                    if (AD[2] == true) AD[2] = false;
                }
                else if (dAGI != 15 && dAGI != 16 && 15 <= AGI.Value && AGI.Value <= 17 && AU[3] == false)
                {
                    for (int i = 0; i < bint.Length; i++)
                    {
                        bint[i]++;
                        sint[i]++;
                    }
                    AGI_1_B.Text = bint[0].ToString();
                    AGI_2_B.Text = bint[1].ToString();
                    AGI_3_B.Text = bint[2].ToString();
                    AGI_4_B.Text = bint[3].ToString();
                    AGI_5_B.Text = bint[4].ToString();
                    AGI_1_S.Text = sint[0].ToString();
                    AGI_2_S.Text = sint[1].ToString();
                    AGI_3_S.Text = sint[2].ToString();
                    AGI_4_S.Text = sint[3].ToString();
                    AGI_5_S.Text = sint[4].ToString();
                    AU[3] = true;
                    if (AD[3] == true) AD[3] = false;
                }
                else if (dAGI != 18 && dAGI != 19 && 18 <= AGI.Value && AGI.Value <= 20 && AU[4] == false)
                {
                    for (int i = 0; i < bint.Length; i++)
                    {
                        bint[i]++;
                        sint[i]++;
                    }
                    AGI_1_B.Text = bint[0].ToString();
                    AGI_2_B.Text = bint[1].ToString();
                    AGI_3_B.Text = bint[2].ToString();
                    AGI_4_B.Text = bint[3].ToString();
                    AGI_5_B.Text = bint[4].ToString();
                    AGI_1_S.Text = sint[0].ToString();
                    AGI_2_S.Text = sint[1].ToString();
                    AGI_3_S.Text = sint[2].ToString();
                    AGI_4_S.Text = sint[3].ToString();
                    AGI_5_S.Text = sint[4].ToString();
                    AU[4] = true;
                    if (AD[4] == true) AD[4] = false;
                }
            }
            if (dAGI > AGI.Value)
            {
                if (dAGI != 3 && dAGI != 2 && dAGI != 1 && AGI.Value <= 3 && AD[0] == false)
                {
                    for (int i = 0; i < bint.Length; i++)
                    {
                        bint[i]--;
                        sint[i]--;
                    }
                    AGI_1_B.Text = bint[0].ToString();
                    AGI_2_B.Text = bint[1].ToString();
                    AGI_3_B.Text = bint[2].ToString();
                    AGI_4_B.Text = bint[3].ToString();
                    AGI_5_B.Text = bint[4].ToString();
                    AGI_1_S.Text = sint[0].ToString();
                    AGI_2_S.Text = sint[1].ToString();
                    AGI_3_S.Text = sint[2].ToString();
                    AGI_4_S.Text = sint[3].ToString();
                    AGI_5_S.Text = sint[4].ToString();
                    AD[0] = true;
                    if (AU[0] == true) AU[0] = false;
                }
                else if (dAGI != 6 && dAGI != 5 && 4 <= AGI.Value && AGI.Value <= 6 && AD[1] == false)
                {
                    for (int i = 0; i < bint.Length; i++)
                    {
                        bint[i]--;
                        sint[i]--;
                    }
                    AGI_1_B.Text = bint[0].ToString();
                    AGI_2_B.Text = bint[1].ToString();
                    AGI_3_B.Text = bint[2].ToString();
                    AGI_4_B.Text = bint[3].ToString();
                    AGI_5_B.Text = bint[4].ToString();
                    AGI_1_S.Text = sint[0].ToString();
                    AGI_2_S.Text = sint[1].ToString();
                    AGI_3_S.Text = sint[2].ToString();
                    AGI_4_S.Text = sint[3].ToString();
                    AGI_5_S.Text = sint[4].ToString();
                    AD[1] = true;
                    if (AU[1] == true) AU[1] = false;
                }
                else if (dAGI != 10 && dAGI != 9 && dAGI != 8 && 7 <= AGI.Value && AGI.Value <= 10 && AD[2] == false)
                {
                    for (int i = 0; i < bint.Length; i++)
                    {
                        bint[i]--;
                        sint[i]--;
                    }
                    AGI_1_B.Text = bint[0].ToString();
                    AGI_2_B.Text = bint[1].ToString();
                    AGI_3_B.Text = bint[2].ToString();
                    AGI_4_B.Text = bint[3].ToString();
                    AGI_5_B.Text = bint[4].ToString();
                    AGI_1_S.Text = sint[0].ToString();
                    AGI_2_S.Text = sint[1].ToString();
                    AGI_3_S.Text = sint[2].ToString();
                    AGI_4_S.Text = sint[3].ToString();
                    AGI_5_S.Text = sint[4].ToString();
                    AD[2] = true;
                    if (AU[2] == true) AU[2] = false;
                }
                else if (dAGI != 14 && dAGI != 13 && dAGI != 12 && 11 <= AGI.Value && AGI.Value <= 14 && AD[3] == false)
                {
                    for (int i = 0; i < bint.Length; i++)
                    {
                        bint[i]--;
                        sint[i]--;
                    }
                    AGI_1_B.Text = bint[0].ToString();
                    AGI_2_B.Text = bint[1].ToString();
                    AGI_3_B.Text = bint[2].ToString();
                    AGI_4_B.Text = bint[3].ToString();
                    AGI_5_B.Text = bint[4].ToString();
                    AGI_1_S.Text = sint[0].ToString();
                    AGI_2_S.Text = sint[1].ToString();
                    AGI_3_S.Text = sint[2].ToString();
                    AGI_4_S.Text = sint[3].ToString();
                    AGI_5_S.Text = sint[4].ToString();
                    AD[3] = true;
                    if (AU[3] == true) AU[3] = false;
                }
                else if (dAGI != 17 && dAGI != 16 && 15 <= AGI.Value && AGI.Value <= 17 && AD[4] == false)
                {
                    for (int i = 0; i < bint.Length; i++)
                    {
                        bint[i]--;
                        sint[i]--;
                    }
                    AGI_1_B.Text = bint[0].ToString();
                    AGI_2_B.Text = bint[1].ToString();
                    AGI_3_B.Text = bint[2].ToString();
                    AGI_4_B.Text = bint[3].ToString();
                    AGI_5_B.Text = bint[4].ToString();
                    AGI_1_S.Text = sint[0].ToString();
                    AGI_2_S.Text = sint[1].ToString();
                    AGI_3_S.Text = sint[2].ToString();
                    AGI_4_S.Text = sint[3].ToString();
                    AGI_5_S.Text = sint[4].ToString();
                    AD[4] = true;
                    if (AU[4] == true) AU[4] = false;
                }
            }
            dAGI = int.Parse(AGI.Value.ToString());
            StatusFormLoad();
        }
        private void NumChangeIMP()
        {
            /*
             * else if (4 <= dice && dice <= 6) ti = 1;
             * else if (7 <= dice && dice <= 10) ti = 2;
             * else if (11 <= dice && dice <= 14) ti = 3;
             * else if (15 <= dice && dice <= 17) ti = 4;
             * else if (18 <= dice && dice <= 20) ti = 5;
             */

            int[] bint = new int[9]{
                    int.Parse(IMP_1_B.Text),
                    int.Parse(IMP_2_B.Text),
                    int.Parse(IMP_3_B.Text),
                    int.Parse(IMP_4_B.Text),
                    int.Parse(IMP_5_B.Text),
                    int.Parse(IMP_6_B.Text),
                    int.Parse(IMP_7_B.Text),
                    int.Parse(IMP_8_B.Text),
                    int.Parse(IMP_9_B.Text)
            };
            int[] sint = new int[9]{
                    int.Parse(IMP_1_S.Text),
                    int.Parse(IMP_2_S.Text),
                    int.Parse(IMP_3_S.Text),
                    int.Parse(IMP_4_S.Text),
                    int.Parse(IMP_5_S.Text),
                    int.Parse(IMP_6_S.Text),
                    int.Parse(IMP_7_S.Text),
                    int.Parse(IMP_8_S.Text),
                    int.Parse(IMP_9_S.Text)
            };
            if (dIMP < IMP.Value)
            {
                if (dIMP != 4 && dIMP != 5 && 4 <= IMP.Value && IMP.Value <= 6 && IU[0] == false)
                {
                    for (int i = 0; i < bint.Length; i++)
                    {
                        bint[i]++;
                        sint[i]++;
                    }
                    IMP_1_B.Text = bint[0].ToString();
                    IMP_2_B.Text = bint[1].ToString();
                    IMP_3_B.Text = bint[2].ToString();
                    IMP_4_B.Text = bint[3].ToString();
                    IMP_5_B.Text = bint[4].ToString();
                    IMP_6_B.Text = bint[5].ToString();
                    IMP_7_B.Text = bint[6].ToString();
                    IMP_8_B.Text = bint[7].ToString();
                    IMP_9_B.Text = bint[8].ToString();
                    IMP_1_S.Text = sint[0].ToString();
                    IMP_2_S.Text = sint[1].ToString();
                    IMP_3_S.Text = sint[2].ToString();
                    IMP_4_S.Text = sint[3].ToString();
                    IMP_5_S.Text = sint[4].ToString();
                    IMP_6_S.Text = sint[5].ToString();
                    IMP_7_S.Text = sint[6].ToString();
                    IMP_8_S.Text = sint[7].ToString();
                    IMP_9_S.Text = sint[8].ToString();
                    IU[0] = true;
                    if (ID[0] == true) ID[0] = false;
                }
                else if (dIMP != 7 && dIMP != 8 && dIMP != 9 && 7 <= IMP.Value && IMP.Value <= 10 && IU[1] == false)
                {
                    for (int i = 0; i < bint.Length; i++)
                    {
                        bint[i]++;
                        sint[i]++;
                    } 
                    IMP_1_B.Text = bint[0].ToString();
                    IMP_2_B.Text = bint[1].ToString();
                    IMP_3_B.Text = bint[2].ToString();
                    IMP_4_B.Text = bint[3].ToString();
                    IMP_5_B.Text = bint[4].ToString();
                    IMP_6_B.Text = bint[5].ToString();
                    IMP_7_B.Text = bint[6].ToString();
                    IMP_8_B.Text = bint[7].ToString();
                    IMP_9_B.Text = bint[8].ToString();
                    IMP_1_S.Text = sint[0].ToString();
                    IMP_2_S.Text = sint[1].ToString();
                    IMP_3_S.Text = sint[2].ToString();
                    IMP_4_S.Text = sint[3].ToString();
                    IMP_5_S.Text = sint[4].ToString();
                    IMP_6_S.Text = sint[5].ToString();
                    IMP_7_S.Text = sint[6].ToString();
                    IMP_8_S.Text = sint[7].ToString();
                    IMP_9_S.Text = sint[8].ToString();
                    IU[1] = true;
                    if (ID[1] == true) ID[1] = false;
                }
                else if (dIMP != 11 && dIMP != 12 && dIMP != 13 && 11 <= IMP.Value && IMP.Value <= 14 && IU[2] == false)
                {
                    for (int i = 0; i < bint.Length; i++)
                    {
                        bint[i]++;
                        sint[i]++;
                    }
                    IMP_1_B.Text = bint[0].ToString();
                    IMP_2_B.Text = bint[1].ToString();
                    IMP_3_B.Text = bint[2].ToString();
                    IMP_4_B.Text = bint[3].ToString();
                    IMP_5_B.Text = bint[4].ToString();
                    IMP_6_B.Text = bint[5].ToString();
                    IMP_7_B.Text = bint[6].ToString();
                    IMP_8_B.Text = bint[7].ToString();
                    IMP_9_B.Text = bint[8].ToString();
                    IMP_1_S.Text = sint[0].ToString();
                    IMP_2_S.Text = sint[1].ToString();
                    IMP_3_S.Text = sint[2].ToString();
                    IMP_4_S.Text = sint[3].ToString();
                    IMP_5_S.Text = sint[4].ToString();
                    IMP_6_S.Text = sint[5].ToString();
                    IMP_7_S.Text = sint[6].ToString();
                    IMP_8_S.Text = sint[7].ToString();
                    IMP_9_S.Text = sint[8].ToString(); 
                    IU[2] = true;
                    if (ID[2] == true) ID[2] = false;
                }
                else if (dIMP != 15 && dIMP != 16 && 15 <= IMP.Value && IMP.Value <= 17 && IU[3] == false)
                {
                    for (int i = 0; i < bint.Length; i++)
                    {
                        bint[i]++;
                        sint[i]++;
                    }
                    IMP_1_B.Text = bint[0].ToString();
                    IMP_2_B.Text = bint[1].ToString();
                    IMP_3_B.Text = bint[2].ToString();
                    IMP_4_B.Text = bint[3].ToString();
                    IMP_5_B.Text = bint[4].ToString();
                    IMP_6_B.Text = bint[5].ToString();
                    IMP_7_B.Text = bint[6].ToString();
                    IMP_8_B.Text = bint[7].ToString();
                    IMP_9_B.Text = bint[8].ToString();
                    IMP_1_S.Text = sint[0].ToString();
                    IMP_2_S.Text = sint[1].ToString();
                    IMP_3_S.Text = sint[2].ToString();
                    IMP_4_S.Text = sint[3].ToString();
                    IMP_5_S.Text = sint[4].ToString();
                    IMP_6_S.Text = sint[5].ToString();
                    IMP_7_S.Text = sint[6].ToString();
                    IMP_8_S.Text = sint[7].ToString();
                    IMP_9_S.Text = sint[8].ToString();
                    IU[3] = true;
                    if (ID[3] == true) ID[3] = false;
                }
                else if (dIMP != 18 && dIMP != 19 && 18 <= IMP.Value && IMP.Value <= 20 && IU[4] == false)
                {
                    for (int i = 0; i < bint.Length; i++)
                    {
                        bint[i]++;
                        sint[i]++;
                    }
                    IMP_1_B.Text = bint[0].ToString();
                    IMP_2_B.Text = bint[1].ToString();
                    IMP_3_B.Text = bint[2].ToString();
                    IMP_4_B.Text = bint[3].ToString();
                    IMP_5_B.Text = bint[4].ToString();
                    IMP_6_B.Text = bint[5].ToString();
                    IMP_7_B.Text = bint[6].ToString();
                    IMP_8_B.Text = bint[7].ToString();
                    IMP_9_B.Text = bint[8].ToString();
                    IMP_1_S.Text = sint[0].ToString();
                    IMP_2_S.Text = sint[1].ToString();
                    IMP_3_S.Text = sint[2].ToString();
                    IMP_4_S.Text = sint[3].ToString();
                    IMP_5_S.Text = sint[4].ToString();
                    IMP_6_S.Text = sint[5].ToString();
                    IMP_7_S.Text = sint[6].ToString();
                    IMP_8_S.Text = sint[7].ToString();
                    IMP_9_S.Text = sint[8].ToString();
                    IU[4] = true;
                    if (ID[4] == true) ID[4] = false;
                }
            }
            if (dIMP > IMP.Value)
            {
                if (dIMP != 3 && dIMP != 2 && dIMP != 1 && IMP.Value <= 3 && ID[0] == false)
                {
                    for (int i = 0; i < bint.Length; i++)
                    {
                        bint[i]--;
                        sint[i]--;
                    }
                    IMP_1_B.Text = bint[0].ToString();
                    IMP_2_B.Text = bint[1].ToString();
                    IMP_3_B.Text = bint[2].ToString();
                    IMP_4_B.Text = bint[3].ToString();
                    IMP_5_B.Text = bint[4].ToString();
                    IMP_6_B.Text = bint[5].ToString();
                    IMP_7_B.Text = bint[6].ToString();
                    IMP_8_B.Text = bint[7].ToString();
                    IMP_9_B.Text = bint[8].ToString();
                    IMP_1_S.Text = sint[0].ToString();
                    IMP_2_S.Text = sint[1].ToString();
                    IMP_3_S.Text = sint[2].ToString();
                    IMP_4_S.Text = sint[3].ToString();
                    IMP_5_S.Text = sint[4].ToString();
                    IMP_6_S.Text = sint[5].ToString();
                    IMP_7_S.Text = sint[6].ToString();
                    IMP_8_S.Text = sint[7].ToString();
                    IMP_9_S.Text = sint[8].ToString();
                    ID[0] = true;
                    if (IU[0] == true) IU[0] = false;
                }
                else if (dIMP != 6 && dIMP != 5 && 4 <= IMP.Value && IMP.Value <= 6 && ID[1] == false)
                {
                    for (int i = 0; i < bint.Length; i++)
                    {
                        bint[i]--;
                        sint[i]--;
                    }
                    IMP_1_B.Text = bint[0].ToString();
                    IMP_2_B.Text = bint[1].ToString();
                    IMP_3_B.Text = bint[2].ToString();
                    IMP_4_B.Text = bint[3].ToString();
                    IMP_5_B.Text = bint[4].ToString();
                    IMP_6_B.Text = bint[5].ToString();
                    IMP_7_B.Text = bint[6].ToString();
                    IMP_8_B.Text = bint[7].ToString();
                    IMP_9_B.Text = bint[8].ToString();
                    IMP_1_S.Text = sint[0].ToString();
                    IMP_2_S.Text = sint[1].ToString();
                    IMP_3_S.Text = sint[2].ToString();
                    IMP_4_S.Text = sint[3].ToString();
                    IMP_5_S.Text = sint[4].ToString();
                    IMP_6_S.Text = sint[5].ToString();
                    IMP_7_S.Text = sint[6].ToString();
                    IMP_8_S.Text = sint[7].ToString();
                    IMP_9_S.Text = sint[8].ToString();
                    ID[1] = true;
                    if (IU[1] == true) IU[1] = false;
                }
                else if (dIMP != 10 && dIMP != 9 && dIMP != 8 && 7 <= IMP.Value && IMP.Value <= 10 && ID[2] == false)
                {
                    for (int i = 0; i < bint.Length; i++)
                    {
                        bint[i]--;
                        sint[i]--;
                    }
                    IMP_1_B.Text = bint[0].ToString();
                    IMP_2_B.Text = bint[1].ToString();
                    IMP_3_B.Text = bint[2].ToString();
                    IMP_4_B.Text = bint[3].ToString();
                    IMP_5_B.Text = bint[4].ToString();
                    IMP_6_B.Text = bint[5].ToString();
                    IMP_7_B.Text = bint[6].ToString();
                    IMP_8_B.Text = bint[7].ToString();
                    IMP_9_B.Text = bint[8].ToString();
                    IMP_1_S.Text = sint[0].ToString();
                    IMP_2_S.Text = sint[1].ToString();
                    IMP_3_S.Text = sint[2].ToString();
                    IMP_4_S.Text = sint[3].ToString();
                    IMP_5_S.Text = sint[4].ToString();
                    IMP_6_S.Text = sint[5].ToString();
                    IMP_7_S.Text = sint[6].ToString();
                    IMP_8_S.Text = sint[7].ToString();
                    IMP_9_S.Text = sint[8].ToString();
                    ID[2] = true;
                    if (IU[2] == true) IU[2] = false;
                }
                else if (dIMP != 14 && dIMP != 13 && dIMP != 12 && 11 <= IMP.Value && IMP.Value <= 14 && ID[3] == false)
                {
                    for (int i = 0; i < bint.Length; i++)
                    {
                        bint[i]--;
                        sint[i]--;
                    } 
                    IMP_1_B.Text = bint[0].ToString();
                    IMP_2_B.Text = bint[1].ToString();
                    IMP_3_B.Text = bint[2].ToString();
                    IMP_4_B.Text = bint[3].ToString();
                    IMP_5_B.Text = bint[4].ToString();
                    IMP_6_B.Text = bint[5].ToString();
                    IMP_7_B.Text = bint[6].ToString();
                    IMP_8_B.Text = bint[7].ToString();
                    IMP_9_B.Text = bint[8].ToString();
                    IMP_1_S.Text = sint[0].ToString();
                    IMP_2_S.Text = sint[1].ToString();
                    IMP_3_S.Text = sint[2].ToString();
                    IMP_4_S.Text = sint[3].ToString();
                    IMP_5_S.Text = sint[4].ToString();
                    IMP_6_S.Text = sint[5].ToString();
                    IMP_7_S.Text = sint[6].ToString();
                    IMP_8_S.Text = sint[7].ToString();
                    IMP_9_S.Text = sint[8].ToString();
                    ID[3] = true;
                    if (IU[3] == true) IU[3] = false;
                }
                else if (dIMP != 17 && dIMP != 16 && 15 <= IMP.Value && IMP.Value <= 17 && ID[4] == false)
                {
                    for (int i = 0; i < bint.Length; i++)
                    {
                        bint[i]--;
                        sint[i]--;
                    }
                    IMP_1_B.Text = bint[0].ToString();
                    IMP_2_B.Text = bint[1].ToString();
                    IMP_3_B.Text = bint[2].ToString();
                    IMP_4_B.Text = bint[3].ToString();
                    IMP_5_B.Text = bint[4].ToString();
                    IMP_6_B.Text = bint[5].ToString();
                    IMP_7_B.Text = bint[6].ToString();
                    IMP_8_B.Text = bint[7].ToString();
                    IMP_9_B.Text = bint[8].ToString();
                    IMP_1_S.Text = sint[0].ToString();
                    IMP_2_S.Text = sint[1].ToString();
                    IMP_3_S.Text = sint[2].ToString();
                    IMP_4_S.Text = sint[3].ToString();
                    IMP_5_S.Text = sint[4].ToString();
                    IMP_6_S.Text = sint[5].ToString();
                    IMP_7_S.Text = sint[6].ToString();
                    IMP_8_S.Text = sint[7].ToString();
                    IMP_9_S.Text = sint[8].ToString();
                    ID[4] = true;
                    if (IU[4] == true) IU[4] = false;
                }
            }
            dIMP = int.Parse(IMP.Value.ToString());
            StatusFormLoad();
        }
        private void NumChangeMEC()
        {
            /*
             * else if (4 <= dice && dice <= 6) ti = 1;
             * else if (7 <= dice && dice <= 10) ti = 2;
             * else if (11 <= dice && dice <= 14) ti = 3;
             * else if (15 <= dice && dice <= 17) ti = 4;
             * else if (18 <= dice && dice <= 20) ti = 5;
             */

            int[] bint = new int[8]{
                    int.Parse(MEC_1_B.Text),
                    int.Parse(MEC_2_B.Text),
                    int.Parse(MEC_3_B.Text),
                    int.Parse(MEC_4_B.Text),
                    int.Parse(MEC_5_B.Text),
                    int.Parse(MEC_6_B.Text),
                    int.Parse(MEC_7_B.Text),
                    int.Parse(MEC_8_B.Text)
            };
            int[] sint = new int[8]{
                    int.Parse(MEC_1_S.Text),
                    int.Parse(MEC_2_S.Text),
                    int.Parse(MEC_3_S.Text),
                    int.Parse(MEC_4_S.Text),
                    int.Parse(MEC_5_S.Text),
                    int.Parse(MEC_6_S.Text),
                    int.Parse(MEC_7_S.Text),
                    int.Parse(MEC_8_S.Text)
            };
            if (dMEC < MEC.Value)
            {
                if (dMEC != 4 && dMEC != 5 && 4 <= MEC.Value && MEC.Value <= 6 && MU[0] == false)
                {
                    for (int i = 0; i < bint.Length; i++)
                    {
                        bint[i]++;
                        sint[i]++;
                    }
                    MEC_1_B.Text = bint[0].ToString();
                    MEC_2_B.Text = bint[1].ToString();
                    MEC_3_B.Text = bint[2].ToString();
                    MEC_4_B.Text = bint[3].ToString();
                    MEC_5_B.Text = bint[4].ToString();
                    MEC_6_B.Text = bint[5].ToString();
                    MEC_7_B.Text = bint[6].ToString();
                    MEC_8_B.Text = bint[7].ToString();
                    MEC_1_S.Text = sint[0].ToString();
                    MEC_2_S.Text = sint[1].ToString();
                    MEC_3_S.Text = sint[2].ToString();
                    MEC_4_S.Text = sint[3].ToString();
                    MEC_5_S.Text = sint[4].ToString();
                    MEC_6_S.Text = sint[5].ToString();
                    MEC_7_S.Text = sint[6].ToString();
                    MEC_8_S.Text = sint[7].ToString();
                    MU[0] = true;
                    if (MD[0] == true) MD[0] = false;
                }
                else if (dMEC != 7 && dMEC != 8 && dMEC != 9 && 7 <= MEC.Value && MEC.Value <= 10 && MU[1] == false)
                {
                    for (int i = 0; i < bint.Length; i++)
                    {
                        bint[i]++;
                        sint[i]++;
                    }
                    MEC_1_B.Text = bint[0].ToString();
                    MEC_2_B.Text = bint[1].ToString();
                    MEC_3_B.Text = bint[2].ToString();
                    MEC_4_B.Text = bint[3].ToString();
                    MEC_5_B.Text = bint[4].ToString();
                    MEC_6_B.Text = bint[5].ToString();
                    MEC_7_B.Text = bint[6].ToString();
                    MEC_8_B.Text = bint[7].ToString();
                    MEC_1_S.Text = sint[0].ToString();
                    MEC_2_S.Text = sint[1].ToString();
                    MEC_3_S.Text = sint[2].ToString();
                    MEC_4_S.Text = sint[3].ToString();
                    MEC_5_S.Text = sint[4].ToString();
                    MEC_6_S.Text = sint[5].ToString();
                    MEC_7_S.Text = sint[6].ToString();
                    MEC_8_S.Text = sint[7].ToString();
                    MU[1] = true;
                    if (MD[1] == true) MD[1] = false;
                }
                else if (dMEC != 11 && dMEC != 12 && dMEC != 13 && 11 <= MEC.Value && MEC.Value <= 14 && MU[2] == false)
                {
                    for (int i = 0; i < bint.Length; i++)
                    {
                        bint[i]++;
                        sint[i]++;
                    }
                    MEC_1_B.Text = bint[0].ToString();
                    MEC_2_B.Text = bint[1].ToString();
                    MEC_3_B.Text = bint[2].ToString();
                    MEC_4_B.Text = bint[3].ToString();
                    MEC_5_B.Text = bint[4].ToString();
                    MEC_6_B.Text = bint[5].ToString();
                    MEC_7_B.Text = bint[6].ToString();
                    MEC_8_B.Text = bint[7].ToString();
                    MEC_1_S.Text = sint[0].ToString();
                    MEC_2_S.Text = sint[1].ToString();
                    MEC_3_S.Text = sint[2].ToString();
                    MEC_4_S.Text = sint[3].ToString();
                    MEC_5_S.Text = sint[4].ToString();
                    MEC_6_S.Text = sint[5].ToString();
                    MEC_7_S.Text = sint[6].ToString();
                    MEC_8_S.Text = sint[7].ToString();
                    MU[2] = true;
                    if (MD[2] == true) MD[2] = false;
                }
                else if (dMEC != 15 && dMEC != 16 && 15 <= MEC.Value && MEC.Value <= 17 && MU[3] == false)
                {
                    for (int i = 0; i < bint.Length; i++)
                    {
                        bint[i]++;
                        sint[i]++;
                    }
                    MEC_1_B.Text = bint[0].ToString();
                    MEC_2_B.Text = bint[1].ToString();
                    MEC_3_B.Text = bint[2].ToString();
                    MEC_4_B.Text = bint[3].ToString();
                    MEC_5_B.Text = bint[4].ToString();
                    MEC_6_B.Text = bint[5].ToString();
                    MEC_7_B.Text = bint[6].ToString();
                    MEC_8_B.Text = bint[7].ToString();
                    MEC_1_S.Text = sint[0].ToString();
                    MEC_2_S.Text = sint[1].ToString();
                    MEC_3_S.Text = sint[2].ToString();
                    MEC_4_S.Text = sint[3].ToString();
                    MEC_5_S.Text = sint[4].ToString();
                    MEC_6_S.Text = sint[5].ToString();
                    MEC_7_S.Text = sint[6].ToString();
                    MEC_8_S.Text = sint[7].ToString();
                    MU[3] = true;
                    if (MD[3] == true) MD[3] = false;
                }
                else if (dMEC != 18 && dMEC != 19 && 18 <= MEC.Value && MEC.Value <= 20 && MU[4] == false)
                {
                    for (int i = 0; i < bint.Length; i++)
                    {
                        bint[i]++;
                        sint[i]++;
                    }
                    MEC_1_B.Text = bint[0].ToString();
                    MEC_2_B.Text = bint[1].ToString();
                    MEC_3_B.Text = bint[2].ToString();
                    MEC_4_B.Text = bint[3].ToString();
                    MEC_5_B.Text = bint[4].ToString();
                    MEC_6_B.Text = bint[5].ToString();
                    MEC_7_B.Text = bint[6].ToString();
                    MEC_8_B.Text = bint[7].ToString();
                    MEC_1_S.Text = sint[0].ToString();
                    MEC_2_S.Text = sint[1].ToString();
                    MEC_3_S.Text = sint[2].ToString();
                    MEC_4_S.Text = sint[3].ToString();
                    MEC_5_S.Text = sint[4].ToString();
                    MEC_6_S.Text = sint[5].ToString();
                    MEC_7_S.Text = sint[6].ToString();
                    MEC_8_S.Text = sint[7].ToString();
                    MU[4] = true;
                    if (MD[4] == true) MD[4] = false;
                }
            }
            if (dMEC > MEC.Value)
            {
                if (dMEC != 3 && dMEC != 2 && dMEC != 1 && MEC.Value <= 3 && MD[0] == false)
                {
                    for (int i = 0; i < bint.Length; i++)
                    {
                        bint[i]--;
                        sint[i]--;
                    }
                    MEC_1_B.Text = bint[0].ToString();
                    MEC_2_B.Text = bint[1].ToString();
                    MEC_3_B.Text = bint[2].ToString();
                    MEC_4_B.Text = bint[3].ToString();
                    MEC_5_B.Text = bint[4].ToString();
                    MEC_6_B.Text = bint[5].ToString();
                    MEC_7_B.Text = bint[6].ToString();
                    MEC_8_B.Text = bint[7].ToString();
                    MEC_1_S.Text = sint[0].ToString();
                    MEC_2_S.Text = sint[1].ToString();
                    MEC_3_S.Text = sint[2].ToString();
                    MEC_4_S.Text = sint[3].ToString();
                    MEC_5_S.Text = sint[4].ToString();
                    MEC_6_S.Text = sint[5].ToString();
                    MEC_7_S.Text = sint[6].ToString();
                    MEC_8_S.Text = sint[7].ToString();
                    MD[0] = true;
                    if (MU[0] == true) MU[0] = false;
                }
                else if (dMEC != 6 && dMEC != 5 && 4 <= MEC.Value && MEC.Value <= 6 && MD[1] == false)
                {
                    for (int i = 0; i < bint.Length; i++)
                    {
                        bint[i]--;
                        sint[i]--;
                    }
                    MEC_1_B.Text = bint[0].ToString();
                    MEC_2_B.Text = bint[1].ToString();
                    MEC_3_B.Text = bint[2].ToString();
                    MEC_4_B.Text = bint[3].ToString();
                    MEC_5_B.Text = bint[4].ToString();
                    MEC_6_B.Text = bint[5].ToString();
                    MEC_7_B.Text = bint[6].ToString();
                    MEC_8_B.Text = bint[7].ToString();
                    MEC_1_S.Text = sint[0].ToString();
                    MEC_2_S.Text = sint[1].ToString();
                    MEC_3_S.Text = sint[2].ToString();
                    MEC_4_S.Text = sint[3].ToString();
                    MEC_5_S.Text = sint[4].ToString();
                    MEC_6_S.Text = sint[5].ToString();
                    MEC_7_S.Text = sint[6].ToString();
                    MEC_8_S.Text = sint[7].ToString();
                    MD[1] = true;
                    if (MU[1] == true) MU[1] = false;
                }
                else if (dMEC != 10 && dMEC != 9 && dMEC != 8 && 7 <= MEC.Value && MEC.Value <= 10 && MD[2] == false)
                {
                    for (int i = 0; i < bint.Length; i++)
                    {
                        bint[i]--;
                        sint[i]--;
                    }
                    MEC_1_B.Text = bint[0].ToString();
                    MEC_2_B.Text = bint[1].ToString();
                    MEC_3_B.Text = bint[2].ToString();
                    MEC_4_B.Text = bint[3].ToString();
                    MEC_5_B.Text = bint[4].ToString();
                    MEC_6_B.Text = bint[5].ToString();
                    MEC_7_B.Text = bint[6].ToString();
                    MEC_8_B.Text = bint[7].ToString();
                    MEC_1_S.Text = sint[0].ToString();
                    MEC_2_S.Text = sint[1].ToString();
                    MEC_3_S.Text = sint[2].ToString();
                    MEC_4_S.Text = sint[3].ToString();
                    MEC_5_S.Text = sint[4].ToString();
                    MEC_6_S.Text = sint[5].ToString();
                    MEC_7_S.Text = sint[6].ToString();
                    MEC_8_S.Text = sint[7].ToString();
                    MD[2] = true;
                    if (MU[2] == true) MU[2] = false;
                }
                else if (dMEC != 14 && dMEC != 13 && dMEC != 12 && 11 <= MEC.Value && MEC.Value <= 14 && MD[3] == false)
                {
                    for (int i = 0; i < bint.Length; i++)
                    {
                        bint[i]--;
                        sint[i]--;
                    }
                    MEC_1_B.Text = bint[0].ToString();
                    MEC_2_B.Text = bint[1].ToString();
                    MEC_3_B.Text = bint[2].ToString();
                    MEC_4_B.Text = bint[3].ToString();
                    MEC_5_B.Text = bint[4].ToString();
                    MEC_6_B.Text = bint[5].ToString();
                    MEC_7_B.Text = bint[6].ToString();
                    MEC_8_B.Text = bint[7].ToString();
                    MEC_1_S.Text = sint[0].ToString();
                    MEC_2_S.Text = sint[1].ToString();
                    MEC_3_S.Text = sint[2].ToString();
                    MEC_4_S.Text = sint[3].ToString();
                    MEC_5_S.Text = sint[4].ToString();
                    MEC_6_S.Text = sint[5].ToString();
                    MEC_7_S.Text = sint[6].ToString();
                    MEC_8_S.Text = sint[7].ToString();
                    MD[3] = true;
                    if (MU[3] == true) MU[3] = false;
                }
                else if (dMEC != 17 && dMEC != 16 && 15 <= MEC.Value && MEC.Value <= 17 && MD[4] == false)
                {
                    for (int i = 0; i < bint.Length; i++)
                    {
                        bint[i]--;
                        sint[i]--;
                    }
                    MEC_1_B.Text = bint[0].ToString();
                    MEC_2_B.Text = bint[1].ToString();
                    MEC_3_B.Text = bint[2].ToString();
                    MEC_4_B.Text = bint[3].ToString();
                    MEC_5_B.Text = bint[4].ToString();
                    MEC_6_B.Text = bint[5].ToString();
                    MEC_7_B.Text = bint[6].ToString();
                    MEC_8_B.Text = bint[7].ToString();
                    MEC_1_S.Text = sint[0].ToString();
                    MEC_2_S.Text = sint[1].ToString();
                    MEC_3_S.Text = sint[2].ToString();
                    MEC_4_S.Text = sint[3].ToString();
                    MEC_5_S.Text = sint[4].ToString();
                    MEC_6_S.Text = sint[5].ToString();
                    MEC_7_S.Text = sint[6].ToString();
                    MEC_8_S.Text = sint[7].ToString();
                    MD[4] = true;
                    if (MU[4] == true) MU[4] = false;
                }
            }
            dMEC = int.Parse(MEC.Value.ToString());
            StatusFormLoad();
        }
        private void NumChangeSEN()
        {
            /*
             * else if (4 <= dice && dice <= 6) ti = 1;
             * else if (7 <= dice && dice <= 10) ti = 2;
             * else if (11 <= dice && dice <= 14) ti = 3;
             * else if (15 <= dice && dice <= 17) ti = 4;
             * else if (18 <= dice && dice <= 20) ti = 5;
             */

            int[] bint = new int[12]{
                    int.Parse(SEN_1_B.Text),
                    int.Parse(SEN_2_B.Text),
                    int.Parse(SEN_3_B.Text),
                    int.Parse(SEN_4_B.Text),
                    int.Parse(SEN_5_B.Text),
                    int.Parse(SEN_6_B.Text),
                    int.Parse(SEN_7_B.Text),
                    int.Parse(SEN_8_B.Text),
                    int.Parse(SEN_9_B.Text),
                    int.Parse(SEN_10_B.Text),
                    int.Parse(SEN_11_B.Text),
                    int.Parse(SEN_12_B.Text)
            };
            int[] sint = new int[12]{
                    int.Parse(SEN_1_S.Text),
                    int.Parse(SEN_2_S.Text),
                    int.Parse(SEN_3_S.Text),
                    int.Parse(SEN_4_S.Text),
                    int.Parse(SEN_5_S.Text),
                    int.Parse(SEN_6_S.Text),
                    int.Parse(SEN_7_S.Text),
                    int.Parse(SEN_8_S.Text),
                    int.Parse(SEN_9_S.Text),
                    int.Parse(SEN_10_S.Text),
                    int.Parse(SEN_11_S.Text),
                    int.Parse(SEN_12_S.Text)
            };
            if (dSEN < SEN.Value)
            {
                if (dSEN != 4 && dSEN != 5 && 4 <= SEN.Value && SEN.Value <= 6 && SU[0] == false)
                {
                    for (int i = 0; i < bint.Length; i++)
                    {
                        bint[i]++;
                        sint[i]++;
                    }
                    SEN_1_B.Text = bint[0].ToString();
                    SEN_2_B.Text = bint[1].ToString();
                    SEN_3_B.Text = bint[2].ToString();
                    SEN_4_B.Text = bint[3].ToString();
                    SEN_5_B.Text = bint[4].ToString();
                    SEN_6_B.Text = bint[5].ToString();
                    SEN_7_B.Text = bint[6].ToString();
                    SEN_8_B.Text = bint[7].ToString();
                    SEN_9_B.Text = bint[8].ToString();
                    SEN_10_B.Text = bint[9].ToString();
                    SEN_11_B.Text = bint[10].ToString();
                    SEN_12_B.Text = bint[11].ToString();
                    SEN_1_S.Text = sint[0].ToString();
                    SEN_2_S.Text = sint[1].ToString();
                    SEN_3_S.Text = sint[2].ToString();
                    SEN_4_S.Text = sint[3].ToString();
                    SEN_5_S.Text = sint[4].ToString();
                    SEN_6_S.Text = sint[5].ToString();
                    SEN_7_S.Text = sint[6].ToString();
                    SEN_8_S.Text = sint[7].ToString();
                    SEN_9_S.Text = sint[8].ToString();
                    SEN_10_S.Text = sint[9].ToString();
                    SEN_11_S.Text = sint[10].ToString();
                    SEN_12_S.Text = sint[11].ToString();
                    SU[0] = true;
                    if (SD[0] == true) SD[0] = false;
                }
                else if (dSEN != 7 && dSEN != 8 && dSEN != 9 && 7 <= SEN.Value && SEN.Value <= 10 && SU[1] == false)
                {
                    for (int i = 0; i < bint.Length; i++)
                    {
                        bint[i]++;
                        sint[i]++;
                    }
                    SEN_1_B.Text = bint[0].ToString();
                    SEN_2_B.Text = bint[1].ToString();
                    SEN_3_B.Text = bint[2].ToString();
                    SEN_4_B.Text = bint[3].ToString();
                    SEN_5_B.Text = bint[4].ToString();
                    SEN_6_B.Text = bint[5].ToString();
                    SEN_7_B.Text = bint[6].ToString();
                    SEN_8_B.Text = bint[7].ToString();
                    SEN_9_B.Text = bint[8].ToString();
                    SEN_10_B.Text = bint[9].ToString();
                    SEN_11_B.Text = bint[10].ToString();
                    SEN_12_B.Text = bint[11].ToString();
                    SEN_1_S.Text = sint[0].ToString();
                    SEN_2_S.Text = sint[1].ToString();
                    SEN_3_S.Text = sint[2].ToString();
                    SEN_4_S.Text = sint[3].ToString();
                    SEN_5_S.Text = sint[4].ToString();
                    SEN_6_S.Text = sint[5].ToString();
                    SEN_7_S.Text = sint[6].ToString();
                    SEN_8_S.Text = sint[7].ToString();
                    SEN_9_S.Text = sint[8].ToString();
                    SEN_10_S.Text = sint[9].ToString();
                    SEN_11_S.Text = sint[10].ToString();
                    SEN_12_S.Text = sint[11].ToString();
                    SU[1] = true;
                    if (SD[1] == true) SD[1] = false;
                }
                else if (dSEN != 11 && dSEN != 12 && dSEN != 13 && 11 <= SEN.Value && SEN.Value <= 14 && SU[2] == false)
                {
                    for (int i = 0; i < bint.Length; i++)
                    {
                        bint[i]++;
                        sint[i]++;
                    }
                    SEN_1_B.Text = bint[0].ToString();
                    SEN_2_B.Text = bint[1].ToString();
                    SEN_3_B.Text = bint[2].ToString();
                    SEN_4_B.Text = bint[3].ToString();
                    SEN_5_B.Text = bint[4].ToString();
                    SEN_6_B.Text = bint[5].ToString();
                    SEN_7_B.Text = bint[6].ToString();
                    SEN_8_B.Text = bint[7].ToString();
                    SEN_9_B.Text = bint[8].ToString();
                    SEN_10_B.Text = bint[9].ToString();
                    SEN_11_B.Text = bint[10].ToString();
                    SEN_12_B.Text = bint[11].ToString();
                    SEN_1_S.Text = sint[0].ToString();
                    SEN_2_S.Text = sint[1].ToString();
                    SEN_3_S.Text = sint[2].ToString();
                    SEN_4_S.Text = sint[3].ToString();
                    SEN_5_S.Text = sint[4].ToString();
                    SEN_6_S.Text = sint[5].ToString();
                    SEN_7_S.Text = sint[6].ToString();
                    SEN_8_S.Text = sint[7].ToString();
                    SEN_9_S.Text = sint[8].ToString();
                    SEN_10_S.Text = sint[9].ToString();
                    SEN_11_S.Text = sint[10].ToString();
                    SEN_12_S.Text = sint[11].ToString();
                    SU[2] = true;
                    if (SD[2] == true) SD[2] = false;
                }
                else if (dSEN != 15 && dSEN != 16 && 15 <= SEN.Value && SEN.Value <= 17 && SU[3] == false)
                {
                    for (int i = 0; i < bint.Length; i++)
                    {
                        bint[i]++;
                        sint[i]++;
                    }
                    SEN_1_B.Text = bint[0].ToString();
                    SEN_2_B.Text = bint[1].ToString();
                    SEN_3_B.Text = bint[2].ToString();
                    SEN_4_B.Text = bint[3].ToString();
                    SEN_5_B.Text = bint[4].ToString();
                    SEN_6_B.Text = bint[5].ToString();
                    SEN_7_B.Text = bint[6].ToString();
                    SEN_8_B.Text = bint[7].ToString();
                    SEN_9_B.Text = bint[8].ToString();
                    SEN_10_B.Text = bint[9].ToString();
                    SEN_11_B.Text = bint[10].ToString();
                    SEN_12_B.Text = bint[11].ToString();
                    SEN_1_S.Text = sint[0].ToString();
                    SEN_2_S.Text = sint[1].ToString();
                    SEN_3_S.Text = sint[2].ToString();
                    SEN_4_S.Text = sint[3].ToString();
                    SEN_5_S.Text = sint[4].ToString();
                    SEN_6_S.Text = sint[5].ToString();
                    SEN_7_S.Text = sint[6].ToString();
                    SEN_8_S.Text = sint[7].ToString();
                    SEN_9_S.Text = sint[8].ToString();
                    SEN_10_S.Text = sint[9].ToString();
                    SEN_11_S.Text = sint[10].ToString();
                    SEN_12_S.Text = sint[11].ToString();
                    SU[3] = true;
                    if (SD[3] == true) SD[3] = false;
                }
                else if (dSEN != 18 && dSEN != 19 && 18 <= SEN.Value && SEN.Value <= 20 && SU[4] == false)
                {
                    for (int i = 0; i < bint.Length; i++)
                    {
                        bint[i]++;
                        sint[i]++;
                    }
                    SEN_1_B.Text = bint[0].ToString();
                    SEN_2_B.Text = bint[1].ToString();
                    SEN_3_B.Text = bint[2].ToString();
                    SEN_4_B.Text = bint[3].ToString();
                    SEN_5_B.Text = bint[4].ToString();
                    SEN_6_B.Text = bint[5].ToString();
                    SEN_7_B.Text = bint[6].ToString();
                    SEN_8_B.Text = bint[7].ToString();
                    SEN_9_B.Text = bint[8].ToString();
                    SEN_10_B.Text = bint[9].ToString();
                    SEN_11_B.Text = bint[10].ToString();
                    SEN_12_B.Text = bint[11].ToString();
                    SEN_1_S.Text = sint[0].ToString();
                    SEN_2_S.Text = sint[1].ToString();
                    SEN_3_S.Text = sint[2].ToString();
                    SEN_4_S.Text = sint[3].ToString();
                    SEN_5_S.Text = sint[4].ToString();
                    SEN_6_S.Text = sint[5].ToString();
                    SEN_7_S.Text = sint[6].ToString();
                    SEN_8_S.Text = sint[7].ToString();
                    SEN_9_S.Text = sint[8].ToString();
                    SEN_10_S.Text = sint[9].ToString();
                    SEN_11_S.Text = sint[10].ToString();
                    SEN_12_S.Text = sint[11].ToString();
                    SU[4] = true;
                    if (SD[4] == true) SD[4] = false;
                }
            }
            if (dSEN > SEN.Value)
            {
                if (dSEN != 3 && dSEN != 2 && dSEN != 1 && SEN.Value <= 3 && SD[0] == false)
                {
                    for (int i = 0; i < bint.Length; i++)
                    {
                        bint[i]--;
                        sint[i]--;
                    }
                    SEN_1_B.Text = bint[0].ToString();
                    SEN_2_B.Text = bint[1].ToString();
                    SEN_3_B.Text = bint[2].ToString();
                    SEN_4_B.Text = bint[3].ToString();
                    SEN_5_B.Text = bint[4].ToString();
                    SEN_6_B.Text = bint[5].ToString();
                    SEN_7_B.Text = bint[6].ToString();
                    SEN_8_B.Text = bint[7].ToString();
                    SEN_9_B.Text = bint[8].ToString();
                    SEN_10_B.Text = bint[9].ToString();
                    SEN_11_B.Text = bint[10].ToString();
                    SEN_12_B.Text = bint[11].ToString();
                    SEN_1_S.Text = sint[0].ToString();
                    SEN_2_S.Text = sint[1].ToString();
                    SEN_3_S.Text = sint[2].ToString();
                    SEN_4_S.Text = sint[3].ToString();
                    SEN_5_S.Text = sint[4].ToString();
                    SEN_6_S.Text = sint[5].ToString();
                    SEN_7_S.Text = sint[6].ToString();
                    SEN_8_S.Text = sint[7].ToString();
                    SEN_9_S.Text = sint[8].ToString();
                    SEN_10_S.Text = sint[9].ToString();
                    SEN_11_S.Text = sint[10].ToString();
                    SEN_12_S.Text = sint[11].ToString();
                    SD[0] = true;
                    if (SU[0] == true) SU[0] = false;
                }
                else if (dSEN != 6 && dSEN != 5 && 4 <= SEN.Value && SEN.Value <= 6 && SD[1] == false)
                {
                    for (int i = 0; i < bint.Length; i++)
                    {
                        bint[i]--;
                        sint[i]--;
                    }
                    SEN_1_B.Text = bint[0].ToString();
                    SEN_2_B.Text = bint[1].ToString();
                    SEN_3_B.Text = bint[2].ToString();
                    SEN_4_B.Text = bint[3].ToString();
                    SEN_5_B.Text = bint[4].ToString();
                    SEN_6_B.Text = bint[5].ToString();
                    SEN_7_B.Text = bint[6].ToString();
                    SEN_8_B.Text = bint[7].ToString();
                    SEN_9_B.Text = bint[8].ToString();
                    SEN_10_B.Text = bint[9].ToString();
                    SEN_11_B.Text = bint[10].ToString();
                    SEN_12_B.Text = bint[11].ToString();
                    SEN_1_S.Text = sint[0].ToString();
                    SEN_2_S.Text = sint[1].ToString();
                    SEN_3_S.Text = sint[2].ToString();
                    SEN_4_S.Text = sint[3].ToString();
                    SEN_5_S.Text = sint[4].ToString();
                    SEN_6_S.Text = sint[5].ToString();
                    SEN_7_S.Text = sint[6].ToString();
                    SEN_8_S.Text = sint[7].ToString();
                    SEN_9_S.Text = sint[8].ToString();
                    SEN_10_S.Text = sint[9].ToString();
                    SEN_11_S.Text = sint[10].ToString();
                    SEN_12_S.Text = sint[11].ToString();
                    SD[1] = true;
                    if (SU[1] == true) SU[1] = false;
                }
                else if (dSEN != 10 && dSEN != 9 && dSEN != 8 && 7 <= SEN.Value && SEN.Value <= 10 && SD[2] == false)
                {
                    for (int i = 0; i < bint.Length; i++)
                    {
                        bint[i]--;
                        sint[i]--;
                    }
                    SEN_1_B.Text = bint[0].ToString();
                    SEN_2_B.Text = bint[1].ToString();
                    SEN_3_B.Text = bint[2].ToString();
                    SEN_4_B.Text = bint[3].ToString();
                    SEN_5_B.Text = bint[4].ToString();
                    SEN_6_B.Text = bint[5].ToString();
                    SEN_7_B.Text = bint[6].ToString();
                    SEN_8_B.Text = bint[7].ToString();
                    SEN_9_B.Text = bint[8].ToString();
                    SEN_10_B.Text = bint[9].ToString();
                    SEN_11_B.Text = bint[10].ToString();
                    SEN_12_B.Text = bint[11].ToString();
                    SEN_1_S.Text = sint[0].ToString();
                    SEN_2_S.Text = sint[1].ToString();
                    SEN_3_S.Text = sint[2].ToString();
                    SEN_4_S.Text = sint[3].ToString();
                    SEN_5_S.Text = sint[4].ToString();
                    SEN_6_S.Text = sint[5].ToString();
                    SEN_7_S.Text = sint[6].ToString();
                    SEN_8_S.Text = sint[7].ToString();
                    SEN_9_S.Text = sint[8].ToString();
                    SEN_10_S.Text = sint[9].ToString();
                    SEN_11_S.Text = sint[10].ToString();
                    SEN_12_S.Text = sint[11].ToString();
                    SD[2] = true;
                    if (SU[2] == true) SU[2] = false;
                }
                else if (dSEN != 14 && dSEN != 13 && dSEN != 12 && 11 <= SEN.Value && SEN.Value <= 14 && SD[3] == false)
                {
                    for (int i = 0; i < bint.Length; i++)
                    {
                        bint[i]--;
                        sint[i]--;
                    }
                    SEN_1_B.Text = bint[0].ToString();
                    SEN_2_B.Text = bint[1].ToString();
                    SEN_3_B.Text = bint[2].ToString();
                    SEN_4_B.Text = bint[3].ToString();
                    SEN_5_B.Text = bint[4].ToString();
                    SEN_6_B.Text = bint[5].ToString();
                    SEN_7_B.Text = bint[6].ToString();
                    SEN_8_B.Text = bint[7].ToString();
                    SEN_9_B.Text = bint[8].ToString();
                    SEN_10_B.Text = bint[9].ToString();
                    SEN_11_B.Text = bint[10].ToString();
                    SEN_12_B.Text = bint[11].ToString();
                    SEN_1_S.Text = sint[0].ToString();
                    SEN_2_S.Text = sint[1].ToString();
                    SEN_3_S.Text = sint[2].ToString();
                    SEN_4_S.Text = sint[3].ToString();
                    SEN_5_S.Text = sint[4].ToString();
                    SEN_6_S.Text = sint[5].ToString();
                    SEN_7_S.Text = sint[6].ToString();
                    SEN_8_S.Text = sint[7].ToString();
                    SEN_9_S.Text = sint[8].ToString();
                    SEN_10_S.Text = sint[9].ToString();
                    SEN_11_S.Text = sint[10].ToString();
                    SEN_12_S.Text = sint[11].ToString();
                    SD[3] = true;
                    if (SU[3] == true) SU[3] = false;
                }
                else if (dSEN != 17 && dSEN != 16 && 15 <= SEN.Value && SEN.Value <= 17 && SD[4] == false)
                {
                    for (int i = 0; i < bint.Length; i++)
                    {
                        bint[i]--;
                        sint[i]--;
                    }
                    SEN_1_B.Text = bint[0].ToString();
                    SEN_2_B.Text = bint[1].ToString();
                    SEN_3_B.Text = bint[2].ToString();
                    SEN_4_B.Text = bint[3].ToString();
                    SEN_5_B.Text = bint[4].ToString();
                    SEN_6_B.Text = bint[5].ToString();
                    SEN_7_B.Text = bint[6].ToString();
                    SEN_8_B.Text = bint[7].ToString();
                    SEN_9_B.Text = bint[8].ToString();
                    SEN_10_B.Text = bint[9].ToString();
                    SEN_11_B.Text = bint[10].ToString();
                    SEN_12_B.Text = bint[11].ToString();
                    SEN_1_S.Text = sint[0].ToString();
                    SEN_2_S.Text = sint[1].ToString();
                    SEN_3_S.Text = sint[2].ToString();
                    SEN_4_S.Text = sint[3].ToString();
                    SEN_5_S.Text = sint[4].ToString();
                    SEN_6_S.Text = sint[5].ToString();
                    SEN_7_S.Text = sint[6].ToString();
                    SEN_8_S.Text = sint[7].ToString();
                    SEN_9_S.Text = sint[8].ToString();
                    SEN_10_S.Text = sint[9].ToString();
                    SEN_11_S.Text = sint[10].ToString();
                    SEN_12_S.Text = sint[11].ToString();
                    SD[4] = true;
                    if (SU[4] == true) SU[4] = false;
                }
            }
            dSEN = int.Parse(SEN.Value.ToString());
            StatusFormLoad();
        }
        private void NumChangeDEX()
        {
            /*
             * else if (4 <= dice && dice <= 6) ti = 1;
             * else if (7 <= dice && dice <= 10) ti = 2;
             * else if (11 <= dice && dice <= 14) ti = 3;
             * else if (15 <= dice && dice <= 17) ti = 4;
             * else if (18 <= dice && dice <= 20) ti = 5;
             */

            int[] bint = new int[5]{
                    int.Parse(DEX_1_B.Text),
                    int.Parse(DEX_2_B.Text),
                    int.Parse(DEX_3_B.Text),
                    int.Parse(DEX_4_B.Text),
                    int.Parse(DEX_5_B.Text)
            };
            int[] sint = new int[5]{
                    int.Parse(DEX_1_S.Text),
                    int.Parse(DEX_2_S.Text),
                    int.Parse(DEX_3_S.Text),
                    int.Parse(DEX_4_S.Text),
                    int.Parse(DEX_5_S.Text)
            };
            if (dDEX < DEX.Value)
            {
                if (dDEX != 4 && dDEX != 5 && 4 <= DEX.Value && DEX.Value <= 6 && DU[0] == false)
                {
                    for (int i = 0; i < bint.Length; i++)
                    {
                        bint[i]++;
                        sint[i]++;
                    }
                    DEX_1_B.Text = bint[0].ToString();
                    DEX_2_B.Text = bint[1].ToString();
                    DEX_3_B.Text = bint[2].ToString();
                    DEX_4_B.Text = bint[3].ToString();
                    DEX_5_B.Text = bint[4].ToString();
                    DEX_1_S.Text = sint[0].ToString();
                    DEX_2_S.Text = sint[1].ToString();
                    DEX_3_S.Text = sint[2].ToString();
                    DEX_4_S.Text = sint[3].ToString();
                    DEX_5_S.Text = sint[4].ToString();
                    DU[0] = true;
                    if (DD[0] == true) DD[0] = false;
                }
                else if (dDEX != 7 && dDEX != 8 && dDEX != 9 && 7 <= DEX.Value && DEX.Value <= 10 && DU[1] == false)
                {
                    for (int i = 0; i < bint.Length; i++)
                    {
                        bint[i]++;
                        sint[i]++;
                    }
                    DEX_1_B.Text = bint[0].ToString();
                    DEX_2_B.Text = bint[1].ToString();
                    DEX_3_B.Text = bint[2].ToString();
                    DEX_4_B.Text = bint[3].ToString();
                    DEX_5_B.Text = bint[4].ToString();
                    DEX_1_S.Text = sint[0].ToString();
                    DEX_2_S.Text = sint[1].ToString();
                    DEX_3_S.Text = sint[2].ToString();
                    DEX_4_S.Text = sint[3].ToString();
                    DEX_5_S.Text = sint[4].ToString();
                    DU[1] = true;
                    if (DD[1] == true) DD[1] = false;
                }
                else if (dDEX != 11 && dDEX != 12 && dDEX != 13 && 11 <= DEX.Value && DEX.Value <= 14 && DU[2] == false)
                {
                    for (int i = 0; i < bint.Length; i++)
                    {
                        bint[i]++;
                        sint[i]++;
                    }
                    DEX_1_B.Text = bint[0].ToString();
                    DEX_2_B.Text = bint[1].ToString();
                    DEX_3_B.Text = bint[2].ToString();
                    DEX_4_B.Text = bint[3].ToString();
                    DEX_5_B.Text = bint[4].ToString();
                    DEX_1_S.Text = sint[0].ToString();
                    DEX_2_S.Text = sint[1].ToString();
                    DEX_3_S.Text = sint[2].ToString();
                    DEX_4_S.Text = sint[3].ToString();
                    DEX_5_S.Text = sint[4].ToString();
                    DU[2] = true;
                    if (DD[2] == true) DD[2] = false;
                }
                else if (dDEX != 15 && dDEX != 16 && 15 <= DEX.Value && DEX.Value <= 17 && DU[3] == false)
                {
                    for (int i = 0; i < bint.Length; i++)
                    {
                        bint[i]++;
                        sint[i]++;
                    }
                    DEX_1_B.Text = bint[0].ToString();
                    DEX_2_B.Text = bint[1].ToString();
                    DEX_3_B.Text = bint[2].ToString();
                    DEX_4_B.Text = bint[3].ToString();
                    DEX_5_B.Text = bint[4].ToString();
                    DEX_1_S.Text = sint[0].ToString();
                    DEX_2_S.Text = sint[1].ToString();
                    DEX_3_S.Text = sint[2].ToString();
                    DEX_4_S.Text = sint[3].ToString();
                    DEX_5_S.Text = sint[4].ToString();
                    DU[3] = true;
                    if (DD[3] == true) DD[3] = false;
                }
                else if (dDEX != 18 && dDEX != 19 && 18 <= DEX.Value && DEX.Value <= 20 && DU[4] == false)
                {
                    for (int i = 0; i < bint.Length; i++)
                    {
                        bint[i]++;
                        sint[i]++;
                    }
                    DEX_1_B.Text = bint[0].ToString();
                    DEX_2_B.Text = bint[1].ToString();
                    DEX_3_B.Text = bint[2].ToString();
                    DEX_4_B.Text = bint[3].ToString();
                    DEX_5_B.Text = bint[4].ToString();
                    DEX_1_S.Text = sint[0].ToString();
                    DEX_2_S.Text = sint[1].ToString();
                    DEX_3_S.Text = sint[2].ToString();
                    DEX_4_S.Text = sint[3].ToString();
                    DEX_5_S.Text = sint[4].ToString();
                    DU[4] = true;
                    if (DD[4] == true) DD[4] = false;
                }
            }
            if (dDEX > DEX.Value)
            {
                if (dDEX != 3 && dDEX != 2 && dDEX != 1 && DEX.Value <= 3 && DD[0] == false)
                {
                    for (int i = 0; i < bint.Length; i++)
                    {
                        bint[i]--;
                        sint[i]--;
                    }
                    DEX_1_B.Text = bint[0].ToString();
                    DEX_2_B.Text = bint[1].ToString();
                    DEX_3_B.Text = bint[2].ToString();
                    DEX_4_B.Text = bint[3].ToString();
                    DEX_5_B.Text = bint[4].ToString();
                    DEX_1_S.Text = sint[0].ToString();
                    DEX_2_S.Text = sint[1].ToString();
                    DEX_3_S.Text = sint[2].ToString();
                    DEX_4_S.Text = sint[3].ToString();
                    DEX_5_S.Text = sint[4].ToString();
                    DD[0] = true;
                    if (DU[0] == true) DU[0] = false;
                }
                else if (dDEX != 6 && dDEX != 5 && 4 <= DEX.Value && DEX.Value <= 6 && DD[1] == false)
                {
                    for (int i = 0; i < bint.Length; i++)
                    {
                        bint[i]--;
                        sint[i]--;
                    }
                    DEX_1_B.Text = bint[0].ToString();
                    DEX_2_B.Text = bint[1].ToString();
                    DEX_3_B.Text = bint[2].ToString();
                    DEX_4_B.Text = bint[3].ToString();
                    DEX_5_B.Text = bint[4].ToString();
                    DEX_1_S.Text = sint[0].ToString();
                    DEX_2_S.Text = sint[1].ToString();
                    DEX_3_S.Text = sint[2].ToString();
                    DEX_4_S.Text = sint[3].ToString();
                    DEX_5_S.Text = sint[4].ToString();
                    DD[1] = true;
                    if (DU[1] == true) DU[1] = false;
                }
                else if (dDEX != 10 && dDEX != 9 && dDEX != 8 && 7 <= DEX.Value && DEX.Value <= 10 && DD[2] == false)
                {
                    for (int i = 0; i < bint.Length; i++)
                    {
                        bint[i]--;
                        sint[i]--;
                    }
                    DEX_1_B.Text = bint[0].ToString();
                    DEX_2_B.Text = bint[1].ToString();
                    DEX_3_B.Text = bint[2].ToString();
                    DEX_4_B.Text = bint[3].ToString();
                    DEX_5_B.Text = bint[4].ToString();
                    DEX_1_S.Text = sint[0].ToString();
                    DEX_2_S.Text = sint[1].ToString();
                    DEX_3_S.Text = sint[2].ToString();
                    DEX_4_S.Text = sint[3].ToString();
                    DEX_5_S.Text = sint[4].ToString();
                    DD[2] = true;
                    if (DU[2] == true) DU[2] = false;
                }
                else if (dDEX != 14 && dDEX != 13 && dDEX != 12 && 11 <= DEX.Value && DEX.Value <= 14 && DD[3] == false)
                {
                    for (int i = 0; i < bint.Length; i++)
                    {
                        bint[i]--;
                        sint[i]--;
                    }
                    DEX_1_B.Text = bint[0].ToString();
                    DEX_2_B.Text = bint[1].ToString();
                    DEX_3_B.Text = bint[2].ToString();
                    DEX_4_B.Text = bint[3].ToString();
                    DEX_5_B.Text = bint[4].ToString();
                    DEX_1_S.Text = sint[0].ToString();
                    DEX_2_S.Text = sint[1].ToString();
                    DEX_3_S.Text = sint[2].ToString();
                    DEX_4_S.Text = sint[3].ToString();
                    DEX_5_S.Text = sint[4].ToString();
                    DD[3] = true;
                    if (DU[3] == true) DU[3] = false;
                }
                else if (dDEX != 17 && dDEX != 16 && 15 <= DEX.Value && DEX.Value <= 17 && DD[4] == false)
                {
                    for (int i = 0; i < bint.Length; i++)
                    {
                        bint[i]--;
                        sint[i]--;
                    }
                    DEX_1_B.Text = bint[0].ToString();
                    DEX_2_B.Text = bint[1].ToString();
                    DEX_3_B.Text = bint[2].ToString();
                    DEX_4_B.Text = bint[3].ToString();
                    DEX_5_B.Text = bint[4].ToString();
                    DEX_1_S.Text = sint[0].ToString();
                    DEX_2_S.Text = sint[1].ToString();
                    DEX_3_S.Text = sint[2].ToString();
                    DEX_4_S.Text = sint[3].ToString();
                    DEX_5_S.Text = sint[4].ToString();
                    DD[4] = true;
                    if (DU[4] == true) DU[4] = false;
                }
            }
            dDEX = int.Parse(DEX.Value.ToString());
            StatusFormLoad();
        }

        //早苗さんかわいい関数
        private void SanaesanKawaii() {
            Console.WriteLine("早苗さん可愛い可愛いよ可愛いいいいいいい");
        }


        //////////////////ボタンクリック//////////////////
        private void IMP_1_ADD_Click(object sender, EventArgs e)
        {
            int num = int.Parse(IMP_1_S.Text);
            if (SP > 0) {
                switch (ServiceGroup.SelectedIndex) {
                    case 2: if (IMP_1_S.Text != "14") { num++; SP--; } break;
                    default: if(IMP_1_S.Text != "12") {num++; SP--; }break;
                }
            }
            bIMP1 = num;
            IMP_1_S.Text = num.ToString();
            SkillPoint1.Text = SP.ToString();
            SkillPoint2.Text = SP.ToString();
            SkillPoint3.Text = SP.ToString();
            StatusFormLoad();
        }
        private void IMP_1_SUB_Click(object sender, EventArgs e)
        {
            int num = int.Parse(IMP_1_S.Text);
            int Base = int.Parse(IMP_1_B.Text);
            if (SP < 30) { if (Base < num) { num--; SP++; } }
            IMP_1_S.Text = num.ToString();
            SkillPoint1.Text = SP.ToString();
            SkillPoint2.Text = SP.ToString();
            SkillPoint3.Text = SP.ToString();
            StatusFormLoad();
        }
        private void IMP_2_ADD_Click(object sender, EventArgs e)
        {
            int num = int.Parse(IMP_2_S.Text);
            if (SP > 0){
                switch (ServiceGroup.SelectedIndex){
                    case 4: if (IMP_2_S.Text != "14") { num++; SP--; } break;
                    default: if (IMP_2_S.Text != "12") { num++; SP--; } break;
                }
            }
            bIMP2 = num;
            IMP_2_S.Text = num.ToString();
            SkillPoint1.Text = SP.ToString();
            SkillPoint2.Text = SP.ToString();
            SkillPoint3.Text = SP.ToString();
            StatusFormLoad();
        }
        private void IMP_2_SUB_Click(object sender, EventArgs e)
        {
            int num = int.Parse(IMP_2_S.Text);
            int Base = int.Parse(IMP_2_B.Text);
            if (SP < 30) { if (Base < num) { num--; SP++; } }
            IMP_2_S.Text = num.ToString();
            SkillPoint1.Text = SP.ToString();
            SkillPoint2.Text = SP.ToString();
            SkillPoint3.Text = SP.ToString();
            StatusFormLoad();
        }
        private void IMP_3_ADD_Click(object sender, EventArgs e)
        {
            int num = int.Parse(IMP_3_S.Text);
            if (SP > 0){
                switch (ServiceGroup.SelectedIndex){
                    case 2: if (IMP_3_S.Text != "14") { num++; SP--; } break;
                    case 7: if (IMP_3_S.Text != "14") { num++; SP--; } break;
                    default: if (IMP_3_S.Text != "12") { num++; SP--; } break;
                }
            }
            bIMP3 = num;
            IMP_3_S.Text = num.ToString();
            SkillPoint1.Text = SP.ToString();
            SkillPoint2.Text = SP.ToString();
            SkillPoint3.Text = SP.ToString();
            StatusFormLoad();
        }
        private void IMP_3_SUB_Click(object sender, EventArgs e)
        {
            int num = int.Parse(IMP_3_S.Text);
            int Base = int.Parse(IMP_3_B.Text);
            if (SP < 30) { if (Base < num) { num--; SP++; } }
            IMP_3_S.Text = num.ToString();
            SkillPoint1.Text = SP.ToString();
            SkillPoint2.Text = SP.ToString();
            SkillPoint3.Text = SP.ToString();
            StatusFormLoad();
        }
        private void IMP_4_ADD_Click(object sender, EventArgs e)
        {
            int num = int.Parse(IMP_4_S.Text);
            if (SP > 0)
            {
                switch (ServiceGroup.SelectedIndex)
                {
                    case 4: if (IMP_4_S.Text != "14") { num++; SP--; } break;
                    case 7: if (IMP_4_S.Text != "14") { num++; SP--; } break;
                    default: if (IMP_4_S.Text != "12") { num++; SP--; } break;
                }
            }
            bIMP4 = num;
            IMP_4_S.Text = num.ToString();
            SkillPoint1.Text = SP.ToString();
            SkillPoint2.Text = SP.ToString();
            SkillPoint3.Text = SP.ToString();
            StatusFormLoad();
        }
        private void IMP_4_SUB_Click(object sender, EventArgs e)
        {
            int num = int.Parse(IMP_4_S.Text);
            int Base = int.Parse(IMP_4_B.Text);
            if (SP < 30) { if (Base < num) { num--; SP++; } }
            IMP_4_S.Text = num.ToString();
            SkillPoint1.Text = SP.ToString();
            SkillPoint2.Text = SP.ToString();
            SkillPoint3.Text = SP.ToString();
            StatusFormLoad();
        }
        private void IMP_5_ADD_Click(object sender, EventArgs e)
        {
            int num = int.Parse(IMP_5_S.Text);
            if (SP > 0)
            {
                switch (ServiceGroup.SelectedIndex)
                {
                    case 2: if (IMP_5_S.Text != "14") { num++; SP--; } break;
                    case 4: if (IMP_5_S.Text != "14") { num++; SP--; } break;
                    default: if (IMP_5_S.Text != "12") { num++; SP--; } break;
                }
            }
            bIMP5 = num;
            IMP_5_S.Text = num.ToString();
            SkillPoint1.Text = SP.ToString();
            SkillPoint2.Text = SP.ToString();
            SkillPoint3.Text = SP.ToString();
            StatusFormLoad();
        }
        private void IMP_5_SUB_Click(object sender, EventArgs e)
        {
            int num = int.Parse(IMP_5_S.Text);
            int Base = int.Parse(IMP_5_B.Text);
            if (SP < 30) { if (Base < num) { num--; SP++; } }
            IMP_5_S.Text = num.ToString();
            SkillPoint1.Text = SP.ToString();
            SkillPoint2.Text = SP.ToString();
            SkillPoint3.Text = SP.ToString();
            StatusFormLoad();
        }
        private void IMP_6_ADD_Click(object sender, EventArgs e)
        {
            int num = int.Parse(IMP_6_S.Text);
            if (SP > 0)
            {
                switch (ServiceGroup.SelectedIndex)
                {
                    case 0: if (IMP_6_S.Text != "14") { num++; SP--; } break;
                    case 7: if (IMP_6_S.Text != "14") { num++; SP--; } break;
                    default: if (IMP_6_S.Text != "12") { num++; SP--; } break;
                }
            }
            bIMP6 = num;
            IMP_6_S.Text = num.ToString();
            SkillPoint1.Text = SP.ToString();
            SkillPoint2.Text = SP.ToString();
            SkillPoint3.Text = SP.ToString();
            StatusFormLoad();
        }
        private void IMP_6_SUB_Click(object sender, EventArgs e)
        {
            int num = int.Parse(IMP_6_S.Text);
            int Base = int.Parse(IMP_6_B.Text);
            if (SP < 30) { if (Base < num) { num--; SP++; } }
            IMP_6_S.Text = num.ToString();
            SkillPoint1.Text = SP.ToString();
            SkillPoint2.Text = SP.ToString();
            SkillPoint3.Text = SP.ToString();
            StatusFormLoad();
        }
        private void IMP_7_ADD_Click(object sender, EventArgs e)
        {
            int num = int.Parse(IMP_7_S.Text);
            if (SP > 0)
            {
                switch (ServiceGroup.SelectedIndex)
                {
                    case 2: if (IMP_7_S.Text != "14") { num++; SP--; } break;
                    case 7: if (IMP_7_S.Text != "14") { num++; SP--; } break;
                    default: if (IMP_7_S.Text != "12") { num++; SP--; } break;
                }
            }
            bIMP7 = num;
            IMP_7_S.Text = num.ToString();
            SkillPoint1.Text = SP.ToString();
            SkillPoint2.Text = SP.ToString();
            SkillPoint3.Text = SP.ToString();
            StatusFormLoad();
        }
        private void IMP_7_SUB_Click(object sender, EventArgs e)
        {
            int num = int.Parse(IMP_7_S.Text);
            int Base = int.Parse(IMP_7_B.Text);
            if (SP < 30) { if (Base < num) { num--; SP++; } }
            IMP_7_S.Text = num.ToString();
            SkillPoint1.Text = SP.ToString();
            SkillPoint2.Text = SP.ToString();
            SkillPoint3.Text = SP.ToString();
            StatusFormLoad();
        }
        private void IMP_8_ADD_Click(object sender, EventArgs e)
        {
            int num = int.Parse(IMP_8_S.Text);
            if (SP > 0)
            {
                switch (ServiceGroup.SelectedIndex)
                {
                    case 0: if (IMP_8_S.Text != "14") { num++; SP--; } break;
                    case 7: if (IMP_8_S.Text != "14") { num++; SP--; } break;
                    default: if (IMP_8_S.Text != "12") { num++; SP--; } break;
                }
            }
            bIMP8 = num;
            IMP_8_S.Text = num.ToString();
            SkillPoint1.Text = SP.ToString();
            SkillPoint2.Text = SP.ToString();
            SkillPoint3.Text = SP.ToString();
            StatusFormLoad();
        }
        private void IMP_8_SUB_Click(object sender, EventArgs e)
        {
            int num = int.Parse(IMP_8_S.Text);
            int Base = int.Parse(IMP_8_B.Text);
            if (SP < 30) { if (Base < num) { num--; SP++; } }
            IMP_8_S.Text = num.ToString();
            SkillPoint1.Text = SP.ToString();
            SkillPoint2.Text = SP.ToString();
            SkillPoint3.Text = SP.ToString();
            StatusFormLoad();
        }
        private void IMP_9_ADD_Click(object sender, EventArgs e)
        {
            int num = int.Parse(IMP_9_S.Text);
            if (SP > 0)
            {
                switch (ServiceGroup.SelectedIndex)
                {
                    case 1: if (IMP_9_S.Text != "14") { num++; SP--; } break;
                    case 5: if (IMP_9_S.Text != "14") { num++; SP--; } break;
                    default: if (IMP_9_S.Text != "12") { num++; SP--; } break;
                }
            }

            bIMP9 = num;
            IMP_9_S.Text = num.ToString();
            SkillPoint1.Text = SP.ToString();
            SkillPoint2.Text = SP.ToString();
            SkillPoint3.Text = SP.ToString();
            StatusFormLoad();
        }
        private void IMP_9_SUB_Click(object sender, EventArgs e)
        {
            int num = int.Parse(IMP_9_S.Text);
            int Base = int.Parse(IMP_9_B.Text);
            if (SP < 30) { if (Base < num) { num--; SP++; } }
            IMP_9_S.Text = num.ToString();
            SkillPoint1.Text = SP.ToString();
            SkillPoint2.Text = SP.ToString();
            SkillPoint3.Text = SP.ToString();
            StatusFormLoad();
        }
        private void AGI_1_ADD_Click(object sender, EventArgs e)
        {
            int num = int.Parse(AGI_1_S.Text);
            if (SP > 0)
            {
                switch (ServiceGroup.SelectedIndex)
                {
                    case 0: if (AGI_1_S.Text != "14") { num++; SP--; } break;
                    default: if (AGI_1_S.Text != "12") { num++; SP--; } break;
                }
            }
            bAGI1 = num;
            AGI_1_S.Text = num.ToString();
            SkillPoint1.Text = SP.ToString();
            SkillPoint2.Text = SP.ToString();
            SkillPoint3.Text = SP.ToString();
            StatusFormLoad();
        }
        private void AGI_1_SUB_Click(object sender, EventArgs e)
        {
            int num = int.Parse(AGI_1_S.Text);
            int Base = int.Parse(AGI_1_B.Text);
            if (SP < 30) { if (Base < num) { num--; SP++; } }
            AGI_1_S.Text = num.ToString();
            SkillPoint1.Text = SP.ToString();
            SkillPoint2.Text = SP.ToString();
            SkillPoint3.Text = SP.ToString();
            StatusFormLoad();
        }
        private void AGI_2_ADD_Click(object sender, EventArgs e)
        {
            int num = int.Parse(AGI_2_S.Text);
            if (SP > 0)
            {
                switch (ServiceGroup.SelectedIndex)
                {
                    case 0: if (AGI_2_S.Text != "14") { num++; SP--; } break;
                    default: if (AGI_2_S.Text != "12") { num++; SP--; } break;
                }
            }
            bAGI2 = num;
            AGI_2_S.Text = num.ToString();
            SkillPoint1.Text = SP.ToString();
            SkillPoint2.Text = SP.ToString();
            SkillPoint3.Text = SP.ToString();
            StatusFormLoad();
        }
        private void AGI_2_SUB_Click(object sender, EventArgs e)
        {
            int num = int.Parse(AGI_2_S.Text);
            int Base = int.Parse(AGI_2_B.Text);
            if (SP < 30) { if (Base < num) { num--; SP++; } }
            AGI_2_S.Text = num.ToString();
            SkillPoint1.Text = SP.ToString();
            SkillPoint2.Text = SP.ToString();
            SkillPoint3.Text = SP.ToString();
            StatusFormLoad();
        }
        private void AGI_3_ADD_Click(object sender, EventArgs e)
        {
            int num = int.Parse(AGI_3_S.Text);
            if (SP > 0)
            {
                switch (ServiceGroup.SelectedIndex)
                {
                    case 3: if (AGI_3_S.Text != "14") { num++; SP--; } break;
                    default: if (AGI_3_S.Text != "12") { num++; SP--; } break;
                }
            }
            bAGI3 = num;
            AGI_3_S.Text = num.ToString();
            SkillPoint1.Text = SP.ToString();
            SkillPoint2.Text = SP.ToString();
            SkillPoint3.Text = SP.ToString();
            StatusFormLoad();
        }
        private void AGI_3_SUB_Click(object sender, EventArgs e)
        {
            int num = int.Parse(AGI_3_S.Text);
            int Base = int.Parse(AGI_3_B.Text);
            if (SP < 30) { if (Base < num) { num--; SP++; } }
            AGI_3_S.Text = num.ToString();
            SkillPoint1.Text = SP.ToString();
            SkillPoint2.Text = SP.ToString();
            SkillPoint3.Text = SP.ToString();
            StatusFormLoad();
        }
        private void AGI_4_ADD_Click(object sender, EventArgs e)
        {
            int num = int.Parse(AGI_4_S.Text);
            if (SP > 0)
            {
                switch (ServiceGroup.SelectedIndex)
                {
                    case 0: if (AGI_4_S.Text != "14") { num++; SP--; } break;
                    default: if (AGI_4_S.Text != "12") { num++; SP--; } break;
                }
            }
            bAGI4 = num;
            AGI_4_S.Text = num.ToString();
            SkillPoint1.Text = SP.ToString();
            SkillPoint2.Text = SP.ToString();
            SkillPoint3.Text = SP.ToString();
            StatusFormLoad();
        }
        private void AGI_4_SUB_Click(object sender, EventArgs e)
        {
            int num = int.Parse(AGI_4_S.Text);
            int Base = int.Parse(AGI_4_B.Text);
            if (SP < 30) { if (Base < num) { num--; SP++; } }
            AGI_4_S.Text = num.ToString();
            SkillPoint1.Text = SP.ToString();
            SkillPoint2.Text = SP.ToString();
            SkillPoint3.Text = SP.ToString();
            StatusFormLoad();
        }
        private void AGI_5_ADD_Click(object sender, EventArgs e)
        {
            int num = int.Parse(AGI_5_S.Text);
            if (SP > 0)
            {
                switch (ServiceGroup.SelectedIndex)
                {
                    case 3: if (AGI_5_S.Text != "14") { num++; SP--; } break;
                    default: if (AGI_5_S.Text != "12") { num++; SP--; } break;
                }
            }
            bAGI5 = num;
            AGI_5_S.Text = num.ToString();
            SkillPoint1.Text = SP.ToString();
            SkillPoint2.Text = SP.ToString();
            SkillPoint3.Text = SP.ToString();
            StatusFormLoad();
        }
        private void AGI_5_SUB_Click(object sender, EventArgs e)
        {
            int num = int.Parse(AGI_5_S.Text);
            int Base = int.Parse(AGI_5_B.Text);
            if (SP < 30) { if (Base < num) { num--; SP++; } }
            AGI_5_S.Text = num.ToString();
            SkillPoint1.Text = SP.ToString();
            SkillPoint2.Text = SP.ToString();
            SkillPoint3.Text = SP.ToString();
            StatusFormLoad();
        }
        private void MEC_1_ADD_Click(object sender, EventArgs e)
        {
            int num = int.Parse(MEC_1_S.Text);
            if (SP > 0)
            {
                switch (ServiceGroup.SelectedIndex)
                {
                    case 6: if (MEC_1_S.Text != "14") { num++; SP--; } break;
                    default: if (MEC_1_S.Text != "12") { num++; SP--; } break;
                }
            }
            bMEC1 = num;
            MEC_1_S.Text = num.ToString();
            SkillPoint1.Text = SP.ToString();
            SkillPoint2.Text = SP.ToString();
            SkillPoint3.Text = SP.ToString();
            StatusFormLoad();
        }
        private void MEC_1_SUB_Click(object sender, EventArgs e)
        {
            int num = int.Parse(MEC_1_S.Text);
            int Base = int.Parse(MEC_1_B.Text);
            if (SP < 30) { if (Base < num) { num--; SP++; } }
            MEC_1_S.Text = num.ToString();
            SkillPoint1.Text = SP.ToString();
            SkillPoint2.Text = SP.ToString();
            SkillPoint3.Text = SP.ToString();
            StatusFormLoad();
        }
        private void MEC_2_ADD_Click(object sender, EventArgs e)
        {
            int num = int.Parse(MEC_2_S.Text);
            if (SP > 0)
            {
                switch (ServiceGroup.SelectedIndex)
                {
                    case 1: if (MEC_2_S.Text != "14") { num++; SP--; } break;
                    case 2: if (MEC_2_S.Text != "14") { num++; SP--; } break;
                    case 4: if (MEC_2_S.Text != "14") { num++; SP--; } break;
                    case 6: if (MEC_2_S.Text != "14") { num++; SP--; } break;
                    default: if (MEC_2_S.Text != "12") { num++; SP--; } break;
                }
            }
            bMEC2 = num;
            MEC_2_S.Text = num.ToString();
            SkillPoint1.Text = SP.ToString();
            SkillPoint2.Text = SP.ToString();
            SkillPoint3.Text = SP.ToString();
            StatusFormLoad();
        }
        private void MEC_2_SUB_Click(object sender, EventArgs e)
        {
            int num = int.Parse(MEC_2_S.Text);
            int Base = int.Parse(MEC_2_B.Text);
            if (SP < 30) { if (Base < num) { num--; SP++; } }
            MEC_2_S.Text = num.ToString();
            SkillPoint1.Text = SP.ToString();
            SkillPoint2.Text = SP.ToString();
            SkillPoint3.Text = SP.ToString();
            StatusFormLoad();
        }
        private void MEC_3_ADD_Click(object sender, EventArgs e)
        {
            int num = int.Parse(MEC_3_S.Text);
            if (SP > 0)
            {
                switch (ServiceGroup.SelectedIndex)
                {
                    case 5: if (MEC_3_S.Text != "14") { num++; SP--; } break;
                    default: if (MEC_3_S.Text != "12") { num++; SP--; } break;
                }
            }
            bMEC3 = num;
            MEC_3_S.Text = num.ToString();
            SkillPoint1.Text = SP.ToString();
            SkillPoint2.Text = SP.ToString();
            SkillPoint3.Text = SP.ToString();
            StatusFormLoad();
        }
        private void MEC_3_SUB_Click(object sender, EventArgs e)
        {
            int num = int.Parse(MEC_3_S.Text);
            int Base = int.Parse(MEC_3_B.Text);
            if (SP < 30) { if (Base < num) { num--; SP++; } }
            MEC_3_S.Text = num.ToString();
            SkillPoint1.Text = SP.ToString();
            SkillPoint2.Text = SP.ToString();
            SkillPoint3.Text = SP.ToString();
            StatusFormLoad();
        }
        private void MEC_4_ADD_Click(object sender, EventArgs e)
        {
            int num = int.Parse(MEC_4_S.Text);
            if (SP > 0)
            {
                switch (ServiceGroup.SelectedIndex)
                {
                    case 1: if (MEC_4_S.Text != "14") { num++; SP--; } break;
                    case 4: if (MEC_4_S.Text != "14") { num++; SP--; } break;
                    default: if (MEC_4_S.Text != "12") { num++; SP--; } break;
                }
            }
            bMEC4 = num;
            MEC_4_S.Text = num.ToString();
            SkillPoint1.Text = SP.ToString();
            SkillPoint2.Text = SP.ToString();
            SkillPoint3.Text = SP.ToString();
            StatusFormLoad();
        }
        private void MEC_4_SUB_Click(object sender, EventArgs e)
        {
            int num = int.Parse(MEC_4_S.Text);
            int Base = int.Parse(MEC_4_B.Text);
            if (SP < 30) { if (Base < num) { num--; SP++; } }
            MEC_4_S.Text = num.ToString();
            SkillPoint1.Text = SP.ToString();
            SkillPoint2.Text = SP.ToString();
            SkillPoint3.Text = SP.ToString();
            StatusFormLoad();
        }
        private void MEC_5_ADD_Click(object sender, EventArgs e)
        {
            int num = int.Parse(MEC_5_S.Text);
            if (SP > 0)
            {
                switch (ServiceGroup.SelectedIndex)
                {
                    case 1: if (MEC_5_S.Text != "14") { num++; SP--; } break;
                    case 6: if (MEC_5_S.Text != "14") { num++; SP--; } break;
                    default: if (MEC_5_S.Text != "12") { num++; SP--; } break;
                }
            }
            bMEC5 = num;
            MEC_5_S.Text = num.ToString();
            SkillPoint1.Text = SP.ToString();
            SkillPoint2.Text = SP.ToString();
            SkillPoint3.Text = SP.ToString();
            StatusFormLoad();
        }
        private void MEC_5_SUB_Click(object sender, EventArgs e)
        {
            int num = int.Parse(MEC_5_S.Text);
            int Base = int.Parse(MEC_5_B.Text);
            if (SP < 30) { if (Base < num) { num--; SP++; } }
            MEC_5_S.Text = num.ToString();
            SkillPoint1.Text = SP.ToString();
            SkillPoint2.Text = SP.ToString();
            SkillPoint3.Text = SP.ToString();
            StatusFormLoad();
        }
        private void MEC_6_ADD_Click(object sender, EventArgs e)
        {
            int num = int.Parse(MEC_6_S.Text);
            if (SP > 0)
            {
                switch (ServiceGroup.SelectedIndex)
                {
                    case 1: if (MEC_6_S.Text != "14") { num++; SP--; } break;
                    case 5: if (MEC_6_S.Text != "14") { num++; SP--; } break;
                    default: if (MEC_6_S.Text != "12") { num++; SP--; } break;
                }
            }
            bMEC6 = num;
            MEC_6_S.Text = num.ToString();
            SkillPoint1.Text = SP.ToString();
            SkillPoint2.Text = SP.ToString();
            SkillPoint3.Text = SP.ToString();
            StatusFormLoad();
        }
        private void MEC_6_SUB_Click(object sender, EventArgs e)
        {
            int num = int.Parse(MEC_6_S.Text);
            int Base = int.Parse(MEC_6_B.Text);
            if (SP < 30) { if (Base < num) { num--; SP++; } }
            MEC_6_S.Text = num.ToString();
            SkillPoint1.Text = SP.ToString();
            SkillPoint2.Text = SP.ToString();
            SkillPoint3.Text = SP.ToString();
            StatusFormLoad();
        }
        private void MEC_7_ADD_Click(object sender, EventArgs e)
        {
            int num = int.Parse(MEC_7_S.Text);
            if (SP > 0)
            {
                switch (ServiceGroup.SelectedIndex)
                {
                    case 5: if (MEC_7_S.Text != "14") { num++; SP--; } break;
                    default: if (MEC_7_S.Text != "12") { num++; SP--; } break;
                }
            }
            bMEC7 = num;
            MEC_7_S.Text = num.ToString();
            SkillPoint1.Text = SP.ToString();
            SkillPoint2.Text = SP.ToString();
            SkillPoint3.Text = SP.ToString();
            StatusFormLoad();
        }
        private void MEC_7_SUB_Click(object sender, EventArgs e)
        {
            int num = int.Parse(MEC_7_S.Text);
            int Base = int.Parse(MEC_7_B.Text);
            if (SP < 30) { if (Base < num) { num--; SP++; } }
            MEC_7_S.Text = num.ToString();
            SkillPoint1.Text = SP.ToString();
            SkillPoint2.Text = SP.ToString();
            SkillPoint3.Text = SP.ToString();
            StatusFormLoad();
        }
        private void MEC_8_ADD_Click(object sender, EventArgs e)
        {
            int num = int.Parse(MEC_8_S.Text);
            if (SP > 0)
            {
                switch (ServiceGroup.SelectedIndex)
                {
                    case 3: if (MEC_8_S.Text != "14") { num++; SP--; } break;
                    default: if (MEC_8_S.Text != "12") { num++; SP--; } break;
                }
            }
            bMEC8 = num;
            MEC_8_S.Text = num.ToString();
            SkillPoint1.Text = SP.ToString();
            SkillPoint2.Text = SP.ToString();
            SkillPoint3.Text = SP.ToString();
            StatusFormLoad();
        }
        private void MEC_8_SUB_Click(object sender, EventArgs e)
        {
            int num = int.Parse(MEC_8_S.Text);
            int Base = int.Parse(MEC_8_B.Text);
            if (SP < 30) { if (Base < num) { num--; SP++; } }
            MEC_8_S.Text = num.ToString();
            SkillPoint1.Text = SP.ToString();
            SkillPoint2.Text = SP.ToString();
            SkillPoint3.Text = SP.ToString();
            StatusFormLoad();
        }
        private void DEX_1_ADD_Click(object sender, EventArgs e)
        {
            int num = int.Parse(DEX_1_S.Text);
            if (SP > 0)
            {
                switch (ServiceGroup.SelectedIndex)
                {
                    case 0: if (DEX_1_S.Text != "14") { num++; SP--; } break;
                    case 3: if (DEX_1_S.Text != "14") { num++; SP--; } break;
                    default: if (DEX_1_S.Text != "12") { num++; SP--; } break;
                }
            }
            bDEX1 = num;
            DEX_1_S.Text = num.ToString();
            SkillPoint1.Text = SP.ToString();
            SkillPoint2.Text = SP.ToString();
            SkillPoint3.Text = SP.ToString();
            StatusFormLoad();
        }
        private void DEX_1_SUB_Click(object sender, EventArgs e)
        {
            int num = int.Parse(DEX_1_S.Text);
            int Base = int.Parse(DEX_1_B.Text);
            if (SP < 30) { if (Base < num) { num--; SP++; } }
            DEX_1_S.Text = num.ToString();
            SkillPoint1.Text = SP.ToString();
            SkillPoint2.Text = SP.ToString();
            SkillPoint3.Text = SP.ToString();
            StatusFormLoad();
        }
        private void DEX_2_ADD_Click(object sender, EventArgs e)
        {
            int num = int.Parse(DEX_2_S.Text);
            if (SP > 0)
            {
                switch (ServiceGroup.SelectedIndex)
                {
                    default: if (DEX_2_S.Text != "12") { num++; SP--; } break;
                }
            }
            bDEX2 = num;
            DEX_2_S.Text = num.ToString();
            SkillPoint1.Text = SP.ToString();
            SkillPoint2.Text = SP.ToString();
            SkillPoint3.Text = SP.ToString();
            StatusFormLoad();
        }
        private void DEX_2_SUB_Click(object sender, EventArgs e)
        {
            int num = int.Parse(DEX_2_S.Text);
            int Base = int.Parse(DEX_2_B.Text);
            if (SP < 30) { if (Base < num) { num--; SP++; } }
            DEX_2_S.Text = num.ToString();
            SkillPoint1.Text = SP.ToString();
            SkillPoint2.Text = SP.ToString();
            SkillPoint3.Text = SP.ToString();
            StatusFormLoad();
        }
        private void DEX_3_ADD_Click(object sender, EventArgs e)
        {
            int num = int.Parse(DEX_3_S.Text);
            if (SP > 0)
            {
                switch (ServiceGroup.SelectedIndex)
                {
                    case 3: if (DEX_3_S.Text != "14") { num++; SP--; } break;
                    default: if (DEX_3_S.Text != "12") { num++; SP--; } break;
                }
            }
            bDEX3 = num;
            DEX_3_S.Text = num.ToString();
            SkillPoint1.Text = SP.ToString();
            SkillPoint2.Text = SP.ToString();
            SkillPoint3.Text = SP.ToString();
            StatusFormLoad();
        }
        private void DEX_3_SUB_Click(object sender, EventArgs e)
        {
            int num = int.Parse(DEX_3_S.Text);
            int Base = int.Parse(DEX_3_B.Text);
            if (SP < 30) { if (Base < num) { num--; SP++; } }
            DEX_3_S.Text = num.ToString();
            SkillPoint1.Text = SP.ToString();
            SkillPoint2.Text = SP.ToString();
            SkillPoint3.Text = SP.ToString();
            StatusFormLoad();
        }
        private void DEX_4_ADD_Click(object sender, EventArgs e)
        {
            int num = int.Parse(DEX_4_S.Text);
            if (SP > 0)
            {
                switch (ServiceGroup.SelectedIndex)
                {
                    default: if (DEX_4_S.Text != "12") { num++; SP--; } break;
                }
            }
            bDEX4 = num;
            DEX_4_S.Text = num.ToString();
            SkillPoint1.Text = SP.ToString();
            SkillPoint2.Text = SP.ToString();
            SkillPoint3.Text = SP.ToString();
            StatusFormLoad();
        }
        private void DEX_4_SUB_Click(object sender, EventArgs e)
        {
            int num = int.Parse(DEX_4_S.Text);
            int Base = int.Parse(DEX_4_B.Text);
            if (SP < 30) { if (Base < num) { num--; SP++; } }
            DEX_4_S.Text = num.ToString();
            SkillPoint1.Text = SP.ToString();
            SkillPoint2.Text = SP.ToString();
            SkillPoint3.Text = SP.ToString();
            StatusFormLoad();
        }
        private void DEX_5_ADD_Click(object sender, EventArgs e)
        {
            int num = int.Parse(DEX_5_S.Text);
            if (SP > 0)
            {
                switch (ServiceGroup.SelectedIndex)
                {
                    case 4: if (DEX_5_S.Text != "14") { num++; SP--; } break;
                    default: if (DEX_5_S.Text != "12") { num++; SP--; } break;
                }
            }
            bDEX5 = num;
            DEX_5_S.Text = num.ToString();
            SkillPoint1.Text = SP.ToString();
            SkillPoint2.Text = SP.ToString();
            SkillPoint3.Text = SP.ToString();
            StatusFormLoad();
        }
        private void DEX_5_SUB_Click(object sender, EventArgs e)
        {
            int num = int.Parse(DEX_5_S.Text);
            int Base = int.Parse(DEX_5_B.Text);
            if (SP < 30) { if (Base < num) { num--; SP++; } }
            DEX_5_S.Text = num.ToString();
            SkillPoint1.Text = SP.ToString();
            SkillPoint2.Text = SP.ToString();
            SkillPoint3.Text = SP.ToString();
            StatusFormLoad();
        }
        private void SEN_1_ADD_Click(object sender, EventArgs e)
        {
            int num = int.Parse(SEN_1_S.Text);
            if (SP > 0)
            {
                switch (ServiceGroup.SelectedIndex)
                {
                    case 2: if (SEN_1_S.Text != "14") { num++; SP--; } break;
                    case 4: if (SEN_1_S.Text != "14") { num++; SP--; } break;
                    case 6: if (SEN_1_S.Text != "14") { num++; SP--; } break;
                    default: if (SEN_1_S.Text != "12") { num++; SP--; } break;
                }
            }
            bSEN1 = num;
            SEN_1_S.Text = num.ToString();
            SkillPoint1.Text = SP.ToString();
            SkillPoint2.Text = SP.ToString();
            SkillPoint3.Text = SP.ToString();
            StatusFormLoad();
        }
        private void SEN_1_SUB_Click(object sender, EventArgs e)
        {
            int num = int.Parse(SEN_1_S.Text);
            int Base = int.Parse(SEN_1_B.Text);
            if (SP < 30) { if (Base < num) { num--; SP++; } }
            SEN_1_S.Text = num.ToString();
            SkillPoint1.Text = SP.ToString();
            SkillPoint2.Text = SP.ToString();
            SkillPoint3.Text = SP.ToString();
            StatusFormLoad();
        }
        private void SEN_2_ADD_Click(object sender, EventArgs e)
        {
            int num = int.Parse(SEN_2_S.Text);
            if (SP > 0)
            {
                switch (ServiceGroup.SelectedIndex)
                {
                    case 5: if (SEN_2_S.Text != "14") { num++; SP--; } break;
                    case 6: if (SEN_2_S.Text != "14") { num++; SP--; } break;
                    default: if (SEN_2_S.Text != "12") { num++; SP--; } break;
                }
            }
            bSEN2 = num;
            SEN_2_S.Text = num.ToString();
            SkillPoint1.Text = SP.ToString();
            SkillPoint2.Text = SP.ToString();
            SkillPoint3.Text = SP.ToString();
            StatusFormLoad();
        }
        private void SEN_2_SUB_Click(object sender, EventArgs e)
        {
            int num = int.Parse(SEN_2_S.Text);
            int Base = int.Parse(SEN_2_B.Text);
            if (SP < 30) { if (Base < num) { num--; SP++; } }
            SEN_2_S.Text = num.ToString();
            SkillPoint1.Text = SP.ToString();
            SkillPoint2.Text = SP.ToString();
            SkillPoint3.Text = SP.ToString();
            StatusFormLoad();
        }
        private void SEN_3_ADD_Click(object sender, EventArgs e)
        {
            int num = int.Parse(SEN_3_S.Text);
            if (SP > 0)
            {
                switch (ServiceGroup.SelectedIndex)
                {
                    case 6: if (SEN_3_S.Text != "14") { num++; SP--; } break;
                    case 7: if (SEN_3_S.Text != "14") { num++; SP--; } break;
                    default: if (SEN_3_S.Text != "12") { num++; SP--; } break;
                }
            }
            bSEN3 = num;
            SEN_3_S.Text = num.ToString();
            SkillPoint1.Text = SP.ToString();
            SkillPoint2.Text = SP.ToString();
            SkillPoint3.Text = SP.ToString();
            StatusFormLoad();
        }
        private void SEN_3_SUB_Click(object sender, EventArgs e)
        {
            int num = int.Parse(SEN_3_S.Text);
            int Base = int.Parse(SEN_3_B.Text);
            if (SP < 30) { if (Base < num) { num--; SP++; } }
            SEN_3_S.Text = num.ToString();
            SkillPoint1.Text = SP.ToString();
            SkillPoint2.Text = SP.ToString();
            SkillPoint3.Text = SP.ToString();
            StatusFormLoad();
        }
        private void SEN_4_ADD_Click(object sender, EventArgs e)
        {
            int num = int.Parse(SEN_4_S.Text);
            if (SP > 0)
            {
                switch (ServiceGroup.SelectedIndex)
                {
                    case 3: if (SEN_4_S.Text != "14") { num++; SP--; } break;
                    default: if (SEN_4_S.Text != "12") { num++; SP--; } break;
                }
            }
            bSEN4 = num;
            SEN_4_S.Text = num.ToString();
            SkillPoint1.Text = SP.ToString();
            SkillPoint2.Text = SP.ToString();
            SkillPoint3.Text = SP.ToString();
            StatusFormLoad();
        }
        private void SEN_4_SUB_Click(object sender, EventArgs e)
        {
            int num = int.Parse(SEN_4_S.Text);
            int Base = int.Parse(SEN_4_B.Text);
            if (SP < 30) { if (Base < num) { num--; SP++; } }
            SEN_4_S.Text = num.ToString();
            SkillPoint1.Text = SP.ToString();
            SkillPoint2.Text = SP.ToString();
            SkillPoint3.Text = SP.ToString();
            StatusFormLoad();
        }
        private void SEN_5_ADD_Click(object sender, EventArgs e)
        {
            int num = int.Parse(SEN_5_S.Text);
            if (SP > 0)
            {
                switch (ServiceGroup.SelectedIndex)
                {
                    case 1: if (SEN_5_S.Text != "14") { num++; SP--; } break;
                    case 5: if (SEN_5_S.Text != "14") { num++; SP--; } break;
                    case 6: if (SEN_5_S.Text != "14") { num++; SP--; } break;
                    default: if (SEN_5_S.Text != "12") { num++; SP--; } break;
                }
            }
            bSEN5 = num;
            SEN_5_S.Text = num.ToString();
            SkillPoint1.Text = SP.ToString();
            SkillPoint2.Text = SP.ToString();
            SkillPoint3.Text = SP.ToString();
            StatusFormLoad();
        }
        private void SEN_5_SUB_Click(object sender, EventArgs e)
        {
            int num = int.Parse(SEN_5_S.Text);
            int Base = int.Parse(SEN_5_B.Text);
            if (SP < 30) { if (Base < num) { num--; SP++; } }
            SEN_5_S.Text = num.ToString();
            SkillPoint1.Text = SP.ToString();
            SkillPoint2.Text = SP.ToString();
            SkillPoint3.Text = SP.ToString();
            StatusFormLoad();
        }
        private void SEN_6_ADD_Click(object sender, EventArgs e)
        {
            int num = int.Parse(SEN_6_S.Text);
            if (SP > 0)
            {
                switch (ServiceGroup.SelectedIndex)
                {
                    case 2: if (SEN_6_S.Text != "14") { num++; SP--; } break;
                    default: if (SEN_6_S.Text != "12") { num++; SP--; } break;
                }
            }
            bSEN6 = num;
            SEN_6_S.Text = num.ToString();
            SkillPoint1.Text = SP.ToString();
            SkillPoint2.Text = SP.ToString();
            SkillPoint3.Text = SP.ToString();
            StatusFormLoad();
        }
        private void SEN_6_SUB_Click(object sender, EventArgs e)
        {
            int num = int.Parse(SEN_6_S.Text);
            int Base = int.Parse(SEN_6_B.Text);
            if (SP < 30) { if (Base < num) { num--; SP++; } }
            SEN_6_S.Text = num.ToString();
            SkillPoint1.Text = SP.ToString();
            SkillPoint2.Text = SP.ToString();
            SkillPoint3.Text = SP.ToString();
            StatusFormLoad();
        }
        private void SEN_7_ADD_Click(object sender, EventArgs e)
        {
            int num = int.Parse(SEN_7_S.Text);
            if (SP > 0)
            {
                switch (ServiceGroup.SelectedIndex)
                {
                    case 1: if (SEN_7_S.Text != "14") { num++; SP--; } break;
                    default: if (SEN_7_S.Text != "12") { num++; SP--; } break;
                }
            }
            bSEN7 = num;
            SEN_7_S.Text = num.ToString();
            SkillPoint1.Text = SP.ToString();
            SkillPoint2.Text = SP.ToString();
            SkillPoint3.Text = SP.ToString();
            StatusFormLoad();
        }
        private void SEN_7_SUB_Click(object sender, EventArgs e)
        {
            int num = int.Parse(SEN_7_S.Text);
            int Base = int.Parse(SEN_7_B.Text);
            if (SP < 30) { if (Base < num) { num--; SP++; } }
            SEN_7_S.Text = num.ToString();
            SkillPoint1.Text = SP.ToString();
            SkillPoint2.Text = SP.ToString();
            SkillPoint3.Text = SP.ToString();
            StatusFormLoad();
        }
        private void SEN_8_ADD_Click(object sender, EventArgs e)
        {
            int num = int.Parse(SEN_8_S.Text);
            if (SP > 0)
            {
                switch (ServiceGroup.SelectedIndex)
                {
                    case 0: if (SEN_8_S.Text != "14") { num++; SP--; } break;
                    case 7: if (SEN_8_S.Text != "14") { num++; SP--; } break;
                    default: if (SEN_8_S.Text != "12") { num++; SP--; } break;
                }
            }
            bSEN8 = num;
            SEN_8_S.Text = num.ToString();
            SkillPoint1.Text = SP.ToString();
            SkillPoint2.Text = SP.ToString();
            SkillPoint3.Text = SP.ToString();
            StatusFormLoad();
        }
        private void SEN_8_SUB_Click(object sender, EventArgs e)
        {
            int num = int.Parse(SEN_8_S.Text);
            int Base = int.Parse(SEN_8_B.Text);
            if (SP < 30) { if (Base < num) { num--; SP++; } }
            SEN_8_S.Text = num.ToString();
            SkillPoint1.Text = SP.ToString();
            SkillPoint2.Text = SP.ToString();
            SkillPoint3.Text = SP.ToString();
            StatusFormLoad();
        }
        private void SEN_9_ADD_Click(object sender, EventArgs e)
        {
            int num = int.Parse(SEN_9_S.Text);
            if (SP > 0)
            {
                switch (ServiceGroup.SelectedIndex)
                {
                    case 3: if (SEN_9_S.Text != "14") { num++; SP--; } break;
                    default: if (SEN_9_S.Text != "12") { num++; SP--; } break;
                }
            }
            bSEN9 = num;
            SEN_9_S.Text = num.ToString();
            SkillPoint1.Text = SP.ToString();
            SkillPoint2.Text = SP.ToString();
            SkillPoint3.Text = SP.ToString();
            StatusFormLoad();
        }
        private void SEN_9_SUB_Click(object sender, EventArgs e)
        {
            int num = int.Parse(SEN_9_S.Text);
            int Base = int.Parse(SEN_9_B.Text);
            if (SP < 30) { if (Base < num) { num--; SP++; } }
            SEN_9_S.Text = num.ToString();
            SkillPoint1.Text = SP.ToString();
            SkillPoint2.Text = SP.ToString();
            SkillPoint3.Text = SP.ToString();
            StatusFormLoad();
        }
        private void SEN_10_ADD_Click(object sender, EventArgs e)
        {
            int num = int.Parse(SEN_10_S.Text);
            if (SP > 0)
            {
                switch (ServiceGroup.SelectedIndex)
                {
                    case 5: if (SEN_10_S.Text != "14") { num++; SP--; } break;
                    default: if (SEN_10_S.Text != "12") { num++; SP--; } break;
                }
            }
            bSEN10 = num;
            SEN_10_S.Text = num.ToString();
            SkillPoint1.Text = SP.ToString();
            SkillPoint2.Text = SP.ToString();
            SkillPoint3.Text = SP.ToString();
            StatusFormLoad();
        }
        private void SEN_10_SUB_Click(object sender, EventArgs e)
        {
            int num = int.Parse(SEN_10_S.Text);
            int Base = int.Parse(SEN_10_B.Text);
            if (SP < 30) { if (Base < num) { num--; SP++; } }
            SEN_10_S.Text = num.ToString();
            SkillPoint1.Text = SP.ToString();
            SkillPoint2.Text = SP.ToString();
            SkillPoint3.Text = SP.ToString();
            StatusFormLoad();
        }
        private void SEN_11_ADD_Click(object sender, EventArgs e)
        {
            int num = int.Parse(SEN_11_S.Text);
            if (SP > 0)
            {
                switch (ServiceGroup.SelectedIndex)
                {
                    default: if (SEN_11_S.Text != "12") { num++; SP--; } break;
                }
            }
            bSEN11 = num;
            SEN_11_S.Text = num.ToString();
            SkillPoint1.Text = SP.ToString();
            SkillPoint2.Text = SP.ToString();
            SkillPoint3.Text = SP.ToString();
            StatusFormLoad();
        }
        private void SEN_11_SUB_Click(object sender, EventArgs e)
        {
            int num = int.Parse(SEN_11_S.Text);
            int Base = int.Parse(SEN_11_B.Text);
            if (SP < 30) { if (Base < num) { num--; SP++; } }
            SEN_11_S.Text = num.ToString();
            SkillPoint1.Text = SP.ToString();
            SkillPoint2.Text = SP.ToString();
            SkillPoint3.Text = SP.ToString();
            StatusFormLoad();
        }
        private void SEN_12_ADD_Click(object sender, EventArgs e)
        {
            int num = int.Parse(SEN_12_S.Text);
            if (SP > 0)
            {
                switch (ServiceGroup.SelectedIndex)
                {
                    case 0: if (SEN_12_S.Text != "14") { num++; SP--; } break;
                    case 7: if (SEN_12_S.Text != "14") { num++; SP--; } break;
                    default: if (SEN_12_S.Text != "12") { num++; SP--; } break;
                }
            }
            bSEN12 = num;
            SEN_12_S.Text = num.ToString();
            SkillPoint1.Text = SP.ToString();
            SkillPoint2.Text = SP.ToString();
            SkillPoint3.Text = SP.ToString();
            StatusFormLoad();
        }
        private void SEN_12_SUB_Click(object sender, EventArgs e)
        {
            int num = int.Parse(SEN_12_S.Text);
            int Base = int.Parse(SEN_12_B.Text);
            if (SP < 30) { if (Base < num) { num--; SP++; } }
            SEN_12_S.Text = num.ToString();
            SkillPoint1.Text = SP.ToString();
            SkillPoint2.Text = SP.ToString();
            SkillPoint3.Text = SP.ToString();
            StatusFormLoad();
        }

        public static string EncryptString(string sourceString, string password) {

            System.Security.Cryptography.RijndaelManaged rijndael = new System.Security.Cryptography.RijndaelManaged();
            byte[] key, iv;
            GenKeyFromPassword(password, rijndael.KeySize, out key, rijndael.BlockSize, out iv);
            rijndael.Key = key;
            rijndael.IV = iv;

            byte[] strBytes = System.Text.Encoding.UTF8.GetBytes(sourceString);
            System.Security.Cryptography.ICryptoTransform encryptor = rijndael.CreateEncryptor();
            
            byte[] encBytes = encryptor.TransformFinalBlock(strBytes, 0, strBytes.Length);
            encryptor.Dispose();

            return System.Convert.ToBase64String(encBytes);
            
        }

        public static string DecryptString(string sourceString, string password) {
            System.Security.Cryptography.RijndaelManaged rijndeal = new System.Security.Cryptography.RijndaelManaged();

            byte[] key, iv;
            GenKeyFromPassword(password, rijndeal.KeySize, out key, rijndeal.BlockSize, out iv);
            rijndeal.Key = key;
            rijndeal.IV = iv;

            byte[] strBytes = System.Convert.FromBase64String(sourceString);
            System.Security.Cryptography.ICryptoTransform decryptor = rijndeal.CreateDecryptor();

            byte[] decBytes = decryptor.TransformFinalBlock(strBytes, 0, strBytes.Length);
            decryptor.Dispose();

            return System.Text.Encoding.UTF8.GetString(decBytes);
        }

        private static void GenKeyFromPassword(string password, int keySize, out byte[] key, int blockSize, out byte[] iv) {
            byte[] salt = System.Text.Encoding.UTF8.GetBytes("早苗さんかわいい");
            System.Security.Cryptography.Rfc2898DeriveBytes deriveBytes = new System.Security.Cryptography.Rfc2898DeriveBytes(password, salt);
            deriveBytes.IterationCount = 1000;

            key = deriveBytes.GetBytes(keySize / 8);
            iv = deriveBytes.GetBytes(blockSize / 8);
        }

        private void Export_Click(object sender, EventArgs e)
        {
            string[] data = new string[1000];
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "PCSCファイル(*.pcs)|*.pcs;|すべてのファイル(*.*)|*.*";
            sfd.FileName = CharacterName.Text;
            data[0] = CharacterName.Text;
            data[1] = PlayerName.Text;
            data[2] = CloneNum.Value.ToString();
            data[3] = SecurityClearance.SelectedIndex.ToString();
            data[4] = ServiceGroup.SelectedIndex.ToString();
            if(MBD.SelectedItem != null)data[5] = MBD.SelectedItem.ToString();
            data[6] = MUT.Value.ToString();
            
            data[100] = STR.Value.ToString();
            
            data[200] = END.Value.ToString();
            
            data[300] = DEX.Value.ToString(); 
            for (int i = 0; i < 5; i++){ //301~310まで使用
                if (DU[i] == false)
                {
                    data[i + 301] = "0";
                }
                else if (DU[i] == true)
                {
                    data[i + 301] = "1";
                }
                if (DD[i] == false)
                {
                    data[i + 306] = "0";
                }
                else if (DD[i] == true)
                {
                    data[i + 306] = "1";
                }
            }
            data[330] = dDEX.ToString();
            data[340] = DEX_1_S.Text;
            data[341] = DEX_2_S.Text;
            data[342] = DEX_3_S.Text;
            data[343] = DEX_4_S.Text;
            data[344] = DEX_5_S.Text;

            data[400] = AGI.Value.ToString();
            for (int i = 0; i < 5; i++){ //401~410まで使用
                if (AU[i] == false)
                {
                    data[i + 401] = "0";
                }
                else if (AU[i] == true)
                {
                    data[i + 401] = "1";
                }
                if (AD[i] == false)
                {
                    data[i + 406] = "0";
                }
                else if (AD[i] == true)
                {
                    data[i + 406] = "1";
                }
            }
            data[430] = dAGI.ToString();
            data[440] = AGI_1_S.Text;
            data[441] = AGI_2_S.Text;
            data[442] = AGI_3_S.Text;
            data[443] = AGI_4_S.Text;
            data[444] = AGI_5_S.Text;
            
            data[500] = IMP.Value.ToString();
            for (int i = 0; i < 9; i++){ //501~518まで使用
                if (IU[i] == false)
                {
                    data[i + 501] = "0";
                }
                else if (IU[i] == true)
                {
                    data[i + 501] = "1";
                }
                if (ID[i] == false)
                {
                    data[i + 510] = "0";
                }
                else if (ID[i] == true)
                {
                    data[i + 510] = "1";
                }
            }
            data[530] = dIMP.ToString();
            data[540] = IMP_1_S.Text;
            data[541] = IMP_2_S.Text;
            data[542] = IMP_3_S.Text;
            data[543] = IMP_4_S.Text;
            data[544] = IMP_5_S.Text;
            data[545] = IMP_6_S.Text;
            data[546] = IMP_7_S.Text;
            data[547] = IMP_8_S.Text;
            data[548] = IMP_9_S.Text;
            
            data[600] = SEN.Value.ToString();
            for (int i = 0; i < 12; i++){ //601~624まで使用
                if (SU[i] == false)
                {
                    data[i + 601] = "0";
                }
                else if (SU[i] == true)
                {
                    data[i + 601] = "1";
                }
                if (SD[i] == false)
                {
                    data[i + 613] = "0";
                }
                else if (SD[i] == true)
                {
                    data[i + 613] = "1";
                }
            }
            data[630] = dSEN.ToString();
            data[640] = SEN_1_S.Text;
            data[641] = SEN_2_S.Text;
            data[642] = SEN_3_S.Text;
            data[643] = SEN_4_S.Text;
            data[644] = SEN_5_S.Text;
            data[645] = SEN_6_S.Text;
            data[646] = SEN_7_S.Text;
            data[647] = SEN_8_S.Text;
            data[648] = SEN_9_S.Text;
            data[649] = SEN_10_S.Text;
            data[650] = SEN_11_S.Text;
            data[651] = SEN_12_S.Text;
            
            data[700] = MEC.Value.ToString();
            for (int i = 0; i < 8; i++){ //701~716まで使用
                if (MU[i] == false)
                {
                    data[i + 701] = "0";
                }
                else if (MU[i] == true)
                {
                    data[i + 701] = "1";
                }
                if (MD[i] == false)
                {
                    data[i + 709] = "0";
                }
                else if (MD[i] == true)
                {
                    data[i + 709] = "1";
                }
            }
            data[730] = dMEC.ToString();
            data[740] = MEC_1_S.Text;
            data[741] = MEC_2_S.Text;
            data[742] = MEC_3_S.Text;
            data[743] = MEC_4_S.Text;
            data[744] = MEC_5_S.Text;
            data[745] = MEC_6_S.Text;
            data[746] = MEC_7_S.Text;
            data[747] = MEC_8_S.Text;

            data[800] = SP.ToString();
            
            data[900] = Weapon1Name.Text;
            data[901] = Weapon1Skill.Text;
            data[902] = Weapon1Dnum.Text;
            data[903] = Weapon1Type.Text;
            data[904] = Weapon1Range.Text;
            data[905] = Weapon2Name.Text;
            data[906] = Weapon2Skill.Text;
            data[907] = Weapon2Dnum.Text;
            data[908] = Weapon2Type.Text;
            data[909] = Weapon2Range.Text; 
            data[910] = Weapon3Name.Text;
            data[911] = Weapon3Skill.Text;
            data[912] = Weapon3Dnum.Text;
            data[913] = Weapon3Type.Text;
            data[914] = Weapon3Range.Text;
            data[920] = Armor1Name.Text;
            data[921] = Armor1Type.Text;
            data[922] = Armor1Rate.Text;
            data[923] = Armor2Name.Text;
            data[924] = Armor2Type.Text;
            data[925] = Armor2Rate.Text;
            data[930] = EquipmentItem.Text;
            data[931] = Credit.Text;
            data[940] = MutantSkills.SelectedIndex.ToString();
            data[941] = SecretSociety.SelectedIndex.ToString();
            data[942] = SecretSocietyRank.Text;
            data[950] = etc.Text;

            if (sfd.ShowDialog() == DialogResult.OK) {

                System.IO.Stream stream;
                stream = sfd.OpenFile();
                string str;
                if (stream != null) {

                    System.IO.StreamWriter sw = new System.IO.StreamWriter(
                        stream);
                    for (int i = 0; i < 1000; i++)
                    {
                        if (data[i] != null)
                        {
                            str = EncryptString(data[i], "sanaesankawaii");
                            if (i < 10) {
                                sw.WriteLine("00" + i + str);
                            }
                            else if (10 <= i && i < 100)
                            {
                                sw.WriteLine("0" + i + str);
                            }
                            else
                            {
                                sw.WriteLine(i + str);
                            }    
                        }
                    }
                    sw.Close();
                    stream.Close();
                }
            } sfd.Filter = "PCSCPassファイル(*.pcp)|*.pcp;|すべてのファイル(*.*)|*.*";
            sfd.FileName = CharacterName.Text + "_Pass";
            if (sfd.ShowDialog() == DialogResult.OK) {
                System.IO.Stream stream;
                stream = sfd.OpenFile();
                string str;
                string key;
                if (stream != null)
                {
                    System.IO.StreamWriter sw = new System.IO.StreamWriter(
                                stream);
                    key = data[0] + data[940] + data[941];
                    str = EncryptString(key,"sanaesankawaii");
                    sw.WriteLine("999" + str);
                    sw.Close();
                    stream.Close();
                }
                

            }
        }

        private void Inport_Click(object sender, EventArgs e)
        {
            passFile = false;
            tabControl1.TabPages.Remove(tabPage5);
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "PCSCファイル(*.pcs)|*.pcs;|PCSCPassファイル(*.pcp)|*pcp;|すべてのファイル(*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                System.IO.Stream stream;
                stream = ofd.OpenFile();
                string stResult = string.Empty;
                string encStr = string.Empty;
                string num = string.Empty;
                if (stream != null)
                {
                    System.IO.StreamReader sr = new System.IO.StreamReader(stream);
                    while (sr.Peek() >= 0)
                    {
                        string stBuffer = sr.ReadLine();
                        num = stBuffer.Substring(0, 3);
                        encStr = stBuffer.Substring(3);
                        stResult = DecryptString(encStr, "sanaesankawaii");
                        InportNum(num, stResult);

                    }
                    sr.Close();
                    stream.Close();
                }
            }
            StatusFormLoad();
        }

        private void InportNum(string num,string stResult) {
            switch (num) {
                case "000": CharacterName.Text = stResult; break;
                case "001": PlayerName.Text = stResult; break;
                case "002": CloneNum.Value = int.Parse(stResult); break;
                case "003": SecurityClearance.SelectedIndex = int.Parse(stResult); break;
                case "004": ServiceGroup.SelectedIndex = int.Parse(stResult); break;
                case "005": MBD.SelectedItem = stResult; break;
                case "006": MUT.Value = int.Parse(stResult); break ;
                case "100": STR.Value = int.Parse(stResult); break;
                case "200": END.Value = int.Parse(stResult);
                    END_CHANGE(int.Parse(stResult)); break;
                case "300": DEX.Value = int.Parse(stResult);
                    DEX_DICE(int.Parse(stResult)); break;
                case "301": if (stResult == "0") DU[0] = false; else DU[0] = true; break;
                case "302": if (stResult == "0") DU[1] = false; else DU[1] = true; break;
                case "303": if (stResult == "0") DU[2] = false; else DU[2] = true; break;
                case "304": if (stResult == "0") DU[3] = false; else DU[3] = true; break;
                case "305": if (stResult == "0") DU[4] = false; else DU[4] = true; break;
                case "306": if (stResult == "0") DD[0] = false; else DD[0] = true; break;
                case "307": if (stResult == "0") DD[1] = false; else DD[1] = true; break;
                case "308": if (stResult == "0") DD[2] = false; else DD[2] = true; break;
                case "309": if (stResult == "0") DD[3] = false; else DD[3] = true; break;
                case "310": if (stResult == "0") DD[4] = false; else DD[4] = true; break;
                case "330": dDEX = int.Parse(stResult); break;
                case "340": DEX_1_S.Text = stResult; break;
                case "341": DEX_2_S.Text = stResult; break;
                case "342": DEX_3_S.Text = stResult; break;
                case "343": DEX_4_S.Text = stResult; break;
                case "344": DEX_5_S.Text = stResult; break;
                case "400": AGI.Value = int.Parse(stResult);
                    AGI_DICE(int.Parse(stResult)); break;
                case "401": if (stResult == "0") AU[0] = false; else AU[0] = true; break;
                case "402": if (stResult == "0") AU[1] = false; else AU[1] = true; break;
                case "403": if (stResult == "0") AU[2] = false; else AU[2] = true; break;
                case "404": if (stResult == "0") AU[3] = false; else AU[3] = true; break;
                case "405": if (stResult == "0") AU[4] = false; else AU[4] = true; break;
                case "406": if (stResult == "0") AD[0] = false; else AD[0] = true; break;
                case "407": if (stResult == "0") AD[1] = false; else AD[1] = true; break;
                case "408": if (stResult == "0") AD[2] = false; else AD[2] = true; break;
                case "409": if (stResult == "0") AD[3] = false; else AD[3] = true; break;
                case "410": if (stResult == "0") AD[4] = false; else AD[4] = true; break;
                case "430": dAGI = int.Parse(stResult); break;
                case "440": AGI_1_S.Text = stResult; break;
                case "441": AGI_2_S.Text = stResult; break;
                case "442": AGI_3_S.Text = stResult; break;
                case "443": AGI_4_S.Text = stResult; break;
                case "444": AGI_5_S.Text = stResult; break;
                case "500": IMP.Value = int.Parse(stResult);
                    IMP_DICE(int.Parse(stResult)); break;
                case "501": if (stResult == "0") IU[0] = false; else IU[0] = true; break;
                case "502": if (stResult == "0") IU[1] = false; else IU[1] = true; break;
                case "503": if (stResult == "0") IU[2] = false; else IU[2] = true; break;
                case "504": if (stResult == "0") IU[3] = false; else IU[3] = true; break;
                case "505": if (stResult == "0") IU[4] = false; else IU[4] = true; break;
                case "506": if (stResult == "0") IU[5] = false; else IU[5] = true; break;
                case "507": if (stResult == "0") IU[6] = false; else IU[6] = true; break;
                case "508": if (stResult == "0") IU[7] = false; else IU[7] = true; break;
                case "509": if (stResult == "0") IU[8] = false; else IU[8] = true; break;
                case "510": if (stResult == "0") ID[0] = false; else ID[0] = true; break;
                case "511": if (stResult == "0") ID[1] = false; else ID[1] = true; break;
                case "512": if (stResult == "0") ID[2] = false; else ID[2] = true; break;
                case "513": if (stResult == "0") ID[3] = false; else ID[3] = true; break;
                case "514": if (stResult == "0") ID[4] = false; else ID[4] = true; break;
                case "515": if (stResult == "0") ID[5] = false; else ID[5] = true; break;
                case "516": if (stResult == "0") ID[6] = false; else ID[6] = true; break;
                case "517": if (stResult == "0") ID[7] = false; else ID[7] = true; break;
                case "518": if (stResult == "0") ID[8] = false; else ID[8] = true; break;
                case "530": dIMP = int.Parse(stResult); break;
                case "540": IMP_1_S.Text = stResult; break;
                case "541": IMP_2_S.Text = stResult; break;
                case "542": IMP_3_S.Text = stResult; break;
                case "543": IMP_4_S.Text = stResult; break;
                case "544": IMP_5_S.Text = stResult; break;
                case "545": IMP_6_S.Text = stResult; break;
                case "546": IMP_7_S.Text = stResult; break;
                case "547": IMP_8_S.Text = stResult; break;
                case "548": IMP_9_S.Text = stResult; break;
                case "600": SEN.Value = int.Parse(stResult);
                    SEN_DICE(int.Parse(stResult)); break;
                case "601": if (stResult == "0") SU[0] = false; else SU[0] = true; break;
                case "602": if (stResult == "0") SU[1] = false; else SU[1] = true; break;
                case "603": if (stResult == "0") SU[2] = false; else SU[2] = true; break;
                case "604": if (stResult == "0") SU[3] = false; else SU[3] = true; break;
                case "605": if (stResult == "0") SU[4] = false; else SU[4] = true; break;
                case "606": if (stResult == "0") SU[5] = false; else SU[5] = true; break;
                case "607": if (stResult == "0") SU[6] = false; else SU[6] = true; break;
                case "608": if (stResult == "0") SU[7] = false; else SU[7] = true; break;
                case "609": if (stResult == "0") SU[8] = false; else SU[8] = true; break;
                case "610": if (stResult == "0") SU[9] = false; else SU[9] = true; break;
                case "611": if (stResult == "0") SU[10] = false; else SU[10] = true; break;
                case "612": if (stResult == "0") SU[11] = false; else SU[11] = true; break;
                case "613": if (stResult == "0") SD[0] = false; else SD[0] = true; break;
                case "614": if (stResult == "0") SD[1] = false; else SD[1] = true; break;
                case "615": if (stResult == "0") SD[2] = false; else SD[2] = true; break;
                case "616": if (stResult == "0") SD[3] = false; else SD[3] = true; break;
                case "617": if (stResult == "0") SD[4] = false; else SD[4] = true; break;
                case "618": if (stResult == "0") SD[5] = false; else SD[5] = true; break;
                case "619": if (stResult == "0") SD[6] = false; else SD[6] = true; break;
                case "620": if (stResult == "0") SD[7] = false; else SD[7] = true; break;
                case "621": if (stResult == "0") SD[8] = false; else SD[8] = true; break;
                case "622": if (stResult == "0") SD[9] = false; else SD[9] = true; break;
                case "623": if (stResult == "0") SD[10] = false; else SD[10] = true; break;
                case "624": if (stResult == "0") SD[11] = false; else SD[11] = true; break;
                case "630": dSEN = int.Parse(stResult); break;
                case "640": SEN_1_S.Text = stResult; break;
                case "641": SEN_2_S.Text = stResult; break;
                case "642": SEN_3_S.Text = stResult; break;
                case "643": SEN_4_S.Text = stResult; break;
                case "644": SEN_5_S.Text = stResult; break;
                case "645": SEN_6_S.Text = stResult; break;
                case "646": SEN_7_S.Text = stResult; break;
                case "647": SEN_8_S.Text = stResult; break;
                case "648": SEN_9_S.Text = stResult; break;
                case "649": SEN_10_S.Text = stResult; break;
                case "650": SEN_11_S.Text = stResult; break;
                case "651": SEN_12_S.Text = stResult; break;
                case "700": MEC.Value = int.Parse(stResult);
                    MEC_DICE(int.Parse(stResult)); break;
                case "701": if (stResult == "0") MU[0] = false; else MU[0] = true; break;
                case "702": if (stResult == "0") MU[1] = false; else MU[1] = true; break;
                case "703": if (stResult == "0") MU[2] = false; else MU[2] = true; break;
                case "704": if (stResult == "0") MU[3] = false; else MU[3] = true; break;
                case "705": if (stResult == "0") MU[4] = false; else MU[4] = true; break;
                case "706": if (stResult == "0") MU[5] = false; else MU[5] = true; break;
                case "707": if (stResult == "0") MU[6] = false; else MU[6] = true; break;
                case "708": if (stResult == "0") MU[7] = false; else MU[7] = true; break;
                case "709": if (stResult == "0") MD[0] = false; else MD[0] = true; break;
                case "710": if (stResult == "0") MD[1] = false; else MD[1] = true; break;
                case "711": if (stResult == "0") MD[2] = false; else MD[2] = true; break;
                case "712": if (stResult == "0") MD[3] = false; else MD[3] = true; break;
                case "713": if (stResult == "0") MD[4] = false; else MD[4] = true; break;
                case "714": if (stResult == "0") MD[5] = false; else MD[5] = true; break;
                case "715": if (stResult == "0") MD[6] = false; else MD[6] = true; break;
                case "716": if (stResult == "0") MD[7] = false; else MD[7] = true; break;
                case "730": dMEC = int.Parse(stResult); break;
                case "740": MEC_1_S.Text = stResult; break;
                case "741": MEC_2_S.Text = stResult; break;
                case "742": MEC_3_S.Text = stResult; break;
                case "743": MEC_4_S.Text = stResult; break;
                case "744": MEC_5_S.Text = stResult; break;
                case "745": MEC_6_S.Text = stResult; break;
                case "746": MEC_7_S.Text = stResult; break;
                case "747": MEC_8_S.Text = stResult; break;



                case "800": SP = int.Parse(stResult);
                    SkillPoint1.Text = SP.ToString();
                    SkillPoint2.Text = SP.ToString();
                    SkillPoint3.Text = SP.ToString(); break;

                case "900": Weapon1Name.Text = stResult; break;
                case "901": Weapon1Skill.Text = stResult; break;
                case "902": Weapon1Dnum.Text = stResult; break;
                case "903": Weapon1Type.Text = stResult; break;
                case "904": Weapon1Range.Text = stResult; break;
                case "905": Weapon2Name.Text = stResult; break;
                case "906": Weapon2Skill.Text = stResult; break;
                case "907": Weapon2Dnum.Text = stResult; break;
                case "908": Weapon2Type.Text = stResult; break;
                case "909": Weapon2Range.Text = stResult; break;
                case "910": Weapon3Name.Text = stResult; break;
                case "911": Weapon3Skill.Text = stResult; break;
                case "912": Weapon3Dnum.Text = stResult; break;
                case "913": Weapon3Type.Text = stResult; break;
                case "914": Weapon3Range.Text = stResult; break;
                case "920": Armor1Name.Text = stResult; break;
                case "921": Armor1Type.Text = stResult; break;
                case "922": Armor1Rate.Text = stResult; break;
                case "923": Armor2Name.Text = stResult; break;
                case "924": Armor2Type.Text = stResult; break;
                case "925": Armor2Rate.Text = stResult; break;
                case "930": EquipmentItem.Text = stResult; break;
                case "931": Credit.Text = stResult; break;
                case "940": MutantSkills.SelectedIndex = int.Parse(stResult); break;
                case "941": SecretSociety.SelectedIndex = int.Parse(stResult); break;
                case "942": SecretSocietyRank.Text = stResult; break;
                case "950": etc.Text = stResult; break;

                case "999": string key; key = CharacterName.Text + MutantSkills.SelectedIndex.ToString() + SecretSociety.SelectedIndex.ToString();
                    if (stResult == key) { tabControl1.TabPages.Add(tabPage5); }  passFile = true; break;
                
                
                default: break;
            }
        }

        private void Status_Click(object sender, EventArgs e)
        {
            StatusForm = true;
            if (sForm != null) sForm.Close();
            sForm = new StatusForm();
            StatusFormLoad();
            sForm.Show();
        }
        private void StatusFormLoad() 
        {
            if (StatusForm)
            {
                sForm.CharacterName.Text = CharacterName.Text;
                sForm.Player.Text = PlayerName.Text;
                sForm.CloneNum.Text = CloneNum.Value.ToString();
                switch (SecurityClearance.SelectedIndex)
                {
                    case 0: sForm.SecurityClearance.Text = "InfraRed"; break;
                    case 1: sForm.SecurityClearance.Text = "Red"; break;
                    case 2: sForm.SecurityClearance.Text = "Orange"; break;
                    case 3: sForm.SecurityClearance.Text = "Yellow"; break;
                    case 4: sForm.SecurityClearance.Text = "Green"; break;
                    case 5: sForm.SecurityClearance.Text = "Blue"; break;
                    case 6: sForm.SecurityClearance.Text = "Ivory"; break;
                    case 7: sForm.SecurityClearance.Text = "Violet"; break;
                    case 8: sForm.SecurityClearance.Text = "UltraViolet"; break;
                }
                sForm.Service.Text = ServiceGroup.Text;
                switch (MBD.SelectedIndex)
                {
                    case 0: sForm.MBD.Text = "チームリーダー"; break;
                    case 1: sForm.MBD.Text = "記録係官"; break;
                    case 2: sForm.MBD.Text = "忠誠係官"; break;
                    case 3: sForm.MBD.Text = "幸福係官"; break;
                    case 4: sForm.MBD.Text = "清潔係官"; break;
                    case 5: sForm.MBD.Text = "整備品係官"; break;
                }
                sForm.STR.Text = STR.Value.ToString();
                sForm.END.Text = END.Value.ToString();
                sForm.DEX.Text = DEX.Value.ToString();
                sForm.AGI.Text = AGI.Value.ToString();
                sForm.IMP.Text = IMP.Value.ToString();
                sForm.SEN.Text = SEN.Value.ToString();
                sForm.MEC.Text = MEC.Value.ToString();
                sForm.MUT.Text = MUT.Value.ToString();
                sForm.Macho.Text = Macho.Value.ToString();
                sForm.ATK_Bonus.Text = ATK_Bonus.Value.ToString();
                sForm.Max_Carry.Text = Max_Carry.Value.ToString();
                sForm.HP.Text = HP.Value.ToString();
                sForm.AGI1.Text = AGI_1_S.Text;
                sForm.AGI2.Text = AGI_2_S.Text;
                sForm.AGI3.Text = AGI_3_S.Text;
                sForm.AGI4.Text = AGI_4_S.Text;
                sForm.AGI5.Text = AGI_5_S.Text;
                sForm.IMP1.Text = IMP_1_S.Text;
                sForm.IMP2.Text = IMP_2_S.Text;
                sForm.IMP3.Text = IMP_3_S.Text;
                sForm.IMP4.Text = IMP_4_S.Text;
                sForm.IMP5.Text = IMP_5_S.Text;
                sForm.IMP6.Text = IMP_6_S.Text;
                sForm.IMP7.Text = IMP_7_S.Text;
                sForm.IMP8.Text = IMP_8_S.Text;
                sForm.IMP9.Text = IMP_9_S.Text;
                sForm.MEC1.Text = MEC_1_S.Text;
                sForm.MEC2.Text = MEC_2_S.Text;
                sForm.MEC3.Text = MEC_3_S.Text;
                sForm.MEC4.Text = MEC_4_S.Text;
                sForm.MEC5.Text = MEC_5_S.Text;
                sForm.MEC6.Text = MEC_6_S.Text;
                sForm.MEC7.Text = MEC_7_S.Text;
                sForm.MEC8.Text = MEC_8_S.Text;
                sForm.DEX1.Text = DEX_1_S.Text;
                sForm.DEX2.Text = DEX_2_S.Text;
                sForm.DEX3.Text = DEX_3_S.Text;
                sForm.DEX4.Text = DEX_4_S.Text;
                sForm.DEX5.Text = DEX_5_S.Text;
                sForm.SEN1.Text = SEN_1_S.Text;
                sForm.SEN2.Text = SEN_2_S.Text;
                sForm.SEN3.Text = SEN_3_S.Text;
                sForm.SEN4.Text = SEN_4_S.Text;
                sForm.SEN5.Text = SEN_5_S.Text;
                sForm.SEN6.Text = SEN_6_S.Text;
                sForm.SEN7.Text = SEN_7_S.Text;
                sForm.SEN8.Text = SEN_8_S.Text;
                sForm.SEN9.Text = SEN_9_S.Text;
                sForm.SEN10.Text = SEN_10_S.Text;
                sForm.SEN11.Text = SEN_11_S.Text;
                sForm.SEN12.Text = SEN_12_S.Text;
                sForm.Weapon1Name.Text = Weapon1Name.Text;
                sForm.Weapon1Skill.Text = Weapon1Skill.Text;
                sForm.Weapon1Dnum.Text = Weapon1Dnum.Text;
                sForm.Weapon1Type.Text = Weapon1Type.Text;
                sForm.Weapon1Range.Text = Weapon1Range.Text;
                sForm.Weapon2Name.Text = Weapon2Name.Text;
                sForm.Weapon2Skill.Text = Weapon2Skill.Text;
                sForm.Weapon2Dnum.Text = Weapon2Dnum.Text;
                sForm.Weapon2Type.Text = Weapon2Type.Text;
                sForm.Weapon2Range.Text = Weapon2Range.Text;
                sForm.Weapon3Name.Text = Weapon3Name.Text;
                sForm.Weapon3Skill.Text = Weapon3Skill.Text;
                sForm.Weapon3Dnum.Text = Weapon3Dnum.Text;
                sForm.Weapon3Type.Text = Weapon3Type.Text;
                sForm.Weapon3Range.Text = Weapon3Range.Text;
                sForm.Armor1Name.Text = Armor1Name.Text;
                sForm.Armor1Type.Text = Armor1Type.Text;
                sForm.Armor1Rate.Text = Armor1Rate.Text;
                sForm.Armor2Name.Text = Armor2Name.Text;
                sForm.Armor2Type.Text = Armor2Type.Text;
                sForm.Armor2Rate.Text = Armor2Rate.Text;
                sForm.EquipmentItem.Text = EquipmentItem.Text;
                sForm.Credit.Text = Credit.Text;
                if (passFile)
                {
                    switch (MutantSkills.SelectedIndex)
                    {
                        case 0: sForm.MutantSkills.Text = "アドレナリン調整"; break;
                        case 1: sForm.MutantSkills.Text = "魅了"; break;
                        case 2: sForm.MutantSkills.Text = "閾下侵入"; break;
                        case 3: sForm.MutantSkills.Text = "電撃"; break;
                        case 4: sForm.MutantSkills.Text = "感応"; break;
                        case 5: sForm.MutantSkills.Text = "エナジーフィールド"; break;
                        case 6: sForm.MutantSkills.Text = "超感覚"; break;
                        case 7: sForm.MutantSkills.Text = "浮遊"; break;
                        case 8: sForm.MutantSkills.Text = "機械感応"; break;
                        case 9: sForm.MutantSkills.Text = "悪食"; break;
                        case 10: sForm.MutantSkills.Text = "メンタルブラスト"; break;
                        case 11: sForm.MutantSkills.Text = "形状変化"; break;
                        case 12: sForm.MutantSkills.Text = "予知能力"; break;
                        case 13: sForm.MutantSkills.Text = "パイロキネシス"; break;
                        case 14: sForm.MutantSkills.Text = "テレキネシス"; break;
                        case 15: sForm.MutantSkills.Text = "テレポート"; break;
                    }
                    switch (SecretSociety.SelectedIndex)
                    {
                        case 0: sForm.SecretSociety.Text = "コープ・メタリカ"; break;
                        case 1: sForm.SecretSociety.Text = "シエラ・クラブ"; break;
                        case 2: sForm.SecretSociety.Text = "ロマンティクス"; break;
                        case 3: sForm.SecretSociety.Text = "P.U.R.G.E."; break;
                        case 4: sForm.SecretSociety.Text = "ミスティック"; break;
                        case 5: sForm.SecretSociety.Text = "プロ・テック"; break;
                        case 6: sForm.SecretSociety.Text = "サイオン"; break;
                        case 7: sForm.SecretSociety.Text = "イルミナティ"; break;
                        case 8: sForm.SecretSociety.Text = "FCCCP"; break;
                        case 9: sForm.SecretSociety.Text = "フリー・エンタープライズ"; break;
                        case 10: sForm.SecretSociety.Text = "ユマニスト"; break;
                        case 11: sForm.SecretSociety.Text = "フランケンシュタイン・デストロイヤー"; break;
                        case 12: sForm.SecretSociety.Text = "他のアルファコンプレックスからの密偵"; break;
                        case 13: sForm.SecretSociety.Text = "デス・パレード"; break;
                        case 14: sForm.SecretSociety.Text = "反ミュータント"; break;
                        case 15: sForm.SecretSociety.Text = "コンピュータ狂信者"; break;
                        case 16: sForm.SecretSociety.Text = "共産主義者"; break;
                    }
                    sForm.SecretSocietyRank.Text = SecretSocietyRank.Text;
                    sForm.etc.Text = etc.Text;
                }
                if (passFile != true)
                {
                    sForm.MutantSkills.Text = "表示するにはPassファイルを読み込んでください。";
                    sForm.SecretSociety.Text = "表示するにはPassファイルを読み込んでください。";
                    sForm.SecretSocietyRank.Text = "表示するにはPassファイルを読み込んでください。";
                    sForm.etc.Text = "表示するにはPassファイルを読み込んでください。";
                }
            }
        }//StatusFormLoadここまで

        private void MBD_SelectedIndexChanged(object sender, EventArgs e)
        {
            StatusFormLoad();
        }

        private void SecurityClearance_SelectedIndexChanged(object sender, EventArgs e)
        {
            StatusFormLoad();
        }

        private void MutantSkills_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (passFile)
                StatusFormLoad();
        }

        private void SecretSociety_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (passFile)
                StatusFormLoad();
        }
        
    }
}
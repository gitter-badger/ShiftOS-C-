﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShiftOS
{
    public partial class HackUI : Form
    {
        public HackUI()
        {
            InitializeComponent();
            ThisEnemyHacker = new EnemyHacker("Test Dummy", "A test hacker", "A test hacker", 1, 1, "easy");
        }

        public event EventHandler OnWin;

        public HackUI(EnemyHacker enemy)
        {
            ThisEnemyHacker = enemy;
            InitializeComponent();
        }

        public Computer ThisPlayerPC = null;
        private decimal TotalPlayerHP = 0;
        private EnemyHacker EnemyNet = null;

        private List<Module> MyNetwork = new List<Module>();

        #region PLAYER

        private void LoadPlayerScreen()
        {
            AntiVirusBounds = new List<Rectangle>();
            var tc = new Module(SystemType.Core, 1, "localhost");
            tc.HP = 100;
            TutorialNetwork.Add(tc);
            foreach (var m in GetMyNet())
            {
                if (m.Type == SystemType.Core)
                {
                    MyNetwork.Add(m);
                }
            }
            VisualizePlayerNetwork();
            if (EnemyNet != null)
            {
                tmrplayerhealthdetect.Start();
            }
            else
            {
                tmrplayerhealthdetect.Start();
            }
            if (IsTutorial)
            {
                SetupTutorialUI(0);
            }
        }

        private void VisualizePlayerNetwork()
        {
            AllPlayerComputers = new List<Computer>();
            foreach (Module m in MyNetwork)
            {
                if (AllPlayerComputers.Count <= 10)
                {
                    var c = m.Deploy();
                    if (c.Type == SystemType.Core)
                    {
                        ThisPlayerPC = c;
                    }
                    AddModule(c);
                }
            }
            if(ThisPlayerPC == null)
            {
                var m = new Module(SystemType.Core, 1, "localhost");
                GetMyNet().Add(m);
                MyNetwork.Add(m);
                var c = m.Deploy();
                ThisPlayerPC = c;
                AddModule(c);
            }
        }
        
        public List<Computer> AllPlayerComputers = null;

        private void tmrplayerhealthdetect_Tick(object sender, EventArgs e)
        {
            if(ThisPlayerPC != null)
            {
                ThisPlayerPC.Left = (pnlyou.Width - ThisPlayerPC.Width) / 2;
                ThisPlayerPC.Top = (pnlyou.Height - ThisPlayerPC.Height) / 2;

            }
            var rnd = new Random();
            int chance = 0;
            foreach (var pc in AllPlayerComputers)
            {
                if (pc.Disabled == false)
                {
                    if (pc.Enemies != null)
                    {
                        foreach (var enemy in pc.Enemies)
                        {
                            if (AllEnemyComputers.Contains(enemy))
                            {
                                chance = rnd.Next(1, 15);
                                if (chance == 7)
                                {
                                    if (IsTutorial)
                                    {
                                        if (TutorialProgress == 32 || TutorialProgress == 9)
                                        {
                                            enemy.LaunchAttack(pc.GetProperType(), pc.GetDamageRate());
                                        }
                                    }
                                    else
                                    {
                                        enemy.LaunchAttack(pc.GetProperType(), pc.GetDamageRate());
                                    }
                                }
                            }
                        }
                    }
                }
            }
            decimal health = 0;
            foreach (var pc in AllPlayerComputers)
            {
                health += (decimal)pc.HP;
            }
            if (health > TotalPlayerHP)
            {
                TotalPlayerHP = health;
            }
            try
            {
                decimal percent = (health / TotalPlayerHP) * 100;
                lbstats.Text = $"System Health: {percent}%";
            }
            catch
            {

            }
                if (ThisPlayerPC.HP <= 0)
            {
                API.CreateInfoboxSession("System compromised.", "The enemy hacker has overthrown your defenses and compromised your system. You will need to wait an hour before you can start another hack battle.", infobox.InfoboxMode.Info);
                Hacking.Failure = true;
                Hacking.FailDate = DateTime.Now;
                UserRequestedClose = false;
                this.Close();
            }
        }

        public bool UserRequestedClose = true;

        private void this_Closing(object sender, FormClosingEventArgs e)
        {
            if (UserRequestedClose == false)
            {
                arc.Dispose();
                Computer[] pcs = { };
                AllPlayerComputers.CopyTo(pcs);
                foreach(var pc in pcs)
                {
                    pc.Dispose();
                }
                tmrplayerhealthdetect.Stop();
                Hacking.RepairTimer.Start(); //Now the player can repair.
            }
            else
            {
                e.Cancel = true;
            }
        }

        public Computer SelectedPlayerComputer = null;

        public void AddModule(Computer newModule)
        {
            pnlyou.Controls.Add(newModule);
            int hp = newModule.HP;
            WriteLine($"[Network] Welcome to the network, {newModule.Hostname}!");
            TotalPlayerHP += newModule.HP;
            AllPlayerComputers.Add(newModule);
            newModule.Show();
            newModule.OnDestruction += (object s, EventArgs a) =>
            {
                if (this.SelectedPlayerComputer == newModule)
                {
                    SelectedPlayerComputer = null;
                }
                if (newModule.Type == SystemType.Firewall)
                {
                    Player_Firewall_Destroy(newModule);
                }
                AllPlayerComputers.Remove(newModule);
                newModule.Dispose();
                WriteLine($"[Network] {newModule.Hostname} has gone OFFLINE.");
            };
            newModule.Select += (object s, EventArgs e) =>
            {
                SelectedPlayerComputer = newModule;
                ShowPCInfo(newModule.Hostname);
                if (IsTutorial)
                {
                    if (TutorialProgress == 6)
                    {
                        if (newModule == ThisPlayerPC)
                        {
                            SetupTutorialUI(7);
                        }
                    }
                }
            };
            newModule.HP_Decreased += new EventHandler(Player_System_Damaged);
            newModule.OnRepair += new EventHandler(Player_System_Repaired);
            if (newModule.Type == SystemType.Antivirus || newModule.Type == SystemType.RepairModule)
            {
                var b = newModule.GetAreaOfEffect();
                AntiVirusBounds.Add(b);
                pnlyou.Refresh();
                newModule.AntivirusRepair += (object s, EventArgs a) =>
                {
                    foreach (Computer pc in AllPlayerComputers)
                    {
                        if (pc != newModule && pc.Bounds.IntersectsWith(b))
                        {
                            if (newModule.Type == SystemType.RepairModule)
                            {
                                if (pc.HP < newModule.HP)
                                {
                                    if (pc.HP < pc.GetTotal())
                                    {
                                        WriteLine($"[{newModule.Hostname}] Repairing neighbouring system \"{pc.Hostname}\"");
                                        pc.Repair(1);
                                    }
                                }

                            }
                            else
                            {
                                if (pc.HP < 10)
                                {
                                    WriteLine($"[{newModule.Hostname}] Repairing neighbouring system \"{pc.Hostname}\"");
                                    pc.Repair(1);
                                }
                            }
                        }
                    }
                };

            }
            if (newModule.Type == SystemType.Firewall)
            {
                var b = newModule.GetAreaOfEffect();
                AntiVirusBounds.Add(b);
                pnlenemy.Refresh();
                Player_Firewall_Deflect(newModule);
            }
            if (newModule.Type == SystemType.ServerStack)
            {
                newModule.MassDDoS += (object s, EventArgs a) =>
                {
                    WormToEnemy();
                };
            }
        }

        public void WormToEnemy()
        {
            var rnd = new Random();
            int r = rnd.Next(0, 10);
            WriteLine("[Network] Launching distributed denial-of-service attack on rival network.");
            foreach (Computer c in AllEnemyComputers)
            {
                if (r == 5)
                {
                    c.Disable();
                }
            }
        }

        public void ShowPCInfo(string hostname)
        {
            Module mod = null;
            foreach (var m in GetMyNet())
            {
                if (m.Hostname == hostname)
                {
                    mod = m;
                }
            }
            if (mod != null)
            {
                pnlpcinfo.Left = 7;
                pnlpcinfo.Show();
                lbmoduletitle.Text = "Module Info - " + hostname;
                lbpcinfo.Text = $"Hostname: {hostname}{Environment.NewLine}Type: {mod.Type.ToString()}";
                if (mod.Type == SystemType.Core)
                {
                    lbpcinfo.Text += Environment.NewLine + "This represents your main system. If this module is destroyed, you will automatically lose the battle. Protect it at all costs.";
                    btnupgrade.Hide();
                    btnpoweroff.Hide();
                }
                else
                {
                    lbpcinfo.Text += $"{Environment.NewLine}Grade: {mod.Grade}";
                    if (mod.Grade < 4)
                    {
                        btnupgrade.Show();
                    }
                    else
                    {
                        btnupgrade.Hide();
                    }
                    btnpoweroff.Show();
                }
            }
            Computer c = null;
            foreach (var pc in AllPlayerComputers)
            {
                if (pc.Hostname == hostname)
                {
                    c = pc;
                }
            }
            if (c != null)
            {
                lbtargets.Text = "Targets: ";
                if (c.Enemies != null)
                {
                    if (c.Enemies.Count > 0)
                    {
                        foreach (var pc in c.Enemies)
                        {
                            lbtargets.Text += " " + pc.Hostname + ",";
                        }
                    }
                    else
                    {
                        lbtargets.Text += " - Click on an enemy module to target it.";
                    }
                }
                else
                {
                    lbtargets.Text += " - Click on an enemy module to target it.";
                }
                lbtargets.Text += Environment.NewLine + "Some modules will not fire at their targets.";
            }
        }

        public void Player_Firewall_Deflect(Computer fwall)
        {
            //Safegaurd...
            if (fwall.Type == SystemType.Firewall)
            {
                var r = fwall.GetAreaOfEffect();
                foreach (var pc in AllPlayerComputers)
                {
                    if (pc != fwall)
                    {
                        if (pc.Bounds.IntersectsWith(r))
                        {
                            pc.DamageDefector = fwall.Grade;
                        }
                    }
                }
            }
        }

        public void Player_Firewall_Destroy(Computer fwall)
        {
            //Safegaurd...
            if (fwall.Type == SystemType.Firewall)
            {
                var r = fwall.GetAreaOfEffect();
                foreach (var pc in AllPlayerComputers)
                {
                    if (pc.Bounds.IntersectsWith(r))
                    {
                        pc.DamageDefector = 1;
                        UpdatePlayerFirewalls();
                    }
                }
            }
        }

        public void UpdatePlayerFirewalls()
        {
            foreach (var pc in AllPlayerComputers)
            {
                if (pc.Type == SystemType.Firewall)
                {
                    Player_Firewall_Deflect(pc);
                }
            }
        }


        private void Player_System_Repaired(object s, EventArgs e)
        {
            var c = (Computer)s;
            WriteLine($"[{c.Hostname}] System repaired.");
            lbcompromised.Text = "System regenerating...";
            int location = c.Left - (lbcompromised.Width / 4);
            int y = c.Top - 25;
            lbcompromised.Location = new Point(location, y);
            lbcompromised.Show();
            c.Flash(lbcompromised);

        }


        private void Player_System_Damaged(object s, EventArgs e)
        {
            var c = (Computer)s;
            WriteLine($"[{c.Hostname}] System damaged. Total HP: {c.HP}");
            lbcompromised.Text = "System damaged!";
            int location = c.Left - (lbcompromised.Width / 4);
            int y = c.Top - 25;
            lbcompromised.Location = new Point(location, y);
            lbcompromised.Show();
            c.Flash(lbcompromised);
        }

        private void btnaddmodule_Click(object sender, EventArgs e)
        {
            SetupModuleList();
            pnldefensemanager.Left = 7;
            pnldefensemanager.Visible = !pnldefensemanager.Visible;
            if (IsTutorial)
            {
                if (TutorialProgress == 12)
                {
                    SetupTutorialUI(13);
                }
            }
        }

        private Dictionary<string, SystemType> FutureModules = null;
        public List<Module> TutorialNetwork = new List<Module>();

        public void SetupModuleList()
        {
            FutureModules = new Dictionary<string, SystemType>();
            cmbmodules.Items.Clear();
            List<Module> net = null;
            if (IsTutorial)
            {
                net = TutorialNetwork;
            }
            else
            {
                net = Hacking.MyNetwork;
            }
            foreach (var item in net)
            {
                Computer m = null;
                foreach (var mod in AllPlayerComputers)
                {
                    if (mod.Hostname == item.Hostname)
                    {
                        m = mod;
                    }
                }
                if (m == null)
                {
                    if (item.HP > 0)
                    {
                        cmbmodules.Items.Add(item.Hostname);
                        FutureModules.Add(item.Hostname, item.Type);
                    }
                }
            }

        }

        bool PlacingNewModule = false;


        private void button1_Click_1(object sender, EventArgs e)
        {
            if (cmbmodules.Text != "")
            {
                PlacingNewModule = true;
                pnldefensemanager.Hide();
                if (IsTutorial)
                {
                    if (TutorialProgress == 20)
                    {
                        SetupTutorialUI(21);
                    }
                }
            }
        }

        private void playfield_MouseDown(object sender, MouseEventArgs e)
        {
            if (PlacingNewModule == true)
            {
                if (e.Button == MouseButtons.Left)
                {
                    if (AllPlayerComputers.Count < 10)
                    {
                        bool cont = true;
                        try
                        {
                            SystemType type = FutureModules[cmbmodules.Text];
                        }
                        catch (Exception ex)
                        {
                            cont = false;
                            API.CreateInfoboxSession("Error", "Please select a module type.", infobox.InfoboxMode.Info);
                        }
                        if (cont == true)
                        {
                            var coordinates = pnlyou.PointToClient(Cursor.Position);
                            int x = coordinates.X;
                            int y = coordinates.Y;

                            var m = new Module(FutureModules[cmbmodules.Text], 1, cmbmodules.Text);
                            foreach (var mod in GetMyNet())
                            {
                                if (mod.Hostname == cmbmodules.Text)
                                {
                                    m = mod;
                                }
                            }
                            m.X = x;
                            m.Y = y;
                            var c = m.Deploy();
                            AddModule(c);
                            API.RemoveCodepoints(10);
                            pnldefensemanager.Hide();
                            if (IsTutorial)
                            {
                                if (TutorialProgress == 21)
                                {
                                    SetupTutorialUI(22);
                                }
                                else if (TutorialProgress == 25)
                                {
                                    SetupTutorialUI(26);
                                }
                            }
                        }
                        PlacingNewModule = false;
                    }
                    else
                    {
                        API.CreateInfoboxSession("Too much deployed modules", "You can have a maximum of 10 modules deployed on your network, including your main system. You will have to wait for one to be destroyed.", infobox.InfoboxMode.Info);
                        PlacingNewModule = false;
                    }
                }
                else
                {
                    PlacingNewModule = false;
                }
            }
        }

        public List<FutureModule> BuyableModules = null;

        public void SetupBuyable()
        {
            if (!IsTutorial)
            {
                BuyableModules = Hacking.GetFutureModules();
            }
            cmbbuyable.Items.Clear();
            foreach (var m in BuyableModules)
            {
                cmbbuyable.Items.Add(m.Name);
            }
            lbmoduleinfo.Text = "";
            txtgrade.Text = "1";
        }

        private void btnbuy_Click(object sender, EventArgs e)
        {
            if (IsTutorial)
            {
                if (TutorialProgress == 14)
                {
                    SetupTutorialUI(15);
                }
            }
            SetupBuyable();
            pnlbuy.Show();
            pnldefensemanager.Hide();
        }

        public List<Rectangle> AntiVirusBounds = null;
        public List<Rectangle> IndicatorsToDestroy = new List<Rectangle>();
        private void boundpaint(object sender, PaintEventArgs e)
        {
            foreach (Rectangle r in IndicatorsToDestroy)
            {
                AntiVirusBounds.Remove(r);
                var sb = new SolidBrush(Color.Black);
                var p = new Pen(sb);
                p.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
                p.Width = 2;
                e.Graphics.DrawRectangle(p, r);

            }
            IndicatorsToDestroy.Clear();
            foreach (Rectangle r in AntiVirusBounds)
            {
                IndicatorsToDestroy.Add(r);
                tmrredraw.Start();
                var sb = new SolidBrush(Color.White);
                var p = new Pen(sb);
                p.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                p.Width = 2;
                e.Graphics.DrawRectangle(p, r);
            }
        }

        private void tmrredraw_Tick(object sender, EventArgs e)
        {
            pnlyou.Refresh();
            tmrredraw.Stop();
        }

        private void SetupModuleInfo()
        {
            bool cont = false;
            FutureModule m = null;
            foreach (var mod in BuyableModules)
            {
                if (mod.Name == cmbbuyable.Text)
                {
                    m = mod;
                    cont = true;
                }
            }
            if (cont == true)
            {
                lbmoduleinfo.Text = m.Name;
                lbmoduleinfo.Text += Environment.NewLine + $"Cost: {m.Cost * Convert.ToInt32(txtgrade.Text)} CP";
                lbmoduleinfo.Text += Environment.NewLine + $"Description: {Environment.NewLine}{m.Description}";
            }
        }

        private void cmbbuyable_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetupModuleInfo();
            if (IsTutorial)
            {
                if (TutorialProgress == 17)
                {
                    if (cmbbuyable.Text == "Antivirus")
                    {
                        SetupTutorialUI(18);
                    }
                }
            }
        }

        private void txtgrade_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int g = Convert.ToInt32(txtgrade.Text);
                if (g < 1)
                {
                    txtgrade.Text = "1";
                }
                else if (g > 4)
                {
                    txtgrade.Text = "4";
                }
                SetupModuleInfo();
            }
            catch (Exception ex)
            {
                txtgrade.Text = "1";
                SetupModuleInfo();
            }
        }

        public List<Module> GetMyNet()
        {
            if (IsTutorial)
            {
                return TutorialNetwork;
            }
            else
            {
                return Hacking.MyNetwork;
            }
        }

        private void btndonebuying_Click(object sender, EventArgs e)
        {
            var mod = new FutureModule("", 0, "", SystemType.Core);
            bool cont = false;
            foreach (var m in BuyableModules)
            {
                if (m.Name == cmbbuyable.Text)
                {
                    mod = m;
                    cont = true;
                }
            }
            if (cont == true)
            {
                if (API.Codepoints >= mod.Cost)
                {
                    if (txthostname.Text != "")
                    {
                        bool cont2 = true;
                        string hname = txthostname.Text.Replace(" ", "_");
                        foreach (var pc in GetMyNet())
                        {
                            if (pc.Hostname == hname)
                            {
                                cont2 = false;
                            }
                        }
                        if (cont2 == true)
                        {
                            var newModule = new Module(mod.Type, Convert.ToInt32(txtgrade.Text), hname);
                            newModule.HP = newModule.GetTotalHP();
                            GetMyNet().Add(newModule);
                            API.RemoveCodepoints(mod.Cost);
                            API.CreateInfoboxSession("Module added.", "To deploy the module to the network, select 'Add Module' and choose the hostname from the menu.", infobox.InfoboxMode.Info);
                            pnlbuy.Hide();
                            if (IsTutorial)
                            {
                                if (TutorialProgress == 19)
                                {
                                    SetupTutorialUI(20);
                                }
                                else if (TutorialProgress == 24)
                                {
                                    SetupTutorialUI(25);
                                }
                            }
                        }
                        else
                        {
                            API.CreateInfoboxSession("Please enter a unique hostname.", "No two computers can share the same hostname. Please choose another.", infobox.InfoboxMode.Info);
                        }
                    }
                    else
                    {
                        API.CreateInfoboxSession("Please enter a hostname.", "It is best to enter a hostname for your new computer so you know which one it is.", infobox.InfoboxMode.Info);
                    }

                }
                else
                {
                    API.CreateInfoboxSession("Insufficient Codepoints", "You do not have enough Codepoints to buy this module.", infobox.InfoboxMode.Info);
                }
            }
        }

        private void btncloseinfo_Click(object sender, EventArgs e)
        {
            SelectedPlayerComputer = null;
            pnlpcinfo.Hide();
            Hacking.SaveCharacters();
        }

        private void btnpoweroff_Click(object sender, EventArgs e)
        {
            //Remove the computer from the game.
            pnlyou.Controls.Remove(SelectedPlayerComputer);
            AllPlayerComputers.Remove(SelectedPlayerComputer);
            btnpoweroff.Hide();
        }

        private void btnupgrade_Click(object sender, EventArgs e)
        {
            int price = 20 * SelectedPlayerComputer.Grade;
            if (API.Codepoints >= price)
            {
                foreach (var m in GetMyNet())
                {
                    if (m.Hostname == SelectedPlayerComputer.Hostname)
                    {
                        SelectedPlayerComputer.Grade += 1;
                        m.Grade += 1;
                        Hacking.SaveCharacters();
                        API.CreateInfoboxSession("Upgrade successful.", "Your module has been upgraded.", infobox.InfoboxMode.Info);
                    }
                }
            }
            else
            {
                API.CreateInfoboxSession("Insufficient funds", $"You need at least {price} CP to upgrade this module.", infobox.InfoboxMode.Info);
            }
            ShowPCInfo(SelectedPlayerComputer.Hostname);
        }

        public int TutorialProgress = 0;
        public bool IsTutorial = false;

        public void SetupTutorialUI(int p)
        {
            TutorialProgress = p;
            lbtutorial.Show();
            pnltutorial.Show();
            pnltutorial.Left = (this.Width - pnltutorial.Width) / 2;
            pnltutorial.Top = (this.Height - pnltutorial.Height) / 2;
            switch (p)
            {
                case 0:
                    lbtutorial.Text = "Welcome to the Hacker Battle tutorial. This guide will teach you the fundamentals and basics of taking part in a Hacker Battle. When you're done here, you'll be able to start up a network and start dominating others' networks.";
                    btnaddmodule.Hide();
                    btnnext.Show();
                    break;
                case 1:
                    lbtutorial.Text = "Let's go over the user interface. It's quite simple, actually. There are 4 different displays on your screen. One for your network, one for your console, and same for the enemy.";
                    break;
                case 2:
                    lbtutorial.Text = "On the left side is your console and playfield. Your console will log all the actions that happen on your network. Your Playfield is a visual representation of your network. Each square represents a different module. Most of your actions will take place in the Playfield.";
                    break;
                case 3:
                    lbtutorial.Text = "On the right is the enemy's console and playfield. Both playfields will show the HP (health) of each module, and the total network HP.";
                    break;
                case 4:
                    lbtutorial.Text = "If the enemy's total network health hits 0%, or his core's strength hits 0%, you win.";
                    break;
                case 5:
                    lbtutorial.Text = "However, if the same happens to you, you will lose the battle, and won't be able to fight back until your Core heals.";
                    break;
                case 6:
                    lbtutorial.Text = "Each network has one core. It is represented by the square in the centre of the playfield. Click on your Core to view information about it.";
                    btnnext.Hide();
                    break;
                case 7:
                    lbtutorial.Text = "When you click on a module, you can see information about it, such as it's grade level, HP, and type. This module is a Core, so it has no grade level. It currently has 100 HP.";
                    btnnext.Show();
                    break;
                case 8:
                    lbtutorial.Text = "When a module is selected you can left-click an enemy module to target it. This will make the selected module attempt to fire at the target. Cores are very weak, but are capable of bringing a target down by 1 HP.";
                    break;
                case 9:
                    lbtutorial.Text = "The enemy Core is attacking your Core now. Looks like it's time to fight back. Select your core, and target the enemy's Core to fight back.";
                    btnnext.Hide();
                    break;
                case 10:
                    lbtutorial.Text = "Phew! He couldn't do much damage before we fought back. In a real battle, modules won't just stop fighting randomly, but for the purpose of this tutorial, your Core will stop attacking the enemy Core.";
                    btnnext.Show();
                    ThisPlayerPC.Enemies.Clear();
                    break;
                case 11:
                    lbtutorial.Text = "Should your Core fall to a fatal state in the future, you can deploy some defenses to slow the enemy down. Any hacker knows it's best to disable defenses before attacking the main target.";
                    ThisPlayerPC.HP = 5;
                    break;
                case 12:
                    lbtutorial.Text = "We will look at ways of healing damaged modules now. You can add new modules to the network by clicking the [Add Module] button in the lower-left corner.";
                    btnaddmodule.Show();
                    btnnext.Hide();
                    break;
                case 13:
                    btnbuy.Hide();
                    lbtutorial.Text = "You can select a module from the list of hostnames. Only modules that are not powered on will display in the menu.";
                    btnnext.Show();
                    BuyableModules = new List<FutureModule>();
                    BuyableModules.Add(new FutureModule("Antivirus", 0, "This module will heal any other module within it's area of effect to 10 HP. Higher grades can improve it's area of effect.", SystemType.Antivirus));
                    break;
                case 14:
                    btnbuy.Show();
                    lbtutorial.Text = "In this demonstration, you have no other modules to deploy. You will need to buy some modules to get started. Click [Buy New Module] to continue.";
                    btnnext.Hide();
                    break;
                case 15:
                    cmbbuyable.Enabled = false;
                    lbtutorial.Text = "Let's go over the user interface, shall we? At the top is a list of all possible module types.";
                    btnnext.Show();
                    btndonebuying.Hide();
                    lbgrade.Hide();
                    txtgrade.Hide();
                    txthostname.Hide();
                    lbhostname.Hide();
                    lbmoduleinfo.Hide();
                    break;
                case 16:
                    lbtutorial.Text = "Below that, is the cost and description of the selected module type. It's invisible right now, but when you select a new module, it will populate.";
                    lbmoduleinfo.Show();
                    break;
                case 17:
                    cmbbuyable.Enabled = true;
                    lbtutorial.Text = "We need an Antivirus module, so go ahead and select it from the menu.";
                    btnnext.Hide();
                    break;
                case 18:
                    lbtutorial.Text = "Normally, an Antivirus would cost us 15 Codepoints, however since this is a tutorial, it is free.";
                    btnnext.Show();
                    break;
                case 19:
                    lbtutorial.Text = "Below the description is the Hostname box. A Hostname is used to identify the new module. Pick something you'll remember as this new Antivirus, then click [Buy] to purchase it.";
                    btnnext.Hide();
                    lbhostname.Show();
                    txthostname.Show();
                    btndonebuying.Show();
                    break;
                case 20:
                    btnnext.Hide();
                    lbtutorial.Text = "Now that we have an antivirus module, go ahead and deploy it by selecting [Add Module], choosing the hostname you entered, and clicking [Done].";
                    break;
                case 21:
                    btnnext.Hide();
                    lbtutorial.Text = "Alrighty. Now you get to choose where you place your module. Simply left-click in a blank area where you'd like to place the module. Right-click to cancel. Oh, be sure to place close to our Core!";
                    break;
                case 22:
                    lbtutorial.Text = "The Antivirus has been placed. You may've noticed that white dotted box around it when you placed it. If the Core is even slightly within the box, the Antivirus will heal it back to 10 HP.";
                    btnnext.Show();
                    break;
                case 23:
                    lbtutorial.Text = "The higher the Antivirus' grade, the bigger this area of effect becomes. However, it will always only be able to heal modules to 10 HP.";
                    break;
                case 24:
                    lbtutorial.Text = "A Turret has been added to the list of buyable modules. Go pick one up!";
                    btnnext.Hide();
                    BuyableModules.Clear();
                    BuyableModules.Add(new FutureModule("Turret", 0, "It's not super-effective, but the Turret will blast through any Grade 1 defenses pretty quickly. The higher the grade, the higher the strength.", SystemType.Turret));
                    break;
                case 25:
                    lbtutorial.Text = "Turrets can fire damaging viruses at their targets. Go ahead and place your Turret somewhere within the Antivirus's Area of Effect.";
                    break;
                case 26:
                    lbtutorial.Text = "Notice how the Turret only has 10 HP, just like the Antivirus?";
                    btnnext.Show();
                    break;
                case 27:
                    lbtutorial.Text = "This is because both the Antivirus and Turret are at Grade 1. There are four grades of modules you can get, and you can easily upgrade by selecting a module and choosing [Upgrade This Module].";
                    break;
                case 28:
                    lbtutorial.Text = "Upgrading a module will increase it's max HP. Grade 1 is 10 HP, Grade 2 is 20 HP, Grade 3 is 40 HP, and Grade 4 is 80 HP.";
                    break;
                case 29:
                    lbtutorial.Text = "Some modules will have a higher attack rate based on their grade. Others may throw more damaging attacks, and any module's Area of Effect (if it has one) will grow.";
                    break;
                case 30:
                    lbtutorial.Text = "Another tip: Multiple modules can target the same module, and a module can have multiple targets. This means that you can have your Core and your Turret both attack the enemy Core.";
                    break;
                case 31:
                    lbtutorial.Text = "Some modules do not work on a target-based system. Some may work using an area-of-effect system (like an Antivirus), and some may target the entire enemy network.";
                    break;
                case 32:
                    pnltutorial.Left = this.Width - pnltutorial.Width;
                    pnltutorial.Top = this.Height - flcontrols.Height - pnltutorial.Height;
                    lbtutorial.Text = "We have reset both your Cores' health. Go ahead and finish off the enemy Core using your newfound skills.";
                    ThisPlayerPC.HP = 100;
                    ThisEnemyPC.HP = 100;
                    btnnext.Hide();
                    BuyableModules = new List<FutureModule>();
                    BuyableModules.Add(new FutureModule("Antivirus", 0, "This module will heal any other module within it's area of effect to 10 HP. Higher grades can improve it's area of effect.", SystemType.Antivirus));
                    BuyableModules.Add(new FutureModule("Turret", 0, "It's not super-effective, but the Turret will blast through any Grade 1 defenses pretty quickly. The higher the grade, the higher the strength.", SystemType.Turret));
                    break;
                default:
                    btnnext.Show();
                    lbtutorial.Text = "This concludes the Hacker Battle tutorial. Happy hunting, soldier. Just kidding. Stay safe.";
                    btnnext.Text = "Close";
                    break;
            }
        }

        private void btnnext_Click(object sender, EventArgs e)
        {
            if (btnnext.Text == "Close")
            {
                UserRequestedClose = false;
                this.Close();
            }
            SetupTutorialUI(TutorialProgress + 1);
        }

        #endregion

        private void HackUI_Load(object sender, EventArgs e)
        {
            Hacking.RepairTimer.Stop(); //Don't want the player to be able to repair dead modules during a battle!
            this.TopMost = true;
            arc = new AudioResourceClient("HackerBattle");
            arc.SongFinished += (object s, EventArgs a) =>
            {
                arc.PlayRandom();
            };
            arc.PlayRandom();
            this.WindowState = FormWindowState.Maximized;
            //this.TopMost = true;
            LoadPlayerScreen();
            LoadEnemyScreen();
        }

        #region ENEMY
        private EnemyHacker ThisEnemyHacker { get; set; }
        public List<Computer> AllEnemyComputers = null;
        public Computer ThisEnemyPC { get; set; }
        private void LoadEnemyScreen()
        {
            AllEnemyComputers = new List<Computer>();
            VisualizeEnemyNetwork();
            tmrenemyhealthdetect.Start();
            ThisEnemyPC.Enemy = true;
        }

        private void VisualizeEnemyNetwork()
        {
            var rnd = new Random();
            foreach (Module m in ThisEnemyHacker.Network)
            {
                m.HP = m.GetTotalHP();
                var c = m.Deploy();
                if (c.Type == SystemType.Core)
                {
                    ThisEnemyPC = c;
                    ThisEnemyPC.EnemyComputer = ThisPlayerPC;
                    ThisPlayerPC.EnemyComputer = ThisEnemyPC;
                }
                AddEnemyModule(c);
                c.Location = new Point(m.X, m.Y);
            }
        }

        public void Enemy_System_Attacking(object s, EventArgs a)
        {
            int i = new Random().Next(AllPlayerComputers.Count);
            var pc = AllPlayerComputers[i];
            var se = (Computer)s;
            pc.LaunchAttack(se.GetProperType());
        }

        public Computer SelectedEnemyComputer = null;

        public void AddEnemyModule(Computer newModule)
        {
            if(newModule.Type == SystemType.Core)
            {
                newModule.Left = (pnlenemy.Width - newModule.Width) / 2;
                newModule.Top = (pnlenemy.Height - newModule.Height) / 2;
            }
            var rnd = new Random();
            pnlenemy.Controls.Add(newModule);
            foreach (var pc in AllEnemyComputers)
            {
                while (newModule.Bounds.IntersectsWith(pc.Bounds))
                {
                    newModule.Location = new Point(rnd.Next(100, 350), rnd.Next(100, 350));
                }
            }
            AllEnemyComputers.Add(newModule);
            int hp = newModule.HP;
            TotalEnemyHP += (decimal)newModule.HP;
            newModule.Show();
            newModule.OnDestruction += (object s, EventArgs a) =>
            {
                if (this.SelectedEnemyComputer == newModule)
                {
                    SelectedEnemyComputer = null;
                }
                WriteLine_Enemy($"[Network] {newModule.Hostname} has gone OFFLINE.");
                AllEnemyComputers.Remove(newModule);
                newModule.Dispose();
            };
            newModule.Select += (object s, EventArgs a) =>
            {
                bool c = true;
                foreach (var pc in SelectedPlayerComputer.Enemies)
                {
                    if (pc.Hostname == newModule.Hostname)
                    {
                        c = false;
                    }
                }
                if (c == true)
                {
                    SelectedPlayerComputer.Enemies.Add(newModule);
                    ShowPCInfo(SelectedPlayerComputer.Hostname);
                    if (IsTutorial)
                    {
                        if (TutorialProgress == 9)
                        {
                            SetupTutorialUI(10);
                        }
                    }
                    WriteLine_Enemy("[Network] WARNING! Rival system has targeted a system on this network!");
                    WriteLine($"[Network] System \"{SelectedPlayerComputer.Hostname}\" is now targeting rival system \"{newModule.Hostname}\".");
                }
            };
            newModule.HP_Decreased += new EventHandler(Enemy_System_Damaged);
            newModule.OnRepair += new EventHandler(Enemy_System_Repaired);
            if (newModule.Type == SystemType.Antivirus)
            {
                var b = newModule.GetAreaOfEffect();
                newModule.AntivirusRepair += (object s, EventArgs a) =>
                {
                    foreach (Computer pc in AllEnemyComputers)
                    {
                        if (pc != newModule && pc.Bounds.IntersectsWith(b))
                        {
                            if (newModule.Type == SystemType.RepairModule)
                            {
                                if (pc.HP < newModule.HP)
                                {
                                    if (pc.HP < pc.GetTotal())
                                    {
                                        WriteLine_Enemy($"[{newModule.Hostname}] Repairing neighbouring system \"{pc.Hostname}\"...");
                                        pc.Repair(1);
                                    }
                                }

                            }
                            else
                            {
                                if (pc.HP < 10)
                                {
                                    pc.Repair(1);
                                }
                            }
                        }
                    }
                };
            }
            if (newModule.Type == SystemType.Firewall)
            {
                pnlenemy.Refresh();
                Enemy_Firewall_Deflect(newModule);
            }
            if (newModule.Type == SystemType.ServerStack)
            {
                newModule.MassDDoS += (object s, EventArgs a) =>
                {
                    WormToPlayer();
                };
            }
        }

        public void Enemy_Firewall_Deflect(Computer fwall)
        {
            //Safeguard... also apparently I can't spell... because this used to be 'Safegaurd'...
            if (fwall.Type == SystemType.Firewall)
            {
                var r = fwall.GetAreaOfEffect();
                foreach (var pc in AllEnemyComputers)
                {
                    if (pc != fwall)
                    {
                        if (pc.Bounds.IntersectsWith(r))
                        {
                            pc.DamageDefector = fwall.Grade;
                        }
                    }
                }
            }
        }

        public void Enemy_Firewall_Destroy(Computer fwall)
        {
            //Safegaurd...
            if (fwall.Type == SystemType.Firewall)
            {
                var r = fwall.GetAreaOfEffect();
                foreach (var pc in AllEnemyComputers)
                {
                    if (pc.Bounds.IntersectsWith(r))
                    {
                        pc.DamageDefector = 1;
                        UpdateEnemyFirewalls();
                    }
                }
            }
        }

        public void UpdateEnemyFirewalls()
        {
            foreach (var pc in AllEnemyComputers)
            {
                if (pc.Type == SystemType.Firewall)
                {
                    Enemy_Firewall_Deflect(pc);
                }
            }
        }


        private void Enemy_System_Repaired(object s, EventArgs e)
        {
            var c = (Computer)s;
            WriteLine_Enemy($"[{c.Hostname}] System repaired.");
            lbenemycompromised.Text = "System regenerating...";
            int location = c.Left - (lbenemycompromised.Width / 4);
            int y = c.Top - 25;
            lbenemycompromised.Location = new Point(location, y);
            lbenemycompromised.Show();
            c.Flash(lbenemycompromised);

        }


        private void Enemy_System_Damaged(object s, EventArgs e)
        {
            var c = (Computer)s;
            WriteLine_Enemy($"[{c.Hostname}] System damaged. Current HP: {c.HP}");
            WriteLine($"[Network] Damaged system on rival network with hostname \"{c.Hostname}\"");
            lbenemycompromised.Text = "System damaged!";
            int location = c.Left - (lbenemycompromised.Width / 4);
            int y = c.Top - 25;
            lbenemycompromised.Location = new Point(location, y);
            lbenemycompromised.Show();
            c.Flash(lbenemycompromised);
        }

        private decimal TotalEnemyHP = 0;

        private void tmrenemyhealthdetect_Tick(object sender, EventArgs e)
        {
            lbsong.Visible = Audio.Enabled;
            btntogglemusic.Visible = Audio.Enabled;

            if(arc != null)
            {
                lbsong.Text = $"Ross Bugden - {arc.CurrentSong}";
            }

            decimal health = 0;
            lbcodepoints.Text = $"Codepoints: {API.Codepoints}";
            var rnd = new Random();
            int chance = 0;
            foreach (var pc in AllEnemyComputers)
            {
                if (pc.Disabled == false)
                {
                    foreach (var enemy in AllPlayerComputers)
                    {
                        chance = rnd.Next(1, 20);
                        if (chance == 10)
                        {
                            if (IsTutorial)
                            {
                                if (TutorialProgress == 9)
                                {
                                    ThisPlayerPC.LaunchAttack(pc.GetProperType(), pc.GetDamageRate());
                                }
                                else if (TutorialProgress == 32)
                                {
                                    enemy.LaunchAttack(pc.GetProperType(), pc.GetDamageRate());
                                }
                                else
                                {
                                    enemy.Enemies.Clear();
                                }
                            }
                            else
                            {
                                enemy.LaunchAttack(pc.GetProperType(), pc.GetDamageRate());
                            }
                        }
                    }
                }
            }

            foreach (var pc in AllEnemyComputers)
            {
                health += (decimal)pc.HP;
            }
            try
            {
                decimal percent = (health / TotalEnemyHP) * 100;
                lbenemystats.Text = $"Enemy Health: {percent}%";
                if (ThisEnemyPC.HP <= 0)
                {
                    if (IsTutorial)
                    {
                        SetupTutorialUI(33);
                    }
                    else
                    {
                        string message = "You have successfully beaten the enemy hacker.";
                        if (ThisEnemyHacker.IsLeader == false)
                        {
                            switch(rnd.Next(0, 5))
                            {
                                case 1:
                                    API.AddCodepoints(1000);
                                    message = "You have beaten the enemy. You have earned some precious Codepoints for your effort!";
                                    break;
                                case 2:
                                    message = "You have beaten the enemy. As a reward, all Shiftorium Upgrades cost half-price.";
                                    Hacking.GiveHack(Hack.PriceDrop);
                                    break;
                                case 3:
                                    message = "You have beaten the enemy. As a reward, applications will now pay out more Codepoints than usual.";
                                    Hacking.GiveHack(Hack.PayoutIncrease);
                                    break;
                                case 4:
                                    message = "The enemy has recognized your skill and has decided to become a friend. You can now hire them for free as a partner during a system hack.";
                                    //befriend the enemy.
                                    var skill = ThisEnemyHacker.FriendSkill;
                                    var speed = ThisEnemyHacker.FriendSpeed;
                                    var desc = ThisEnemyHacker.FriendDesc;
                                    var name = ThisEnemyHacker.Name;
                                    Hacking.AddCharacter(new Character(name, desc, skill, speed, 0));
                                    break;
                                default:
                                    message = "You have successfully beaten the enemy hacker.";
                                    break;
                            }
                        }
                        API.CreateInfoboxSession("You won.", message, infobox.InfoboxMode.Info);

                        UserRequestedClose = false;
                        var h = OnWin;
                        if(h != null)
                        {
                            h(this, new EventArgs());
                        }
                        this.Close();
                    }
                }
            }
            catch
            {

            }
        }

        public void WormToPlayer()
        {
            var rnd = new Random();
            int r = rnd.Next(0, 10);
            WriteLine_Enemy("[NETWORK] Launching distributed denial-of-service attack on rival network...");
            foreach (Computer c in AllPlayerComputers)
            {
                if (r == 5)
                {
                    c.Disable();
                }
            }
        }
        
        public void WriteLine_Enemy(string text)
        {
            if(txtenemyconsole.Text.Length == 0)
            {
                txtenemyconsole.Text = text + Environment.NewLine;
            }
            else
            {
                txtenemyconsole.Text += text + Environment.NewLine;
            }
            txtenemyconsole.Select(txtenemyconsole.TextLength, 0);
            txtenemyconsole.ScrollToCaret();
        }

        public void WriteLine(string text)
        {
            if (txtyourconsole.Text.Length == 0)
            {
                txtyourconsole.Text = text + Environment.NewLine;
            }
            else
            {
                txtyourconsole.Text += text + Environment.NewLine;
            }
            txtyourconsole.Select(txtyourconsole.TextLength, 0);
            txtyourconsole.ScrollToCaret();
        }

        #endregion

        AudioResourceClient arc = null;
        bool musicenabled = true;

        private void button2_Click(object sender, EventArgs e)
        {
            arc.Pause();
        }

        
    }
}

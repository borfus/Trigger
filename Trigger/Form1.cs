using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trigger
{
    public partial class Form1 : Form
    {
        int offsetLocalPlayer;
        int offsetEntityList;
        int offsetCrosshairID;
        int offsetTeam;
        int offsetHealth;
        int offsetAttack;
        int offsetEntityLoopDist;

        int client;
        string process = "csgo";

        bool enabled = false;

        VAMemory VAM;

        public Form1()
        {
            InitializeComponent();
            VAM = new VAMemory(process);
        }

        private void btnEnable_MouseClick(object sender, MouseEventArgs e)
        {
            if (!enabled)
            {
                if (GetModuleAddress())
                {
                    enabled = true;
                    btnEnabled.Text = "Disable";
                    prgFiring.Value = 100;
                    backgroundWorker1.RunWorkerAsync();
                }
                else
                {
                    MessageBox.Show("Something went wrong. Try connecting to a game before enabling.", "Error");
                }
            }
            else
            {
                if (!backgroundWorker1.IsBusy)
                {
                    backgroundWorker1.CancelAsync();
                }
                enabled = false;
                btnEnabled.Text = "Enable";
                prgFiring.Value = 0;
            }
            this.ActiveControl = null;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            int forceAttack = client + offsetAttack;
            int localPlayer = VAM.ReadInt32((IntPtr)(client + offsetLocalPlayer));
            int myTeam = VAM.ReadInt32((IntPtr)(localPlayer + offsetTeam));
            int PICPointer;
            int PICHealth;
            int PICTeam;
            int playerInCrosshair;

            while (true && enabled)
            {
                playerInCrosshair = VAM.ReadInt32((IntPtr)(localPlayer + offsetCrosshairID));
                if (playerInCrosshair > 0 && playerInCrosshair < 65)
                {
                    PICPointer = VAM.ReadInt32((IntPtr)(client + offsetEntityList + (playerInCrosshair - 1) * offsetEntityLoopDist));
                    PICHealth = VAM.ReadInt32((IntPtr)(PICPointer + offsetHealth));
                    PICTeam = VAM.ReadInt32((IntPtr)(PICPointer + offsetTeam));

                    if ((PICTeam != myTeam) && (PICTeam > 1) && (PICHealth > 0))
                    {
                        MethodInvoker mi = delegate ()
                        {
                            prgFiring.ForeColor = Color.Green;
                        };
                        this.Invoke(mi);
                        VAM.WriteInt32((IntPtr)forceAttack, 5);
                        Thread.Sleep(1);
                        VAM.WriteInt32((IntPtr)forceAttack, 4);
                    }
                    Thread.Sleep(10);
                }

                if (prgFiring.ForeColor != Color.Red)
                {
                    MethodInvoker mi = delegate ()
                    {
                        prgFiring.ForeColor = Color.Red;
                    };
                    this.Invoke(mi);
                }
            }
        }

        private bool GetModuleAddress()
        {
            try
            {
                Process[] processes = Process.GetProcessesByName(process);

                if (processes.Length > 0)
                {
                    foreach (ProcessModule m in processes[0].Modules)
                    {
                        if (m.ModuleName == "Module Name")
                        {
                            client = (int)m.BaseAddress;
                            return true;
                        }
                    }
                    return false;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}

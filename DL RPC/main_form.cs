using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using DL_RPC.Properties;
using System.Threading;

namespace DL_RPC
{
    public partial class main_form : Form
    {
        private bool started = false;
        public main_form()
        {
            InitializeComponent();
        }

        private void langtoolchecks()
        {
            switch (Settings.Default.language)
            {
                case "pl":
                    polskiToolStripMenuItem.Checked = true;
                    日本語ToolStripMenuItem.Checked = false;
                    englishToolStripMenuItem.Checked = false;
                    break;
                case "ja":
                    polskiToolStripMenuItem.Checked = false;
                    日本語ToolStripMenuItem.Checked = true;
                    englishToolStripMenuItem.Checked = false;
                    break;
                case "en":
                    polskiToolStripMenuItem.Checked = false;
                    日本語ToolStripMenuItem.Checked = false;
                    englishToolStripMenuItem.Checked = true;
                    break;
            }
        }

        private void main_form_Load(object sender, EventArgs e)
        {
            this.Icon = Resources.dlrpc;
            functions.ChangeLanguage(Settings.Default.language);
            languageToolStripMenuItem.Text = functions.GetString("string_language");
            waitingLabel.Text = functions.GetString("waiting_string");
            hidecheckbox.Text = functions.GetString("hide_string");
            hidecheckbox.Checked = Settings.Default.hide;
            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            bool isGameOpen = false;

            while (true)
            {
                if(functions.isGameOpen() == false)
                {
                    started = false;
                    if(functions.client.IsInitialized)
                        functions.client.ClearPresence();
                    isGameOpen = false;
                    updateUI(isGameOpen, functions.currentMap, functions.playerCount);
                }
                else
                {
                    if (started == false) {
                        if(functions.updatethread.IsAlive == true){
                            functions.updatethread.Abort();
                        }                                                 
                        if (functions.readthread.IsAlive == true){
                            functions.readthread.Abort();
                        }                        
                        if (functions.client.IsInitialized == true){
                            functions.client.ClearPresence();
                            functions.client.Deinitialize();
                            functions.client.Dispose();
                            functions.client = null;
                        }
                        functions.start(); 
                        started = true;
                    }
                    isGameOpen = true;
                    updateUI(isGameOpen, functions.currentMap, functions.playerCount);
                }
                Thread.Sleep(1000);
            }
        }

        private void updateUI(bool gameOpen, functions.map map, int playerCount)
        {
            this.Invoke(new Action(delegate ()
            {
                if (hidecheckbox.Checked && gameOpen == true)
                    this.Hide();
                else
                    this.Show();
            }));

            mapNameDisplay.Invoke(new Action(delegate ()
            {
                mapNameDisplay.Text = functions.GetString(map.ToString());
                if (gameOpen) { mapNameDisplay.Visible = true; }
                else { mapNameDisplay.Visible = false; }
            }));

            playerCountDisplay.Invoke(new Action(delegate ()
            {
                if (gameOpen) { playerCountDisplay.Visible = true; }
                else { playerCountDisplay.Visible = false; }

                if (functions.currentMap == functions.map.slums_btz_tutorial || functions.currentMap == functions.map.none)
                {
                    playerCountDisplay.Visible = false;
                }
                else if (functions.playerCount == 1)
                {
                    playerCountDisplay.Text = functions.GetString("playing_singleplayer");
                    playerCountDisplay.Visible = true;
                }
                else
                {
                    playerCountDisplay.Text = functions.GetString("playing_coop").Replace("{x}", Convert.ToString(playerCount));
                    playerCountDisplay.Visible = true;
                }
            }));

            mapIcon.Invoke(new Action(delegate () {
                if (gameOpen) { mapIcon.Visible = true; }
                else { mapIcon.Visible = false; }
            }));

            waitingLabel.Invoke(new Action(delegate () {
                if (gameOpen) { waitingLabel.Visible = false; }
                else { waitingLabel.Visible = true; }
            }));

            switch (map)
            {
                case functions.map.none:
                    mapIcon.Image = Resources.custom;
                    break;
                case functions.map.slums:
                    mapIcon.Image = Resources.slums;
                    break;
                case functions.map.old_town:
                    mapIcon.Image = Resources.old_town;
                    break;
                case functions.map.countryside:
                    mapIcon.Image = Resources.countryside;
                    break;
                case functions.map.hellraid:
                    mapIcon.Image = Resources.hellraid;
                    break;
                case functions.map.prison:
                    mapIcon.Image = Resources.prison;
                    break;
                case functions.map.stadium:
                    mapIcon.Image = Resources.stadium;
                    break;
                case functions.map.slums_btz_tutorial:
                    mapIcon.Image = Resources.slums_btz_tutorial;
                    break;
                case functions.map.custom:
                    mapIcon.Image = Resources.custom;
                    break;
            }
        }

        private void main_form_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void polskiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings.Default.language = "pl";
            Settings.Default.Save();
            functions.ChangeLanguage(Settings.Default.language);
            langtoolchecks();
        }

        private void 日本語ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings.Default.language = "ja";
            Settings.Default.Save();
            functions.ChangeLanguage(Settings.Default.language);
            langtoolchecks();
        }

        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings.Default.language = "en";
            Settings.Default.Save();
            functions.ChangeLanguage(Settings.Default.language);
            langtoolchecks();
        }

        private void languageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            langtoolchecks();
        }

        private void hidecheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (hidecheckbox.Checked)
                Settings.Default.hide = true;
            else
                Settings.Default.hide = false;

            Settings.Default.Save();
        }
    }
}

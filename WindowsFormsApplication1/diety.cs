using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Diety.classes;
using Diety.helpers;
using Diety.Properties;

namespace Diety
{
    public partial class Game : Helpers
    {
        
        public Game()
        {
            spel = this;
            Ticks = 0;
            InitializeComponent();
            pnlActies.Hide();
            pnlTech.Hide();
            pnlTijd.Hide();
            pnlMenu.BackColor = Color.FromArgb(0, 0, 0, 0);
            GeloofNaam.BackColor = Color.FromArgb(0, 0, 0, 0);
            GeloofNaam.Text = "";
            Gewonnen = false;
            Fullscreen(); 
        }

        private void pnlViewPaint(object sender, PaintEventArgs e)
        {
            if (MijnGeloof != null)
            {

                Parallel.ForEach(MijnGeloof.Volgers, (v) =>
                {
                    lock (e)
                    {
                        e.Graphics.DrawImage(v.Visual.Picture.Image, v.Visual.Picture.Location);
                        e.Graphics.FillRectangle(new SolidBrush(Color.Red), v.Visual.Hp);
                        e.Graphics.DrawRectangle(new Pen(Color.Black, 2), new Rectangle(v.Visual.Hp.Location, new Size(40, 10)));
                        e.Graphics.FillRectangle(new SolidBrush(Color.Green), v.Visual.Honger);
                        e.Graphics.DrawRectangle(new Pen(Color.Black, 2), new Rectangle(v.Visual.Honger.Location, new Size(40, 10)));
                        e.Graphics.FillRectangle(new SolidBrush(Color.Blue), v.Visual.Gelovigheid);
                        e.Graphics.DrawRectangle(new Pen(Color.Black, 2), new Rectangle(v.Visual.Gelovigheid.Location, new Size(40, 10)));
                        e.Graphics.DrawImage(Resources.iconfood, new Point( v.Visual.Honger.Location.X -16 , v.Visual.Honger.Location.Y-2) );
                        e.Graphics.DrawImage(Resources.iconprayer, new Point(v.Visual.Gelovigheid.Location.X - 16, v.Visual.Gelovigheid.Location.Y - 2));
                        e.Graphics.DrawString(v.Visual.NaamVisueel.Text, new Font(FontFamily.GenericMonospace, 10), new SolidBrush(Color.Black),
                            v.Visual.NaamVisueel.Location);
                    }
                });

            }
            
        }

        private void Fullscreen()
        {
            WindowState = FormWindowState.Normal;
            FormBorderStyle = FormBorderStyle.None;
            Bounds = Screen.PrimaryScreen.Bounds;
        }

        private void RemoveText(object sender, EventArgs e)
        {
            tbxGeloof.Text = "";
        }

       #region update
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!Gewonnen)
            {
                UpdateGeloof();
                UpdateImages();
                TijdVerstreken += 1;
            }
        }

        void UpdateGeloof()
        {
            if (MijnGeloof.GetGrondstof(Enums.Grondstoffen.Gebeden) >= 100)
            {
                tbxEvents.SelectionStart = tbxEvents.TextLength;
                tbxEvents.SelectionLength = 0;
                tbxEvents.SelectionColor = Color.Green;
                tbxEvents.AppendText("Gewonnen uw geloof heeft "+ TijdVerstreken+ " dagen overleeft met "+ MijnGeloof.Volgers.Count(x => x.Levend) + " gelovigen!" + Resources.enter);
                tbxEvents.SelectionColor = tbxEvents.ForeColor;
                tbxEvents.ScrollToCaret();
                Gewonnen = true;
                UpdateTimer.Stop();
            }
            if (MijnGeloof == null) { return; }
            MijnGeloof.Volgers = UpdateVolgers(MijnGeloof.Volgers);
            UpdateLabels(MijnGeloof, true);
            UpdateTech(MijnGeloof.GetGrondstof(Enums.Grondstoffen.XP));
            UpdatePowers();
            pnlView.Refresh();
        }

        private void UpdateTech(int xp)
        {
            if (xp >= 5 && !pnlTech.Visible)
            {
                pnlTech.Show();
            }
            if (xp >= 10)
            {
                foreach (var t in MijnGeloof.Technologieen)
                {
                    var actief = t.getActiefNiveau();
                    if (actief == null){continue;}
                    if (actief.XPNodig <= xp && !t.Visual.Toegevoegd)
                    {

                        t.Beschikbaar = true;
                        t.Visual.Toegevoegd = true;
                        pnlTech.Controls.Add(t.Visual.btn);
                        UpdateEvents(new List<string>(), "Technologie beschikbaar : " + actief.Naam, Color.DarkGreen);
                    }
                    if (actief.XPNodig <= xp && t.Visual.btn.Enabled == false)
                        t.Visual.btn.Enabled = true;
                }
            }
            var techmessages = "";
            foreach (var t in MijnGeloof.Technologieen.Where(x=>x.Beschikbaar = true))
            {
                var niveau = t.getActiefNiveau();
                if (niveau != null)
                {
                    if (niveau.Progress == niveau.Onderzoekslengte)
                    {
                        techmessages += niveau.Complete();
                        var volgendniveau = t.GetVolgendNiveau();
                        niveau.Active = false;
                        if (volgendniveau != null)
                        {
                            volgendniveau.Active = true;
                            t.Setbutton();
                            t.Visual.btn.BackColor = Color.LightGray;
                            if (volgendniveau.XPNodig > xp)
                                t.Visual.btn.Enabled = false;
                        }
                        else
                        {
                            pnlTech.Controls.Remove(t.Visual.btn);
                        }
                    }
                }
            }
            if (techmessages != "")
            {
                UpdateEvents(new List<string>(), techmessages  );
            }
        }

        void UpdateGeloofTick(object sender, EventArgs e)
        {
            if (Ticks % 10 != 0 && !Gewonnen)
            {
                UpdateImages();
                Ticks += 1;
            }
            else
            {
                if (!Gewonnen)
                {
                    UpdateImages();
                    UpdateGeloof();
                    TijdVerstreken += 1;
                    Ticks += 1;
                }
            }
        }

        private void UpdateImages()
        {
            foreach (var volger in MijnGeloof.Volgers)
            {
               volger.NextImage(ImageTimer);
            }
            pnlView.Refresh();
            ImageTimer = (ImageTimer + 1) % 4;
        }

        public void UpdateLabels(Geloof mijnGeloof, bool vooruit)
        {
            AantalVolgers.Text = mijnGeloof.Volgers.Where(x=>x.Levend).ToList().Count.ToString();
            GeloofNaam.Text = string.IsNullOrWhiteSpace(tbxGeloof.Text) ? mijnGeloof.Naam : tbxGeloof.Text;
            Voedsel.Text = mijnGeloof.GetGrondstof(Enums.Grondstoffen.Voedsel).ToString();
            Gebeden.Text = mijnGeloof.GetGrondstof(Enums.Grondstoffen.Gebeden).ToString();
            VoedselMaximum.Text = "/ " + mijnGeloof.GetGrondstof(Enums.Grondstoffen.MaxVoedsel);
            if (vooruit)
            {
                Tijd.Text = TijdVerstreken + "";
                if (mijnGeloof.Volgers.Where(x => x.Levend).ToList().Count <= 0)
                {
                    UpdateTimer.Stop();
                    tbxEvents.SelectionStart = tbxEvents.TextLength;
                    tbxEvents.SelectionLength = 0;
                    tbxEvents.SelectionColor = Color.Red;
                    tbxEvents.AppendText( GeloofNaam.Text + " is uitgestorven na " + (TijdVerstreken) + " Dagen"  + Resources.enter);
                    tbxEvents.SelectionColor = tbxEvents.ForeColor;
                    tbxEvents.ScrollToCaret();
                    Gewonnen = true;
                    UpdateTimer.Stop();
                   
                }
            }
        }

        private void UpdatePowers()
        {
            foreach (var p in MijnGeloof.Powers.Where(x => (x.Beschikbaar || x.UnlockWaarde< MijnGeloof.GetGrondstof(Enums.Grondstoffen.Gebeden)) && !x.Visual.Toegevoegd))
            {
                p.Visual.Toegevoegd = true;
                pnlActies.Controls.Add(p.Visual.btn);
            }

        }

        private List<Volger> UpdateVolgers(List<Volger> volgers)
        {
            var messages = new ConcurrentBag<string> { "-------DAG " + TijdVerstreken + " ---------" + Resources.enter };
            foreach (var message in volgers.Where(x => x.Levend).Select(volger => volger.VoerActieUit()).Where(message => message != ""))
            {
                messages.Add(message);
            }
            foreach( var volger  in volgers)
            {
                if (volger.Levend)
                {
                    var message = volger.Update();
                    if (message != "")
                        messages.Add(message);
                }
            };
           
            
            //volgers = volgers.Where(x => x.Levend).ToList();
            UpdateEvents(messages.Reverse() , "");
            
            return volgers;
        }

        public void UpdateEvents(IEnumerable<string> messages , string Techmessage , Color color = default(Color))
        {
            if (color.Name == "0")
                color =Color.Green;
            if (messages != null && messages.Any() )
            {
                tbxEvents.AppendText( string.Join(Environment.NewLine, messages) + Resources.enter);
            }

            tbxEvents.SelectionStart = tbxEvents.TextLength;
            tbxEvents.SelectionLength = 0;
            tbxEvents.SelectionColor = color;
            tbxEvents.AppendText(Techmessage + Resources.enter);
            tbxEvents.SelectionColor = tbxEvents.ForeColor;
            tbxEvents.AppendText(Resources.enter);
            tbxEvents.ScrollToCaret();
        }

        #endregion

        private void btnStart_Click(object sender, EventArgs e)
        {
            UpdateTimer = new Timer();
            TijdVerstreken = 0;
            UpdateTimer.Interval = 200;
            UpdateTimer.Enabled = true;
            UpdateTimer.Tick += UpdateGeloofTick;
            MijnGeloof = new Geloof();
            UpdateLabels(MijnGeloof,true);
            pnlActies.Show();
            pnlTijd.Show();
            btnStart.Hide();
            tbxGeloof.Hide();
            UpdateTimer.Start();
            pnlView.Refresh();
            UpdatePowers();
        }

      

        private void btnPlayPause_Click(object sender, EventArgs e)
        {
            if (UpdateTimer != null)
            {
                if (UpdateTimer.Enabled)
                {
                    UpdateTimer.Stop();
                    btnPlayPause.Text = "Play";
                }
                else
                {
                    UpdateTimer.Start();
                    btnPlayPause.Text = "Pause";
                }
            }
        }
        private void btnStop_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btnSneller_Click(object sender, EventArgs e)
        {
           UpdateTimer.Interval = UpdateTimer.Interval > 500 ? UpdateTimer.Interval - 500 : 100;
        }
        private void btnTrager_Click(object sender, EventArgs e)
        {
            UpdateTimer.Interval += 500;
        }

        
    }
}

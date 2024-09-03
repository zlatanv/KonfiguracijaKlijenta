
namespace KonfiguracijaKlijenta
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.powerOptionsSwitch = new Telerik.WinControls.UI.RadToggleSwitch();
            this.lblPower = new Telerik.WinControls.UI.RadLabel();
            this.log = new Telerik.WinControls.UI.RadTextBoxControl();
            this.crystalDarkTheme1 = new Telerik.WinControls.Themes.CrystalDarkTheme();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.btnDodajOperatera = new Telerik.WinControls.UI.RadButton();
            this.btnPokreniUpdate = new Telerik.WinControls.UI.RadButton();
            this.remoteDesktopSwitch = new Telerik.WinControls.UI.RadToggleSwitch();
            this.btnKonfiguracijaNotifikacija = new Telerik.WinControls.UI.RadButton();
            this.btnJezikDatum = new Telerik.WinControls.UI.RadButton();
            this.btnTring = new Telerik.WinControls.UI.RadButton();
            this.btnAktivirajNetPlwiz = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.powerOptionsSwitch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPower)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.log)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDodajOperatera)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPokreniUpdate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.remoteDesktopSwitch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnKonfiguracijaNotifikacija)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnJezikDatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnTring)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAktivirajNetPlwiz)).BeginInit();
            this.SuspendLayout();
            // 
            // powerOptionsSwitch
            // 
            this.powerOptionsSwitch.Location = new System.Drawing.Point(143, 297);
            this.powerOptionsSwitch.Name = "powerOptionsSwitch";
            this.powerOptionsSwitch.Size = new System.Drawing.Size(67, 20);
            this.powerOptionsSwitch.TabIndex = 0;
            this.powerOptionsSwitch.ThemeName = "CrystalDark";
            this.powerOptionsSwitch.ValueChanged += new System.EventHandler(this.powerOptionsSwitch_ValueChanged);
            // 
            // lblPower
            // 
            this.lblPower.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPower.Location = new System.Drawing.Point(12, 297);
            this.lblPower.Name = "lblPower";
            this.lblPower.Size = new System.Drawing.Size(125, 20);
            this.lblPower.TabIndex = 1;
            this.lblPower.Text = "Power Always ON:";
            // 
            // log
            // 
            this.log.Dock = System.Windows.Forms.DockStyle.Right;
            this.log.IsReadOnly = true;
            this.log.Location = new System.Drawing.Point(553, 0);
            this.log.Multiline = true;
            this.log.Name = "log";
            this.log.Size = new System.Drawing.Size(369, 584);
            this.log.TabIndex = 2;
            this.log.ThemeName = "CrystalDark";
            // 
            // radLabel2
            // 
            this.radLabel2.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel2.Location = new System.Drawing.Point(12, 323);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(116, 20);
            this.radLabel2.TabIndex = 5;
            this.radLabel2.Text = "Remote Desktop:";
            // 
            // btnDodajOperatera
            // 
            this.btnDodajOperatera.Location = new System.Drawing.Point(12, 21);
            this.btnDodajOperatera.Name = "btnDodajOperatera";
            this.btnDodajOperatera.Size = new System.Drawing.Size(198, 24);
            this.btnDodajOperatera.TabIndex = 6;
            this.btnDodajOperatera.Text = "Dodaj Operater Account";
            this.btnDodajOperatera.ThemeName = "CrystalDark";
            this.btnDodajOperatera.Click += new System.EventHandler(this.btnDodajOperatera_Click);
            // 
            // btnPokreniUpdate
            // 
            this.btnPokreniUpdate.Location = new System.Drawing.Point(12, 51);
            this.btnPokreniUpdate.Name = "btnPokreniUpdate";
            this.btnPokreniUpdate.Size = new System.Drawing.Size(198, 24);
            this.btnPokreniUpdate.TabIndex = 7;
            this.btnPokreniUpdate.Text = "Pokreni Sve Update";
            this.btnPokreniUpdate.ThemeName = "CrystalDark";
            this.btnPokreniUpdate.Click += new System.EventHandler(this.btnPokreniUpdate_Click);
            // 
            // remoteDesktopSwitch
            // 
            this.remoteDesktopSwitch.Location = new System.Drawing.Point(143, 323);
            this.remoteDesktopSwitch.Name = "remoteDesktopSwitch";
            this.remoteDesktopSwitch.Size = new System.Drawing.Size(67, 20);
            this.remoteDesktopSwitch.TabIndex = 8;
            this.remoteDesktopSwitch.ThemeName = "CrystalDark";
            this.remoteDesktopSwitch.ValueChanged += new System.EventHandler(this.remoteDesktopSwitch_ValueChanged);
            // 
            // btnKonfiguracijaNotifikacija
            // 
            this.btnKonfiguracijaNotifikacija.Location = new System.Drawing.Point(12, 81);
            this.btnKonfiguracijaNotifikacija.Name = "btnKonfiguracijaNotifikacija";
            this.btnKonfiguracijaNotifikacija.Size = new System.Drawing.Size(198, 24);
            this.btnKonfiguracijaNotifikacija.TabIndex = 9;
            this.btnKonfiguracijaNotifikacija.Text = "Konfiguracija Notifikacija";
            this.btnKonfiguracijaNotifikacija.ThemeName = "CrystalDark";
            this.btnKonfiguracijaNotifikacija.Click += new System.EventHandler(this.btnKonfiguracijaNotifikacija_Click);
            // 
            // btnJezikDatum
            // 
            this.btnJezikDatum.Location = new System.Drawing.Point(12, 111);
            this.btnJezikDatum.Name = "btnJezikDatum";
            this.btnJezikDatum.Size = new System.Drawing.Size(198, 24);
            this.btnJezikDatum.TabIndex = 10;
            this.btnJezikDatum.Text = "Konfiguracija Jezika";
            this.btnJezikDatum.ThemeName = "CrystalDark";
            this.btnJezikDatum.Click += new System.EventHandler(this.btnJezikDatum_Click);
            // 
            // btnTring
            // 
            this.btnTring.Location = new System.Drawing.Point(12, 141);
            this.btnTring.Name = "btnTring";
            this.btnTring.Size = new System.Drawing.Size(198, 24);
            this.btnTring.TabIndex = 11;
            this.btnTring.Text = "Dodaj Tring Folder";
            this.btnTring.ThemeName = "CrystalDark";
            this.btnTring.Click += new System.EventHandler(this.btnTring_Click);
            // 
            // btnAktivirajNetPlwiz
            // 
            this.btnAktivirajNetPlwiz.Location = new System.Drawing.Point(12, 171);
            this.btnAktivirajNetPlwiz.Name = "btnAktivirajNetPlwiz";
            this.btnAktivirajNetPlwiz.Size = new System.Drawing.Size(198, 24);
            this.btnAktivirajNetPlwiz.TabIndex = 12;
            this.btnAktivirajNetPlwiz.Text = "Aktiviraj Netplwiz";
            this.btnAktivirajNetPlwiz.ThemeName = "CrystalDark";
            this.btnAktivirajNetPlwiz.Click += new System.EventHandler(this.btnAktivirajNetPlwiz_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(922, 584);
            this.Controls.Add(this.btnAktivirajNetPlwiz);
            this.Controls.Add(this.btnTring);
            this.Controls.Add(this.btnJezikDatum);
            this.Controls.Add(this.btnKonfiguracijaNotifikacija);
            this.Controls.Add(this.remoteDesktopSwitch);
            this.Controls.Add(this.btnPokreniUpdate);
            this.Controls.Add(this.btnDodajOperatera);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.log);
            this.Controls.Add(this.lblPower);
            this.Controls.Add(this.powerOptionsSwitch);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Konfiguracija";
            ((System.ComponentModel.ISupportInitialize)(this.powerOptionsSwitch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPower)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.log)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDodajOperatera)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPokreniUpdate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.remoteDesktopSwitch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnKonfiguracijaNotifikacija)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnJezikDatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnTring)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAktivirajNetPlwiz)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadToggleSwitch powerOptionsSwitch;
        private Telerik.WinControls.UI.RadLabel lblPower;
        private Telerik.WinControls.UI.RadTextBoxControl log;
        private Telerik.WinControls.Themes.CrystalDarkTheme crystalDarkTheme1;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadButton btnDodajOperatera;
        private Telerik.WinControls.UI.RadButton btnPokreniUpdate;
        private Telerik.WinControls.UI.RadToggleSwitch remoteDesktopSwitch;
        private Telerik.WinControls.UI.RadButton btnKonfiguracijaNotifikacija;
        private Telerik.WinControls.UI.RadButton btnJezikDatum;
        private Telerik.WinControls.UI.RadButton btnTring;
        private Telerik.WinControls.UI.RadButton btnAktivirajNetPlwiz;
    }
}


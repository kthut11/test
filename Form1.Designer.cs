namespace test
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.listView1 = new System.Windows.Forms.ListView();
            this.Dladen = new System.Windows.Forms.Button();
            this.ListeEinnahmen = new System.Windows.Forms.ListView();
            this.ListeAusgaben = new System.Windows.Forms.ListView();
            this.Einnahmentxt = new System.Windows.Forms.TextBox();
            this.Ausgaben = new System.Windows.Forms.TextBox();
            this.Dspeichern = new System.Windows.Forms.Button();
            this.zurücksetzen = new System.Windows.Forms.Button();
            this.löschen = new System.Windows.Forms.Button();
            this.GesamtsummeEinnahmenTextBox = new System.Windows.Forms.TextBox();
            this.GesamtsummeAusgabenTextBox = new System.Windows.Forms.TextBox();
            this.RestbetragTextBox = new System.Windows.Forms.TextBox();
            this.Eeintragen = new System.Windows.Forms.Button();
            this.Aeingeben = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Vermögen = new System.Windows.Forms.Label();
            this.Vermoegen = new System.Windows.Forms.TextBox();
            this.Gesamttxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(403, 458);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(720, 84);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // Dladen
            // 
            this.Dladen.Location = new System.Drawing.Point(68, 318);
            this.Dladen.Name = "Dladen";
            this.Dladen.Size = new System.Drawing.Size(110, 47);
            this.Dladen.TabIndex = 1;
            this.Dladen.Text = "Daten laden";
            this.Dladen.UseVisualStyleBackColor = true;
            this.Dladen.Click += new System.EventHandler(this.Dladen_Click);
            // 
            // ListeEinnahmen
            // 
            this.ListeEinnahmen.HideSelection = false;
            this.ListeEinnahmen.Location = new System.Drawing.Point(403, 54);
            this.ListeEinnahmen.Name = "ListeEinnahmen";
            this.ListeEinnahmen.Size = new System.Drawing.Size(346, 379);
            this.ListeEinnahmen.TabIndex = 2;
            this.ListeEinnahmen.UseCompatibleStateImageBehavior = false;
            this.ListeEinnahmen.View = System.Windows.Forms.View.Details;
            // 
            // ListeAusgaben
            // 
            this.ListeAusgaben.HideSelection = false;
            this.ListeAusgaben.Location = new System.Drawing.Point(777, 54);
            this.ListeAusgaben.Name = "ListeAusgaben";
            this.ListeAusgaben.Size = new System.Drawing.Size(346, 379);
            this.ListeAusgaben.TabIndex = 3;
            this.ListeAusgaben.UseCompatibleStateImageBehavior = false;
            this.ListeAusgaben.View = System.Windows.Forms.View.Details;
            this.ListeAusgaben.SelectedIndexChanged += new System.EventHandler(this.ListeAusgaben_SelectedIndexChanged);
            // 
            // Einnahmentxt
            // 
            this.Einnahmentxt.Location = new System.Drawing.Point(68, 84);
            this.Einnahmentxt.Name = "Einnahmentxt";
            this.Einnahmentxt.Size = new System.Drawing.Size(199, 22);
            this.Einnahmentxt.TabIndex = 4;
            // 
            // Ausgaben
            // 
            this.Ausgaben.Location = new System.Drawing.Point(68, 220);
            this.Ausgaben.Name = "Ausgaben";
            this.Ausgaben.Size = new System.Drawing.Size(199, 22);
            this.Ausgaben.TabIndex = 5;
            // 
            // Dspeichern
            // 
            this.Dspeichern.Location = new System.Drawing.Point(208, 318);
            this.Dspeichern.Name = "Dspeichern";
            this.Dspeichern.Size = new System.Drawing.Size(101, 47);
            this.Dspeichern.TabIndex = 6;
            this.Dspeichern.Text = "Daten speichern";
            this.Dspeichern.UseVisualStyleBackColor = true;
            this.Dspeichern.Click += new System.EventHandler(this.Dspeichern_Click);
            // 
            // zurücksetzen
            // 
            this.zurücksetzen.Location = new System.Drawing.Point(68, 386);
            this.zurücksetzen.Name = "zurücksetzen";
            this.zurücksetzen.Size = new System.Drawing.Size(110, 47);
            this.zurücksetzen.TabIndex = 7;
            this.zurücksetzen.Text = "zurücksetzen";
            this.zurücksetzen.UseVisualStyleBackColor = true;
            this.zurücksetzen.Click += new System.EventHandler(this.zurücksetzen_Click);
            // 
            // löschen
            // 
            this.löschen.Location = new System.Drawing.Point(208, 386);
            this.löschen.Name = "löschen";
            this.löschen.Size = new System.Drawing.Size(101, 47);
            this.löschen.TabIndex = 8;
            this.löschen.Text = "Zeile löschen";
            this.löschen.UseVisualStyleBackColor = true;
            this.löschen.Click += new System.EventHandler(this.löschen_Click);
            // 
            // GesamtsummeEinnahmenTextBox
            // 
            this.GesamtsummeEinnahmenTextBox.Location = new System.Drawing.Point(649, 411);
            this.GesamtsummeEinnahmenTextBox.Name = "GesamtsummeEinnahmenTextBox";
            this.GesamtsummeEinnahmenTextBox.Size = new System.Drawing.Size(100, 22);
            this.GesamtsummeEinnahmenTextBox.TabIndex = 9;
            this.GesamtsummeEinnahmenTextBox.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // GesamtsummeAusgabenTextBox
            // 
            this.GesamtsummeAusgabenTextBox.Location = new System.Drawing.Point(1023, 411);
            this.GesamtsummeAusgabenTextBox.Name = "GesamtsummeAusgabenTextBox";
            this.GesamtsummeAusgabenTextBox.Size = new System.Drawing.Size(100, 22);
            this.GesamtsummeAusgabenTextBox.TabIndex = 10;
            this.GesamtsummeAusgabenTextBox.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // RestbetragTextBox
            // 
            this.RestbetragTextBox.Location = new System.Drawing.Point(68, 476);
            this.RestbetragTextBox.Name = "RestbetragTextBox";
            this.RestbetragTextBox.Size = new System.Drawing.Size(131, 22);
            this.RestbetragTextBox.TabIndex = 11;
            // 
            // Eeintragen
            // 
            this.Eeintragen.Location = new System.Drawing.Point(68, 134);
            this.Eeintragen.Name = "Eeintragen";
            this.Eeintragen.Size = new System.Drawing.Size(199, 34);
            this.Eeintragen.TabIndex = 12;
            this.Eeintragen.Text = "Eingaben übernehmen";
            this.Eeintragen.UseVisualStyleBackColor = true;
            this.Eeintragen.Click += new System.EventHandler(this.Eeintragen_Click);
            // 
            // Aeingeben
            // 
            this.Aeingeben.Location = new System.Drawing.Point(68, 260);
            this.Aeingeben.Name = "Aeingeben";
            this.Aeingeben.Size = new System.Drawing.Size(199, 32);
            this.Aeingeben.TabIndex = 13;
            this.Aeingeben.Text = "Ausgaben übernehmen";
            this.Aeingeben.UseVisualStyleBackColor = true;
            this.Aeingeben.Click += new System.EventHandler(this.Aeingeben_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(71, 453);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 20);
            this.label1.TabIndex = 14;
            this.label1.Text = "aktueller Kontostand";
            // 
            // Vermögen
            // 
            this.Vermögen.AutoSize = true;
            this.Vermögen.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Vermögen.Location = new System.Drawing.Point(71, 510);
            this.Vermögen.Name = "Vermögen";
            this.Vermögen.Size = new System.Drawing.Size(85, 20);
            this.Vermögen.TabIndex = 15;
            this.Vermögen.Text = "Vermögen";
            this.Vermögen.Click += new System.EventHandler(this.Vermögen_Click);
            // 
            // Vermoegen
            // 
            this.Vermoegen.Location = new System.Drawing.Point(1003, 520);
            this.Vermoegen.Name = "Vermoegen";
            this.Vermoegen.Size = new System.Drawing.Size(120, 22);
            this.Vermoegen.TabIndex = 16;
            // 
            // Gesamttxt
            // 
            this.Gesamttxt.Location = new System.Drawing.Point(68, 533);
            this.Gesamttxt.Name = "Gesamttxt";
            this.Gesamttxt.Size = new System.Drawing.Size(131, 22);
            this.Gesamttxt.TabIndex = 17;
            this.Gesamttxt.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(64, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 20);
            this.label2.TabIndex = 18;
            this.label2.Text = "Eingaben";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(71, 197);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 20);
            this.label3.TabIndex = 19;
            this.label3.Text = "Ausgaben";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(663, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(205, 31);
            this.label4.TabIndex = 20;
            this.label4.Text = "Finanzüberblick";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1393, 615);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Gesamttxt);
            this.Controls.Add(this.Vermoegen);
            this.Controls.Add(this.Vermögen);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Aeingeben);
            this.Controls.Add(this.Eeintragen);
            this.Controls.Add(this.RestbetragTextBox);
            this.Controls.Add(this.GesamtsummeAusgabenTextBox);
            this.Controls.Add(this.GesamtsummeEinnahmenTextBox);
            this.Controls.Add(this.löschen);
            this.Controls.Add(this.zurücksetzen);
            this.Controls.Add(this.Dspeichern);
            this.Controls.Add(this.Ausgaben);
            this.Controls.Add(this.Einnahmentxt);
            this.Controls.Add(this.ListeAusgaben);
            this.Controls.Add(this.ListeEinnahmen);
            this.Controls.Add(this.Dladen);
            this.Controls.Add(this.listView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button Dladen;
        private System.Windows.Forms.ListView ListeEinnahmen;
        private System.Windows.Forms.ListView ListeAusgaben;
        private System.Windows.Forms.TextBox Einnahmentxt;
        private System.Windows.Forms.TextBox Ausgaben;
        private System.Windows.Forms.Button Dspeichern;
        private System.Windows.Forms.Button zurücksetzen;
        private System.Windows.Forms.Button löschen;
        private System.Windows.Forms.TextBox GesamtsummeEinnahmenTextBox;
        private System.Windows.Forms.TextBox GesamtsummeAusgabenTextBox;
        private System.Windows.Forms.TextBox RestbetragTextBox;
        private System.Windows.Forms.Button Eeintragen;
        private System.Windows.Forms.Button Aeingeben;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Vermögen;
        private System.Windows.Forms.TextBox Vermoegen;
        private System.Windows.Forms.TextBox Gesamttxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}


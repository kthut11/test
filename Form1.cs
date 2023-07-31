using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test
{
    public partial class Form1 : Form
    {

        decimal restbetrag = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        { 
             // Setze die Spaltenbreite für die ListeEinnahmen
            ListeEinnahmen.Columns.Add("Art", ListeEinnahmen.Width / 2 - 8, HorizontalAlignment.Left);
            ListeEinnahmen.Columns.Add("Betrag in Euro", ListeEinnahmen.Width / 2 - 8, HorizontalAlignment.Right);

            ListeAusgaben.Scrollable = true;

            // Setze die Spaltenbreite für die ListeAusgaben
            ListeAusgaben.Columns.Add("Art", ListeAusgaben.Width / 2 - 8, HorizontalAlignment.Left);
            ListeAusgaben.Columns.Add("Betrag in Euro", ListeAusgaben.Width / 2 - 8, HorizontalAlignment.Right);
        
            listView1.Columns.Add("Kreditkarte", listView1.Width / 8 - 8, HorizontalAlignment.Left);
            listView1.Columns.Add("Ledger", listView1.Width / 8 - 8, HorizontalAlignment.Left);
            listView1.Columns.Add("Trade Republic", listView1.Width / 8 - 8, HorizontalAlignment.Left);
            listView1.Columns.Add("Bausparvertrag1", listView1.Width / 8 - 8, HorizontalAlignment.Left);
            listView1.Columns.Add("Bausparvertrag2", listView1.Width / 8 - 8, HorizontalAlignment.Left);
            listView1.Columns.Add("Union Investment", listView1.Width / 8 - 8, HorizontalAlignment.Left);
            listView1.Columns.Add("Etoro       ", listView1.Width / 8 - 8, HorizontalAlignment.Left);
           

            // Spaltenbreite an Überschriften anpassen
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

        }

        // Methode, um zu prüfen, ob ein Name bereits in der Liste vorhanden ist
        private bool IstNameVorhanden(string name, ListView listView)
        {
            foreach (ListViewItem item in listView.Items)
            {
                if (item.SubItems[0].Text == name)
                {
                    return true;
                }
            }
            return false;
        }

        // Methode, um den Betrag zu einem vorhandenen Eintrag in der Liste hinzuzufügen
        private void BetragHinzufuegen(string name, decimal betrag, ListView listView)
        {
            foreach (ListViewItem item in listView.Items)
            {
                if (item.SubItems[0].Text == name)
                {
                    decimal vorhandenerBetrag;
                    if (decimal.TryParse(item.SubItems[1].Text, out vorhandenerBetrag))
                    {
                        item.SubItems[1].Text = (vorhandenerBetrag + betrag).ToString("N2");
                    }
                    break;
                }
            }
        }

        public void ImportiereZusatzlisteAusCSV(string csvDateiPfad)
        {
            try
            {
                if (File.Exists(csvDateiPfad))
                {
                    listView1.Items.Clear();

                    // Kultur mit Komma als Dezimaltrennzeichen erstellen
                    CultureInfo cultureInfo = new CultureInfo("de-DE");

                    using (var reader = new StreamReader(csvDateiPfad))
                    {
                        // Überschriftenzeile überspringen
                        reader.ReadLine();

                        // Zeile mit Zahlen einlesen
                        string line = reader.ReadLine();
                        string[] fields = line.Split(';');

                        // Füge die Zahlen in die listView1-Steuerung hinzu
                        ListViewItem zusatzItem = new ListViewItem(fields[4].Trim()); // Erste Spalte (Kreditkarte) hinzufügen

                        for (int i = 5; i < fields.Length; i++) // Starte bei Index 1, da Index 0 bereits hinzugefügt wurde
                        {
                            string trimmedField = fields[i].Trim();
                            zusatzItem.SubItems.Add(trimmedField);
                            // Entferne mögliche Tausendertrennzeichen und ersetze das Dezimaltrennzeichen durch einen Punkt
                            string cleanedValue = fields[i].Replace(".", "").Replace(",", ".").Trim();

                            // Prüfe, ob es sich um die Spalte "Kontostand" handelt (Index 11)
                            if (i == 11)
                            {
                                // Versuche den Wert in der "Kontostand"-Spalte in einen Dezimalwert umzuwandeln
                                if (decimal.TryParse(trimmedField, NumberStyles.Any, cultureInfo, out decimal csvKontostand))
                                {
                                    // Subtrahiere den Wert vom Restbetrag, da der Kontostand auf die Gesamtsumme addiert werden soll
                                    restbetrag -= csvKontostand;
                                }
                            }
                        }

                        listView1.Items.Add(zusatzItem);

                    }
                }

                // Aktualisiere die Anzeige des Restbetrags
                RestbetragTextBox.Text = restbetrag.ToString("N2");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fehler beim Importieren der Daten aus der CSV-Datei: " + ex.Message);
            }

            // Rufe die Methode UpdateGesamtsumme() auf, um die Gesamtsummen der Einnahmen und Ausgaben zu aktualisieren
            UpdateGesamtsumme();

        }

        public void ImportiereDatenAusCSV(string csvDateiPfad)
        {
            try
            {
                if (File.Exists(csvDateiPfad))
                {
                    ListeEinnahmen.Items.Clear();
                    ListeAusgaben.Items.Clear();

                    // Kultur mit Komma als Dezimaltrennzeichen erstellen
                    CultureInfo cultureInfo = new CultureInfo("de-DE");

                    using (var reader = new StreamReader(csvDateiPfad))
                    {
                        // Überschriftenzeile überspringen
                        reader.ReadLine();

                        while (!reader.EndOfStream)
                        {
                            string line = reader.ReadLine();
                            // Zeile mit Semikolonzeichen splitten
                            string[] fields = line.Split(';');

                            if (fields.Length >= 11) // Anpassen, wenn es weniger als 11 Spalten gibt
                            {
                                // Prüfe, ob die Zeile leere Felder enthält
                                bool isEmptyRow = true;
                                foreach (string field in fields)
                                {
                                    if (!string.IsNullOrEmpty(field.Trim()))
                                    {
                                        isEmptyRow = false;
                                        break;
                                    }
                                }

                                // Wenn die Zeile nicht leer ist, füge die Daten in die Listen hinzu
                                if (!isEmptyRow)
                                {
                                    string eingabeEingaben = fields[0].Trim();
                                    string eingabeBetrag = fields[1].Trim();
                                    string ausgabeAusgaben = fields[2].Trim();
                                    string ausgabeBetrag = fields[3].Trim();

                                    // Füge die Eingaben und Ausgaben in die jeweiligen Listen hinzu
                                    System.Windows.Forms.ListViewItem eingabeItem = new System.Windows.Forms.ListViewItem(eingabeEingaben);
                                    eingabeItem.SubItems.Add(eingabeBetrag); // Betrag als Komma-Zahl
                                    ListeEinnahmen.Items.Add(eingabeItem);

                                    System.Windows.Forms.ListViewItem ausgabeItem = new System.Windows.Forms.ListViewItem(ausgabeAusgaben);
                                    ausgabeItem.SubItems.Add(ausgabeBetrag); // Betrag als Komma-Zahl
                                    ListeAusgaben.Items.Add(ausgabeItem);
                                }
                            }
                            else
                            {
                                // Fehlerhafte Zeile in der CSV-Datei
                                MessageBox.Show("Ungültige Zeile in der CSV-Datei: " + line);
                            }

                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Fehler beim Importieren der Daten: " + ex.Message);
            }

            // Aktualisiere die Gesamtsumme
            UpdateGesamtsumme();


        }
        
        private void UpdateGesamtsumme()
        {
            decimal gesamtsummeEinnahmen = 0;
            decimal gesamtsummeAusgaben = 0;

            // Gehe durch die Liste der Einnahmen und addiere die Beträge
            foreach (ListViewItem item in ListeEinnahmen.Items)
            {
                if (item.SubItems.Count >= 2 && decimal.TryParse(item.SubItems[1].Text, out decimal betrag))
                {
                    gesamtsummeEinnahmen += betrag;
                }
            }

            // Gehe durch die Liste der Ausgaben und addiere die Beträge
            foreach (ListViewItem item in ListeAusgaben.Items)
            {
                if (item.SubItems.Count >= 2 && decimal.TryParse(item.SubItems[1].Text, out decimal betrag))
                {
                    gesamtsummeAusgaben += betrag;
                }
            }

            foreach (ListViewItem item in ListeAusgaben.Items)
            {
                if (decimal.TryParse(item.SubItems[1].Text, out decimal ausgabeBetrag))
                {
                    if (ausgabeBetrag >= 250)
                    {
                        item.SubItems[1].ForeColor = Color.Red; // Textfarbe auf Rot setzen
                        item.SubItems[1].BackColor = Color.LightPink; // Hintergrundfarbe auf Hellrosa setzen
                    }
                    else
                    {
                        // Wenn der Betrag kleiner als 250 ist, die Farbe zurücksetzen
                        item.SubItems[1].ForeColor = ListeAusgaben.ForeColor; // Standard-Textfarbe
                        item.SubItems[1].BackColor = ListeAusgaben.BackColor; // Standard-Hintergrundfarbe
                    }
                }
            }

            // Zeige die Gesamtsummen der Einnahmen und Ausgaben in den Textboxen an
            GesamtsummeEinnahmenTextBox.Text = gesamtsummeEinnahmen.ToString("N2").PadLeft(GesamtsummeEinnahmenTextBox.Width - 60);
            GesamtsummeAusgabenTextBox.Text = gesamtsummeAusgaben.ToString("N2").PadLeft(GesamtsummeAusgabenTextBox.Width - 60);

            // Berechne den Restbetrag und zeige ihn in der Textbox an
            restbetrag = gesamtsummeEinnahmen - gesamtsummeAusgaben;
            RestbetragTextBox.Text = restbetrag.ToString("N2");

            // Berechne das Gesamtvermögen und zeige es in der Textbox an
            decimal gesamtvermoegen = gesamtsummeEinnahmen - gesamtsummeAusgaben;
            Vermoegen.Text = gesamtvermoegen.ToString("N0");

        }
        private void BerechneGesamtsumme()
        {
            // Addiere den Wert aus "VermoegenTextBox" mit dem Wert aus "RestbetragTextBox"
            // und zeige das Ergebnis in "GesamtTextBox" an
            decimal vermogen = 0;
            if (decimal.TryParse(Vermoegen.Text, NumberStyles.Any, CultureInfo.GetCultureInfo("de-DE"), out decimal vermogenValue))
            {
                vermogen = vermogenValue;
            }

            decimal restbetrag = 0;
            if (decimal.TryParse(RestbetragTextBox.Text, NumberStyles.Any, CultureInfo.GetCultureInfo("de-DE"), out decimal restbetragValue))
            {
                restbetrag = restbetragValue;
            }

            decimal gesamt = vermogen + restbetrag;
            Gesamttxt.Text = gesamt.ToString("N2");
        }

        // Methode, um die nächste freie Zeile in der Liste zu finden
        private int FindeNaechsteFreieZeile(ListView listView)
        {
            int index = 0;
            foreach (ListViewItem item in listView.Items)
            {
                if (string.IsNullOrEmpty(item.SubItems[0].Text) && string.IsNullOrEmpty(item.SubItems[1].Text))
                {
                    return index;
                }
                index++;
            }
            return listView.Items.Count;
        }
        private void Dladen_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "CSV Dateien (*.csv)|*.csv|Alle Dateien (*.*)|*.*";
                    openFileDialog.Title = "CSV Datei auswählen";

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string csvDateiPfad = openFileDialog.FileName;
                       
                        ImportiereZusatzlisteAusCSV(csvDateiPfad);
                        ImportiereDatenAusCSV(csvDateiPfad);
                        BerechneVermoegen();
                        BerechneGesamtsumme();


                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fehler beim Importieren der Daten aus der CSV-Datei: " + ex.Message);
            }
        }
        public void ExportiereDatenInCSV(string csvDateiPfad)
        {
            
                try
                {
                    using (StreamWriter writer = new StreamWriter(csvDateiPfad))
                    {
                        // Schreibe die Überschriften in die CSV-Datei
                        writer.WriteLine("Eingaben;Betrag;Ausgaben;Betrag;Kreditkarte;Ledger;Trade Republic;Bausparvertrag1;Bausparvertrag2;Union Investment;Etoro;Kontostand");

                        // Schreibe die Daten aus ListeEinnahmen und ListeAusgaben in die CSV-Datei
                        int maxZeilen = Math.Max(ListeEinnahmen.Items.Count, ListeAusgaben.Items.Count);
                        for (int i = 0; i < maxZeilen; i++)
                        {
                            string eingabe = "";
                            string eingabeBetrag = "";
                            string ausgabe = "";
                            string ausgabeBetrag = "";

                            if (i < ListeEinnahmen.Items.Count)
                            {
                                ListViewItem eingabeItem = ListeEinnahmen.Items[i];
                                eingabe = eingabeItem.SubItems[0].Text;
                                eingabeBetrag = eingabeItem.SubItems[1].Text;
                            }

                            if (i < ListeAusgaben.Items.Count)
                            {
                                ListViewItem ausgabeItem = ListeAusgaben.Items[i];
                                ausgabe = ausgabeItem.SubItems[0].Text;
                                ausgabeBetrag = ausgabeItem.SubItems[1].Text;
                            }

                            // Schreibe die Daten aus listView1 in die CSV-Datei
                            string zusatzInfo = "";
                            if (i < listView1.Items.Count)
                            {
                                ListViewItem zusatzItem = listView1.Items[i];
                                for (int j = 0; j < zusatzItem.SubItems.Count; j++)
                                {
                                    zusatzInfo += zusatzItem.SubItems[j].Text + ";";
                                }
                            }

                            writer.WriteLine($"{eingabe};{eingabeBetrag};{ausgabe};{ausgabeBetrag};{zusatzInfo.TrimEnd(';')}");
                        }
                    }

                    MessageBox.Show("Daten wurden erfolgreich in die CSV-Datei exportiert.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Fehler beim Exportieren der Daten: " + ex.Message);
                }
            

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void Dspeichern_Click(object sender, EventArgs e)
        {
            try
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "CSV Dateien (*.csv)|*.csv|Alle Dateien (*.*)|*.*";
                    saveFileDialog.Title = "CSV Datei speichern";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string csvDateiPfad = saveFileDialog.FileName;
                        ExportiereDatenInCSV(csvDateiPfad);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fehler beim Exportieren der Daten in die CSV-Datei: " + ex.Message);
            }
        }

        private void zurücksetzen_Click(object sender, EventArgs e)
        {
            ListeEinnahmen.Items.Clear();
            ListeAusgaben.Items.Clear();
            UpdateGesamtsumme();
        }

        private void löschen_Click(object sender, EventArgs e)
        {
            if (ListeAusgaben.SelectedItems.Count > 0)
            {
                ListViewItem selectedAusgabeItem = ListeAusgaben.SelectedItems[0];
                ListeAusgaben.Items.Remove(selectedAusgabeItem);
            }
            else if (ListeEinnahmen.SelectedItems.Count > 0)
            {
                ListViewItem selectedEinnahmeItem = ListeEinnahmen.SelectedItems[0];
                ListeEinnahmen.Items.Remove(selectedEinnahmeItem);
            }
            UpdateGesamtsumme();
        }

        private void Eeintragen_Click(object sender, EventArgs e)
        {
            string eingabe = Einnahmentxt.Text.Trim();

            if (!string.IsNullOrEmpty(eingabe))
            {
                string[] parts = eingabe.Split(' ');

                if (parts.Length == 2)
                {
                    string name = parts[0].Trim();
                    string betragStr = parts[1].Trim();

                    // Versuche den eingegebenen Betrag in eine Dezimalzahl umzuwandeln
                    if (decimal.TryParse(betragStr, out decimal betrag))
                    {
                        bool nameFound = false;

                        // Suche nach dem Namen in der ListeEinnahmen und füge den Betrag hinzu, falls gefunden
                        foreach (ListViewItem item in ListeEinnahmen.Items)
                        {
                            if (item.SubItems[0].Text == name)
                            {
                                nameFound = true;
                                decimal existingBetrag = decimal.Parse(item.SubItems[1].Text);
                                item.SubItems[1].Text = (existingBetrag + betrag).ToString();
                                break;
                            }
                        }

                        // Wenn der Name nicht gefunden wurde, füge den Eintrag in die nächste freie Zeile hinzu
                        if (!nameFound)
                        {
                            int nextEmptyRow = FindeNaechsteFreieZeile(ListeEinnahmen);
                            ListViewItem item = new ListViewItem(name);
                            item.SubItems.Add(betrag.ToString());
                            ListeEinnahmen.Items.Insert(nextEmptyRow, item);
                        }

                        // Textfeld zurücksetzen
                        Einnahmentxt.Text = "";
                        BerechneGesamtsumme();
                        UpdateGesamtsumme();
                        BerechneVermoegen();
                    }
                    else
                    {
                        MessageBox.Show("Bitte geben Sie den Namen und den Betrag im Format 'Name Betrag' ein.");
                    }
                }
                else
                {
                    MessageBox.Show("Bitte geben Sie den Namen und den Betrag im Format 'Name Betrag' ein.");
                }
            }
            else
            {
                MessageBox.Show("Bitte geben Sie den Namen und den Betrag im Format 'Name Betrag' ein.");
            }
        }

        private void Aeingeben_Click(object sender, EventArgs e)
        {
            string eingabe = Ausgaben.Text.Trim();

            if (!string.IsNullOrEmpty(eingabe))
            {
                string[] parts = eingabe.Split(' ');

                if (parts.Length == 2)
                {
                    string name = parts[0].Trim();
                    string betragText = parts[1].Trim();

                    if (decimal.TryParse(betragText, out decimal betrag))
                    {
                        // Überprüfe, ob der Name bereits in der Liste vorhanden ist
                        if (IstNameVorhanden(name, ListeAusgaben))
                        {
                            // Wenn ja, füge den Betrag zu dem vorhandenen Eintrag hinzu
                            BetragHinzufuegen(name, betrag, ListeAusgaben);
                        }
                        else
                        {
                            // Ansonsten füge den Eintrag direkt in die nächste freie Zeile der ListView hinzu
                            ListViewItem item = new ListViewItem(name);
                            item.SubItems.Add(betrag.ToString("N2"));
                            ListeAusgaben.Items.Add(item);
                        }

                        // Textfeld zurücksetzen
                        Ausgaben.Text = "";
                        
                        UpdateGesamtsumme();
                        BerechneVermoegen();
                        BerechneGesamtsumme();
                    }
                    else
                    {
                        MessageBox.Show("Bitte geben Sie den Namen und den Betrag im Format 'Name Betrag' ein.");
                    }
                }
                else
                {
                    MessageBox.Show("Bitte geben Sie den Namen und den Betrag im Format 'Name Betrag' ein.");
                }
            }
            else
            {
                MessageBox.Show("Bitte geben Sie den Namen und den Betrag im Format 'Name Betrag' ein.");
            }
        }
        public void BerechneVermoegen()
        {
            decimal vermoegen = 0;

            foreach (ListViewItem item in listView1.Items)
            {
                // Überspringe die Spalte "Kreditkarte" (Index 0) und die Spalte "Kontostand" (Index 12)
                for (int i = 1; i < item.SubItems.Count - 1; i++)
                {
                    if (decimal.TryParse(item.SubItems[i].Text, NumberStyles.Any, CultureInfo.GetCultureInfo("de-DE"), out decimal wert))
                    {
                        vermoegen += wert;
                    }
                }
            }

            Vermoegen.Text = vermoegen.ToString("N2");

        }
            private void ListeAusgaben_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Vermögen_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

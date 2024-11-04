namespace KandidatProj
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            btnDodaj = new Button();
            txtDodatniLinkovi = new TextBox();
            txtEmail = new TextBox();
            txtIme = new TextBox();
            txtPrezime = new TextBox();
            txtNazivPriloga = new TextBox();
            txtTelefon = new TextBox();
            dtpDatumRodjenja = new DateTimePicker();
            mtxtJMBG = new MaskedTextBox();
            btnIzmeni = new Button();
            lblLastUpdate = new Label();
            cbStatus = new ComboBox();
            dgvKandidati = new DataGridView();
            Imelbl = new Label();
            Prezimelbl = new Label();
            JMBGlbl = new Label();
            DatRodjlbl = new Label();
            Emaillbl = new Label();
            Telefonlbl = new Label();
            Napomenalbl = new Label();
            DodLinklbl = new Label();
            nudOcena = new NumericUpDown();
            Ocenalbl = new Label();
            Statuslbl = new Label();
            btnOdaberiSliku = new Button();
            btnObrisi = new Button();
            txtNapomena = new RichTextBox();
            pbSlika = new PictureBox();
            errorProvider1 = new ErrorProvider(components);
            btnOdaberiPrilog = new Button();
            txtPretragaIme = new TextBox();
            txtPretragaPrezime = new TextBox();
            mtxtPretragaJMBG = new TextBox();
            lblPretragaIme = new Label();
            lblPretragaPrezime = new Label();
            txtPretragaJMBG = new Label();
            btnPretraga = new Button();
            btnResetujPretragu = new Button();
            dgvIstorijaStatusa = new DataGridView();
            lblIstorijaStatusa = new Label();
            btnReset = new Button();
            btnIzvezi = new Button();
            cbTipPriloga = new ComboBox();
            btnOtvoriPrilog = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvKandidati).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudOcena).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbSlika).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvIstorijaStatusa).BeginInit();
            SuspendLayout();
            // 
            // btnDodaj
            // 
            btnDodaj.Location = new Point(12, 598);
            btnDodaj.Name = "btnDodaj";
            btnDodaj.Size = new Size(75, 23);
            btnDodaj.TabIndex = 0;
            btnDodaj.Text = "Dodaj";
            btnDodaj.UseVisualStyleBackColor = true;
            btnDodaj.Click += btnDodaj_Click;
            // 
            // txtDodatniLinkovi
            // 
            txtDodatniLinkovi.Location = new Point(307, 187);
            txtDodatniLinkovi.MaxLength = 700;
            txtDodatniLinkovi.Name = "txtDodatniLinkovi";
            txtDodatniLinkovi.Size = new Size(200, 23);
            txtDodatniLinkovi.TabIndex = 1;
            txtDodatniLinkovi.Click += txtDodatniLinkovi_Click;
            txtDodatniLinkovi.TextChanged += txtDodatniLinkovi_TextChanged;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(307, 128);
            txtEmail.MaxLength = 200;
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(200, 23);
            txtEmail.TabIndex = 2;
            // 
            // txtIme
            // 
            txtIme.Location = new Point(307, 12);
            txtIme.MaxLength = 100;
            txtIme.Name = "txtIme";
            txtIme.Size = new Size(200, 23);
            txtIme.TabIndex = 3;
            // 
            // txtPrezime
            // 
            txtPrezime.Location = new Point(307, 41);
            txtPrezime.MaxLength = 100;
            txtPrezime.Name = "txtPrezime";
            txtPrezime.Size = new Size(200, 23);
            txtPrezime.TabIndex = 4;
            // 
            // txtNazivPriloga
            // 
            txtNazivPriloga.Location = new Point(12, 248);
            txtNazivPriloga.MaxLength = 13;
            txtNazivPriloga.Name = "txtNazivPriloga";
            txtNazivPriloga.ReadOnly = true;
            txtNazivPriloga.Size = new Size(129, 23);
            txtNazivPriloga.TabIndex = 5;
            txtNazivPriloga.Click += txtNazivPriloga_Click;
            txtNazivPriloga.TextChanged += txtNazivPriloga_TextChanged;
            // 
            // txtTelefon
            // 
            txtTelefon.Location = new Point(307, 158);
            txtTelefon.MaxLength = 30;
            txtTelefon.Name = "txtTelefon";
            txtTelefon.Size = new Size(200, 23);
            txtTelefon.TabIndex = 6;
            txtTelefon.TextChanged += txtTelefon_TextChanged;
            txtTelefon.KeyPress += txtTelefon_KeyPress;
            // 
            // dtpDatumRodjenja
            // 
            dtpDatumRodjenja.CustomFormat = "dd.MM.yyyy";
            dtpDatumRodjenja.Format = DateTimePickerFormat.Custom;
            dtpDatumRodjenja.Location = new Point(307, 99);
            dtpDatumRodjenja.Name = "dtpDatumRodjenja";
            dtpDatumRodjenja.Size = new Size(200, 23);
            dtpDatumRodjenja.TabIndex = 7;
            dtpDatumRodjenja.Value = new DateTime(2024, 11, 3, 0, 0, 0, 0);
            // 
            // mtxtJMBG
            // 
            mtxtJMBG.Location = new Point(307, 70);
            mtxtJMBG.Mask = "00000000000/00";
            mtxtJMBG.Name = "mtxtJMBG";
            mtxtJMBG.Size = new Size(200, 23);
            mtxtJMBG.TabIndex = 9;
            mtxtJMBG.TextChanged += mtxtJMBG_TextChanged;
            // 
            // btnIzmeni
            // 
            btnIzmeni.Location = new Point(93, 598);
            btnIzmeni.Name = "btnIzmeni";
            btnIzmeni.Size = new Size(75, 23);
            btnIzmeni.TabIndex = 10;
            btnIzmeni.Text = "Izmeni";
            btnIzmeni.UseVisualStyleBackColor = true;
            btnIzmeni.Click += btnIzmeni_Click;
            // 
            // lblLastUpdate
            // 
            lblLastUpdate.AutoSize = true;
            lblLastUpdate.Location = new Point(307, 339);
            lblLastUpdate.Name = "lblLastUpdate";
            lblLastUpdate.Size = new Size(127, 15);
            lblLastUpdate.TabIndex = 11;
            lblLastUpdate.Text = "Datum i Vreme Izmene";
            lblLastUpdate.Click += label1_Click;
            // 
            // cbStatus
            // 
            cbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cbStatus.FormattingEnabled = true;
            cbStatus.Location = new Point(307, 309);
            cbStatus.Name = "cbStatus";
            cbStatus.Size = new Size(121, 23);
            cbStatus.TabIndex = 13;
            // 
            // dgvKandidati
            // 
            dgvKandidati.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvKandidati.Location = new Point(12, 373);
            dgvKandidati.Name = "dgvKandidati";
            dgvKandidati.Size = new Size(908, 219);
            dgvKandidati.TabIndex = 15;
            dgvKandidati.CellContentClick += dataGridView1_CellContentClick;
            dgvKandidati.SelectionChanged += dgvKandidati_SelectionChanged;
            // 
            // Imelbl
            // 
            Imelbl.AutoSize = true;
            Imelbl.Location = new Point(209, 15);
            Imelbl.Name = "Imelbl";
            Imelbl.Size = new Size(27, 15);
            Imelbl.TabIndex = 17;
            Imelbl.Text = "Ime";
            // 
            // Prezimelbl
            // 
            Prezimelbl.AutoSize = true;
            Prezimelbl.Location = new Point(209, 44);
            Prezimelbl.Name = "Prezimelbl";
            Prezimelbl.Size = new Size(49, 15);
            Prezimelbl.TabIndex = 18;
            Prezimelbl.Text = "Prezime";
            Prezimelbl.Click += label3_Click;
            // 
            // JMBGlbl
            // 
            JMBGlbl.AutoSize = true;
            JMBGlbl.Location = new Point(209, 73);
            JMBGlbl.Name = "JMBGlbl";
            JMBGlbl.Size = new Size(37, 15);
            JMBGlbl.TabIndex = 19;
            JMBGlbl.Text = "JMBG";
            // 
            // DatRodjlbl
            // 
            DatRodjlbl.AutoSize = true;
            DatRodjlbl.Location = new Point(209, 102);
            DatRodjlbl.Name = "DatRodjlbl";
            DatRodjlbl.Size = new Size(86, 15);
            DatRodjlbl.TabIndex = 20;
            DatRodjlbl.Text = "Datum rođenja";
            // 
            // Emaillbl
            // 
            Emaillbl.AutoSize = true;
            Emaillbl.Location = new Point(209, 131);
            Emaillbl.Name = "Emaillbl";
            Emaillbl.Size = new Size(36, 15);
            Emaillbl.TabIndex = 21;
            Emaillbl.Text = "Email";
            // 
            // Telefonlbl
            // 
            Telefonlbl.AutoSize = true;
            Telefonlbl.Location = new Point(209, 161);
            Telefonlbl.Name = "Telefonlbl";
            Telefonlbl.Size = new Size(45, 15);
            Telefonlbl.TabIndex = 22;
            Telefonlbl.Text = "Telefon";
            // 
            // Napomenalbl
            // 
            Napomenalbl.AutoSize = true;
            Napomenalbl.Location = new Point(209, 219);
            Napomenalbl.Name = "Napomenalbl";
            Napomenalbl.Size = new Size(66, 15);
            Napomenalbl.TabIndex = 23;
            Napomenalbl.Text = "Napomena";
            // 
            // DodLinklbl
            // 
            DodLinklbl.AutoSize = true;
            DodLinklbl.Location = new Point(209, 190);
            DodLinklbl.Name = "DodLinklbl";
            DodLinklbl.Size = new Size(87, 15);
            DodLinklbl.TabIndex = 25;
            DodLinklbl.Text = "Dodatni linkovi";
            // 
            // nudOcena
            // 
            nudOcena.Location = new Point(307, 280);
            nudOcena.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            nudOcena.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudOcena.Name = "nudOcena";
            nudOcena.Size = new Size(120, 23);
            nudOcena.TabIndex = 26;
            nudOcena.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // Ocenalbl
            // 
            Ocenalbl.AutoSize = true;
            Ocenalbl.Location = new Point(209, 282);
            Ocenalbl.Name = "Ocenalbl";
            Ocenalbl.Size = new Size(41, 15);
            Ocenalbl.TabIndex = 27;
            Ocenalbl.Text = "Ocena";
            // 
            // Statuslbl
            // 
            Statuslbl.AutoSize = true;
            Statuslbl.Location = new Point(209, 312);
            Statuslbl.Name = "Statuslbl";
            Statuslbl.Size = new Size(39, 15);
            Statuslbl.TabIndex = 28;
            Statuslbl.Text = "Status";
            // 
            // btnOdaberiSliku
            // 
            btnOdaberiSliku.Location = new Point(12, 190);
            btnOdaberiSliku.Name = "btnOdaberiSliku";
            btnOdaberiSliku.Size = new Size(101, 23);
            btnOdaberiSliku.TabIndex = 29;
            btnOdaberiSliku.Text = "Odaberi sliku";
            btnOdaberiSliku.UseVisualStyleBackColor = true;
            btnOdaberiSliku.Click += btnOdaberiSliku_Click;
            // 
            // btnObrisi
            // 
            btnObrisi.Location = new Point(174, 598);
            btnObrisi.Name = "btnObrisi";
            btnObrisi.Size = new Size(75, 23);
            btnObrisi.TabIndex = 30;
            btnObrisi.Text = "Obriši";
            btnObrisi.UseVisualStyleBackColor = true;
            btnObrisi.Click += btnObrisi_Click;
            // 
            // txtNapomena
            // 
            txtNapomena.Location = new Point(307, 215);
            txtNapomena.Name = "txtNapomena";
            txtNapomena.Size = new Size(200, 59);
            txtNapomena.TabIndex = 31;
            txtNapomena.Text = "";
            // 
            // pbSlika
            // 
            pbSlika.Image = (Image)resources.GetObject("pbSlika.Image");
            pbSlika.Location = new Point(12, 9);
            pbSlika.Name = "pbSlika";
            pbSlika.Size = new Size(191, 175);
            pbSlika.SizeMode = PictureBoxSizeMode.Zoom;
            pbSlika.TabIndex = 33;
            pbSlika.TabStop = false;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // btnOdaberiPrilog
            // 
            btnOdaberiPrilog.Location = new Point(12, 219);
            btnOdaberiPrilog.Name = "btnOdaberiPrilog";
            btnOdaberiPrilog.Size = new Size(101, 23);
            btnOdaberiPrilog.TabIndex = 34;
            btnOdaberiPrilog.Text = "Odaberi Prilog";
            btnOdaberiPrilog.UseVisualStyleBackColor = true;
            btnOdaberiPrilog.Click += btnOdaberiPrilog_Click;
            // 
            // txtPretragaIme
            // 
            txtPretragaIme.Location = new Point(926, 391);
            txtPretragaIme.Name = "txtPretragaIme";
            txtPretragaIme.Size = new Size(121, 23);
            txtPretragaIme.TabIndex = 35;
            // 
            // txtPretragaPrezime
            // 
            txtPretragaPrezime.Location = new Point(926, 435);
            txtPretragaPrezime.Name = "txtPretragaPrezime";
            txtPretragaPrezime.Size = new Size(121, 23);
            txtPretragaPrezime.TabIndex = 36;
            // 
            // mtxtPretragaJMBG
            // 
            mtxtPretragaJMBG.Location = new Point(926, 479);
            mtxtPretragaJMBG.Name = "mtxtPretragaJMBG";
            mtxtPretragaJMBG.Size = new Size(121, 23);
            mtxtPretragaJMBG.TabIndex = 37;
            // 
            // lblPretragaIme
            // 
            lblPretragaIme.AutoSize = true;
            lblPretragaIme.Location = new Point(926, 373);
            lblPretragaIme.Name = "lblPretragaIme";
            lblPretragaIme.Size = new Size(88, 15);
            lblPretragaIme.TabIndex = 38;
            lblPretragaIme.Text = "Pretraga za ime";
            lblPretragaIme.Click += lblPretragaIme_Click;
            // 
            // lblPretragaPrezime
            // 
            lblPretragaPrezime.AutoSize = true;
            lblPretragaPrezime.Location = new Point(926, 417);
            lblPretragaPrezime.Name = "lblPretragaPrezime";
            lblPretragaPrezime.Size = new Size(110, 15);
            lblPretragaPrezime.TabIndex = 39;
            lblPretragaPrezime.Text = "Pretraga za prezime";
            // 
            // txtPretragaJMBG
            // 
            txtPretragaJMBG.AutoSize = true;
            txtPretragaJMBG.Location = new Point(926, 461);
            txtPretragaJMBG.Name = "txtPretragaJMBG";
            txtPretragaJMBG.Size = new Size(98, 15);
            txtPretragaJMBG.TabIndex = 40;
            txtPretragaJMBG.Text = "Pretraga za JMBG";
            // 
            // btnPretraga
            // 
            btnPretraga.Location = new Point(926, 524);
            btnPretraga.Name = "btnPretraga";
            btnPretraga.Size = new Size(121, 23);
            btnPretraga.TabIndex = 41;
            btnPretraga.Text = "Pretraga";
            btnPretraga.UseVisualStyleBackColor = true;
            btnPretraga.Click += btnPretraga_Click;
            // 
            // btnResetujPretragu
            // 
            btnResetujPretragu.Location = new Point(926, 569);
            btnResetujPretragu.Name = "btnResetujPretragu";
            btnResetujPretragu.Size = new Size(121, 23);
            btnResetujPretragu.TabIndex = 42;
            btnResetujPretragu.Text = "Resetuj pretragu";
            btnResetujPretragu.UseVisualStyleBackColor = true;
            btnResetujPretragu.Click += btnResetujPretragu_Click;
            // 
            // dgvIstorijaStatusa
            // 
            dgvIstorijaStatusa.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvIstorijaStatusa.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvIstorijaStatusa.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvIstorijaStatusa.Location = new Point(513, 12);
            dgvIstorijaStatusa.Name = "dgvIstorijaStatusa";
            dgvIstorijaStatusa.Size = new Size(401, 198);
            dgvIstorijaStatusa.TabIndex = 43;
            // 
            // lblIstorijaStatusa
            // 
            lblIstorijaStatusa.AutoSize = true;
            lblIstorijaStatusa.Location = new Point(832, 215);
            lblIstorijaStatusa.Name = "lblIstorijaStatusa";
            lblIstorijaStatusa.Size = new Size(82, 15);
            lblIstorijaStatusa.TabIndex = 44;
            lblIstorijaStatusa.Text = "Istorija statusa";
            lblIstorijaStatusa.Click += lblIstorijaStatusa_Click;
            // 
            // btnReset
            // 
            btnReset.Location = new Point(209, 335);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(81, 23);
            btnReset.TabIndex = 45;
            btnReset.Text = "Očisti formu";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // btnIzvezi
            // 
            btnIzvezi.Location = new Point(926, 18);
            btnIzvezi.Name = "btnIzvezi";
            btnIzvezi.Size = new Size(121, 23);
            btnIzvezi.TabIndex = 46;
            btnIzvezi.Text = "Izvezi XLSX fajl";
            btnIzvezi.UseVisualStyleBackColor = true;
            btnIzvezi.Click += btnIzvezi_Click;
            // 
            // cbTipPriloga
            // 
            cbTipPriloga.DropDownStyle = ComboBoxStyle.DropDownList;
            cbTipPriloga.FormattingEnabled = true;
            cbTipPriloga.Location = new Point(12, 277);
            cbTipPriloga.Name = "cbTipPriloga";
            cbTipPriloga.Size = new Size(129, 23);
            cbTipPriloga.TabIndex = 47;
            cbTipPriloga.SelectedIndexChanged += cbTipPriloga_SelectedIndexChanged;
            // 
            // btnOtvoriPrilog
            // 
            btnOtvoriPrilog.Location = new Point(147, 237);
            btnOtvoriPrilog.Name = "btnOtvoriPrilog";
            btnOtvoriPrilog.Size = new Size(56, 42);
            btnOtvoriPrilog.TabIndex = 48;
            btnOtvoriPrilog.Text = "Otvori prilog";
            btnOtvoriPrilog.UseVisualStyleBackColor = true;
            btnOtvoriPrilog.Click += btnOtvoriPrilog_Click;
            // 
            // Form1
            // 
            AcceptButton = btnResetujPretragu;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1059, 629);
            Controls.Add(btnOtvoriPrilog);
            Controls.Add(cbTipPriloga);
            Controls.Add(btnIzvezi);
            Controls.Add(btnReset);
            Controls.Add(lblIstorijaStatusa);
            Controls.Add(dgvIstorijaStatusa);
            Controls.Add(btnResetujPretragu);
            Controls.Add(btnPretraga);
            Controls.Add(txtPretragaJMBG);
            Controls.Add(lblPretragaPrezime);
            Controls.Add(lblPretragaIme);
            Controls.Add(mtxtPretragaJMBG);
            Controls.Add(txtPretragaPrezime);
            Controls.Add(txtPretragaIme);
            Controls.Add(btnOdaberiPrilog);
            Controls.Add(pbSlika);
            Controls.Add(txtNapomena);
            Controls.Add(btnObrisi);
            Controls.Add(btnOdaberiSliku);
            Controls.Add(Statuslbl);
            Controls.Add(Ocenalbl);
            Controls.Add(nudOcena);
            Controls.Add(DodLinklbl);
            Controls.Add(Napomenalbl);
            Controls.Add(Telefonlbl);
            Controls.Add(Emaillbl);
            Controls.Add(DatRodjlbl);
            Controls.Add(JMBGlbl);
            Controls.Add(Prezimelbl);
            Controls.Add(Imelbl);
            Controls.Add(dgvKandidati);
            Controls.Add(cbStatus);
            Controls.Add(lblLastUpdate);
            Controls.Add(btnIzmeni);
            Controls.Add(mtxtJMBG);
            Controls.Add(dtpDatumRodjenja);
            Controls.Add(txtTelefon);
            Controls.Add(txtNazivPriloga);
            Controls.Add(txtPrezime);
            Controls.Add(txtIme);
            Controls.Add(txtEmail);
            Controls.Add(txtDodatniLinkovi);
            Controls.Add(btnDodaj);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "Navigator Kandidata";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dgvKandidati).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudOcena).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbSlika).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvIstorijaStatusa).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnDodaj;
        private TextBox txtDodatniLinkovi;
        private TextBox txtEmail;
        private TextBox txtIme;
        private TextBox txtPrezime;
        private TextBox txtNazivPriloga;
        private TextBox txtTelefon;
        private DateTimePicker dtpDatumRodjenja;
        private MaskedTextBox mtxtJMBG;
        private Button btnIzmeni;
        private Label lblLastUpdate;
        private PictureBox pictureBox1;
        private ComboBox cbStatus;
        private DataGridView dgvKandidati;
        private Label Imelbl;
        private Label Prezimelbl;
        private Label JMBGlbl;
        private Label DatRodjlbl;
        private Label Emaillbl;
        private Label Telefonlbl;
        private Label Napomenalbl;
        private TextBox textBox7;
        private Label DodLinklbl;
        private NumericUpDown nudOcena;
        private Label Ocenalbl;
        private Label Statuslbl;
        private Button btnOdaberiSliku;
        private Button btnObrisi;
        private RichTextBox txtNapomena;
        private PictureBox pbSlika;
        private ErrorProvider errorProvider1;
        private Button btnOdaberiPrilog;
        private Button btnPretraga;
        private Label txtPretragaJMBG;
        private Label lblPretragaPrezime;
        private Label lblPretragaIme;
        private TextBox mtxtPretragaJMBG;
        private TextBox txtPretragaPrezime;
        private TextBox txtPretragaIme;
        private Button btnResetujPretragu;
        private DataGridView dgvIstorijaStatusa;
        private Label lblIstorijaStatusa;
        private Button btnReset;
        private Button btnIzvezi;
        private ComboBox cbTipPriloga;
        private Button btnOtvoriPrilog;
    }
}

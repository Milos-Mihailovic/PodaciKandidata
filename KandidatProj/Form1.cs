using ClosedXML.Excel;
using KandidatApp.Data;
using KandidatApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Windows.Forms;

namespace KandidatProj
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            PopuniComboBoxStatus();
            PopuniComboBoxTipPriloga();
            mtxtJMBG.TextChanged += mtxtJMBG_TextChanged;
            txtDodatniLinkovi.Click += txtDodatniLinkovi_Click;
        }

        private Image defaultSlika;

        private void Form1_Load(object sender, EventArgs e)
        {
            UcitajKandidate();
            //PopuniComboBoxStatus();
            // Postaviti maksimalni datum na današnji dan
            dtpDatumRodjenja.MaxDate = DateTime.Now;
            //Poèetna slika PictureBox-a kao default slika
            defaultSlika = pbSlika.Image;
            // Postaviti minimalni datum
            dtpDatumRodjenja.MinDate = new DateTime(1900, 1, 1);
        }
        private void UcitajKandidate()
        {
            using (var context = new KandidatiDbContext())
            {
                //var kandidati = context.Kandidati.ToList();
                var kandidati = context.Kandidati
                .Select(k => new
                {
                    k.Id,
                    k.Ime,
                    k.Prezime,
                    k.JMBG,
                    DatumRodjenja = k.DatumRodjenja.ToString("dd.MM.yyyy"), // Proverite ako DatumRodjenja može biti null
                    k.Email,
                    k.Telefon,
                    k.DodatniLinkovi,
                    k.Napomena,
                    k.Ocena,
                    Status = k.Status.ToString(), // Dodajte string reprezentaciju statusa
                    k.LastUpdate,
                    k.Slika
                }).ToList();
                dgvKandidati.DataSource = kandidati;
            }
        }

        private void PopuniComboBoxStatus()
        {
            // Dobijamo sve vrednosti iz enum-a StatusKandidata
            var statusValues = Enum.GetValues(typeof(StatusKandidata));

            // Dodajemo svaku vrednost u ComboBox
            foreach (var status in statusValues)
            {
                cbStatus.Items.Add(status);
            }
        }

        private void PopuniComboBoxTipPriloga()
        {
            // Dobijamo sve vrednosti iz enum-a TipPriloga
            var statusValues = Enum.GetValues(typeof(Models.TipPriloga));

            // Dodajemo svaku vrednost u ComboBox
            foreach (var status in statusValues)
            {
                cbTipPriloga.Items.Add(status);
            }
        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            // Oèisti prethodne greške
            errorProvider1.Clear();

            // Proveri obavezna polja
            if (string.IsNullOrWhiteSpace(txtIme.Text))
            {
                errorProvider1.SetError(txtIme, "Ime je obavezno.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPrezime.Text))
            {
                errorProvider1.SetError(txtPrezime, "Prezime je obavezno.");
                return;
            }

            if (string.IsNullOrWhiteSpace(mtxtJMBG.Text.Replace("/", "").Trim()) || !mtxtJMBG.MaskCompleted)
            {
                errorProvider1.SetError(mtxtJMBG, "JMBG je obavezan.");
                mtxtJMBG.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text) || !IsValidEmail(txtEmail.Text))
            {
                errorProvider1.SetError(txtEmail, "Email je obavezan i mora biti validan.");
                return;
            }

            // Proveri da li je odabran datum roðenja
            if (dtpDatumRodjenja.Value.Date >= DateTime.Now.Date)
            {
                MessageBox.Show("Datum roðenja mora biti u prošlosti.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //// Proveri da li je izabran CV
            //if (string.IsNullOrWhiteSpace(txtPrilog.Text))
            //{
            //    MessageBox.Show("Morate izabrati CV.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            // Proveri da li je izabrana slika
            if (pbSlika.Image == null)
            {
                MessageBox.Show("Morate izabrati sliku.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //// Proveri obavezna polja za prilog
            //if (string.IsNullOrWhiteSpace(txtNazivPriloga.Text) || cbTipPriloga.SelectedItem == null)
            //{
            //    MessageBox.Show("Morate odabrati prilog i izabrati tip priloga.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            using (var context = new KandidatiDbContext())
            {

                var noviKandidat = new Kandidat
                {
                    Ime = txtIme.Text,
                    Prezime = txtPrezime.Text,
                    JMBG = mtxtJMBG.Text.Replace("/", "").Trim(),
                    DatumRodjenja = dtpDatumRodjenja.Value,
                    Email = txtEmail.Text,
                    Telefon = txtTelefon.Text, // Telefon
                    DodatniLinkovi = txtDodatniLinkovi.Text, // Dodatni linkovi
                    Napomena = txtNapomena.Text, // Napomena
                    Ocena = (int)nudOcena.Value, // Ocena (1-5)
                    Status = cbStatus.SelectedItem != null ? (StatusKandidata)cbStatus.SelectedItem : StatusKandidata.Kandidat, // Ako nije izabran, postavi na default
                    //Prilozi = putanjaDoPriloga, // Postavite putanju do CV-a ako je izabran
                    Slika = ImageToByte(pbSlika.Image), // Konvertujte sliku u bajt niz
                    //Status = (StatusKandidata)Enum.Parse(typeof(StatusKandidata), cbStatus.SelectedItem.ToString()), // Status kandidata
                    //StatusIstorija = new List<IstorijaPromenaStatusa>() // Inicijalizacija liste istorije statusa
                    LastUpdate = DateTime.Now // Datum i vreme izmene
                };

                // Provera da li postoji kandidat sa istim JMBG ili Email
                var postojiKandidat = context.Kandidati
                    .Any(k => k.JMBG == txtNazivPriloga.Text || k.Email == txtEmail.Text);

                if (postojiKandidat)
                {
                    MessageBox.Show("Kandidat veæ postoji.");
                    return;
                }

                //// Dodavanje priloga
                //var noviPrilog = new Prilog
                //{
                //    Naziv = txtNazivPriloga.Text,
                //    Tip = cbTipPriloga.SelectedItem.ToString(),
                //    FileData = File.ReadAllBytes(openFileDialog.FileName), // Saèuvajte fajl kao bajt niz
                //    LastUpdate = DateTime.Now,
                //    Kandidat = noviKandidat // Povezivanje sa novim kandidatom
                //};

                try
                {

                    lblLastUpdate.Text = "Poslednja izmena: " + DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss");
                    context.Kandidati.Add(noviKandidat);
                    Debug.WriteLine($"Ime: {noviKandidat.Ime}, Prezime: {noviKandidat.Prezime}, JMBG: {noviKandidat.JMBG}, Email: {noviKandidat.Email}, Telefon: {noviKandidat.Telefon}");

                    context.SaveChanges();

                    // Dodaj promenu statusa u istoriju
                    DodajPromenuStatusa(noviKandidat.Id, noviKandidat.Status.ToString());

                    // Dodaj prilog
                    if (!string.IsNullOrWhiteSpace(txtNazivPriloga.Text) && cbTipPriloga.SelectedItem != null)
                    {
                        byte[] fileData = File.ReadAllBytes(_filePath); // Koristite prethodno saèuvanu putanju

                        var prilog = new Prilog
                        {
                            KandidatId = noviKandidat.Id, // Povežite prilog sa novim kandidatom
                            Naziv = txtNazivPriloga.Text,
                            Tip = cbTipPriloga.SelectedItem.ToString(),
                            FileData = fileData,
                            LastUpdate = DateTime.Now
                        };

                        context.Prilozi.Add(prilog);
                        context.SaveChanges(); // Saèuvajte prilog

                        MessageBox.Show("Kandidat i prilog su uspešno dodati!");
                    }

                }
                catch (DbUpdateException ex)
                {
                    MessageBox.Show($"Greška prilikom èuvanja: {ex.InnerException?.Message}");
                }

                //context.Kandidati.Add(noviKandidat);
                //context.SaveChanges();
            }

            UcitajKandidate(); // Ponovo uèitavanje kandidata da bi osvežili prikaz

        }

        private byte[] ImageToByte(Image image)
        {
            using (var ms = new MemoryStream())
            {
                // Kreiramo kopiju slike kako bismo izbegli eventualne zakljuèane resurse
                using (var clonedImage = new Bitmap(image))
                {
                    clonedImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
                return ms.ToArray();
            }
            //using (var ms = new MemoryStream())
            //{
            //    image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            //    return ms.ToArray();
            //}
        }

        // Metoda za validaciju email adrese
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void btnOdaberiSliku_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "Image files (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Uèitaj sliku u PictureBox
                    pbSlika.Image = Image.FromFile(openFileDialog.FileName);
                    // Opciono: èuvanje slike kao byte[]
                    // byte[] imageData = File.ReadAllBytes(openFileDialog.FileName);
                }
            }
        }

        private string _filePath; // Putanja do fajla
        private string _nazivPriloga; // Naziv priloga

        private void btnOdaberiPrilog_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "PDF files (*.pdf)|*.pdf|Word documents (*.docx)|*.docx|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                _filePath = openFileDialog.FileName;// Saèuvajte putanju do fajla
                _nazivPriloga = System.IO.Path.GetFileName(_filePath); // Izvucite naziv fajla

                // Prikazivanje naziva priloga u TextBox
                txtNazivPriloga.Text = _nazivPriloga;

                // Prikazivanje priloga u FormPrikazPriloga
                FormPrikazPriloga formPrikaz = new FormPrikazPriloga(_filePath);
                formPrikaz.ShowDialog();
            }
        }

        private void mtxtJMBG_TextChanged(object sender, EventArgs e)
        {
            // Ukloni sve maske iz JMBG teksta
            string jmbg = mtxtJMBG.Text.Replace("/", "").Trim();

            // Proveri da li ima taèno 13 karaktera i da li su svi karakteri brojevi
            if (jmbg.Length == 13 && long.TryParse(jmbg, out _))
            {
                try
                {
                    // Parsiraj dan, mesec i godinu iz JMBG
                    int dan = int.Parse(jmbg.Substring(0, 2));
                    int mesec = int.Parse(jmbg.Substring(2, 2));
                    int godina = int.Parse(jmbg.Substring(4, 3));

                    // Proveri da li je godina 19xx ili 20xx na osnovu JMBG
                    godina = godina > 900 ? 1000 + godina : 2000 + godina;

                    // Proveri da li godina prelazi tekuæu godinu
                    if (godina > DateTime.Now.Year)
                    {
                        MessageBox.Show("Godina iz JMBG-a ne može biti u buduænosti.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Proverite da li su dan i mesec validni
                    if (mesec < 1 || mesec > 12 || dan < 1 || dan > 31)
                    {
                        MessageBox.Show("Dan ili mesec iz JMBG-a nije validan.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Proverite da li je datum validan
                    if (!IsValidDate(dan, mesec, godina))
                    {
                        MessageBox.Show("Datum roðenja iz JMBG-a nije validan.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Podesi datum roðenja u DateTimePicker kontroli
                    dtpDatumRodjenja.Value = new DateTime(godina, mesec, dan);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Nevažeæi JMBG. Proverite unos.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Metoda za proveru validnosti datuma
        private bool IsValidDate(int day, int month, int year)
        {
            // Proverite da li je godina prestupna
            bool isLeapYear = DateTime.IsLeapYear(year);

            // Proverite broj dana u mesecu
            int daysInMonth = DateTime.DaysInMonth(year, month);
            return day <= daysInMonth;
        }

        private void dgvKandidati_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvKandidati.SelectedRows.Count > 0)
            {
                var selectedRow = dgvKandidati.SelectedRows[0];
                int kandidatId = (int)selectedRow.Cells["Id"].Value;

                txtIme.Text = selectedRow.Cells["Ime"].Value.ToString();
                txtPrezime.Text = selectedRow.Cells["Prezime"].Value.ToString();
                mtxtJMBG.Text = selectedRow.Cells["JMBG"].Value.ToString();
                dtpDatumRodjenja.Value = DateTime.ParseExact(selectedRow.Cells["DatumRodjenja"].Value.ToString(), "dd.MM.yyyy", null);
                txtEmail.Text = selectedRow.Cells["Email"].Value.ToString();
                txtTelefon.Text = selectedRow.Cells["Telefon"].Value.ToString();
                txtDodatniLinkovi.Text = selectedRow.Cells["DodatniLinkovi"].Value.ToString();
                txtNapomena.Text = selectedRow.Cells["Napomena"].Value.ToString();
                nudOcena.Value = Convert.ToDecimal(selectedRow.Cells["Ocena"].Value);
                cbStatus.SelectedItem = Enum.Parse(typeof(StatusKandidata), selectedRow.Cells["Status"].Value.ToString());

                // Ažuriraj LastUpdate labelu
                DateTime lastUpdate = (DateTime)selectedRow.Cells["LastUpdate"].Value;
                lblLastUpdate.Text = "Poslednja izmena: " + lastUpdate.ToString("dd.MM.yyyy HH:mm:ss");
                UcitajIstorijuPromena(kandidatId);

                // Prikaz slike specifiène za kandidata
                pbSlika.Image = ByteToImage((byte[])selectedRow.Cells["Slika"].Value);

                // Resetuj `_filePath` da ne bi koristio stari fajl priloga ako kandidat nema prilog
                _filePath = string.Empty;

                // Dohvati podatke o prilogu kandidata iz baze
                using (var context = new KandidatiDbContext())
                {
                    var prilog = context.Prilozi.FirstOrDefault(p => p.KandidatId == kandidatId);
                    if (prilog != null)
                    {
                        txtNazivPriloga.Text = prilog.Naziv;
                        //cbTipPriloga.SelectedItem = prilog.Tip;
                        // Pronaðite taèan tip priloga u ComboBox-u i selektujte ga
                        int index = cbTipPriloga.FindStringExact(prilog.Tip);
                        if (index != -1)
                        {
                            cbTipPriloga.SelectedIndex = index;
                        }
                        //// Podesi `_filePath` na putanju do priloga, jer prilog postoji
                        //_filePath = Path.Combine(Path.GetTempPath(), prilog.Naziv);
                        //File.WriteAllBytes(_filePath, prilog.FileData);
                    }
                    else
                    {
                        // Ako prilog ne postoji, oèisti polja
                        txtNazivPriloga.Clear();
                        cbTipPriloga.SelectedIndex = -1;
                    }
                }

            }
        }
        private Image ByteToImage(byte[] byteArray)
        {
            if (byteArray == null || byteArray.Length == 0)
            {
                return null; // Vraæa null ako je byteArray prazan ili null
            }

            using (var ms = new MemoryStream(byteArray))
            {
                return Image.FromStream(ms); // Konvertuje byte niz u sliku
            }
        }

        private void DodajPromenuStatusa(int kandidatId, string noviStatus)
        {
            using (var context = new KandidatiDbContext())
            {
                var novaPromena = new IstorijaPromenaStatusa
                {
                    KandidatId = kandidatId,
                    Status = noviStatus,
                    LastUpdate = DateTime.Now
                };

                context.StatusIstorija.Add(novaPromena);
                context.SaveChanges();
            }

            // Ažuriraj prikaz u DataGridView-u
            UcitajIstorijuPromena(kandidatId);
        }


        private void UcitajIstorijuPromena(int kandidatId)
        {
            using (var context = new KandidatiDbContext())
            {
                // Prvo preuzmi podatke iz baze
                var istorijaPromena = context.StatusIstorija
                    .Where(i => i.KandidatId == kandidatId)
                    .OrderByDescending(i => i.LastUpdate) // Sortiranje po LastUpdate u opadajuæem redosledu
                    .ToList() // Povlaèenje podataka iz baze

                    // Zatim formatiraj podatke
                    .Select(i => new
                    {
                        Status = i.Status,
                        LastUpdate = i.LastUpdate.ToString("dd.MM.yyyy HH:mm:ss") // Formatiranje datuma
                    })
                    .ToList();

                // Prikaz u DataGridView
                dgvIstorijaStatusa.DataSource = istorijaPromena;

            }
        }


        private void btnIzmeni_Click(object sender, EventArgs e)
        {
            if (dgvKandidati.SelectedRows.Count > 0)
            {
                var selectedRow = dgvKandidati.SelectedRows[0];
                var kandidatId = (int)selectedRow.Cells["Id"].Value;

                using (var context = new KandidatiDbContext())
                {
                    var kandidat = context.Kandidati.Find(kandidatId);
                    if (kandidat != null)
                    {
                        // Ažuriraj podatke

                        // Saèuvaj trenutni status pre ažuriranja
                        var stariStatus = kandidat.Status;

                        kandidat.Ime = txtIme.Text;
                        kandidat.Prezime = txtPrezime.Text;
                        kandidat.JMBG = mtxtJMBG.Text.Replace("/", "").Trim();
                        kandidat.DatumRodjenja = dtpDatumRodjenja.Value;
                        kandidat.Email = txtEmail.Text;
                        kandidat.Telefon = txtTelefon.Text;
                        kandidat.DodatniLinkovi = txtDodatniLinkovi.Text;
                        kandidat.Napomena = txtNapomena.Text;
                        kandidat.Ocena = (int)nudOcena.Value;
                        kandidat.Status = (StatusKandidata)cbStatus.SelectedItem;
                        kandidat.Slika = ImageToByte(pbSlika.Image);
                        kandidat.LastUpdate = DateTime.Now;

                        // Ažuriraj podatke o prilogu ako postoje
                        var prilog = context.Prilozi.FirstOrDefault(p => p.KandidatId == kandidatId);
                        if (prilog != null)
                        {
                            prilog.Naziv = txtNazivPriloga.Text;
                            prilog.Tip = cbTipPriloga.SelectedItem?.ToString();

                            // Ako postoji novi fajl, ažuriraj fajl u bazi
                            if (!string.IsNullOrEmpty(_filePath))
                            {
                                prilog.FileData = File.ReadAllBytes(_filePath);
                            }
                            prilog.LastUpdate = DateTime.Now;
                        }
                        else if (!string.IsNullOrEmpty(txtNazivPriloga.Text) && cbTipPriloga.SelectedItem != null)
                        {
                            // Ako prilog ne postoji, a uneta su nova polja za prilog, kreiraj novi prilog
                            var noviPrilog = new Prilog
                            {
                                KandidatId = kandidatId,
                                Naziv = txtNazivPriloga.Text,
                                Tip = cbTipPriloga.SelectedItem.ToString(),
                                FileData = !string.IsNullOrEmpty(_filePath) ? File.ReadAllBytes(_filePath) : null,
                                LastUpdate = DateTime.Now
                            };
                            context.Prilozi.Add(noviPrilog);
                        }

                        try
                        {
                            context.SaveChanges();
                            // Proveri da li je status promenjen
                            if (stariStatus != kandidat.Status)
                            {
                                // Dodaj u istoriju promenu statusa
                                DodajPromenuStatusa(kandidat.Id, kandidat.Status.ToString());
                            }
                            MessageBox.Show("Podaci su uspešno ažurirani!");
                        }
                        catch (DbUpdateException ex)
                        {
                            Debug.WriteLine($"Ime: {kandidat.Ime}, Prezime: {kandidat.Prezime}, JMBG: {kandidat.JMBG}, Email: {kandidat.Email}, Telefon: {kandidat.Telefon}");

                            MessageBox.Show($"Greška prilikom èuvanja: {ex.InnerException?.Message}");
                        }
                    }
                }

                UcitajKandidate(); // Osveži prikaz u DataGridView-u
            }
        }

        private void btnObrisi_Click(object sender, EventArgs e)
        {
            // Proveri da li je izabran neki red u DataGridView
            if (dgvKandidati.SelectedRows.Count > 0)
            {
                var selectedRow = dgvKandidati.SelectedRows[0];
                var kandidatId = (int)selectedRow.Cells["Id"].Value; // Pretpostavljamo da je "Id" kolona sa identifikatorom

                // Pitanje za potvrdu brisanja
                var result = MessageBox.Show("Da li ste sigurni da želite da obrišete ovog kandidata?", "Potvrda brisanja", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    using (var context = new KandidatiDbContext())
                    {
                        var kandidat = context.Kandidati.Find(kandidatId); // Naði kandidata u bazi
                        if (kandidat != null)
                        {
                            // Ukloni prilog povezan sa kandidatom ako postoji
                            var prilog = context.Prilozi.FirstOrDefault(p => p.KandidatId == kandidatId);
                            if (prilog != null)
                            {
                                context.Prilozi.Remove(prilog);
                            }

                            context.Kandidati.Remove(kandidat); // Ukloni kandidata iz konteksta
                            try
                            {
                                context.SaveChanges(); // Saèuvaj promene u bazi
                                MessageBox.Show("Kandidat je uspešno obrisan!");
                            }
                            catch (DbUpdateException ex)
                            {
                                MessageBox.Show($"Greška prilikom brisanja: {ex.InnerException?.Message}");
                            }
                        }
                    }

                    UcitajKandidate(); // Osveži prikaz u DataGridView-u
                }
            }
            else
            {
                MessageBox.Show("Morate izabrati kandidata koji želite da obrišete.");
            }
        }

        private void btnPretraga_Click(object sender, EventArgs e)
        {
            using (var context = new KandidatiDbContext())
            {
                var pretragaIme = txtPretragaIme.Text.Trim();
                var pretragaPrezime = txtPretragaPrezime.Text.Trim();
                var pretragaJMBG = mtxtPretragaJMBG.Text.Trim();

                var kandidati = context.Kandidati.AsQueryable();

                // Filtriraj po imenu
                if (!string.IsNullOrEmpty(pretragaIme))
                {
                    kandidati = kandidati.Where(k => k.Ime.Contains(pretragaIme));
                }

                // Filtriraj po prezimenu
                if (!string.IsNullOrEmpty(pretragaPrezime))
                {
                    kandidati = kandidati.Where(k => k.Prezime.Contains(pretragaPrezime));
                }

                // Filtriraj po JMBG
                if (!string.IsNullOrEmpty(pretragaJMBG))
                {
                    kandidati = kandidati.Where(k => k.JMBG.Contains(pretragaJMBG));
                }

                // Izvrši pretragu i postavi rezultat na DataGridView
                var rezultat = kandidati.Select(k => new
                {
                    k.Id,
                    k.Ime,
                    k.Prezime,
                    k.JMBG,
                    DatumRodjenja = k.DatumRodjenja.ToString("dd.MM.yyyy"),
                    k.Email,
                    k.Telefon,
                    k.DodatniLinkovi,
                    k.Napomena,
                    k.Ocena,
                    Status = k.Status.ToString()
                }).ToList();

                dgvKandidati.DataSource = rezultat;
            }
        }

        private void btnResetujPretragu_Click(object sender, EventArgs e)
        {
            txtPretragaIme.Clear();
            txtPretragaPrezime.Clear();
            mtxtPretragaJMBG.Clear();
            UcitajKandidate();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblIstorijaStatusa_Click(object sender, EventArgs e)
        {

        }

        private void txtDodatniLinkovi_Click(object sender, EventArgs e)
        {

            string url = txtDodatniLinkovi.Text.Trim();

            // Proveravamo da li je URL validan
            if (Uri.IsWellFormedUriString(url, UriKind.Absolute))
            {
                try
                {
                    // Otvaramo URL u podrazumevanom pretraživaèu
                    System.Diagnostics.Process.Start(new ProcessStartInfo
                    {
                        FileName = url,
                        UseShellExecute = true // Ovo omoguæava otvaranje u podrazumevanom pretraživaèu
                    });
                }
                catch (Exception ex)
                {
                    //dgvIstorijaStatusa
                    MessageBox.Show($"Došlo je do greške pri otvaranju linka: {ex.Message}");
                }
            }
            //else
            //{
            //    MessageBox.Show("Uneti link nije validan URL.");
            //}
        }

        private void txtDodatniLinkovi_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            OcistiPolja();
        }
        private void OcistiPolja()
        {
            txtIme.Text = string.Empty;
            txtPrezime.Text = string.Empty;
            mtxtJMBG.Clear();
            dtpDatumRodjenja.Value = DateTime.Today;
            txtEmail.Text = string.Empty;
            txtTelefon.Text = string.Empty;
            txtDodatniLinkovi.Text = string.Empty;
            txtNapomena.Text = string.Empty;
            nudOcena.Value = 1;
            cbStatus.SelectedIndex = -1; // Poništi izbor u ComboBox-u
            // Oèisti DataGridView za istoriju statusa
            dgvIstorijaStatusa.DataSource = null;
            pbSlika.Image = defaultSlika;
            txtNazivPriloga.Clear();
            cbTipPriloga.SelectedIndex = -1;
            //pbSlika.Image = null; // Obriši sliku, ako postoji
            txtIme.Focus();
        }

        private void lblPretragaIme_Click(object sender, EventArgs e)
        {

        }

        // Funkcija za izvoz podataka u XLSX
        private void IzveziUExcel(Kandidat kandidat)
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Kandidat");

                // Postavi naslove kolona
                worksheet.Cell(1, 1).Value = "Ime";
                worksheet.Cell(1, 2).Value = "Prezime";
                worksheet.Cell(1, 3).Value = "JMBG";
                worksheet.Cell(1, 4).Value = "Datum Roðenja";
                worksheet.Cell(1, 5).Value = "Email";
                worksheet.Cell(1, 6).Value = "Telefon";
                worksheet.Cell(1, 7).Value = "Dodatni Linkovi";
                worksheet.Cell(1, 8).Value = "Napomena";
                worksheet.Cell(1, 9).Value = "Ocena";
                worksheet.Cell(1, 10).Value = "Status";

                // Unesi podatke kandidata
                worksheet.Cell(2, 1).Value = kandidat.Ime;
                worksheet.Cell(2, 2).Value = kandidat.Prezime;
                worksheet.Cell(2, 3).Value = kandidat.JMBG;
                worksheet.Cell(2, 4).Value = kandidat.DatumRodjenja;
                worksheet.Cell(2, 5).Value = kandidat.Email;
                worksheet.Cell(2, 6).Value = kandidat.Telefon;
                worksheet.Cell(2, 7).Value = kandidat.DodatniLinkovi;
                worksheet.Cell(2, 8).Value = kandidat.Napomena;
                worksheet.Cell(2, 9).Value = kandidat.Ocena;
                worksheet.Cell(2, 10).Value = kandidat.Status.ToString();

                // Postavi formatiranje
                worksheet.Columns().AdjustToContents(); // Prilagodi širinu kolona

                // Saèuvaj fajl
                var saveFileDialog = new SaveFileDialog
                {
                    Filter = "Excel files (*.xlsx)|*.xlsx",
                    Title = "Saèuvaj Excel fajl",
                    FileName = $"{kandidat.Ime}_{kandidat.Prezime}.xlsx"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    workbook.SaveAs(saveFileDialog.FileName);
                    MessageBox.Show("Fajl je uspešno saèuvan!", "Uspeh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnIzvezi_Click(object sender, EventArgs e)
        {
            if (dgvKandidati.SelectedRows.Count == 0)
            {
                // Prikaži obaveštenje ako nije izabran kandidat
                MessageBox.Show("Molimo vas da izaberete kandidata pre nego što izvezete fajl!", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dgvKandidati.SelectedRows.Count > 0)
            {
                var selectedRow = dgvKandidati.SelectedRows[0];
                var kandidatId = (int)selectedRow.Cells["Id"].Value;

                using (var context = new KandidatiDbContext())
                {
                    var kandidat = context.Kandidati.Find(kandidatId);
                    IzveziUExcel(kandidat);
                }
            }
        }

        private void txtNazivPriloga_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbTipPriloga_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtNazivPriloga_Click(object sender, EventArgs e)
        {
            //if (!string.IsNullOrWhiteSpace(_filePath))
            //{
            //    // Proverite da li fajl postoji pre otvaranja
            //    if (System.IO.File.Exists(_filePath))
            //    {
            //        // Otvorite formu za prikaz priloga
            //        FormPrikazPriloga formPrikaz = new FormPrikazPriloga(_filePath);
            //        formPrikaz.ShowDialog();
            //    }
            //    else
            //    {
            //        MessageBox.Show("Fajl ne postoji.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}
        }

        private void btnOtvoriPrilog_Click(object sender, EventArgs e)
        {
            // Ako postoji lokalni fajl priloga koji je upravo dodan, otvorite ga
            if (!string.IsNullOrWhiteSpace(_filePath) && System.IO.File.Exists(_filePath))
            {
                FormPrikazPriloga formPrikaz = new FormPrikazPriloga(_filePath);
                formPrikaz.ShowDialog();
                return;
            }

            // Proverite da li je red izabran i da li polje za naziv priloga nije prazno
            if (!string.IsNullOrWhiteSpace(txtNazivPriloga.Text) && dgvKandidati.SelectedRows.Count > 0)
            {
                // Uzmite `kandidatId` od trenutno selektovanog reda
                int kandidatId = (int)dgvKandidati.SelectedRows[0].Cells["Id"].Value;

                using (var context = new KandidatiDbContext())
                {
                    // Ponovo pronaðite prilog za kandidata kako biste dobili ažurirane podatke
                    var prilog = context.Prilozi.FirstOrDefault(p => p.KandidatId == kandidatId);

                    if (prilog != null)
                    {
                        // Saèuvajte prilog kao privremeni fajl
                        string tempFilePath = Path.Combine(Path.GetTempPath(), prilog.Naziv);
                        File.WriteAllBytes(tempFilePath, prilog.FileData);

                        // Otvori novu formu i prikaži prilog koristeæi putanju do privremenog fajla
                        var formPrikazPriloga = new FormPrikazPriloga(tempFilePath);
                        formPrikazPriloga.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Prilog za ovog kandidata nije pronaðen. Molimo dodajte prilog.",
                                        "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Nema dostupnog priloga za pregled ili red nije izabran.",
                                "Obaveštenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            //if (!string.IsNullOrWhiteSpace(txtNazivPriloga.Text) && dgvKandidati.SelectedRows.Count > 0)
            //{
            //    // Uzmite `kandidatId` od trenutno selektovanog reda
            //    int kandidatId = (int)dgvKandidati.SelectedRows[0].Cells["Id"].Value;


            //    using (var context = new KandidatiDbContext())
            //    {
            //        // Pronaðite prilog povezan sa ovim kandidatom
            //        var prilog = context.Prilozi.FirstOrDefault(p => p.KandidatId == kandidatId);
            //        if (prilog != null)
            //        {
            //            // Saèuvajte prilog kao privremeni fajl
            //            string tempFilePath = Path.Combine(Path.GetTempPath(), prilog.Naziv);
            //            File.WriteAllBytes(tempFilePath, prilog.FileData);

            //            // Otvori novu formu i prikaži prilog koristeæi putanju do privremenog fajla
            //            var formPrikazPriloga = new FormPrikazPriloga(tempFilePath);
            //            formPrikazPriloga.ShowDialog();
            //            //// Otvori novu formu i prikaži prilog
            //            //var formPrikazPriloga = new FormPrikazPriloga(prilog.FileData);
            //            //formPrikazPriloga.ShowDialog();
            //        }
            //        else
            //        {
            //            MessageBox.Show("Prilog za ovog kandidata nije pronaðen.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        }
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Nema dostupnog priloga za pregled.", "Obaveštenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
        }

        private void txtTelefon_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTelefon_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Dozvoljava samo brojeve i kontrolne tastere kao što su Backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Spreèava unos nebrojèanih karaktera
            }
        }
    }
}

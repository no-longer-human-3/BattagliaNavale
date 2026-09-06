

namespace Battaglia_Navale_Lasku_Pagliuca
{
    public struct Posizione
    {
        public int Riga;
        public int Colonna;
    }

    public struct Nave
    {
        public string nome;
        public int dim;
        public Posizione[] Coord;
        public bool[] colpiSubiti;
        public bool affondo;

    }











    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        const int righe = 10; // righe della mia tabella
        const int colonne = 10; // colonne della mia tabella
        const int navi = 5; // numero di navi che la mia flotta possiede

        int[,] mioCampo = new int[righe, colonne];
        int[,] campoAvv = new int[righe, colonne];
        Nave[] miaFlotta = new Nave[navi];

        bool orizzontale = true; // Variabile per salvare l'orientamento scelto dall'utente
        bool[] naviPosizionate = new bool[navi]; // Mantiene traccia di quali navi sono già sulla griglia





        private void GraficaTabelle()
        {
            char[] lettere = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'L' };

            // --- MIO CAMPO ---
            tabellone.Text = "     A   B   C   D   E   F   G   H   I   L\r\n";
            tabellone.Text += "   +---+---+---+---+---+---+---+---+---+---+\r\n";

            for (int r = 0; r < righe; r++)
            {
                if (r + 1 < 10)
                    tabellone.Text += " " + (r + 1) + " |";
                else
                    tabellone.Text += (r + 1) + " |";

                for (int c = 0; c < colonne; c++)
                {
                    if (mioCampo[r, c] == 0) tabellone.Text += "   |"; // Vuoto
                    else if (mioCampo[r, c] == 1) tabellone.Text += " P |"; // Portaerei
                    else if (mioCampo[r, c] == 2) tabellone.Text += " C |"; // Corazzata
                    else if (mioCampo[r, c] == 3) tabellone.Text += "I1 |"; // Incrociatore 1
                    else if (mioCampo[r, c] == 4) tabellone.Text += "I2 |"; // Incrociatore 2
                    else if (mioCampo[r, c] == 5) tabellone.Text += "CP |"; // Cacciatorpediniere
                    else if (mioCampo[r, c] == 8) tabellone.Text += " O |"; // Acqua colpita
                    else if (mioCampo[r, c] == 9) tabellone.Text += " X |"; // Nave colpita
                }
                tabellone.Text += "\r\n   +---+---+---+---+---+---+---+---+---+---+\r\n";
            }

            // --- CAMPO AVVERSARIO ---
            tabelloneAvv.Text = "     A   B   C   D   E   F   G   H   I   L\r\n";
            tabelloneAvv.Text += "   +---+---+---+---+---+---+---+---+---+---+\r\n";

            for (int r = 0; r < righe; r++)
            {
                if (r + 1 < 10)
                    tabelloneAvv.Text += " " + (r + 1) + " |";
                else
                    tabelloneAvv.Text += (r + 1) + " |";

                for (int c = 0; c < colonne; c++)
                {
                    if (campoAvv[r, c] == 0) tabelloneAvv.Text += "   |"; // Non ancora sparato
                    else if (campoAvv[r, c] == 8) tabelloneAvv.Text += " O |"; // Acqua
                    else if (campoAvv[r, c] == 9) tabelloneAvv.Text += " X |"; // Colpito
                }
                tabelloneAvv.Text += "\r\n   +---+---+---+---+---+---+---+---+---+---+\r\n";
            }
        }









        private void InizializzaFlotta() // Funzione per inizializzare la flotta
        {
            // Dichiarazione Portaerei
            miaFlotta[0].nome = "Portaerei";
            miaFlotta[0].dim = 5;
            miaFlotta[0].Coord = new Posizione[5];
            miaFlotta[0].colpiSubiti = new bool[5];
            miaFlotta[0].affondo = false;

            // Dichiarazione Corazzata
            miaFlotta[1].nome = "Corazzata";
            miaFlotta[1].dim = 4;
            miaFlotta[1].Coord = new Posizione[4];
            miaFlotta[1].colpiSubiti = new bool[4];
            miaFlotta[1].affondo = false;

            // Dichiarazione Incrociatore 1
            miaFlotta[2].nome = "Incrociatore 1";
            miaFlotta[2].dim = 3;
            miaFlotta[2].Coord = new Posizione[3];
            miaFlotta[2].colpiSubiti = new bool[3];
            miaFlotta[2].affondo = false;

            // Dichiarazione Incrociatore 2
            miaFlotta[3].nome = "Incrociatore 2";
            miaFlotta[3].dim = 3;
            miaFlotta[3].Coord = new Posizione[3];
            miaFlotta[3].colpiSubiti = new bool[3];
            miaFlotta[3].affondo = false;

            // Dichiarazione Cacciatorpediniere
            miaFlotta[4].nome = "Cacciatorpediniere";
            miaFlotta[4].dim = 2;
            miaFlotta[4].Coord = new Posizione[2];
            miaFlotta[4].colpiSubiti = new bool[2];
            miaFlotta[4].affondo = false;
        }



        private bool PosNave(int indiceNave, Posizione inizio, bool orizzontale) // Definizione funzione (ritorna true se posizionata)
        {
            bool esito = true; // Variabile di supporto: parte ipotizzando che la posizione sia valida
            int dim = miaFlotta[indiceNave].dim; // Recupera la lunghezza della nave selezionata dall'array flotta

            if (orizzontale && (inizio.Colonna + dim > colonne)) // Controlla se la nave esce dal campo a destra in orizzontale
            {
                esito = false; // Se supera la colonna 10, la posizione non è valida
            }

            if (!orizzontale && (inizio.Riga + dim > righe)) // Controlla se la nave esce dal campo in basso in verticale
            {
                esito = false; // Se supera la riga 10, la posizione non è valida
            }

            if (esito == true) // Se non esce dai bordi, controlla che non ci siano sovrapposizioni
            {
                for (int i = 0; i < dim; i++) // Ciclo per controllare ciascuna casella richiesta dalla nave
                {
                    int r = inizio.Riga; // Inizializza la riga con il valore di partenza
                    int c = inizio.Colonna; // Inizializza la colonna con il valore di partenza

                    if (orizzontale == true) // Se la nave è piazzata in orizzontale
                    {
                        c = inizio.Colonna + i; // Sposta la colonna in avanti di i caselle
                    }
                    else // Se la nave è piazzata in verticale
                    {
                        r = inizio.Riga + i; // Sposta la riga in avanti di i caselle
                    }

                    for (int spostamentoRiga = -1; spostamentoRiga <= 1; spostamentoRiga++)
                    {
                        for (int spostamentoColonna = -1; spostamentoColonna <= 1; spostamentoColonna++)
                        {
                            int nr = r + spostamentoRiga;
                            int nc = c + spostamentoColonna;

                            // Verifica che la casella vicina sia all'interno del tabellone
                            if (nr >= 0 && nr < righe && nc >= 0 && nc < colonne)
                            {
                                if (mioCampo[nr, nc] != 0) // Se la casella o una delle caselle vicine è occupata
                                {
                                    esito = false; // Trovata nave vicina o sovrapposta: non valida!
                                }
                            }
                        }
                    }
                }
            }

            if (esito == true) // Se tutti i controlli sono superati, salva la nave
            {
                for (int i = 0; i < dim; i++) // Ciclo per scrivere la nave nel campo e nella struttura
                {
                    int r = inizio.Riga; // Inizializza la riga con il valore di partenza
                    int c = inizio.Colonna; // Inizializza la colonna con il valore di partenza

                    if (orizzontale == true) // Se la nave è piazzata in orizzontale
                    {
                        c = inizio.Colonna + i; // Sposta la colonna in avanti per registrare il segmento
                    }
                    else // Se la nave è piazzata in verticale
                    {
                        r = inizio.Riga + i; // Sposta la riga in avanti per registrare il segmento
                    }

                    mioCampo[r, c] = indiceNave + 1; // Segna la casella della matrice come occupata da nave (1)
                    miaFlotta[indiceNave].Coord[i] = new Posizione { Riga = r, Colonna = c }; // Salva le coordinate nella nave
                }
            }
            return esito; // Restituisce l'esito finale al pulsante
        }

        private bool ControllaAffondato(int indiceNave) // Definizione funzione (ritorna true se la nave è completamente affondata)
        {
            bool affondata = true; // Variabile di supporto: parte ipotizzando che la nave sia affondata

            for (int i = 0; i < miaFlotta[indiceNave].dim; i++) // Scorri tutti i segmenti che compongono la nave
            {
                if (miaFlotta[indiceNave].colpiSubiti[i] == false) // Se trova anche solo un segmento NON colpito (false)
                {
                    affondata = false; // La nave non è ancora del tutto distrutta: imposta affondata a false
                }
            }

            if (affondata == true) // Se dopo il ciclo tutti i segmenti risultano colpiti (affondata è rimasto true)
            {
                miaFlotta[indiceNave].affondo = true; // Aggiorna lo stato ufficiale della nave impostando affondo a true
            }

            return affondata; // Restituisce l'esito finale (true o false) al gestore dei colpi
        }



        private bool VerificaCoord(string coordinate) // Funzione per verificare le coordinate inserite dall'utente
        {

            if (coordinate.Length < 2 || coordinate.Length > 3) // la coordinata deve essere lunga massimo di 3 caratteri e mai minore di 2 
            {
                return false; // se la coordinata è più corta di 2 o più lunga di 3 esce subito dalla funzione e restituisce il valore false
            }
            char[] charValide = { 'A', 'a', 'B', 'b', 'C', 'c', 'D', 'd', 'E', 'e', 'F', 'f', 'G', 'g', 'H', 'h', 'I', 'i', 'L', 'l' };// array di caratteri validi per la prima lettera della coordinata
            bool charValida = false; // variabile booleana per verificare se la prima lettera della coordinata è valida


            for (int i = 0; i < charValide.Length; i++) //ciclo per vedere se la prima lettera è valida scorre l'array lettera per lettera 
            {
                if (coordinate[0] == charValide[i]) // controlla se la lettera che inserisce l'utente è presente nell'array di tutti i caratteri validi 
                {
                    charValida = true; // se sono uguali la variabile booleana diventa valida quindi true quindi la lettera è corretta 
                    break; // esce dal ciclo perché ha trovato la lettera valida
                }
            }


            if (charValida == false) // se dopo il ciclo la variabile booleana è ancora falsa vuol dire che la lettera non è valida 
            {
                return false; // quindi esce dalla funzione e restituisce false
            }


            if (coordinate.Length == 2) // controlla se la coordinata è lunga 2 caratteri 
            {
                if (coordinate[1] >= '1' && coordinate[1] <= '9') // se essa è lunga 2 caratteri controlla che il secondo carattere sia un numero compreso tra 1 e 9 
                {
                    return true; // se è vero esce dalla funzione e restituisce true quindi la coordinata è valida
                }
            }


            if (coordinate.Length == 3) // controlla se la coordinata è lungs 3 caratteri
            {
                if (coordinate[1] == '1' && coordinate[2] == '0') // se essa è lunga 3 controlla che la seconda lettera sia 1 e la terza lettera sia 0 quindi la coordinata è 10
                {
                    return true; // se è vero esce dalla funzione e restituisce true quindi la coordinata è valida
                }
            }

            return false;
        }

        private void ConversioneCoord(string coordinate, out int riga, out int colonna) // funzione che mi converte le coordinate inserite dall'utente in coordinate numeriche poichè il computer non riesce a leggere le lettere quindi le converte in numeri
        {
            riga = -1; // valore di sicurezza per la riga, se non vengono trovate le coordinate corrette rimangono a -1
            colonna = -1; // valore di sicurezza per la colonna, se non vengono trovate le coordinate corrette rimangono a -1
            char[] lettereMaiusc = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'L' }; // array di lettere maiuscole valide per la prima lettera della coordinata
            char[] lettereMin = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'l' }; // array di lettere minuscole valide per la prima lettera della coordinata

            for (int c = 0; c < lettereMaiusc.Length; c++) // Scorre l'array delle lettere una alla volta, dall'inizio alla fine
            {

                if (coordinate[0] == lettereMaiusc[c] || coordinate[0] == lettereMin[c]) // controlla se la prima lettera della coordinata inserita dall'utente è uguale a una delle lettere negli array delle maiuscole o delle minuscole
                {
                    colonna = c; // Se la lettera coincide, assegna a riga l'indice dell'array
                }
            }

            if (coordinate.Length == 2) // controlla se la coordinata è lunga 2 caratteri
            {
                char[] num = { '1', '2', '3', '4', '5', '6', '7', '8', '9' }; // Array contenente i caratteri dei numeri da 1 a 9
                for (int i = 0; i < num.Length; i++) // Scorre l'array dei numeri dal'inizio alla fine
                {
                    if (coordinate[1] == num[i]) // controlla se il secondo carattere della coordinata equivale al numero dell'array
                    {
                        riga = i; // se il numero coincide, assegna a colonna l'indice dell'array
                    }
                }
            }
            else if (coordinate.Length == 3) // controlla se la coordinata è lunga 3 caratteri
            {
                riga = 9; // la colonna viene impostata subito a 9 (l'ultima ) poichè il numero massimo è 10
            }

        }

        private string GestioneColpo(int[,] tabella, int riga, int colonna) // funzione che controlla il colpo e aggiorna la griglia in base all'esito
        {
            //(0 = acqua , 1 = nave , 8 = acqua già colpita, 9 = nave già colpita)

            if (tabella[riga, colonna] == 0) // controlla se nella cella selezione c'è acqua quindi non c'è una nave(0)
            {
                tabella[riga, colonna] = 8; // la cella viene impostata a 8 per indicare acqua già colpita
                return "ACQUA"; // Viene restituito il messaggio dell'esito del colpo
            }

            else if (tabella[riga, colonna] >= 1 && tabella[riga, colonna] <= 5) // controlla se nella cella selezionata c'è una nave (1)
            {
                int indiceNave = tabella[riga, colonna] - 1; // Calcola l'indice della nave colpita sottraendo 1 dal valore della cella (1-5)
                tabella[riga, colonna] = 9; // la cella viene impostata a 9 per indicare nave già colpita
                for (int j = 0; j < miaFlotta[indiceNave].dim; j++)
                {
                    if (miaFlotta[indiceNave].Coord[j].Riga == riga && miaFlotta[indiceNave].Coord[j].Colonna == colonna)
                    {
                        miaFlotta[indiceNave].colpiSubiti[j] = true;
                        break;
                    }
                }

                // Verifica se l'ultimo segmento colpito ha fatto affondare la nave
                if (ControllaAffondato(indiceNave))
                {
                    return miaFlotta[indiceNave].nome + " COLPITO E AFFONDATO!";
                }
                else
                {
                    return miaFlotta[indiceNave].nome + " COLPITO!";
                }

            }

            else if (tabella[riga, colonna] == 8 || tabella[riga, colonna] == 9) // si viene controllato se in quelle posizioni si è già stato sparato in precedenza (8 o 9)
            {
                return "HAI GIA SPARATO QUI IN QUESTA POSIZIONE"; // Avvisa l'utente senza modificare la griglia
            }

            return "ERRORE"; // un ritorno per evitare errori 
        }






















        private void Elenco_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void spara_Click(object sender, EventArgs e)
        {
            string coordinata = coordProprie.Text; // Prende la coordinata inserita dall'utente
            if (VerificaCoord(coordinata) == true)
            {
                int riga, colonna; // Variabili per memorizzare le coordinate convertite
                ConversioneCoord(coordinata, out riga, out colonna); // Converte la coordinata in numeri
                string risultato = GestioneColpo(campoAvv, riga, colonna); // Controlla il colpo e aggiorna la griglia
                MessageBox.Show("Risultato del colpo: " + risultato); // Mostra il risultato del colpo all'utente
                coordProprie.Text = ""; // Pulisce la casella di testo dopo il colpo
                GraficaTabelle();
            }
            else
            {
                MessageBox.Show("Coordinata non valida,inserisci una coordinata corretta."); // Avvisa l'utente che la coordinata inserita non è valida
            }
        }


        private void POSIZIONA_Click(object sender, EventArgs e)
        {
            if (Elenco.SelectedIndex == -1) //Controlla se è stata selezionata una nave, se non è stata selezionata alcuna nave selection index sarà -1, quindi verra mostrato un messaggio di errore
            {
                MessageBox.Show("Seleziona prima una nave dalla lista!");
            }
            else
            {
                int indiceNave = Elenco.SelectedIndex;

                // CONTROLLO: Se la nave è già stata messa, blocca l'operazione
                if (naviPosizionate[indiceNave] == true)
                {
                    MessageBox.Show("Hai già posizionato questa nave!");
                    return;
                }
                string coordinata = posizione.Text; // Prende il testo inserito dall'utente


                if (VerificaCoord(coordinata) == true) // Se la coordinata è valida si procede con il posizionamento
                {
                    int riga;
                    int colonna;

                    ConversioneCoord(coordinata, out riga, out colonna); // converte la coordinata in numeri


                    Posizione inizio; // crea una variabile di tipo Posizione per memorizzare le coordinate iniziali
                    inizio.Riga = riga; // assegna la riga convertita alla variabile inizio
                    inizio.Colonna = colonna; // assegna la colonna convertita alla variabile inizio


                    if (PosNave(Elenco.SelectedIndex, inizio, orizzontale) == true) // Se la funzione PosNave restituisce true, il posizionamento è avvenuto con successo
                    {
                        naviPosizionate[indiceNave] = true;
                        MessageBox.Show("la nave è stata posizionata con successo");
                        coordProprie.Text = ""; // Pulisce la casella di testo
                        cronologia.Text += "Posizionata " + miaFlotta[indiceNave].nome + " in " + coordinata + "\r\n";
                        GraficaTabelle(); // Aggiorna la grafica delle tabelle

                    }
                    else
                    {
                        MessageBox.Show("impossibile posizionare la nave poichè o è fuori dal campo o si sovrappone ad un'altra nave");
                    }
                }
                else
                {
                    MessageBox.Show("La coordinata inserita non è valida");
                }
            }
        }


        private void RegistraColpoNave(int riga, int colonna)
        {
            // Scorriamo tutte e 5 le navi della flotta
            for (int i = 0; i < navi; i++)
            {
                // Per ogni nave, scorriamo i suoi segmenti
                for (int j = 0; j < miaFlotta[i].dim; j++)
                {
                    // Se le coordinate corrispondono a dove l'avversario ha sparato
                    if (miaFlotta[i].Coord[j].Riga == riga && miaFlotta[i].Coord[j].Colonna == colonna)
                    {
                        miaFlotta[i].colpiSubiti[j] = true; // Segnamo il pezzo come colpito!

                        // Controlliamo subito se con questo colpo la nave è affondata tutta
                        if (ControllaAffondato(i) == true)
                        {
                            MessageBox.Show("ATTENZIONE! La tua nave " + miaFlotta[i].nome + " è stata AFFONDATA!");
                        }
                        return; // Trovata la nave, usciamo dalla funzione
                    }
                }
            }
        }


        private void verificaColpo_Click(object sender, EventArgs e)
        {
            string coordinata = coordAvv.Text; // Prende la coordinata inserita dall'utente
            if (VerificaCoord(coordinata) == true)
            {
                int riga, colonna; // Variabili per memorizzare le coordinate convertite
                ConversioneCoord(coordinata, out riga, out colonna); // Converte la coordinata in numeri
                string risultato = GestioneColpo(mioCampo, riga, colonna); // Controlla il colpo e aggiorna la griglia


                if (risultato == "COLPITO")
                {
                    RegistraColpoNave(riga, colonna); // Aggiorna la struct della nave e controlla l'affondamento
                }



                MessageBox.Show("Risposta dall'avversario: " + risultato); // Mostra il risultato del colpo all'utente
                coordAvv.Text = ""; // Pulisce la casella di testo dopo il colpo

                if (risultato == "COLPITO")
                {
                    cronologia.Text += "Avversario spara su " + coordinata + ": COLPITO!\r\n";
                }
                else if (risultato == "ACQUA")
                {
                    cronologia.Text += "Avversario spara su " + coordinata + ": ACQUA\r\n";
                }
                GraficaTabelle();

            }
            else
            {
                MessageBox.Show("Coordinata  avversarianon valida"); // Avvisa l'utente che la coordinata inserita non è valida
            }

        }


        private void acqua_Click(object sender, EventArgs e)
        {
            string coordinata = coordProprie.Text;

            if (VerificaCoord(coordinata))
            {
                ConversioneCoord(coordinata, out int riga, out int colonna);

                // Controlla se la casella è già stata usata
                if (campoAvv[riga, colonna] != 0)
                {
                    MessageBox.Show("Hai già registrato un colpo in questa posizione!");
                    return;
                }

                campoAvv[riga, colonna] = 8; // 8 = Acqua ('O')
                coordProprie.Text = "";
                cronologia.Text += "Mio attacco su " + coordinata + ": ACQUA\r\n";
                GraficaTabelle();
            }
            else
            {
                MessageBox.Show("Coordinata non valida!");
            }
        }


        private void colpito_Click(object sender, EventArgs e)
        {
            string coordinata = coordProprie.Text;

            if (VerificaCoord(coordinata))
            {
                ConversioneCoord(coordinata, out int riga, out int colonna);

                // Controlla se la casella è già stata usata
                if (campoAvv[riga, colonna] != 0)
                {
                    MessageBox.Show("Hai già registrato un colpo in questa posizione!");
                    return;
                }

                campoAvv[riga, colonna] = 9; // 9 = Colpito ('X')
                coordProprie.Text = "";
                cronologia.Text += "Mio attacco su " + coordinata + ": COLPITO!\r\n";
                GraficaTabelle();
            }
            else
            {
                MessageBox.Show("Coordinata non valida!");
            }
        }
        private void Orrizzontale_Click(object sender, EventArgs e)
        {
            orizzontale = true; // Imposta l'orientamento a Orizzontale
            MessageBox.Show("Orientamento impostato su: Orizzontale");
        }

        private void Verticale_Click(object sender, EventArgs e)
        {
            orizzontale = false; // Imposta l'orientamento a Verticale
            MessageBox.Show("Orientamento impostato su: Verticale");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InizializzaFlotta(); // prepara le navi all'avvio

            Elenco.Items.Clear();
            Elenco.Items.Add("Portaerei (5)");
            Elenco.Items.Add("Corazzata (4)");
            Elenco.Items.Add("Incrociatore 1 (3)");
            Elenco.Items.Add("Incrociatore 2 (3)");
            Elenco.Items.Add("Cacciatorpediniere (2)");

            GraficaTabelle();
        }


        private void generaNavi_Click(object sender, EventArgs e)
        {

        }

        private void suggerimento_Click(object sender, EventArgs e)
        {

        }
    }
}

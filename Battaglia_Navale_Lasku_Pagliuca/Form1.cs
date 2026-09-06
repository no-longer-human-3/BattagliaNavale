

namespace Battaglia_Navale_Lasku_Pagliuca
{

    
    // Struct per rappresentare una posizione sulla griglia di gioco, con coordinate di riga e colonna.
    public struct Posizione
    {
        public int Riga;
        public int Colonna;
    }
    // Struct per rappresentare una nave, con nome, dimensione, coordinate dei segmenti, stato dei colpi subiti e stato di affondamento.
    public struct Nave
    {
        public string nome;
        public int dim;
        public Posizione[] Coord;
        public bool[] colpiSubiti;
        public bool affondo;

    }

    //------------------------------------------------------------------------------------------------//
    // legenda dei numeri:
    // numero 0= casella vuota
    // numero 1= portaerei
    // numero 2= corazzata
    // numero 3= incrociatore 1
    // numero 4= incrociatore 2
    // numero 5= cacciatorpediniere
    // numero 8= non è stata colpita nessuna nave quindi ACQUA
    // numero 9= è stata colpita una nave quindi COLPITO
    //------------------------------------------------------------------------------------------------//

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        const int righe = 10; // righe della mia tabella
        const int colonne = 10; // colonne della mia tabella
        const int navi = 5; // numero di navi che la mia flotta possiede

        int[,] mioCampo = new int[righe, colonne]; // Matrice che rappresenta il campo di gioco del giocatore
        int[,] campoAvv = new int[righe, colonne]; // Matrice che rappresenta il campo di gioco dell'avversario 
        Nave[] miaFlotta = new Nave[navi]; // Array di strutture che rappresenta la flotta del giocatore

        bool orizzontale = true; // Variabile per salvare l'orientamento scelto dall'utente
        bool[] naviPosizionate = new bool[navi]; // Mantiene traccia di quali navi sono già sulla griglia
        Random rnd = new Random(); // Oggetto Random per generare numeri casuali per il posizionamento automatico delle navi


        private void GraficaTabelle() // Funzione per aggiornare la grafica delle tabelle di gioco
        {
            char[] lettere = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'L' }; // Array di lettere per le intestazioni delle colonne
            tabellone.Text = "     A   B   C   D   E   F   G   H   I   L\r\n"; // Intestazione delle colonne per il tabellone del giocatore
            tabellone.Text += "   +---+---+---+---+---+---+---+---+---+---+\r\n"; // Riga di separazione iniziale



            for (int r = 0; r < righe; r++) // Ciclo per ogni riga della griglia
            {
                if (r + 1 < 10) // Aggiunge uno spazio per l'allineamento se il numero della riga è minore di 10
                    tabellone.Text += " " + (r + 1) + " |";
                else
                    tabellone.Text += (r + 1) + " |";

                for (int c = 0; c < colonne; c++) // Ciclo per ogni colonna della griglia
                {
                    if (mioCampo[r, c] == 0) tabellone.Text += "   |"; // TABELLA ALL'INIZIO: Casella vuota (0)
                    else if (mioCampo[r, c] == 1) tabellone.Text += " P |"; // Portaerei
                    else if (mioCampo[r, c] == 2) tabellone.Text += " C |"; // Corazzata
                    else if (mioCampo[r, c] == 3) tabellone.Text += "I1 |"; // Incrociatore 1
                    else if (mioCampo[r, c] == 4) tabellone.Text += "I2 |"; // Incrociatore 2
                    else if (mioCampo[r, c] == 5) tabellone.Text += "CP |"; // Cacciatorpediniere
                    else if (mioCampo[r, c] == 8) tabellone.Text += " O |"; // Acqua colpita
                    else if (mioCampo[r, c] == 9) tabellone.Text += " X |"; // Nave colpita
                }
                tabellone.Text += "\r\n   +---+---+---+---+---+---+---+---+---+---+\r\n"; // Riga di separazione tra le righe della griglia
            }

            

            tabelloneAvv.Text = "     A   B   C   D   E   F   G   H   I   L\r\n"; // Intestazione delle colonne per il tabellone dell'avversario
            tabelloneAvv.Text += "   +---+---+---+---+---+---+---+---+---+---+\r\n"; // Riga di separazione iniziale

            for (int r = 0; r < righe; r++) // Ciclo per ogni riga della griglia dell'avversario
            {
                if (r + 1 < 10) // Aggiunge uno spazio per l'allineamento se il numero della riga è minore di 10
                    tabelloneAvv.Text += " " + (r + 1) + " |";
                else
                    tabelloneAvv.Text += (r + 1) + " |";

                for (int c = 0; c < colonne; c++) // Ciclo per ogni colonna della griglia dell'avversario
                {
                    if (campoAvv[r, c] == 0) tabelloneAvv.Text += "   |"; // TABELLA ALL'INIZIO: Casella vuota(0)
                    else if (campoAvv[r, c] == 8) tabelloneAvv.Text += " O |"; // Acqua
                    else if (campoAvv[r, c] == 9) tabelloneAvv.Text += " X |"; // Colpito
                }
                tabelloneAvv.Text += "\r\n   +---+---+---+---+---+---+---+---+---+---+\r\n"; // Riga di separazione tra le righe della griglia dell'avversario
            }
        }





        private void InizializzaFlotta() // Funzione per dichiarare le navi della flotta e inizializzare le loro proprietà
        {
            
            miaFlotta[0].nome = "Portaerei"; // Dichiarazione Portaerei
            miaFlotta[0].dim = 5;
            miaFlotta[0].Coord = new Posizione[5];
            miaFlotta[0].colpiSubiti = new bool[5];
            miaFlotta[0].affondo = false;

            
            miaFlotta[1].nome = "Corazzata"; // Dichiarazione Corazzata
            miaFlotta[1].dim = 4;
            miaFlotta[1].Coord = new Posizione[4];
            miaFlotta[1].colpiSubiti = new bool[4];
            miaFlotta[1].affondo = false;

            
            miaFlotta[2].nome = "Incrociatore 1"; // Dichiarazione Incrociatore 1
            miaFlotta[2].dim = 3;
            miaFlotta[2].Coord = new Posizione[3];
            miaFlotta[2].colpiSubiti = new bool[3];
            miaFlotta[2].affondo = false;

            
            miaFlotta[3].nome = "Incrociatore 2"; // Dichiarazione Incrociatore 2
            miaFlotta[3].dim = 3;
            miaFlotta[3].Coord = new Posizione[3];
            miaFlotta[3].colpiSubiti = new bool[3];
            miaFlotta[3].affondo = false;

            
            miaFlotta[4].nome = "Cacciatorpediniere"; // Dichiarazione Cacciatorpediniere
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

            if (orizzontale == false && (inizio.Riga + dim > righe)) // Controlla se la nave esce dal campo in basso in verticale
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

                    for (int spostamentoRiga = -1; spostamentoRiga <= 1; spostamentoRiga++) // Ciclo per controllare le caselle vicine (inclusa quella stessa)
                    {
                        for (int spostamentoColonna = -1; spostamentoColonna <= 1; spostamentoColonna++) // Ciclo per controllare le caselle vicine (inclusa quella stessa)
                        {
                            int nr = r + spostamentoRiga; // Calcola la riga della casella vicina
                            int nc = c + spostamentoColonna; // Calcola la colonna della casella vicina

                            
                            if (nr >= 0 && nr < righe && nc >= 0 && nc < colonne) // Controlla che le coordinate della casella vicina siano valide (non fuori dai bordi)
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
            // 0 = acqua 
            // 1 = nave 
            // 8 = acqua già colpita
            // 9 = nave già colpita

            if (tabella[riga, colonna] == 0) // controlla se nella cella selezione c'è acqua quindi non c'è una nave(0)
            {
                tabella[riga, colonna] = 8; // la cella viene impostata a 8 per indicare acqua già colpita
                return "ACQUA"; // viene restituito il messaggio dell'esito del colpo
            }

            else if (tabella[riga, colonna] >= 1 && tabella[riga, colonna] <= 5) // controlla se nella cella selezionata c'è una nave (1)
            {
                int indiceNave = tabella[riga, colonna] - 1; // Calcola l'indice della nave colpita sottraendo 1 dal valore della cella (1-5)
                tabella[riga, colonna] = 9; // la cella viene impostata a 9 per indicare nave già colpita

                for (int i = 0; i < miaFlotta[indiceNave].dim; i++) // Ciclo per trovare quale segmento della nave è stato colpito
                {
                    if (miaFlotta[indiceNave].Coord[i].Riga == riga && miaFlotta[indiceNave].Coord[i].Colonna == colonna) // Controlla se le coordinate del segmento corrispondono a quelle del colpo
                    {
                        miaFlotta[indiceNave].colpiSubiti[i] = true;// Segna il segmento come colpito
                        break; // esce dal ciclo una volta trovato il segmento colpito
                    }
                }

                if (ControllaAffondato(indiceNave)) // Controlla se la nave è completamente affondata
                {
                    return miaFlotta[indiceNave].nome + " è stato colpito e AFFONDATO";
                }
                else
                {
                    return miaFlotta[indiceNave].nome + " è stato colpito";
                }

            }

            else if (tabella[riga, colonna] == 8 || tabella[riga, colonna] == 9) // si viene controllato se in quelle posizioni si è già stato sparato in precedenza (8 o 9)
            {
                return "hai già sparato in questa posizione"; // avvisa l'utente senza modificare la griglia
            }

            return "ERRORE"; // un ritorno per evitare errori 
        }

        private void Vittoria()
        {
            int caselleColpAvv = 0; // variabile per contare le caselle colpite dell'avversario

            for (int r = 0; r < righe; r++) 
            {
                for (int c = 0; c < colonne; c++) 
                {
                    if (campoAvv[r, c] == 9) // controlla se la casella è stata colpita (9)
                    {
                        caselleColpAvv++; //incrementa il contatore delle caselle colpite dell'avversario
                    }
                }
            }

            
            if (caselleColpAvv == 17) // controlla se tutte le caselle delle navi dell'avversario sono state colpite (17 caselle in totale)
            {
                MessageBox.Show("LE NAVI SONO STATE AFFONDATE, HAI VINTO");
            }

            int naviAffondate = 0; // Variabile per contare le navi affondate del giocatore
            int navi = 5; // Numero totale di navi del giocatore
            for (int i = 0; i < navi; i++) // Ciclo per scorrere tutte le navi del giocatore
            {
                if (miaFlotta[i].affondo == true) // Controlla se la nave è affondata
                {
                    naviAffondate++; // incrementa il contatore delle navi affondate del giocatore
                }
            }

            if (naviAffondate == navi) // controlla se tutte le navi del giocatore sono affondate (5 navi in totale)
            {
                MessageBox.Show("TUTTE LE TUE NAVI SONO STATE AFFONDATE, HAI PERSO"); 
            }
        }



        private void POSIZIONA_Click(object sender, EventArgs e)
        {
            if (Elenco.SelectedIndex == -1) //controlla se è stata selezionata una nave, se non è stata selezionata alcuna nave selection index sarà -1, quindi verra mostrato un messaggio di errore
            {
                MessageBox.Show("seleziona una nave dalla lista");
            }
            else
            {
                int indiceNave = Elenco.SelectedIndex; // recupera l'indice della nave selezionata dall'elenco

                if (naviPosizionate[indiceNave] == true) // controlla se la nave selezionata è già stata posizionata, se è già stata posizionata mostra un messaggio di errore
                {
                    MessageBox.Show("questa nave è già stata posizionata");
                    return;
                }

                string coordinata = posizione.Text; // prende il testo inserito dall'utente

                if (VerificaCoord(coordinata) == true) // se la coordinata è valida si procede con il posizionamento
                {
                    int riga; 
                    int colonna; 
                    ConversioneCoord(coordinata, out riga, out colonna); // converte la coordinata in numeri

                    Posizione inizio; // crea una variabile di tipo Posizione per memorizzare le coordinate iniziali
                    inizio.Riga = riga; // assegna la riga convertita alla variabile inizio
                    inizio.Colonna = colonna; // assegna la colonna convertita alla variabile inizio

                    if (PosNave(Elenco.SelectedIndex, inizio, orizzontale) == true) // Se la funzione PosNave restituisce true, il posizionamento è avvenuto con successo
                    {
                        naviPosizionate[indiceNave] = true; // aggiorna lo stato della nave come posizionata
                        MessageBox.Show("la nave selezionata è stata posizionata");
                        coordProprie.Text = ""; // Pulisce la casella di testo
                        cronologia.Text = cronologia.Text + "La nave " + miaFlotta[indiceNave].nome + " è stata posizionata in " + coordinata + "\r\n"; // Aggiunge un messaggio alla cronologia indicando la nave posizionata e la coordinata
                        GraficaTabelle(); // Aggiorna la grafica delle tabelle

                    }
                    else
                    {
                        MessageBox.Show("impossibile posizionare la nave");
                    }
                }
                else
                {
                    MessageBox.Show("la coordinata che è stata inserita non è valida");
                }
            }
        }





        private void RegistraColpoNave(int riga, int colonna) // funzione per registrare il colpo subito da una nave e controllare se è affondata
        {
            
            for (int i = 0; i < navi; i++) // Ciclo per scorrere tutte le navi della flotta
            {
                
                for (int j = 0; j < miaFlotta[i].dim; j++) // Ciclo per scorrere tutti i segmenti della nave corrente
                {
                    
                    if (miaFlotta[i].Coord[j].Riga == riga && miaFlotta[i].Coord[j].Colonna == colonna) // Controlla se le coordinate del segmento corrispondono a quelle del colpo
                    {
                        miaFlotta[i].colpiSubiti[j] = true; // Segna il segmento come colpito

                        
                        if (ControllaAffondato(i) == true) // Controlla se la nave è completamente affondata
                        {
                            MessageBox.Show("La tua nave " + miaFlotta[i].nome + " è stata AFFONDATA");
                        }
                        return; // trovata la nave si esce dalla funzione
                    }
                }
            }
        }





        private void verificaColpo_Click(object sender, EventArgs e) // Funzione per gestire il colpo dell'avversario e aggiornare la griglia di gioco
        {
            string coordinata = coordAvv.Text; // Prende la coordinata inserita dall'utente
            if (VerificaCoord(coordinata) == true) // Se la coordinata è valida, procede con la gestione del colpo
            {
                int riga, colonna; // Variabili per memorizzare le coordinate convertite
                ConversioneCoord(coordinata, out riga, out colonna); // Converte la coordinata in numeri
                string risultato = GestioneColpo(mioCampo, riga, colonna); // Controlla il colpo e aggiorna la griglia


                if (risultato == "colpito") // Se il risultato del colpo è "COLPITO", registra il colpo subito dalla nave
                {
                    RegistraColpoNave(riga, colonna); // Aggiorna la struct della nave e controlla l'affondamento
                }



                MessageBox.Show(risultato); // Mostra il risultato del colpo all'utente
                coordAvv.Text = ""; // Pulisce la casella di testo dopo il colpo

                if (risultato == "colpito" || risultato == "COLPITO" || risultato == "Colpito") // Se il risultato del colpo è "COLPITO", aggiorna la cronologia con il messaggio corrispondente
                {
                    cronologia.Text = cronologia.Text + "L'Avversario spara su " + coordinata + ": COLPITO\r\n";
                }
                else if (risultato == "acqua" || risultato == "ACQUA" || risultato == "Acqua")
                {
                    cronologia.Text = cronologia.Text + "L'Avversario spara su " + coordinata + ": ACQUA\r\n";
                }
                GraficaTabelle(); // Aggiorna la grafica delle tabelle dopo il colpo

            }
            else
            {
                MessageBox.Show("la coordinata dell'avversario non è valida"); // Avvisa l'utente che la coordinata inserita non è valida
            }

            Vittoria(); // Controlla se c'è una vittoria o una sconfitta dopo il colpo dell'avversario
        }





        private void acqua_Click(object sender, EventArgs e) // Funzione per registrare un colpo d'acqua dell'avversario e aggiornare la griglia di gioco
        {
            string coordinata = coordProprie.Text; // Prende la coordinata inserita dall'utente

            if (VerificaCoord(coordinata)) // Se la coordinata è valida, procede con la registrazione del colpo d'acqua
            {
                ConversioneCoord(coordinata, out int riga, out int colonna); // Converte la coordinata in numeri

                
                if (campoAvv[riga, colonna] != 0) // Controlla se la casella è già stata usata (diversa da 0)
                {
                    MessageBox.Show("hai già colpito in questa posizione");
                    return;
                }

                campoAvv[riga, colonna] = 8; // 8 = Acqua ('O') per indicare che la casella è stata colpita e non c'è una nave
                coordProprie.Text = "";
                cronologia.Text = cronologia.Text+ "il mio attacco su " + coordinata + ": ACQUA\r\n"; // Aggiorna la cronologia con il messaggio corrispondente
                GraficaTabelle();
                Vittoria(); // Controlla se c'è una vittoria o una sconfitta dopo il colpo subito
            }
            else
            {
                MessageBox.Show("la coordinata non è valida");
            }
        }





        private void colpito_Click(object sender, EventArgs e)// Funzione per registrare un colpo subito da una nave dell'avversario e aggiornare la griglia di gioco
        {
            string coordinata = coordProprie.Text; // Prende la coordinata inserita dall'utente

            if (VerificaCoord(coordinata)) // Se la coordinata è valida, procede con la registrazione del colpo subito
            {
                ConversioneCoord(coordinata, out int riga, out int colonna); // Converte la coordinata in numeri

                if (campoAvv[riga, colonna] != 0) // Controlla se la casella è già stata usata (diversa da 0)
                {
                    MessageBox.Show("hai già colpito in questa posizione");
                    return;
                }

                campoAvv[riga, colonna] = 9;// 9 = Colpito ('X') per indicare che la casella è stata colpita e c'è una nave
                coordProprie.Text = "";
                cronologia.Text = cronologia.Text + "il mio attacco su " + coordinata + ": COLPITO\r\n"; // Aggiorna la cronologia con il messaggio corrispondente
                GraficaTabelle(); // Aggiorna la grafica delle tabelle dopo il colpo
                Vittoria(); // Controlla se c'è una vittoria o una sconfitta dopo il colpo subito
            }
            else
            {
                MessageBox.Show("la coordinata non è valida"); 
            }
           

        }





        private void Orrizzontale_Click(object sender, EventArgs e) // Funzione per impostare l'orientamento delle navi su Orizzontale
        {
            orizzontale = true; // Imposta l'orientamento a Orizzontale
            MessageBox.Show("Orientamento impostato su: Orizzontale"); 
        }


        private void Verticale_Click(object sender, EventArgs e) // Funzione per impostare l'orientamento delle navi su Verticale
        {
            orizzontale = false; // Imposta l'orientamento a Verticale
            MessageBox.Show("Orientamento impostato su: Verticale");
        }






        private void Form1_Load(object sender, EventArgs e) // Funzione che viene eseguita quando il form viene caricato
        {
            InizializzaFlotta(); // prepara le navi all'avvio

            Elenco.Items.Clear(); // Pulisce l'elenco delle navi prima di aggiungere le nuove voci
            Elenco.Items.Add("Portaerei (5)"); // Aggiunge le navi all'elenco con il loro nome e dimensione
            Elenco.Items.Add("Corazzata (4)"); // Aggiunge le navi all'elenco con il loro nome e dimensione
            Elenco.Items.Add("Incrociatore 1 (3)"); // Aggiunge le navi all'elenco con il loro nome e dimensione
            Elenco.Items.Add("Incrociatore 2 (3)"); // Aggiunge le navi all'elenco con il loro nome e dimensione
            Elenco.Items.Add("Cacciatorpediniere (2)"); // Aggiunge le navi all'elenco con il loro nome e dimensione

            GraficaTabelle(); // Aggiorna la grafica delle tabelle all'avvio del form
        }





        private void generaNavi_Click(object sender, EventArgs e) // Funzione per generare automaticamente le navi in posizioni casuali
        {
   
            mioCampo = new int[righe, colonne]; // Reimposta la matrice del campo da gioco a una nuova matrice vuota (tutte le celle a 0)
            for (int i = 0; i < navi; i++) // Ciclo per impostare tutte le navi come non posizionate
            {
                naviPosizionate[i] = false; // Imposta lo stato di posizionamento della nave a false (non posizionata)
                miaFlotta[i].affondo = false; // Imposta lo stato di affondamento della nave a false (non affondata)
                for (int k = 0; k < miaFlotta[i].dim; k++) // Ciclo per impostare tutti i segmenti della nave come non colpiti
                {
                    miaFlotta[i].colpiSubiti[k] = false; // Imposta lo stato di colpo del segmento della nave a false (non colpito)
                }
            }

            for (int i = 0; i < navi; i++) // Ciclo per posizionare automaticamente ciascuna nave
            {
                bool posizionamento = false; // Variabile di supporto per indicare se la nave è stata posizionata correttamente

                while (posizionamento == false) // Ciclo finché la nave non viene posizionata correttamente
                {
                    int r = rnd.Next(0, righe); // Genera un numero casuale per la riga (da 0 a righe-1)
                    int c = rnd.Next(0, colonne); // Genera un numero casuale per la colonna (da 0 a colonne-1)
                    bool orizzontale = rnd.Next(0, 2) == 0; // Genera un valore casuale per l'orientamento della nave (true = orizzontale, false = verticale)

                    Posizione p = new Posizione { Riga = r, Colonna = c }; // Crea una nuova posizione con le coordinate casuali generate

                    if (PosNave(i, p, orizzontale)) // Chiama la funzione PosNave per tentare di posizionare la nave nella posizione casuale generata
                    {
                        naviPosizionate[i] = true; // Aggiorna lo stato della nave come posizionata
                        posizionamento = true; // Imposta la variabile di supporto a true per uscire dal ciclo while
                    }
                }
            }
            cronologia.Text = cronologia.Text + "Navi posizionate automaticamente\r\n"; // Aggiorna la cronologia con il messaggio corrispondente
            GraficaTabelle(); // Aggiorna la grafica delle tabelle dopo il posizionamento automatico delle navi
        }





        private string ConvertiInStringaCoord(int riga, int colonna) // Funzione per convertire le coordinate numeriche in una stringa di coordinate leggibile (es. A1, B2, ecc.)
        {
            char[] lettere = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'L' }; // Array di lettere corrispondenti alle colonne della griglia
            int numeroRiga = riga + 1; // Aggiunge 1 alla riga per ottenere il numero corretto (da 1 a 10 invece di 0 a 9)
            return "" + lettere[colonna] + numeroRiga; // Restituisce la stringa di coordinate combinando la lettera della colonna e il numero della riga
        }





        private void suggerimento_Click(object sender, EventArgs e) // Funzione per fornire un suggerimento di tiro all'utente
        {
            for (int r = 0; r < righe; r++) // Ciclo per ogni riga della griglia dell'avversario
            {
                for (int c = 0; c < colonne; c++) // Ciclo per ogni colonna della griglia dell'avversario
                {
                    if (campoAvv[r, c] == 9) // Controlla se la casella è stata colpita (9)
                    {
                        if (r > 0 && campoAvv[r - 1, c] == 0) // Controlla se la casella sopra è disponibile (0)
                        {
                            coordProprie.Text = ConvertiInStringaCoord(r - 1, c); // Converte le coordinate in stringa e le assegna alla casella di testo per il suggerimento
                            return;
                        }

                        if (r < 9 && campoAvv[r + 1, c] == 0) // Controlla se la casella sotto è disponibile (0)
                        {
                            coordProprie.Text = ConvertiInStringaCoord(r + 1, c); // Converte le coordinate in stringa e le assegna alla casella di testo per il suggerimento
                            return;
                        }

                        if (c > 0 && campoAvv[r, c - 1] == 0) // Controlla se la casella a sinistra è disponibile (0)
                        {
                            coordProprie.Text = ConvertiInStringaCoord(r, c - 1); // Converte le coordinate in stringa e le assegna alla casella di testo per il suggerimento
                            return;
                        }

                        if (c < 9 && campoAvv[r, c + 1] == 0)// Controlla se la casella a destra è disponibile (0)
                        {
                            coordProprie.Text = ConvertiInStringaCoord(r, c + 1); // Converte le coordinate in stringa e le assegna alla casella di testo per il suggerimento
                            return;
                        }
                    }
                }
            }

            int rigaCasuale; 
            int colonnaCasuale; 
            do
            {
                rigaCasuale = rnd.Next(0, 10); // genera un numero casuale per la riga (da 0 a 9)
                colonnaCasuale = rnd.Next(0, 10); // genera un numero casuale per la colonna (da 0 a 9) 
            }
            while (campoAvv[rigaCasuale, colonnaCasuale] != 0); // continua a generare nuove coordinate casuali finché non trova una casella disponibile (0)

            coordProprie.Text = ConvertiInStringaCoord(rigaCasuale, colonnaCasuale); // converte le coordinate casuali in stringa e le assegna alla casella di testo per il suggerimento
        }

    }
}

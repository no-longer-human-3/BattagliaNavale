using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Battaglia_Navale_Lasku_Pagliuca
{
    public struct Posizione // Struttura per rappresentare la posizione di un quadratino
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
        Nave[] miaFlotta = new Nave[navi];

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
                    int r = orizzontale ? inizio.Riga : inizio.Riga + i; // Calcola la riga (avanza solo se verticale)
                    int c = orizzontale ? inizio.Colonna + i : inizio.Colonna; // Calcola la colonna (avanza solo se orizzontale)

                    if (mioCampo[r, c] != 0) // Controlla se nella matrice la casella è già occupata (diverso da 0)
                    {
                        esito = false; // Trovata casella occupata: imposta esito a false
                    }
                }
            }

            if (esito == true) // Se tutti i controlli sono superati, salva la nave
            {
                for (int i = 0; i < dim; i++) // Ciclo per scrivere la nave nel campo e nella struttura
                {
                    int r = orizzontale ? inizio.Riga : inizio.Riga + i; // Ricalcola la riga per la casella corrente
                    int c = orizzontale ? inizio.Colonna + i : inizio.Colonna; // Ricalcola la colonna per la casella corrente

                    mioCampo[r, c] = 1; // Segna la casella della matrice come occupata da nave (1)
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
                    riga = c; // Se la lettera coincide, assegna a riga l'indice dell'array
                }
            }

            if (coordinate.Length == 2) // controlla se la coordinata è lunga 2 caratteri
            {
                char[] num= { '1', '2', '3', '4', '5', '6', '7', '8', '9' }; // Array contenente i caratteri dei numeri da 1 a 9
                for (int i = 0; i < num.Length; i++) // Scorre l'array dei numeri dal'inizio alla fine
                {
                    if (coordinate[1] == num[i]) // controlla se il secondo carattere della coordinata equivale al numero dell'array
                    {
                        colonna = i; // se il numero coincide, assegna a colonna l'indice dell'array
                    }
                }
            }
            else if (coordinate.Length == 3) // controlla se la coordinata è lunga 3 caratteri
            {
                colonna = 9; // la colonna viene impostata subito a 9 (l'ultima ) poichè il numero massimo è 10
            }

        }

        private string GestioneColpo(int[,] tabella, int riga, int colonna) // funzione che controlla il colpo e aggiorna la griglia in base all'esito
        { 
            //(0 = acqua , 1 = nave , 2 = acqua già colpita, 3 = nave già colpita)
            
            if (tabella[riga, colonna] == 0) // controlla se nella cella selezione c'è acqua quindi non c'è una nave(0)
            {
                tabella[riga, colonna] = 2; // la cella viene impostata a 2 per indicare acqua già colpita
                return "ACQUA"; // Viene restituito il messaggio dell'esito del colpo
            }
            
            else if (tabella[riga, colonna] == 1) // controlla se nella cella selezionata c'è una nave (1)
            {
                tabella[riga, colonna] = 3; // la cella viene impostata a 3 per indicare nave già colpita
                return "COLPITO"; //Viene restituito il messaggio dell'esito del colpo
            }
            
            else if (tabella[riga, colonna] == 2 || tabella[riga, colonna] == 3) // si viene controllato se in quelle posizioni si è già stato sparato in precedenza (2 o 3)
            {
                return "HAI GIA SPARATO QUI IN QUESTA POSIZIONE"; // Avvisa l'utente senza modificare la griglia
            }

            return "ERRORE"; // un ritorno per evitare errori 
        }


        private void Elenco_SelectedIndexChanged(object sender, EventArgs e)
        {
            Elenco.Items.Clear();
            Elenco.Items.Add("Portaerei (5)");
            Elenco.Items.Add("Corazzata (4)");
            Elenco.Items.Add("Incrociatore 1 (3)");
            Elenco.Items.Add("Incrociatore 2 (3)");
            Elenco.Items.Add("Cacciatorpediniere (2)");
        }
    }
}

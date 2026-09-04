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

            // 4. PosizionaNave(...)
            // 6. ControllaAffondato(...)

        }

        private bool VerificaCoordinate(string coordinate) // Funzione per verificare le coordinate inserite dall'utente
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

        private void ConversioneCoordinate(string coordinate, out int riga, out int colonna) // funzione che mi converte le coordinate inserite dall'utente in coordinate numeriche poichè il computer non riesce a leggere le lettere quindi le converte in numeri
        {
            riga = -1; // valore di sicurezza per la riga, se non vengono trovate le coordinate corrette rimangono a -1
            colonna = -1; // valore di sicurezza per la colonna, se non vengono trovate le coordinate corrette rimangono a -1
            char[] lettereMaiuscole = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'L' }; // array di lettere maiuscole valide per la prima lettera della coordinata
            char[] lettereMinuscole = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'l' }; // array di lettere minuscole valide per la prima lettera della coordinata

            for (int i = 0; i < lettereMaiuscole.Length; i++) // Scorre l'array delle lettere una alla volta, dall'inizio alla fine
            {
                
                if (coordinate[0] == lettereMaiuscole[i] || coordinate[0] == lettereMinuscole[i]) // controlla se la prima lettera della coordinata inserita dall'utente è uguale a una delle lettere negli array delle maiuscole o delle minuscole
                {
                    riga = i; // Se la lettera coincide, assegna a riga l'indice dell'array
                }
            }

            if (coordinate.Length == 2) // controlla se la coordinata è lunga 2 caratteri
            {
                char[] numeri = { '1', '2', '3', '4', '5', '6', '7', '8', '9' }; // Array contenente i caratteri dei numeri da 1 a 9
                for (int j = 0; j < numeri.Length; j++) // Scorre l'array dei numeri dal'inizio alla fine
                {
                    if (coordinate[1] == numeri[j]) // controlla se il secondo carattere della coordinata equivale al numero dell'array
                    {
                        colonna = j; // se il numero coincide, assegna a colonna l'indice dell'array
                    }
                }
            }
            else if (coordinate.Length == 3) // controlla se la coordinata è lunga 3 caratteri
            {
                colonna = 9; // la colonna viene impostata subito a 9 (l'ultima ) poichè il numero massimo è 10
            }

        }

        private void gestisciColpo() 
        {

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

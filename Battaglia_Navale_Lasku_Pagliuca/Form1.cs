namespace Battaglia_Navale_Lasku_Pagliuca
{
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
           
            if (coordinate.Length < 2 || coordinate.Length > 3)
            {
                return false;
            }
            char[] charValide = { 'A', 'a', 'B', 'b', 'C', 'c', 'D', 'd', 'E', 'e', 'F', 'f', 'G', 'g', 'H', 'h', 'I', 'i', 'L', 'l' };
            bool charValida = false;

            
            for (int i = 0; i < charValide.Length; i++)
            {
                if (coordinate[0] == charValide[i])
                {
                    charValida = true;
                    break; 
                }
            }

            
            if (charValida == false)
            {
                return false;
            }

          
            if (coordinate.Length == 2)
            {
                if (coordinate[1] >= '1' && coordinate[1] <= '9')
                {
                    return true;
                }
            }

            
            if (coordinate.Length == 3)
            {
                if (coordinate[1] == '1' && coordinate[2] == '0')
                {
                    return true;
                }
            }

            return false;



            // 3. ConvertiCoordinate(...)
            // 5. GestisciColpo(...)
        }

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
}

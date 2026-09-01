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

        // ==========================================
        // PARTE DEL PROGRAMMATORE 1
        // ==========================================

        private void InizializzaFlotta()
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


            // ==========================================
            // PARTE DEL PROGRAMMATORE 2
            // ==========================================

            // 2. VerificaCoordinate(...)
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

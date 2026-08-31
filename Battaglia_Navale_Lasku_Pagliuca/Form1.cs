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

        // 1. InizializzaFlotta()
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

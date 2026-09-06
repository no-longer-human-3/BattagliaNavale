namespace Battaglia_Navale_Lasku_Pagliuca
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            pictureBox2 = new PictureBox();
            pannello_di_gioco = new GroupBox();
            colpito = new Button();
            acqua = new Button();
            POSIZIONA = new Button();
            Verticale = new Button();
            Orrizzontale = new Button();
            label46 = new Label();
            label45 = new Label();
            posizione = new TextBox();
            label44 = new Label();
            Elenco = new ListBox();
            cronologia = new TextBox();
            label3 = new Label();
            verificaColpo = new Button();
            coordAvv = new MaskedTextBox();
            label2 = new Label();
            coordProprie = new MaskedTextBox();
            label1 = new Label();
            NostroCampo = new Label();
            CampoAvversario = new Label();
            tabelloneAvv = new TextBox();
            tabellone = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            pannello_di_gioco.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(349, 11);
            pictureBox2.Margin = new Padding(2);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(881, 68);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 3;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // pannello_di_gioco
            // 
            pannello_di_gioco.Controls.Add(colpito);
            pannello_di_gioco.Controls.Add(acqua);
            pannello_di_gioco.Controls.Add(POSIZIONA);
            pannello_di_gioco.Controls.Add(Verticale);
            pannello_di_gioco.Controls.Add(Orrizzontale);
            pannello_di_gioco.Controls.Add(label46);
            pannello_di_gioco.Controls.Add(label45);
            pannello_di_gioco.Controls.Add(posizione);
            pannello_di_gioco.Controls.Add(label44);
            pannello_di_gioco.Controls.Add(Elenco);
            pannello_di_gioco.Controls.Add(cronologia);
            pannello_di_gioco.Controls.Add(label3);
            pannello_di_gioco.Controls.Add(verificaColpo);
            pannello_di_gioco.Controls.Add(coordAvv);
            pannello_di_gioco.Controls.Add(label2);
            pannello_di_gioco.Controls.Add(coordProprie);
            pannello_di_gioco.Controls.Add(label1);
            pannello_di_gioco.Location = new Point(564, 94);
            pannello_di_gioco.Name = "pannello_di_gioco";
            pannello_di_gioco.Size = new Size(413, 672);
            pannello_di_gioco.TabIndex = 5;
            pannello_di_gioco.TabStop = false;
            pannello_di_gioco.Text = "Pannello di Gioco";
            // 
            // colpito
            // 
            colpito.Font = new Font("Bodoni MT Condensed", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            colpito.ForeColor = Color.Navy;
            colpito.Location = new Point(235, 89);
            colpito.Name = "colpito";
            colpito.Size = new Size(152, 55);
            colpito.TabIndex = 53;
            colpito.Text = "COLPITO";
            colpito.UseVisualStyleBackColor = true;
            colpito.Click += colpito_Click;
            // 
            // acqua
            // 
            acqua.Font = new Font("Bodoni MT Condensed", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            acqua.ForeColor = Color.Navy;
            acqua.Location = new Point(27, 89);
            acqua.Name = "acqua";
            acqua.Size = new Size(152, 55);
            acqua.TabIndex = 24;
            acqua.Text = "ACQUA";
            acqua.UseVisualStyleBackColor = true;
            acqua.Click += acqua_Click;
            // 
            // POSIZIONA
            // 
            POSIZIONA.Font = new Font("Bodoni MT Condensed", 21F, FontStyle.Bold);
            POSIZIONA.ForeColor = Color.Navy;
            POSIZIONA.Location = new Point(10, 441);
            POSIZIONA.Margin = new Padding(2);
            POSIZIONA.Name = "POSIZIONA";
            POSIZIONA.Size = new Size(387, 51);
            POSIZIONA.TabIndex = 23;
            POSIZIONA.Text = "POSIZIONA!";
            POSIZIONA.UseVisualStyleBackColor = true;
            POSIZIONA.Click += POSIZIONA_Click;
            // 
            // Verticale
            // 
            Verticale.Font = new Font("Bodoni MT Condensed", 13F, FontStyle.Bold);
            Verticale.ForeColor = Color.Navy;
            Verticale.Location = new Point(190, 406);
            Verticale.Margin = new Padding(2);
            Verticale.Name = "Verticale";
            Verticale.Size = new Size(207, 29);
            Verticale.TabIndex = 22;
            Verticale.Text = "VERTICALE";
            Verticale.UseVisualStyleBackColor = true;
            Verticale.Click += Verticale_Click;
            // 
            // Orrizzontale
            // 
            Orrizzontale.Font = new Font("Bodoni MT Condensed", 13F, FontStyle.Bold);
            Orrizzontale.ForeColor = Color.Navy;
            Orrizzontale.Location = new Point(190, 373);
            Orrizzontale.Margin = new Padding(2);
            Orrizzontale.Name = "Orrizzontale";
            Orrizzontale.Size = new Size(208, 29);
            Orrizzontale.TabIndex = 21;
            Orrizzontale.Text = "ORIZZONTALE";
            Orrizzontale.UseVisualStyleBackColor = true;
            Orrizzontale.Click += Orrizzontale_Click;
            // 
            // label46
            // 
            label46.AutoSize = true;
            label46.Location = new Point(203, 352);
            label46.Margin = new Padding(2, 0, 2, 0);
            label46.Name = "label46";
            label46.Size = new Size(184, 20);
            label46.TabIndex = 20;
            label46.Text = "Come la vuoi posizionare?";
            // 
            // label45
            // 
            label45.AutoSize = true;
            label45.Location = new Point(6, 494);
            label45.Name = "label45";
            label45.Size = new Size(381, 20);
            label45.TabIndex = 19;
            label45.Text = "--------------------------------------------------------------";
            // 
            // posizione
            // 
            posizione.Location = new Point(191, 321);
            posizione.Margin = new Padding(2);
            posizione.Name = "posizione";
            posizione.PlaceholderText = "Inserisci la posizione (es. A1)";
            posizione.Size = new Size(209, 27);
            posizione.TabIndex = 18;
            // 
            // label44
            // 
            label44.AutoSize = true;
            label44.Location = new Point(10, 292);
            label44.Margin = new Padding(2, 0, 2, 0);
            label44.Name = "label44";
            label44.Size = new Size(199, 20);
            label44.TabIndex = 17;
            label44.Text = "Seleziona la nave dalla lista: ";
            // 
            // Elenco
            // 
            Elenco.Font = new Font("Segoe UI", 9F);
            Elenco.FormattingEnabled = true;
            Elenco.Items.AddRange(new object[] { "Portaerei (5)", "Corazzata (4)", "Incrociatore 1 (3)", "Incrociatore 2 (3)", "Cacciatorpediniere (2)" });
            Elenco.Location = new Point(10, 314);
            Elenco.Margin = new Padding(2);
            Elenco.Name = "Elenco";
            Elenco.Size = new Size(179, 124);
            Elenco.TabIndex = 16;
            // 
            // cronologia
            // 
            cronologia.Font = new Font("Segoe UI", 9F);
            cronologia.Location = new Point(9, 512);
            cronologia.Multiline = true;
            cronologia.Name = "cronologia";
            cronologia.PlaceholderText = "Cronologia";
            cronologia.Size = new Size(391, 155);
            cronologia.TabIndex = 14;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(9, 271);
            label3.Name = "label3";
            label3.Size = new Size(381, 20);
            label3.TabIndex = 13;
            label3.Text = "--------------------------------------------------------------";
            // 
            // verificaColpo
            // 
            verificaColpo.Font = new Font("Bodoni MT Condensed", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            verificaColpo.ForeColor = Color.Navy;
            verificaColpo.Location = new Point(112, 209);
            verificaColpo.Name = "verificaColpo";
            verificaColpo.Size = new Size(197, 59);
            verificaColpo.TabIndex = 12;
            verificaColpo.Text = "VERIFICA COLPO";
            verificaColpo.UseVisualStyleBackColor = true;
            verificaColpo.Click += verificaColpo_Click;
            // 
            // coordAvv
            // 
            coordAvv.Location = new Point(9, 179);
            coordAvv.Name = "coordAvv";
            coordAvv.Size = new Size(390, 27);
            coordAvv.TabIndex = 11;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(8, 156);
            label2.Name = "label2";
            label2.Size = new Size(397, 20);
            label2.TabIndex = 10;
            label2.Text = "Coordinata sparata dall'avversario---------------------------";
            // 
            // coordProprie
            // 
            coordProprie.Location = new Point(10, 53);
            coordProprie.Name = "coordProprie";
            coordProprie.Size = new Size(390, 27);
            coordProprie.TabIndex = 9;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 30);
            label1.Name = "label1";
            label1.Size = new Size(397, 20);
            label1.TabIndex = 8;
            label1.Text = "Coordinata da sparare----------------------------------------";
            // 
            // NostroCampo
            // 
            NostroCampo.AutoSize = true;
            NostroCampo.Font = new Font("Bodoni MT Condensed", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            NostroCampo.ForeColor = Color.Navy;
            NostroCampo.Location = new Point(171, 119);
            NostroCampo.Name = "NostroCampo";
            NostroCampo.Size = new Size(196, 47);
            NostroCampo.TabIndex = 6;
            NostroCampo.Text = "IL TUO CAMPO";
            // 
            // CampoAvversario
            // 
            CampoAvversario.AutoSize = true;
            CampoAvversario.Font = new Font("Bodoni MT Condensed", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CampoAvversario.ForeColor = Color.Navy;
            CampoAvversario.Location = new Point(1137, 119);
            CampoAvversario.Name = "CampoAvversario";
            CampoAvversario.Size = new Size(279, 47);
            CampoAvversario.TabIndex = 7;
            CampoAvversario.Text = "CAMPO AVVERSARIO";
            // 
            // tabelloneAvv
            // 
            tabelloneAvv.Font = new Font("Courier New", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tabelloneAvv.Location = new Point(1005, 209);
            tabelloneAvv.Multiline = true;
            tabelloneAvv.Name = "tabelloneAvv";
            tabelloneAvv.ReadOnly = true;
            tabelloneAvv.Size = new Size(505, 469);
            tabelloneAvv.TabIndex = 51;
            // 
            // tabellone
            // 
            tabellone.Font = new Font("Courier New", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tabellone.Location = new Point(24, 203);
            tabellone.Multiline = true;
            tabellone.Name = "tabellone";
            tabellone.ReadOnly = true;
            tabellone.Size = new Size(505, 469);
            tabellone.TabIndex = 52;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(1531, 784);
            Controls.Add(tabellone);
            Controls.Add(tabelloneAvv);
            Controls.Add(CampoAvversario);
            Controls.Add(NostroCampo);
            Controls.Add(pannello_di_gioco);
            Controls.Add(pictureBox2);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            pannello_di_gioco.ResumeLayout(false);
            pannello_di_gioco.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private PictureBox pictureBox2;
        private GroupBox pannello_di_gioco;
        private Label NostroCampo;
        private Label CampoAvversario;
        private Label label1;
        private MaskedTextBox coordProprie;
        private Label label2;
        private TextBox cronologia;
        private Label label3;
        private Button verificaColpo;
        private MaskedTextBox coordAvv;
        private TextBox posizione;
        private ListBox Elenco;
        private Label label44;
        private Button Verticale;
        private Button Orrizzontale;
        private Label label46;
        private Label label45;
        private Button POSIZIONA;
        private TextBox tabelloneAvv;
        private TextBox tabellone;
        private Button acqua;
        private Button colpito;
    }
}

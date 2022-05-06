namespace jogodavelha
{
    public partial class Form1 : Form
    {
        int pontoX, pontoO, ties, rodadas = 0;

        private void button10_Click(object sender, EventArgs e)
        {
            //limpar campos
            button1.Text = "";
            button2.Text = "";
            button3.Text = "";
            button4.Text = "";
            button5.Text = "";
            button6.Text = "";
            button7.Text = "";
            button8.Text = "";
            button9.Text = "";

            //nova rodada, começar um novo jogo
            rodadas = 0;
            jogo_final = false;
            for (int i = 0; i < 9; i++)
            {
                texto[i] = "";   
            }


        }

        bool turn = true, jogo_final = false;
        string[] texto = new string[9];
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //configurando os botões
            Button button1 = (Button)sender;
            int buttonIndex = button1.TabIndex;
            if (button1.Text == "" && jogo_final == false)
            {
                //checar de qual o jogador da rodada
                if (turn)
                {
                    button1.Text = "X";
                    texto[buttonIndex] = button1.Text;
                    rodadas++;
                    turn = !turn;
                    Checagem(1);
                }
                else
                {
                    button1.Text = "O";
                    texto[buttonIndex] = button1.Text;
                    rodadas++;
                    turn = !turn;
                    Checagem(2);
                }
            }
        }

        void Vencedor(int PlayerWin)
        {
            // adicionar pontos ao vencedor da rodada ou ao numero de empates
            jogo_final = true;
            if(PlayerWin == 1)
            {
                pontoX++;
                label4.Text = Convert.ToString(pontoX);
                MessageBox.Show("Jogador X Ganhou");
                turn = true;
            }
            else
            {
                pontoO++;
                label5.Text = Convert.ToString(pontoO);
                MessageBox.Show("Jogador O Ganhou");
                turn = false;
            }
        }

        void Checagem(int ChecarPlayer)
        {
            
            string suporte = "";
            if (ChecarPlayer == 1)
            {
                suporte = "X";
            }
            else
            {
                suporte = "O";
            }
            //checagem de vitória horizontal
            for (int horizontal = 0; horizontal < 8; horizontal += 3)
            {
                if (suporte == texto[horizontal])
                {
                    
                    if (texto[horizontal] == texto[horizontal + 1] && texto[horizontal] == texto[horizontal + 2])
                    {
                        Vencedor(ChecarPlayer);
                        return;
                    }
                }
            } 
            // checagem de vitória vertical
            for (int vertical = 0; vertical < 3; vertical ++)
            {
                if (suporte == texto[vertical])
                {
                    
                    if (texto[vertical] == texto[vertical + 3] && texto[vertical] == texto[vertical + 6])
                    {
                        Vencedor(ChecarPlayer);
                        return;
                    }
                }
            } 

            // checagem de vitória diagonal
            if (texto[0] == suporte)
            if (texto[0] == texto[4] && texto[0] == texto[8])
            {
                    Vencedor(ChecarPlayer);
                    return;
            }
            if (texto[2] == suporte)
            {
                if (texto[2] == texto[4] && texto[2] == texto[6])
                {
                    Vencedor(ChecarPlayer);
                    return;
                }
            }
            if (rodadas == 9 && jogo_final == false)
            {
                ties++;
                label6.Text = Convert.ToString(ties);
                MessageBox.Show("Empate!");
                jogo_final = true;
                return;
            }
        }
    }
}


                
        
            
        
    
    


 


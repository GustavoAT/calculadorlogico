﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

/* Autor: Gustavo Almeida   Data: 13/04/2013  Pojuca - BA
 * Esta aplicação recebe uma expressão de lógica matemática e elabora a tabela verdade 
 * correspondente a a expressao e mostra na tela
 */

namespace calculador_logico
{
    public partial class TabVjanela : Form
    {
        protected string alf = "abcdefghijklmnopqrstuvxywz!", cn = "˄˅ṿ→↔", sp = "([{)]}";//Strings que definem quais caracteres podem ser usados
        
        public TabVjanela()
        {
            InitializeComponent();
        }

        #region Botões dos operadores
        private void BTconj_Click(object sender, EventArgs e)
        {
            TBexpressao.Paste(BTconj.Text);
            TBexpressao.Focus();
        }

        private void BTdisj_Click(object sender, EventArgs e)
        {
            TBexpressao.Paste(BTdisj.Text);
            TBexpressao.Focus();
        }

        private void BTdisjx_Click(object sender, EventArgs e)
        {
            TBexpressao.Paste(BTdisjx.Text);
            TBexpressao.Focus();
        }

        private void BTcond_Click(object sender, EventArgs e)
        {
            TBexpressao.Paste(BTcond.Text);
            TBexpressao.Focus();
        }

        private void BTbicond_Click(object sender, EventArgs e)
        {
            TBexpressao.Paste(BTbicond.Text);
            TBexpressao.Focus();
        }
        #endregion

        private void Btgertab_Click(object sender, EventArgs e)//Método chamado pelo botão gerar tabela
        {
            try
            {
                verificarexpressao(TBexpressao.Text);
                TBexpressao.Text = corrigirniveis(TBexpressao.Text);
                calcular(TBexpressao.Text);
            }
            catch (ApplicationException er)
            {
                MessageBox.Show("Erros na expressão:\n" + er.Message, "Atenção!");
            }
        }

        protected void verificarexpressao(string expr)//Garante a validez da expressão
        {           
            string erros = "";//String que armazenará os possíveis erros;
            List<int> indsep = new List<int>();//Lista auxiliar para checagem dos separadores
            if (expr.Length < 3 || !expr.Any(e => cn.Contains(e)))//Uma mínima expressão precisa ter esses requisitos (duas proposições e uma conjunção)
            {
                erros += "A expressão está incompleta.\n";
            }
            for (int ctd = 0; ctd < expr.Length; ctd++)//Percorre toda a expressão caractere por caractere
            {
                if (!(alf + cn + sp).Contains(expr.ElementAt(ctd)))//Checa se é válido
                {
                    erros += "O caractere " + expr.ElementAt(ctd) + " na posição " + (ctd + 1) + " não é válido.\n";
                }
                if (cn.Contains(expr.ElementAt(ctd)))//Para conectivos
                {
                    if (ctd == 0 || ctd == expr.Length - 1)//Conectivo no início ou no fim da expressão
                    {
                        erros += "Posicionamento incorreto do conectivo \"" + expr.ElementAt(ctd) + "\" na posição " + (ctd + 1) + "\n";
                    }
                    else if (("([{~").Contains(expr.ElementAt(ctd - 1)) || (")]}").Contains(expr.ElementAt(ctd + 1)))//Se o conectivo estiver entre dois separadores se proposições
                    {
                        erros += "Falta uma proposição antes ou depois do conectivo \"" + expr.ElementAt(ctd) + "\" na posição " + (ctd + 1) + "\n";
                    }else
                    if (cn.Contains(expr.ElementAt(ctd)) && (expr.ElementAt(ctd - 1).Equals(expr.ElementAt(ctd + 1))))//Para proposições repetidas no mesmo teste lógico
                    {
                        erros += "Uso redundante de proposição no conectivo \"" + expr.ElementAt(ctd) + "\" na posição " + (ctd + 1) + "\n";
                    }
                }
                if (sp.Substring(0, 3).Contains(expr.ElementAt(ctd)))//Para os separadores ([{
                {
                    if (sp.Substring(3, 3).Contains(expr.ElementAt(ctd + 1)) || ctd == expr.Length - 1)
                    {
                        erros += "Separador não utilizado na posição " + (ctd + 1) + "\n";
                    }
                    indsep.Add(ctd);
                    
                }
                if (sp.Substring(3, 3).Contains(expr.ElementAt(ctd)))//Para os separadores )]}
                {
                    if (ctd == 0)
                    {
                        erros += "Separador não utilizado na posição " + (ctd + 1) + "\n";
                    }
                    int ctd2 = ctd - 1;
                    while (ctd2 >=0)
                    {
                        if (expr.ElementAt(ctd2).Equals(sp.ElementAt(sp.IndexOf(expr.ElementAt(ctd)) - 3)) && indsep.Contains(ctd2))
                        {
                            break;
                        }
                        ctd2--;
                    }
                    if (ctd2 >= 0)
                    {
                        indsep.Remove(ctd2);
                    }
                    else
                    {
                        erros += "Separador não aberto na posição "+ (ctd + 1)+ "\n";
                    }
                }
                if (ctd == expr.Length - 1 && indsep.Count > 0)
                {
                    erros += "Separadores abertos sem fechar \n";
                }
            }
            if (erros.Length > 0)//Teste se houve erros
            {
                ApplicationException ers = new ApplicationException(erros);
                throw ers;
            }
        }

        protected string corrigirniveis(string expr)// Corrige os níveis de separadores
        {
            List<object[]> vcn = new List<object[]>{new object[]{1,'˄'},new object[]{1,'˅'},new object[]{1,'ṿ'},new object[]{2,'→'},new object[]{3,'↔'} };
            for (int ctd = 0; ctd < expr.Length; ctd++) 
            {
                if (alf.Contains(expr.ElementAt(ctd)) && ctd > 0 && ctd < (expr.Length - 1))
                {
                    if (cn.Contains(expr.ElementAt(ctd - 1)) && cn.Contains(expr.ElementAt(ctd + 1)))
                    {
                        int cn1 = (int)vcn.Find(x => x[1].Equals(expr.ElementAt(ctd - 1)))[0],
                            cn2 = (int)vcn.Find(x => x[1].Equals(expr.ElementAt(ctd + 1)))[0];
                        if (cn2 > cn1)
                        {
                            int ctd4 = ctd + 3;
                            if (expr.ElementAt(ctd + 2).Equals('¬'))
                            {
                                ctd4++;
                            }
                            if (sp.Substring(0, 3).Contains(expr.ElementAt(ctd + 2)))
                            {
                                int  ctd5 = 0;
                                while (ctd4 < expr.Length)
                                {
                                    if (sp.Substring(0, 3).Contains(expr.ElementAt(ctd4)))
                                    {
                                        ctd5++;
                                    }
                                    if (expr.ElementAt(ctd4).Equals(sp.ElementAt(sp.IndexOf(expr.ElementAt(ctd + 2)) + 3)) && ctd5 == 0)
                                    {
                                        break;
                                    }
                                    if (sp.Substring(3, 3).Contains(expr.ElementAt(ctd4)))
                                    {
                                        ctd5--;
                                    }
                                    ctd4++;
                                }
                            }
                            expr = expr.Insert(ctd4, ")");
                            expr = expr.Insert(ctd, "(");
                        }
                        else
                        {
                            int ctd4 = ctd - 2;
                            if (sp.Substring(3, 3).Contains(expr.ElementAt(ctd - 2)))
                            {
                                ctd4--;
                                int ctd5 = 0;
                                while (ctd4 >= 0)
                                {
                                    if (sp.Substring(3, 3).Contains(expr.ElementAt(ctd4)))
                                    {
                                        ctd5++;
                                    }
                                    if (expr.ElementAt(ctd4).Equals(sp.ElementAt(sp.IndexOf(expr.ElementAt(ctd - 2)) - 3)) && ctd5 == 0)
                                    {
                                        break;
                                    }
                                    if (sp.Substring(0, 3).Contains(expr.ElementAt(ctd4)))
                                    {
                                        ctd5--;
                                    }
                                    ctd4--;
                                }
                            }
                            if (ctd4 > 1 && expr.ElementAt(ctd4 - 1).Equals('¬'))
                            {
                                ctd4--;
                            }
                            expr = expr.Insert(ctd + 1, ")");
                            expr = expr.Insert(ctd4, "(");
                        }
                    }
                }
                else if (sp.Substring(3,3).Contains(expr.ElementAt(ctd)) && ctd < (expr.Length - 1))
                {
                    int ctd2 = ctd - 1,ctd3 = 0;
                    while (ctd2 >= 0)
                    {
                        if(sp.Substring(3,3).Contains(expr.ElementAt(ctd2)))
                        {
                            ctd3++;
                        }
                        if (expr.ElementAt(ctd2).Equals(sp.ElementAt(sp.IndexOf(expr.ElementAt(ctd)) - 3)) && ctd3 == 0)
                        {
                            break;
                        }
                        if (sp.Substring(0, 3).Contains(expr.ElementAt(ctd2)))
                        {
                            ctd3--;
                        }
                        ctd2--;
                    }
                    if (ctd2 > 0 && cn.Contains(expr.ElementAt(ctd2 - 1)) && cn.Contains(expr.ElementAt(ctd + 1)))
                    {
                        int cn1 = (int)vcn.Find(x => x[1].Equals(expr.ElementAt(ctd2 - 1)))[0],
                            cn2 = (int)vcn.Find(x => x[1].Equals(expr.ElementAt(ctd + 1)))[0];
                        if (cn2 > cn1)
                        {
                            int ctd4 = ctd + 3, ctd5 = 0;
                            if (sp.Contains(expr.ElementAt(ctd + 2)))
                            {
                                while (ctd4 < expr.Length)
                                {
                                    if (sp.Substring(0, 3).Contains(expr.ElementAt(ctd4)))
                                    {
                                        ctd5++;
                                    }
                                    if (expr.ElementAt(ctd4).Equals(sp.ElementAt(sp.IndexOf(expr.ElementAt(ctd + 2)) + 3)) && ctd5 == 0)
                                    {
                                        break;
                                    }
                                    if (sp.Substring(3, 3).Contains(expr.ElementAt(ctd4)))
                                    {
                                        ctd5--;
                                    }
                                    ctd4++;
                                }
                            }else if(expr.ElementAt(ctd+2).Equals('¬'))
                            {
                                ctd4++;
                            }
                            expr = expr.Insert(ctd2, "(");
                            expr = expr.Insert(ctd4, ")");
                        }
                        else
                        {
                            int ctd4 = ctd2 - 3, ctd5 = 0;
                            if (sp.Contains(expr.ElementAt(ctd2 - 2)))
                            {
                                while (ctd4 >= 0)
                                {
                                    if (sp.Substring(3, 3).Contains(expr.ElementAt(ctd4)))
                                    {
                                        ctd5++;
                                    }
                                    if (expr.ElementAt(ctd4).Equals(sp.ElementAt(sp.IndexOf(expr.ElementAt(ctd2 - 2)) - 3)) && ctd5 == 0)
                                    {
                                        break;
                                    }
                                    if (sp.Substring(0, 3).Contains(expr.ElementAt(ctd4)))
                                    {
                                        ctd5--;
                                    }
                                    ctd4--;
                                }
                            }
                            else if (expr.ElementAt(ctd2 - 3).Equals('¬'))
                            {
                                ctd4--;
                            }
                            expr = expr.Insert(ctd4, "(");
                            expr = expr.Insert(ctd + 1, ")");
                        }
                    }
                }
            }
            return expr;
        }

        protected void calcular(string expr)// Nomeia as colunas e depois preenche uma tabela com os valores
        {
            int propo = 0;
            string[][] tabelav;
            List<int[]> inds = new List<int[]>();
            List<string> colu = new List<string>();
            for (int ctd = 0; ctd < expr.Length; ctd++) // Procurando e adcionando as proposições simples
            {
                if (alf.Contains(expr.ElementAt(ctd)) && !colu.Contains(expr.ElementAt(ctd).ToString()))
                {
                    colu.Add(expr.ElementAt(ctd).ToString());
                    propo++;
                }
            }
            for (int ctd = 0; ctd < expr.Length; ctd++)  // Procurando e adcionando as proposições simples negadas
            {
                if (expr.ElementAt(ctd).Equals('¬') && alf.Contains(expr.ElementAt(ctd + 1)) && !colu.Contains(expr.Substring(ctd, 2)))
                {
                    colu.Add(expr.Substring(ctd, 2));
                }
            }
            for (int ctd = 0; ctd < expr.Length; ctd++)// Procurando e adcionando as posições compostas de duas proposições ou as mesmas negadas
            {
                if (cn.Contains(expr.ElementAt(ctd)) && alf.Contains(expr.ElementAt(ctd - 1)) && (alf.Contains(expr.ElementAt(ctd + 1)) || expr.ElementAt(ctd+1).Equals('¬')))
                {
                    int cm = ctd - 1, cr = 3;
                    if (expr.ElementAt(ctd - 2).Equals('¬')) { cm--; cr++; }
                    if (expr.ElementAt(ctd + 1).Equals('¬')) { cr++; }
                    colu.Add(expr.Substring(cm,cr));//Adciona a composta
                    if (ctd >= 3 && expr.ElementAt(ctd - 3).Equals('¬'))//Adciona a negação da mesma se existir
                    {
                        int crts = 5,ct = ctd + 1;
                        while (!expr.ElementAt(ct).Equals(sp.ElementAt(sp.IndexOf(expr.ElementAt(ctd - 2)) + 3)))
                        {
                            ct++;
                            crts++;
                        }
                        colu.Add(expr.Substring(ctd - 3, crts));
                    }
                    
                }
            }
            for (int ctd = 0; ctd < expr.Length; ctd++)// Procurando e adcionando proposições compostas de outras proposições compostas
            {
                if (cn.Contains(expr.ElementAt(ctd)) && (sp.Contains(expr.ElementAt(ctd - 1)) || sp.Contains(expr.ElementAt(ctd + 1))))
                {
                    int itpr1 = 0, tpr1 = ctd, itpr2 = ctd + 1, tpr2 = expr.Length - 1 - ctd;
                    if (sp.Contains(expr.ElementAt(ctd - 1)))
                    {
                        tpr1 = ctd - 1;
                    }
                    if (sp.Contains(expr.ElementAt(ctd + 1)))
                    {
                        itpr2++;
                        tpr2--;
                    }
                    while (itpr1 < (ctd - 1))
                    {
                        if(colu.IndexOf(expr.Substring(itpr1,tpr1)) >= 0)
                        {
                            if (sp.Contains(expr.ElementAt(ctd - 1))) tpr1+=2;
                            if (itpr1 != 0 && sp.Contains(expr.ElementAt(itpr1 - 1))) itpr1--;
                            break;
                        }
                        itpr1++;
                        tpr1--;
                    }
                    while (tpr2 > 1)
                    {
                        if(colu.IndexOf(expr.Substring(itpr2,tpr2)) >= 0)
                        {
                            if (sp.Contains(expr.ElementAt(ctd + 1))) tpr2 += 2;
                            break;
                        }
                        tpr2--;
                    }
                    string aux = expr.Substring(itpr1, tpr1 + tpr2 + 1);
                    colu.Add(aux);
                    colu.OrderBy(x => x.Length);//A lista das colunas é ordenada pelo tamanho das proposições
                    inds.Add(new int[] { colu.IndexOf(aux), tpr1 });// O índice que mostra a posição do conectivo é armazenado com o índice da proposição em colu
                }
            }
                        
            int lin = (int)Math.Pow(2,Convert.ToDouble(propo)), col = colu.Count;//O número de linhase colunas da tabela é calculado
            tabelav = new string[lin][];
            for (int ctd1 = 0; ctd1 < lin; ctd1++)
            {
                tabelav[ctd1] = new string[col];
            }
            string p1,p2,conlog;
            int np1,np2;
            for (int ctd1 = 0; ctd1 < col; ctd1++)
            {
                if (ctd1 < propo)
                {
                    int lin2 = 0;
                    for (int ctd2 = 0; ctd2 < ((int)Math.Pow(2,ctd1)); ctd2++)
                    {
                        for (int ctd3 = 0; ctd3 < (lin / ((int)Math.Pow(2,(ctd1+1)))); ctd3++)
                        {
                            tabelav[lin2][ctd1] = "V";
                            lin2++;
                        }
                        for (int ctd3 = 0; ctd3 < (lin / ((int)Math.Pow(2, (ctd1 + 1)))); ctd3++)
                        {
                            tabelav[lin2][ctd1] = "F";
                            lin2++;
                        }
                    }
                }
                else
                {       
                    if (colu[ctd1].ElementAt(0).Equals('¬'))
                    {
                        if (sp.Contains(colu[ctd1].ElementAt(1)))
                        {
                            np1 = colu.IndexOf(colu[ctd1].Substring(2, colu[ctd1].Length - 3));
                        }
                        else if (colu[ctd1].Length == 2)
                        {
                            np1 = colu.IndexOf(colu[ctd1].Substring(1, 1));
                        }
                        else 
                        { 
                            np1 = -1; 
                        }
                        if (np1 != -1)
                        {
                            for (int ctd2 = 0; ctd2 < lin; ctd2++)
                            {
                                tabelav[ctd2][ctd1] = negue(tabelav[ctd2][np1]);
                            }
                        }
                    }
                    if (colu[ctd1].Count(x => cn.Any(x.Equals)) == 1)
                    {
                        int ic = colu[ctd1].LastIndexOfAny(cn.ToCharArray());
                        conlog = colu[ctd1].ElementAt(ic).ToString();
                        p1 = colu[ctd1].Substring(0, ic);
                        p2 = colu[ctd1].Substring(ic + 1, colu[ctd1].Length - 1 - ic);
                        np1 = colu.IndexOf(p1);
                        np2 = colu.IndexOf(p2);
                        for (int ctd2 = 0; ctd2 < lin; ctd2++)
                        {
                            tabelav[ctd2][ctd1] = conecte(tabelav[ctd2][np1], tabelav[ctd2][np2], conlog);
                        }
                    }
                    else
                    {
                        int ic = inds.Find(x => x[0]==ctd1)[1];
                        conlog = colu[ctd1].ElementAt(ic).ToString();
                        if (sp.Contains(colu[ctd1].ElementAt(ic-1)))
                        {
                            p1 = colu[ctd1].Substring(1, ic - 2);
                        }
                        else
                        {
                            p1 = colu[ctd1].Substring(0, ic);
                        }
                        if (sp.Contains(colu[ctd1].ElementAt(ic + 1)))
                        {
                            p2 = colu[ctd1].Substring(ic + 2, colu[ctd1].Length - (ic+3));
                        }
                        else
                        {
                            p2 = colu[ctd1].Substring(ic + 1, colu[ctd1].Length - 1 - ic); ;
                        }
                        np1 = colu.IndexOf(p1);
                        np2 = colu.IndexOf(p2);
                        for (int ctd2 = 0; ctd2 < lin; ctd2++)
                        {
                            tabelav[ctd2][ctd1] = conecte(tabelav[ctd2][np1], tabelav[ctd2][np2], conlog);
                        }
                    }
                    
                }
            }
            prenchegridview(tabelav, colu);
        }

        public string conecte(string v1,string v2, string con)//Faz a conexão de acordo com a lógica escolhida e retorna V ou F
        {
            string ret = "F";
            if (con.Equals("˄"))
            {
                if(v1.Equals("V") && v2.Equals("V"))
                {
                    ret = "V";
                }
            }
            else if (con.Equals("˅"))
            {
                if (v1.Equals("V") || v2.Equals("V"))
                {
                    ret = "V";
                }
            }else if (con.Equals("ṿ"))
            {
                if (!v1.Equals(v2))
                {
                    ret = "V";
                }
            }
            else if (con.Equals("→"))
            {
                if (!(v1.Equals("V") && v2.Equals("F")))
                {
                    ret = "V";
                }
            }
            else if (con.Equals("↔"))
            {
                if (v1.Equals(v2))
                {
                    ret = "V";
                }
            }
            return ret;
        }

        public string negue(string v1)//Nega a coluna escolhida retornando V ou F
        {
            string ret = "F";
            if (v1.Equals("F"))
            {
                ret = "V";
            }
            return ret;
        }

        public void prenchegridview(string[][] tab,List<string> coln)// Preenche a gridview com os valores da tabela e com os títulos das colunas
        {
            DGVtabverdade.Rows.Clear();
            DGVtabverdade.ColumnCount = coln.Count;
            for (int ctd = 0; ctd < coln.Count;ctd++)
            {
                DGVtabverdade.Columns[ctd].Name = coln[ctd];
                
            }
            for(int ctd2 = 0;ctd2<tab.Length;ctd2++)
            {
                DGVtabverdade.Rows.Add(tab[ctd2]);
            }
        }
    }
}

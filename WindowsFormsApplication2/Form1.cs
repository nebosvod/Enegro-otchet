using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using System.IO.Ports;
using System.Threading;
using MySql.Data;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }







        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;


            //string conn_str = "Database=resources;Data Source=localhost;User Id=root;Password=Rfnfgekmrf48";
            string conn_str = "Database=resources;Data Source=10.1.1.50;User Id=sa;Password=Rfnfgekmrf48";

            MySqlLib.MySqlData.MySqlExecuteData.MyResultData result = new MySqlLib.MySqlData.MySqlExecuteData.MyResultData();

            DateTime date1 = new DateTime(2013, 1, 1, 0, 0, 0);
            DateTime date2 = new DateTime(2013, 1, 1, 0, 0, 0);

            if (radioButton1.Checked)
            {
                DateTime date1_1 = DateTime.Now.AddMonths(-1);
                date1 = new DateTime(date1_1.Year, date1_1.Month, 1, 11, 0, 0);

                date1_1 = DateTime.Now;
                date2 = new DateTime(date1_1.Year, date1_1.Month, 1, 11, 0, 0);
            }

            if (radioButton2.Checked)
            {
                if (comboBox1.Text == "Январь")
                {
                    date1 = new DateTime(Convert.ToInt32(textBox1.Text), 1, 1, 11, 0, 0);
                    date2 = date1.AddMonths(1);
                }

                if (comboBox1.Text == "Февраль")
                {
                    date1 = new DateTime(Convert.ToInt32(textBox1.Text), 2, 1, 11, 0, 0);
                    date2 = date1.AddMonths(1);
                }

                if (comboBox1.Text == "Март")
                {
                    date1 = new DateTime(Convert.ToInt32(textBox1.Text), 3, 1, 11, 0, 0);
                    date2 = date1.AddMonths(1);
                }

                if (comboBox1.Text == "Апрель")
                {
                    date1 = new DateTime(Convert.ToInt32(textBox1.Text), 4, 1, 11, 0, 0);
                    date2 = date1.AddMonths(1);
                }

                if (comboBox1.Text == "Май")
                {
                    date1 = new DateTime(Convert.ToInt32(textBox1.Text), 5, 1, 11, 0, 0);
                    date2 = date1.AddMonths(1);
                }

                if (comboBox1.Text == "Июнь")
                {
                    date1 = new DateTime(Convert.ToInt32(textBox1.Text), 6, 1, 11, 0, 0);
                    date2 = date1.AddMonths(1);
                }

                if (comboBox1.Text == "Июль")
                {
                    date1 = new DateTime(Convert.ToInt32(textBox1.Text), 7, 1, 11, 0, 0);
                    date2 = date1.AddMonths(1);
                }

                if (comboBox1.Text == "Август")
                {
                    date1 = new DateTime(Convert.ToInt32(textBox1.Text), 8, 1, 11, 0, 0);
                    date2 = date1.AddMonths(1);
                }

                if (comboBox1.Text == "Сентябрь")
                {
                    date1 = new DateTime(Convert.ToInt32(textBox1.Text), 9, 1, 11, 0, 0);
                    date2 = date1.AddMonths(1);
                }

                if (comboBox1.Text == "Октябрь")
                {
                    date1 = new DateTime(Convert.ToInt32(textBox1.Text), 10, 1, 11, 0, 0);
                    date2 = date1.AddMonths(1);
                }

                if (comboBox1.Text == "Ноябрь")
                {
                    date1 = new DateTime(Convert.ToInt32(textBox1.Text), 11, 1, 11, 0, 0);
                    date2 = date1.AddMonths(1);
                }

                if (comboBox1.Text == "Декабрь")
                {
                    date1 = new DateTime(Convert.ToInt32(textBox1.Text), 12, 1, 11, 0, 0);
                    date2 = date1.AddMonths(1);
                }

            }

            if (radioButton3.Checked)
            {
                date1 = new DateTime(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month, dateTimePicker1.Value.Day, 11, 0, 0);
                date2 = new DateTime(dateTimePicker2.Value.Year, dateTimePicker2.Value.Month, dateTimePicker2.Value.Day + 1, 11, 0, 0);
            }



            TimeSpan interval = date2 - date1;



            DateTime date1_sut = date1;
            DateTime date2_sut = date2;

            TimeSpan interval_sut = date2_sut - date1_sut;

            DateTime date1_akt = date1;
            DateTime date2_akt = date2;

            TimeSpan interval_akt = date2_akt - date1_akt;

            DateTime date1_akt_table = date1;

            DateTime date1_pril = date1;
            DateTime date2_pril = date2;

            TimeSpan interval_pril = date2_pril - date1_pril;

            DateTime date1_pril2 = date1;
            DateTime date2_pril2 = date2;

            TimeSpan interval_pril2 = date2_pril2 - date1_pril2;


            Decimal v_r_sum = 0;
            Decimal v_st_sum = 0;
            Decimal temperature_sr = 0;
            Decimal pressure_sr = 0;

            object oMissing = System.Reflection.Missing.Value;
            object oEndOfDoc = "\\endofdoc"; /* \endofdoc is a predefined bookmark */

            if (checkBox1.Checked)
            {

                //Start Word and create a new document.
                Word._Application oWord;
                Word._Document oDoc;
                oWord = new Word.Application();
                oWord.Visible = false;
                oDoc = oWord.Documents.Add(ref oMissing, ref oMissing, ref oMissing, ref oMissing);
                oDoc.PageSetup.Orientation = Word.WdOrientation.wdOrientLandscape;
                oDoc.PageSetup.TopMargin = oDoc.Content.Application.CentimetersToPoints((float)1.2);
                oDoc.PageSetup.LeftMargin = oDoc.Content.Application.CentimetersToPoints((float)1);
                oDoc.PageSetup.RightMargin = oDoc.Content.Application.CentimetersToPoints((float)1);
                //Insert a paragraph at the beginning of the document.
                Word.Paragraph oPara1;
                oPara1 = oDoc.Content.Paragraphs.Add(ref oMissing);
                oPara1.Range.Text = "Дата создания отчета: " + DateTime.Now;
                oPara1.Range.Font.Name = "Arial";
                oPara1.Range.Font.Size = 8;
                oPara1.Range.Font.Bold = 0;
                oPara1.Range.Font.Italic = 1;
                oPara1.Format.SpaceAfter = 4;    //24 pt spacing after paragraph.
                oPara1.Range.InsertParagraphAfter();

                //Insert a paragraph at the end of the document.
                Word.Paragraph oPara2;
                object oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
                oPara2 = oDoc.Content.Paragraphs.Add(ref oRng);
                oPara2.Range.Text = "Поставщик:";
                oPara2.Range.Font.Size = 10;
                oPara2.Range.Font.Italic = 0;
                oPara2.Range.Font.Bold = 1;
                oPara2.Format.SpaceAfter = 4;
                oPara2.Range.InsertParagraphAfter();

                //Insert another paragraph.
                Word.Paragraph oPara3;
                oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
                oPara3 = oDoc.Content.Paragraphs.Add(ref oRng);
                oPara3.Range.Text = "Потребитель: ОАО \"Аньковское\"";
                oPara3.Range.Font.Size = 10;
                oPara3.Range.Font.Bold = 1;
                oPara3.Format.SpaceAfter = 4;
                oPara3.Range.InsertParagraphAfter();

                //Insert another paragraph.
                Word.Paragraph oPara4;
                oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
                oPara4 = oDoc.Content.Paragraphs.Add(ref oRng);
                oPara4.Range.Text = "Прибор: Корректор ЕК260 № 10327262";
                oPara4.Range.Font.Size = 10;
                oPara4.Range.Font.Bold = 1;
                oPara4.Format.SpaceAfter = 4;
                oPara4.Range.InsertParagraphAfter();

                //Insert another paragraph.
                Word.Paragraph oPara5;
                oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
                oPara5 = oDoc.Content.Paragraphs.Add(ref oRng);
                oPara5.Range.Text = "Объект: Узел учета газа";
                oPara5.Range.Font.Size = 9;
                oPara5.Range.Font.Bold = 0;
                oPara5.Format.SpaceAfter = 4;
                oPara5.Range.InsertParagraphAfter();

                //Insert another paragraph.
                Word.Paragraph oPara6;
                oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
                oPara6 = oDoc.Content.Paragraphs.Add(ref oRng);
                oPara6.Range.Text = "Место установки";
                oPara6.Range.Font.Size = 9;
                oPara6.Range.Font.Bold = 0;
                oPara6.Format.SpaceAfter = 4;
                oPara6.Range.InsertParagraphAfter();

                //Insert another paragraph.
                Word.Paragraph oPara7;
                oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
                oPara7 = oDoc.Content.Paragraphs.Add(ref oRng);
                oPara7.Range.Text = "Начало дня приборное: 10:00:00                                                        Начало дня программное: 10:00:00";
                oPara7.Range.Font.Size = 9;
                oPara7.Range.Font.Bold = 0;
                oPara7.Format.SpaceAfter = 4;
                oPara7.Range.InsertParagraphAfter();

                //Insert another paragraph.
                Word.Paragraph oPara8;
                oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
                oPara8 = oDoc.Content.Paragraphs.Add(ref oRng);
                oPara8.Range.Text = "Период отчета: с " + date1.AddHours(-1) + " по " + date2.AddHours(-1).AddSeconds(-1);
                oPara8.Range.Font.Size = 9;
                oPara8.Range.Font.Bold = 0;
                oPara8.Format.SpaceAfter = 8;
                oPara8.Range.InsertParagraphAfter();

                //Insert another paragraph.
                Word.Paragraph oPara9;
                oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
                oPara9 = oDoc.Content.Paragraphs.Add(ref oRng);
                oPara9.Range.Text = "Интервальный подробный отчет";
                oPara9.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                oPara9.Range.Font.Size = 14;
                oPara9.Range.Font.Bold = 1;
                oPara9.Format.SpaceAfter = 4;
                oPara9.Range.InsertParagraphAfter();


                //Insert a 3 x 5 table, fill it with data, and make the first row
                //bold and italic.
                Word.Table oTable;
                Word.Range wrdRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;

                oTable = oDoc.Tables.Add(wrdRng, (2 + 26 * interval.Days), 13, ref oMissing, ref oMissing);
                oTable.Range.ParagraphFormat.SpaceBefore = 1;
                oTable.Range.ParagraphFormat.SpaceAfter = 1;
                oTable.Range.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                oTable.Rows[1].Range.Font.Size = 8;
                oTable.Rows[1].Range.Font.Bold = 0;
                oTable.Range.Font.Size = 8;
                oTable.Range.Font.Bold = 0;
                oTable.Range.InsertParagraphAfter();

                oTable.Columns[1].Width = oWord.CentimetersToPoints((float)3);
                oTable.Columns[2].Width = oWord.CentimetersToPoints((float)2.5);
                oTable.Columns[3].Width = oWord.CentimetersToPoints((float)2.5);
                oTable.Columns[4].Width = oWord.CentimetersToPoints((float)1.75);
                oTable.Columns[5].Width = oWord.CentimetersToPoints((float)1.75);
                oTable.Columns[6].Width = oWord.CentimetersToPoints((float)1.5);
                oTable.Columns[12].Width = oWord.CentimetersToPoints((float)2.5);
                oTable.Columns[13].Width = oWord.CentimetersToPoints((float)2.5);




                oWord.ActiveWindow.ActivePane.View.SeekView = Word.WdSeekView.wdSeekCurrentPageFooter;
                oWord.ActiveWindow.ActivePane.Selection.Font.Name = "Arial";
                oWord.ActiveWindow.ActivePane.Selection.Font.Size = 10;
                //oWord.ActiveWindow.ActivePane.Selection.Font.Color = 0;
                oWord.ActiveWindow.Selection.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight;
                oWord.ActiveWindow.ActivePane.Selection.TypeText("Стр № ");
                oWord.ActiveWindow.ActivePane.Selection.Fields.Add(oWord.ActiveWindow.ActivePane.Selection.Range, Word.WdFieldType.wdFieldPage, oMissing, oMissing);
                oWord.ActiveWindow.ActivePane.Selection.TypeText(" из ");
                oWord.ActiveWindow.ActivePane.Selection.Fields.Add(oWord.ActiveWindow.ActivePane.Selection.Range, Word.WdFieldType.wdFieldNumPages, oMissing, oMissing);
                oWord.ActiveWindow.ActivePane.View.SeekView = Word.WdSeekView.wdSeekMainDocument;




                Word.Border[] borders = new Word.Border[6];//массив бордеров
                borders[0] = oTable.Borders[Word.WdBorderType.wdBorderLeft];//левая граница 
                borders[1] = oTable.Borders[Word.WdBorderType.wdBorderRight];//правая граница 
                borders[2] = oTable.Borders[Word.WdBorderType.wdBorderTop];//нижняя граница 
                borders[3] = oTable.Borders[Word.WdBorderType.wdBorderBottom];//верхняя граница
                borders[4] = oTable.Borders[Word.WdBorderType.wdBorderHorizontal];//горизонтальная граница
                borders[5] = oTable.Borders[Word.WdBorderType.wdBorderVertical];//вертикальная граница

                foreach (Word.Border border in borders)
                {
                    border.LineStyle = Word.WdLineStyle.wdLineStyleSingle;//ставим стиль границы 
                    border.Color = Word.WdColor.wdColorBlack;//задаем цвет границы
                }
                oTable.Rows[1].HeadingFormat = -1;
                oTable.Cell(1, 1).Range.Text = "Время";
                oTable.Cell(1, 2).Range.Text = "Vраб.общ., [м3] (потребление)";
                oTable.Cell(1, 3).Range.Text = "Vст.общ., [м3] (потребление)";
                oTable.Cell(1, 4).Range.Text = "P, [бар]";
                oTable.Cell(1, 5).Range.Text = "T, [" + Convert.ToChar(176) + "С]";
                oTable.Cell(1, 6).Range.Text = "К кор.";
                oTable.Cell(1, 7).Range.Text = "Сист. статус";
                oTable.Cell(1, 8).Range.Text = "Статус Vраб.";
                oTable.Cell(1, 9).Range.Text = "Статус Vст.";
                oTable.Cell(1, 10).Range.Text = "Статус P";
                oTable.Cell(1, 11).Range.Text = "Статус T";
                oTable.Cell(1, 12).Range.Text = "Vраб.общ., [м3] (счетчик)";
                oTable.Cell(1, 13).Range.Text = "Vст.общ., [м3] (счетчик)";


                int k1 = 0;
                int k_sum = 0;

                decimal gas_v_r_p, gas_v_st_p;
                decimal gas_v_r_p_sum = 0;
                decimal gas_v_st_p_sum = 0;
                decimal gas_pressure_sum = 0;
                decimal gas_temperature_sum = 0;
                string date1_sql;
                string date1_str;
                string date1_month = "";

                //int days = Convert.ToInt32(Math.Floor(interval.TotalDays));
                //progressBar1.Maximum = Convert.ToInt32(days);

                int hours = Convert.ToInt32(Math.Floor(interval.TotalHours));
                progressBar1.Maximum = Convert.ToInt32(hours);

                for (int k = 0; k <= (interval.Days - 1); k++)
                {
                    gas_v_r_p = 0;
                    gas_v_st_p = 0;

                    oTable.Cell(2 + 26 * k, 1).Merge(oTable.Cell(2 + 26 * k, 13));

                    if (date1.Month == 1) { date1_month = "Январь"; }
                    if (date1.Month == 2) { date1_month = "Февраль"; }
                    if (date1.Month == 3) { date1_month = "Март"; }
                    if (date1.Month == 4) { date1_month = "Апрель"; }
                    if (date1.Month == 5) { date1_month = "Май"; }
                    if (date1.Month == 6) { date1_month = "Июнь"; }
                    if (date1.Month == 7) { date1_month = "Июль"; }
                    if (date1.Month == 8) { date1_month = "Август"; }
                    if (date1.Month == 9) { date1_month = "Сентябрь"; }
                    if (date1.Month == 10) { date1_month = "Октябрь"; }
                    if (date1.Month == 11) { date1_month = "Ноябрь"; }
                    if (date1.Month == 12) { date1_month = "Декабрь"; }

                    oTable.Cell(2 + 26 * k, 1).Range.Font.Bold = 1;
                    oTable.Cell(2 + 26 * k, 1).Range.Font.Size = 9;
                    oTable.Cell(2 + 26 * k, 1).Range.Text = "Газовые сутки: " + date1.Day + " " + date1_month + " " + date1.Year;

                    oTable.Cell(2 + 26 * k, 1).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;


                    for (int j = 1; j <= 24; j++)
                    {

                        date1_str = date1.ToString();

                        if (date1_str.Length == 19)
                        {
                            date1_sql = date1_str.Substring(6, 4) + date1_str.Substring(3, 2) + date1_str.Substring(0, 2) + date1_str.Substring(11, 2) + date1_str.Substring(14, 2) + date1_str.Substring(17, 2);
                        }
                        else
                        {
                            date1_sql = date1_str.Substring(6, 4) + date1_str.Substring(3, 2) + date1_str.Substring(0, 2) + "0" + date1_str.Substring(11, 1) + date1_str.Substring(13, 2) + date1_str.Substring(16, 2);
                        }
                        result = MySqlLib.MySqlData.MySqlExecuteData.SqlReturnDataset("SELECT * FROM gas where gas_datetime =" + date1_sql + " LIMIT 0,1", conn_str);
                        if (result.ResultData.DefaultView.Table.Rows[0]["gas_datetime"].ToString().Length == 19)
                        {
                            oTable.Cell(2 + 26 * k + j, 1).Range.Text = result.ResultData.DefaultView.Table.Rows[0]["gas_datetime"].ToString().Substring(0, 6) + result.ResultData.DefaultView.Table.Rows[0]["gas_datetime"].ToString().Substring(8, 8);
                        }
                        else
                        {
                            oTable.Cell(2 + 26 * k + j, 1).Range.Text = result.ResultData.DefaultView.Table.Rows[0]["gas_datetime"].ToString().Substring(0, 6) + result.ResultData.DefaultView.Table.Rows[0]["gas_datetime"].ToString().Substring(8, 3) + "0" + result.ResultData.DefaultView.Table.Rows[0]["gas_datetime"].ToString().Substring(11, 4);
                        }


                        if (result.ResultData.DefaultView.Table.Rows[0]["gas_mark_gray"].ToString() == "1")
                        {

                            oTable.Cell(2 + 26 * k + j, 2).Range.Shading.BackgroundPatternColor = Word.WdColor.wdColorGray125;
                            oTable.Cell(2 + 26 * k + j, 3).Range.Shading.BackgroundPatternColor = Word.WdColor.wdColorGray125;
                            oTable.Cell(2 + 26 * k + j, 4).Range.Shading.BackgroundPatternColor = Word.WdColor.wdColorGray125;
                            oTable.Cell(2 + 26 * k + j, 5).Range.Shading.BackgroundPatternColor = Word.WdColor.wdColorGray125;

                        }




                        oTable.Cell(2 + 26 * k + j, 2).Range.Text = result.ResultData.DefaultView.Table.Rows[0]["gas_v_r_p"].ToString();
                        oTable.Cell(2 + 26 * k + j, 3).Range.Text = result.ResultData.DefaultView.Table.Rows[0]["gas_v_st_p"].ToString();
                        oTable.Cell(2 + 26 * k + j, 4).Range.Text = result.ResultData.DefaultView.Table.Rows[0]["gas_pressure"].ToString();
                        oTable.Cell(2 + 26 * k + j, 5).Range.Text = result.ResultData.DefaultView.Table.Rows[0]["gas_temperature"].ToString();
                        oTable.Cell(2 + 26 * k + j, 6).Range.Text = result.ResultData.DefaultView.Table.Rows[0]["gas_kkor"].ToString();

                        v_r_sum = v_r_sum + Convert.ToDecimal(result.ResultData.DefaultView.Table.Rows[0]["gas_v_r_p"].ToString());
                        v_st_sum = v_st_sum + Convert.ToDecimal(result.ResultData.DefaultView.Table.Rows[0]["gas_v_st_p"].ToString());

                        pressure_sr = pressure_sr + Convert.ToDecimal(result.ResultData.DefaultView.Table.Rows[0]["gas_pressure"].ToString());
                        temperature_sr = temperature_sr + Convert.ToDecimal(result.ResultData.DefaultView.Table.Rows[0]["gas_temperature"].ToString());


                        if (result.ResultData.DefaultView.Table.Rows[0]["gas_sys_status"].ToString() == "0")
                        {
                            oTable.Cell(2 + 26 * k + j, 7).Range.Text = "";
                        }
                        else
                        {
                            oTable.Cell(2 + 26 * k + j, 7).Range.Text = result.ResultData.DefaultView.Table.Rows[0]["gas_sys_status"].ToString();
                        }

                        if (result.ResultData.DefaultView.Table.Rows[0]["gas_status_vr"].ToString() == "0")
                        {

                            oTable.Cell(2 + 26 * k + j, 8).Range.Text = "";

                        }
                        else
                        {
                            oTable.Cell(2 + 26 * k + j, 8).Range.Text = result.ResultData.DefaultView.Table.Rows[0]["gas_status_vr"].ToString();
                        }

                        if (result.ResultData.DefaultView.Table.Rows[0]["gas_status_vst"].ToString() == "0")
                        {
                            oTable.Cell(2 + 26 * k + j, 9).Range.Text = "";

                        }
                        else
                        {
                            oTable.Cell(2 + 26 * k + j, 9).Range.Text = result.ResultData.DefaultView.Table.Rows[0]["gas_status_vst"].ToString();
                        }

                        if (result.ResultData.DefaultView.Table.Rows[0]["gas_status_p"].ToString() == "0")
                        {
                            oTable.Cell(2 + 26 * k + j, 10).Range.Text = "";
                        }
                        else
                        {
                            oTable.Cell(2 + 26 * k + j, 10).Range.Text = result.ResultData.DefaultView.Table.Rows[0]["gas_status_p"].ToString();
                        }

                        if (result.ResultData.DefaultView.Table.Rows[0]["gas_status_t"].ToString() == "0")
                        {
                            oTable.Cell(2 + 26 * k + j, 11).Range.Text = "";
                        }
                        else
                        {
                            oTable.Cell(2 + 26 * k + j, 11).Range.Text = result.ResultData.DefaultView.Table.Rows[0]["gas_status_t"].ToString();
                        }
                        oTable.Cell(2 + 26 * k + j, 12).Range.Text = result.ResultData.DefaultView.Table.Rows[0]["gas_v_r_s"].ToString();
                        oTable.Cell(2 + 26 * k + j, 13).Range.Text = result.ResultData.DefaultView.Table.Rows[0]["gas_v_st_s"].ToString();

                        gas_v_r_p = gas_v_r_p + Convert.ToDecimal(result.ResultData.DefaultView.Table.Rows[0]["gas_v_r_p"].ToString());
                        gas_v_st_p = gas_v_st_p + Convert.ToDecimal(result.ResultData.DefaultView.Table.Rows[0]["gas_v_st_p"].ToString());
                        gas_pressure_sum = gas_pressure_sum + Convert.ToDecimal(result.ResultData.DefaultView.Table.Rows[0]["gas_pressure"].ToString());
                        gas_temperature_sum = gas_temperature_sum + Convert.ToDecimal(result.ResultData.DefaultView.Table.Rows[0]["gas_temperature"].ToString());

                        date1 = date1.AddHours(1);

                        k_sum = k_sum + 1;
                        progressBar1.Value = k_sum;


                        // Form1.ActiveForm.Update();
                    }
                    gas_v_r_p_sum = gas_v_r_p_sum + gas_v_r_p;
                    gas_v_st_p_sum = gas_v_st_p_sum + gas_v_st_p;
                    oTable.Cell(27 + 26 * k, 1).Range.Font.Size = 7;
                    oTable.Cell(27 + 26 * k, 1).Range.Text = "Итого за газ. сутки: " + Convert.ToString(date1.Date.AddDays(-1)).Substring(0, 10);
                    oTable.Cell(27 + 26 * k, 2).Range.Text = Convert.ToString(gas_v_r_p);
                    oTable.Cell(27 + 26 * k, 3).Range.Text = Convert.ToString(gas_v_st_p);

                    k1 = (27 + 26 * k);
                }




                gas_temperature_sum = gas_temperature_sum / Convert.ToDecimal(interval.TotalHours);
                gas_pressure_sum = gas_pressure_sum / Convert.ToDecimal(interval.TotalHours);

                oTable.Cell(k1 + 1, 1).Merge(oTable.Cell(k1 + 1, 13));
                oTable.Cell(k1 + 1, 1).Range.Font.Size = 7;
                oTable.Cell(k1 + 1, 1).Range.Font.Italic = 1;
                oTable.Cell(k1 + 1, 1).Range.Text = "Примечание: в интервалах, затенённых серым цветом, содержатся сообщения о начале или завершении нештатных ситуаций.";
                Word.Cell cell = oTable.Cell(k1 + 1, 1);
                cell.Range.Font.Underline = Word.WdUnderline.wdUnderlineSingle;
                oTable.Cell(k1 + 1, 1).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;


                Word.Paragraph oPara10;
                oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
                oPara10 = oDoc.Content.Paragraphs.Add(ref oRng);
                oPara10.Range.Text = "";
                oPara10.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                oPara10.Range.Font.Size = 14;
                oPara10.Range.Font.Bold = 1;
                oPara10.Format.SpaceAfter = 4;
                oPara10.Range.InsertParagraphAfter();

                Word.Table oTable2;
                Word.Range wrdRng2 = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
                oTable2 = oDoc.Tables.Add(wrdRng2, 5, 2, ref oMissing, ref oMissing);
                oTable2.Range.ParagraphFormat.SpaceAfter = 1;
                oTable2.Range.ParagraphFormat.SpaceBefore = 1;
                oTable2.Columns[1].Width = oWord.CentimetersToPoints((float)12);
                oTable2.Columns[2].Width = oWord.CentimetersToPoints((float)7);
                oTable2.Range.Font.Size = 9;
                oTable2.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
                oTable2.Range.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

                oTable2.Cell(1, 1).Merge(oTable2.Cell(1, 2));
                oTable2.Cell(1, 1).Range.Font.Size = 10;
                oTable2.Cell(1, 1).Range.Font.Bold = 1;
                oTable2.Cell(1, 1).Range.Text = "ИТОГО ПО ОТЧЕТУ";

                Word.Cell cell2 = oTable2.Cell(1, 1);
                cell2.Range.Font.Underline = Word.WdUnderline.wdUnderlineSingle;
                oTable2.Cell(1, 1).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                oTable2.Cell(2, 1).Range.Text = "Суммарный рабочий объем [м3]:";
                oTable2.Cell(2, 2).Range.Text = "V = " + Convert.ToString(v_r_sum);

                oTable2.Cell(3, 1).Range.Text = "Суммарный стандартный объем [м3]:";
                oTable2.Cell(3, 2).Range.Text = "Vст. = " + Convert.ToString(v_st_sum);

                oTable2.Cell(4, 1).Range.Text = "Среднее давление [бар]:";
                oTable2.Cell(4, 2).Range.Text = "P = " + Convert.ToString(Math.Round(pressure_sr / k_sum, 4));

                oTable2.Cell(5, 1).Range.Text = "Средняя температура [" + Convert.ToChar(176) + "С]:";
                oTable2.Cell(5, 2).Range.Text = "T = " + Convert.ToString(Math.Round(temperature_sr / k_sum, 2));



                Word.Paragraph oPara11;
                oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
                oPara11 = oDoc.Content.Paragraphs.Add(ref oRng);
                oPara11.Range.Text = "________________________________________________________________________________________";
                oPara11.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
                oPara11.Range.Font.Size = 10;
                oPara11.Range.Font.Bold = 1;
                oPara11.Format.SpaceAfter = 12;
                oPara11.Range.InsertParagraphAfter();

                Word.Paragraph oPara12;
                oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
                oPara12 = oDoc.Content.Paragraphs.Add(ref oRng);
                oPara12.Range.Text = "Представитель поставщика:________________________________//";
                oPara12.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
                oPara12.Range.Font.Size = 10;
                oPara12.Range.Font.Bold = 1;
                oPara12.Range.Font.Italic = 1;
                oPara12.Format.SpaceAfter = 12;
                oPara12.Range.InsertParagraphAfter();


                Word.Paragraph oPara14;
                oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
                oPara14 = oDoc.Content.Paragraphs.Add(ref oRng);
                oPara14.Range.Text = "Ответственный за учет:________________________________/Смолярчук А.Н./";
                oPara14.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
                oPara14.Range.Font.Size = 10;
                oPara14.Range.Font.Bold = 1;
                oPara14.Range.Font.Italic = 1;
                oPara14.Format.SpaceAfter = 12;
                oPara14.Range.InsertParagraphAfter();

                Word.Paragraph oPara15;
                oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
                oPara15 = oDoc.Content.Paragraphs.Add(ref oRng);
                oPara15.Range.Text = "Ответственный за прибор:________________________________//";
                oPara15.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
                oPara15.Range.Font.Size = 10;
                oPara15.Range.Font.Bold = 1;
                oPara15.Range.Font.Italic = 1;
                oPara15.Format.SpaceAfter = 12;
                oPara15.Range.InsertParagraphAfter();

                oWord.Visible = true;
            }





            if (checkBox2.Checked)
            {

                // Создание суточного отчета--------------------------------------------------------

                //Start Word and create a new document.
                Word._Application oWord2;
                Word._Document oDoc2;
                oWord2 = new Word.Application();
                oWord2.Visible = false;
                oDoc2 = oWord2.Documents.Add(ref oMissing, ref oMissing,
                    ref oMissing, ref oMissing);

                oDoc2.PageSetup.Orientation = Word.WdOrientation.wdOrientPortrait;
                oDoc2.PageSetup.TopMargin = oDoc2.Content.Application.CentimetersToPoints((float)1.2);
                oDoc2.PageSetup.LeftMargin = oDoc2.Content.Application.CentimetersToPoints((float)1);
                oDoc2.PageSetup.RightMargin = oDoc2.Content.Application.CentimetersToPoints((float)1);
                //Insert a paragraph at the beginning of the document.
                Word.Paragraph oPara20;
                oPara20 = oDoc2.Content.Paragraphs.Add(ref oMissing);
                oPara20.Range.Text = "Дата создания отчета: " + DateTime.Now;
                oPara20.Range.Font.Name = "Arial";
                oPara20.Range.Font.Size = 8;
                oPara20.Range.Font.Bold = 0;
                oPara20.Range.Font.Italic = 1;
                oPara20.Format.SpaceAfter = 4;    //24 pt spacing after paragraph.
                oPara20.Range.InsertParagraphAfter();

                //Insert a paragraph at the end of the document.
                Word.Paragraph oPara21;
                object oRng2 = oDoc2.Bookmarks.get_Item(ref oEndOfDoc).Range;
                oPara21 = oDoc2.Content.Paragraphs.Add(ref oRng2);
                oPara21.Range.Text = "Поставщик:";
                oPara21.Range.Font.Size = 10;
                oPara21.Range.Font.Italic = 0;
                oPara21.Range.Font.Bold = 1;
                oPara21.Format.SpaceAfter = 4;
                oPara21.Range.InsertParagraphAfter();

                //Insert another paragraph.
                Word.Paragraph oPara22;
                oRng2 = oDoc2.Bookmarks.get_Item(ref oEndOfDoc).Range;
                oPara22 = oDoc2.Content.Paragraphs.Add(ref oRng2);
                oPara22.Range.Text = "Потребитель: ОАО \"Аньковское\"";
                oPara22.Range.Font.Size = 10;
                oPara22.Range.Font.Bold = 1;
                oPara22.Format.SpaceAfter = 4;
                oPara22.Range.InsertParagraphAfter();

                //Insert another paragraph.
                Word.Paragraph oPara23;
                oRng2 = oDoc2.Bookmarks.get_Item(ref oEndOfDoc).Range;
                oPara23 = oDoc2.Content.Paragraphs.Add(ref oRng2);
                oPara23.Range.Text = "Прибор: Корректор ЕК260 № 10327262";
                oPara23.Range.Font.Size = 10;
                oPara23.Range.Font.Bold = 1;
                oPara23.Format.SpaceAfter = 4;
                oPara23.Range.InsertParagraphAfter();

                //Insert another paragraph.
                Word.Paragraph oPara28;
                oRng2 = oDoc2.Bookmarks.get_Item(ref oEndOfDoc).Range;
                oPara28 = oDoc2.Content.Paragraphs.Add(ref oRng2);
                oPara28.Range.Text = "Объект: Узел учета газа";
                oPara28.Range.Font.Size = 9;
                oPara28.Range.Font.Bold = 0;
                oPara28.Format.SpaceAfter = 4;
                oPara28.Range.InsertParagraphAfter();

                //Insert another paragraph.
                Word.Paragraph oPara24;
                oRng2 = oDoc2.Bookmarks.get_Item(ref oEndOfDoc).Range;
                oPara24 = oDoc2.Content.Paragraphs.Add(ref oRng2);
                oPara24.Range.Text = "Место установки";
                oPara24.Range.Font.Size = 9;
                oPara24.Range.Font.Bold = 0;
                oPara24.Format.SpaceAfter = 4;
                oPara24.Range.InsertParagraphAfter();

                //Insert another paragraph.
                Word.Paragraph oPara25;
                oRng2 = oDoc2.Bookmarks.get_Item(ref oEndOfDoc).Range;
                oPara25 = oDoc2.Content.Paragraphs.Add(ref oRng2);
                oPara25.Range.Text = "Начало дня приборное: 10:00:00                                                        Начало дня программное: 10:00:00";
                oPara25.Range.Font.Size = 9;
                oPara25.Range.Font.Bold = 0;
                oPara25.Format.SpaceAfter = 4;
                oPara25.Range.InsertParagraphAfter();

                //Insert another paragraph.
                Word.Paragraph oPara26;
                oRng2 = oDoc2.Bookmarks.get_Item(ref oEndOfDoc).Range;
                oPara26 = oDoc2.Content.Paragraphs.Add(ref oRng2);
                oPara26.Range.Text = "Период отчета: с " + date1_sut.AddHours(-1) + " по " + date2_sut.AddHours(-1).AddSeconds(-1);
                oPara26.Range.Font.Size = 9;
                oPara26.Range.Font.Bold = 0;
                oPara26.Format.SpaceAfter = 8;
                oPara26.Range.InsertParagraphAfter();

                //Insert another paragraph.
                Word.Paragraph oPara27;
                oRng2 = oDoc2.Bookmarks.get_Item(ref oEndOfDoc).Range;
                oPara27 = oDoc2.Content.Paragraphs.Add(ref oRng2);
                oPara27.Range.Text = "Суточный отчет";
                oPara27.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                oPara27.Range.Font.Size = 14;
                oPara27.Range.Font.Bold = 1;
                oPara27.Format.SpaceAfter = 4;
                oPara27.Range.InsertParagraphAfter();






                //Insert a 3 x 5 table, fill it with data, and make the first row
                //bold and italic.
                Word.Table oTable3;
                Word.Range wrdRng3 = oDoc2.Bookmarks.get_Item(ref oEndOfDoc).Range;
                oTable3 = oDoc2.Tables.Add(wrdRng3, (2 + interval_sut.Days), 6, ref oMissing, ref oMissing);
                oTable3.Range.ParagraphFormat.SpaceBefore = 1;
                oTable3.Range.ParagraphFormat.SpaceAfter = 1;
                oTable3.Range.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                oTable3.Rows[1].Range.Font.Size = 8;
                oTable3.Rows[1].Range.Font.Bold = 0;
                oTable3.Range.Font.Size = 8;
                oTable3.Range.Font.Bold = 0;
                oTable3.Range.InsertParagraphAfter();

                oTable3.Columns[1].Width = oWord2.CentimetersToPoints((float)2);
                oTable3.Columns[2].Width = oWord2.CentimetersToPoints((float)2.5);
                oTable3.Columns[3].Width = oWord2.CentimetersToPoints((float)2.5);
                oTable3.Columns[4].Width = oWord2.CentimetersToPoints((float)2.2);
                oTable3.Columns[5].Width = oWord2.CentimetersToPoints((float)2.2);
                oTable3.Columns[6].Width = oWord2.CentimetersToPoints((float)2);




                oWord2.ActiveWindow.ActivePane.View.SeekView = Word.WdSeekView.wdSeekCurrentPageFooter;
                oWord2.ActiveWindow.ActivePane.Selection.Font.Name = "Arial";
                oWord2.ActiveWindow.ActivePane.Selection.Font.Size = 10;
                oWord2.ActiveWindow.ActivePane.Selection.Font.Color = 0;
                oWord2.ActiveWindow.Selection.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight;
                oWord2.ActiveWindow.ActivePane.Selection.TypeText("Стр № ");
                oWord2.ActiveWindow.ActivePane.Selection.Fields.Add(oWord2.ActiveWindow.ActivePane.Selection.Range, Word.WdFieldType.wdFieldPage, oMissing, oMissing);
                oWord2.ActiveWindow.ActivePane.Selection.TypeText(" из ");
                oWord2.ActiveWindow.ActivePane.Selection.Fields.Add(oWord2.ActiveWindow.ActivePane.Selection.Range, Word.WdFieldType.wdFieldNumPages, oMissing, oMissing);
                oWord2.ActiveWindow.ActivePane.View.SeekView = Word.WdSeekView.wdSeekMainDocument;




                Word.Border[] borders2 = new Word.Border[6];//массив бордеров
                borders2[0] = oTable3.Borders[Word.WdBorderType.wdBorderLeft];//левая граница 
                borders2[1] = oTable3.Borders[Word.WdBorderType.wdBorderRight];//правая граница 
                borders2[2] = oTable3.Borders[Word.WdBorderType.wdBorderTop];//нижняя граница 
                borders2[3] = oTable3.Borders[Word.WdBorderType.wdBorderBottom];//верхняя граница
                borders2[4] = oTable3.Borders[Word.WdBorderType.wdBorderHorizontal];//горизонтальная граница
                borders2[5] = oTable3.Borders[Word.WdBorderType.wdBorderVertical];//вертикальная граница

                foreach (Word.Border border in borders2)
                {
                    border.LineStyle = Word.WdLineStyle.wdLineStyleSingle;//ставим стиль границы 
                    border.Color = Word.WdColor.wdColorBlack;//задаем цвет границы
                }
                //          oTable3.Rows[1].HeadingFormat = -1;
                oTable3.Cell(1, 1).Range.Text = "Дата";
                oTable3.Cell(1, 2).Range.Text = "Vраб.общ., [м3] (потребление)";
                oTable3.Cell(1, 3).Range.Text = "Vст.общ., [м3] (потребление)";
                oTable3.Cell(1, 4).Range.Text = "P, [бар]";
                oTable3.Cell(1, 5).Range.Text = "T, [" + Convert.ToChar(176) + "С]";
                oTable3.Cell(1, 6).Range.Text = "К кор.";

                oTable3.Cell(2 + interval_sut.Days, 1).Range.Text = "Итого:";


                //Insert another paragraph.
                Word.Paragraph oPara29;
                oRng2 = oDoc2.Bookmarks.get_Item(ref oEndOfDoc).Range;
                oPara29 = oDoc2.Content.Paragraphs.Add(ref oRng2);
                oPara29.Range.Text = "Примечание: в интервалах, затенённых серым цветом, содержатся сообщения о начале или завершении нештатных ситуаций.";
                oPara29.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
                oPara29.Range.Font.Size = 7;
                oPara29.Range.Font.Bold = 0;
                oPara29.Range.Font.Italic = 1;
                oPara29.Range.Font.Underline = Word.WdUnderline.wdUnderlineSingle;
                oPara29.Format.SpaceAfter = 4;
                oPara29.Format.SpaceBefore = 4;
                oPara29.Range.InsertParagraphAfter();

                Word.Paragraph oPara30;
                oRng2 = oDoc2.Bookmarks.get_Item(ref oEndOfDoc).Range;
                oPara30 = oDoc2.Content.Paragraphs.Add(ref oRng2);
                oPara30.Range.Text = "________________________________________________________________________________________";
                oPara30.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
                oPara30.Range.Font.Size = 10;
                oPara30.Range.Font.Bold = 1;
                oPara30.Format.SpaceAfter = 12;
                oPara30.Range.InsertParagraphAfter();

                Word.Paragraph oPara31;
                oRng2 = oDoc2.Bookmarks.get_Item(ref oEndOfDoc).Range;
                oPara31 = oDoc2.Content.Paragraphs.Add(ref oRng2);
                oPara31.Range.Text = "Представитель поставщика:________________________________//";
                oPara31.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
                oPara31.Range.Font.Size = 10;
                oPara31.Range.Font.Bold = 1;
                oPara31.Range.Font.Italic = 1;
                oPara31.Format.SpaceAfter = 12;
                oPara31.Range.InsertParagraphAfter();


                Word.Paragraph oPara32;
                oRng2 = oDoc2.Bookmarks.get_Item(ref oEndOfDoc).Range;
                oPara32 = oDoc2.Content.Paragraphs.Add(ref oRng2);
                oPara32.Range.Text = "Ответственный за учет:________________________________/Смолярчук А.Н./";
                oPara32.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
                oPara32.Range.Font.Size = 10;
                oPara32.Range.Font.Bold = 1;
                oPara32.Range.Font.Italic = 1;
                oPara32.Format.SpaceAfter = 12;
                oPara32.Range.InsertParagraphAfter();

                Word.Paragraph oPara33;
                oRng2 = oDoc2.Bookmarks.get_Item(ref oEndOfDoc).Range;
                oPara33 = oDoc2.Content.Paragraphs.Add(ref oRng2);
                oPara33.Range.Text = "Ответственный за прибор:________________________________//";
                oPara33.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
                oPara33.Range.Font.Size = 10;
                oPara33.Range.Font.Bold = 1;
                oPara33.Range.Font.Italic = 1;
                oPara33.Format.SpaceAfter = 12;
                oPara33.Range.InsertParagraphAfter();






                int k1 = 0;
                int gas_mark_gray_sut = 0;

                decimal gas_v_r_p, gas_v_st_p;
                decimal gas_pressure_sut = 0;
                decimal gas_temperature_sut = 0;
                decimal gas_kkor_sut = 0;
                decimal gas_v_r_p_sum = 0;
                decimal gas_v_st_p_sum = 0;
                decimal gas_pressure_sum = 0;
                decimal gas_temperature_sum = 0;
                string date1_sql;
                string date1_str;


                for (int k = 0; k <= (interval_sut.Days - 1); k++)
                {
                    gas_v_r_p = 0;
                    gas_v_st_p = 0;
                    gas_pressure_sut = 0;
                    gas_temperature_sut = 0;
                    gas_kkor_sut = 0;


                    for (int j = 1; j <= 24; j++)
                    {

                        date1_str = date1_sut.ToString();

                        if (date1_str.Length == 19)
                        {
                            date1_sql = date1_str.Substring(6, 4) + date1_str.Substring(3, 2) + date1_str.Substring(0, 2) + date1_str.Substring(11, 2) + date1_str.Substring(14, 2) + date1_str.Substring(17, 2);
                        }
                        else
                        {
                            date1_sql = date1_str.Substring(6, 4) + date1_str.Substring(3, 2) + date1_str.Substring(0, 2) + "0" + date1_str.Substring(11, 1) + date1_str.Substring(13, 2) + date1_str.Substring(16, 2);
                        }

                        result = MySqlLib.MySqlData.MySqlExecuteData.SqlReturnDataset("SELECT * FROM gas where gas_datetime =" + date1_sql + " LIMIT 0,1", conn_str);



                        if (result.ResultData.DefaultView.Table.Rows[0]["gas_mark_gray"].ToString() == "1")
                        {
                            gas_mark_gray_sut = 1;
                        }

                        v_r_sum = v_r_sum + Convert.ToDecimal(result.ResultData.DefaultView.Table.Rows[0]["gas_v_r_p"].ToString());
                        v_st_sum = v_st_sum + Convert.ToDecimal(result.ResultData.DefaultView.Table.Rows[0]["gas_v_st_p"].ToString());

                        pressure_sr = pressure_sr + Convert.ToDecimal(result.ResultData.DefaultView.Table.Rows[0]["gas_pressure"].ToString());
                        temperature_sr = pressure_sr + Convert.ToDecimal(result.ResultData.DefaultView.Table.Rows[0]["gas_temperature"].ToString());

                        gas_pressure_sut = gas_pressure_sut + Convert.ToDecimal(result.ResultData.DefaultView.Table.Rows[0]["gas_pressure"].ToString());
                        gas_temperature_sut = gas_temperature_sut + Convert.ToDecimal(result.ResultData.DefaultView.Table.Rows[0]["gas_temperature"].ToString());
                        gas_kkor_sut = gas_kkor_sut + Convert.ToDecimal(result.ResultData.DefaultView.Table.Rows[0]["gas_kkor"].ToString());



                        gas_v_r_p = gas_v_r_p + Convert.ToDecimal(result.ResultData.DefaultView.Table.Rows[0]["gas_v_r_p"].ToString());
                        gas_v_st_p = gas_v_st_p + Convert.ToDecimal(result.ResultData.DefaultView.Table.Rows[0]["gas_v_st_p"].ToString());
                        gas_pressure_sum = gas_pressure_sum + Convert.ToDecimal(result.ResultData.DefaultView.Table.Rows[0]["gas_pressure"].ToString());
                        gas_temperature_sum = gas_temperature_sum + Convert.ToDecimal(result.ResultData.DefaultView.Table.Rows[0]["gas_temperature"].ToString());

                        date1_sut = date1_sut.AddHours(1);


                    }

                    gas_v_r_p_sum = gas_v_r_p_sum + gas_v_r_p;
                    gas_v_st_p_sum = gas_v_st_p_sum + gas_v_st_p;

                    oTable3.Cell(2 + k, 1).Range.Text = Convert.ToString(date1_sut.Date.AddDays(-1)).Substring(0, 6) + Convert.ToString(date1_sut.Date.AddDays(-1)).Substring(8, 2);
                    if (gas_mark_gray_sut == 1)
                    {
                        oTable3.Cell(2 + k, 2).Range.Shading.BackgroundPatternColor = Word.WdColor.wdColorGray125;
                        oTable3.Cell(2 + k, 3).Range.Shading.BackgroundPatternColor = Word.WdColor.wdColorGray125;
                        oTable3.Cell(2 + k, 4).Range.Shading.BackgroundPatternColor = Word.WdColor.wdColorGray125;
                        oTable3.Cell(2 + k, 5).Range.Shading.BackgroundPatternColor = Word.WdColor.wdColorGray125;
                    }

                    oTable3.Cell(2 + k, 2).Range.Text = Convert.ToString(gas_v_r_p);
                    oTable3.Cell(2 + k, 3).Range.Text = Convert.ToString(gas_v_st_p);
                    oTable3.Cell(2 + k, 4).Range.Text = Convert.ToString(Math.Round(gas_pressure_sut / 24, 4));
                    oTable3.Cell(2 + k, 5).Range.Text = Convert.ToString(Math.Round(gas_temperature_sut / 24, 2));
                    oTable3.Cell(2 + k, 6).Range.Text = Convert.ToString(Math.Round(gas_kkor_sut / 24, 5));

                    k1 = (27 + 26 * k);
                }

                oTable3.Cell(2 + interval_sut.Days, 2).Range.Text = Convert.ToString(gas_v_r_p_sum);
                oTable3.Cell(2 + interval_sut.Days, 3).Range.Text = Convert.ToString(gas_v_st_p_sum);



                oWord2.Visible = true;
            }





            if (checkBox3.Checked)
            {
                string date1_month_akt = "";
                string date2_month_akt = "";

                string date1_sql;
                string date1_str;

                //Start Word and create a new document.
                Word._Application oWord4;
                Word._Document oDoc4;
                oWord4 = new Word.Application();
                oWord4.Visible = true;
                oDoc4 = oWord4.Documents.Add(ref oMissing, ref oMissing,
                    ref oMissing, ref oMissing);

                oDoc4.PageSetup.Orientation = Word.WdOrientation.wdOrientPortrait;
                oDoc4.PageSetup.TopMargin = oDoc4.Content.Application.CentimetersToPoints((float)1.5);
                oDoc4.PageSetup.LeftMargin = oDoc4.Content.Application.CentimetersToPoints((float)2);
                oDoc4.PageSetup.RightMargin = oDoc4.Content.Application.CentimetersToPoints((float)2);
                //Insert a paragraph at the beginning of the document.
                Word.Paragraph oPara40;
                oPara40 = oDoc4.Content.Paragraphs.Add(ref oMissing);
                oPara40.Range.Text = "Приложение №1";
                oPara40.Range.Font.Name = "Times New Roman";
                oPara40.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight;
                oPara40.Range.Font.Size = 10;
                oPara40.Range.Font.Bold = 1;
                oPara40.Range.Font.Italic = 1;
                oPara40.Format.SpaceAfter = 4;    //24 pt spacing after paragraph.
                oPara40.Range.InsertParagraphAfter();

                //Insert a paragraph at the end of the document.
                Word.Paragraph oPara41;
                object oRng4 = oDoc4.Bookmarks.get_Item(ref oEndOfDoc).Range;
                oPara41 = oDoc4.Content.Paragraphs.Add(ref oRng4);
                oPara41.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight;
                oPara41.Range.Text = "к договору поставки газа №13-5-7118 ИВ от 01.11.2012 между";
                oPara41.Range.Font.Size = 10;
                oPara41.Range.Font.Italic = 1;
                oPara41.Range.Font.Bold = 0;
                oPara41.Format.SpaceAfter = 4;
                oPara41.Range.InsertParagraphAfter();


                Word.Paragraph oPara42;
                oRng4 = oDoc4.Bookmarks.get_Item(ref oEndOfDoc).Range;
                oPara42 = oDoc4.Content.Paragraphs.Add(ref oRng4);
                oPara42.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight;
                oPara42.Range.Text = "ООО «Газпром межрегионгаз Иваново» (Поставщик)";
                oPara42.Range.Font.Size = 10;
                oPara42.Range.Font.Italic = 1;
                oPara42.Range.Font.Bold = 0;
                oPara42.Format.SpaceAfter = 4;
                oPara42.Range.InsertParagraphAfter();
                Word.Paragraph oPara43;
                oRng4 = oDoc4.Bookmarks.get_Item(ref oEndOfDoc).Range;
                oPara43 = oDoc4.Content.Paragraphs.Add(ref oRng4);
                oPara43.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight;
                oPara43.Range.Text = " и ОАО «Аньковское» (Покупатель)";
                oPara43.Range.Font.Size = 10;
                oPara43.Range.Font.Italic = 1;
                oPara43.Range.Font.Bold = 0;
                oPara43.Format.SpaceAfter = 24;
                oPara43.Range.InsertParagraphAfter();

                Word.Paragraph oPara44;
                oRng4 = oDoc4.Bookmarks.get_Item(ref oEndOfDoc).Range;
                oPara44 = oDoc4.Content.Paragraphs.Add(ref oRng4);
                oPara44.Range.Text = "АКТ";
                oPara44.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                oPara44.Range.Font.Size = 10;
                oPara44.Range.Font.Italic = 0;
                oPara44.Range.Font.Bold = 1;
                oPara44.Format.SpaceAfter = 4;
                oPara44.Range.InsertParagraphAfter();

                Word.Paragraph oPara45;
                oRng4 = oDoc4.Bookmarks.get_Item(ref oEndOfDoc).Range;
                oPara45 = oDoc4.Content.Paragraphs.Add(ref oRng4);
                oPara45.Range.Text = "поданного - принятого газа";
                oPara45.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                oPara45.Range.Font.Size = 10;
                oPara45.Range.Font.Italic = 0;
                oPara45.Range.Font.Bold = 1;
                oPara45.Format.SpaceAfter = 4;
                oPara45.Range.InsertParagraphAfter();

                Word.Paragraph oPara46;
                oRng4 = oDoc4.Bookmarks.get_Item(ref oEndOfDoc).Range;
                oPara46 = oDoc4.Content.Paragraphs.Add(ref oRng4);
                oPara46.Range.Text = "между ООО «Газпром межрегионгаз Иваново» и ОАО «Аньковское»";
                oPara46.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                oPara46.Range.Font.Size = 10;
                oPara46.Range.Font.Italic = 0;
                oPara46.Range.Font.Bold = 1;
                oPara46.Format.SpaceAfter = 4;
                oPara46.Range.InsertParagraphAfter();

                Word.Paragraph oPara47;
                oRng4 = oDoc4.Bookmarks.get_Item(ref oEndOfDoc).Range;
                oPara47 = oDoc4.Content.Paragraphs.Add(ref oRng4);
                oPara47.Range.Text = "по договору поставки газа № 13 – 5 – 7118 ИВ от 01.11.2012 г.";
                oPara47.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                oPara47.Range.Font.Size = 10;
                oPara47.Range.Font.Italic = 0;
                oPara47.Range.Font.Bold = 1;
                oPara47.Format.SpaceAfter = 4;
                oPara47.Range.InsertParagraphAfter();



                if (date1_akt.Month == 1) { date1_month_akt = "Январь"; }
                if (date1_akt.Month == 2) { date1_month_akt = "Февраль"; }
                if (date1_akt.Month == 3) { date1_month_akt = "Март"; }
                if (date1_akt.Month == 4) { date1_month_akt = "Апрель"; }
                if (date1_akt.Month == 5) { date1_month_akt = "Май"; }
                if (date1_akt.Month == 6) { date1_month_akt = "Июнь"; }
                if (date1_akt.Month == 7) { date1_month_akt = "Июль"; }
                if (date1_akt.Month == 8) { date1_month_akt = "Август"; }
                if (date1_akt.Month == 9) { date1_month_akt = "Сентябрь"; }
                if (date1_akt.Month == 10) { date1_month_akt = "Октябрь"; }
                if (date1_akt.Month == 11) { date1_month_akt = "Ноябрь"; }
                if (date1_akt.Month == 12) { date1_month_akt = "Декабрь"; }

                Word.Paragraph oPara48;
                oRng4 = oDoc4.Bookmarks.get_Item(ref oEndOfDoc).Range;
                oPara48 = oDoc4.Content.Paragraphs.Add(ref oRng4);
                oPara48.Range.Text = "За " + date1_month_akt + " " + date1_akt.Year + " года";
                oPara48.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                oPara48.Range.Font.Size = 10;
                oPara48.Range.Font.Italic = 0;
                oPara48.Range.Font.Bold = 1;
                oPara48.Format.SpaceAfter = 24;
                oPara48.Range.InsertParagraphAfter();


                if (date1_akt.Month == 1) { date1_month_akt = "Января"; }
                if (date1_akt.Month == 2) { date1_month_akt = "Февраля"; }
                if (date1_akt.Month == 3) { date1_month_akt = "Марта"; }
                if (date1_akt.Month == 4) { date1_month_akt = "Апреля"; }
                if (date1_akt.Month == 5) { date1_month_akt = "Мая"; }
                if (date1_akt.Month == 6) { date1_month_akt = "Июня"; }
                if (date1_akt.Month == 7) { date1_month_akt = "Июля"; }
                if (date1_akt.Month == 8) { date1_month_akt = "Августа"; }
                if (date1_akt.Month == 9) { date1_month_akt = "Сентября"; }
                if (date1_akt.Month == 10) { date1_month_akt = "Октября"; }
                if (date1_akt.Month == 11) { date1_month_akt = "Ноября"; }
                if (date1_akt.Month == 12) { date1_month_akt = "Декабря"; }


                if (date2_akt.Month == 1) { date2_month_akt = "Января"; }
                if (date2_akt.Month == 2) { date2_month_akt = "Февраля"; }
                if (date2_akt.Month == 3) { date2_month_akt = "Марта"; }
                if (date2_akt.Month == 4) { date2_month_akt = "Апреля"; }
                if (date2_akt.Month == 5) { date2_month_akt = "Мая"; }
                if (date2_akt.Month == 6) { date2_month_akt = "Июня"; }
                if (date2_akt.Month == 7) { date2_month_akt = "Июля"; }
                if (date2_akt.Month == 8) { date2_month_akt = "Августа"; }
                if (date2_akt.Month == 9) { date2_month_akt = "Сентября"; }
                if (date2_akt.Month == 10) { date2_month_akt = "Октября"; }
                if (date2_akt.Month == 11) { date2_month_akt = "Ноября"; }
                if (date2_akt.Month == 12) { date2_month_akt = "Декабря"; }


                Word.Paragraph oPara49;
                oRng4 = oDoc4.Bookmarks.get_Item(ref oEndOfDoc).Range;
                oPara49 = oDoc4.Content.Paragraphs.Add(ref oRng4);
                oPara49.Range.Text = date2_akt.Day + " " + date2_month_akt + " " + date2_akt.Year + " г.";
                oPara49.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight;
                oPara49.Range.Font.Size = 10;
                oPara49.Range.Font.Italic = 0;
                oPara49.Range.Font.Bold = 1;
                oPara49.Format.SpaceAfter = 24;
                oPara49.Range.InsertParagraphAfter();

                Word.Paragraph oPara50;
                oRng4 = oDoc4.Bookmarks.get_Item(ref oEndOfDoc).Range;
                oPara50 = oDoc4.Content.Paragraphs.Add(ref oRng4);
                oPara50.Range.Text = "              Мы, нижеподписавшиеся, ООО «Газпром межрегионгаз Иваново», именуемое в дальнейшем «Поставщик», в лице генерального директора Мазалова Сергея Владимировича, действующего на основании Устава, и";
                oPara50.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphJustify;
                oPara50.Range.Font.Size = 10;
                oPara50.Range.Font.Italic = 0;
                oPara50.Range.Font.Bold = 0;
                oPara50.Format.SpaceAfter = 4;
                oPara50.Range.InsertParagraphAfter();

                Word.Paragraph oPara51;
                oRng4 = oDoc4.Bookmarks.get_Item(ref oEndOfDoc).Range;
                oPara51 = oDoc4.Content.Paragraphs.Add(ref oRng4);
                oPara51.Range.Text = "              ОАО «Аньковское», именуемое в дальнейшем «Покупатель», в лице генерального директора Грязновой Ирины Львовны, действующего на основании Устава,";
                oPara51.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphJustify;
                oPara51.Range.Font.Size = 10;
                oPara51.Range.Font.Italic = 0;
                oPara51.Range.Font.Bold = 0;
                oPara51.Format.SpaceAfter = 4;
                oPara51.Range.InsertParagraphAfter();

                decimal v_st_sum_akt = 0;

                for (int k = 0; k <= (interval_akt.Days - 1); k++)
                {



                    for (int j = 1; j <= 24; j++)
                    {

                        date1_str = date1_akt.ToString();

                        if (date1_str.Length == 19)
                        {
                            date1_sql = date1_str.Substring(6, 4) + date1_str.Substring(3, 2) + date1_str.Substring(0, 2) + date1_str.Substring(11, 2) + date1_str.Substring(14, 2) + date1_str.Substring(17, 2);
                        }
                        else
                        {
                            date1_sql = date1_str.Substring(6, 4) + date1_str.Substring(3, 2) + date1_str.Substring(0, 2) + "0" + date1_str.Substring(11, 1) + date1_str.Substring(13, 2) + date1_str.Substring(16, 2);
                        }

                        result = MySqlLib.MySqlData.MySqlExecuteData.SqlReturnDataset("SELECT * FROM gas where gas_datetime =" + date1_sql + " LIMIT 0,1", conn_str);






                        v_st_sum_akt = v_st_sum_akt + Convert.ToDecimal(result.ResultData.DefaultView.Table.Rows[0]["gas_v_st_p"].ToString());


                        date1_akt = date1_akt.AddHours(1);


                    }

                }



                Word.Paragraph oPara52;
                oRng4 = oDoc4.Bookmarks.get_Item(ref oEndOfDoc).Range;
                oPara52 = oDoc4.Content.Paragraphs.Add(ref oRng4);
                oPara52.Range.Text = "              составили настоящий акт о том, что за период с " + date1_akt_table.Day + " " + date1_month_akt + " по " + date2_akt.Day + " " + date2_month_akt + " " + date2_akt.Year + " г. Поставщик передал, а Покупатель  принял газ в объёме " + Convert.ToString(Math.Truncate(v_st_sum_akt) / 1000) + " тыс. н.м" + Convert.ToChar(179) + " согласно ежесуточных данных Приложения, являющегося неотъемлемой частью настоящего акта.";
                oPara52.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphJustify;
                oPara52.Range.Font.Size = 10;
                oPara52.Range.Font.Italic = 0;
                oPara52.Range.Font.Bold = 0;
                oPara52.Format.SpaceAfter = 18;
                oPara52.Range.InsertParagraphAfter();


                Word.Table oTable4;
                Word.Range wrdRng4 = oDoc4.Bookmarks.get_Item(ref oEndOfDoc).Range;
                oTable4 = oDoc4.Tables.Add(wrdRng4, 5, 3, ref oMissing, ref oMissing);
                oTable4.Range.ParagraphFormat.SpaceAfter = 1;
                oTable4.Range.ParagraphFormat.SpaceBefore = 1;
                oTable4.Columns[1].Width = oWord4.CentimetersToPoints((float)10);
                oTable4.Columns[2].Width = oWord4.CentimetersToPoints((float)4);
                oTable4.Columns[3].Width = oWord4.CentimetersToPoints((float)4);
                oTable4.Range.Font.Size = 11;
                oTable4.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
                oTable4.Range.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;


                oTable4.Cell(1, 1).Range.Text = "Наименование";
                oTable4.Cell(1, 1).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                oTable4.Cell(1, 2).Range.Text = "Объемная теплота сгорания, ккал/ м" + Convert.ToChar(179);
                oTable4.Cell(1, 2).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                oTable4.Cell(1, 3).Range.Text = "Объем, тыс.н.м" + Convert.ToChar(179);
                oTable4.Cell(1, 3).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                oTable4.Cell(2, 1).Range.Text = "Всего принято-переданно в целом по договору";
                oTable4.Cell(3, 1).Range.Text = "(Вид газа ________ ) газ, принятый-переданный по всем точкам подключения, в т.ч.";
                oTable4.Cell(4, 1).Range.Text = "Точка подключения: Ивановская обл., Ильинский р-он, с. Аньково, ул. Советская, 101";

                oTable4.Cell(2, 3).Range.Text = Convert.ToString(Math.Truncate(v_st_sum_akt) / 1000);
                oTable4.Cell(2, 3).Range.Font.Italic = 1;
                oTable4.Cell(2, 3).Range.Font.Bold = 1;
                oTable4.Cell(2, 3).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                oTable4.Cell(4, 3).Range.Text = Convert.ToString(Math.Truncate(v_st_sum_akt) / 1000);
                oTable4.Cell(4, 3).Range.Font.Italic = 1;
                oTable4.Cell(4, 3).Range.Font.Bold = 1;
                oTable4.Cell(4, 3).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;



                Word.Paragraph oPara53;
                oRng4 = oDoc4.Bookmarks.get_Item(ref oEndOfDoc).Range;
                oPara53 = oDoc4.Content.Paragraphs.Add(ref oRng4);
                oPara53.Range.Text = "Поставщик                                                                                  Покупатель";
                oPara53.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                oPara53.Range.Font.Size = 10;
                oPara53.Range.Font.Italic = 0;
                oPara53.Range.Font.Bold = 1;
                oPara53.Format.SpaceBefore = 32;
                oPara53.Format.SpaceAfter = 10;
                oPara53.Range.InsertParagraphAfter();

                Word.Paragraph oPara54;
                oRng4 = oDoc4.Bookmarks.get_Item(ref oEndOfDoc).Range;
                oPara54 = oDoc4.Content.Paragraphs.Add(ref oRng4);
                oPara54.Range.Text = "__________________                                                                        ______________";
                oPara54.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                oPara54.Range.Font.Size = 10;
                oPara54.Range.Font.Italic = 0;
                oPara54.Range.Font.Bold = 1;
                oPara54.Format.SpaceAfter = 4;
                oPara54.Range.InsertParagraphAfter();

                oWord4.Visible = true;
            }


            if (checkBox4.Checked)
            {

                string date1_sql_pril;
                string date1_str_pril;
                decimal gas_v_st_p_pril = 0;

                string date1_sql_pril2;
                string date1_str_pril2;
                decimal gas_v_st_p_pril2 = 0;

                decimal gas_v_st_p_sum_pril = 0;
                decimal pererashod = 0;

                //Start Word and create a new document.
                Word._Application oWord5;
                Word._Document oDoc5;
                oWord5 = new Word.Application();
                oWord5.Visible = true;
                oDoc5 = oWord5.Documents.Add(ref oMissing, ref oMissing,
                    ref oMissing, ref oMissing);

                oDoc5.PageSetup.Orientation = Word.WdOrientation.wdOrientPortrait;
                oDoc5.PageSetup.TopMargin = oDoc5.Content.Application.CentimetersToPoints((float)1.5);
                oDoc5.PageSetup.LeftMargin = oDoc5.Content.Application.CentimetersToPoints((float)2);
                oDoc5.PageSetup.RightMargin = oDoc5.Content.Application.CentimetersToPoints((float)2);

                //Insert a paragraph at the beginning of the document.
                Word.Paragraph oPara60;
                oPara60 = oDoc5.Content.Paragraphs.Add(ref oMissing);
                oPara60.Range.Text = "Приложение к Акту поданного - принятого газа";
                oPara60.Range.Font.Name = "Times New Roman";
                oPara60.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                oPara60.Range.Font.Size = 12;
                oPara60.Range.Font.Bold = 1;
                oPara60.Range.Font.Italic = 0;
                oPara60.Format.SpaceAfter = 4;    //24 pt spacing after paragraph.
                oPara60.Range.InsertParagraphAfter();

                //Insert a paragraph at the end of the document.
                Word.Paragraph oPara61;
                object oRng5 = oDoc5.Bookmarks.get_Item(ref oEndOfDoc).Range;
                oPara61 = oDoc5.Content.Paragraphs.Add(ref oRng5);
                oPara61.Range.Text = "между ООО «Газпром межрегионгаз Иваново» и ОАО «Аньковское»";
                oPara61.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                oPara61.Range.Font.Size = 12;
                oPara61.Range.Font.Italic = 0;
                oPara61.Range.Font.Bold = 0;
                oPara61.Format.SpaceAfter = 4;
                oPara61.Range.InsertParagraphAfter();

                string date2_month_pril = "";

                if (date2_pril.Month == 1) { date2_month_pril = "Января"; }
                if (date2_pril.Month == 2) { date2_month_pril = "Февраля"; }
                if (date2_pril.Month == 3) { date2_month_pril = "Марта"; }
                if (date2_pril.Month == 4) { date2_month_pril = "Апреля"; }
                if (date2_pril.Month == 5) { date2_month_pril = "Мая"; }
                if (date2_pril.Month == 6) { date2_month_pril = "Июня"; }
                if (date2_pril.Month == 7) { date2_month_pril = "Июля"; }
                if (date2_pril.Month == 8) { date2_month_pril = "Августа"; }
                if (date2_pril.Month == 9) { date2_month_pril = "Сентября"; }
                if (date2_pril.Month == 10) { date2_month_pril = "Октября"; }
                if (date2_pril.Month == 11) { date2_month_pril = "Ноября"; }
                if (date2_pril.Month == 12) { date2_month_pril = "Декабря"; }


                //Insert a paragraph at the end of the document.
                Word.Paragraph oPara62;
                oRng5 = oDoc5.Bookmarks.get_Item(ref oEndOfDoc).Range;
                oPara62 = oDoc5.Content.Paragraphs.Add(ref oRng5);
                oPara62.Range.Text = "от " + date2.Day + " " + date2_month_pril + " " + date2_pril.Year + " г";
                oPara62.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight;
                oPara62.Range.Font.Size = 12;
                oPara62.Range.Font.Italic = 0;
                oPara62.Range.Font.Underline = Word.WdUnderline.wdUnderlineSingle;
                oPara62.Range.Font.Bold = 0;
                oPara62.Format.SpaceAfter = 4;
                oPara62.Range.InsertParagraphAfter();


                if (date2_pril.Month == 1) { date2_month_pril = "Январь"; }
                if (date2_pril.Month == 2) { date2_month_pril = "Февраль"; }
                if (date2_pril.Month == 3) { date2_month_pril = "Март"; }
                if (date2_pril.Month == 4) { date2_month_pril = "Апрель"; }
                if (date2_pril.Month == 5) { date2_month_pril = "Май"; }
                if (date2_pril.Month == 6) { date2_month_pril = "Июнь"; }
                if (date2_pril.Month == 7) { date2_month_pril = "Июль"; }
                if (date2_pril.Month == 8) { date2_month_pril = "Август"; }
                if (date2_pril.Month == 9) { date2_month_pril = "Сентябрь"; }
                if (date2_pril.Month == 10) { date2_month_pril = "Октябрь"; }
                if (date2_pril.Month == 11) { date2_month_pril = "Ноябрь"; }
                if (date2_pril.Month == 12) { date2_month_pril = "Декабрь"; }

                //Insert a paragraph at the end of the document.
                Word.Paragraph oPara63;
                oRng5 = oDoc5.Bookmarks.get_Item(ref oEndOfDoc).Range;
                oPara63 = oDoc5.Content.Paragraphs.Add(ref oRng5);
                oPara63.Range.Text = "За " + date2_month_pril + " месяц 2013 года";
                oPara63.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                oPara62.Range.Font.Underline = Word.WdUnderline.wdUnderlineNone;
                oPara63.Range.Font.Size = 12;
                oPara63.Range.Font.Italic = 0;
                oPara63.Range.Font.Bold = 0;
                oPara63.Format.SpaceAfter = 4;
                oPara63.Range.InsertParagraphAfter();


                for (int k = 0; k <= (interval_pril2.Days - 1); k++)
                {

                    for (int j = 1; j <= 24; j++)
                    {
                        date1_str_pril2 = date1_pril2.ToString();

                        if (date1_str_pril2.Length == 19)
                        {
                            date1_sql_pril2 = date1_str_pril2.Substring(6, 4) + date1_str_pril2.Substring(3, 2) + date1_str_pril2.Substring(0, 2) + date1_str_pril2.Substring(11, 2) + date1_str_pril2.Substring(14, 2) + date1_str_pril2.Substring(17, 2);
                        }
                        else
                        {
                            date1_sql_pril2 = date1_str_pril2.Substring(6, 4) + date1_str_pril2.Substring(3, 2) + date1_str_pril2.Substring(0, 2) + "0" + date1_str_pril2.Substring(11, 1) + date1_str_pril2.Substring(13, 2) + date1_str_pril2.Substring(16, 2);
                        }

                        result = MySqlLib.MySqlData.MySqlExecuteData.SqlReturnDataset("SELECT * FROM gas where gas_datetime =" + date1_sql_pril2 + " LIMIT 0,1", conn_str);
                        gas_v_st_p_pril2 = gas_v_st_p_pril2 + Convert.ToDecimal(result.ResultData.DefaultView.Table.Rows[0]["gas_v_st_p"].ToString());
                        date1_pril2 = date1_pril2.AddHours(1);
                    }

                }





                //Insert a paragraph at the end of the document.
                Word.Paragraph oPara64;
                oRng5 = oDoc5.Bookmarks.get_Item(ref oEndOfDoc).Range;
                oPara64 = oDoc5.Content.Paragraphs.Add(ref oRng5);
                oPara64.Range.Text = "Принято всего " + Convert.ToString(Math.Truncate(gas_v_st_p_pril2) / 1000) + " тыс. н.м." + Convert.ToChar(179) + ", в том числе за каждые сутки месяца:";
                oPara64.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
                oPara64.Range.Font.Size = 12;
                oPara64.Range.Font.Italic = 0;
                oPara64.Range.Font.Bold = 0;
                oPara64.Format.SpaceAfter = 4;
                oPara64.Range.InsertParagraphAfter();





                Word.Table oTable5;
                Word.Range wrdRng5 = oDoc5.Bookmarks.get_Item(ref oEndOfDoc).Range;
                oTable5 = oDoc5.Tables.Add(wrdRng5, 3 + interval.Days, 5, ref oMissing, ref oMissing);
                oTable5.Range.ParagraphFormat.SpaceAfter = 1;
                oTable5.Range.ParagraphFormat.SpaceBefore = 1;
                oTable5.Columns[1].Width = oWord5.CentimetersToPoints((float)3);
                oTable5.Columns[2].Width = oWord5.CentimetersToPoints((float)3.8);
                oTable5.Columns[3].Width = oWord5.CentimetersToPoints((float)3.8);
                oTable5.Columns[4].Width = oWord5.CentimetersToPoints((float)3.8);
                oTable5.Columns[5].Width = oWord5.CentimetersToPoints((float)3.8);
                oTable5.Range.Font.Size = 11;
                oTable5.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
                oTable5.Range.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

                oTable5.Cell(1, 1).Range.Text = "Дата";
                oTable5.Cell(1, 1).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                oTable5.Cell(1, 1).Range.Bold = 1;
                oTable5.Cell(1, 2).Range.Text = "Суточный договорной объем";
                oTable5.Cell(1, 2).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                oTable5.Cell(1, 2).Range.Bold = 1;
                oTable5.Cell(1, 3).Range.Text = "Максимальный суточный объем";
                oTable5.Cell(1, 3).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                oTable5.Cell(1, 3).Range.Bold = 1;
                oTable5.Cell(1, 4).Range.Text = "Фактический объем принятого газа";
                oTable5.Cell(1, 4).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                oTable5.Cell(1, 4).Range.Bold = 1;
                oTable5.Cell(1, 5).Range.Text = "Перерасход газа за каждые сутки от максимального суточного  объема";
                oTable5.Cell(1, 5).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                oTable5.Cell(1, 5).Range.Bold = 1;

                oTable5.Cell(2, 1).Range.Text = "1";
                oTable5.Cell(2, 1).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                oTable5.Cell(2, 1).Range.Bold = 1;
                oTable5.Cell(2, 2).Range.Text = "2";
                oTable5.Cell(2, 2).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                oTable5.Cell(2, 2).Range.Bold = 1;
                oTable5.Cell(2, 3).Range.Text = "3";
                oTable5.Cell(2, 3).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                oTable5.Cell(2, 3).Range.Bold = 1;
                oTable5.Cell(2, 4).Range.Text = "4";
                oTable5.Cell(2, 4).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                oTable5.Cell(2, 4).Range.Bold = 1;
                oTable5.Cell(2, 5).Range.Text = "5";
                oTable5.Cell(2, 5).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                oTable5.Cell(2, 5).Range.Bold = 1;

                for (int k = 0; k <= (interval_pril.Days - 1); k++)
                {
                    oTable5.Cell(k + 3, 1).Range.Text = Convert.ToString(k + 1);
                    oTable5.Cell(k + 3, 1).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    oTable5.Cell(k + 3, 1).Range.Bold = 1;
                    oTable5.Cell(k + 3, 1).Range.Italic = 1;

                    oTable5.Cell(k + 3, 2).Range.Text = "2,1";
                    oTable5.Cell(k + 3, 2).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    oTable5.Cell(k + 3, 2).Range.Bold = 0;
                    oTable5.Cell(k + 3, 2).Range.Italic = 0;

                    oTable5.Cell(k + 3, 3).Range.Text = "2,310";
                    oTable5.Cell(k + 3, 3).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    oTable5.Cell(k + 3, 3).Range.Bold = 0;
                    oTable5.Cell(k + 3, 3).Range.Italic = 0;

                    gas_v_st_p_pril = 0;

                    for (int j = 1; j <= 24; j++)
                    {
                        date1_str_pril = date1_pril.ToString();

                        if (date1_str_pril.Length == 19)
                        {
                            date1_sql_pril = date1_str_pril.Substring(6, 4) + date1_str_pril.Substring(3, 2) + date1_str_pril.Substring(0, 2) + date1_str_pril.Substring(11, 2) + date1_str_pril.Substring(14, 2) + date1_str_pril.Substring(17, 2);
                        }
                        else
                        {
                            date1_sql_pril = date1_str_pril.Substring(6, 4) + date1_str_pril.Substring(3, 2) + date1_str_pril.Substring(0, 2) + "0" + date1_str_pril.Substring(11, 1) + date1_str_pril.Substring(13, 2) + date1_str_pril.Substring(16, 2);
                        }

                        result = MySqlLib.MySqlData.MySqlExecuteData.SqlReturnDataset("SELECT * FROM gas where gas_datetime =" + date1_sql_pril + " LIMIT 0,1", conn_str);
                        gas_v_st_p_pril = gas_v_st_p_pril + Convert.ToDecimal(result.ResultData.DefaultView.Table.Rows[0]["gas_v_st_p"].ToString());
                        date1_pril = date1_pril.AddHours(1);
                    }

                    oTable5.Cell(k + 3, 4).Range.Text = Convert.ToString(Math.Round(gas_v_st_p_pril / 1000, 3));
                    oTable5.Cell(k + 3, 4).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    oTable5.Cell(k + 3, 4).Range.Bold = 0;
                    oTable5.Cell(k + 3, 4).Range.Italic = 0;

                    if ((gas_v_st_p_pril - 2310) > 0)
                    {
                        oTable5.Cell(k + 3, 5).Range.Text = Convert.ToString(Math.Round((gas_v_st_p_pril - 2310) / 1000, 3));
                        pererashod = pererashod + Math.Round((gas_v_st_p_pril - 2310) / 1000, 3);
                    }
                    else
                    {
                        oTable5.Cell(k + 3, 5).Range.Text = "0";
                    }
                    oTable5.Cell(k + 3, 5).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    oTable5.Cell(k + 3, 5).Range.Bold = 0;
                    oTable5.Cell(k + 3, 5).Range.Italic = 0;

                    gas_v_st_p_sum_pril = gas_v_st_p_sum_pril + gas_v_st_p_pril;

                }




                oTable5.Cell(1 + interval.Days + 3, 1).Range.Text = "Всего:";
                oTable5.Cell(1 + interval.Days + 3, 1).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                oTable5.Cell(1 + interval.Days + 3, 1).Range.Bold = 1;
                oTable5.Cell(1 + interval.Days + 3, 1).Range.Italic = 0;

                oTable5.Cell(1 + interval.Days + 3, 2).Range.Text = Convert.ToString(interval_pril.Days * 2.1);
                oTable5.Cell(1 + interval.Days + 3, 2).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                oTable5.Cell(1 + interval.Days + 3, 2).Range.Bold = 1;
                oTable5.Cell(1 + interval.Days + 3, 2).Range.Italic = 0;

                oTable5.Cell(1 + interval.Days + 3, 3).Range.Text = Convert.ToString(interval_pril.Days * 2.31);
                oTable5.Cell(1 + interval.Days + 3, 3).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                oTable5.Cell(1 + interval.Days + 3, 3).Range.Bold = 1;
                oTable5.Cell(1 + interval.Days + 3, 3).Range.Italic = 0;

                oTable5.Cell(1 + interval.Days + 3, 4).Range.Text = Convert.ToString(Math.Truncate(gas_v_st_p_sum_pril) / 1000);
                oTable5.Cell(1 + interval.Days + 3, 4).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                oTable5.Cell(1 + interval.Days + 3, 4).Range.Bold = 1;
                oTable5.Cell(1 + interval.Days + 3, 4).Range.Italic = 0;

                oTable5.Cell(1 + interval.Days + 3, 5).Range.Text = Convert.ToString(pererashod);
                oTable5.Cell(1 + interval.Days + 3, 5).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                oTable5.Cell(1 + interval.Days + 3, 5).Range.Bold = 1;
                oTable5.Cell(1 + interval.Days + 3, 5).Range.Italic = 0;


                Word.Paragraph oPara65;
                oRng5 = oDoc5.Bookmarks.get_Item(ref oEndOfDoc).Range;
                oPara65 = oDoc5.Content.Paragraphs.Add(ref oRng5);
                oPara65.Range.Text = "Поставщик                                                                                  Покупатель";
                oPara65.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                oPara65.Range.Font.Size = 10;
                oPara65.Range.Font.Italic = 0;
                oPara65.Range.Font.Bold = 1;
                oPara65.Format.SpaceBefore = 12;
                oPara65.Format.SpaceAfter = 10;
                oPara65.Range.InsertParagraphAfter();

                Word.Paragraph oPara66;
                oRng5 = oDoc5.Bookmarks.get_Item(ref oEndOfDoc).Range;
                oPara66 = oDoc5.Content.Paragraphs.Add(ref oRng5);
                oPara66.Range.Text = "__________________                                                                                    _________________";
                oPara66.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                oPara66.Range.Font.Size = 8;
                oPara66.Range.Font.Italic = 0;
                oPara66.Range.Font.Bold = 1;
                oPara66.Format.SpaceAfter = 4;
                oPara66.Range.InsertParagraphAfter();

            }


            button1.Enabled = true;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //string conn_str = "Database=resources;Data Source=localhost;User Id=root;Password=Rfnfgekmrf48";
            string conn_str = "Database=resources;Data Source=10.1.1.50;User Id=sa;Password=Rfnfgekmrf48";
            MySqlLib.MySqlData.MySqlExecute.MyResult result = new MySqlLib.MySqlData.MySqlExecute.MyResult();
            MySqlLib.MySqlData.MySqlExecute.MyResult result2 = new MySqlLib.MySqlData.MySqlExecute.MyResult();
            MySqlLib.MySqlData.MySqlExecute.MyResult result3 = new MySqlLib.MySqlData.MySqlExecute.MyResult();
            MySqlLib.MySqlData.MySqlExecute.MyResult result4 = new MySqlLib.MySqlData.MySqlExecute.MyResult();
            MySqlLib.MySqlData.MySqlExecute.MyResult result5 = new MySqlLib.MySqlData.MySqlExecute.MyResult();
            MySqlLib.MySqlData.MySqlExecute.MyResult result6 = new MySqlLib.MySqlData.MySqlExecute.MyResult();
            MySqlLib.MySqlData.MySqlExecute.MyResult result7 = new MySqlLib.MySqlData.MySqlExecute.MyResult();
            MySqlLib.MySqlData.MySqlExecute.MyResult result8 = new MySqlLib.MySqlData.MySqlExecute.MyResult();
            MySqlLib.MySqlData.MySqlExecute.MyResult result9 = new MySqlLib.MySqlData.MySqlExecute.MyResult();
            MySqlLib.MySqlData.MySqlExecute.MyResult result10 = new MySqlLib.MySqlData.MySqlExecute.MyResult();
            MySqlLib.MySqlData.MySqlExecute.MyResult result11 = new MySqlLib.MySqlData.MySqlExecute.MyResult();
            MySqlLib.MySqlData.MySqlExecute.MyResult result12 = new MySqlLib.MySqlData.MySqlExecute.MyResult();
            MySqlLib.MySqlData.MySqlExecute.MyResult result13 = new MySqlLib.MySqlData.MySqlExecute.MyResult();
            MySqlLib.MySqlData.MySqlExecute.MyResult result14 = new MySqlLib.MySqlData.MySqlExecute.MyResult();
            MySqlLib.MySqlData.MySqlExecute.MyResult result15 = new MySqlLib.MySqlData.MySqlExecute.MyResult();
            MySqlLib.MySqlData.MySqlExecute.MyResult result16 = new MySqlLib.MySqlData.MySqlExecute.MyResult();

            MySqlLib.MySqlData.MySqlExecute.MyResult result17 = new MySqlLib.MySqlData.MySqlExecute.MyResult();
            MySqlLib.MySqlData.MySqlExecute.MyResult result18 = new MySqlLib.MySqlData.MySqlExecute.MyResult();
            MySqlLib.MySqlData.MySqlExecute.MyResult result19 = new MySqlLib.MySqlData.MySqlExecute.MyResult();
            MySqlLib.MySqlData.MySqlExecute.MyResult result20 = new MySqlLib.MySqlData.MySqlExecute.MyResult();

            DateTime date3 = DateTime.Now;

            textBox1.Text = Convert.ToString(date3.Year);
            textBox2.Text = Convert.ToString(date3.Year);
            textBox3.Text = Convert.ToString(date3.Year);
            textBox4.Text = Convert.ToString(date3.Year);

            if (date3.Month == 1)
            {
                comboBox1.Text = "Декабрь";
                textBox1.Text = Convert.ToString(date3.Year - 1);
                comboBox3.Text = "Декабрь";
                textBox3.Text = Convert.ToString(date3.Year - 1);
                comboBox4.Text = "Декабрь";
                textBox4.Text = Convert.ToString(date3.Year - 1);
            }
            if (date3.Month == 2)
            {
                comboBox1.Text = "Январь";
                comboBox3.Text = "Январь";
                comboBox4.Text = "Январь";
            }
            if (date3.Month == 3)
            {
                comboBox1.Text = "Февраль";
                comboBox3.Text = "Февраль";
                comboBox4.Text = "Февраль";
            }
            if (date3.Month == 4)
            {
                comboBox1.Text = "Март";
                comboBox3.Text = "Март";
                comboBox4.Text = "Март";
            }
            if (date3.Month == 5)
            {
                comboBox1.Text = "Апрель";
                comboBox3.Text = "Апрель";
                comboBox4.Text = "Апрель";
            }
            if (date3.Month == 6)
            {
                comboBox1.Text = "Май";
                comboBox3.Text = "Май";
                comboBox4.Text = "Май";
            }
            if (date3.Month == 7)
            {
                comboBox1.Text = "Июнь";
                comboBox3.Text = "Июнь";
                comboBox4.Text = "Июнь";
            }
            if (date3.Month == 8)
            {
                comboBox1.Text = "Июль";
                comboBox3.Text = "Июль";
                comboBox4.Text = "Июль";
            }
            if (date3.Month == 9)
            {
                comboBox1.Text = "Август";
                comboBox3.Text = "Август";
                comboBox4.Text = "Август";
            }
            if (date3.Month == 10)
            {
                comboBox1.Text = "Сентябрь";
                comboBox3.Text = "Сентябрь";
                comboBox4.Text = "Сентябрь";
            }
            if (date3.Month == 11)
            {
                comboBox1.Text = "Октябрь";
                comboBox3.Text = "Октябрь";
                comboBox4.Text = "Октябрь";
            }
            if (date3.Month == 12)
            {
                comboBox1.Text = "Ноябрь";
                comboBox3.Text = "Ноябрь";
                comboBox4.Text = "Ноябрь";
            }

            // date3 = date3.AddHours(-11);

            string date3_str, date3_sql;


            for (int k = 0; k <= 11; k++)
            {

                date3_str = date3.ToString();

                if (date3_str.Length == 19)
                {
                    date3_sql = date3_str.Substring(6, 4) + date3_str.Substring(3, 2) + date3_str.Substring(0, 2) + date3_str.Substring(11, 2) + "00" + "00";
                }
                else
                {
                    date3_sql = date3_str.Substring(6, 4) + date3_str.Substring(3, 2) + date3_str.Substring(0, 2) + "0" + date3_str.Substring(11, 1) + "00" + "00";
                }





                result = MySqlLib.MySqlData.MySqlExecute.SqlScalar("SELECT gas_datetime FROM gas where gas_datetime =" + date3_sql + " LIMIT 0,1", conn_str);
                result2 = MySqlLib.MySqlData.MySqlExecute.SqlScalar("SELECT gas_v_st_p FROM gas where gas_datetime =" + date3_sql + " LIMIT 0,1", conn_str);


                result15 = MySqlLib.MySqlData.MySqlExecute.SqlScalar("SELECT stoki_date FROM stoki where stoki_date =" + date3_sql + " LIMIT 0,1", conn_str);
                result16 = MySqlLib.MySqlData.MySqlExecute.SqlScalar("SELECT stoki FROM stoki where stoki_date =" + date3_sql + " LIMIT 0,1", conn_str);


                ListViewItem lvi, lvi7;
                ListViewItem.ListViewSubItem lvsi, lvsi13;


                //-----------------------------
                lvi = new ListViewItem();
                lvsi = new ListViewItem.ListViewSubItem();

                lvi7 = new ListViewItem();
                lvsi13 = new ListViewItem.ListViewSubItem();

                if (result.ResultText != null)
                {

                    if (result.ResultText.Length == 19)
                    {
                        lvi.Text = result.ResultText.Substring(0, 16);
                    }
                    else
                    {
                        lvi.Text = result.ResultText.Substring(0, 11) + "0" + result.ResultText.Substring(11, 4);
                    }
                }
                else
                {
                    lvi.Text = "Показаний нет";
                }

                if (result2.ResultText != null)
                {
                    lvsi.Text = result2.ResultText;
                }
                else
                {
                    lvsi.Text = "Показаний нет";
                }


                if (result15.ResultText != null)
                {

                    if (result15.ResultText.Length == 19)
                    {
                        lvi7.Text = result15.ResultText.Substring(0, 16);
                    }
                    else
                    {
                        lvi7.Text = result15.ResultText.Substring(0, 11) + "0" + result15.ResultText.Substring(11, 4);
                    }
                }
                else
                {
                    lvi7.Text = "Показаний нет";
                }

                if (result16.ResultText != null)
                {
                    lvsi13.Text = result16.ResultText;
                }
                else
                {
                    lvsi13.Text = "Показаний нет";
                }


                lvi.SubItems.Add(lvsi);
                listView1.Items.Add(lvi);

                lvi7.SubItems.Add(lvsi13);
                listView7.Items.Add(lvi7);

                date3 = date3.AddHours(-1);




            }


            DateTime date4 = DateTime.Now;
            //date4 = date4.AddDays(-12);

            string date4_str, date4_sql;

            string[] v_st_s = new string[13];
            string[] datetime = new string[13];
            string[] datetime_w = new string[13];
            string[] water_ch1 = new string[13];
            string[] water_ch2 = new string[13];

            string[] datetime_w_2466 = new string[13];
            string[] water_ch1_2466 = new string[13];
            string[] water_ch2_2466 = new string[13];

            string[] datetime_s_2094 = new string[13];
            string[] steam_ch1_2094 = new string[13];

            string[] datetime_s_2123 = new string[13];
            string[] steam_ch1_2123 = new string[13];

            string[] datetime_stoki = new string[13];
            string[] stoki = new string[13];

            for (int k = 0; k <= 12; k++)
            {

                date4_str = date4.ToString();

                if (date4_str.Length == 19)
                {
                    date4_sql = date4_str.Substring(6, 4) + date4_str.Substring(3, 2) + date4_str.Substring(0, 2) + "10" + "00" + "00";
                }
                else
                {
                    date4_sql = date4_str.Substring(6, 4) + date4_str.Substring(3, 2) + date4_str.Substring(0, 2) + "10" + "00" + "00";
                }


                result = MySqlLib.MySqlData.MySqlExecute.SqlScalar("SELECT gas_datetime FROM gas where gas_datetime =" + date4_sql + " LIMIT 0,1", conn_str);
                result2 = MySqlLib.MySqlData.MySqlExecute.SqlScalar("SELECT gas_v_st_s FROM gas where gas_datetime =" + date4_sql + " LIMIT 0,1", conn_str);

                datetime[k] = result.ResultText;
                v_st_s[k] = result2.ResultText;

                date4_sql = date4_str.Substring(6, 4) + date4_str.Substring(3, 2) + date4_str.Substring(0, 2);

                result3 = MySqlLib.MySqlData.MySqlExecute.SqlScalar("SELECT water_date FROM water2467 where water_date =" + date4_sql + " LIMIT 0,1", conn_str);
                result4 = MySqlLib.MySqlData.MySqlExecute.SqlScalar("SELECT water_ch1 FROM water2467 where water_date =" + date4_sql + " LIMIT 0,1", conn_str);
                result5 = MySqlLib.MySqlData.MySqlExecute.SqlScalar("SELECT water_ch2 FROM water2467 where water_date =" + date4_sql + " LIMIT 0,1", conn_str);

                datetime_w[k] = result3.ResultText;
                water_ch1[k] = result4.ResultText;
                water_ch2[k] = result5.ResultText;


                date4_sql = date4_str.Substring(6, 4) + date4_str.Substring(3, 2) + date4_str.Substring(0, 2);

                result6 = MySqlLib.MySqlData.MySqlExecute.SqlScalar("SELECT water_date FROM water2466 where water_date =" + date4_sql + " LIMIT 0,1", conn_str);
                result7 = MySqlLib.MySqlData.MySqlExecute.SqlScalar("SELECT water_ch1 FROM water2466 where water_date =" + date4_sql + " LIMIT 0,1", conn_str);
                result8 = MySqlLib.MySqlData.MySqlExecute.SqlScalar("SELECT water_ch2 FROM water2466 where water_date =" + date4_sql + " LIMIT 0,1", conn_str);


                datetime_w_2466[k] = result6.ResultText;
                water_ch1_2466[k] = result7.ResultText;
                water_ch2_2466[k] = result8.ResultText;


                date4_sql = date4_str.Substring(6, 4) + date4_str.Substring(3, 2) + date4_str.Substring(0, 2);

                result9 = MySqlLib.MySqlData.MySqlExecute.SqlScalar("SELECT steam_date FROM steam2094 where steam_date =" + date4_sql + " LIMIT 0,1", conn_str);
                result10 = MySqlLib.MySqlData.MySqlExecute.SqlScalar("SELECT steam_ch1 FROM steam2094 where steam_date =" + date4_sql + " LIMIT 0,1", conn_str);


                datetime_s_2094[k] = result9.ResultText;
                steam_ch1_2094[k] = result10.ResultText;

                date4_sql = date4_str.Substring(6, 4) + date4_str.Substring(3, 2) + date4_str.Substring(0, 2);

                result11 = MySqlLib.MySqlData.MySqlExecute.SqlScalar("SELECT steam_date FROM steam2123 where steam_date =" + date4_sql + " LIMIT 0,1", conn_str);
                result12 = MySqlLib.MySqlData.MySqlExecute.SqlScalar("SELECT steam_ch1 FROM steam2123 where steam_date =" + date4_sql + " LIMIT 0,1", conn_str);


                datetime_s_2123[k] = result11.ResultText;
                steam_ch1_2123[k] = result12.ResultText;


                date4_sql = date4_str.Substring(6, 4) + date4_str.Substring(3, 2) + date4_str.Substring(0, 2);

                result13 = MySqlLib.MySqlData.MySqlExecute.SqlScalar("SELECT stoki_date FROM stoki where stoki_date =" + date4_sql + " LIMIT 0,1", conn_str);
                result14 = MySqlLib.MySqlData.MySqlExecute.SqlScalar("SELECT stoki FROM stoki where stoki_date =" + date4_sql + " LIMIT 0,1", conn_str);


                datetime_stoki[k] = result13.ResultText;
                stoki[k] = result14.ResultText;




                date4 = date4.AddDays(-1);
            }

            for (int k = 0; k <= 11; k++)
            {
                ListViewItem lvi, lvi2, lvi3, lvi4, lvi5, lvi6;
                ListViewItem.ListViewSubItem lvsi, lvsi2, lvsi2_2, lvsi3_2, lvsi3, lvsi4, lvsi5, lvsi6, lvsi7, lvsi8, lvsi9, lvsi10, lvsi11, lvsi12;
                //-----------------------------
                lvi = new ListViewItem();
                lvsi = new ListViewItem.ListViewSubItem();
                lvi2 = new ListViewItem();
                lvsi2 = new ListViewItem.ListViewSubItem();
                lvsi3 = new ListViewItem.ListViewSubItem();
                lvsi2_2 = new ListViewItem.ListViewSubItem();
                lvsi3_2 = new ListViewItem.ListViewSubItem();

                lvi3 = new ListViewItem();
                lvsi4 = new ListViewItem.ListViewSubItem();
                lvsi5 = new ListViewItem.ListViewSubItem();
                lvsi6 = new ListViewItem.ListViewSubItem();
                lvsi7 = new ListViewItem.ListViewSubItem();


                lvi4 = new ListViewItem();
                lvsi8 = new ListViewItem.ListViewSubItem();
                lvsi9 = new ListViewItem.ListViewSubItem();

                lvi5 = new ListViewItem();
                lvsi10 = new ListViewItem.ListViewSubItem();
                lvsi11 = new ListViewItem.ListViewSubItem();

                lvi6 = new ListViewItem();
                lvsi12 = new ListViewItem.ListViewSubItem();
                


                if (datetime[k] == null)
                {
                    lvi.Text = "Показаний нет";
                }
                else
                {
                    lvi.Text = datetime[k].Substring(0, 10);
                }
                if (v_st_s[k] == null)
                {
                    lvsi.Text = "Показаний нет";
                }
                else
                {
                    lvsi.Text = Convert.ToString(Convert.ToDecimal(v_st_s[k]) - Convert.ToDecimal(v_st_s[k + 1]));
                }

                if (datetime_w[k] == null)
                {
                    lvi2.Text = "Показаний нет";
                }
                else
                {
                    lvi2.Text = datetime_w[k].Substring(0, 10);
                }
                if (water_ch1[k] == null)
                {
                    lvsi2.Text = "Показаний нет";
                }
                else
                {
                    lvsi2.Text = Convert.ToString(Convert.ToDecimal(water_ch1[k]) - Convert.ToDecimal(water_ch1[k + 1]));
                }
                if (water_ch1[k] == null)
                {
                    lvsi3.Text = "Показаний нет";
                }
                else
                {
                    lvsi3.Text = Convert.ToString(Convert.ToDecimal(water_ch1[k]));
                }

                if (water_ch2[k] == null)
                {
                    lvsi2_2.Text = "Показаний нет";
                }
                else
                {
                    lvsi2_2.Text = Convert.ToString(Convert.ToDecimal(water_ch2[k]) - Convert.ToDecimal(water_ch2[k + 1]));
                }
                if (water_ch2[k] == null)
                {
                    lvsi3_2.Text = "Показаний нет";
                }
                else
                {
                    lvsi3_2.Text = Convert.ToString(Convert.ToDecimal(water_ch2[k]));
                }



                if (datetime_w_2466[k] == null)
                {
                    lvi3.Text = "Показаний нет";
                }
                else
                {
                    lvi3.Text = datetime_w_2466[k].Substring(0, 10);
                }
                if (water_ch1_2466[k] == null)
                {
                    lvsi4.Text = "Показаний нет";
                }
                else
                {
                    lvsi4.Text = Convert.ToString(Convert.ToDecimal(water_ch1_2466[k]) - Convert.ToDecimal(water_ch1_2466[k + 1]));
                }
                if (water_ch2_2466[k] == null)
                {
                    lvsi5.Text = "Показаний нет";
                }
                else
                {
                    lvsi5.Text = Convert.ToString(Convert.ToDecimal(water_ch1_2466[k]));
                }
                if (water_ch2_2466[k] == null)
                {
                    lvsi6.Text = "Показаний нет";
                }
                else
                {
                    lvsi6.Text = Convert.ToString(Convert.ToDecimal(water_ch2_2466[k]) - Convert.ToDecimal(water_ch2_2466[k + 1]));
                }
                if (water_ch2_2466[k] == null)
                {
                    lvsi7.Text = "Показаний нет";
                }
                else
                {
                    lvsi7.Text = Convert.ToString(Convert.ToDecimal(water_ch2_2466[k]));
                }


                if (datetime_s_2094[k] == null)
                {
                    lvi4.Text = "Показаний нет";
                }
                else
                {
                    lvi4.Text = datetime_s_2094[k].Substring(0, 10);
                }
                if (steam_ch1_2094[k] == null)
                {
                    lvsi8.Text = "Показаний нет";
                    lvsi9.Text = "Показаний нет";
                }
                else
                {
                    lvsi8.Text = Convert.ToString(Convert.ToDecimal(steam_ch1_2094[k]) - Convert.ToDecimal(steam_ch1_2094[k + 1]));
                    lvsi9.Text = Convert.ToString(Convert.ToDecimal(steam_ch1_2094[k]));
                }

                if (datetime_s_2123[k] == null)
                {
                    lvi5.Text = "Показаний нет";
                }
                else
                {
                    lvi5.Text = datetime_s_2123[k].Substring(0, 10);
                }
                if (steam_ch1_2123[k] == null)
                {
                    lvsi10.Text = "Показаний нет";
                    lvsi11.Text = "Показаний нет";
                }
                else
                {
                    lvsi10.Text = Convert.ToString(Convert.ToDecimal(steam_ch1_2123[k]) - Convert.ToDecimal(steam_ch1_2123[k + 1]));
                    lvsi11.Text = Convert.ToString(Convert.ToDecimal(steam_ch1_2123[k]));
                }

                if (datetime_stoki[k] == null)
                {
                    lvi6.Text = "Показаний нет";
                }
                else
                {
                    lvi6.Text = datetime_stoki[k].Substring(0, 10);
                }

                if (stoki[k] == null)
                {
                    lvsi12.Text = "Показаний нет";
                }
                else
                {
                    lvsi12.Text = Convert.ToString(Convert.ToDecimal(stoki[k]));
                }


                lvi.SubItems.Add(lvsi);
                listView2.Items.Add(lvi);

                lvi2.SubItems.Add(lvsi2);
                lvi2.SubItems.Add(lvsi3);
                lvi2.SubItems.Add(lvsi2_2);
                lvi2.SubItems.Add(lvsi3_2);
                listView3.Items.Add(lvi2);

                lvi3.SubItems.Add(lvsi4);
                lvi3.SubItems.Add(lvsi5);
                lvi3.SubItems.Add(lvsi6);
                lvi3.SubItems.Add(lvsi7);
                listView4.Items.Add(lvi3);

                lvi4.SubItems.Add(lvsi8);
                lvi4.SubItems.Add(lvsi9);
                listView5.Items.Add(lvi4);

                lvi5.SubItems.Add(lvsi10);
                lvi5.SubItems.Add(lvsi11);
                listView6.Items.Add(lvi5);

                lvi6.SubItems.Add(lvsi12);
                listView8.Items.Add(lvi6);


            }





            /*
            
            chart1.Series[0].Points.AddY(1000.56);
            chart1.Series[0].Points.AddY(2000.56);
            chart1.Series[0].Points.AddY(3000.56);
            chart1.Series[0].Points.AddY(5000.56);

            chart1.ChartAreas["ChartArea1"].AxisX.CustomLabels.Add(0, 2, "10.12.2013");
            chart1.ChartAreas["ChartArea1"].AxisX.CustomLabels.Add(1, 3, "11.12.2013");
            */




            DateTime date3_w = DateTime.Now;


            if (date3_w.Month == 1)
            {
                comboBox2.Text = "Декабрь";
                textBox2.Text = Convert.ToString(date3.Year - 1);
            }
            if (date3_w.Month == 2)
            {
                comboBox2.Text = "Январь";
            }
            if (date3_w.Month == 3)
            {
                comboBox2.Text = "Февраль";
            }
            if (date3_w.Month == 4)
            {
                comboBox2.Text = "Март";
            }
            if (date3_w.Month == 5)
            {
                comboBox2.Text = "Апрель";
            }
            if (date3_w.Month == 6)
            {
                comboBox2.Text = "Май";
            }
            if (date3_w.Month == 7)
            {
                comboBox2.Text = "Июнь";
            }
            if (date3_w.Month == 8)
            {
                comboBox2.Text = "Июль";
            }
            if (date3_w.Month == 9)
            {
                comboBox2.Text = "Август";
            }
            if (date3_w.Month == 10)
            {
                comboBox2.Text = "Сентябрь";
            }
            if (date3_w.Month == 11)
            {
                comboBox2.Text = "Октябрь";
            }
            if (date3_w.Month == 12)
            {
                comboBox2.Text = "Ноябрь";
            }

            
            
            DateTime date5 = DateTime.Now;
            DateTime date6 = DateTime.Now;

            date5 = date5.AddDays(-1);
            date6 = date6.AddDays(-1);

            DateTime date7 = DateTime.Now;
            DateTime date8 = DateTime.Now;

            date7 = date7.AddDays(-1);
            date8 = date8.AddDays(-1);

            DateTime date9 = DateTime.Now;
            DateTime date10 = DateTime.Now;

            date9 = date9.AddDays(-1);
            date10 = date10.AddDays(-1);

            String date5_str, date5_sql;
            String date6_str, date6_sql;

            String date7_str, date7_sql;
            String date8_str, date8_sql;

            String date9_str, date9_sql;
            String date10_str, date10_sql;

            date5_str = "";
            date7_str = "";
            date9_str = "";

            Decimal active42 = 0;
            Decimal reactive42 = 0;

            string[] date42_arr = new string[12];
            string[] active42_arr = new string[12];
            string[] reactive42_arr = new string[12];

            Decimal active55 = 0;
            Decimal reactive55 = 0;

            string[] date55_arr = new string[12];
            string[] active55_arr = new string[12];
            string[] reactive55_arr = new string[12];

            Decimal active56 = 0;
            Decimal reactive56 = 0;

            string[] date56_arr = new string[12];
            string[] active56_arr = new string[12];
            string[] reactive56_arr = new string[12];




            date5 = new DateTime(date5.Year, date5.Month, date5.Day, 0, 30, 00);
            date6 = new DateTime(date6.Year, date6.Month, date6.Day, 1, 00, 00);

            date7 = new DateTime(date7.Year, date7.Month, date7.Day, 0, 40, 00);
            date8 = new DateTime(date8.Year, date8.Month, date8.Day, 1, 10, 00);

            date9 = new DateTime(date9.Year, date9.Month, date9.Day, 0, 43, 00);
            date10 = new DateTime(date10.Year, date10.Month, date10.Day, 1, 13, 00);

            for (int k = 0; k < 5; k++)
            {
                active42 = 0;
                reactive42 = 0;
                active55 = 0;
                reactive55 = 0;
                active56 = 0;
                reactive56 = 0;

                for (int m = 0; m < 24; m++)
                {

                    date5_str = date5.ToString();

                    if (date5_str.Length == 19)
                    {
                        date5_sql = date5_str.Substring(6, 4) + date5_str.Substring(3, 2) + date5_str.Substring(0, 2) + date5_str.Substring(11, 2) + date5_str.Substring(14, 2) + date5_str.Substring(17, 2);
                    }
                    else
                    {
                        date5_sql = date5_str.Substring(6, 4) + date5_str.Substring(3, 2) + date5_str.Substring(0, 2) + "0" + date5_str.Substring(11, 1) + date5_str.Substring(13, 2) + date5_str.Substring(16, 2) ;
                    }




                    date6_str = date6.ToString();

                    if (date6_str.Length == 19)
                    {
                        date6_sql = date6_str.Substring(6, 4) + date6_str.Substring(3, 2) + date6_str.Substring(0, 2) + date6_str.Substring(11, 2) + date6_str.Substring(14, 2) + date6_str.Substring(17, 2);
                    }
                    else
                    {
                        date6_sql = date6_str.Substring(6, 4) + date6_str.Substring(3, 2) + date6_str.Substring(0, 2) + "0" + date6_str.Substring(11, 1) + date6_str.Substring(13, 2) + date6_str.Substring(16, 2);
                    }

                    result17 = MySqlLib.MySqlData.MySqlExecute.SqlScalar("SELECT electro42_active FROM electro42 where electro42_datetime =" + date5_sql + " LIMIT 0,1", conn_str);
                    result18 = MySqlLib.MySqlData.MySqlExecute.SqlScalar("SELECT electro42_reactive FROM electro42 where electro42_datetime =" + date5_sql + " LIMIT 0,1", conn_str);
                    
                    result19 = MySqlLib.MySqlData.MySqlExecute.SqlScalar("SELECT electro42_active FROM electro42 where electro42_datetime =" + date6_sql + " LIMIT 0,1", conn_str);
                    result20 = MySqlLib.MySqlData.MySqlExecute.SqlScalar("SELECT electro42_reactive FROM electro42 where electro42_datetime =" + date6_sql + " LIMIT 0,1", conn_str);


                    active42 = active42 + Convert.ToDecimal(result17.ResultText)/2 + Convert.ToDecimal(result19.ResultText)/2;
                    reactive42 = reactive42 + Convert.ToDecimal(result18.ResultText) / 2 + Convert.ToDecimal(result20.ResultText) / 2;


                    date7_str = date7.ToString();

                    if (date7_str.Length == 19)
                    {
                        date7_sql = date7_str.Substring(6, 4) + date7_str.Substring(3, 2) + date7_str.Substring(0, 2) + date7_str.Substring(11, 2) + date7_str.Substring(14, 2) + date7_str.Substring(17, 2);
                    }
                    else
                    {
                        date7_sql = date7_str.Substring(6, 4) + date7_str.Substring(3, 2) + date7_str.Substring(0, 2) + "0" + date7_str.Substring(11, 1) + date7_str.Substring(13, 2) + date7_str.Substring(16, 2);
                    }


                    date8_str = date8.ToString();

                    if (date8_str.Length == 19)
                    {
                        date8_sql = date8_str.Substring(6, 4) + date8_str.Substring(3, 2) + date8_str.Substring(0, 2) + date8_str.Substring(11, 2) + date8_str.Substring(14, 2) + date8_str.Substring(17, 2);
                    }
                    else
                    {
                        date8_sql = date8_str.Substring(6, 4) + date8_str.Substring(3, 2) + date8_str.Substring(0, 2) + "0" + date8_str.Substring(11, 1) + date8_str.Substring(13, 2) + date8_str.Substring(16, 2);
                    }

                    result17 = MySqlLib.MySqlData.MySqlExecute.SqlScalar("SELECT electro55_active FROM electro55 where electro55_datetime =" + date7_sql + " LIMIT 0,1", conn_str);
                    result18 = MySqlLib.MySqlData.MySqlExecute.SqlScalar("SELECT electro55_reactive FROM electro55 where electro55_datetime =" + date7_sql + " LIMIT 0,1", conn_str);

                    result19 = MySqlLib.MySqlData.MySqlExecute.SqlScalar("SELECT electro55_active FROM electro55 where electro55_datetime =" + date8_sql + " LIMIT 0,1", conn_str);
                    result20 = MySqlLib.MySqlData.MySqlExecute.SqlScalar("SELECT electro55_reactive FROM electro55 where electro55_datetime =" + date8_sql + " LIMIT 0,1", conn_str);


                    active55 = active55 + Convert.ToDecimal(result17.ResultText) / 2 + Convert.ToDecimal(result19.ResultText) / 2;
                    reactive55 = reactive55 + Convert.ToDecimal(result18.ResultText) / 2 + Convert.ToDecimal(result20.ResultText) / 2;

                    
                    date9_str = date9.ToString();

                    if (date9_str.Length == 19)
                    {
                        date9_sql = date9_str.Substring(6, 4) + date9_str.Substring(3, 2) + date9_str.Substring(0, 2) + date9_str.Substring(11, 2) + date9_str.Substring(14, 2) + date9_str.Substring(17, 2);
                    }
                    else
                    {
                        date9_sql = date9_str.Substring(6, 4) + date9_str.Substring(3, 2) + date9_str.Substring(0, 2) + "0" + date9_str.Substring(11, 1) + date9_str.Substring(13, 2) + date9_str.Substring(16, 2);
                    }


                    date10_str = date10.ToString();

                    if (date10_str.Length == 19)
                    {
                        date10_sql = date10_str.Substring(6, 4) + date10_str.Substring(3, 2) + date10_str.Substring(0, 2) + date10_str.Substring(11, 2) + date10_str.Substring(14, 2) + date10_str.Substring(17, 2);
                    }
                    else
                    {
                        date10_sql = date10_str.Substring(6, 4) + date10_str.Substring(3, 2) + date10_str.Substring(0, 2) + "0" + date10_str.Substring(11, 1) + date10_str.Substring(13, 2) + date10_str.Substring(16, 2);
                    } 

                    
                    result17 = MySqlLib.MySqlData.MySqlExecute.SqlScalar("SELECT electro56_active FROM electro56 where electro56_datetime =" + date9_sql + " LIMIT 0,1", conn_str);
                    result18 = MySqlLib.MySqlData.MySqlExecute.SqlScalar("SELECT electro56_reactive FROM electro56 where electro56_datetime =" + date9_sql + " LIMIT 0,1", conn_str);

                    result19 = MySqlLib.MySqlData.MySqlExecute.SqlScalar("SELECT electro56_active FROM electro56 where electro56_datetime =" + date10_sql + " LIMIT 0,1", conn_str);
                    result20 = MySqlLib.MySqlData.MySqlExecute.SqlScalar("SELECT electro56_reactive FROM electro56 where electro56_datetime =" + date10_sql + " LIMIT 0,1", conn_str);


                    active56 = active56 + Convert.ToDecimal(result17.ResultText) / 2 + Convert.ToDecimal(result19.ResultText) / 2;
                    reactive56 = reactive56 + Convert.ToDecimal(result18.ResultText) / 2 + Convert.ToDecimal(result20.ResultText) / 2;

                    date5 = date5.AddMinutes(+60);
                    date6 = date6.AddMinutes(+60);
                    date7 = date7.AddMinutes(+60);
                    date8 = date8.AddMinutes(+60);
                    date9 = date9.AddMinutes(+60);
                    date10 = date10.AddMinutes(+60);

                }
                
                date42_arr[k] = date5_str.Substring(0, 2) + "." + date5_str.Substring(3, 2) + "." + date5_str.Substring(6, 4);
                active42_arr[k] = Convert.ToString(active42); 
                reactive42_arr[k] = Convert.ToString(reactive42);

                date55_arr[k] = date7_str.Substring(0, 2) + "." + date7_str.Substring(3, 2) + "." + date7_str.Substring(6, 4);
                active55_arr[k] = Convert.ToString(active55);
                reactive55_arr[k] = Convert.ToString(reactive55);

                date56_arr[k] = date9_str.Substring(0, 2) + "." + date9_str.Substring(3, 2) + "." + date9_str.Substring(6, 4);
                active56_arr[k] = Convert.ToString(active56);
                reactive56_arr[k] = Convert.ToString(reactive56); 
                
                date5 = date5.AddDays(-2);
                date6 = date6.AddDays(-2);
                date7 = date7.AddDays(-2);
                date8 = date8.AddDays(-2);
                date9 = date9.AddDays(-2);
                date10 = date10.AddDays(-2);
            }

            for (int k = 0; k <= 11; k++)
            {
                ListViewItem lvi7, lvi8, lvi9;
                ListViewItem.ListViewSubItem lvsi14, lvsi15, lvsi16, lvsi17, lvsi18, lvsi19;

                lvi7 = new ListViewItem();
                lvsi14 = new ListViewItem.ListViewSubItem();
                lvsi15 = new ListViewItem.ListViewSubItem();

                lvi8 = new ListViewItem();
                lvsi16 = new ListViewItem.ListViewSubItem();
                lvsi17 = new ListViewItem.ListViewSubItem();
                
                lvi9 = new ListViewItem();
                lvsi18 = new ListViewItem.ListViewSubItem();
                lvsi19 = new ListViewItem.ListViewSubItem();

                lvi7.Text = date42_arr[k];
                lvsi14.Text = active42_arr[k];
                lvsi15.Text = reactive42_arr[k];

                listView11.Items.Add(lvi7);
                lvi7.SubItems.Add(lvsi14);
                lvi7.SubItems.Add(lvsi15);

                lvi8.Text = date55_arr[k];
                lvsi16.Text = active55_arr[k];
                lvsi17.Text = reactive55_arr[k];

                listView9.Items.Add(lvi8);
                lvi8.SubItems.Add(lvsi16);
                lvi8.SubItems.Add(lvsi17);

                lvi9.Text = date56_arr[k];
                lvsi18.Text = active56_arr[k];
                lvsi19.Text = reactive56_arr[k];

                listView10.Items.Add(lvi9);
                lvi9.SubItems.Add(lvsi18);
                lvi9.SubItems.Add(lvsi19);
            }


        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                comboBox1.Enabled = false;
                textBox1.Enabled = false;

                dateTimePicker1.Enabled = false;
                dateTimePicker2.Enabled = false;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                comboBox1.Enabled = true;
                textBox1.Enabled = true;

                dateTimePicker1.Enabled = false;
                dateTimePicker2.Enabled = false;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                comboBox1.Enabled = false;
                textBox1.Enabled = false;

                dateTimePicker1.Enabled = true;
                dateTimePicker2.Enabled = true;
            }
        }


        private void radioButton4_CheckedChanged_1(object sender, EventArgs e)
        {
            if (radioButton4.Checked)
            {
                comboBox2.Enabled = false;
                textBox2.Enabled = false;

                dateTimePicker3.Enabled = false;
                dateTimePicker4.Enabled = false;
            }
        }

        private void radioButton5_CheckedChanged_1(object sender, EventArgs e)
        {
            if (radioButton5.Checked)
            {
                comboBox2.Enabled = true;
                textBox2.Enabled = true;

                dateTimePicker3.Enabled = false;
                dateTimePicker4.Enabled = false;
            }
        }

        private void radioButton6_CheckedChanged_1(object sender, EventArgs e)
        {
            if (radioButton6.Checked)
            {
                comboBox2.Enabled = false;
                textBox2.Enabled = false;

                dateTimePicker3.Enabled = true;
                dateTimePicker4.Enabled = true;
            }
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton7.Checked)
            {
                comboBox3.Enabled = false;
                textBox3.Enabled = false;

                dateTimePicker5.Enabled = false;
                dateTimePicker6.Enabled = false;
            }

        }


        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton8.Checked)
            {
                comboBox3.Enabled = true;
                textBox3.Enabled = true;

                dateTimePicker5.Enabled = false;
                dateTimePicker6.Enabled = false;
            }
        }


        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton9.Checked)
            {
                comboBox3.Enabled = false;
                textBox3.Enabled = false;

                dateTimePicker5.Enabled = true;
                dateTimePicker6.Enabled = true;
            }
        }

        private void radioButton10_CheckedChanged(object sender, EventArgs e)
        {
            comboBox4.Enabled = false;
            textBox4.Enabled = false;

            dateTimePicker7.Enabled = false;
            dateTimePicker8.Enabled = false;

        }


        private void radioButton11_CheckedChanged(object sender, EventArgs e)
        {
            comboBox4.Enabled = true;
            textBox4.Enabled = true;

            dateTimePicker7.Enabled = false;
            dateTimePicker8.Enabled = false;
        }

        private void radioButton12_CheckedChanged(object sender, EventArgs e)
        {
            comboBox4.Enabled = false;
            textBox4.Enabled = false;

            dateTimePicker7.Enabled = true;
            dateTimePicker8.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (checkBox7.Checked)
            {
                Excel.Workbook m_workBook = null;
                Excel.Worksheet m_workSheet = null;

                Excel._Application m_app = null;
                string filename = "D:\\Отчет за " +
                    DateTime.Now.Day + "." +
                    DateTime.Now.Month + "." +
                    DateTime.Now.Year + "(Маневровая).xls";// по умолчанию сохраняет в корень диска С:


                button2.Enabled = false;


                string conn_str = "Database=resources;Data Source=10.1.1.50;User Id=sa;Password=Rfnfgekmrf48";

                MySqlLib.MySqlData.MySqlExecuteData.MyResultData result = new MySqlLib.MySqlData.MySqlExecuteData.MyResultData();

                DateTime date1_w = new DateTime(2014, 1, 1);
                DateTime date2_w = new DateTime(2014, 1, 1);
                DateTime date22_w = new DateTime(2014, 1, 1);
                DateTime date1_w_otch = new DateTime(2014, 1, 1);
                DateTime date2_w_otch = new DateTime(2014, 1, 1);


                if (radioButton4.Checked)
                {
                    DateTime date1_1 = DateTime.Now.AddMonths(-1);
                    date1_w = new DateTime(date1_1.Year, date1_1.Month, 1, 11, 0, 0);

                    date1_1 = DateTime.Now;
                    date2_w = new DateTime(date1_1.Year, date1_1.Month, 1, 11, 0, 0);
                }



                if (radioButton5.Checked)
                {
                    if (comboBox2.Text == "Январь")
                    {
                        date1_w = new DateTime(Convert.ToInt32(textBox2.Text), 1, 1);
                        date2_w = date1_w.AddMonths(1);
                    }
                    if (comboBox2.Text == "Февраль")
                    {
                        date1_w = new DateTime(Convert.ToInt32(textBox2.Text), 2, 1);
                        date2_w = date1_w.AddMonths(1);
                    }
                    if (comboBox2.Text == "Март")
                    {
                        date1_w = new DateTime(Convert.ToInt32(textBox2.Text), 3, 1);
                        date2_w = date1_w.AddMonths(1);
                    }
                    if (comboBox2.Text == "Апрель")
                    {
                        date1_w = new DateTime(Convert.ToInt32(textBox2.Text), 4, 1);
                        date2_w = date1_w.AddMonths(1);
                    }
                    if (comboBox2.Text == "Май")
                    {
                        date1_w = new DateTime(Convert.ToInt32(textBox2.Text), 5, 1);
                        date2_w = date1_w.AddMonths(1);
                    }
                    if (comboBox2.Text == "Июнь")
                    {
                        date1_w = new DateTime(Convert.ToInt32(textBox2.Text), 6, 1);
                        date2_w = date1_w.AddMonths(1);
                    }
                    if (comboBox2.Text == "Июль")
                    {
                        date1_w = new DateTime(Convert.ToInt32(textBox2.Text), 7, 1);
                        date2_w = date1_w.AddMonths(1);
                    }
                    if (comboBox2.Text == "Август")
                    {
                        date1_w = new DateTime(Convert.ToInt32(textBox2.Text), 8, 1);
                        date2_w = date1_w.AddMonths(1);
                    }
                    if (comboBox2.Text == "Сентябрь")
                    {
                        date1_w = new DateTime(Convert.ToInt32(textBox2.Text), 9, 1);
                        date2_w = date1_w.AddMonths(1);
                    }
                    if (comboBox2.Text == "Октябрь")
                    {
                        date1_w = new DateTime(Convert.ToInt32(textBox2.Text), 10, 1);
                        date2_w = date1_w.AddMonths(1);
                    }
                    if (comboBox2.Text == "Ноябрь")
                    {
                        date1_w = new DateTime(Convert.ToInt32(textBox2.Text), 11, 1);
                        date2_w = date1_w.AddMonths(1);
                    }
                    if (comboBox2.Text == "Декабрь")
                    {
                        date1_w = new DateTime(Convert.ToInt32(textBox2.Text), 12, 1);
                        date2_w = date1_w.AddMonths(1);
                    }

                }

                if (radioButton6.Checked)
                {
                    date1_w = new DateTime(dateTimePicker3.Value.Year, dateTimePicker3.Value.Month, dateTimePicker3.Value.Day);
                    date2_w = new DateTime(dateTimePicker4.Value.Year, dateTimePicker4.Value.Month, dateTimePicker4.Value.Day + 1);
                }

                date22_w = date2_w.AddDays(-1);
                date1_w_otch = date1_w;
                date2_w_otch = date2_w;

                TimeSpan interval_w = date2_w - date1_w;

                int days_w = Convert.ToInt32(Math.Floor(interval_w.TotalDays));
                progressBar2.Maximum = Convert.ToInt32(days_w - 1);



                try
                {

                    // Создание приложения Excel.
                    m_app = new Microsoft.Office.Interop.Excel.Application();
                    m_app.ReferenceStyle = Excel.XlReferenceStyle.xlA1;
                    // Приложение "невидимо".
                    m_app.Visible = true;
                    // Приложение управляется пользователем.
                    m_app.UserControl = true;
                    // Добавление книги Excel.
                    m_workBook = m_app.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);


                    // Связь со страницей Excel.

                    m_app.StandardFont = "Courier new cyr";
                    m_app.StandardFontSize = 10;

                    m_workSheet = m_app.ActiveSheet as Excel.Worksheet;

                    m_workSheet.Columns.ColumnWidth = 8.5;

                    m_workSheet.Cells.NumberFormat = "@";

                    m_workSheet.get_Range("A1").ColumnWidth = 10;

                    m_workSheet.get_Range("A1", "K1").Merge(System.Type.Missing);
                    m_workSheet.get_Range("A1").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    m_workSheet.get_Range("A1").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    m_workSheet.Cells[1, 1] = "Отчет";

                    m_workSheet.get_Range("A2", "K2").Merge(System.Type.Missing);
                    m_workSheet.Cells[2, 1] = "о суточных параметрах расхода";
                    m_workSheet.get_Range("A2").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    m_workSheet.get_Range("A2").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                    m_workSheet.get_Range("A3", "K3").Merge(System.Type.Missing);




                    m_workSheet.Cells[3, 1] = "за " + String.Format("{0:dd/MM/yyyy}", date1_w) + "г. - " + String.Format("{0:dd/MM/yyyy}", date22_w) + "г.";


                    m_workSheet.get_Range("A3").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    m_workSheet.get_Range("A3").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                    m_workSheet.get_Range("A5", "K5").Merge(System.Type.Missing);
                    m_workSheet.Cells[5, 1] = "Абонент: 000000000000                             Договор N: ______________";
                    m_workSheet.get_Range("A5").HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    m_workSheet.get_Range("A5").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                    m_workSheet.get_Range("A7", "K7").Merge(System.Type.Missing);
                    m_workSheet.Cells[7, 1] = "Адрес: ________________________                   Тип расходомера: ________ ";
                    m_workSheet.get_Range("A7").HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    m_workSheet.get_Range("A7").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                    m_workSheet.get_Range("A9", "K9").Merge(System.Type.Missing);
                    m_workSheet.Cells[9, 1] = "Расходомер Днепр-7 N 3 (Маневровая)";
                    m_workSheet.get_Range("A9").HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    m_workSheet.get_Range("A9").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                    m_workSheet.get_Range("A11", "K11").Merge(System.Type.Missing);
                    m_workSheet.Cells[11, 1] = "Договорные расходы:                        Пределы измерений:";
                    m_workSheet.get_Range("A11").HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    m_workSheet.get_Range("A11").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                    m_workSheet.get_Range("A12", "K12").Merge(System.Type.Missing);
                    m_workSheet.Cells[12, 1] = "M под= _____ т.сут  М обр= _____ т.сут     G под max= _____  G под min= _____";
                    m_workSheet.get_Range("A12").HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    m_workSheet.get_Range("A12").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                    m_workSheet.get_Range("A16", "A18").Merge(System.Type.Missing);
                    m_workSheet.Cells[16, 1] = "ДАТА";
                    m_workSheet.get_Range("A16").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    m_workSheet.get_Range("A16").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                    m_workSheet.get_Range("B16", "B17").Merge(System.Type.Missing);
                    m_workSheet.Cells[16, 2] = "dV1";
                    m_workSheet.get_Range("B16").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    m_workSheet.get_Range("B16").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                    m_workSheet.Cells[18, 2] = "м3";
                    m_workSheet.get_Range("B18").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    m_workSheet.get_Range("B18").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                    m_workSheet.get_Range("C16", "C17").Merge(System.Type.Missing);
                    m_workSheet.Cells[16, 3] = "dV2";
                    m_workSheet.get_Range("C16").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    m_workSheet.get_Range("C16").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                    m_workSheet.Cells[18, 3] = "м3";
                    m_workSheet.get_Range("C18").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    m_workSheet.get_Range("C18").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                    m_workSheet.Cells[16, 4] = "Наруш";
                    m_workSheet.get_Range("D16").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    m_workSheet.get_Range("D16").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                    m_workSheet.Cells[17, 4] = "О.П.";
                    m_workSheet.get_Range("D17").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    m_workSheet.get_Range("D17").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                    m_workSheet.Cells[18, 4] = "час";
                    m_workSheet.get_Range("D18").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    m_workSheet.get_Range("D18").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;


                    m_workSheet.get_Range("E1").ColumnWidth = 12;
                    m_workSheet.get_Range("F1").ColumnWidth = 12;
                    m_workSheet.get_Range("E16", "F17").Merge(System.Type.Missing);
                    m_workSheet.get_Range("E16").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                    m_workSheet.Cells[16, 5] = "Показания";
                    m_workSheet.get_Range("E16").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    m_workSheet.get_Range("E16").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                    m_workSheet.Cells[18, 5] = "Канал 1";
                    m_workSheet.get_Range("E18").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    m_workSheet.get_Range("E18").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                    m_workSheet.Cells[18, 6] = "Канал 2";
                    m_workSheet.get_Range("F18").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    m_workSheet.get_Range("F18").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                    m_workSheet.get_Range("A16", "F16").BorderAround();
                    m_workSheet.get_Range("A16", "F16").Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = Excel.XlLineStyle.xlContinuous;
                    m_workSheet.get_Range("A17", "F17").BorderAround();
                    m_workSheet.get_Range("A17", "F17").Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = Excel.XlLineStyle.xlContinuous;
                    m_workSheet.get_Range("A18", "F18").BorderAround();
                    m_workSheet.get_Range("A18", "F18").Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = Excel.XlLineStyle.xlContinuous;


                    DateTime date3_w = new DateTime(2014, 1, 1);

                    int k1 = 0;
                    decimal fl_sum = 0;
                    decimal fl1 = 0;
                    decimal fl2 = 0;

                    decimal fl_sum_2 = 0;
                    decimal fl1_2 = 0;
                    decimal fl2_2 = 0;


                    for (int k = 0; k <= (interval_w.Days - 1); k++)
                    {

                        if (date1_w.Day < 10)
                        {

                            if (date1_w.Month < 10)
                            {
                                m_workSheet.Cells[19 + k, 1] = "0" + date1_w.Day + "/" + "0" + date1_w.Month;
                            }
                            else
                                m_workSheet.Cells[19 + k, 1] = "0" + date1_w.Day + "/" + date1_w.Month;


                        }
                        else
                        {

                            if (date1_w.Month < 10)
                            {
                                m_workSheet.Cells[19 + k, 1] = date1_w.Day + "/" + "0" + date1_w.Month;
                            }
                            else
                                m_workSheet.Cells[19 + k, 1] = date1_w.Day + "/" + date1_w.Month;
                        }

                        date3_w = date1_w.AddDays(1);

                        string date1_str_w = date1_w.ToString();
                        string date3_str_w = date3_w.ToString();

                        string date1_sql_w;
                        string date3_sql_w;



                        date1_sql_w = date1_str_w.Substring(6, 4) + date1_str_w.Substring(3, 2) + date1_str_w.Substring(0, 2);
                        date3_sql_w = date3_str_w.Substring(6, 4) + date3_str_w.Substring(3, 2) + date3_str_w.Substring(0, 2);


                        result = MySqlLib.MySqlData.MySqlExecuteData.SqlReturnDataset("SELECT * FROM water2467 where water_date =" + date1_sql_w + " LIMIT 0,1", conn_str);
                        fl1 = Convert.ToDecimal(result.ResultData.DefaultView.Table.Rows[0]["water_ch1"].ToString());

                        result = MySqlLib.MySqlData.MySqlExecuteData.SqlReturnDataset("SELECT * FROM water2467 where water_date =" + date3_sql_w + " LIMIT 0,1", conn_str);
                        fl2 = Convert.ToDecimal(result.ResultData.DefaultView.Table.Rows[0]["water_ch1"].ToString());

                        fl_sum = fl_sum + (fl2 - fl1);

                        string result_okr = Convert.ToString(fl2 - fl1).Substring(0, Convert.ToString(fl2 - fl1).IndexOf(',') + 3);


                        result = MySqlLib.MySqlData.MySqlExecuteData.SqlReturnDataset("SELECT * FROM water2467 where water_date =" + date1_sql_w + " LIMIT 0,1", conn_str);
                        fl1_2 = Convert.ToDecimal(result.ResultData.DefaultView.Table.Rows[0]["water_ch2"].ToString());

                        result = MySqlLib.MySqlData.MySqlExecuteData.SqlReturnDataset("SELECT * FROM water2467 where water_date =" + date3_sql_w + " LIMIT 0,1", conn_str);
                        fl2_2 = Convert.ToDecimal(result.ResultData.DefaultView.Table.Rows[0]["water_ch2"].ToString());

                        fl_sum_2 = fl_sum_2 + (fl2_2 - fl1_2);



                        string result_okr2 = Convert.ToString(fl2_2 - fl1_2).Substring(0, Convert.ToString(fl2_2 - fl1_2).IndexOf(',') + 3);


                        m_workSheet.get_Range("B" + Convert.ToString(19 + k)).NumberFormat = "0.00";
                        m_workSheet.get_Range("C" + Convert.ToString(19 + k)).NumberFormat = "0.00";
                        m_workSheet.get_Range("E" + Convert.ToString(19 + k)).NumberFormat = "0.0000";
                        m_workSheet.get_Range("F" + Convert.ToString(19 + k)).NumberFormat = "0.0000";

                        m_workSheet.get_Range("A" + Convert.ToString(19 + k)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        m_workSheet.get_Range("B" + Convert.ToString(19 + k)).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;


                        m_workSheet.Cells[19 + k, 5] = Convert.ToDecimal(result.ResultData.DefaultView.Table.Rows[0]["water_ch1"].ToString());
                        m_workSheet.Cells[19 + k, 6] = Convert.ToDecimal(result.ResultData.DefaultView.Table.Rows[0]["water_ch2"].ToString());

                        m_workSheet.Cells[19 + k, 2] = Convert.ToDecimal(result_okr);
                        m_workSheet.Cells[19 + k, 3] = Convert.ToDecimal(result_okr2);


                        m_workSheet.get_Range("A" + Convert.ToString(19 + k), "F" + Convert.ToString(19 + k)).BorderAround();
                        m_workSheet.get_Range("A" + Convert.ToString(19 + k), "F" + Convert.ToString(19 + k)).Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = Excel.XlLineStyle.xlContinuous;

                        date1_w = date1_w.AddDays(1);
                        progressBar2.Value = k;
                        progressBar2.Update();

                        k1 = k;
                    }






                    m_workSheet.Cells[19 + k1 + 1, 1] = "Итого";
                    m_workSheet.get_Range("A" + Convert.ToString(19 + k1 + 1)).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                    m_workSheet.get_Range("A" + Convert.ToString(19 + k1 + 1)).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                    m_workSheet.Cells[19 + k1 + 1, 2] = fl_sum;
                    m_workSheet.get_Range("B" + Convert.ToString(19 + k1 + 1)).NumberFormat = "0.00";
                    m_workSheet.get_Range("B" + Convert.ToString(19 + k1 + 1)).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                    m_workSheet.get_Range("B" + Convert.ToString(19 + k1 + 1)).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                    m_workSheet.Cells[19 + k1 + 1, 3] = fl_sum_2;
                    m_workSheet.get_Range("C" + Convert.ToString(19 + k1 + 1)).NumberFormat = "0.00";
                    m_workSheet.get_Range("C" + Convert.ToString(19 + k1 + 1)).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                    m_workSheet.get_Range("C" + Convert.ToString(19 + k1 + 1)).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;



                    m_workSheet.Cells[19 + k1 + 2, 1] = "Средний";
                    m_workSheet.get_Range("A" + Convert.ToString(19 + k1 + 2)).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                    m_workSheet.get_Range("A" + Convert.ToString(19 + k1 + 2)).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                    m_workSheet.Cells[19 + k1 + 2, 2] = fl_sum / interval_w.Days;
                    m_workSheet.get_Range("B" + Convert.ToString(19 + k1 + 2)).NumberFormat = "0.00";
                    m_workSheet.get_Range("B" + Convert.ToString(19 + k1 + 2)).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                    m_workSheet.get_Range("B" + Convert.ToString(19 + k1 + 2)).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                    m_workSheet.Cells[19 + k1 + 2, 3] = fl_sum_2 / interval_w.Days;
                    m_workSheet.get_Range("C" + Convert.ToString(19 + k1 + 2)).NumberFormat = "0.00";
                    m_workSheet.get_Range("C" + Convert.ToString(19 + k1 + 2)).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                    m_workSheet.get_Range("C" + Convert.ToString(19 + k1 + 2)).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                    m_workSheet.get_Range("A" + Convert.ToString(19 + k1 + 1), "C" + Convert.ToString(19 + k1 + 1)).BorderAround();
                    m_workSheet.get_Range("A" + Convert.ToString(19 + k1 + 1), "C" + Convert.ToString(19 + k1 + 1)).Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = Excel.XlLineStyle.xlContinuous;
                    m_workSheet.get_Range("A" + Convert.ToString(19 + k1 + 2), "C" + Convert.ToString(19 + k1 + 2)).BorderAround();
                    m_workSheet.get_Range("A" + Convert.ToString(19 + k1 + 2), "C" + Convert.ToString(19 + k1 + 2)).Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = Excel.XlLineStyle.xlContinuous;



                    m_workSheet.get_Range("A" + Convert.ToString(19 + k1 + 4), "F" + Convert.ToString(19 + k1 + 4)).BorderAround();
                    m_workSheet.get_Range("A" + Convert.ToString(19 + k1 + 4), "F" + Convert.ToString(19 + k1 + 4)).Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = Excel.XlLineStyle.xlContinuous;
                    m_workSheet.get_Range("A" + Convert.ToString(19 + k1 + 5), "F" + Convert.ToString(19 + k1 + 5)).BorderAround();
                    m_workSheet.get_Range("A" + Convert.ToString(19 + k1 + 5), "F" + Convert.ToString(19 + k1 + 5)).Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = Excel.XlLineStyle.xlContinuous;
                    m_workSheet.get_Range("A" + Convert.ToString(19 + k1 + 6), "F" + Convert.ToString(19 + k1 + 6)).BorderAround();
                    m_workSheet.get_Range("A" + Convert.ToString(19 + k1 + 6), "F" + Convert.ToString(19 + k1 + 6)).Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = Excel.XlLineStyle.xlContinuous;
                    m_workSheet.get_Range("A" + Convert.ToString(19 + k1 + 7), "F" + Convert.ToString(19 + k1 + 7)).BorderAround();
                    m_workSheet.get_Range("A" + Convert.ToString(19 + k1 + 7), "F" + Convert.ToString(19 + k1 + 7)).Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = Excel.XlLineStyle.xlContinuous;

                    m_workSheet.get_Range("A" + Convert.ToString(19 + k1 + 4), "A" + Convert.ToString(19 + k1 + 5)).Merge(System.Type.Missing);
                    m_workSheet.Cells[19 + k1 + 4, 1] = "Дата";
                    m_workSheet.get_Range("A" + Convert.ToString(19 + k1 + 4)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    m_workSheet.get_Range("A" + Convert.ToString(19 + k1 + 4)).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;


                    if (date1_w_otch.Day < 10)
                    {

                        if (date1_w_otch.Month < 10)
                        {
                            m_workSheet.Cells[19 + k1 + 6, 1] = "0" + date1_w_otch.Day + "/" + "0" + date1_w_otch.Month + "/" + date1_w_otch.Year;
                        }
                        else
                            m_workSheet.Cells[19 + k1 + 6, 1] = "0" + date1_w_otch.Day + "/" + date1_w_otch.Month + "/" + date1_w_otch.Year;


                    }
                    else
                    {

                        if (date1_w_otch.Month < 10)
                        {
                            m_workSheet.Cells[19 + k1 + 6, 1] = date1_w_otch.Day + "/" + "0" + date1_w_otch.Month + "/" + date1_w_otch.Year;
                        }
                        else
                            m_workSheet.Cells[19 + k1 + 6, 1] = date1_w_otch.Day + "/" + date1_w_otch.Month + "/" + date1_w_otch.Year;
                    }

                    if (date2_w_otch.Day < 10)
                    {

                        if (date2_w_otch.Month < 10)
                        {
                            m_workSheet.Cells[19 + k1 + 7, 1] = "0" + date2_w_otch.Day + "/" + "0" + date2_w_otch.Month + "/" + date2_w_otch.Year;
                        }
                        else
                            m_workSheet.Cells[19 + k1 + 7, 1] = "0" + date2_w_otch.Day + "/" + date2_w_otch.Month + "/" + date2_w_otch.Year;


                    }
                    else
                    {

                        if (date2_w_otch.Month < 10)
                        {
                            m_workSheet.Cells[19 + k1 + 7, 1] = date2_w_otch.Day + "/" + "0" + date2_w_otch.Month + "/" + date2_w_otch.Year;
                        }
                        else
                            m_workSheet.Cells[19 + k1 + 7, 1] = date2_w_otch.Day + "/" + date2_w_otch.Month + "/" + date2_w_otch.Year;
                    }



                    m_workSheet.get_Range("A" + Convert.ToString(19 + k1 + 6)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    m_workSheet.get_Range("A" + Convert.ToString(19 + k1 + 6)).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;


                    m_workSheet.get_Range("B" + Convert.ToString(19 + k1 + 4), "B" + Convert.ToString(19 + k1 + 5)).Merge(System.Type.Missing);
                    m_workSheet.Cells[19 + k1 + 4, 2] = "Время";
                    m_workSheet.get_Range("B" + Convert.ToString(19 + k1 + 4)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    m_workSheet.get_Range("B" + Convert.ToString(19 + k1 + 4)).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                    m_workSheet.Cells[19 + k1 + 6, 2] = "00:00";
                    m_workSheet.get_Range("B" + Convert.ToString(19 + k1 + 6)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    m_workSheet.get_Range("B" + Convert.ToString(19 + k1 + 6)).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                    m_workSheet.Cells[19 + k1 + 7, 2] = "00:00";
                    m_workSheet.get_Range("B" + Convert.ToString(19 + k1 + 7)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    m_workSheet.get_Range("B" + Convert.ToString(19 + k1 + 7)).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;


                    m_workSheet.get_Range("C" + Convert.ToString(19 + k1 + 4), "D" + Convert.ToString(19 + k1 + 4)).Merge(System.Type.Missing);
                    m_workSheet.Cells[19 + k1 + 4, 3] = "V1";
                    m_workSheet.get_Range("C" + Convert.ToString(19 + k1 + 4)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    m_workSheet.get_Range("C" + Convert.ToString(19 + k1 + 4)).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                    m_workSheet.get_Range("C" + Convert.ToString(19 + k1 + 5), "D" + Convert.ToString(19 + k1 + 5)).Merge(System.Type.Missing);
                    m_workSheet.Cells[19 + k1 + 5, 3] = "м3";
                    m_workSheet.get_Range("C" + Convert.ToString(19 + k1 + 5)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    m_workSheet.get_Range("C" + Convert.ToString(19 + k1 + 5)).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                    m_workSheet.get_Range("E" + Convert.ToString(19 + k1 + 4), "F" + Convert.ToString(19 + k1 + 4)).Merge(System.Type.Missing);
                    m_workSheet.Cells[19 + k1 + 4, 5] = "V2";
                    m_workSheet.get_Range("E" + Convert.ToString(19 + k1 + 4)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    m_workSheet.get_Range("E" + Convert.ToString(19 + k1 + 4)).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                    m_workSheet.get_Range("E" + Convert.ToString(19 + k1 + 5), "F" + Convert.ToString(19 + k1 + 5)).Merge(System.Type.Missing);
                    m_workSheet.Cells[19 + k1 + 5, 5] = "м3";
                    m_workSheet.get_Range("E" + Convert.ToString(19 + k1 + 5)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    m_workSheet.get_Range("E" + Convert.ToString(19 + k1 + 5)).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;



                    m_workSheet.get_Range("C" + Convert.ToString(19 + k1 + 6)).NumberFormat = "0.0000";
                    m_workSheet.get_Range("E" + Convert.ToString(19 + k1 + 6)).NumberFormat = "0.0000";

                    m_workSheet.get_Range("C" + Convert.ToString(19 + k1 + 7)).NumberFormat = "0.0000";
                    m_workSheet.get_Range("E" + Convert.ToString(19 + k1 + 7)).NumberFormat = "0.0000";


                    m_workSheet.get_Range("C" + Convert.ToString(19 + k1 + 6), "D" + Convert.ToString(19 + k1 + 6)).Merge(System.Type.Missing);
                    m_workSheet.Cells[19 + k1 + 6, 3] = fl2 - fl_sum;
                    m_workSheet.get_Range("C" + Convert.ToString(19 + k1 + 6)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    m_workSheet.get_Range("C" + Convert.ToString(19 + k1 + 6)).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                    m_workSheet.get_Range("E" + Convert.ToString(19 + k1 + 6), "F" + Convert.ToString(19 + k1 + 6)).Merge(System.Type.Missing);
                    m_workSheet.Cells[19 + k1 + 6, 5] = fl2_2 - fl_sum_2;
                    m_workSheet.get_Range("E" + Convert.ToString(19 + k1 + 6)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    m_workSheet.get_Range("E" + Convert.ToString(19 + k1 + 6)).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                    m_workSheet.get_Range("C" + Convert.ToString(19 + k1 + 7), "D" + Convert.ToString(19 + k1 + 7)).Merge(System.Type.Missing);
                    m_workSheet.Cells[19 + k1 + 7, 3] = fl2;
                    m_workSheet.get_Range("C" + Convert.ToString(19 + k1 + 7)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    m_workSheet.get_Range("C" + Convert.ToString(19 + k1 + 7)).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                    m_workSheet.get_Range("E" + Convert.ToString(19 + k1 + 7), "F" + Convert.ToString(19 + k1 + 7)).Merge(System.Type.Missing);
                    m_workSheet.Cells[19 + k1 + 7, 5] = fl2_2;
                    m_workSheet.get_Range("E" + Convert.ToString(19 + k1 + 7)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    m_workSheet.get_Range("E" + Convert.ToString(19 + k1 + 7)).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                    m_workSheet.get_Range("A" + Convert.ToString(19 + k1 + 9), "F" + Convert.ToString(19 + k1 + 9)).Merge(System.Type.Missing);
                    m_workSheet.Cells[19 + k1 + 9, 1] = "Время наработки: " + Convert.ToString(24 * interval_w.TotalDays) + ".00 часов";

                    m_workSheet.get_Range("A" + Convert.ToString(19 + k1 + 11), "C" + Convert.ToString(19 + k1 + 11)).Merge(System.Type.Missing);
                    m_workSheet.Cells[19 + k1 + 11, 1] = "Представитель потребителя";

                    m_workSheet.get_Range("D" + Convert.ToString(19 + k1 + 11), "F" + Convert.ToString(19 + k1 + 11)).Merge(System.Type.Missing);
                    m_workSheet.Cells[19 + k1 + 11, 4] = "Представитель заказчика";

                    m_workBook.SaveCopyAs(filename);

                }

                finally
                {
                    // Закрытие книги.
                    //m_workBook.Close(false, "", Type.Missing);
                    // Закрытие приложения Excel.
                    //m_app.Quit();

                    m_workBook = null;
                    m_workSheet = null;
                    m_app = null;
                    GC.Collect();
                }
            }

            if (checkBox6.Checked)
            {
                Excel.Workbook m_workBook = null;
                Excel.Worksheet m_workSheet = null;

                Excel._Application m_app = null;
                string filename = "D:\\Отчет за " +
                    DateTime.Now.Day + "." +
                    DateTime.Now.Month + "." +
                    DateTime.Now.Year + "(Насосная).xls";// по умолчанию сохраняет в корень диска С:


                button2.Enabled = false;


                string conn_str = "Database=resources;Data Source=10.1.1.50;User Id=sa;Password=Rfnfgekmrf48";

                MySqlLib.MySqlData.MySqlExecuteData.MyResultData result = new MySqlLib.MySqlData.MySqlExecuteData.MyResultData();

                DateTime date1_w = new DateTime(2014, 1, 1);
                DateTime date2_w = new DateTime(2014, 1, 1);
                DateTime date22_w = new DateTime(2014, 1, 1);
                DateTime date1_w_otch = new DateTime(2014, 1, 1);
                DateTime date2_w_otch = new DateTime(2014, 1, 1);


                if (radioButton4.Checked)
                {
                    DateTime date1_1 = DateTime.Now.AddMonths(-1);
                    date1_w = new DateTime(date1_1.Year, date1_1.Month, 1, 11, 0, 0);

                    date1_1 = DateTime.Now;
                    date2_w = new DateTime(date1_1.Year, date1_1.Month, 1, 11, 0, 0);
                }



                if (radioButton5.Checked)
                {
                    if (comboBox2.Text == "Январь")
                    {
                        date1_w = new DateTime(Convert.ToInt32(textBox2.Text), 1, 1);
                        date2_w = date1_w.AddMonths(1);
                    }
                    if (comboBox2.Text == "Февраль")
                    {
                        date1_w = new DateTime(Convert.ToInt32(textBox2.Text), 2, 1);
                        date2_w = date1_w.AddMonths(1);
                    }
                    if (comboBox2.Text == "Март")
                    {
                        date1_w = new DateTime(Convert.ToInt32(textBox2.Text), 3, 1);
                        date2_w = date1_w.AddMonths(1);
                    }
                    if (comboBox2.Text == "Апрель")
                    {
                        date1_w = new DateTime(Convert.ToInt32(textBox2.Text), 4, 1);
                        date2_w = date1_w.AddMonths(1);
                    }
                    if (comboBox2.Text == "Май")
                    {
                        date1_w = new DateTime(Convert.ToInt32(textBox2.Text), 5, 1);
                        date2_w = date1_w.AddMonths(1);
                    }
                    if (comboBox2.Text == "Июнь")
                    {
                        date1_w = new DateTime(Convert.ToInt32(textBox2.Text), 6, 1);
                        date2_w = date1_w.AddMonths(1);
                    }
                    if (comboBox2.Text == "Июль")
                    {
                        date1_w = new DateTime(Convert.ToInt32(textBox2.Text), 7, 1);
                        date2_w = date1_w.AddMonths(1);
                    }
                    if (comboBox2.Text == "Август")
                    {
                        date1_w = new DateTime(Convert.ToInt32(textBox2.Text), 8, 1);
                        date2_w = date1_w.AddMonths(1);
                    }
                    if (comboBox2.Text == "Сентябрь")
                    {
                        date1_w = new DateTime(Convert.ToInt32(textBox2.Text), 9, 1);
                        date2_w = date1_w.AddMonths(1);
                    }
                    if (comboBox2.Text == "Октябрь")
                    {
                        date1_w = new DateTime(Convert.ToInt32(textBox2.Text), 10, 1);
                        date2_w = date1_w.AddMonths(1);
                    }
                    if (comboBox2.Text == "Ноябрь")
                    {
                        date1_w = new DateTime(Convert.ToInt32(textBox2.Text), 11, 1);
                        date2_w = date1_w.AddMonths(1);
                    }
                    if (comboBox2.Text == "Декабрь")
                    {
                        date1_w = new DateTime(Convert.ToInt32(textBox2.Text), 12, 1);
                        date2_w = date1_w.AddMonths(1);
                    }

                }

                if (radioButton6.Checked)
                {
                    date1_w = new DateTime(dateTimePicker3.Value.Year, dateTimePicker3.Value.Month, dateTimePicker3.Value.Day);
                    date2_w = new DateTime(dateTimePicker4.Value.Year, dateTimePicker4.Value.Month, dateTimePicker4.Value.Day + 1);
                }

                date22_w = date2_w.AddDays(-1);
                date1_w_otch = date1_w;
                date2_w_otch = date2_w;

                TimeSpan interval_w = date2_w - date1_w;

                int days_w = Convert.ToInt32(Math.Floor(interval_w.TotalDays));
                progressBar2.Maximum = Convert.ToInt32(days_w - 1);



                try
                {

                    // Создание приложения Excel.
                    m_app = new Microsoft.Office.Interop.Excel.Application();
                    m_app.ReferenceStyle = Excel.XlReferenceStyle.xlA1;
                    // Приложение "невидимо".
                    m_app.Visible = true;
                    // Приложение управляется пользователем.
                    m_app.UserControl = true;
                    // Добавление книги Excel.
                    m_workBook = m_app.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);


                    // Связь со страницей Excel.

                    m_app.StandardFont = "Courier new cyr";
                    m_app.StandardFontSize = 10;

                    m_workSheet = m_app.ActiveSheet as Excel.Worksheet;

                    m_workSheet.Columns.ColumnWidth = 8.5;

                    m_workSheet.Cells.NumberFormat = "@";

                    m_workSheet.get_Range("A1").ColumnWidth = 10;

                    m_workSheet.get_Range("A1", "K1").Merge(System.Type.Missing);
                    m_workSheet.get_Range("A1").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    m_workSheet.get_Range("A1").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    m_workSheet.Cells[1, 1] = "Отчет";

                    m_workSheet.get_Range("A2", "K2").Merge(System.Type.Missing);
                    m_workSheet.Cells[2, 1] = "о суточных параметрах расхода";
                    m_workSheet.get_Range("A2").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    m_workSheet.get_Range("A2").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                    m_workSheet.get_Range("A3", "K3").Merge(System.Type.Missing);




                    m_workSheet.Cells[3, 1] = "за " + String.Format("{0:dd/MM/yyyy}", date1_w) + "г. - " + String.Format("{0:dd/MM/yyyy}", date22_w) + "г.";


                    m_workSheet.get_Range("A3").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    m_workSheet.get_Range("A3").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                    m_workSheet.get_Range("A5", "K5").Merge(System.Type.Missing);
                    m_workSheet.Cells[5, 1] = "Абонент: 000000000000                             Договор N: ______________";
                    m_workSheet.get_Range("A5").HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    m_workSheet.get_Range("A5").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                    m_workSheet.get_Range("A7", "K7").Merge(System.Type.Missing);
                    m_workSheet.Cells[7, 1] = "Адрес: ________________________                   Тип расходомера: ________ ";
                    m_workSheet.get_Range("A7").HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    m_workSheet.get_Range("A7").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                    m_workSheet.get_Range("A9", "K9").Merge(System.Type.Missing);
                    m_workSheet.Cells[9, 1] = "Расходомер Днепр-7 N 4 (Насосная)";
                    m_workSheet.get_Range("A9").HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    m_workSheet.get_Range("A9").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                    m_workSheet.get_Range("A11", "K11").Merge(System.Type.Missing);
                    m_workSheet.Cells[11, 1] = "Договорные расходы:                        Пределы измерений:";
                    m_workSheet.get_Range("A11").HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    m_workSheet.get_Range("A11").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                    m_workSheet.get_Range("A12", "K12").Merge(System.Type.Missing);
                    m_workSheet.Cells[12, 1] = "M под= _____ т.сут  М обр= _____ т.сут     G под max= _____  G под min= _____";
                    m_workSheet.get_Range("A12").HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    m_workSheet.get_Range("A12").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                    m_workSheet.get_Range("A16", "A18").Merge(System.Type.Missing);
                    m_workSheet.Cells[16, 1] = "ДАТА";
                    m_workSheet.get_Range("A16").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    m_workSheet.get_Range("A16").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                    m_workSheet.get_Range("B16", "B17").Merge(System.Type.Missing);
                    m_workSheet.Cells[16, 2] = "dV1";
                    m_workSheet.get_Range("B16").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    m_workSheet.get_Range("B16").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                    m_workSheet.Cells[18, 2] = "м3";
                    m_workSheet.get_Range("B18").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    m_workSheet.get_Range("B18").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                    m_workSheet.get_Range("C16", "C17").Merge(System.Type.Missing);
                    m_workSheet.Cells[16, 3] = "dV2";
                    m_workSheet.get_Range("C16").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    m_workSheet.get_Range("C16").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                    m_workSheet.Cells[18, 3] = "м3";
                    m_workSheet.get_Range("C18").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    m_workSheet.get_Range("C18").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                    m_workSheet.Cells[16, 4] = "Наруш";
                    m_workSheet.get_Range("D16").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    m_workSheet.get_Range("D16").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                    m_workSheet.Cells[17, 4] = "О.П.";
                    m_workSheet.get_Range("D17").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    m_workSheet.get_Range("D17").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                    m_workSheet.Cells[18, 4] = "час";
                    m_workSheet.get_Range("D18").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    m_workSheet.get_Range("D18").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;


                    m_workSheet.get_Range("E1").ColumnWidth = 12;
                    m_workSheet.get_Range("F1").ColumnWidth = 12;
                    m_workSheet.get_Range("E16", "F17").Merge(System.Type.Missing);
                    m_workSheet.get_Range("E16").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                    m_workSheet.Cells[16, 5] = "Показания";
                    m_workSheet.get_Range("E16").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    m_workSheet.get_Range("E16").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                    m_workSheet.Cells[18, 5] = "Канал 1";
                    m_workSheet.get_Range("E18").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    m_workSheet.get_Range("E18").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                    m_workSheet.Cells[18, 6] = "Канал 2";
                    m_workSheet.get_Range("F19").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    m_workSheet.get_Range("F19").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                    m_workSheet.get_Range("A16", "F16").BorderAround();
                    m_workSheet.get_Range("A16", "F16").Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = Excel.XlLineStyle.xlContinuous;
                    m_workSheet.get_Range("A17", "F17").BorderAround();
                    m_workSheet.get_Range("A17", "F17").Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = Excel.XlLineStyle.xlContinuous;
                    m_workSheet.get_Range("A18", "F18").BorderAround();
                    m_workSheet.get_Range("A18", "F18").Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = Excel.XlLineStyle.xlContinuous;


                    DateTime date3_w = new DateTime(2014, 1, 1);

                    int k1 = 0;
                    decimal fl_sum = 0;
                    decimal fl1 = 0;
                    decimal fl2 = 0;

                    decimal fl_sum_2 = 0;
                    decimal fl1_2 = 0;
                    decimal fl2_2 = 0;


                    for (int k = 0; k <= (interval_w.Days - 1); k++)
                    {

                        if (date1_w.Day < 10)
                        {

                            if (date1_w.Month < 10)
                            {
                                m_workSheet.Cells[19 + k, 1] = "0" + date1_w.Day + "/" + "0" + date1_w.Month;
                            }
                            else
                                m_workSheet.Cells[19 + k, 1] = "0" + date1_w.Day + "/" + date1_w.Month;


                        }
                        else
                        {

                            if (date1_w.Month < 10)
                            {
                                m_workSheet.Cells[19 + k, 1] = date1_w.Day + "/" + "0" + date1_w.Month;
                            }
                            else
                                m_workSheet.Cells[19 + k, 1] = date1_w.Day + "/" + date1_w.Month;
                        }

                        date3_w = date1_w.AddDays(1);

                        string date1_str_w = date1_w.ToString();
                        string date3_str_w = date3_w.ToString();

                        string date1_sql_w;
                        string date3_sql_w;



                        date1_sql_w = date1_str_w.Substring(6, 4) + date1_str_w.Substring(3, 2) + date1_str_w.Substring(0, 2);
                        date3_sql_w = date3_str_w.Substring(6, 4) + date3_str_w.Substring(3, 2) + date3_str_w.Substring(0, 2);


                        result = MySqlLib.MySqlData.MySqlExecuteData.SqlReturnDataset("SELECT * FROM water2466 where water_date =" + date1_sql_w + " LIMIT 0,1", conn_str);
                        fl1 = Convert.ToDecimal(result.ResultData.DefaultView.Table.Rows[0]["water_ch1"].ToString());

                        result = MySqlLib.MySqlData.MySqlExecuteData.SqlReturnDataset("SELECT * FROM water2466 where water_date =" + date3_sql_w + " LIMIT 0,1", conn_str);
                        fl2 = Convert.ToDecimal(result.ResultData.DefaultView.Table.Rows[0]["water_ch1"].ToString());

                        fl_sum = fl_sum + (fl2 - fl1);



                        string result_okr = Convert.ToString(fl2 - fl1).Substring(0, Convert.ToString(fl2 - fl1).IndexOf(',') + 3);



                        result = MySqlLib.MySqlData.MySqlExecuteData.SqlReturnDataset("SELECT * FROM water2466 where water_date =" + date1_sql_w + " LIMIT 0,1", conn_str);
                        fl1_2 = Convert.ToDecimal(result.ResultData.DefaultView.Table.Rows[0]["water_ch2"].ToString());

                        result = MySqlLib.MySqlData.MySqlExecuteData.SqlReturnDataset("SELECT * FROM water2466 where water_date =" + date3_sql_w + " LIMIT 0,1", conn_str);
                        fl2_2 = Convert.ToDecimal(result.ResultData.DefaultView.Table.Rows[0]["water_ch2"].ToString());

                        fl_sum_2 = fl_sum_2 + (fl2_2 - fl1_2);



                        string result_okr2 = Convert.ToString(fl2_2 - fl1_2).Substring(0, Convert.ToString(fl2_2 - fl1_2).IndexOf(',') + 3);

                        m_workSheet.get_Range("B" + Convert.ToString(19 + k)).NumberFormat = "0.00";
                        m_workSheet.get_Range("C" + Convert.ToString(19 + k)).NumberFormat = "0.00";
                        m_workSheet.get_Range("E" + Convert.ToString(19 + k)).NumberFormat = "0.0000";
                        m_workSheet.get_Range("F" + Convert.ToString(19 + k)).NumberFormat = "0.0000";

                        m_workSheet.get_Range("A" + Convert.ToString(19 + k)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        m_workSheet.get_Range("B" + Convert.ToString(19 + k)).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;


                        m_workSheet.Cells[19 + k, 5] = Convert.ToDecimal(result.ResultData.DefaultView.Table.Rows[0]["water_ch1"].ToString());
                        m_workSheet.Cells[19 + k, 6] = Convert.ToDecimal(result.ResultData.DefaultView.Table.Rows[0]["water_ch2"].ToString());

                        m_workSheet.Cells[19 + k, 2] = Convert.ToDecimal(result_okr);
                        m_workSheet.Cells[19 + k, 3] = Convert.ToDecimal(result_okr2);


                        m_workSheet.get_Range("A" + Convert.ToString(19 + k), "F" + Convert.ToString(19 + k)).BorderAround();
                        m_workSheet.get_Range("A" + Convert.ToString(19 + k), "F" + Convert.ToString(19 + k)).Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = Excel.XlLineStyle.xlContinuous;

                        date1_w = date1_w.AddDays(1);
                        progressBar2.Value = k;
                        progressBar2.Update();

                        k1 = k;
                    }






                    m_workSheet.Cells[19 + k1 + 1, 1] = "Итого";
                    m_workSheet.get_Range("A" + Convert.ToString(19 + k1 + 1)).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                    m_workSheet.get_Range("A" + Convert.ToString(19 + k1 + 1)).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                    m_workSheet.Cells[19 + k1 + 1, 2] = fl_sum;
                    m_workSheet.get_Range("B" + Convert.ToString(19 + k1 + 1)).NumberFormat = "0.00";
                    m_workSheet.get_Range("B" + Convert.ToString(19 + k1 + 1)).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                    m_workSheet.get_Range("B" + Convert.ToString(19 + k1 + 1)).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                    m_workSheet.Cells[19 + k1 + 1, 3] = fl_sum_2;
                    m_workSheet.get_Range("C" + Convert.ToString(19 + k1 + 1)).NumberFormat = "0.00";
                    m_workSheet.get_Range("C" + Convert.ToString(19 + k1 + 1)).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                    m_workSheet.get_Range("C" + Convert.ToString(19 + k1 + 1)).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;



                    m_workSheet.Cells[19 + k1 + 2, 1] = "Средний";
                    m_workSheet.get_Range("A" + Convert.ToString(19 + k1 + 2)).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                    m_workSheet.get_Range("A" + Convert.ToString(19 + k1 + 2)).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                    m_workSheet.Cells[19 + k1 + 2, 2] = fl_sum / interval_w.Days;
                    m_workSheet.get_Range("B" + Convert.ToString(19 + k1 + 2)).NumberFormat = "0.00";
                    m_workSheet.get_Range("B" + Convert.ToString(19 + k1 + 2)).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                    m_workSheet.get_Range("B" + Convert.ToString(19 + k1 + 2)).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                    m_workSheet.Cells[19 + k1 + 2, 3] = fl_sum_2 / interval_w.Days;
                    m_workSheet.get_Range("C" + Convert.ToString(19 + k1 + 2)).NumberFormat = "0.00";
                    m_workSheet.get_Range("C" + Convert.ToString(19 + k1 + 2)).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                    m_workSheet.get_Range("C" + Convert.ToString(19 + k1 + 2)).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                    m_workSheet.get_Range("A" + Convert.ToString(19 + k1 + 1), "C" + Convert.ToString(19 + k1 + 1)).BorderAround();
                    m_workSheet.get_Range("A" + Convert.ToString(19 + k1 + 1), "C" + Convert.ToString(19 + k1 + 1)).Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = Excel.XlLineStyle.xlContinuous;
                    m_workSheet.get_Range("A" + Convert.ToString(19 + k1 + 2), "C" + Convert.ToString(19 + k1 + 2)).BorderAround();
                    m_workSheet.get_Range("A" + Convert.ToString(19 + k1 + 2), "C" + Convert.ToString(19 + k1 + 2)).Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = Excel.XlLineStyle.xlContinuous;



                    m_workSheet.get_Range("A" + Convert.ToString(19 + k1 + 4), "F" + Convert.ToString(19 + k1 + 4)).BorderAround();
                    m_workSheet.get_Range("A" + Convert.ToString(19 + k1 + 4), "F" + Convert.ToString(19 + k1 + 4)).Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = Excel.XlLineStyle.xlContinuous;
                    m_workSheet.get_Range("A" + Convert.ToString(19 + k1 + 5), "F" + Convert.ToString(19 + k1 + 5)).BorderAround();
                    m_workSheet.get_Range("A" + Convert.ToString(19 + k1 + 5), "F" + Convert.ToString(19 + k1 + 5)).Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = Excel.XlLineStyle.xlContinuous;
                    m_workSheet.get_Range("A" + Convert.ToString(19 + k1 + 6), "F" + Convert.ToString(19 + k1 + 6)).BorderAround();
                    m_workSheet.get_Range("A" + Convert.ToString(19 + k1 + 6), "F" + Convert.ToString(19 + k1 + 6)).Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = Excel.XlLineStyle.xlContinuous;
                    m_workSheet.get_Range("A" + Convert.ToString(19 + k1 + 7), "F" + Convert.ToString(19 + k1 + 7)).BorderAround();
                    m_workSheet.get_Range("A" + Convert.ToString(19 + k1 + 7), "F" + Convert.ToString(19 + k1 + 7)).Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = Excel.XlLineStyle.xlContinuous;

                    m_workSheet.get_Range("A" + Convert.ToString(19 + k1 + 4), "A" + Convert.ToString(19 + k1 + 5)).Merge(System.Type.Missing);
                    m_workSheet.Cells[19 + k1 + 4, 1] = "Дата";
                    m_workSheet.get_Range("A" + Convert.ToString(19 + k1 + 4)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    m_workSheet.get_Range("A" + Convert.ToString(19 + k1 + 4)).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;


                    if (date1_w_otch.Day < 10)
                    {

                        if (date1_w_otch.Month < 10)
                        {
                            m_workSheet.Cells[19 + k1 + 6, 1] = "0" + date1_w_otch.Day + "/" + "0" + date1_w_otch.Month + "/" + date1_w_otch.Year;
                        }
                        else
                            m_workSheet.Cells[19 + k1 + 6, 1] = "0" + date1_w_otch.Day + "/" + date1_w_otch.Month + "/" + date1_w_otch.Year;


                    }
                    else
                    {

                        if (date1_w_otch.Month < 10)
                        {
                            m_workSheet.Cells[19 + k1 + 6, 1] = date1_w_otch.Day + "/" + "0" + date1_w_otch.Month + "/" + date1_w_otch.Year;
                        }
                        else
                            m_workSheet.Cells[19 + k1 + 6, 1] = date1_w_otch.Day + "/" + date1_w_otch.Month + "/" + date1_w_otch.Year;
                    }

                    if (date2_w_otch.Day < 10)
                    {

                        if (date2_w_otch.Month < 10)
                        {
                            m_workSheet.Cells[19 + k1 + 7, 1] = "0" + date2_w_otch.Day + "/" + "0" + date2_w_otch.Month + "/" + date2_w_otch.Year;
                        }
                        else
                            m_workSheet.Cells[19 + k1 + 7, 1] = "0" + date2_w_otch.Day + "/" + date2_w_otch.Month + "/" + date2_w_otch.Year;


                    }
                    else
                    {

                        if (date2_w_otch.Month < 10)
                        {
                            m_workSheet.Cells[19 + k1 + 7, 1] = date2_w_otch.Day + "/" + "0" + date2_w_otch.Month + "/" + date2_w_otch.Year;
                        }
                        else
                            m_workSheet.Cells[19 + k1 + 7, 1] = date2_w_otch.Day + "/" + date2_w_otch.Month + "/" + date2_w_otch.Year;
                    }



                    m_workSheet.get_Range("A" + Convert.ToString(19 + k1 + 6)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    m_workSheet.get_Range("A" + Convert.ToString(19 + k1 + 6)).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;


                    m_workSheet.get_Range("B" + Convert.ToString(19 + k1 + 4), "B" + Convert.ToString(19 + k1 + 5)).Merge(System.Type.Missing);
                    m_workSheet.Cells[19 + k1 + 4, 2] = "Время";
                    m_workSheet.get_Range("B" + Convert.ToString(19 + k1 + 4)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    m_workSheet.get_Range("B" + Convert.ToString(19 + k1 + 4)).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                    m_workSheet.Cells[19 + k1 + 6, 2] = "00:00";
                    m_workSheet.get_Range("B" + Convert.ToString(19 + k1 + 6)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    m_workSheet.get_Range("B" + Convert.ToString(19 + k1 + 6)).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                    m_workSheet.Cells[19 + k1 + 7, 2] = "00:00";
                    m_workSheet.get_Range("B" + Convert.ToString(19 + k1 + 7)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    m_workSheet.get_Range("B" + Convert.ToString(19 + k1 + 7)).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;


                    m_workSheet.get_Range("C" + Convert.ToString(19 + k1 + 4), "D" + Convert.ToString(19 + k1 + 4)).Merge(System.Type.Missing);
                    m_workSheet.Cells[19 + k1 + 4, 3] = "V1";
                    m_workSheet.get_Range("C" + Convert.ToString(19 + k1 + 4)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    m_workSheet.get_Range("C" + Convert.ToString(19 + k1 + 4)).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                    m_workSheet.get_Range("C" + Convert.ToString(19 + k1 + 5), "D" + Convert.ToString(19 + k1 + 5)).Merge(System.Type.Missing);
                    m_workSheet.Cells[19 + k1 + 5, 3] = "м3";
                    m_workSheet.get_Range("C" + Convert.ToString(19 + k1 + 5)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    m_workSheet.get_Range("C" + Convert.ToString(19 + k1 + 5)).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                    m_workSheet.get_Range("E" + Convert.ToString(19 + k1 + 4), "F" + Convert.ToString(19 + k1 + 4)).Merge(System.Type.Missing);
                    m_workSheet.Cells[19 + k1 + 4, 5] = "V2";
                    m_workSheet.get_Range("E" + Convert.ToString(19 + k1 + 4)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    m_workSheet.get_Range("E" + Convert.ToString(19 + k1 + 4)).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                    m_workSheet.get_Range("E" + Convert.ToString(19 + k1 + 5), "F" + Convert.ToString(19 + k1 + 5)).Merge(System.Type.Missing);
                    m_workSheet.Cells[19 + k1 + 5, 5] = "м3";
                    m_workSheet.get_Range("E" + Convert.ToString(19 + k1 + 5)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    m_workSheet.get_Range("E" + Convert.ToString(19 + k1 + 5)).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;



                    m_workSheet.get_Range("C" + Convert.ToString(19 + k1 + 6)).NumberFormat = "0.0000";
                    m_workSheet.get_Range("E" + Convert.ToString(19 + k1 + 6)).NumberFormat = "0.0000";

                    m_workSheet.get_Range("C" + Convert.ToString(19 + k1 + 7)).NumberFormat = "0.0000";
                    m_workSheet.get_Range("E" + Convert.ToString(19 + k1 + 7)).NumberFormat = "0.0000";


                    m_workSheet.get_Range("C" + Convert.ToString(19 + k1 + 6), "D" + Convert.ToString(19 + k1 + 6)).Merge(System.Type.Missing);
                    m_workSheet.Cells[19 + k1 + 6, 3] = fl2 - fl_sum;
                    m_workSheet.get_Range("C" + Convert.ToString(19 + k1 + 6)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    m_workSheet.get_Range("C" + Convert.ToString(19 + k1 + 6)).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                    m_workSheet.get_Range("E" + Convert.ToString(19 + k1 + 6), "F" + Convert.ToString(19 + k1 + 6)).Merge(System.Type.Missing);
                    m_workSheet.Cells[19 + k1 + 6, 5] = fl2_2 - fl_sum_2; ;
                    m_workSheet.get_Range("E" + Convert.ToString(19 + k1 + 6)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    m_workSheet.get_Range("E" + Convert.ToString(19 + k1 + 6)).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                    m_workSheet.get_Range("C" + Convert.ToString(19 + k1 + 7), "D" + Convert.ToString(19 + k1 + 7)).Merge(System.Type.Missing);
                    m_workSheet.Cells[19 + k1 + 7, 3] = fl2;
                    m_workSheet.get_Range("C" + Convert.ToString(19 + k1 + 7)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    m_workSheet.get_Range("C" + Convert.ToString(19 + k1 + 7)).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                    m_workSheet.get_Range("E" + Convert.ToString(19 + k1 + 7), "F" + Convert.ToString(19 + k1 + 7)).Merge(System.Type.Missing);
                    m_workSheet.Cells[19 + k1 + 7, 5] = fl2_2;
                    m_workSheet.get_Range("E" + Convert.ToString(19 + k1 + 7)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    m_workSheet.get_Range("E" + Convert.ToString(19 + k1 + 7)).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                    m_workSheet.get_Range("A" + Convert.ToString(19 + k1 + 9), "F" + Convert.ToString(19 + k1 + 9)).Merge(System.Type.Missing);
                    m_workSheet.Cells[19 + k1 + 9, 1] = "Время наработки: " + Convert.ToString(24 * interval_w.TotalDays) + ".00 часов";

                    m_workSheet.get_Range("A" + Convert.ToString(19 + k1 + 11), "C" + Convert.ToString(19 + k1 + 11)).Merge(System.Type.Missing);
                    m_workSheet.Cells[19 + k1 + 11, 1] = "Представитель потребителя";

                    m_workSheet.get_Range("D" + Convert.ToString(19 + k1 + 11), "F" + Convert.ToString(19 + k1 + 11)).Merge(System.Type.Missing);
                    m_workSheet.Cells[19 + k1 + 11, 4] = "Представитель заказчика";

                    m_workBook.SaveCopyAs(filename);

                }

                finally
                {
                    // Закрытие книги.
                   // m_workBook.Close(false, "", Type.Missing);
                    // Закрытие приложения Excel.
                   // m_app.Quit();

                    m_workBook = null;
                    m_workSheet = null;
                    m_app = null;
                    GC.Collect();
                }
            }


            button2.Enabled = true;
          
        }

        private void button3_Click(object sender, EventArgs e)
        {


            if (checkBox7.Checked)
            {
                Excel.Workbook m_workBook = null;
                Excel.Worksheet m_workSheet = null;

                Excel._Application m_app = null;
                string filename = "D:\\Отчет за " +
                    DateTime.Now.Day + "." +
                    DateTime.Now.Month + "." +
                    DateTime.Now.Year + "(КК + Прачечная).xls";// по умолчанию сохраняет в корень диска С:


                button3.Enabled = false;


                string conn_str = "Database=resources;Data Source=10.1.1.50;User Id=sa;Password=Rfnfgekmrf48";

                MySqlLib.MySqlData.MySqlExecuteData.MyResultData result = new MySqlLib.MySqlData.MySqlExecuteData.MyResultData();

                DateTime date1_w = new DateTime(2014, 1, 1);
                DateTime date2_w = new DateTime(2014, 1, 1);
                DateTime date22_w = new DateTime(2014, 1, 1);
                DateTime date1_w_otch = new DateTime(2014, 1, 1);
                DateTime date2_w_otch = new DateTime(2014, 1, 1);


                if (radioButton7.Checked)
                {
                    DateTime date1_1 = DateTime.Now.AddMonths(-1);
                    date1_w = new DateTime(date1_1.Year, date1_1.Month, 1, 11, 0, 0);

                    date1_1 = DateTime.Now;
                    date2_w = new DateTime(date1_1.Year, date1_1.Month, 1, 11, 0, 0);
                }



                if (radioButton8.Checked)
                {
                    if (comboBox3.Text == "Январь")
                    {
                        date1_w = new DateTime(Convert.ToInt32(textBox3.Text), 1, 1);
                        date2_w = date1_w.AddMonths(1);
                    }
                    if (comboBox3.Text == "Февраль")
                    {
                        date1_w = new DateTime(Convert.ToInt32(textBox3.Text), 2, 1);
                        date2_w = date1_w.AddMonths(1);
                    }
                    if (comboBox3.Text == "Март")
                    {
                        date1_w = new DateTime(Convert.ToInt32(textBox3.Text), 3, 1);
                        date2_w = date1_w.AddMonths(1);
                    }
                    if (comboBox3.Text == "Апрель")
                    {
                        date1_w = new DateTime(Convert.ToInt32(textBox3.Text), 4, 1);
                        date2_w = date1_w.AddMonths(1);
                    }
                    if (comboBox3.Text == "Май")
                    {
                        date1_w = new DateTime(Convert.ToInt32(textBox3.Text), 5, 1);
                        date2_w = date1_w.AddMonths(1);
                    }
                    if (comboBox3.Text == "Июнь")
                    {
                        date1_w = new DateTime(Convert.ToInt32(textBox3.Text), 6, 1);
                        date2_w = date1_w.AddMonths(1);
                    }
                    if (comboBox3.Text == "Июль")
                    {
                        date1_w = new DateTime(Convert.ToInt32(textBox3.Text), 7, 1);
                        date2_w = date1_w.AddMonths(1);
                    }
                    if (comboBox3.Text == "Август")
                    {
                        date1_w = new DateTime(Convert.ToInt32(textBox3.Text), 8, 1);
                        date2_w = date1_w.AddMonths(1);
                    }
                    if (comboBox3.Text == "Сентябрь")
                    {
                        date1_w = new DateTime(Convert.ToInt32(textBox3.Text), 9, 1);
                        date2_w = date1_w.AddMonths(1);
                    }
                    if (comboBox3.Text == "Октябрь")
                    {
                        date1_w = new DateTime(Convert.ToInt32(textBox3.Text), 10, 1);
                        date2_w = date1_w.AddMonths(1);
                    }
                    if (comboBox3.Text == "Ноябрь")
                    {
                        date1_w = new DateTime(Convert.ToInt32(textBox3.Text), 11, 1);
                        date2_w = date1_w.AddMonths(1);
                    }
                    if (comboBox3.Text == "Декабрь")
                    {
                        date1_w = new DateTime(Convert.ToInt32(textBox3.Text), 12, 1);
                        date2_w = date1_w.AddMonths(1);
                    }

                }

                if (radioButton9.Checked)
                {
                    date1_w = new DateTime(dateTimePicker5.Value.Year, dateTimePicker5.Value.Month, dateTimePicker5.Value.Day);
                    date2_w = new DateTime(dateTimePicker6.Value.Year, dateTimePicker6.Value.Month, dateTimePicker6.Value.Day);
                }

                date22_w = date2_w.AddDays(-1);
                date1_w_otch = date1_w;
                date2_w_otch = date2_w;

                TimeSpan interval_w = date2_w - date1_w;

                int days_w = Convert.ToInt32(Math.Floor(interval_w.TotalDays));
                progressBar3.Maximum = Convert.ToInt32(days_w - 1);



                try
                {

                    // Создание приложения Excel.
                    m_app = new Microsoft.Office.Interop.Excel.Application();
                    m_app.ReferenceStyle = Excel.XlReferenceStyle.xlA1;
                    // Приложение "невидимо".
                    m_app.Visible = true;
                    // Приложение управляется пользователем.
                    m_app.UserControl = true;
                    // Добавление книги Excel.
                    m_workBook = m_app.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);


                    // Связь со страницей Excel.

                    m_app.StandardFont = "Courier new cyr";
                    m_app.StandardFontSize = 10;

                    m_workSheet = m_app.ActiveSheet as Excel.Worksheet;

                    m_workSheet.Columns.ColumnWidth = 8.5;

                    m_workSheet.Cells.NumberFormat = "@";

                    m_workSheet.get_Range("A1").ColumnWidth = 10;

                    m_workSheet.get_Range("A1", "K1").Merge(System.Type.Missing);
                    m_workSheet.get_Range("A1").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    m_workSheet.get_Range("A1").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    m_workSheet.Cells[1, 1] = "Отчет";

                    m_workSheet.get_Range("A2", "K2").Merge(System.Type.Missing);
                    m_workSheet.Cells[2, 1] = "о суточных параметрах расхода";
                    m_workSheet.get_Range("A2").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    m_workSheet.get_Range("A2").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                    m_workSheet.get_Range("A3", "K3").Merge(System.Type.Missing);




                    m_workSheet.Cells[3, 1] = "за " + String.Format("{0:dd/MM/yyyy}", date1_w) + "г. - " + String.Format("{0:dd/MM/yyyy}", date22_w) + "г.";


                    m_workSheet.get_Range("A3").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    m_workSheet.get_Range("A3").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                    m_workSheet.get_Range("A5", "K5").Merge(System.Type.Missing);
                    m_workSheet.Cells[5, 1] = "Абонент: 000000000000                             Договор N: ______________";
                    m_workSheet.get_Range("A5").HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    m_workSheet.get_Range("A5").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                    m_workSheet.get_Range("A7", "K7").Merge(System.Type.Missing);
                    m_workSheet.Cells[7, 1] = "Адрес: ________________________                   Тип расходомера: ________ ";
                    m_workSheet.get_Range("A7").HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    m_workSheet.get_Range("A7").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                    m_workSheet.get_Range("A9", "K9").Merge(System.Type.Missing);
                    m_workSheet.Cells[9, 1] = "Расходомер Днепр-7 N 255 (КК + Прачечная)";
                    m_workSheet.get_Range("A9").HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    m_workSheet.get_Range("A9").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                    m_workSheet.get_Range("A11", "K11").Merge(System.Type.Missing);
                    m_workSheet.Cells[11, 1] = "Договорные расходы:                        Пределы измерений:";
                    m_workSheet.get_Range("A11").HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    m_workSheet.get_Range("A11").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                    m_workSheet.get_Range("A12", "K12").Merge(System.Type.Missing);
                    m_workSheet.Cells[12, 1] = "M под= _____ т.сут  М обр= _____ т.сут     G под max= _____  G под min= _____";
                    m_workSheet.get_Range("A12").HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    m_workSheet.get_Range("A12").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                    m_workSheet.get_Range("A16", "A18").Merge(System.Type.Missing);
                    m_workSheet.Cells[16, 1] = "ДАТА";
                    m_workSheet.get_Range("A16").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    m_workSheet.get_Range("A16").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                    m_workSheet.get_Range("B16", "B17").Merge(System.Type.Missing);
                    m_workSheet.Cells[16, 2] = "dM";
                    m_workSheet.get_Range("B16").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    m_workSheet.get_Range("B16").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                    m_workSheet.Cells[18, 2] = "т";
                    m_workSheet.get_Range("B18").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    m_workSheet.get_Range("B18").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                    //m_workSheet.get_Range("C16", "C17").Merge(System.Type.Missing);
                    //m_workSheet.Cells[16, 3] = "dV2";
                    //m_workSheet.get_Range("C16").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    //m_workSheet.get_Range("C16").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                    //m_workSheet.Cells[18, 3] = "м3";
                    //m_workSheet.get_Range("C18").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    //m_workSheet.get_Range("C18").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                    //m_workSheet.Cells[16, 4] = "Наруш";
                    //m_workSheet.get_Range("D16").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    //m_workSheet.get_Range("D16").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                    //m_workSheet.Cells[17, 4] = "О.П.";
                    //m_workSheet.get_Range("D17").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    //m_workSheet.get_Range("D17").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                    //m_workSheet.Cells[18, 4] = "час";
                    //m_workSheet.get_Range("D18").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    //m_workSheet.get_Range("D18").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;


                    m_workSheet.get_Range("C1").ColumnWidth = 12;
                    //m_workSheet.get_Range("F1").ColumnWidth = 12;
                    //m_workSheet.get_Range("E16", "F17").Merge(System.Type.Missing);
                    //m_workSheet.get_Range("E16").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    
                    m_workSheet.get_Range("C16", "C18").Merge(System.Type.Missing);
                    m_workSheet.Cells[16, 3] = "Показания";
                    m_workSheet.get_Range("C16").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    m_workSheet.get_Range("C16").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                    //m_workSheet.Cells[18, 5] = "Канал 1";
                    //m_workSheet.get_Range("E18").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    //m_workSheet.get_Range("E18").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                    //m_workSheet.Cells[18, 6] = "Канал 2";
                    //m_workSheet.get_Range("F18").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    //m_workSheet.get_Range("F18").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                    m_workSheet.get_Range("A16", "C16").BorderAround();
                    m_workSheet.get_Range("A16", "C16").Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = Excel.XlLineStyle.xlContinuous;
                    m_workSheet.get_Range("A17", "C17").BorderAround();
                    m_workSheet.get_Range("A17", "C17").Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = Excel.XlLineStyle.xlContinuous;
                    m_workSheet.get_Range("A18", "C18").BorderAround();
                    m_workSheet.get_Range("A18", "C18").Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = Excel.XlLineStyle.xlContinuous;


                    DateTime date3_w = new DateTime(2014, 1, 1);
                    DateTime date1_1_w = new DateTime(2014, 1, 1);

                    int k1 = 0;
                    decimal fl_sum = 0;
                    decimal fl1 = 0;
                    decimal fl2 = 0;

                   // decimal fl_sum_2 = 0;
                   // decimal fl1_2 = 0;
                   // decimal fl2_2 = 0;


                    for (int k = 0; k <= (interval_w.Days - 1); k++)
                    {

                        if (date1_w.Day < 10)
                        {

                            if (date1_w.Month < 10)
                            {
                                m_workSheet.Cells[19 + k, 1] = "0" + date1_w.Day + "/" + "0" + date1_w.Month;
                            }
                            else
                                m_workSheet.Cells[19 + k, 1] = "0" + date1_w.Day + "/" + date1_w.Month;


                        }
                        else
                        {

                            if (date1_w.Month < 10)
                            {
                                m_workSheet.Cells[19 + k, 1] = date1_w.Day + "/" + "0" + date1_w.Month;
                            }
                            else
                                m_workSheet.Cells[19 + k, 1] = date1_w.Day + "/" + date1_w.Month;
                        }



                        date1_1_w = date1_w.AddDays(-1);
                        date3_w = date1_w;


                        string date1_str_w = date1_1_w.ToString();
                        string date3_str_w = date3_w.ToString();

                        string date1_sql_w;
                        string date3_sql_w;



                        date1_sql_w = date1_str_w.Substring(6, 4) + date1_str_w.Substring(3, 2) + date1_str_w.Substring(0, 2);
                        date3_sql_w = date3_str_w.Substring(6, 4) + date3_str_w.Substring(3, 2) + date3_str_w.Substring(0, 2);


                        result = MySqlLib.MySqlData.MySqlExecuteData.SqlReturnDataset("SELECT * FROM steam2094 where steam_date =" + date1_sql_w + " LIMIT 0,1", conn_str);
                        fl1 = Convert.ToDecimal(result.ResultData.DefaultView.Table.Rows[0]["steam_ch1"].ToString());

                        result = MySqlLib.MySqlData.MySqlExecuteData.SqlReturnDataset("SELECT * FROM steam2094 where steam_date =" + date3_sql_w + " LIMIT 0,1", conn_str);
                        fl2 = Convert.ToDecimal(result.ResultData.DefaultView.Table.Rows[0]["steam_ch1"].ToString());

                        fl_sum = fl_sum + (fl2 - fl1);

                        string result_okr = Convert.ToString(fl2 - fl1).Substring(0, Convert.ToString(fl2 - fl1).IndexOf(',') + 3);


                       // result = MySqlLib.MySqlData.MySqlExecuteData.SqlReturnDataset("SELECT * FROM steam2094 where steam_date =" + date1_sql_w + " LIMIT 0,1", conn_str);
                       // fl1_2 = Convert.ToDecimal(result.ResultData.DefaultView.Table.Rows[0]["steam_ch2"].ToString());

                        //result = MySqlLib.MySqlData.MySqlExecuteData.SqlReturnDataset("SELECT * FROM steam2094 where steam_date =" + date3_sql_w + " LIMIT 0,1", conn_str);
                        //fl2_2 = Convert.ToDecimal(result.ResultData.DefaultView.Table.Rows[0]["steam_ch2"].ToString());

                       // fl_sum_2 = fl_sum_2 + (fl2_2 - fl1_2);



                        //string result_okr2 = Convert.ToString(fl2_2 - fl1_2).Substring(0, Convert.ToString(fl2_2 - fl1_2).IndexOf(',') + 3);


                        m_workSheet.get_Range("B" + Convert.ToString(19 + k)).NumberFormat = "0.00";
                        m_workSheet.get_Range("C" + Convert.ToString(19 + k)).NumberFormat = "0.00";
                        //m_workSheet.get_Range("E" + Convert.ToString(19 + k)).NumberFormat = "0.0000";
                        //m_workSheet.get_Range("F" + Convert.ToString(19 + k)).NumberFormat = "0.0000";

                        m_workSheet.get_Range("A" + Convert.ToString(19 + k)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        m_workSheet.get_Range("B" + Convert.ToString(19 + k)).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;


                        m_workSheet.Cells[19 + k, 3] = Convert.ToDecimal(result.ResultData.DefaultView.Table.Rows[0]["steam_ch1"].ToString());
                        //m_workSheet.Cells[19 + k, 6] = Convert.ToDecimal(result.ResultData.DefaultView.Table.Rows[0]["water_ch2"].ToString());

                        m_workSheet.Cells[19 + k, 2] = Convert.ToDecimal(result_okr);
                       // m_workSheet.Cells[19 + k, 3] = Convert.ToDecimal(result_okr2);


                        m_workSheet.get_Range("A" + Convert.ToString(19 + k), "C" + Convert.ToString(19 + k)).BorderAround();
                        m_workSheet.get_Range("A" + Convert.ToString(19 + k), "C" + Convert.ToString(19 + k)).Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = Excel.XlLineStyle.xlContinuous;

                        date1_w = date1_w.AddDays(1);
                        progressBar2.Value = k;
                        progressBar2.Update();

                        k1 = k;
                    }






                    m_workSheet.Cells[19 + k1 + 1, 1] = "Итого";
                    m_workSheet.get_Range("A" + Convert.ToString(19 + k1 + 1)).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                    m_workSheet.get_Range("A" + Convert.ToString(19 + k1 + 1)).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                    m_workSheet.Cells[19 + k1 + 1, 2] = fl_sum;
                    m_workSheet.get_Range("B" + Convert.ToString(19 + k1 + 1)).NumberFormat = "0.00";
                    m_workSheet.get_Range("B" + Convert.ToString(19 + k1 + 1)).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                    m_workSheet.get_Range("B" + Convert.ToString(19 + k1 + 1)).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                    //m_workSheet.Cells[19 + k1 + 1, 3] = fl_sum_2;
                    //m_workSheet.get_Range("C" + Convert.ToString(19 + k1 + 1)).NumberFormat = "0.00";
                    //m_workSheet.get_Range("C" + Convert.ToString(19 + k1 + 1)).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                    //m_workSheet.get_Range("C" + Convert.ToString(19 + k1 + 1)).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;



                    m_workSheet.Cells[19 + k1 + 2, 1] = "Средний";
                    m_workSheet.get_Range("A" + Convert.ToString(19 + k1 + 2)).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                    m_workSheet.get_Range("A" + Convert.ToString(19 + k1 + 2)).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                    m_workSheet.Cells[19 + k1 + 2, 2] = fl_sum / interval_w.Days;
                    m_workSheet.get_Range("B" + Convert.ToString(19 + k1 + 2)).NumberFormat = "0.00";
                    m_workSheet.get_Range("B" + Convert.ToString(19 + k1 + 2)).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                    m_workSheet.get_Range("B" + Convert.ToString(19 + k1 + 2)).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                   // m_workSheet.Cells[19 + k1 + 2, 3] = fl_sum_2 / interval_w.Days;
                   // m_workSheet.get_Range("C" + Convert.ToString(19 + k1 + 2)).NumberFormat = "0.00";
                   // m_workSheet.get_Range("C" + Convert.ToString(19 + k1 + 2)).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                   // m_workSheet.get_Range("C" + Convert.ToString(19 + k1 + 2)).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                    m_workSheet.get_Range("A" + Convert.ToString(19 + k1 + 1), "B" + Convert.ToString(19 + k1 + 1)).BorderAround();
                    m_workSheet.get_Range("A" + Convert.ToString(19 + k1 + 1), "B" + Convert.ToString(19 + k1 + 1)).Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = Excel.XlLineStyle.xlContinuous;
                    m_workSheet.get_Range("A" + Convert.ToString(19 + k1 + 2), "B" + Convert.ToString(19 + k1 + 2)).BorderAround();
                    m_workSheet.get_Range("A" + Convert.ToString(19 + k1 + 2), "B" + Convert.ToString(19 + k1 + 2)).Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = Excel.XlLineStyle.xlContinuous;



                    m_workSheet.get_Range("A" + Convert.ToString(19 + k1 + 4), "D" + Convert.ToString(19 + k1 + 4)).BorderAround();
                    m_workSheet.get_Range("A" + Convert.ToString(19 + k1 + 4), "D" + Convert.ToString(19 + k1 + 4)).Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = Excel.XlLineStyle.xlContinuous;
                    m_workSheet.get_Range("A" + Convert.ToString(19 + k1 + 5), "D" + Convert.ToString(19 + k1 + 5)).BorderAround();
                    m_workSheet.get_Range("A" + Convert.ToString(19 + k1 + 5), "D" + Convert.ToString(19 + k1 + 5)).Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = Excel.XlLineStyle.xlContinuous;
                    m_workSheet.get_Range("A" + Convert.ToString(19 + k1 + 6), "D" + Convert.ToString(19 + k1 + 6)).BorderAround();
                    m_workSheet.get_Range("A" + Convert.ToString(19 + k1 + 6), "D" + Convert.ToString(19 + k1 + 6)).Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = Excel.XlLineStyle.xlContinuous;
                    m_workSheet.get_Range("A" + Convert.ToString(19 + k1 + 7), "D" + Convert.ToString(19 + k1 + 7)).BorderAround();
                    m_workSheet.get_Range("A" + Convert.ToString(19 + k1 + 7), "D" + Convert.ToString(19 + k1 + 7)).Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = Excel.XlLineStyle.xlContinuous;

                    m_workSheet.get_Range("A" + Convert.ToString(19 + k1 + 4), "A" + Convert.ToString(19 + k1 + 5)).Merge(System.Type.Missing);
                    m_workSheet.Cells[19 + k1 + 4, 1] = "Дата";
                    m_workSheet.get_Range("A" + Convert.ToString(19 + k1 + 4)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    m_workSheet.get_Range("A" + Convert.ToString(19 + k1 + 4)).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;


                    if (date1_w_otch.Day < 10)
                    {

                        if (date1_w_otch.Month < 10)
                        {
                            m_workSheet.Cells[19 + k1 + 6, 1] = "0" + date1_w_otch.Day + "/" + "0" + date1_w_otch.Month + "/" + date1_w_otch.Year;
                        }
                        else
                            m_workSheet.Cells[19 + k1 + 6, 1] = "0" + date1_w_otch.Day + "/" + date1_w_otch.Month + "/" + date1_w_otch.Year;


                    }
                    else
                    {

                        if (date1_w_otch.Month < 10)
                        {
                            m_workSheet.Cells[19 + k1 + 6, 1] = date1_w_otch.Day + "/" + "0" + date1_w_otch.Month + "/" + date1_w_otch.Year;
                        }
                        else
                            m_workSheet.Cells[19 + k1 + 6, 1] = date1_w_otch.Day + "/" + date1_w_otch.Month + "/" + date1_w_otch.Year;
                    }

                    if (date2_w_otch.Day < 10)
                    {

                        if (date2_w_otch.Month < 10)
                        {
                            m_workSheet.Cells[19 + k1 + 7, 1] = "0" + date2_w_otch.Day + "/" + "0" + date2_w_otch.Month + "/" + date2_w_otch.Year;
                        }
                        else
                            m_workSheet.Cells[19 + k1 + 7, 1] = "0" + date2_w_otch.Day + "/" + date2_w_otch.Month + "/" + date2_w_otch.Year;


                    }
                    else
                    {

                        if (date2_w_otch.Month < 10)
                        {
                            m_workSheet.Cells[19 + k1 + 7, 1] = date2_w_otch.Day + "/" + "0" + date2_w_otch.Month + "/" + date2_w_otch.Year;
                        }
                        else
                            m_workSheet.Cells[19 + k1 + 7, 1] = date2_w_otch.Day + "/" + date2_w_otch.Month + "/" + date2_w_otch.Year;
                    }



                    m_workSheet.get_Range("A" + Convert.ToString(19 + k1 + 6)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    m_workSheet.get_Range("A" + Convert.ToString(19 + k1 + 6)).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;


                    m_workSheet.get_Range("B" + Convert.ToString(19 + k1 + 4), "B" + Convert.ToString(19 + k1 + 5)).Merge(System.Type.Missing);
                    m_workSheet.Cells[19 + k1 + 4, 2] = "Время";
                    m_workSheet.get_Range("B" + Convert.ToString(19 + k1 + 4)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    m_workSheet.get_Range("B" + Convert.ToString(19 + k1 + 4)).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                    m_workSheet.Cells[19 + k1 + 6, 2] = "00:00";
                    m_workSheet.get_Range("B" + Convert.ToString(19 + k1 + 6)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    m_workSheet.get_Range("B" + Convert.ToString(19 + k1 + 6)).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                    m_workSheet.Cells[19 + k1 + 7, 2] = "00:00";
                    m_workSheet.get_Range("B" + Convert.ToString(19 + k1 + 7)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    m_workSheet.get_Range("B" + Convert.ToString(19 + k1 + 7)).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;


                    m_workSheet.get_Range("C" + Convert.ToString(19 + k1 + 4), "D" + Convert.ToString(19 + k1 + 4)).Merge(System.Type.Missing);
                    m_workSheet.Cells[19 + k1 + 4, 3] = "M";
                    m_workSheet.get_Range("C" + Convert.ToString(19 + k1 + 4)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    m_workSheet.get_Range("C" + Convert.ToString(19 + k1 + 4)).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                    m_workSheet.get_Range("C" + Convert.ToString(19 + k1 + 5), "D" + Convert.ToString(19 + k1 + 5)).Merge(System.Type.Missing);
                    m_workSheet.Cells[19 + k1 + 5, 3] = "т";
                    m_workSheet.get_Range("C" + Convert.ToString(19 + k1 + 5)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    m_workSheet.get_Range("C" + Convert.ToString(19 + k1 + 5)).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                    //m_workSheet.get_Range("E" + Convert.ToString(19 + k1 + 4), "F" + Convert.ToString(19 + k1 + 4)).Merge(System.Type.Missing);
                    //m_workSheet.Cells[19 + k1 + 4, 5] = "V2";
                    //m_workSheet.get_Range("E" + Convert.ToString(19 + k1 + 4)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    //m_workSheet.get_Range("E" + Convert.ToString(19 + k1 + 4)).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                    //m_workSheet.get_Range("E" + Convert.ToString(19 + k1 + 5), "F" + Convert.ToString(19 + k1 + 5)).Merge(System.Type.Missing);
                    //m_workSheet.Cells[19 + k1 + 5, 5] = "м3";
                    //m_workSheet.get_Range("E" + Convert.ToString(19 + k1 + 5)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    //m_workSheet.get_Range("E" + Convert.ToString(19 + k1 + 5)).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;



                    m_workSheet.get_Range("C" + Convert.ToString(19 + k1 + 6)).NumberFormat = "0.0000";
                    //m_workSheet.get_Range("E" + Convert.ToString(19 + k1 + 6)).NumberFormat = "0.0000";

                    m_workSheet.get_Range("C" + Convert.ToString(19 + k1 + 7)).NumberFormat = "0.0000";
                    //m_workSheet.get_Range("E" + Convert.ToString(19 + k1 + 7)).NumberFormat = "0.0000";


                    m_workSheet.get_Range("C" + Convert.ToString(19 + k1 + 6), "D" + Convert.ToString(19 + k1 + 6)).Merge(System.Type.Missing);
                    m_workSheet.Cells[19 + k1 + 6, 3] = fl2 - fl_sum;
                    m_workSheet.get_Range("C" + Convert.ToString(19 + k1 + 6)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    m_workSheet.get_Range("C" + Convert.ToString(19 + k1 + 6)).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                    //m_workSheet.get_Range("E" + Convert.ToString(19 + k1 + 6), "F" + Convert.ToString(19 + k1 + 6)).Merge(System.Type.Missing);
                    //m_workSheet.Cells[19 + k1 + 6, 5] = fl2_2 - fl_sum_2;
                    //m_workSheet.get_Range("E" + Convert.ToString(19 + k1 + 6)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    //m_workSheet.get_Range("E" + Convert.ToString(19 + k1 + 6)).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                    m_workSheet.get_Range("C" + Convert.ToString(19 + k1 + 7), "D" + Convert.ToString(19 + k1 + 7)).Merge(System.Type.Missing);
                    m_workSheet.Cells[19 + k1 + 7, 3] = fl2;
                    m_workSheet.get_Range("C" + Convert.ToString(19 + k1 + 7)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    m_workSheet.get_Range("C" + Convert.ToString(19 + k1 + 7)).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                    //m_workSheet.get_Range("E" + Convert.ToString(19 + k1 + 7), "F" + Convert.ToString(19 + k1 + 7)).Merge(System.Type.Missing);
                    //m_workSheet.Cells[19 + k1 + 7, 5] = fl2_2;
                    //m_workSheet.get_Range("E" + Convert.ToString(19 + k1 + 7)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    //m_workSheet.get_Range("E" + Convert.ToString(19 + k1 + 7)).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                    m_workSheet.get_Range("A" + Convert.ToString(19 + k1 + 9), "F" + Convert.ToString(19 + k1 + 9)).Merge(System.Type.Missing);
                    m_workSheet.Cells[19 + k1 + 9, 1] = "Время наработки: " + Convert.ToString(24 * interval_w.TotalDays) + ".00 часов";

                    m_workSheet.get_Range("A" + Convert.ToString(19 + k1 + 11), "C" + Convert.ToString(19 + k1 + 11)).Merge(System.Type.Missing);
                    m_workSheet.Cells[19 + k1 + 11, 1] = "Представитель потребителя";

                    m_workSheet.get_Range("D" + Convert.ToString(19 + k1 + 11), "F" + Convert.ToString(19 + k1 + 11)).Merge(System.Type.Missing);
                    m_workSheet.Cells[19 + k1 + 11, 4] = "Представитель заказчика";

                    m_workBook.SaveCopyAs(filename);

                }

                finally
                {
                    // Закрытие книги.
                   // m_workBook.Close(false, "", Type.Missing);
                    // Закрытие приложения Excel.
                   // m_app.Quit();

                    m_workBook = null;
                    m_workSheet = null;
                    m_app = null;
                    GC.Collect();
                }
            }

            if (checkBox8.Checked)
                {
                    Excel.Workbook m_workBook = null;
                    Excel.Worksheet m_workSheet = null;

                    Excel._Application m_app = null;
                    string filename = "D:\\Отчет за " +
                        DateTime.Now.Day + "." +
                        DateTime.Now.Month + "." +
                        DateTime.Now.Year + "(Маслоцех + НС).xls";// по умолчанию сохраняет в корень диска С:


                    button2.Enabled = false;


                    string conn_str = "Database=resources;Data Source=10.1.1.50;User Id=sa;Password=Rfnfgekmrf48";

                    MySqlLib.MySqlData.MySqlExecuteData.MyResultData result = new MySqlLib.MySqlData.MySqlExecuteData.MyResultData();

                    DateTime date1_w = new DateTime(2014, 1, 1);
                    DateTime date2_w = new DateTime(2014, 1, 1);
                    DateTime date22_w = new DateTime(2014, 1, 1);
                    DateTime date1_w_otch = new DateTime(2014, 1, 1);
                    DateTime date2_w_otch = new DateTime(2014, 1, 1);


                    if (radioButton7.Checked)
                    {
                        DateTime date1_1 = DateTime.Now.AddMonths(-1);
                        date1_w = new DateTime(date1_1.Year, date1_1.Month, 1, 11, 0, 0);

                        date1_1 = DateTime.Now;
                        date2_w = new DateTime(date1_1.Year, date1_1.Month, 1, 11, 0, 0);
                    }



                    if (radioButton8.Checked)
                    {
                        if (comboBox3.Text == "Январь")
                        {
                            date1_w = new DateTime(Convert.ToInt32(textBox3.Text), 1, 1);
                            date2_w = date1_w.AddMonths(1);
                        }
                        if (comboBox3.Text == "Февраль")
                        {
                            date1_w = new DateTime(Convert.ToInt32(textBox3.Text), 2, 1);
                            date2_w = date1_w.AddMonths(1);
                        }
                        if (comboBox3.Text == "Март")
                        {
                            date1_w = new DateTime(Convert.ToInt32(textBox3.Text), 3, 1);
                            date2_w = date1_w.AddMonths(1);
                        }
                        if (comboBox3.Text == "Апрель")
                        {
                            date1_w = new DateTime(Convert.ToInt32(textBox3.Text), 4, 1);
                            date2_w = date1_w.AddMonths(1);
                        }
                        if (comboBox3.Text == "Май")
                        {
                            date1_w = new DateTime(Convert.ToInt32(textBox3.Text), 5, 1);
                            date2_w = date1_w.AddMonths(1);
                        }
                        if (comboBox3.Text == "Июнь")
                        {
                            date1_w = new DateTime(Convert.ToInt32(textBox3.Text), 6, 1);
                            date2_w = date1_w.AddMonths(1);
                        }
                        if (comboBox3.Text == "Июль")
                        {
                            date1_w = new DateTime(Convert.ToInt32(textBox3.Text), 7, 1);
                            date2_w = date1_w.AddMonths(1);
                        }
                        if (comboBox3.Text == "Август")
                        {
                            date1_w = new DateTime(Convert.ToInt32(textBox3.Text), 8, 1);
                            date2_w = date1_w.AddMonths(1);
                        }
                        if (comboBox3.Text == "Сентябрь")
                        {
                            date1_w = new DateTime(Convert.ToInt32(textBox3.Text), 9, 1);
                            date2_w = date1_w.AddMonths(1);
                        }
                        if (comboBox3.Text == "Октябрь")
                        {
                            date1_w = new DateTime(Convert.ToInt32(textBox3.Text), 10, 1);
                            date2_w = date1_w.AddMonths(1);
                        }
                        if (comboBox3.Text == "Ноябрь")
                        {
                            date1_w = new DateTime(Convert.ToInt32(textBox3.Text), 11, 1);
                            date2_w = date1_w.AddMonths(1);
                        }
                        if (comboBox3.Text == "Декабрь")
                        {
                            date1_w = new DateTime(Convert.ToInt32(textBox3.Text), 12, 1);
                            date2_w = date1_w.AddMonths(1);
                        }

                    }

                    if (radioButton9.Checked)
                    {
                        date1_w = new DateTime(dateTimePicker5.Value.Year, dateTimePicker5.Value.Month, dateTimePicker5.Value.Day);
                        date2_w = new DateTime(dateTimePicker6.Value.Year, dateTimePicker6.Value.Month, dateTimePicker6.Value.Day);
                    }







                    date22_w = date2_w.AddDays(-1);
                    date1_w_otch = date1_w;
                    date2_w_otch = date2_w;

                    TimeSpan interval_w = date2_w - date1_w;

                    int days_w = Convert.ToInt32(Math.Floor(interval_w.TotalDays));
                    progressBar2.Maximum = Convert.ToInt32(days_w - 1);



                    try
                    {

                        // Создание приложения Excel.
                        m_app = new Microsoft.Office.Interop.Excel.Application();
                        m_app.ReferenceStyle = Excel.XlReferenceStyle.xlA1;
                        // Приложение "невидимо".
                        m_app.Visible = true;
                        // Приложение управляется пользователем.
                        m_app.UserControl = true;
                        // Добавление книги Excel.
                        m_workBook = m_app.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);


                        // Связь со страницей Excel.

                        m_app.StandardFont = "Courier new cyr";
                        m_app.StandardFontSize = 10;

                        m_workSheet = m_app.ActiveSheet as Excel.Worksheet;

                        m_workSheet.Columns.ColumnWidth = 8.5;

                        m_workSheet.Cells.NumberFormat = "@";

                        m_workSheet.get_Range("A1").ColumnWidth = 10;

                        m_workSheet.get_Range("A1", "K1").Merge(System.Type.Missing);
                        m_workSheet.get_Range("A1").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        m_workSheet.get_Range("A1").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                        m_workSheet.Cells[1, 1] = "Отчет";

                        m_workSheet.get_Range("A2", "K2").Merge(System.Type.Missing);
                        m_workSheet.Cells[2, 1] = "о суточных параметрах расхода";
                        m_workSheet.get_Range("A2").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        m_workSheet.get_Range("A2").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                        m_workSheet.get_Range("A3", "K3").Merge(System.Type.Missing);




                        m_workSheet.Cells[3, 1] = "за " + String.Format("{0:dd/MM/yyyy}", date1_w) + "г. - " + String.Format("{0:dd/MM/yyyy}", date22_w) + "г.";


                        m_workSheet.get_Range("A3").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        m_workSheet.get_Range("A3").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                        m_workSheet.get_Range("A5", "K5").Merge(System.Type.Missing);
                        m_workSheet.Cells[5, 1] = "Абонент: 000000000000                             Договор N: ______________";
                        m_workSheet.get_Range("A5").HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                        m_workSheet.get_Range("A5").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                        m_workSheet.get_Range("A7", "K7").Merge(System.Type.Missing);
                        m_workSheet.Cells[7, 1] = "Адрес: ________________________                   Тип расходомера: ________ ";
                        m_workSheet.get_Range("A7").HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                        m_workSheet.get_Range("A7").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                        m_workSheet.get_Range("A9", "K9").Merge(System.Type.Missing);
                        m_workSheet.Cells[9, 1] = "Расходомер Днепр-7 N 255 (Маслоцех + НС)";
                        m_workSheet.get_Range("A9").HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                        m_workSheet.get_Range("A9").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                        m_workSheet.get_Range("A11", "K11").Merge(System.Type.Missing);
                        m_workSheet.Cells[11, 1] = "Договорные расходы:                        Пределы измерений:";
                        m_workSheet.get_Range("A11").HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                        m_workSheet.get_Range("A11").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                        m_workSheet.get_Range("A12", "K12").Merge(System.Type.Missing);
                        m_workSheet.Cells[12, 1] = "M под= _____ т.сут  М обр= _____ т.сут     G под max= _____  G под min= _____";
                        m_workSheet.get_Range("A12").HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                        m_workSheet.get_Range("A12").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                        m_workSheet.get_Range("A16", "A18").Merge(System.Type.Missing);
                        m_workSheet.Cells[16, 1] = "ДАТА";
                        m_workSheet.get_Range("A16").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        m_workSheet.get_Range("A16").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                        m_workSheet.get_Range("B16", "B17").Merge(System.Type.Missing);
                        m_workSheet.Cells[16, 2] = "dM";
                        m_workSheet.get_Range("B16").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        m_workSheet.get_Range("B16").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                        m_workSheet.Cells[18, 2] = "т";
                        m_workSheet.get_Range("B18").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        m_workSheet.get_Range("B18").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                        //m_workSheet.get_Range("C16", "C17").Merge(System.Type.Missing);
                        //m_workSheet.Cells[16, 3] = "dV2";
                        //m_workSheet.get_Range("C16").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        //m_workSheet.get_Range("C16").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                        //m_workSheet.Cells[18, 3] = "м3";
                        //m_workSheet.get_Range("C18").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        //m_workSheet.get_Range("C18").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                        //m_workSheet.Cells[16, 4] = "Наруш";
                        //m_workSheet.get_Range("D16").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        //m_workSheet.get_Range("D16").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                        //m_workSheet.Cells[17, 4] = "О.П.";
                        //m_workSheet.get_Range("D17").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        //m_workSheet.get_Range("D17").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                        //m_workSheet.Cells[18, 4] = "час";
                        //m_workSheet.get_Range("D18").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        //m_workSheet.get_Range("D18").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;


                        m_workSheet.get_Range("C1").ColumnWidth = 12;
                        //m_workSheet.get_Range("F1").ColumnWidth = 12;
                        //m_workSheet.get_Range("E16", "F17").Merge(System.Type.Missing);
                        //m_workSheet.get_Range("E16").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                        m_workSheet.get_Range("C16", "C18").Merge(System.Type.Missing);
                        m_workSheet.Cells[16, 3] = "Показания";
                        m_workSheet.get_Range("C16").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        m_workSheet.get_Range("C16").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                        //m_workSheet.Cells[18, 5] = "Канал 1";
                        //m_workSheet.get_Range("E18").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        //m_workSheet.get_Range("E18").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                        //m_workSheet.Cells[18, 6] = "Канал 2";
                        //m_workSheet.get_Range("F18").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        //m_workSheet.get_Range("F18").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                        m_workSheet.get_Range("A16", "C16").BorderAround();
                        m_workSheet.get_Range("A16", "C16").Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = Excel.XlLineStyle.xlContinuous;
                        m_workSheet.get_Range("A17", "C17").BorderAround();
                        m_workSheet.get_Range("A17", "C17").Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = Excel.XlLineStyle.xlContinuous;
                        m_workSheet.get_Range("A18", "C18").BorderAround();
                        m_workSheet.get_Range("A18", "C18").Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = Excel.XlLineStyle.xlContinuous;


                        DateTime date3_w = new DateTime(2014, 1, 1);
                        DateTime date1_1_w = new DateTime(2014, 1, 1);

                        int k1 = 0;
                        decimal fl_sum = 0;
                        decimal fl1 = 0;
                        decimal fl2 = 0;

                        //decimal fl_sum_2 = 0;
                        //decimal fl1_2 = 0;
                        //decimal fl2_2 = 0;


                        for (int k = 0; k <= (interval_w.Days - 1); k++)
                        {

                            if (date1_w.Day < 10)
                            {

                                if (date1_w.Month < 10)
                                {
                                    m_workSheet.Cells[19 + k, 1] = "0" + date1_w.Day + "/" + "0" + date1_w.Month;
                                }
                                else
                                    m_workSheet.Cells[19 + k, 1] = "0" + date1_w.Day + "/" + date1_w.Month;


                            }
                            else
                            {

                                if (date1_w.Month < 10)
                                {
                                    m_workSheet.Cells[19 + k, 1] = date1_w.Day + "/" + "0" + date1_w.Month;
                                }
                                else
                                    m_workSheet.Cells[19 + k, 1] = date1_w.Day + "/" + date1_w.Month;
                            }



                            date1_1_w = date1_w.AddDays(-1);
                            date3_w = date1_w;


                            string date1_str_w = date1_1_w.ToString();
                            string date3_str_w = date3_w.ToString();

                            string date1_sql_w;
                            string date3_sql_w;



                            date1_sql_w = date1_str_w.Substring(6, 4) + date1_str_w.Substring(3, 2) + date1_str_w.Substring(0, 2);
                            date3_sql_w = date3_str_w.Substring(6, 4) + date3_str_w.Substring(3, 2) + date3_str_w.Substring(0, 2);


                            result = MySqlLib.MySqlData.MySqlExecuteData.SqlReturnDataset("SELECT * FROM steam2123 where steam_date =" + date1_sql_w + " LIMIT 0,1", conn_str);
                            fl1 = Convert.ToDecimal(result.ResultData.DefaultView.Table.Rows[0]["steam_ch1"].ToString());

                            result = MySqlLib.MySqlData.MySqlExecuteData.SqlReturnDataset("SELECT * FROM steam2123 where steam_date =" + date3_sql_w + " LIMIT 0,1", conn_str);
                            fl2 = Convert.ToDecimal(result.ResultData.DefaultView.Table.Rows[0]["steam_ch1"].ToString());

                            fl_sum = fl_sum + (fl2 - fl1);

                            string result_okr = Convert.ToString(fl2 - fl1).Substring(0, Convert.ToString(fl2 - fl1).IndexOf(',') + 3);


                            // result = MySqlLib.MySqlData.MySqlExecuteData.SqlReturnDataset("SELECT * FROM steam2123 where steam_date =" + date1_sql_w + " LIMIT 0,1", conn_str);
                            // fl1_2 = Convert.ToDecimal(result.ResultData.DefaultView.Table.Rows[0]["steam_ch2"].ToString());

                            //result = MySqlLib.MySqlData.MySqlExecuteData.SqlReturnDataset("SELECT * FROM steam2123 where steam_date =" + date3_sql_w + " LIMIT 0,1", conn_str);
                            //fl2_2 = Convert.ToDecimal(result.ResultData.DefaultView.Table.Rows[0]["steam_ch2"].ToString());

                            // fl_sum_2 = fl_sum_2 + (fl2_2 - fl1_2);



                            //string result_okr2 = Convert.ToString(fl2_2 - fl1_2).Substring(0, Convert.ToString(fl2_2 - fl1_2).IndexOf(',') + 3);


                            m_workSheet.get_Range("B" + Convert.ToString(19 + k)).NumberFormat = "0.00";
                            m_workSheet.get_Range("C" + Convert.ToString(19 + k)).NumberFormat = "0.00";
                            //m_workSheet.get_Range("E" + Convert.ToString(19 + k)).NumberFormat = "0.0000";
                            //m_workSheet.get_Range("F" + Convert.ToString(19 + k)).NumberFormat = "0.0000";

                            m_workSheet.get_Range("A" + Convert.ToString(19 + k)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                            m_workSheet.get_Range("B" + Convert.ToString(19 + k)).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;


                            m_workSheet.Cells[19 + k, 3] = Convert.ToDecimal(result.ResultData.DefaultView.Table.Rows[0]["steam_ch1"].ToString());
                            //m_workSheet.Cells[19 + k, 6] = Convert.ToDecimal(result.ResultData.DefaultView.Table.Rows[0]["water_ch2"].ToString());

                            m_workSheet.Cells[19 + k, 2] = Convert.ToDecimal(result_okr);
                            // m_workSheet.Cells[19 + k, 3] = Convert.ToDecimal(result_okr2);


                            m_workSheet.get_Range("A" + Convert.ToString(19 + k), "C" + Convert.ToString(19 + k)).BorderAround();
                            m_workSheet.get_Range("A" + Convert.ToString(19 + k), "C" + Convert.ToString(19 + k)).Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = Excel.XlLineStyle.xlContinuous;

                            date1_w = date1_w.AddDays(1);
                            progressBar2.Value = k;
                            progressBar2.Update();

                            k1 = k;
                        }






                        m_workSheet.Cells[19 + k1 + 1, 1] = "Итого";
                        m_workSheet.get_Range("A" + Convert.ToString(19 + k1 + 1)).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                        m_workSheet.get_Range("A" + Convert.ToString(19 + k1 + 1)).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                        m_workSheet.Cells[19 + k1 + 1, 2] = fl_sum;
                        m_workSheet.get_Range("B" + Convert.ToString(19 + k1 + 1)).NumberFormat = "0.00";
                        m_workSheet.get_Range("B" + Convert.ToString(19 + k1 + 1)).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                        m_workSheet.get_Range("B" + Convert.ToString(19 + k1 + 1)).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                        //m_workSheet.Cells[19 + k1 + 1, 3] = fl_sum_2;
                        //m_workSheet.get_Range("C" + Convert.ToString(19 + k1 + 1)).NumberFormat = "0.00";
                        //m_workSheet.get_Range("C" + Convert.ToString(19 + k1 + 1)).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                        //m_workSheet.get_Range("C" + Convert.ToString(19 + k1 + 1)).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;



                        m_workSheet.Cells[19 + k1 + 2, 1] = "Средний";
                        m_workSheet.get_Range("A" + Convert.ToString(19 + k1 + 2)).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                        m_workSheet.get_Range("A" + Convert.ToString(19 + k1 + 2)).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                        m_workSheet.Cells[19 + k1 + 2, 2] = fl_sum / interval_w.Days;
                        m_workSheet.get_Range("B" + Convert.ToString(19 + k1 + 2)).NumberFormat = "0.00";
                        m_workSheet.get_Range("B" + Convert.ToString(19 + k1 + 2)).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                        m_workSheet.get_Range("B" + Convert.ToString(19 + k1 + 2)).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                        // m_workSheet.Cells[19 + k1 + 2, 3] = fl_sum_2 / interval_w.Days;
                        // m_workSheet.get_Range("C" + Convert.ToString(19 + k1 + 2)).NumberFormat = "0.00";
                        // m_workSheet.get_Range("C" + Convert.ToString(19 + k1 + 2)).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                        // m_workSheet.get_Range("C" + Convert.ToString(19 + k1 + 2)).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                        m_workSheet.get_Range("A" + Convert.ToString(19 + k1 + 1), "B" + Convert.ToString(19 + k1 + 1)).BorderAround();
                        m_workSheet.get_Range("A" + Convert.ToString(19 + k1 + 1), "B" + Convert.ToString(19 + k1 + 1)).Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = Excel.XlLineStyle.xlContinuous;
                        m_workSheet.get_Range("A" + Convert.ToString(19 + k1 + 2), "B" + Convert.ToString(19 + k1 + 2)).BorderAround();
                        m_workSheet.get_Range("A" + Convert.ToString(19 + k1 + 2), "B" + Convert.ToString(19 + k1 + 2)).Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = Excel.XlLineStyle.xlContinuous;



                        m_workSheet.get_Range("A" + Convert.ToString(19 + k1 + 4), "D" + Convert.ToString(19 + k1 + 4)).BorderAround();
                        m_workSheet.get_Range("A" + Convert.ToString(19 + k1 + 4), "D" + Convert.ToString(19 + k1 + 4)).Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = Excel.XlLineStyle.xlContinuous;
                        m_workSheet.get_Range("A" + Convert.ToString(19 + k1 + 5), "D" + Convert.ToString(19 + k1 + 5)).BorderAround();
                        m_workSheet.get_Range("A" + Convert.ToString(19 + k1 + 5), "D" + Convert.ToString(19 + k1 + 5)).Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = Excel.XlLineStyle.xlContinuous;
                        m_workSheet.get_Range("A" + Convert.ToString(19 + k1 + 6), "D" + Convert.ToString(19 + k1 + 6)).BorderAround();
                        m_workSheet.get_Range("A" + Convert.ToString(19 + k1 + 6), "D" + Convert.ToString(19 + k1 + 6)).Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = Excel.XlLineStyle.xlContinuous;
                        m_workSheet.get_Range("A" + Convert.ToString(19 + k1 + 7), "D" + Convert.ToString(19 + k1 + 7)).BorderAround();
                        m_workSheet.get_Range("A" + Convert.ToString(19 + k1 + 7), "D" + Convert.ToString(19 + k1 + 7)).Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = Excel.XlLineStyle.xlContinuous;

                        m_workSheet.get_Range("A" + Convert.ToString(19 + k1 + 4), "A" + Convert.ToString(19 + k1 + 5)).Merge(System.Type.Missing);
                        m_workSheet.Cells[19 + k1 + 4, 1] = "Дата";
                        m_workSheet.get_Range("A" + Convert.ToString(19 + k1 + 4)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        m_workSheet.get_Range("A" + Convert.ToString(19 + k1 + 4)).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;


                        if (date1_w_otch.Day < 10)
                        {

                            if (date1_w_otch.Month < 10)
                            {
                                m_workSheet.Cells[19 + k1 + 6, 1] = "0" + date1_w_otch.Day + "/" + "0" + date1_w_otch.Month + "/" + date1_w_otch.Year;
                            }
                            else
                                m_workSheet.Cells[19 + k1 + 6, 1] = "0" + date1_w_otch.Day + "/" + date1_w_otch.Month + "/" + date1_w_otch.Year;


                        }
                        else
                        {

                            if (date1_w_otch.Month < 10)
                            {
                                m_workSheet.Cells[19 + k1 + 6, 1] = date1_w_otch.Day + "/" + "0" + date1_w_otch.Month + "/" + date1_w_otch.Year;
                            }
                            else
                                m_workSheet.Cells[19 + k1 + 6, 1] = date1_w_otch.Day + "/" + date1_w_otch.Month + "/" + date1_w_otch.Year;
                        }

                        if (date2_w_otch.Day < 10)
                        {

                            if (date2_w_otch.Month < 10)
                            {
                                m_workSheet.Cells[19 + k1 + 7, 1] = "0" + date2_w_otch.Day + "/" + "0" + date2_w_otch.Month + "/" + date2_w_otch.Year;
                            }
                            else
                                m_workSheet.Cells[19 + k1 + 7, 1] = "0" + date2_w_otch.Day + "/" + date2_w_otch.Month + "/" + date2_w_otch.Year;


                        }
                        else
                        {

                            if (date2_w_otch.Month < 10)
                            {
                                m_workSheet.Cells[19 + k1 + 7, 1] = date2_w_otch.Day + "/" + "0" + date2_w_otch.Month + "/" + date2_w_otch.Year;
                            }
                            else
                                m_workSheet.Cells[19 + k1 + 7, 1] = date2_w_otch.Day + "/" + date2_w_otch.Month + "/" + date2_w_otch.Year;
                        }



                        m_workSheet.get_Range("A" + Convert.ToString(19 + k1 + 6)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        m_workSheet.get_Range("A" + Convert.ToString(19 + k1 + 6)).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;


                        m_workSheet.get_Range("B" + Convert.ToString(19 + k1 + 4), "B" + Convert.ToString(19 + k1 + 5)).Merge(System.Type.Missing);
                        m_workSheet.Cells[19 + k1 + 4, 2] = "Время";
                        m_workSheet.get_Range("B" + Convert.ToString(19 + k1 + 4)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        m_workSheet.get_Range("B" + Convert.ToString(19 + k1 + 4)).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                        m_workSheet.Cells[19 + k1 + 6, 2] = "00:00";
                        m_workSheet.get_Range("B" + Convert.ToString(19 + k1 + 6)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        m_workSheet.get_Range("B" + Convert.ToString(19 + k1 + 6)).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                        m_workSheet.Cells[19 + k1 + 7, 2] = "00:00";
                        m_workSheet.get_Range("B" + Convert.ToString(19 + k1 + 7)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        m_workSheet.get_Range("B" + Convert.ToString(19 + k1 + 7)).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;


                        m_workSheet.get_Range("C" + Convert.ToString(19 + k1 + 4), "D" + Convert.ToString(19 + k1 + 4)).Merge(System.Type.Missing);
                        m_workSheet.Cells[19 + k1 + 4, 3] = "M";
                        m_workSheet.get_Range("C" + Convert.ToString(19 + k1 + 4)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        m_workSheet.get_Range("C" + Convert.ToString(19 + k1 + 4)).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                        m_workSheet.get_Range("C" + Convert.ToString(19 + k1 + 5), "D" + Convert.ToString(19 + k1 + 5)).Merge(System.Type.Missing);
                        m_workSheet.Cells[19 + k1 + 5, 3] = "т";
                        m_workSheet.get_Range("C" + Convert.ToString(19 + k1 + 5)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        m_workSheet.get_Range("C" + Convert.ToString(19 + k1 + 5)).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                        //m_workSheet.get_Range("E" + Convert.ToString(19 + k1 + 4), "F" + Convert.ToString(19 + k1 + 4)).Merge(System.Type.Missing);
                        //m_workSheet.Cells[19 + k1 + 4, 5] = "V2";
                        //m_workSheet.get_Range("E" + Convert.ToString(19 + k1 + 4)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        //m_workSheet.get_Range("E" + Convert.ToString(19 + k1 + 4)).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                        //m_workSheet.get_Range("E" + Convert.ToString(19 + k1 + 5), "F" + Convert.ToString(19 + k1 + 5)).Merge(System.Type.Missing);
                        //m_workSheet.Cells[19 + k1 + 5, 5] = "м3";
                        //m_workSheet.get_Range("E" + Convert.ToString(19 + k1 + 5)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        //m_workSheet.get_Range("E" + Convert.ToString(19 + k1 + 5)).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;



                        m_workSheet.get_Range("C" + Convert.ToString(19 + k1 + 6)).NumberFormat = "0.0000";
                        //m_workSheet.get_Range("E" + Convert.ToString(19 + k1 + 6)).NumberFormat = "0.0000";

                        m_workSheet.get_Range("C" + Convert.ToString(19 + k1 + 7)).NumberFormat = "0.0000";
                        //m_workSheet.get_Range("E" + Convert.ToString(19 + k1 + 7)).NumberFormat = "0.0000";


                        m_workSheet.get_Range("C" + Convert.ToString(19 + k1 + 6), "D" + Convert.ToString(19 + k1 + 6)).Merge(System.Type.Missing);
                        m_workSheet.Cells[19 + k1 + 6, 3] = fl2 - fl_sum;
                        m_workSheet.get_Range("C" + Convert.ToString(19 + k1 + 6)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        m_workSheet.get_Range("C" + Convert.ToString(19 + k1 + 6)).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                        //m_workSheet.get_Range("E" + Convert.ToString(19 + k1 + 6), "F" + Convert.ToString(19 + k1 + 6)).Merge(System.Type.Missing);
                        //m_workSheet.Cells[19 + k1 + 6, 5] = fl2_2 - fl_sum_2;
                        //m_workSheet.get_Range("E" + Convert.ToString(19 + k1 + 6)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        //m_workSheet.get_Range("E" + Convert.ToString(19 + k1 + 6)).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                        m_workSheet.get_Range("C" + Convert.ToString(19 + k1 + 7), "D" + Convert.ToString(19 + k1 + 7)).Merge(System.Type.Missing);
                        m_workSheet.Cells[19 + k1 + 7, 3] = fl2;
                        m_workSheet.get_Range("C" + Convert.ToString(19 + k1 + 7)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        m_workSheet.get_Range("C" + Convert.ToString(19 + k1 + 7)).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                        //m_workSheet.get_Range("E" + Convert.ToString(19 + k1 + 7), "F" + Convert.ToString(19 + k1 + 7)).Merge(System.Type.Missing);
                        //m_workSheet.Cells[19 + k1 + 7, 5] = fl2_2;
                        //m_workSheet.get_Range("E" + Convert.ToString(19 + k1 + 7)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        //m_workSheet.get_Range("E" + Convert.ToString(19 + k1 + 7)).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                        m_workSheet.get_Range("A" + Convert.ToString(19 + k1 + 9), "F" + Convert.ToString(19 + k1 + 9)).Merge(System.Type.Missing);
                        m_workSheet.Cells[19 + k1 + 9, 1] = "Время наработки: " + Convert.ToString(24 * interval_w.TotalDays) + ".00 часов";

                        m_workSheet.get_Range("A" + Convert.ToString(19 + k1 + 11), "C" + Convert.ToString(19 + k1 + 11)).Merge(System.Type.Missing);
                        m_workSheet.Cells[19 + k1 + 11, 1] = "Представитель потребителя";

                        m_workSheet.get_Range("D" + Convert.ToString(19 + k1 + 11), "F" + Convert.ToString(19 + k1 + 11)).Merge(System.Type.Missing);
                        m_workSheet.Cells[19 + k1 + 11, 4] = "Представитель заказчика";

                        m_workBook.SaveCopyAs(filename);

                    }

                    finally
                    {
                        // Закрытие книги.
                       // m_workBook.Close(false, "", Type.Missing);
                        // Закрытие приложения Excel.
                       // m_app.Quit();

                        m_workBook = null;
                        m_workSheet = null;
                        m_app = null;
                        GC.Collect();
                    }
                }


            button3.Enabled = true;


        }

        private void button5_Click(object sender, EventArgs e)
        {
           Excel.Workbook m_workBook = null;
           Excel.Worksheet m_workSheet = null;
           Excel._Application m_app = null; 
            
            DateTime date1_w = new DateTime(2014, 1, 1);
            DateTime date2_w = new DateTime(2014, 1, 1);
            string month_str="";

            string conn_str = "Database=resources;Data Source=10.1.1.50;User Id=sa;Password=Rfnfgekmrf48";

            MySqlLib.MySqlData.MySqlExecuteData.MyResultData result = new MySqlLib.MySqlData.MySqlExecuteData.MyResultData();
            
            try
                    {

                        // Создание приложения Excel.
                        m_app = new Microsoft.Office.Interop.Excel.Application();
                        m_app.ReferenceStyle = Excel.XlReferenceStyle.xlA1;
                        // Приложение "невидимо".
                        m_app.Visible = true;
                        // Приложение управляется пользователем.
                        m_app.UserControl = true;
                        // Добавление книги Excel.
                        m_workBook = m_app.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);

                         if (radioButton15.Checked)
                            {
                             DateTime date1_1 = DateTime.Now.AddMonths(-1);
                             date1_w = new DateTime(date1_1.Year, date1_1.Month, 1, 0, 0, 0);

                             date1_1 = DateTime.Now;
                             date2_w = new DateTime(date1_1.Year, date1_1.Month, 1, 0, 0, 0);
                             }
                        // Связь со страницей Excel.

                        m_app.StandardFont = "Calibri";
                        m_app.StandardFontSize = 11;

                        m_workSheet = m_app.ActiveSheet as Excel.Worksheet;

                        m_workSheet.Columns.ColumnWidth = 11.29;

                        m_workSheet.Cells.NumberFormat = "@";

                        m_workSheet.get_Range("A1").ColumnWidth = 23.29;
                        m_workSheet.get_Range("A1").HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                        m_workSheet.get_Range("A1").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                        m_workSheet.get_Range("A1").Font.Bold = true;
                        m_workSheet.Cells[1, 1] = "ОАО \"Аньковское\"";

                        m_workSheet.get_Range("A2").HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                        m_workSheet.get_Range("A2").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                        m_workSheet.get_Range("A2").Font.Bold = true;

                        if (date1_w.Month == 1) { month_str = "Январь";};
                        if (date1_w.Month == 2) { month_str = "Февраль";};
                        if (date1_w.Month == 3) { month_str = "Март";};
                        if (date1_w.Month == 4) { month_str = "Апрель";};
                        if (date1_w.Month == 5) { month_str = "Май";};
                        if (date1_w.Month == 6) { month_str = "Июнь";};
                        if (date1_w.Month == 7) { month_str = "Июль";};
                        if (date1_w.Month == 8) { month_str = "Август";};
                        if (date1_w.Month == 9) { month_str = "Сентябрь";};
                        if (date1_w.Month == 10) { month_str = "Октябрь";};
                        if (date1_w.Month == 11) { month_str = "Ноябрь";};
                        if (date1_w.Month == 12) { month_str = "Декабрь"; };
                        
                        m_workSheet.Cells[2, 1] = "Отчет за потребленную электроэнергию и мощность, " + month_str + " " + date1_w.Year + " г.";


                        m_workSheet.get_Range("A3").HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                        m_workSheet.get_Range("A3").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                        m_workSheet.get_Range("A3").Font.Bold = false;
                        m_workSheet.Cells[3, 1] = "Счетчик №";

                        m_workSheet.get_Range("B3").HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                        m_workSheet.get_Range("B3").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                        m_workSheet.get_Range("B3").Font.Bold = true;
                        m_workSheet.Cells[3, 2] = "335385";

                        m_workSheet.get_Range("A4").HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                        m_workSheet.get_Range("A4").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                        m_workSheet.get_Range("A4").Font.Bold = false;
                        m_workSheet.Cells[4, 1] = "Тр.тока (коэф)";

                        m_workSheet.get_Range("B4").HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                        m_workSheet.get_Range("B4").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                        m_workSheet.get_Range("B4").Font.Bold = true;
                        m_workSheet.Cells[4, 2] = "120";


                        m_workSheet.get_Range("B6").RowHeight = 30;
                        m_workSheet.get_Range("B5", "B6").Merge(System.Type.Missing);
                        m_workSheet.get_Range("B5").WrapText = true;
                        m_workSheet.get_Range("B5").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        m_workSheet.get_Range("B5").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                        m_workSheet.Cells[5, 2] = "Число расчетного месяца";

                        m_workSheet.get_Range("C5", "Z5").Merge(System.Type.Missing);
                        m_workSheet.get_Range("C5").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        m_workSheet.get_Range("C5").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                        m_workSheet.Cells[5, 3] = "Время суток";

                        m_workSheet.get_Range("C6").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        m_workSheet.get_Range("C6").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                        m_workSheet.Cells[6, 3] = "0.00-1.00";
                        
                        m_workSheet.get_Range("D6").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        m_workSheet.get_Range("D6").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                        m_workSheet.Cells[6, 4] = "1.00-2.00";

                        m_workSheet.get_Range("E6").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        m_workSheet.get_Range("E6").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                        m_workSheet.Cells[6, 5] = "2.00-3.00";

                        m_workSheet.get_Range("F6").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        m_workSheet.get_Range("F6").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                        m_workSheet.Cells[6, 6] = "3.00-4.00";

                        m_workSheet.get_Range("G6").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        m_workSheet.get_Range("G6").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                        m_workSheet.Cells[6, 7] = "4.00-5.00";

                        m_workSheet.get_Range("H6").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        m_workSheet.get_Range("H6").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                        m_workSheet.Cells[6, 8] = "5.00-6.00";

                        m_workSheet.get_Range("I6").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        m_workSheet.get_Range("I6").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                        m_workSheet.Cells[6, 9] = "6.00-7.00";
                        
                        m_workSheet.get_Range("J6").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        m_workSheet.get_Range("J6").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                        m_workSheet.Cells[6, 10] = "7.00-8.00";

                        m_workSheet.get_Range("K6").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        m_workSheet.get_Range("K6").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                        m_workSheet.Cells[6, 11] = "8.00-9.00";

                        m_workSheet.get_Range("L6").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        m_workSheet.get_Range("L6").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                        m_workSheet.Cells[6, 12] = "9.00-10.00";

                        m_workSheet.get_Range("M6").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        m_workSheet.get_Range("M6").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                        m_workSheet.Cells[6, 13] = "10.00-11.00";

                        m_workSheet.get_Range("N6").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        m_workSheet.get_Range("N6").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                        m_workSheet.Cells[6, 14] = "11.00-12.00";

                        m_workSheet.get_Range("O6").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        m_workSheet.get_Range("O6").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                        m_workSheet.Cells[6, 15] = "12.00-13.00";

                        m_workSheet.get_Range("P6").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        m_workSheet.get_Range("P6").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                        m_workSheet.Cells[6, 16] = "13.00-14.00";

                        m_workSheet.get_Range("Q6").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        m_workSheet.get_Range("Q6").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                        m_workSheet.Cells[6, 17] = "14.00-15.00";

                        m_workSheet.get_Range("R6").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        m_workSheet.get_Range("R6").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                        m_workSheet.Cells[6, 18] = "15.00-16.00";

                        m_workSheet.get_Range("S6").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        m_workSheet.get_Range("S6").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                        m_workSheet.Cells[6, 19] = "16.00-17.00";

                        m_workSheet.get_Range("T6").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        m_workSheet.get_Range("T6").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                        m_workSheet.Cells[6, 20] = "17.00-18.00";

                        m_workSheet.get_Range("U6").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        m_workSheet.get_Range("U6").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                        m_workSheet.Cells[6, 21] = "18.00-19.00";

                        m_workSheet.get_Range("V6").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        m_workSheet.get_Range("V6").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                        m_workSheet.Cells[6, 22] = "19.00-20.00";

                        m_workSheet.get_Range("W6").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        m_workSheet.get_Range("W6").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                        m_workSheet.Cells[6, 23] = "20.00-21.00";

                        m_workSheet.get_Range("X6").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        m_workSheet.get_Range("X6").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                        m_workSheet.Cells[6, 24] = "21.00-22.00";

                        m_workSheet.get_Range("Y6").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        m_workSheet.get_Range("Y6").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                        m_workSheet.Cells[6, 25] = "22.00-23.00";

                        m_workSheet.get_Range("Z6").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        m_workSheet.get_Range("Z6").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                        m_workSheet.Cells[6, 26] = "23.00-24.00";


                        m_workSheet.get_Range("B7").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        m_workSheet.get_Range("B7").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                        m_workSheet.Cells[7, 2] = "1";

                        m_workSheet.get_Range("B8").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        m_workSheet.get_Range("B8").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                        m_workSheet.Cells[8, 2] = "2";

                        m_workSheet.get_Range("B9").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        m_workSheet.get_Range("B9").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                        m_workSheet.Cells[9, 2] = "3";

                        m_workSheet.get_Range("B10").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        m_workSheet.get_Range("B10").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                        m_workSheet.Cells[10, 2] = "4";

                        m_workSheet.get_Range("B11").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        m_workSheet.get_Range("B11").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                        m_workSheet.Cells[11, 2] = "5";

                        m_workSheet.get_Range("B12").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        m_workSheet.get_Range("B12").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                        m_workSheet.Cells[12, 2] = "6";

                        m_workSheet.get_Range("B13").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        m_workSheet.get_Range("B13").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                        m_workSheet.Cells[13, 2] = "7";

                        m_workSheet.get_Range("B14").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        m_workSheet.get_Range("B14").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                        m_workSheet.Cells[14, 2] = "8";

                        m_workSheet.get_Range("B15").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        m_workSheet.get_Range("B15").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                        m_workSheet.Cells[15, 2] = "9";

                        m_workSheet.get_Range("B16").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        m_workSheet.get_Range("B16").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                        m_workSheet.Cells[16, 2] = "10";

                        m_workSheet.get_Range("B17").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        m_workSheet.get_Range("B17").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                        m_workSheet.Cells[17, 2] = "11";

                        m_workSheet.get_Range("B18").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        m_workSheet.get_Range("B18").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                        m_workSheet.Cells[18, 2] = "12";

                        m_workSheet.get_Range("B19").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        m_workSheet.get_Range("B19").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                        m_workSheet.Cells[19, 2] = "13";

                        m_workSheet.get_Range("B20").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        m_workSheet.get_Range("B20").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                        m_workSheet.Cells[20, 2] = "14";

                        m_workSheet.get_Range("B21").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        m_workSheet.get_Range("B21").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                        m_workSheet.Cells[21, 2] = "15";

                        m_workSheet.get_Range("B22").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        m_workSheet.get_Range("B22").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                        m_workSheet.Cells[22, 2] = "16";

                        m_workSheet.get_Range("B23").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        m_workSheet.get_Range("B23").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                        m_workSheet.Cells[23, 2] = "17";

                        m_workSheet.get_Range("B24").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        m_workSheet.get_Range("B24").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                        m_workSheet.Cells[24, 2] = "18";

                        m_workSheet.get_Range("B25").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        m_workSheet.get_Range("B25").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                        m_workSheet.Cells[25, 2] = "19";

                        m_workSheet.get_Range("B26").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        m_workSheet.get_Range("B26").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                        m_workSheet.Cells[26, 2] = "20";

                        m_workSheet.get_Range("B27").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        m_workSheet.get_Range("B27").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                        m_workSheet.Cells[27, 2] = "21";

                        m_workSheet.get_Range("B28").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        m_workSheet.get_Range("B28").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                        m_workSheet.Cells[28, 2] = "22";

                        m_workSheet.get_Range("B29").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        m_workSheet.get_Range("B29").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                        m_workSheet.Cells[29, 2] = "23";

                        m_workSheet.get_Range("B30").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        m_workSheet.get_Range("B30").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                        m_workSheet.Cells[30, 2] = "24";

                        m_workSheet.get_Range("B31").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        m_workSheet.get_Range("B31").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                        m_workSheet.Cells[31, 2] = "25";

                        m_workSheet.get_Range("B32").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        m_workSheet.get_Range("B32").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                        m_workSheet.Cells[32, 2] = "26";

                        m_workSheet.get_Range("B33").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        m_workSheet.get_Range("B33").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                        m_workSheet.Cells[33, 2] = "27";

                        m_workSheet.get_Range("B34").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        m_workSheet.get_Range("B34").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                        m_workSheet.Cells[34, 2] = "28";

                        m_workSheet.get_Range("B35").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        m_workSheet.get_Range("B35").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                        m_workSheet.Cells[35, 2] = "29";

                        m_workSheet.get_Range("B36").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        m_workSheet.get_Range("B36").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                        m_workSheet.Cells[36, 2] = "30";

                        m_workSheet.get_Range("B37").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        m_workSheet.get_Range("B37").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                        m_workSheet.Cells[37, 2] = "31";

                        TimeSpan interval_w = date2_w - date1_w;
                        decimal fl1 = 0;
                        string date_sql = ""; 

                        for (int k = 0; k <= (interval_w.Days - 1); k++)
                        {
                            for (int j = 1; j <= 24; j++)
                            {
                                date1_w = date1_w.AddMinutes(30);

                                date_sql = date1_w.Year + "-" + date1_w.Month + "-" + date1_w.Day + " " + date1_w.Hour + ":" + date1_w.Minute + ":00";
                                result = MySqlLib.MySqlData.MySqlExecuteData.SqlReturnDataset("SELECT * FROM resources.electro55 where electro55_datetime = '" + date_sql + "' LIMIT 0,1", conn_str);
                                fl1 = Convert.ToDecimal(result.ResultData.DefaultView.Table.Rows[0]["electro55_active"].ToString());

                            }

                        }
                        



             }

                    finally
                    {
                        // Закрытие книги.
                       // m_workBook.Close(false, "", Type.Missing);
                        // Закрытие приложения Excel.
                       // m_app.Quit();

                        m_workBook = null;
                        m_workSheet = null;
                        m_app = null;
                        GC.Collect();
                    }
                
        }





        }
    }






namespace MySqlLib
{
    /// <summary>
    /// Набор компонент для простой работы с MySQL базой данных.
    /// </summary>
    public class MySqlData
    {

        /// <summary>
        /// Методы реализующие выполнение запросов с возвращением одного параметра либо без параметров вовсе.
        /// </summary>
        public class MySqlExecute
        {

            /// <summary>
            /// Возвращаемый набор данных.
            /// </summary>
            public class MyResult
            {
                /// <summary>
                /// Возвращает результат запроса.
                /// </summary>
                public string ResultText;
                /// <summary>
                /// Возвращает True - если произошла ошибка.
                /// </summary>
                public string ErrorText;
                /// <summary>
                /// Возвращает текст ошибки.
                /// </summary>
                public bool HasError;
            }

            /// <summary>
            /// Для выполнения запросов к MySQL с возвращением 1 параметра.
            /// </summary>
            /// <param name="sql">Текст запроса к базе данных</param>
            /// <param name="connection">Строка подключения к базе данных</param>
            /// <returns>Возвращает значение при успешном выполнении запроса, текст ошибки - при ошибке.</returns>
            public static MyResult SqlScalar(string sql, string connection)
            {
                MyResult result = new MyResult();
                try
                {
                    MySql.Data.MySqlClient.MySqlConnection connRC = new MySql.Data.MySqlClient.MySqlConnection(connection);
                    MySql.Data.MySqlClient.MySqlCommand commRC = new MySql.Data.MySqlClient.MySqlCommand(sql, connRC);
                    connRC.Open();
                    try
                    {
                        result.ResultText = commRC.ExecuteScalar().ToString();
                        result.HasError = false;
                    }
                    catch (Exception ex)
                    {
                        result.ErrorText = ex.Message;
                        result.HasError = true;

                    }
                    connRC.Close();
                }
                catch (Exception ex)//Этот эксепшн на случай отсутствия соединения с сервером.
                {
                    result.ErrorText = ex.Message;
                    result.HasError = true;
                }
                return result;
            }


            /// <summary>
            /// Для выполнения запросов к MySQL без возвращения параметров.
            /// </summary>
            /// <param name="sql">Текст запроса к базе данных</param>
            /// <param name="connection">Строка подключения к базе данных</param>
            /// <returns>Возвращает True - ошибка или False - выполнено успешно.</returns>
            public static MyResult SqlNoneQuery(string sql, string connection)
            {
                MyResult result = new MyResult();
                try
                {
                    MySql.Data.MySqlClient.MySqlConnection connRC = new MySql.Data.MySqlClient.MySqlConnection(connection);
                    MySql.Data.MySqlClient.MySqlCommand commRC = new MySql.Data.MySqlClient.MySqlCommand(sql, connRC);
                    connRC.Open();
                    try
                    {
                        commRC.ExecuteNonQuery();
                        result.HasError = false;
                    }
                    catch (Exception ex)
                    {
                        result.ErrorText = ex.Message;
                        result.HasError = true;
                    }
                    connRC.Close();
                }
                catch (Exception ex)//Этот эксепшн на случай отсутствия соединения с сервером.
                {
                    result.ErrorText = ex.Message;
                    result.HasError = true;
                }
                return result;
            }

        }
        /// <summary>
        /// Методы реализующие выполнение запросов с возвращением набора данных.
        /// </summary>
        public class MySqlExecuteData
        {
            /// <summary>
            /// Возвращаемый набор данных.
            /// </summary>
            public class MyResultData
            {
                /// <summary>
                /// Возвращает результат запроса.
                /// </summary>
                public DataTable ResultData;
                /// <summary>
                /// Возвращает True - если произошла ошибка.
                /// </summary>
                public string ErrorText;
                /// <summary>
                /// Возвращает текст ошибки.
                /// </summary>
                public bool HasError;
            }
            /// <summary>
            /// Выполняет запрос выборки набора строк.
            /// </summary>
            /// <param name="sql">Текст запроса к базе данных</param>
            /// <param name="connection">Строка подключения к базе данных</param>
            /// <returns>Возвращает набор строк в DataSet.</returns>
            public static MyResultData SqlReturnDataset(string sql, string connection)
            {
                MyResultData result = new MyResultData();
                try
                {
                    MySql.Data.MySqlClient.MySqlConnection connRC = new MySql.Data.MySqlClient.MySqlConnection(connection);
                    MySql.Data.MySqlClient.MySqlCommand commRC = new MySql.Data.MySqlClient.MySqlCommand(sql, connRC);
                    connRC.Open();
                    try
                    {
                        MySql.Data.MySqlClient.MySqlDataAdapter AdapterP = new MySql.Data.MySqlClient.MySqlDataAdapter();
                        AdapterP.SelectCommand = commRC;
                        DataSet ds1 = new DataSet();
                        AdapterP.Fill(ds1);
                        result.ResultData = ds1.Tables[0];
                    }
                    catch (Exception ex)
                    {
                        result.HasError = true;
                        result.ErrorText = ex.Message;
                    }
                    connRC.Close();
                }
                catch (Exception ex)//Этот эксепшн на случай отсутствия соединения с сервером.
                {
                    result.ErrorText = ex.Message;
                    result.HasError = true;
                }
                return result;
            }
        }
    }
}


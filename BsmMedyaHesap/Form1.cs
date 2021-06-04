using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BsmMedyaHesap
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //temizle butonu
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "" || textBox2.Text != "" || textBox3.Text != "" || textBox4.Text != "" || comboBox1.Text != ""
                                || radioButton1.Checked == true || radioButton2.Checked == true || radioButton3.Checked == true
                                || checkBox1.Checked == true || checkBox2.Checked == true || checkBox3.Checked == true)
                {
                    foreach (Control item in this.Controls)
                    {
                        if (item is TextBox)
                        {
                            TextBox tbox = (TextBox)item;
                            tbox.Clear();
                        }
                        if (item is RadioButton)
                        {
                            RadioButton tbox = (RadioButton)item;
                            tbox.Checked = false;
                        }
                        if (item is CheckBox)
                        {
                            CheckBox tbox = (CheckBox)item;
                            tbox.Checked = false;
                        }
                        if (item is ComboBox)
                        {
                            ComboBox tbox = (ComboBox)item;
                            tbox.Text = "";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                label11.Text = ex.Message + "Temizle fonksiyonu hatası!";
                //throw;
            }
        }
        //hesapla kodları
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                double kdvfiyat=0;
                double alisfiyati, kargofiyati, komisyonfiyati, kdvodenen=0;
                //komisyon tl
                double komistontl = Convert.ToDouble(textBox1.Text) * Convert.ToDouble(textBox3.Text) / 100;

                //kdv kodları
                if (radioButton3.Checked == true) //%1 
                {
                    kdvfiyat = Convert.ToDouble(textBox1.Text) / (1 + 0.01) * 0.01;
                    alisfiyati = Convert.ToDouble(textBox2.Text) / (1 + 0.01) * 0.01;
                    kargofiyati = Convert.ToDouble(textBox4.Text) / (1 + 0.18) * 0.18;
                    komisyonfiyati = komistontl / (1 + 0.18) * 0.18;
                    kdvodenen = alisfiyati + kargofiyati + komisyonfiyati;
                }
                if (radioButton1.Checked == true)//%8
                {
                    kdvfiyat = Convert.ToDouble(textBox1.Text) / (1 + 0.08) * 0.08;
                    alisfiyati = Convert.ToDouble(textBox2.Text) / (1 + 0.08) * 0.08;
                    kargofiyati = Convert.ToDouble(textBox4.Text) / (1 + 0.18) * 0.18;
                    komisyonfiyati = komistontl / (1 + 0.18) * 0.18;
                    kdvodenen = alisfiyati + kargofiyati + komisyonfiyati;
                }
                if (radioButton2.Checked == true)//%18
                {
                    kdvfiyat = Convert.ToDouble(textBox1.Text) / (1 + 0.18) * 0.18;
                    alisfiyati = Convert.ToDouble(textBox2.Text) / (1 + 0.18) * 0.18;
                    kargofiyati = Convert.ToDouble(textBox4.Text) / (1 + 0.18) * 0.18;
                    komisyonfiyati = komistontl / (1 + 0.18) * 0.18;
                    kdvodenen = alisfiyati + kargofiyati + komisyonfiyati;
                }

                //sade işlemler
                //mailyet
                double maliyettl = Convert.ToDouble(textBox2.Text) + Convert.ToDouble(textBox4.Text) + komistontl;
                //kar oran hesabı kdvsiz
                double kar = Convert.ToDouble(textBox1.Text) - maliyettl;
                double karorani = (kar / Convert.ToDouble(textBox1.Text)) * 100;

                label7.Text = kar.ToString() + "TL - %" + karorani.ToString();

                double kdvfarki = kdvodenen-kdvfiyat;
                double kdvlikar = kar + kdvfarki;
                double kdvkarorani = (kdvlikar / Convert.ToDouble(textBox1.Text)) * 100;
                label10.Text = kdvlikar.ToString()+"TL -%"+kdvkarorani.ToString(); //kar kdv

                //double kdvhesap = Convert.ToInt32(textBox1.Text) - kdvfiyat;

                //double kdvodenen = (Convert.ToDouble(textBox2.Text) / kdvfiyat) + (Convert.ToDouble(textBox4.Text) / kdvfiyat) + (komistontl / kdvfiyat);
                //double kdvalinan = Convert.ToDouble(textBox1.Text) / kdvfiyat;
                //double kdvfarki = kdvodenen - kdvalinan;

                //double satisfiyat = Convert.ToDouble(textBox1.Text) - kdvfiyat;
                //kdv ödenen

                //label10.Text = kdvodenen.ToString();


                //kdv ve alis fiyati cikmis hali
                //double aliscikincakalanpara = satisfiyati - Convert.ToDouble(textBox2.Text);
                //kdv alis ve komisyon dusmus hali
                //double komisyondusmushali = aliscikincakalanpara - (aliscikincakalanpara * Convert.ToDouble(textBox3.Text) / 100);
                //kdv alis komisyon ve kargo cikmis hali
                //double kargofiyaticikmishali = komisyondusmushali - Convert.ToDouble(textBox4.Text);

            }
            catch (Exception)
            {
                MessageBox.Show("BOŞ YERLERİ DOLDURUNUZ!");
                //throw;
            }
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            double[] kargofiyatdizisi = new double[477]{ 11.51, 11.51, 12.39, 12.98, 14.16, 14.75,
15.34,
15.93,
17.70,
18.88,
20.06,
20.65,
21.83,
23.01,
23.60,
25.96,
27.73,
30.09,
31.27,
33.04,
34.81,
36.58,
38.35,
40.12,
42.48,
44.25,
45.43,
47.20,
48.97,
51.33,
52.51,
53.69,
55.46,
57.23,
59.00,
60.77,
62.54,
63.72,
65.49,
67.26,
69.03,
70.80,
72.57,
74.34,
75.52,
77.29,
79.06,
80.83,
82.60,
84.37,
85.55,
87.32,
89.09,
90.86,
92.63,
94.40,
95.58,
97.35,
99.12,
100.89,
102.66,
104.43,
106.20,
107.38,
109.15,
110.92,
112.69,
114.46,
116.23,
117.41,
119.18,
120.95,
122.72,
124.49,
126.26,
127.44,
129.21,
130.98,
132.75,
134.52,
136.29,
138.06,
139.24,
141.01,
142.78,
144.55,
146.32,
148.09,
149.27,
151.04,
152.81,
154.58,
156.35,
158.12,
159.30,
161.07,
162.84,
164.61,
166.38,
168.15,
169.92,
171.10,
172.87,
174.64,
176.41,
177.59,
179.36,
181.13,
182.90,
184.08,
185.85,
187.62,
189.39,
191.16,
192.34,
194.11,
195.88,
197.65,
198.83,
200.60,
202.37,
204.14,
205.91,
207.09,
208.86,
210.63,
212.40,
213.58,
215.35,
217.12,
218.89,
220.66,
221.84,
223.61,
225.38,
227.15,
228.33,
230.10,
231.87,
233.64,
235.41,
236.59,
238.36,
240.13,
241.90,
243.08,
244.85,
246.62,
248.39,
250.16,
251.34,
253.11,
254.88,
256.65,
257.83,
259.60,
261.37,
263.14,
264.91,
266.09,
267.86,
269.63,
271.40,
272.58,
274.35,
276.12,
277.89,
279.66,
280.84,
282.61,
284.38,
286.15,
287.33,
289.10,
290.87,
292.64,
294.41,
295.59,
297.36,
299.13,
300.90,
302.08,
303.85,
305.62,
307.39,
308.57,
310.34,
312.11,
313.88,
315.65,
316.83,
318.60,
320.37,
322.14,
323.32,
325.09,
326.86,
328.63,
330.40,
331.58,
333.35,
335.12,
336.89,
338.07,
339.84,
341.61,
343.38,
345.15,
346.33,
348.10,
349.87,
351.64,
352.82,
354.59,
356.36,
358.13,
359.90,
361.08,
362.85,
364.62,
366.39,
367.57,
369.34,
371.11,
372.88,
374.65,
375.83,
377.60,
379.37,
381.14,
382.32,
384.09,
385.86,
387.63,
389.40,
390.58,
392.35,
394.12,
395.89,
397.07,
398.84,
400.61,
402.38,
404.15,
405.33,
407.10,
408.87,
410.64,
411.82,
413.59,
415.36,
417.13,
418.90,
420.08,
421.85,
423.62,
425.39,
426.57,
428.34,
430.11,
431.88,
433.06,
434.83,
436.60,
438.37,
440.14,
441.32,
443.09,
444.86,
446.63,
447.81,
449.58,
451.35,
453.12,
454.89,
456.07,
457.84,
459.61,
461.38,
462.56,
464.33,
466.10,
467.87,
469.64,
470.82,
472.59,
474.36,
476.13,
477.31,
479.08,
480.85,
482.62,
484.39,
485.57,
487.34,
489.11,
490.88,
492.06,
493.83,
495.60,
497.37,
499.14,
500.32,
502.09,
503.86,
505.63,
506.81,
508.58,
510.35,
512.12,
513.89,
515.07,
516.84,
518.61,
520.38,
521.56,
523.33,
525.10,
526.87,
528.64,
529.82,
531.59,
533.36,
535.13,
536.31,
538.08,
539.85,
541.62,
542.80,
544.57,
546.34,
548.11,
549.88,
551.06,
552.83,
554.60,
556.37,
557.55,
559.32,
561.09,
562.86,
564.63,
565.81,
567.58,
569.35,
571.12,
572.30,
574.07,
575.84,
577.61,
579.38,
580.56,
582.33,
584.10,
585.87,
587.05,
588.82,
590.59,
592.36,
594.13,
595.31,
597.08,
598.85,
600.62,
601.80,
603.57,
605.34,
607.11,
608.88,
610.06,
611.83,
613.60,
615.37,
616.55,
618.32,
620.09,
621.86,
623.63,
624.81,
626.58,
628.35,
630.12,
631.30,
633.07,
634.84,
636.61,
638.38,
639.56,
641.33,
643.10,
644.87,
646.05,
647.82,
649.59,
651.36,
653.13,
654.31,
656.08,
657.85,
659.62,
660.80,
662.57,
664.34,
666.11,
667.29,
669.06,
670.83,
672.60,
674.37,
675.55,
677.32,
679.09,
680.86,
682.04,
683.81,
685.58,
687.35,
689.12,
690.30,
692.07,
693.84,
695.61,
696.79,
698.56,
700.33,
702.10,
703.87,
705.05,
706.82,
708.59,
710.36,
711.54,
713.31,
715.08,
716.85,
718.62,
719.80,
721.57,
723.34,
725.11,
726.29,
728.06,
729.83,
731.60,
733.37,
734.55,
736.32,
738.09,
739.86,
741.04,
742.81,
744.58,
746.35,
748.12,
749.30,
751.07,
752.84,
754.61,
755.79,
757.56,
759.33,
761.10,
762.87,
764.05,
765.82,
767.59,
769.36,
770.54,
772.31,
774.08,
775.85,
777.03,
778.80,
780.57,
782.34,
784.11,
785.29,
}; //+1 cunku sifirdan basliyor - desi
            try
            {
                for (int i = 0; i <= 476; i++)
                {
                    comboBox1.Items.Add(i); //combobox desi ekle
                                            //index sayısı cmb ye eşit olduğunda yakala ve ekrana ver
                    if (comboBox1.SelectedIndex == i )
                    {
                        textBox4.Text = Convert.ToString(kargofiyatdizisi[i]);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("KARGO ÜCRETİ KISMINI KONTROL EDİN!");
                //throw;
            }
            
        }

        //checkbox kargo ucreti sabit
        private void checkBox1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(textBox1.Text) <= 19.99)
                {
                    if (checkBox1.Checked == true)
                    {
                        double deger1 = Convert.ToDouble(2.99);
                        textBox4.Text = deger1.ToString();
                    }
                    if (checkBox1.Checked == false)
                    {
                        textBox4.Text = "";
                    }
                }
                else
                {
                    checkBox1.Checked = false;
                    MessageBox.Show("SATIŞ FİYATI 19.99 TL ALTI DEĞİL!");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("SATIŞ FİYATI GİRİNİZ!");
                //throw;
            }
            
        }

        private void checkBox2_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(textBox1.Text) <= 29.99 && Convert.ToInt32(textBox1.Text) > 20)
                {
                    if (checkBox2.Checked == true)
                    {
                        double deger2 = Convert.ToDouble(4.48);
                        textBox4.Text = deger2.ToString();
                    }
                    if (checkBox2.Checked == false)
                    {
                        textBox4.Text = "";
                    }
                }
                else
                {
                    checkBox2.Checked = false;
                    MessageBox.Show("SATIŞ FİYATI 20 TL ÜSTÜ ve 29.99 TL ALTI DEĞİL!");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("SATIŞ FİYATI GİRİNİZ!");
                //throw;
            }
            
        }

        private void checkBox3_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(textBox1.Text) > 30 && Convert.ToInt32(textBox1.Text) < 49.99)
                {
                    if (checkBox3.Checked == true)
                    {
                        double deger3 = Convert.ToDouble(8.26);
                        textBox4.Text = deger3.ToString();
                    }
                    if (checkBox3.Checked == false)
                    {
                        textBox4.Text = "";
                    }
                }
                else
                {
                    checkBox3.Checked = false;
                    MessageBox.Show("SATIŞ FİYATI 30 TL ÜSTÜ ve 49.99 TL ALTI DEĞİL!");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("SATIŞ FİYATI GİRİNİZ!");
                //throw;
            }
            
        }

        //fare hareketini yakala
        private void Form1_MouseCaptureChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(textBox1.Text) <= 19.99)
                {
                    double deger1 = Convert.ToDouble(2.99);
                    textBox4.Text = deger1.ToString();
                }
                if (Convert.ToInt32(textBox1.Text) <= 29.99 && Convert.ToInt32(textBox1.Text) > 20)
                {
                    double deger2 = Convert.ToDouble(4.48);
                    textBox4.Text = deger2.ToString();
                }
                if (Convert.ToInt32(textBox1.Text) > 30 && Convert.ToInt32(textBox1.Text) < 49.99)
                {
                    double deger3 = Convert.ToDouble(8.26);
                    textBox4.Text = deger3.ToString();
                }
            }
            catch (Exception ex)
            {
                label11.Text = ex.Message+" mouse_capture hatasi!";
                //throw;
            }
        }
    }
}


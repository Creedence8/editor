using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml; 

namespace editor
{
    public partial class Form1 : Form
    {
        List<events> eventslist = new List<events>();
        List<intervals> intervalslist = new List<intervals>();
        List<rules> ruleslist = new List<rules>();
        string file="" ;
         string fileR = "";

        public void load ()
        {
            int i = 0;
            int j = 0;
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(file );
            XmlElement xRoot = xDoc.DocumentElement;

            
            XmlNodeList childnodes = xRoot.SelectNodes("//Interval"); 
            
            foreach (XmlNode n in childnodes)
            {
                
                intervalslist.Add(new intervals() );
                intervalslist[i].name = n.SelectSingleNode("@Name").Value;
                XmlNode childnodes2 = n.FirstChild;
                if (childnodes2 != null)
                {
                    if (childnodes2.FirstChild.Name != "LogOp")
                    {
                        XmlNodeList aq = childnodes2.SelectNodes("*");
                        foreach (XmlNode a in aq)
                        {
                            intervalslist[i].qa.Add(new prop());
                            intervalslist[i].qa[j].EqOp1 = a.SelectSingleNode("@Value").Value;
                            XmlNode b = a.FirstChild;
                            XmlNode c = a.LastChild;
                            intervalslist[i].qa[j].Attribute = b.SelectSingleNode("@Value").Value;
                            intervalslist[i].qa[j].info = c.SelectSingleNode("@Value").Value;
                            intervalslist[i].qa[j].flag = "Open";
                            j += 1;
                        }
                    }
                    else
                    {
                        XmlNodeList aq = childnodes2.FirstChild .SelectNodes("*");
                        foreach (XmlNode a in aq)
                        {
                            intervalslist[i].qa.Add(new prop());
                            intervalslist[i].qa[j].EqOp1 = a.SelectSingleNode("@Value").Value;
                            XmlNode b = a.FirstChild;
                            XmlNode c = a.LastChild;
                            intervalslist[i].qa[j].Attribute = b.SelectSingleNode("@Value").Value;
                            intervalslist[i].qa[j].info = c.SelectSingleNode("@Value").Value;
                            intervalslist[i].qa[j].flag = "Open";
                            intervalslist[i].qa[j].logop = childnodes2.FirstChild.SelectSingleNode("@Value").Value;
                            j += 1;
                        }
                    }
                }
                
                XmlNode childnodes3 = n.LastChild;
                if (childnodes3 != null)
                {
                    if (childnodes3.FirstChild.Name != "LogOp")
                    {
                        XmlNodeList aq = childnodes3.SelectNodes("*");
                        foreach (XmlNode a in aq)
                        {
                            intervalslist[i].qa.Add(new prop());
                            intervalslist[i].qa[j].EqOp1 = a.SelectSingleNode("@Value").Value;
                            XmlNode b = a.FirstChild;
                            XmlNode c = a.LastChild;
                            intervalslist[i].qa[j].Attribute = b.SelectSingleNode("@Value").Value;
                            intervalslist[i].qa[j].info = c.SelectSingleNode("@Value").Value;
                            intervalslist[i].qa[j].flag = "Close";
                            j += 1;
                        }
                    }
                    else
                    {
                        XmlNodeList aq = childnodes3.FirstChild.SelectNodes("*");
                        foreach (XmlNode a in aq)
                        {
                            intervalslist[i].qa.Add(new prop());
                            intervalslist[i].qa[j].EqOp1 = a.SelectSingleNode("@Value").Value;
                            XmlNode b = a.FirstChild;
                            XmlNode c = a.LastChild;
                            intervalslist[i].qa[j].Attribute = b.SelectSingleNode("@Value").Value;
                            intervalslist[i].qa[j].info = c.SelectSingleNode("@Value").Value;
                            intervalslist[i].qa[j].flag = "Close";
                            intervalslist[i].qa[j].logop = childnodes2.FirstChild.SelectSingleNode("@Value").Value;
                            j += 1;
                        }
                    }
                }
                comboBox1.Items.Add(intervalslist[i].name );
                comboBox3.Items.Add(intervalslist[i].name);
                comboBox5.Items.Add(intervalslist[i].name);
                i += 1;
                j = 0;
            }
            i = 0;
           
            XmlNodeList childnodesev = xRoot.SelectNodes("//Event");

            foreach (XmlNode n in childnodesev)
            {
                j = 0;
                eventslist.Add(new events());
                eventslist[i].name = n.SelectSingleNode("@Name").Value;        
                XmlNode childnodes2 = n.FirstChild ;
                if (childnodes2.FirstChild.Name != "LogOp")
                {
                    XmlNodeList a = childnodes2.SelectNodes("*");
                    foreach (XmlNode aq in a)
                    {
                        eventslist[i].qa.Add(new prop());
                        eventslist[i].qa[j].EqOp1 = aq.SelectSingleNode("@Value").Value;
                        XmlNode b = aq.FirstChild;
                        XmlNode c = aq.LastChild;
                        eventslist[i].qa[j].Attribute = b.SelectSingleNode("@Value").Value;
                        eventslist[i].qa[j].info = c.SelectSingleNode("@Value").Value;
                        j += 1;
                    }
                }
                else
                {
                    XmlNodeList a = childnodes2.FirstChild.SelectNodes("*");
                    foreach (XmlNode aq in a)
                    {
                        eventslist[i].qa.Add(new prop());
                        eventslist[i].qa[j].EqOp1 = aq.SelectSingleNode("@Value").Value;
                        XmlNode b = aq.FirstChild;
                        XmlNode c = aq.LastChild;
                        eventslist[i].qa[j].Attribute = b.SelectSingleNode("@Value").Value;
                        eventslist[i].qa[j].info = c.SelectSingleNode("@Value").Value;
                        eventslist[i].qa[j].logop = childnodes2.FirstChild.SelectSingleNode("@Value").Value;
                        j += 1;
                    }
                }
                comboBox2.Items.Add(eventslist[i].name);
                i += 1;
            }

            
        }

        public void loadR()
        {   
            int i=0;
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(fileR);
            XmlElement xRoot = xDoc.DocumentElement;
            XmlNodeList childnodes = xRoot.SelectNodes("//Rule"); 

            foreach (XmlNode xn in childnodes )
            {
                ruleslist.Add(new rules());
                ruleslist[i].name = xn.SelectSingleNode("@Name").Value;
                ruleslist[i].general = xn.SelectSingleNode("@General").Value;
                ruleslist[i].type = xn.SelectSingleNode("@Type").Value;
                XmlNode childnodes2 = xn.FirstChild;
                XmlNode childnodes3 = childnodes2.FirstChild;
                ruleslist [i].rul .Add (new prop());
                ruleslist[i].rul[0].logop = childnodes3.SelectSingleNode("@Value").Value;
                XmlNode cn4 = childnodes3.FirstChild;
                ruleslist[i].rul[0].EqOp1 = cn4.SelectSingleNode("@Value").Value;
                XmlNode cn5 = cn4.FirstChild;
                XmlNode cn6 = cn4.LastChild;
                ruleslist[i].rul[0].Attribute = cn5.SelectSingleNode("@Value").Value;
                ruleslist[i].rul[0].info  = cn6.SelectSingleNode("@Value").Value;
                XmlNode cn7 = childnodes3.LastChild;
                ruleslist[i].alop = cn7.SelectSingleNode("@Value").Value;
                XmlNode cn8 = cn7.FirstChild;
                XmlNode cn9 = cn7.LastChild;
                ruleslist[i].inter1  = cn8.SelectSingleNode("@Value").Value;
                ruleslist[i].inter2 = cn9.SelectSingleNode("@Value").Value;
                XmlNode cn10 = xn.LastChild;
                XmlNode cn11 = cn10.LastChild;
                ruleslist [i].rul .Add (new prop());
                ruleslist[i].rul[1].Attribute = cn11.SelectSingleNode("@Attribute").Value;
                ruleslist[i].rul[1].info  = cn11.SelectSingleNode("@Value").Value;
                comboBox4.Items.Add(ruleslist[i].name);
                i++;
            }
 
        }

        public void delete()
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(file);
            XmlElement xRoot = xDoc.DocumentElement;
            XmlNodeList childnodes = xRoot.SelectNodes("//Interval");
            if (childnodes.Count >0 )
            {
                foreach (XmlNode n in childnodes)
                {
                    if (lt1.Text == n.SelectSingleNode("@Name").Value)
                    {
                        n.ParentNode.RemoveChild(n);
                        xDoc.Save(file);
                        return;
                    }
                }
            }

            XmlNodeList childnodesev = xRoot.SelectNodes("//Event");
            if (childnodesev.Count>0)
            {
                foreach (XmlNode n in childnodesev)
                {
                    if (lt1.Text == n.SelectSingleNode("@Name").Value)
                    {
                        n.ParentNode.RemoveChild(n);
                        xDoc.Save(file);
                        break;
                    }
                }
            }
        }

        public void deleteR()
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(fileR);
            XmlElement xRoot = xDoc.DocumentElement;
            XmlNodeList childnodes = xRoot.SelectNodes("//Rule");
            if (childnodes.Count > 0)
            {
                foreach (XmlNode n in childnodes)
                {
                    if (tr2.Text == n.SelectSingleNode("@Name").Value)
                    {
                        n.ParentNode.RemoveChild(n);
                        xDoc.Save(fileR);
                        return;
                    }
                }
            }
        }

        public void add()
        {
            if (file == "")
            { return; }
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(file);
            XmlElement xRoot = xDoc.DocumentElement;
            if (name1.Text!="")
            {
                //работаем с интервалами
                XmlElement intElem = xDoc.CreateElement("Interval");
                XmlAttribute nameAttr = xDoc.CreateAttribute("Name");
                XmlElement openElem = xDoc.CreateElement("Open");
                XmlElement lElem = xDoc.CreateElement("LogOp");
                XmlElement eqopElem = xDoc.CreateElement("EqOp");
                XmlAttribute veAttr = xDoc.CreateAttribute("Value");
                XmlAttribute lAttr = xDoc.CreateAttribute("Value");
                XmlAttribute vaAttr = xDoc.CreateAttribute("Value");
                XmlAttribute vsAttr = xDoc.CreateAttribute("Value");
                XmlElement atElem = xDoc.CreateElement("Attribute");
                XmlElement stElem = xDoc.CreateElement("String");
                XmlElement closeElem = xDoc.CreateElement("Close");
                XmlElement eqop2Elem = xDoc.CreateElement("EqOp");
                XmlAttribute ve2Attr = xDoc.CreateAttribute("Value");
                XmlAttribute va2Attr = xDoc.CreateAttribute("Value");
                XmlAttribute vs2Attr = xDoc.CreateAttribute("Value");
                XmlElement at2Elem = xDoc.CreateElement("Attribute");
                XmlElement st2Elem = xDoc.CreateElement("String");
                XmlText nameText = xDoc.CreateTextNode(name1 .Text );
                XmlText eqText = xDoc.CreateTextNode(eqop1 .Text );
                XmlText atText = xDoc.CreateTextNode(atr1.Text );
                XmlText stText = xDoc.CreateTextNode(string1.Text );
                XmlText eq1Text = xDoc.CreateTextNode(eqop12.Text );
                XmlText at1Text = xDoc.CreateTextNode(atr12 .Text );
                XmlText st1Text = xDoc.CreateTextNode(string12.Text );
                nameAttr.AppendChild(nameText);
                veAttr.AppendChild(eqText);
                vaAttr.AppendChild(atText);
                vsAttr.AppendChild(stText);
                ve2Attr.AppendChild(eq1Text);
                va2Attr.AppendChild(at1Text);
                vs2Attr.AppendChild(st1Text);
                intElem.Attributes.Append(nameAttr);
                intElem.AppendChild(openElem );
                openElem.AppendChild(eqopElem);
                eqopElem.Attributes.Append(veAttr);
                eqopElem.AppendChild(atElem);
                eqopElem.AppendChild(stElem );
                atElem.Attributes.Append(vaAttr);
                stElem.Attributes.Append(vsAttr);
                intElem.AppendChild(closeElem );
                closeElem.AppendChild(eqop2Elem);
                eqop2Elem.Attributes.Append(ve2Attr);
                eqop2Elem.AppendChild(at2Elem);
                eqop2Elem.AppendChild(st2Elem);
                at2Elem.Attributes.Append(va2Attr);
                st2Elem.Attributes.Append(vs2Attr);
                xRoot.FirstChild.AppendChild(intElem);
                xDoc.Save(file);

            }
            if (name2.Text != "")
            {
                //работаем с событиями
                XmlElement eventElem = xDoc.CreateElement("Event");
                XmlElement formulaElem = xDoc.CreateElement("Formula");
                XmlElement eqopElem = xDoc.CreateElement("EqOp");
                XmlElement atrElem = xDoc.CreateElement("Attribute");
                XmlElement numberElem = xDoc.CreateElement("Number");
                XmlAttribute nameAttr = xDoc.CreateAttribute("Name");
                XmlAttribute eqopAttr = xDoc.CreateAttribute("Value");
                XmlAttribute atrAttr = xDoc.CreateAttribute("Value");
                XmlAttribute numAttr = xDoc.CreateAttribute("Value");
                XmlText nameText = xDoc.CreateTextNode(name2.Text);
                XmlText eqopText = xDoc.CreateTextNode(eqop2.Text);
                XmlText atrText = xDoc.CreateTextNode(atr2.Text);
                XmlText numText = xDoc.CreateTextNode(num.Text);
                nameAttr.AppendChild(nameText);
                eqopAttr.AppendChild(eqopText);
                atrAttr.AppendChild(atrText);
                numAttr.AppendChild(numText);
                eventElem.Attributes.Append(nameAttr);
                eventElem.AppendChild(formulaElem);
                formulaElem.AppendChild(eqopElem);
                eqopElem.Attributes.Append(eqopAttr);
                eqopElem.AppendChild(atrElem);
                eqopElem.AppendChild(numberElem);
                atrElem.Attributes.Append(atrAttr);
                numberElem.Attributes.Append(numAttr);
                xRoot.LastChild.AppendChild(eventElem);
                xDoc.Save(file);


            }
            name1.Text = name2.Text = eqop1.Text = eqop12.Text = eqop2.Text = atr1.Text = atr12.Text = atr2.Text = string1.Text = string12.Text = num.Text = "";
        }

        public void addR()
        {
            if (fileR == "")
            { return; }
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(fileR);
            XmlElement xRoot = xDoc.DocumentElement;
            if (r1.Text != "")
            {
                //работаем с правилами
                XmlElement intElem = xDoc.CreateElement("Rule");
                XmlAttribute nameAttr = xDoc.CreateAttribute("Name");
                XmlAttribute nameAttr2 = xDoc.CreateAttribute("General");
                XmlAttribute nameAttr3 = xDoc.CreateAttribute("Type");

                XmlElement IFElem = xDoc.CreateElement("If");
                XmlElement lElem = xDoc.CreateElement("LogOp");
                XmlElement eqopElem = xDoc.CreateElement("EqOp");
                XmlAttribute veAttr = xDoc.CreateAttribute("Value");
                XmlAttribute lAttr = xDoc.CreateAttribute("Value");

                XmlAttribute vaAttr = xDoc.CreateAttribute("Value");
                XmlAttribute vsAttr = xDoc.CreateAttribute("Value");
                XmlElement atElem = xDoc.CreateElement("Attribute");
                XmlElement stElem = xDoc.CreateElement("Number");

                XmlElement closeElem = xDoc.CreateElement("AlOp");
                XmlElement int1Elem = xDoc.CreateElement("Interval");
                XmlElement int2Elem = xDoc.CreateElement("Interval");
                XmlAttribute ve2Attr = xDoc.CreateAttribute("Value");
                XmlAttribute va2Attr = xDoc.CreateAttribute("Value");
                XmlAttribute vs2Attr = xDoc.CreateAttribute("Value");
                XmlElement ThElem = xDoc.CreateElement("Then");
                XmlElement actElem = xDoc.CreateElement("Action");
                XmlAttribute attrAttr = xDoc.CreateAttribute("Attribute");
                XmlAttribute valAttr = xDoc.CreateAttribute("Value");

                XmlText nameText = xDoc.CreateTextNode(r1.Text);
                XmlText generalText = xDoc.CreateTextNode(r2.Text);
                XmlText typeText = xDoc.CreateTextNode(r3.Text);
                XmlText logText = xDoc.CreateTextNode(r4.Text);
                XmlText eq1Text = xDoc.CreateTextNode(r5.Text);
                XmlText at1Text = xDoc.CreateTextNode(r6.Text);
                XmlText numbText = xDoc.CreateTextNode(r7.Text);
                XmlText alopText = xDoc.CreateTextNode(r8.Text);
                XmlText atrText = xDoc.CreateTextNode(r9.Text);
                XmlText valText = xDoc.CreateTextNode(r10.Text);
                XmlText int1Text = xDoc.CreateTextNode(comboBox3.SelectedItem .ToString ());
                XmlText int2Text = xDoc.CreateTextNode(comboBox5.SelectedItem.ToString());

                nameAttr.AppendChild(nameText);
                nameAttr2.AppendChild(generalText);
                nameAttr3.AppendChild(typeText);
                veAttr.AppendChild(logText);
                lAttr.AppendChild(eq1Text);
                vaAttr.AppendChild(at1Text);
                vsAttr.AppendChild(numbText);
                ve2Attr.AppendChild(alopText);
                va2Attr.AppendChild(int1Text );
                vs2Attr.AppendChild(int2Text);
                attrAttr.AppendChild(atrText);
                valAttr.AppendChild(valText);

                intElem.Attributes.Append(nameAttr);
                intElem.Attributes.Append(nameAttr2);
                intElem.Attributes.Append(nameAttr3);
                intElem.AppendChild(IFElem);
                IFElem.AppendChild(lElem);
                lElem.Attributes.Append(veAttr);
                lElem.AppendChild(eqopElem);
                eqopElem.Attributes.Append(lAttr);
                eqopElem.AppendChild(atElem);
                eqopElem.AppendChild(stElem);
                atElem.Attributes.Append(vaAttr);
                stElem.Attributes.Append(vsAttr);
                lElem.AppendChild(closeElem);
                closeElem.Attributes.Append(ve2Attr);
                closeElem.AppendChild(int1Elem);
                closeElem.AppendChild(int2Elem);
                int1Elem.Attributes.Append(va2Attr);
                int2Elem.Attributes.Append(vs2Attr);
                intElem.AppendChild(ThElem);
                ThElem.AppendChild(actElem);
                actElem.Attributes.Append(attrAttr);
                actElem.Attributes.Append(valAttr);
                xRoot.AppendChild(intElem);
                xDoc.Save(fileR);

            }
        }

        //public XmlNode cai()
        //{

        //}

        public void refresh()
        {
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            load();
        }

        public void refreshR()
        {
            comboBox4.Items.Clear();
            loadR();
        }

        public void create()
        {
            XmlTextWriter allen2 = new XmlTextWriter("Allen5.xml", null);
            allen2.WriteStartDocument();
            allen2.WriteStartElement("IntervalsAndEvents");
            allen2.WriteEndElement();
            allen2.Close();
            file = "Allen5.xml";
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(file);
            XmlElement xRoot = xDoc.DocumentElement;
            XmlElement ev = xDoc .CreateElement ("Events");
            XmlElement inter = xDoc .CreateElement ("Intervals");
            xRoot .AppendChild (inter);
            xRoot .AppendChild (ev);
            xDoc.Save(file);
        }

        public void createR()
        {
            XmlTextWriter TKB2 = new XmlTextWriter("TKB5.xml", null);
            TKB2.WriteStartDocument();
            TKB2.WriteStartElement("TKB");
            TKB2.WriteEndElement();
            TKB2.Close();
            fileR = "TKB5.xml";
            XmlDocument xDocR = new XmlDocument();
            xDocR.Load(fileR);
            xDocR.Save(fileR);
        }
             
        public Form1()
        {
            InitializeComponent();
            
        }

        public void Form1_Load(object sender, EventArgs e)
        {
            
            ToolTip t = new ToolTip(); 
            t.SetToolTip(comboBox1 ,"Интервалы");
            t.SetToolTip(comboBox2, "События");
            t.SetToolTip(comboBox3, "Первый интервал");
            t.SetToolTip(comboBox4, "Правила");
            t.SetToolTip(comboBox5, "Второй интервал");  
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            add();
            refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            delete();
            refresh();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            t.Text = "";
            lt1.Text = comboBox1.SelectedItem.ToString() ;
            foreach (intervals n in intervalslist)
            {
                for (int i = 0; i < intervalslist.Count; i++)
                {
                    if (comboBox1.SelectedItem.ToString() == intervalslist[i].name)
                    {
                        
                        for (int x = 0; x < intervalslist[i].qa.Count; x++)
                        {
                            t.Text += "IF\r\n" + intervalslist[i].qa[x].logop + "\r\n" + intervalslist[i].qa[x].Attribute + "\r\n" + intervalslist[i].qa[x].EqOp1 + "\r\n" + intervalslist[i].qa[x].info + "\r\n\r\nTHEN\r\n\r\n" + intervalslist[i].qa[x].flag + " " + intervalslist[i].name + "\r\n\r\n";
                        }
                        return;
                         
                    }
                }
            }
        }

        private void comboBox2_SelectedValueChanged(object sender, EventArgs e)
        {
            t.Text = "";
            lt1.Text = comboBox2.SelectedItem.ToString() ;
            foreach (events n in eventslist)
            {
                for (int i = 0; i < eventslist.Count; i++)
                {
                    if (comboBox2.SelectedItem.ToString() == eventslist[i].name)
                    {

                        for (int x = 0; x < eventslist[i].qa.Count; x++)
                        {
                            t.Text += "IF\r\n" + eventslist[i].qa[x].logop + "\r\n" + eventslist[i].qa[x].Attribute + "\r\n" + eventslist[i].qa[x].EqOp1 + "\r\n" + eventslist[i].qa[x].info + "\r\n\r\nTHEN\r\n\r\n" + eventslist[i].qa[x].flag + " " + eventslist[i].name + "\r\n\r\n";
                        }
                        return;
                    } 
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button4_MouseMove(object sender, MouseEventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
           
        }

        private void выходToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void загрузитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();
            openFileDialog1.ShowDialog();
            file = openFileDialog1.FileName;
            if (file != "openFileDialog1")
            { load(); }
            
        }

        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void создатьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();
            create();
        }

        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            //cai();
        }

        private void t_TextChanged(object sender, EventArgs e)
        {

        }

        private void создатьБЗПToolStripMenuItem_Click(object sender, EventArgs e)
        {
            comboBox4.Items.Clear();
            createR();
        }

        private void загрузитьБЗПToolStripMenuItem_Click(object sender, EventArgs e)
        {
            comboBox4.Items.Clear();
            openFileDialog1.ShowDialog();
            fileR = openFileDialog1.FileName;
            if (fileR != "openFileDialog1")
            { loadR(); }
            
        }

        private void comboBox1_SelectedIndexChanged_2(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            tr.Text = "";
            tr2.Text = "";
            for (int i = 0; i < ruleslist.Count; i++)
            {
                if (comboBox4.SelectedItem.ToString() == ruleslist[i].name)
                { 
                    tr2.Text = ruleslist[i].name;
                    tr.Text = "IF\r\n\r\n        " + ruleslist[i].rul[0].Attribute + "    " + ruleslist[i].rul[0].EqOp1 + "    " + ruleslist[i].rul[0].info + "\r\n\r\n    " + ruleslist[i].rul[0].logop + "\r\n\r\n        " + ruleslist[i].inter1 + "    " + ruleslist[i].alop + "    " + ruleslist[i].inter2 + "\r\n\r\n" + "THEN\r\n\r\n        " + ruleslist[i].rul[1].Attribute + " = " + ruleslist[i].rul[1].info;
                }
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox5.SelectedItem == comboBox3.SelectedItem)
            {
                MessageBox.Show("Выберите другой интервал", "Недопустимое значение", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox5 .SelectedItem == comboBox3 .SelectedItem )
            {
                MessageBox.Show("Выберите другой интервал", "Недопустимое значение", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            deleteR();
            refreshR();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            addR();
            refreshR();
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void label27_Click(object sender, EventArgs e)
        {

        }
        //private void button5_Click(object sender, EventArgs e)
        //{
        //   cai2();
        //}

        //private void button4_Click_2(object sender, EventArgs e)
        //{
        //    cai3();
        //}

       
    }

   
    public class events
    {
       public string name;
       public List<prop> qa = new List<prop>();
        public events()
        { 
        name = "";
        }

    }

    public class prop
    {
        private string EqOp;

        public string EqOp1
        {
            get { return EqOp; }
            set { EqOp = value; }
        }
        public string Attribute;
        public string info;
        public string flag;
        public string logop;
        public prop ()
        { logop = ""; }
    }

    public class intervals
    { 
       public string name;
       public List<prop> qa = new List<prop>();
        public intervals()
        {
            name = "";
        }
    }

    public class rules  
    {
        public string name;
        public string general;
        public string type;
        public string alop;
        public string inter1;
        public string inter2;
        public List<prop> rul = new List<prop>();
        public rules()
        {
            name = "";
        }
    }

}

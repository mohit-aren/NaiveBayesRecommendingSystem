using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class Recommend : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected int CountDistinct()
    {
        string filepath = Server.MapPath("./Docs");

        filepath += "\\Distinct.txt";
        int count = 0;

        if (File.Exists(filepath))
        {
            StreamReader sr = new StreamReader(filepath);
            while (!sr.EndOfStream)
            {
                string word_prev = sr.ReadLine();

                if (word_prev.ToUpper().Trim() != "")
                    count++;
            }
            sr.Close();
        }

        return count;
    }

    protected int getWordCount(string word, string line)
    {
       
        int count = 0;

        string[] words = line.Split(' ');

        for (int index = 0; index < words.Length; index++)
        {
            if (words[index].ToUpper().IndexOf(word.ToUpper()) >= 0)
                count++;
        }

        return count;
    }

    protected int getLineCount(string path)
    {
        StreamReader sr = new StreamReader(path);

        int count = 0;

        while (!sr.EndOfStream)
        {
            string line = sr.ReadLine();

            count++;
        }
        sr.Close();

        return count;
    }

    protected int getTotalWordCount(string path)
    {
        StreamReader sr = new StreamReader(path);

        int count = 0;

        while (!sr.EndOfStream)
        {
            string line = sr.ReadLine();

            string[] words = line.Split(' ');

            for (int index = 0; index < words.Length; index++)
            {
                if (words[index].ToUpper().Trim() != "")
                    count++;
            }
        }
        sr.Close();

        return count;
    }

    protected void MakeDistinct_File(string filepath)
    {
        StreamReader sr = new StreamReader(filepath);

        while (!sr.EndOfStream)
        {
            string line = sr.ReadLine();

            string[] words = line.Split(' ');

            for (int index = 0; index < words.Length; index++)
            {
                MakeDistinctWords(words[index]);
            }
        }
        sr.Close();
    }

    protected void MakeDistinctWords(string word)
    {
        string filepath = Server.MapPath("./Docs");

        filepath += "\\Distinct.txt";

        int exist = 0;
        if (File.Exists(filepath))
        {
            StreamReader sr = new StreamReader(filepath);
            while (!sr.EndOfStream)
            {
                string word_prev = sr.ReadLine();

                if (word_prev.ToUpper() == word.ToUpper())
                    exist = 1;
            }
            sr.Close();
        }
        if (exist == 0)
        {
            StreamWriter sw = new StreamWriter(filepath, true);
            sw.WriteLine(word);
            sw.Close();
        }
    }

    protected void btnCheck_Click(object sender, EventArgs e)
    {
        string filepath = Server.MapPath("./Docs");

        filepath += "\\titles.txt";

        updFile.SaveAs(filepath);
        string filepath2 = Server.MapPath("./Docs");

        filepath2 += "\\urls.txt";

        updUrl.SaveAs(filepath2);
        //MakeDistinct_File(filepath);

        int line1 = getLineCount(filepath);

        double[] prob = new double[line1];
        string[] prods = new string[line1];
        string[] urls = new string[line1];

        int[] recomm = new int[50];

        string filepath1 = Server.MapPath("./Docs");

        filepath1 += "\\Distinct.txt";
        int distinct = getLineCount(filepath1);

        string prod = txtProd.Text;

        StreamReader sr = new StreamReader(filepath);
        StreamReader sr1 = new StreamReader(filepath2);
        int index1 = 0;
        while (!sr.EndOfStream)
        {

            prob[index1] = 1;
            string line = sr.ReadLine();
            string url = sr1.ReadLine();
            prods[index1] = line;
            urls[index1] = url;


            string[] words = prod.Split(' ');
            for (int index = 0; index < words.Length; index++)
            {
                int num = getWordCount(words[index], line) + 1;
                string [] words1 = line.Split(' ');
                int den = words1.Length + distinct;
                prob[index1] *= (double)num / (double)den;

            }

            index1++;
        }
        sr.Close();
        sr1.Close();

        for (int index = 0; index < 50; index++)
        {
            double max_prob = 0.0;

            int max_index = 0;
            for (int j = 0; j < index1; j++)
            {
                if (max_prob < prob[j])
                {
                    max_prob = prob[j];
                    max_index = j;
                }
            }
            recomm[index] = max_index;
            prob[max_index] *= -1;
        }

        string html = "<table>";
        for (int index = 0; index < 50; index++)
        {
            html += "<tr><td>" + prods[recomm[index]] + "</td><td>" + "<img src='" + urls[recomm[index]] + "'></td></tr>";

        }
        html += "</table>";

        capRecomm.Text = html;
    }
    protected void btnDist_Click(object sender, EventArgs e)
    {
        string filepath = Server.MapPath("./Docs");

        filepath += "\\titles.txt";

        MakeDistinct_File(filepath);

    }
}
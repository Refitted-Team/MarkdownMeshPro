using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

public class TMPItem
{
}

public class TMPTextItem : TMPItem
{
    public string Text { get; set; }

    public TMPTextItem(string text)
    {
        Text = text;
    }

    public override string ToString()
    {
        return "TEXT: " + Text;
    }
}

public class TMPImageItem : TMPItem
{
    public string URL { get; set; }

    public TMPImageItem(string url)
    {
        URL = url;
    }

    public override string ToString()
    {
        return "IMAGE: " + URL;
    }
}
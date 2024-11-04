using Markdig.Extensions.Tables;

public class MarkdownMeshProTableRenderer : MarkdownMeshProObjectRenderer<Table>
{
    public static string ExtractText(string text, Markdig.Syntax.Block item)
    {
        var start = item.Span.Start;
        var end = item.Span.End;
        var len = item.Span.Length;

        if (item is Table)
        {
            start--;
            end++;
            len += 2;
        }

        return text.Substring(start, len);
    }
    
    //BEEEG TODO
    protected override void Write(MarkdownMeshProRenderer renderer, Table table)
    {
        renderer.Write("<space=0.3em><mark=#0000003C padding=\"25,25,0,0\">"
            //+ "<font=Miracode SDF>"
        );
        renderer.WriteLine();
        bool didHeaders = false;
        int headerWidths = 0;
        foreach (var rowObj in table)
        {
            var row = (TableRow)rowObj;
            for (int i = 0; i < row.Count; i++)
            {
                var cellObj = row[i];
                renderer.Write('|');
                string cellText = ExtractText(renderer.processingText, cellObj);
                if (!didHeaders)
                    headerWidths += cellText.Length;
                renderer.Write(cellText);
            }

            renderer.Write('|');
            renderer.WriteLine();
            if (!didHeaders)
            {
                didHeaders = true;
                renderer.Write('=', headerWidths + 3);
                renderer.WriteLine();
            }
        }
        renderer.Write('=', headerWidths + 3);
        renderer.WriteLine();
        renderer.WriteLine();
        renderer.Write("</mark>" 
            //+ "</font>"
        );
        /*
        foreach (var rowObj in table)
        {
            var row = (TableRow)rowObj;
            for (int i = 0; i < row.Count; i++)
            {
                var cellObj = row[i];
                var cell = (TableCell)cellObj;
                renderer.Write(cell);
                //write a space after each cell to avoid text being merged with the next cell
                renderer.Write(' ');
            }
            renderer.WriteLine();
        }*/
    }
}
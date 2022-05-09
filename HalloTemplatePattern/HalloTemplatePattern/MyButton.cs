namespace HalloTemplatePattern
{
    internal class MyButton : Button
    {
        int count = 0;
        protected override void OnPaint(PaintEventArgs pevent)
        {
            //base.OnPaint(pevent);
            pevent.Graphics.FillRectangle(Brushes.Gold, this.ClientRectangle);
            count++;
            pevent.Graphics.DrawString($"count: {count}", SystemFonts.DefaultFont, Brushes.Green, this.ClientRectangle);
        }
    }
}

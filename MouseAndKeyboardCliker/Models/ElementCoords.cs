namespace MouseAndKeyboardCliker
{
    public class ElementCoords
    {
        public Coords Field { get; set; }

        public Coords ContextMenuInsert { get; set; }

        public Coords List { get; set; }


        public ElementCoords()
        {

        }

        public ElementCoords(int f_x, int f_y)
        {
            this.Field = new Coords(f_x, f_y);
        }

        public ElementCoords(int f_x, int f_y, int cmi_x, int cmi_y) : this(f_x, f_y)
        {
            this.ContextMenuInsert = new Coords(cmi_x, cmi_y);
        }

        public ElementCoords(int f_x, int f_y, int cmi_x, int cmi_y, int l_x, int l_y) : this(f_x, f_y, cmi_x, cmi_y)
        {
            this.List = new Coords(l_x, l_y);
        }
    }
}

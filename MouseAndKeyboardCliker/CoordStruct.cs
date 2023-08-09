namespace MouseAndKeyboardCliker
{
    public class CoordStruct
    {
        public int field_X { get; set; }
        public int field_Y { get; set; }

        public int contextMenuInsert_X { get; set; }
        public int contextMenuInsert_Y { get; set; }

        public int list_X { get; set; }
        public int list_Y { get; set; }


        public CoordStruct()
        {

        }

        public CoordStruct(int f_x, int f_y)
        {
            this.field_X = f_x;
            this.field_Y = f_y;
        }

        public CoordStruct(int f_x, int f_y, int cmi_x, int cmi_y)
        {
            this.field_X = f_x;
            this.field_Y = f_y;

            this.contextMenuInsert_X = cmi_x;
            this.contextMenuInsert_Y = cmi_y;
        }

        public CoordStruct(int f_x, int f_y, int cmi_x, int cmi_y, int l_x, int l_y)
        {
            this.field_X = f_x;
            this.field_Y = f_y;

            this.contextMenuInsert_X = cmi_x;
            this.contextMenuInsert_Y = cmi_y;

            this.list_X = l_x;
            this.list_Y = l_y;
        }
    }
}

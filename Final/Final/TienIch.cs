namespace Final;

class TienIch
{
    public static void XuatKeNgang(int soLuong)
    {
        XuatKeNgang('=', soLuong);
    }

    public static void XuatKeNgang(char kiTu, int soLuong)
    {
        for (int i = 0; i < soLuong; i++)
        {
            Console.Write(kiTu);
        }

        Console.WriteLine();
    }
}
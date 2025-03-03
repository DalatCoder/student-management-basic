namespace Final;

class Program
{
    static void Main()
    {
        ChayChuongTrinh();
    }

    static void ChayChuongTrinh()
    {
        var menu = new Menu();

        while (true)
        {
            Console.Clear();
            
            menu.XuatMenu();
            var chucNang = menu.ChonMenu();
            
            Console.Clear();
            menu.XuLyChucNang(chucNang);

            if (chucNang == ChucNang.ThoatChuongTrinh)
            {
                break;
            }
        }
    }
}
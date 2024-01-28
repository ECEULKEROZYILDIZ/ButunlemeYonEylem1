namespace ProjectScheduling
{
    class Program
    {
        static void Main(string[] args)
        {
            // Faaliyetlerin sürelerini tanımlayın.
            int[] faaliyetSüreleri = { 4, 3, 5, 2, 10, 10, 1 };

            // Faaliyetlerin öncelik ilişkilerini tanımlayın.
            int[] faaliyetÖncelikIlişkileri = { 2, 1, 2, 2, 1, 2, 2 };

            // Projenin tamamlanma süresini minimize eden bir çözüm bulun.
            int tamamlanmaSuresi = minimizeProjectCompletionTime(faaliyetSüreleri, faaliyetÖncelikIlişkileri);

            // Çözümü yazdırın.
            Console.WriteLine("Projenin tamamlanma süresi: " + tamamlanmaSuresi);
        }

        static int minimizeProjectCompletionTime(int[] faaliyetSüreleri, int[] faaliyetÖncelikIlişkileri)
        {
            // İlk olarak, her bir faaliyetin başlama tarihini hesaplayacağız.
            int[] faaliyetBaslamaTarihi = new int[faaliyetSüreleri.Length];
            for (int i = 0; i < faaliyetSüreleri.Length; i++)
            {
                faaliyetBaslamaTarihi[i] = 0;
                for (int j = 0; j < i; j++)
                {
                    if (faaliyetÖncelikIlişkileri[i] == faaliyetÖncelikIlişkileri[j])
                    {
                        faaliyetBaslamaTarihi[i] = Math.Max(faaliyetBaslamaTarihi[i], faaliyetBaslamaTarihi[j] + faaliyetSüreleri[j]);
                    }
                }
            }

            // Ardından, projenin tamamlanma süresini hesaplayacağız.
            int tamamlanmaSuresi = faaliyetBaslamaTarihi[faaliyetSüreleri.Length - 1] + faaliyetSüreleri[faaliyetSüreleri.Length - 1];

            return tamamlanmaSuresi;
        }
    }
}
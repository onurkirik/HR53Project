using System.ComponentModel.DataAnnotations;

namespace HR53.Web.Validations
{
    public class IdentityCardNoValidation : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value == null) return false;

            string gelenTc = value.ToString().Trim();
            int teklerToplami = 0;
            int ciftlerToplami = 0;
            int toplam = 0;

            if (gelenTc.Length != 11) return false;

            if (Convert.ToInt32(gelenTc[0].ToString()) == 0) return false;

            if (gelenTc.Any(k => !Char.IsDigit(k))) return false;

            for (int i = 0; i <= 9; i++)
            {
                if (i % 2 != 0 && i <= 7)
                {
                    ciftlerToplami += Convert.ToInt32(gelenTc[i].ToString());
                }

                else if (i % 2 == 0 && i <= 8)
                {
                    teklerToplami += Convert.ToInt32(gelenTc[i].ToString());
                }

                toplam += Convert.ToInt32(gelenTc[i].ToString());
            }

            if (((7 * teklerToplami) - (ciftlerToplami)) % 10 != Convert.ToInt32(gelenTc[10].ToString()))
            {
                return false;
            }

            if (toplam % 10 != Convert.ToInt32(gelenTc[10].ToString()))
            {
                return false;
            }
            return true;
        }
    }
}

using EpiHot.Models;
using EpiHot.Models.Dto;

namespace EpiHot.Services
{
    public class FiscalCodeSvc
    {
        public string CalculateFiscalCode(FiscalCodeDto2 data)
        {
            // Calcolo del nome
            string surnameCode = CalculateSurname(data.CustomerSurname);
            // Calcolo del cognome
            string nameCode = CalculateName(data.CustomerName);
            // Conversione del genere da stringa a enum Gender
            Gender gender = data.CustomerGender == "M" ? Gender.M : Gender.F;
            // Calcolo della data di nascita
            string birthDateCode = CalculateBirthDate(data.CustomerBirthDate, gender);
            // Calcolo del codice del comune di nascita
            string birthCityCode = CalculateBirthCity(data.CustomerBirthCity);
            // Calcolo del codice fiscale parziale
            string partialCode = surnameCode + nameCode + birthDateCode + birthCityCode;
            // Calcolo del carattere di controllo
            char controlChar = CalculateControlChar(partialCode);
            // Restituzione del codice fiscale completo
            return partialCode + controlChar;
        }

        public string CalculateSurname(string surname)
        {
            // Rimozione spazi
            surname = surname.Replace(" ", "");
            // Tutte le vocali esistenti
            string allVowels = "AEIOUaeiouÀÈÌÒÙàèìòùÁÉÍÓÚáéíóúÂÊÎÔÛâêîôûÄËÏÖÜäëïöü";
            // Filtro consonanti
            string consonants = new string(surname.Where(c => !allVowels.Contains(c)).ToArray());
            // Filtro vocali
            string vowels = new string(surname.Where(c => allVowels.Contains(c)).ToArray());
            // Combinazione consonanti e vocali, se insufficienti verranno aggiunte X
            string code = (consonants + vowels).PadRight(3, 'X').Substring(0, 3);
            // Restituzione del codice in maiuscolo
            return code.ToUpper();
        }

        public string CalculateName(string name)
        {
            // Rimozione spazi
            name = name.Replace(" ", "");
            // Tutte le vocali esistenti
            string allVowels = "AEIOUaeiouÀÈÌÒÙàèìòùÁÉÍÓÚáéíóúÂÊÎÔÛâêîôûÄËÏÖÜäëïöü";
            // Filtro consonanti
            string consonants = new string(name.Where(c => !allVowels.Contains(c)).ToArray());
            // Filtro vocali
            string vowels = new string(name.Where(c => allVowels.Contains(c)).ToArray());
            // Se ci sono 4 o più consonanti, prendere la prima, la terza e la quarta
            if (consonants.Length >= 4)
            {
                consonants = $"{consonants[0]}{consonants[2]}{consonants[3]}";
            }
            // Combinazione consonanti e vocali, se insufficienti verranno aggiunte X
            string code = (consonants + vowels).PadRight(3, 'X').Substring(0, 3);
            // Restituzione del codice in maiuscolo
            return code.ToUpper();
        }

        public string CalculateBirthDate(DateOnly birthDate, Gender gender)
        {
            // Estrazione ultime due cifre dell'anno
            string year = birthDate.Year.ToString().Substring(2, 2);
            // Ottenimento del codice corrispondente al mese
            string month = GetMonthCode(birthDate.Month);
            // Calcolo del giorno in base al genere
            string day = (gender == Gender.F) ? (birthDate.Day + 40).ToString("D2") : birthDate.Day.ToString("D2");
            // Restituzione del codice completo (anno, mese e giorno)
            return year + month + day;
        }

        private static string GetMonthCode(int month)
        {
            // Restituzione del codice mese in base al mese
            return month switch
            {
                1 => "A",
                2 => "B",
                3 => "C",
                4 => "D",
                5 => "E",
                6 => "H",
                7 => "L",
                8 => "M",
                9 => "P",
                10 => "R",
                11 => "S",
                12 => "T",
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        public string CalculateBirthCity(City birthCity)
        {
            return birthCity.CadastralCode;
        }

        private char CalculateControlChar(string partialCode)
        {
            // Dizionario di conversione per i numeri pari
            Dictionary<char, int> evenConversion = new Dictionary<char, int>
            {
                { '0', 0 }, { '1', 1 }, { '2', 2 }, { '3', 3 }, { '4', 4 }, { '5', 5 }, { '6', 6 }, { '7', 7 }, { '8', 8 }, { '9', 9 },
                { 'A', 0 }, { 'B', 1 }, { 'C', 2 }, { 'D', 3 }, { 'E', 4 }, { 'F', 5 }, { 'G', 6 }, { 'H', 7 }, { 'I', 8 }, { 'J', 9 },
                { 'K', 10 }, { 'L', 11 }, { 'M', 12 }, { 'N', 13 }, { 'O', 14 }, { 'P', 15 }, { 'Q', 16 }, { 'R', 17 }, { 'S', 18 }, { 'T', 19 },
                { 'U', 20 }, { 'V', 21 }, { 'W', 22 }, { 'X', 23 }, { 'Y', 24 }, { 'Z', 25 }
            };

            // Dizionario di conversione per i numeri dispari
            Dictionary<char, int> oddConversion = new Dictionary<char, int>
            {
                { '0', 1 }, { '1', 0 }, { '2', 5 }, { '3', 7 }, { '4', 9 }, { '5', 13 }, { '6', 15 }, { '7', 17 }, { '8', 19 }, { '9', 21 },
                { 'A', 1 }, { 'B', 0 }, { 'C', 5 }, { 'D', 7 }, { 'E', 9 }, { 'F', 13 }, { 'G', 15 }, { 'H', 17 }, { 'I', 19 }, { 'J', 21 },
                { 'K', 1 }, { 'L', 0 }, { 'M', 5 }, { 'N', 7 }, { 'O', 9 }, { 'P', 13 }, { 'Q', 15 }, { 'R', 17 }, { 'S', 19 }, { 'T', 21 },
                { 'U', 1 }, { 'V', 0 }, { 'W', 5 }, { 'X', 7 }, { 'Y', 9 }, { 'Z', 13 }
            };

            // Dizionario di conversione per il resto di 26
            Dictionary<int, char> remainderToChar = new Dictionary<int, char>
            {
                { 0, 'A' }, { 1, 'B' }, { 2, 'C' }, { 3, 'D' }, { 4, 'E' }, { 5, 'F' }, { 6, 'G' }, { 7, 'H' }, { 8, 'I' }, { 9, 'J' },
                { 10, 'K' }, { 11, 'L' }, { 12, 'M' }, { 13, 'N' }, { 14, 'O' }, { 15, 'P' }, { 16, 'Q' }, { 17, 'R' }, { 18, 'S' }, { 19, 'T' },
                { 20, 'U' }, { 21, 'V' }, { 22, 'W' }, { 23, 'X' }, { 24, 'Y' }, { 25, 'Z' }
            };

            // Somma dei numeri pari e dispari
            int sumEven = 0;
            int sumOdd = 0;

            // Calcolo della somma dei numeri pari e dispari
            for (int i = 0; i < partialCode.Length; i++)
            {
                char c = partialCode[i];
                if (i % 2 == 0) // Dispari (0-based, ma 1-based nei documenti)
                {
                    sumOdd += oddConversion[c];
                }
                else // Pari (0-based, ma 1-based nei documenti)
                {
                    sumEven += evenConversion[c];
                }
            }

            // Calcolo del totale e del resto
            int totalSum = sumEven + sumOdd;
            int remainder = totalSum % 26;

            // Restituzione del carattere di controllo
            return remainderToChar[remainder];
        }
    }
}


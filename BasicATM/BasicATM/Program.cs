using System;
public class cardInf
{
    string cardNumber;
    int pin;
    string firstName;
    string lastName;
    double balance;

    public cardInf(string cardNumber, int pin, string firstName, string lastName, double Balance)
    {
        this.cardNumber = cardNumber;
        this.pin = pin;
        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = Balance;
    }
    public string getNum()
    {
        return cardNumber;
    }
    public int getPin()
    {
        return pin;
    }
    public string getFirstName()
    {
        return firstName;
    }
    public string getLastName()
    {
        return lastName;
    }
    public double getBalance()
    {
        return balance;
    }

    public void setNum(string newCardNum)
    {
        cardNumber = newCardNum;
    }
    public void setPin(int newPin)
    {
        pin = newPin;
    }
    public void setFirstName(string newFirstName)
    {
        firstName = newFirstName;
    }
    public void setLastName(string newLastName)
    {
        lastName = newLastName;
    }
    public void setBalance(double newBalance)
    {
        balance = newBalance;
    }
    public static void Main(string[] args)
    {
        void printOptions()
        {
            Console.WriteLine("Yapmak İstediğiniz İşlemi Sayısıyla Birlikte Seçiniz...");
            Console.WriteLine("1 - Para Yatırma");
            Console.WriteLine("2 - Para Çekme");
            Console.WriteLine("3 - Bakiye Sorgulama");
            Console.WriteLine("4 - Çıkış");
        }
        void deposit(cardInf currentUser)
        {
            Console.WriteLine("Ne kadar Para Yatıracaksınız ? ");
            double deposit = Double.Parse(Console.ReadLine());
            currentUser.setBalance(currentUser.getBalance()+deposit);
            Console.WriteLine("Paranız yatırılmıştır. Yeni bakiyeniz : " + currentUser.getBalance());
        }
        void withdraw(cardInf currentUser)
        {
            Console.WriteLine("Ne kadar Para Çekmek İstiyorsunuz ? ");
            double withdraw = Double.Parse(Console.ReadLine());
            //Kullanıcının yeterli parası olup olmadığını kontrol etme . . . 
            if (currentUser.getBalance() < withdraw)
            {
                Console.WriteLine("Yetersiz bakiye...");
            }
            else
            {
                currentUser.setBalance(currentUser.getBalance() - withdraw);
                Console.WriteLine("Para Çekim İşlemi Başarılı...");
            }
        }
        void balance(cardInf currentUser)
        {
            Console.WriteLine("Şu an ki bakiyeniz : " + currentUser.getBalance());
        }
        List<cardInf> cardInfs = new List<cardInf>();
        cardInfs.Add(new cardInf("4532772818527395", 1234, "Bora", "Cirit", 150.31));
        cardInfs.Add(new cardInf("4532761841325802", 4321, "Ashley", "Jones", 321.13));
        cardInfs.Add(new cardInf("5128381368581872", 9999, "Frida", "Dickerson", 105.59));
        cardInfs.Add(new cardInf("6011188364697109", 2468, "Muneeb", "Harding", 851.84));
        cardInfs.Add(new cardInf("3490693153147110", 4826, "Dawn", "Smith", 54.27));

        Console.WriteLine("Welcome to BasicATM :) ");
        Console.WriteLine("Lütfen Banka Kartınızı Yerleştirin: ");
        string debitCardNum = string.Empty;
        cardInf currentUser;

        while (true)
        {
            try
            {
                debitCardNum = Console.ReadLine();
                //Müşteri kart bilgisini kontrol eder...
                currentUser = cardInfs.FirstOrDefault(a => a.cardNumber == debitCardNum);
                if (currentUser != null) { break; }
                else { Console.WriteLine("Kart Tanınmadı , Lütfen Doğru Kartı Takınız..."); }
            }
            catch { Console.WriteLine("Kart Tanınmadı , Lütfen Doğru Kartı Takınız..."); }
        }

        Console.WriteLine("Lütfen Şifrenizi Girin:");
        int userPin = 0;
        while (true)
        {
            try
            {
                userPin = int.Parse(Console.ReadLine());
                //Müşteri kart bilgisini kontrol eder...
                if (currentUser.getPin() == userPin) { break; }
                else { Console.WriteLine("Yanlış Şifre Lütfen Tekrar Deneyin."); }
            }
            catch { Console.WriteLine("Yanlış Şifre Lütfen Tekrar Deneyin."); }
        }
        Console.WriteLine("Hoşgeldiniz" + currentUser.getFirstName() + ":)");
        int option = 0;
        do
        {
            printOptions();
            try
            {
                option = int.Parse(Console.ReadLine());
            }
            catch { }
            if (option == 1) { deposit(currentUser); }
            else if (option == 2) { withdraw(currentUser); }
            else if (option == 3) { balance(currentUser); }
            else if (option == 4) { break; }
            else { option= 0; }
        }
        while (option != 4);
        Console.WriteLine("Teşekkür Eder,İyi Günler Dileriz...");
    }

}
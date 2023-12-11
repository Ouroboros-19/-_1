using System.Collections;
using System.Collections.Generic;
using System.Linq;
class Proga
{
    static void Main()
    {
        
        int S;
        string T;
        
        Staff staff = new Staff();

        Console.WriteLine("Кол-во сотрудников");
        S =Convert.ToInt32(Console.ReadLine());
        staff.Data_Entry(S);

        Console.WriteLine("Табельный номер интересующего сотрудника");
        T=Console.ReadLine();
        staff.employee_search(T);
        
        Client client = new Client();
        int C, C2, Pass, Check;
        Console.WriteLine("Введите кол-во клиентов");
        C=Convert.ToInt32(Console.ReadLine());
        client.Data_Client(C);
        
        Console.WriteLine("Введите паспортные данные интересующего клиента");
        Pass= Convert.ToInt32(Console.ReadLine());
        client.Client_withdrawal(Pass,C);
        
        Console.WriteLine("Возможный новый клиент");
        C2 = client.Add_Client(C);
        if (C2 != C) 
        { 
            Console.WriteLine("Добавление нового клиента в базу"); 
            client.Data_Client(1); 
            Console.WriteLine("Клиент добавлен в базу"); 
        }
        else Console.WriteLine("Клиент уже в базе");
        
        Console.WriteLine("Проверка наличие счета");
        Console.WriteLine("Введите паспортные данные интересующего клиента");
        Pass = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Введите интересующий счет 2-RUB 3-USD");
        Check = Convert.ToInt32(Console.ReadLine());
        client.Check_Bank_Account(Pass, Check,C);
        
        Console.WriteLine("Пополнение счета");
        Console.WriteLine("Введите паспортные данные интересующего клиента");
        Pass = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Введите интересующий счет 1-RUP 2-RUB 3-USD");
        Check = Convert.ToInt32(Console.ReadLine());
        client.Bank_Account_Refill(Pass, Check, C);
        
        Console.WriteLine("Снятие со счета");
        Console.WriteLine("Введите паспортные данные интересующего клиента");
        Pass = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Введите интересующий счет 1-RUP 2-RUB 3-USD");
        Check = Convert.ToInt32(Console.ReadLine());
        client.Bank_Account_Take(Pass, Check, C);
        
        Console.WriteLine("Блокировка");
        Console.WriteLine("Введите паспортные данные интересующего клиента");
        Pass = Convert.ToInt32(Console.ReadLine());
        client.Client_Block(Pass, C);
        Console.WriteLine("Проверка блокировки");
        Console.WriteLine("Введите интересующий счет 1-RUP 2-RUB 3-USD");
        Check = Convert.ToInt32(Console.ReadLine());
        client.Bank_Account_Refill(Pass, Check, C);
        
        Console.WriteLine("Удаленние счета в банке");
        Console.WriteLine("Введите паспортные данные интересующего клиента");
        Pass = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Введите интересующий счет 1-RUP 2-RUB 3-USD");
        Check = Convert.ToInt32(Console.ReadLine());
        client.Bank_Account_Delete(Pass,Check, C);
        
        Console.WriteLine("Удаление пользователя");
        Console.WriteLine("Введите паспортные данные интересующего клиента");
        Pass = Convert.ToInt32(Console.ReadLine());
        client.Client_Delete(Pass,C);
        C--;
        
        client.Conclusion(C);
    }
}
class Client
{
    private int Passport;
    private string FIO;
    private double RUP, RUB, USD;
    private double[][] cashflow;
    public Client()
    {
        this.FIO = FIO;
        this.Passport = Passport;
        this.RUP = RUP;
        this.RUB = RUB;
        this.USD = USD;
        this.cashflow = cashflow;
    }
    public void Data_Client(int k)
    {
        int a;
        cashflow = new double[k][];
        for (int i = 0; i < k; i++)
        {
            Console.WriteLine("Введите ФИО");
            FIO = Console.ReadLine();
            Console.WriteLine("Введите паспортные данные");
            Passport = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите сумму на счету в рублях ПМР");
            RUP = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите счета, которые хотите открыть: 0 - Рубли РФ, 1 - Доллары, 2 - РФ и Доллары, 3 -  Не открывать доп счета ");
            a = Convert.ToInt32(Console.ReadLine());
            switch (a)
            {
                case 0:
                    Console.WriteLine("Введите сумму на счету в рублях РФ");
                    RUB = Convert.ToDouble(Console.ReadLine());
                    USD = -0;
                    cashflow[i] = new double[] { Passport, RUP, RUB, USD };
                    break;
                case 1:
                    Console.WriteLine("Введите сумму на счету в долларах");
                    USD = Convert.ToDouble(Console.ReadLine());
                    RUB = -0;
                    cashflow[i] = new double[] { Passport, RUP, RUB, USD };
                    break;
                case 2:
                    Console.WriteLine("Введите сумму на счету в рублях РФ");
                    RUB = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Введите сумму на счету в долларах");
                    USD = Convert.ToDouble(Console.ReadLine());
                    cashflow[i] = new double[] { Passport, RUP, RUB, USD };
                    break;
                case 3:
                    RUB = -0;
                    USD = -0;
                    cashflow[i] = new double[] { Passport, RUP, RUB, USD };
                    break;
            }
        }
    }
    public void Client_withdrawal(double T,int n)
    {
        int index=0;
        for(int i=0; i<n; i++)
        {
            if (cashflow[i][0] == T) index = i;
        }
        Console.WriteLine($"\nСчета клиента {cashflow[index][0]}:");
        if (cashflow[index].Length == 2) Console.WriteLine($"RUP={cashflow[index][1]}");
        if (cashflow[index].Length == 3) Console.WriteLine($"RUP={cashflow[index][1]} RUB={cashflow[index][2]}");
        if (cashflow[index].Length == 4) Console.WriteLine($"RUP={cashflow[index][1]} RUB={cashflow[index][2]} USD={cashflow[index][3]}");
    }
    public int Add_Client(int n)
    {
        double Pass,a=0;
        Console.WriteLine("Введите для проверки паспортные данные нового клиента");
        Pass = Convert.ToInt32(Console.ReadLine());
        for (int i=0;i<n;i++)
        {
            if (cashflow[i][0] != Pass)
            {
                a = 1; 
            }
        }
        if (a==0) return n;
        else return n+1;
    }
    public void Check_Bank_Account(int Pass, int Check, int n)
    {
        int index_Pass = 0, YN;
        for (int i = 0; i < n; i++)
        {
            if (cashflow[i][0] == Pass) { index_Pass = i; break; }
        }
        if (cashflow[index_Pass][0] < 0) Console.WriteLine("Пользователь заблокирова");
        else
        {
            if (cashflow[index_Pass][Check] == -0)
            {
                Console.WriteLine("Счета нет");
                Console.WriteLine("Желаете открыть? 1-Да 2-Нет");
                YN = Convert.ToInt32(Console.ReadLine());
                if (YN == 1)
                {
                    switch (Check)
                    {
                        case 2:
                            Console.WriteLine("Счет создан");
                            cashflow[index_Pass][Check] = 0;
                            break;
                        case 3:
                            Console.WriteLine("Счет создан");
                            cashflow[index_Pass][Check] = 0;
                            break;
                    }
                }
            }
            else
            {
                switch (Check)
                {
                    case 2:
                        Console.WriteLine($"Счет есть его баланс: RUB = {cashflow[index_Pass][2]}");
                        break;
                    case 3:
                        Console.WriteLine($"Счет есть его баланс: USD = {cashflow[index_Pass][3]}");
                        break;
                }
            }
        }
    }
    public void Bank_Account_Refill(int Pass, int Check, int n)
    {
        int index_Pass = 0;
        double Refills;
        for (int i = 0; i < n; i++)
        {
            if (cashflow[i][0] == Pass) { index_Pass = i; break; }
        }
        if (cashflow[index_Pass][0] < 0) Console.WriteLine("Пользователь заблокирова");
        else if (cashflow[index_Pass][1] == -0 || cashflow[index_Pass][2] == -0 || cashflow[index_Pass][3] == -0 ) Console.WriteLine("Счета нет");
        else
        {
            switch (Check)
            {
                case 1:
                    Console.WriteLine("Сумма пополнения");
                    Refills = Convert.ToDouble(Console.ReadLine());
                    cashflow[index_Pass][Check] += Refills;
                    Console.WriteLine($"RUP={cashflow[index_Pass][Check]}");
                    break;
                case 2:
                    Console.WriteLine("Сумма пополнения");
                    Refills = Convert.ToDouble(Console.ReadLine());
                    cashflow[index_Pass][Check] += Refills;
                    Console.WriteLine($"RUB={cashflow[index_Pass][Check]}");
                    break;
                case 3:
                    Console.WriteLine("Сумма пополнения");
                    Refills = Convert.ToDouble(Console.ReadLine());
                    cashflow[index_Pass][Check] += Refills;
                    Console.WriteLine($"USD={cashflow[index_Pass][Check]}");
                    break;
            }
        }
    }
    public void Bank_Account_Take(int Pass, int Check, int n)
    {
        int index_Pass = 0;
        double Takes, result;
        for (int i = 0; i < n; i++)
        {
            if (cashflow[i][0] == Pass) { index_Pass = i; break; }
        }
        if (cashflow[index_Pass][0] < 0) Console.WriteLine("Пользователь заблокирова");
        else if (cashflow[index_Pass][1] == -0 || cashflow[index_Pass][2] == -0 || cashflow[index_Pass][3] == -0) Console.WriteLine("Счета нет");
        else
        {
            switch (Check)
            {
                case 1:
                    Console.WriteLine("Введите сумму снятия");
                    Takes = Convert.ToDouble(Console.ReadLine());
                    result = cashflow[index_Pass][Check] - Takes;
                    if (result < 0) Console.WriteLine("Нельзя снять данную сумму (в долг не даём)");
                    else Console.WriteLine($"Остаток RUP={cashflow[index_Pass][Check] - Takes}");
                    break;
                case 2:
                    Console.WriteLine("Введите сумму снятия");
                    Takes = Convert.ToDouble(Console.ReadLine());
                    result = cashflow[index_Pass][Check] - Takes;
                    if (result < 0) Console.WriteLine("Нельзя снять данную сумму (в долг не даём)");
                    else Console.WriteLine($"Остаток RUB={cashflow[index_Pass][Check] - Takes}");
                    break;
                case 3:
                    Console.WriteLine("Введите сумму снятия");
                    Takes = Convert.ToDouble(Console.ReadLine());
                    result = cashflow[index_Pass][Check] - Takes;
                    if (result < 0) Console.WriteLine("Нельзя снять данную сумму (в долг не даём)");
                    else Console.WriteLine($"Остаток USD={cashflow[index_Pass][Check] - Takes}");
                    break;
            }
        }
    }
    public void Client_Block(int Pass, int n)
    {
        int index_Pass = 0;
        for (int i = 0; i < n; i++)
        {
            if (cashflow[i][0] == Pass) { index_Pass = i; break; }
        }
        cashflow[index_Pass][0] *= -1;
        Console.WriteLine($"Пользователь: {cashflow[index_Pass][0]*-1} заблокирован");
    }
    public void Bank_Account_Delete(int Pass,int Check,int n)
    {
        int index_Pass = 0;
        for (int i = 0; i < n; i++)
        {
            if (cashflow[i][0] == Pass) { index_Pass = i; break; }
        }
        if (cashflow[index_Pass][0] < 0) Console.WriteLine("Пользователь заблокирова");
        else if (Check==1) Console.WriteLine("Нельзя удалить данный счет. Произведите удаленние аккаунта");
        else if (cashflow[index_Pass][Check] == -0) Console.WriteLine("Счета нет");
        else
        {
            cashflow[index_Pass][Check] = -0;
            Console.WriteLine("Счет удалён");
        }
    }
    public void Client_Delete(int Pass, int n)
    {
        int index_Pass = 0;
        for (int i = 0; i < n; i++)
        {
            if (cashflow[i][0] == Pass) { index_Pass = i; break; }
        }
        List<double[]> list_cashflow = cashflow.ToList();
        list_cashflow.RemoveAt(index_Pass);
        cashflow = list_cashflow.ToArray();
        Console.WriteLine("Пользователь удалён");
    }
    public void Conclusion(int n)
    {
        int a;
        for(int i=0;i<n;i++)
        {
            if (cashflow[i][2]==-0 & cashflow[i][3]==-0) Console.WriteLine($"Пасспортные данные: {cashflow[i][0]} \nСчет: RUP = {cashflow[i][1]}");
            else if (cashflow[i][2] == -0) Console.WriteLine($"Пасспортные данные: {cashflow[i][0]} \nСчета: RUP = {cashflow[i][1]} USD = {cashflow[i][3]}");
            else if (cashflow[i][3] == -0) Console.WriteLine($"Пасспортные данные: {cashflow[i][0]} \nСчета: RUP = {cashflow[i][1]} RUB = {cashflow[i][2]}");
            else Console.WriteLine($"Пасспортные данные: {cashflow[i][0]} \nСчета: RUP = {cashflow[i][1]} RUB = {cashflow[i][2]} USD = {cashflow[i][3]}");
        }
    }
}
class Staff
{
    private string Number, Phone, Position, FIO;
    private List<string> list = new List<string>();
    public Staff () 
    { 
        this.FIO=FIO;
        this.Number = Number;
        this.Phone = Phone;
        this.Position = Position;
        this.list = list;
    }
    public void Data_Entry(int n)
    {
        while (n > 0)
        {
            Console.WriteLine("Табельный номер");
            Number = Console.ReadLine();
            Console.WriteLine("Телефонный номер");
            Phone = Console.ReadLine();
            Console.WriteLine("ФИО");
            FIO = Console.ReadLine();
            Console.WriteLine("Должность");
            Position = Console.ReadLine();
            list.Add(Number);
            list.Add(Phone);
            list.Add(FIO);
            list.Add(Position);
            n--;
        }
    }
    public void employee_search(string T)
    {
        int index;
        index=list.BinarySearch(T);
        var selected = list.Skip(index).Take(4);
        Console.WriteLine(string.Join(" ", selected));
    }
}
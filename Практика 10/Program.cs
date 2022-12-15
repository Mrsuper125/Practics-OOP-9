using System;

internal class Program
{
    static int count;
    
    public static int F(int n){
        count++;
        if (n <= 5){
            return n + 15;
        }
        else{
            if (n % 2 == 0){
                return F(n/2) + n*n*n - 1;
            }
            else{
                return F(n-1) + 2*n*n + 1;
            }
        }
    }
    
    public static int countEights(int n){
        int res = 0;
        while (n > 0){
            if (n%10 == 8) res++;
            n/=10;
        }
        return res;
    }
    
    public static void Main(string[] args)
    {
        int res = 0;
        for (int i = 1; i <= 1000; i++){
            if (countEights(F(i))>=2) res++;
        }
        Console.WriteLine(res);
    }
}
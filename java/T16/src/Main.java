import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);

        System.out.print("Give me a number: ");
        int n1 = scan.nextInt();

        System.out.print("Give me a second number: ");
        int n2 = scan.nextInt();

        int n1_3 = (int) Math.pow(n1, 3);
        int n2_3 = (int) Math.pow(n2, 3);

        int total = n1_3 + n2_3;

        System.out.printf("The sum of the two numbers cubed is %d %n", total);

        System.out.printf("%d^3 + %d^3 = %d + %d = %d", n1, n2, n1_3, n2_3, total);
    }
}
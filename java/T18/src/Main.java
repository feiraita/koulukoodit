import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);

        System.out.print("Give me a double (,): ");
        double input = scan.nextDouble();

        int smaller = (int)Math.floor(input);
        int bigger = (int)Math.ceil(input);

        System.out.println("Smaller integer: " + smaller);
        System.out.println("Bigger integer: " + bigger);
    }
}
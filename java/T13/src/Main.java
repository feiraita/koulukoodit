import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);

        System.out.print("Give number of kilometers: ");
        float distance = scan.nextFloat();

        System.out.print("Give used time in format hours minutes seconds: ");
        int hours = scan.nextInt();
        int minutes = scan.nextInt();
        int seconds = scan.nextInt();

        int totalSeconds = hours * 3600 + minutes * 60 + seconds;

        float kmh = (distance / totalSeconds) * 3600;

        System.out.printf("Your average speed was %.2f kilometers per hour.", kmh);
    }
}
